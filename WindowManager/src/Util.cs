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

				exec_line = ProcessExecString (exec_line);
				
				exec_lines [pid] = exec_line;
			}
			
			last_update = DateTime.UtcNow;
		}

		public static string ProcessExecString (string exec)
		{
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
					return parts [i].ToLower ();
				}
			}
			return null;
		}
	}
}
