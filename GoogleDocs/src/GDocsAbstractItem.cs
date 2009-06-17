// GDocsAbstractItem.cs
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

using System;
using System.Text;

using Mono.Unix;

using Do.Universe;
using Do.Platform;

namespace GDocs
{
	public class GDocsAbstractItem : Item, IOpenableItem
	{
		string name, url;
		
		public GDocsAbstractItem (string name, string url)
		{
			this.name = name;
			this.url = url;
		}
		
		public override string Name {
			get { return name; }
		}
		
		public override string Description {
			get { return Catalog.GetString ("Google Docs Generic Document"); }
		}
		
		public virtual string URL {
			get { return url; }
		}
		
		public override string Icon {
			get { return "x-office-document"; }
		}
		
		public void Open ()
		{
			Services.Environment.OpenUrl (url);
		}
	}
}
