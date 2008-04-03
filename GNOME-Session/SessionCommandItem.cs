/* SessionCommandItem.cs
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
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Threading;

using Do.Universe;

namespace GNOME.Session
{
	class SessionCommandItem : IRunnableItem
	{
		public delegate void RunDelegate ();

		const int SessionItemRunDelay = 500;

		RunDelegate run;
		string name, description, icon;

		public SessionCommandItem (string name, string description, string icon,
			RunDelegate run)
		{
			this.name = name;
			this.description = description;
			this.icon = icon;
			this.run = run;
		}

		public string Name { get { return name; } }
		public string Description { get { return description; } }
		public string Icon { get { return icon; } }

		public virtual void Run ()
		{
			new Thread ((ThreadStart)
				delegate {
					Thread.Sleep (SessionItemRunDelay);
					run ();
				}
			).Start ();
		}
	}
}
