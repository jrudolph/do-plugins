using System;
using System.Collections.Generic;
using Mono.Unix;
using Do.Universe;

namespace YouTube
{	
	public class YouTubeSubscriptionItemSource : ItemSource
	{
		public YouTubeSubscriptionItemSource()
		{
		}
		
		public override IEnumerable<Type> SupportedItemTypes 
		{
			get {yield return typeof (YouTubeSubscriptionItem);}
		}
		
		public override string Name { get { return "Youtube Subscriptions"; } }
		public override string Description { get { return "Your YouTube subscriptions"; } }
		public override string Icon {get { return "youtube_user.png@" + GetType ().Assembly.FullName; } }
		
		public override IEnumerable<Item> Items 
		{
			get { return Youtube.subscriptions; }
		}
		
		public override void UpdateItems ()
		{
			Youtube.updateSubscriptions();
		}		
	}
}

