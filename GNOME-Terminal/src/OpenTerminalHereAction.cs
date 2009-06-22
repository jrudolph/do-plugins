/* OpenTerminalHereAction.cs
 * 
 * GNOME Do is the legal property of its developers, whose names are too numerous
 * to list here.  Please refer to the COPYRIGHT file distributed with this
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
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Mono.Addins;
using Do.Universe;

namespace GNOME.Terminal
{
	public class OpenTerminalHereAction : Act
	{	
		public OpenTerminalHereAction()
		{
		}

		public override string Name
		{
			get { return AddinManager.CurrentLocalizer.GetString ("Open Terminal Here"); }
		}

		public override string Description
		{
			get { return AddinManager.CurrentLocalizer.GetString ("Opens a GNOME Terminal in a given location."); }
		}
		
		public override string Icon
		{
			get { return "gnome-terminal"; }
		}

	    public override IEnumerable<Type> SupportedItemTypes
		{
	      get {
	      	return new Type[] {
	      		typeof (IFileItem),
	      	};
	      }
	    }

	    public override IEnumerable<Item> Perform( IEnumerable<Item> items, IEnumerable<Item> modifierItems )
	    {
	    	Process term;
	    	string dir;
			
			dir = (items.First () as IFileItem).Path;
			if (!System.IO.Directory.Exists (dir)) {
				dir = System.IO.Path.GetDirectoryName (dir);
			}
			
			term = new Process ();
			term.StartInfo.WorkingDirectory = dir;
			term.StartInfo.FileName = "gnome-terminal";
			term.Start ();
			return null;
		}
	}
}
