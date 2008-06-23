// GMailContactItemSource.cs
// 
// GNOME Do is the legal property of its developers, whose names are too
// numerous to list here.  Please refer to the COPYRIGHT file distributed with
// this source distribution.
// 
// This program is free software: you can redistribute it and/or modify it under
// the terms of the GNU General Public License as published by the Free Software
// Foundation, either version 3 of the License, or (at your option) any later
// version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more
// details.
// 
// You should have received a copy of the GNU General Public License along with
// this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.Threading;
using System.Collections.Generic;

using Gtk;

using Do.Addins;
using Do.Universe;

namespace GMailContacts
{	
	public sealed class GMailContactsItemSource : IItemSource, IConfigurable
	{
		public string Name { 
			get { return "GMail Contacts"; }
		}
		
		public string Description { 
			get { return "Indexes your GMail contacts"; }
		}
		
		public string Icon { 
			get { return "gmail-logo.png@" + GetType ().Assembly.FullName; }
		}
		
		public Type [] SupportedItemTypes {
			get {
				return new Type [] {
					typeof (ContactItem),
				};
			}
		}
		
		public ICollection<IItem> Items {
			get { return GMail.Contacts; }
		}
		
		public ICollection<IItem> ChildrenOfItem (IItem item) 
		{
			ContactItem contact = (item as ContactItem);
			List<IItem> details;
			
			details = new List<IItem> ();
			foreach (string detail in contact.Details) {
				if (detail.Contains ("."))
					details.Add (new GMailContactDetailItem (
						detail, contact [detail]));
			}
			return details;
		}
		
		public void UpdateItems () 
		{
			try {
				Thread thread = new Thread ((ThreadStart) (GMail.UpdateContacts));
				thread.IsBackground = true;
				thread.Start ();
			} catch (Exception e) {
				Console.Error.WriteLine (e.Message);
			}
		}
		
		public Gtk.Bin GetConfiguration ()
		{
			return new GMailConfig ();
		}
	}
}