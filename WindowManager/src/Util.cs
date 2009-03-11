// Util.cs
// 
// Copyright (C) 2009 GNOME Do
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Wnck;

namespace WindowManager
{
	
	
	public static class Util
	{
		static string RemapFile {
			get { return Path.Combine (Do.Platform.Services.Paths.UserDataDirectory, "RemapFile"); }
		}
		
		static IEnumerable<string> BadPrefixes {
			get {
				yield return "gksu";
				yield return "sudo";
				yield return "java";
				yield return "mono";
				yield return "ruby";
				yield return "padsp";
				yield return "aoss";
				yield return "python";
				yield return "python2.4";
				yield return "python2.5";
			}
		}
		
		static Dictionary<string, string> RemapDictionary { get; set; }
		
		static List<Application> application_list;
		static bool application_list_update_needed;
		
		static Dictionary<int, string> exec_lines = new Dictionary<int, string> ();
		static DateTime last_update = new DateTime (0);
		
		static Util ()
		{
			Wnck.Screen.Default.WindowClosed += delegate {
				application_list_update_needed = true;
			};
			
			Wnck.Screen.Default.WindowOpened += delegate {
				application_list_update_needed = true;
			};
			
			Wnck.Screen.Default.ApplicationOpened += delegate {
				application_list_update_needed = true;
			};
			
			Wnck.Screen.Default.ApplicationClosed += delegate {
				application_list_update_needed = true;
			};
			
			BuildRemapDictionary ();
		}
		
		static void BuildRemapDictionary ()
		{
			RemapDictionary = new Dictionary<string, string> ();
			if (!File.Exists (RemapFile)) {
				RemapDictionary ["banshee.exe"] = "banshee";
				RemapDictionary ["banshee-1"] = "banshee";
				
				StreamWriter writer = null;
				try {
					writer = new StreamWriter (RemapFile);
					writer.WriteLine ("# Docky Remap File");
					writer.WriteLine ("# Add key value pairs following dictionary syntax");
					writer.WriteLine ("# key, value");
					writer.WriteLine ("# key, altKey, value");
					writer.WriteLine ("# Lines starting with # are comments, otherwise # is a valid character");
					
					foreach (KeyValuePair<string, string> kvp in RemapDictionary) {
						writer.WriteLine ("{0}, {1}", kvp.Key, kvp.Value);
					}
					writer.Close ();
				} finally {
					if (writer != null)
						writer.Dispose ();
				}
			} else {
				StreamReader reader = null;
				try {
					reader = new StreamReader (RemapFile);
					
					string line;
					while (!reader.EndOfStream) {
						line = reader.ReadLine ();
						if (line.StartsWith ("#") || !line.Contains (","))
							continue;
						string [] array = line.Split (',');
						if (array.Length < 2 || array [0].Length == 0)
							continue;
						
						string val = array [array.Length - 1].Trim ().ToLower ();
						if (string.IsNullOrEmpty (val))
							continue;
						
						for (int i=0; i < array.Length - 1; i++) {
							string key = array [i].Trim ().ToLower ();
							if (string.IsNullOrEmpty (key))
								continue;
							RemapDictionary [key] = val;
						}
					}
					
					reader.Close ();
				} catch {
					Do.Platform.Log.Error ("Could not read remap file");
					RemapDictionary = new Dictionary<string, string> ();
					RemapDictionary ["banshee.exe"] = "banshee";
					RemapDictionary ["banshee-1"] = "banshee";
				} finally {
					if (reader != null)
						reader.Dispose ();
				}
			}
		}
		
		/// <summary>
		/// Returns a list of all applications on the default screen
		/// </summary>
		/// <returns>
		/// A <see cref="Application"/> array
		/// </returns>
		public static List<Application> GetApplications ()
		{
			if (application_list == null || application_list_update_needed) {
				application_list = new List<Application> ();
				foreach (Window w in Wnck.Screen.Default.Windows) {
					if (!application_list.Contains (w.Application))
						application_list.Add (w.Application);
				}
			}
			return application_list;
		}
		
