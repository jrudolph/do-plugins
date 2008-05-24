/* GCalendarEventItem.cs
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
using System.Text;

using Do.Addins;
using Do.Universe;

namespace GCalendar {
	public sealed class GCalendarEventItem : IURLItem {
		string name, url, desc;
		public GCalendarEventItem (string name, string url, string desc)
		{
			this.name = name;
			this.url = url;
			this.desc = desc;
		}
		
		public string Name {
			get { return name; }
		}
		
		public string Description {
			get { return desc; }
		}
		
		public string Icon {
			get { return "date"; }
		}
		
		public string URL {
			get { return url; }
		}
	}
}
