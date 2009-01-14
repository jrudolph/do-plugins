/* PauseAction.cs 
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
using System.Collections.Generic;
using Mono.Unix;

using Do.Universe;

namespace Banshee
{
	
	
	public class PauseAction : Act
	{
		public override string Name {
			get { return Catalog.GetString ("Pause"); }
		}
		
		public override string Description {
			get { return Catalog.GetString ("Play from your Banshee Collection"); }
		}
		
		public override string Icon {
			get { return "media-playback-pause"; }
		}
		
		public override IEnumerable<Type> SupportedItemTypes {
			get { yield return typeof (IApplicationItem); }
		}

		public override bool SupportsItem (Item item)
		{
			return Banshee.Playing;
		}

		public override IEnumerable<Item> Perform (IEnumerable<Item> items, IEnumerable<Item> modItems)
		{
			Banshee.Pause ();
			
			yield break;
		}
	}
}
