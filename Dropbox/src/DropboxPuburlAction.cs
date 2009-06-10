/* DropboxPuburlAction.cs
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
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Mono.Unix;

using Do.Universe;
using Do.Universe.Common;
using Do.Platform;


namespace Dropbox
{
	
	
	public class DropboxPuburlAction : DropboxAbstractAction
	{
				
		public override string Name {
			get { return Catalog.GetString ("Get public URL");  }
		}
		
		public override string Description {
			get { return Catalog.GetString ("Gets public URL of a shared Dropbox file."); }
		}
		
		public override string Icon {
			get { return "dropbox"; }
		}
		
		public override bool SupportsItem (Item item) 
		{
			string path = GetPath(item);
			
			return File.Exists (path) && 
				Dropbox.HasCli && 
				(path.StartsWith (Dropbox.PublicPath) || 
				HasLink (path));
		}
		
		public override IEnumerable<Item> Perform (IEnumerable<Item> items, IEnumerable<Item> modItems)
		{
			string path;
			
			foreach (Item i in items)
			{
				path = GetPath(i);
			
				if (!path.StartsWith (Dropbox.PublicPath)) 
					path = GetLink (path);
	
				string url = Dropbox.GetPubUrl (path);
				
				yield return new BookmarkItem (pub_url_title, url);
			}
			
			yield break;
		}

	}
}
