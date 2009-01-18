// EmeseneChatAction.cs created with MonoDevelop
// User: luis at 07:45 p 04/07/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;
using System.Threading;

using Do.Universe;

using NDesk.DBus;
using org.freedesktop.DBus;

namespace Emesene
{
	public class EmeseneChatAction : Act
	{
		public EmeseneChatAction ()
		{
		}
		
		public override string Name
		{
			get { return "Chat"; }
		}
		
		public override string Description
		{
			get { return "Send an instant message to a friend."; }
		}
		
		public override string Icon
		{
			get { return "emesene"; }
		}
		
		public override IEnumerable<Type> SupportedItemTypes {
			get {
				return new Type[] {
					typeof (ContactItem),					
				};
			}
		}

		public override bool SupportsItem (Item item)
		{
			if (item is ContactItem) {
				foreach (string detail in (item as ContactItem).Details) {
					if (detail.StartsWith ("prpl-")) return false;
				}
				return true;
			} return false;
		}
		
		public override IEnumerable<Item> Perform (IEnumerable<Item> items, IEnumerable<Item> modItems)
		{
			foreach(Item buddy in items){
				string mail = null;

				if (buddy is ContactItem) {
					ContactItem contact = buddy as ContactItem;
				    mail = contact["email"];
					}			
				if (null != mail) {
					Emesene.openChatWith(mail);
				}
			}
			return null;
		}
		
	}
}
