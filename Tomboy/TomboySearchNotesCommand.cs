//  RhythmboxPlayCommand.cs
//
//  GNOME Do is the legal property of its developers, whose names are too numerous
//  to list here.  Please refer to the COPYRIGHT file distributed with this
//  source distribution.
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Diagnostics;

using Do.Universe;

namespace Do.Addins.Tomboy
{
	
	
	public class TomboySearchNotesCommand : IAction
	{
		
		public TomboySearchNotesCommand()
		{
		}
		
		public string Name {
			get { return "Search Tomboy Notes"; }
		}
		
		public string Description {
			get { return "Search your Tomboy Notes bodies"; }
		}
		
		public string Icon {
			get { return "/usr/share/icons/Tango/scalable/actions/gtk-find.svg"; }
		}
		
		public Type[] SupportedItemTypes {
			get {
				return new Type[] {
					typeof (ITextItem),
				};
			}
		}
		
		public Type[] SupportedModifierItemTypes {
			get { return null; }
		}
		
	    public bool ModifierItemsOptional {
		  get { return false; }
	    }

		public bool SupportsItem (IItem item) {
			return true;
		}
		
	    public bool SupportsModifierItemForItems (IItem[] items, IItem modItem) {
	      return false;
	    }
			
	    public IItem[] DynamicModifierItemsForItem (IItem item) {
	      return null;
	    }
		
		public IItem[] Perform (IItem[] items, IItem[] modifierItems)
		{
			TomboyDBus tomboy_instance = new TomboyDBus();
			tomboy_instance.SearchNotes((items[0] as ITextItem).Text);
			return null;
		}
	}
}