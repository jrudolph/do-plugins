// TurnOn.cs created with MonoDevelop
// User: anders at 15:08 18-01-2009
//
////  This program is free software: you can redistribute it and/or modify
////  it under the terms of the GNU General Public License as published by
////  the Free Software Foundation, either version 3 of the License, or
////  (at your option) any later version.
////
////  This program is distributed in the hope that it will be useful,
////  but WITHOUT ANY WARRANTY; without even the implied warranty of
////  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
////  GNU General Public License for more details.
////
////  You should have received a copy of the GNU General Public License
////  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using Do.Universe;

namespace SqueezeCenter.PlayerCommands
{	
	
	public class TurnOn : PlayerCommand 
	{		
		public TurnOn () : base(
		                        "Turn on", "Turn on the player", "sunny", 
		                        new PlayerStatus[] {PlayerStatus.TurnedOff}) {}
		
		public override string GetCommand (Player player, Item modifierItem)
		{
			return string.Format ("{0} power 1", player.Id);
		}
	}
}