		/// <summary>
		/// Gets the command line excec string for a PID
		/// </summary>
		/// <param name="pid">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public static string CmdLineForPid (int pid)
		{
			StreamReader reader;
			string cmdline = null;
			
			try {
				string procPath = new [] { "/proc", pid.ToString (), "cmdline" }.Aggregate (Path.Combine);
				reader = new StreamReader (procPath);
				cmdline = reader.ReadLine ().Replace (Convert.ToChar (0x0), ' ');
				reader.Close ();
				reader.Dispose ();
			} catch { }
			
			return cmdline;
		}
		
		/// <summary>
		/// Returns a list of applications that match an exec string
		/// </summary>
		/// <param name="exec">
		/// A <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// A <see cref="List"/>
		/// </returns>
		public static List<Application> GetApplicationList (string exec)
		{
			List<Application> apps = new List<Application> ();
			if (string.IsNullOrEmpty (exec))
				return apps;
			
			exec = ProcessExecString (exec);
			
			UpdateExecList ();

			foreach (KeyValuePair<int, string> kvp in exec_lines) {
				if (kvp.Value != null && kvp.Value.Contains (exec)) {
					foreach (Application app in GetApplications ()) {
						if (app == null)
							continue;
						
						if (app.Pid == kvp.Key || app.Windows.Any (w => w.Pid == kvp.Key)) {
							if (app.Windows.Any (win => !win.IsSkipTasklist))
								apps.Add (app);
							break;
						}
					}
				}
			}
			return apps;
		}
		
		static void UpdateExecList ()
		{
			if ((DateTime.UtcNow - last_update).TotalMilliseconds < 200) return;
			
			exec_lines.Clear ();
			
			foreach (string dir in Directory.GetDirectories ("/proc")) {
				int pid;
				try { pid = Convert.ToInt32 (Path.GetFileName (dir)); } 
				catch { continue; }
				
				string exec_line = CmdLineForPid (pid);
				if (string.IsNullOrEmpty (exec_line))
					continue;
				
				if (exec_line.Contains ("java") && exec_line.Contains ("-D")) {
					foreach (Application app in GetApplications ()) {
						if (app == null)
							continue;
						
						if (app.Pid == pid || app.Windows.Any (w => w.Pid == pid)) {
							foreach (Wnck.Window window in app.Windows.Where (win => !win.IsSkipTasklist)) {
								exec_line = window.ClassGroup.Name;
								
								// Vuze is retarded
								if (exec_line == "SWT")
									exec_line = window.Name;
								
								break;
							}
						}
					}
				}	
				
				exec_line = ProcessExecString (exec_line);
					
				exec_lines [pid] = exec_line;
			}
			
			last_update = DateTime.UtcNow;
		}

		public static string ProcessExecString (string exec)
		{
			exec = exec.ToLower ().Trim ();
			
			if (RemapDictionary.ContainsKey (exec))
				return RemapDictionary [exec];
			
			if (exec.StartsWith ("/")) {
				string first_part = exec.Split (' ') [0];
				int length = first_part.Length;
				first_part = first_part.Split ('/').Last ();
				
				if (length < exec.Length)
					 first_part = first_part + " " + exec.Substring (length + 1);
						
				if (RemapDictionary.ContainsKey (first_part)) {
					return RemapDictionary [first_part];
				}
			}
			
			string [] parts = exec.Split (' ');
			for (int i = 0; i < parts.Length; i++) {
				if (parts [i].StartsWith ("-"))
					continue;
				
				if (parts [i].Contains ("/"))
					parts [i] = parts [i].Split ('/').Last ();
				
				foreach (string prefix in BadPrefixes) {
					if (parts [i] == prefix)
						parts [i] = null;
				}
				
				if (!string.IsNullOrEmpty (parts [i])) {
					string out_val = parts [i];
					if (RemapDictionary.ContainsKey (out_val))
						out_val = RemapDictionary [out_val];
					return out_val;
				}
			}
			return null;
		}
	}
}
