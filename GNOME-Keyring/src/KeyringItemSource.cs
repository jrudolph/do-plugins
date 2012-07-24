using System;
using System.Collections.Generic;

using Mono.Addins;

using Do.Universe;

using Gnome.Keyring;

namespace Keyring
{
	public class KeyringItemSource : ItemSource
	{
		List<Item> items;

		public KeyringItemSource()
		{
			items = new List<Item> ();
		}
		public override string Name {
			get { return AddinManager.CurrentLocalizer.GetString ("Keyrings"); }
		}
		
		public override string Description {
			get { return AddinManager.CurrentLocalizer.GetString ("Access stored passwords"); }
		}
		
		public override string Icon {
			get { return "seahorse"; }
		}
		
		public override IEnumerable<Type> SupportedItemTypes {
			get { 
				yield return typeof (KeyringItem);
			}
		}
		public override IEnumerable<Item> Items {
			get { return items; }
		}
		public override void UpdateItems ()
		{
			items.Clear ();
			foreach (string ring in Ring.GetKeyrings ())
				items.Add (new KeyringItem (ring));
		}
		public override IEnumerable<Item> ChildrenOfItem (Item parent)
		{
			if (parent is KeyringItem) {
				KeyringItem keyring = parent as KeyringItem;

				// don't access locked keyrings for now
				if (Ring.GetKeyringInfo (keyring.Name).Locked)
					yield break;

				foreach (int id in Ring.ListItemIDs (keyring.Name)) {
					ItemData info = Ring.GetItemInfo (keyring.Name, id);

					// for some reason stored passwords can be both reported as GenericSecret or Note
					if (info.Type == ItemType.GenericSecret || info.Type == ItemType.Note)
						yield return new KeyItem (id, info.Attributes ["name"] as string, info.Keyring);
				}
			}
		}
	}

	public class LockAction : KeyringAction
	{
		public override string Name
		{
			get { return AddinManager.CurrentLocalizer.GetString ("Lock"); }
		}
		
		public override string Description
		{
			get { return AddinManager.CurrentLocalizer.GetString ("Locks the keyring."); }
		}
		
		public override string Icon
		{
			get { return "locked"; }
		}
		protected override void Run (KeyringItem ring) 
		{
			Ring.Lock (ring.Name);
		}
		protected override bool Supported (KeyringItem ring)
		{
			return !ring.Locked;
		}
	}
	public class UnlockAction : KeyringAction
	{
		public override string Name
		{
			get { return AddinManager.CurrentLocalizer.GetString ("Unlock"); }
		}
		
		public override string Description
		{
			get { return AddinManager.CurrentLocalizer.GetString ("Unlocks the keyring."); }
		}
		
		public override string Icon
		{
			get { return "object-unlocked"; }
		}
		protected override void Run (KeyringItem ring) 
		{
			Ring.Unlock (ring.Name, null);
		}
		protected override bool Supported (KeyringItem ring)
		{
			return ring.Locked;
		}
	}

	public abstract class KeyringAction: Act
	{
		public override IEnumerable<Type> SupportedItemTypes
		{
			get {
				yield return typeof (KeyringItem);
			}
		}
		
		public override bool SupportsItem (Item item)
		{
			if (item is KeyringItem) {
				KeyringItem ring = item as KeyringItem;
				
				return Supported (ring);
			}
			return false;
		}
		
		public override IEnumerable<Type> SupportedModifierItemTypes
		{
			get { yield return typeof (ITextItem); }
		}
		
		public override bool ModifierItemsOptional
		{
			get { return true; }
		}

		public override IEnumerable<Item> Perform (IEnumerable<Item> items, IEnumerable<Item> modItems)
		{
			foreach (Item item in items)
			{
				KeyringItem ring = item as KeyringItem;
				Run (ring);
			}

			yield break;
		}
		protected abstract void Run (KeyringItem ring);
		protected abstract bool Supported (KeyringItem ring);
	}


	public class KeyringItem : Item
	{
		string name;
		public KeyringItem(string name)
		{
			this.name = name;
		}
		
		public override string Name {
			get { return name; }

		}

		public override string Icon {
			get { return "seahorse"; }
		}
		
		public override string Description {
			get { return AddinManager.CurrentLocalizer.GetString ("Keyring"); }
		}

		public KeyringInfo Info {
			get { return Ring.GetKeyringInfo (Name); }
		}

		public bool Locked {
			get { return Info.Locked; }
		}
	}
	public class KeyItem : Item, ITextItem
	{
		string name;
		public KeyItem(int id, string name, string keyring)
		{
			this.Id = id;
			this.Keyring = keyring;
			this.name = name;
		}
		public int Id {
			get;
			private set;
		}
		public string Keyring {
			get;
			private set;
		}
		public override string Name {
			get { return name; }
		}
		
		public override string Icon {
			get { return "seahorse"; }
		}
		
		public override string Description {
			get { return AddinManager.CurrentLocalizer.GetString ("Stored password"); }
		}

		public string Text {
			get { return Ring.GetItemInfo(this.Keyring, this.Id).Secret; }
		}
	}
}
