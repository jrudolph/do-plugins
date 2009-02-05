// XRandrItemSource.cs created with MonoDevelop
// User: johannes at 4:38 PM 2/4/2009
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Do.Universe;
using System.Collections.Generic;
using Mono.Unix;

namespace XRandR
{
	public class XRandRItemSource : ItemSource
	{
		List<Item> items;

		public XRandRItemSource ()
		{
			items = new List<Item> ();
		}		
		
		public override string Name {
			get { return Catalog.GetString ("Displays"); }
		}
		
		public override string Description {
			get { return Catalog.GetString ("Set your resolution"); }
		}
		
		public override string Icon {
			get { return "system-config-display"; }
		}
		
		public override IEnumerable<Type> SupportedItemTypes {
			get { return new Type [] {
					typeof (OutputItem)
				};
			}
		}
		
		public override IEnumerable<Item> Items {
			get { return items; }
		}

		
		public override void UpdateItems ()
		{
			items.Clear ();
			foreach(ScreenResources res in External.ScreenResources()){
				foreach(XRROutputInfo output in res.Outputs.All)
					items.Add (new OutputItem(output.name));
			}
		}
	}
}
