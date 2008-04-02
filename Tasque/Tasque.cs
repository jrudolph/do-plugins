// Tasque.cs
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
using System.Collections;

using Do.Universe;
using Tasque.DBus;
using Tasque.Category.Item;

namespace Tasque
{
	public static class Tasque
	{		
		public static List<IItem> GetCategoryItems ()
		{
			List<IItem> items =  new List<IItem> ();
			TasqueDBus tasque = new TasqueDBus ();
			ArrayList categories = new ArrayList ();
			
			try {
				categories = tasque.GetCategoryNames ();
				
				foreach (string category in categories) 
					items.Add (new TasqueCategoryItem (category));
			} catch (Exception) {
				Console.Error.WriteLine ("Could not read Tasque's category");
			}
			return items;
		}
	}
}
