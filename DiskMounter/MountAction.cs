// MountAction.cs
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, see <http://www.gnu.org/licenses/> or 
// write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, 
// Boston, MA 02111-1307 USA
//
using System;
using System.Collections.Generic;

using Gnome.Vfs;

using Mount;
using Do.Universe;

namespace Mount
{
	public class MountAction : AbstractAction
	{
	
                public MountAction ()
                {
                }
                
		public override string Name {
			get { return "Mount"; }
		}
		
		public override string Description {
			get { return "Mount volume"; }
		}
		
		public override string Icon {
			get { return "harddrive"; }
		}
		
		public override Type[] SupportedItemTypes {
			get {
			return new Type[] {
				
                                        typeof (UnmountedDriveItem),
				};
			}
		}
                
                public override bool SupportsItem (IItem item) 
                {
			return true;
		}
                
                public override bool SupportsModifierItemForItems (IItem[] items, IItem modItem)
                {
                        return false;
                }
		
		public override IItem[] Perform (IItem[] items, IItem[] modItems)
		{
		        (items[0] as UnmountedDriveItem).Mount ();
			return null;
		}
	}
}
