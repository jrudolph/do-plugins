//  PidginChatAction.cs
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
using System.Linq;
using System.Threading;
using System.Collections.Generic;

using Mono.Unix;

using Do.Platform;
using Do.Universe;

namespace PidginPlugin
{

	public class PidginChatAction : Act
	{

		public PidginChatAction ()
		{
		}
		
		public override string Name {
			get { return Catalog.GetString ("Chat"); }
		}
		
		public override string Description {
			get { return Catalog.GetString ("Send an instant message to a friend."); }
		}
		
		public override string Icon {
			get { return Pidgin.ChatIcon; }
		}
		
		public override IEnumerable<Type> SupportedItemTypes {
			get {
				yield return typeof (ContactItem);
				yield return typeof (PidginHandleContactDetailItem);
			}
		}

		public override bool SupportsItem (Item item)
		{
			if (item is ContactItem)
				return (item as ContactItem).Details.Any (d => d.StartsWith ("prpl-"));
			return true;
		}
		
		public override IEnumerable<Item> Perform (IEnumerable<Item> items, IEnumerable<Item> modItems)
		{
			Item item = items.First ();
			string name = null;

			if (item is ContactItem) {
				// Just grab the first protocol we see.
				ContactItem contact = item as ContactItem;
				foreach (string detail in contact.Details) {
					if (detail.StartsWith ("prpl-")) {
						name = contact[detail];
						// If this buddy is online, break, else keep looking.
						if (Pidgin.BuddyIsOnline (name)) break;
					}
				}
			} else if (item is PidginHandleContactDetailItem) {
				name = (item as PidginHandleContactDetailItem).Value;
			}

			if (name != null) {
				Services.Application.RunOnThread (() => {
					Pidgin.StartIfNeccessary ();
					Services.Application.RunOnMainThread (() =>
						Pidgin.OpenConversationWithBuddy (name)
					);
				});
			}
			yield break;
		}
		
	}
}
