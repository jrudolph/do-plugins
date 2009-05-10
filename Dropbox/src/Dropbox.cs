// 
// Dropbox.cs
// 
// GNOME Do is the legal property of its developers. Please refer to the
// COPYRIGHT file distributed with this
// source distribution.
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
using System.IO;
using System.Diagnostics;

using Mono.Unix;

using Do.Platform;

namespace Dropbox
{
	
	
	public static class Dropbox
	{
		public static string BasePath;
		public static string PublicPath;
		public static string DoSharedPath;
		
		private static string db_url = "https://www.getdropbox.com/";
		
		static Dropbox ()
		{
			string home = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			
			BasePath = home + "/Dropbox";
			PublicPath = BasePath + "/Public";
			DoSharedPath = PublicPath + "/Do Shared Files";
		}
		
		public static bool IsRunning {
			get {
				return !Exec ("status").StartsWith ("Dropbox isn't running!");
			}
		}
		
		public static void Start ()
		{
			Exec ("start -i");
		}
		
		public static void Stop ()
		{
			Exec ("stop");
		}
		
		public static string GetPubUrl (string path)
		{
			string url = Exec (String.Format ("puburl \"{0}\"", path));
			if (!url.StartsWith ("http")) { url = null; }
			
			return url;
		}
		
		public static string GetWebUrl ()
		{
			return db_url + "home#";
		}
		
		public static string GetWebUrl (string path)
		{
			return GetWebUrl () + path.Substring (BasePath.Length);
		}
		
		public static string GetRevisionsUrl (string path)
		{
			return db_url + "revisions" + path.Substring (BasePath.Length);
		}
		
		private static string Exec (string args) 
		{
			string stdout = "";
			
			try {
				ProcessStartInfo cmd = new ProcessStartInfo ();
				cmd.FileName = "dropbox";
				cmd.Arguments = args; 
				cmd.UseShellExecute = false;
				cmd.RedirectStandardOutput = true;
				
				Process run = Process.Start (cmd);
				run.WaitForExit ();
				
				stdout = run.StandardOutput.ReadLine ();
				Log.Debug (stdout);
				
			} catch (Exception e) {
				Log.Error ("Error running dropbox {0}: {2}", args, e.Message);
				Log.Debug (e.StackTrace);
			}
			
			return stdout;
		}
			
	}
}
