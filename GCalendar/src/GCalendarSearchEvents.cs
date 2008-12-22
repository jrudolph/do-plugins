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
using System.Collections.Generic;
using System.Linq;
using Mono.Unix;


using Do.Universe;

using Google.GData.Client;
using Google.GData.Calendar;

namespace GCalendar {
    public sealed class GCalendarSearchEvents : Act
    {
        public GCalendarSearchEvents()
        {
        }
        
        public override string Name {
            get { return Catalog.GetString ("Search Events"); }
        }
        
        public override string Description {
            get { return Catalog.GetString ("Search Google Calendar for Events"); }
        }
        
        public override string Icon {
            get { return "calIcon.png@" + GetType ().Assembly.FullName; }
        }
        
        public override IEnumerable<Type> SupportedItemTypes {
            get {
                return new Type[] {
                    typeof (ITextItem),
                };
            }
        }
        
        public override IEnumerable<Type> SupportedModifierItemTypes {
            get { 
                return new Type[] {
                    typeof (GCalendarItem),
                };
            }
        }
        
        public bool ModifierItemsOptional {
            get { return false; }
        }
        
        public bool SupportsItem (Item item) {
            return true;
        }
        
        public override bool SupportsModifierItemForItems (IEnumerable<Item> items, Item modItem)
        {
            return true;
        }
        
        public IEnumerable<Item> DynamicModifierItemsForItem (Item item)
        {
            return null;
        }
        
        public IEnumerable<Item> Perform (IEnumerable<Item> items, IEnumerable<Item> modifierItems)
        {
            string search_text = "";
            foreach (Item item in items) {
                search_text += (item as ITextItem).Text;
            }
            return GCal2.SearchEvents ((modifierItems.First () as GCalendarItem).URL, search_text);
        }
    }
}