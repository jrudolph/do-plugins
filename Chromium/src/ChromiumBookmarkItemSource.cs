/* ChromiumBookmarkItemSource.cs
 *
 * GNOME Do is the legal property of its developers. Please refer to the
 * COPYRIGHT file distributed with this
 * source distribution.
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.	See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.	If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using Mono.Addins;

using Do.Platform;
using Do.Universe;
using Do.Universe.Common;

namespace Chromium 
{
	public class ChromiumBookmarkItemSource : ItemSource 
	{	
		List<Item> items;
		
		public ChromiumBookmarkItemSource ()
		{
			items = new List<Item> ();
		}
		
		public override string Name {
			get { return AddinManager.CurrentLocalizer.GetString ("Chromium Bookmarks"); }
		}
		
		public override string Description {
			get { return AddinManager.CurrentLocalizer.GetString ("Indexes your Chromium bookmarks"); }
		}
		
		public override string Icon {
			get { return "chromium-browser"; }
		}
		
		public override IEnumerable<Type> SupportedItemTypes {
			get { yield return typeof (BookmarkItem); }
		}
		
		public override IEnumerable<Item> Items {
			get { return items; }
		}
		
		public override void UpdateItems ()
		{
			string type = "", name = "", url = "";
			string home = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string bookmarksFile = "~/.config/chromium/Default/Bookmarks".Replace ("~", home);
			try {				
				Regex RE = new Regex ("(\"([^\"]*)\" *: *\"([^\"]*)\")|[{}]", RegexOptions.Multiline);
				FileStream fs = new FileStream (bookmarksFile, FileMode.Open,FileAccess.Read);
				StreamReader reader = new StreamReader (fs);
				
				items.Clear ();
				
				foreach (Match m in RE.Matches (reader.ReadToEnd ())) {
					if (m.Value == "{") {
						url = "";
						type = "";
						name = "";
					}
					else if (m.Value == "}" && type == "url" && !string.IsNullOrEmpty (name) && !string.IsNullOrEmpty (url)) {
						items.Add (new BookmarkItem (name, url));
					}
					else if (m.Value.StartsWith ("\"")) {
						if (m.Groups [2].Value == "url")
							url = m.Groups [3].Value;
						else if (m.Groups [2].Value == "name")
							name = m.Groups [3].Value;
						else if (m.Groups [2].Value == "type")
							type = m.Groups [3].Value;
					}
				}
				fs.Dispose ();
				reader.Dispose ();
			}
			catch (Exception e) {
				Log.Error ("Could not read Chromium Bookmarks file {0}: {1}", bookmarksFile, e.Message);
				Log.Debug (e.StackTrace);
			}
		}
	}
}