/* TakeScreenshotAction.cs
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
using System.Diagnostics;
using System.Collections.Generic;

using Do.Universe;

namespace GNOME {

	public class TakeScreenshotAction : AbstractAction {

		public override string Name {
			get { return Catalog.GetString ("Take screenshot"); }
		}

		public override string Description {
			get { return Catalog.GetString ("Takes a screenshot with optional delay."); }
		}

		public override string Icon {
			get { return "camera"; }
		}

		public override Type [] SupportedItemTypes {
			get {
				return new Type [] {
					typeof (ScreenshotItem),
				};
			}
		}

		public override Type [] SupportedModifierItemTypes {
			get {
				return new Type [] {
					typeof (ScreenshotDelayItem),
				};
			}
		}

		public override bool ModifierItemsOptional {
			get { return true; }
		}

		public override IItem [] DynamicModifierItemsForItem (IItem item)
		{
			IItem [] items = new IItem [100];
			for (int i = 0; i < items.Length; ++i)
				items [i] = new ScreenshotDelayItem (i+1);
			return items;
		}

		public override IItem [] Perform (IItem [] items, IItem [] modItems)
		{
			int seconds;
			string window;

			window = "";
			seconds = 0;

			if (items [0] is CurrentWindowScreenshotItem)
				window = "--window";

			if (modItems.Length > 0)
				seconds = (modItems [0] as ScreenshotDelayItem).Seconds;
				
			Process.Start (string.Format ("gnome-screenshot {0} --delay={1}", window, seconds));
			return null;
		}
	}
}
