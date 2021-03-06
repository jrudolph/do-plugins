// RTMDeleteTags.cs
// 
// Copyright (C) 2009 GNOME Do
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 

using System;
using System.Linq;
using System.Collections.Generic;
using Mono.Addins;

using Do.Universe;
using Do.Platform;

namespace RememberTheMilk
{
	/// <summary>
	/// Class to provide the "Delete Tags" action.
	/// </summary>
	public class RTMDeleteTags : Act
	{
		public override string Name {
			get { return AddinManager.CurrentLocalizer.GetString ("Delete Tag(s)"); }
		}
		
		public override string Description {
			get { return AddinManager.CurrentLocalizer.GetString ("Detele one or more tags from a task."); }
		}
		
		public override string Icon {
			get { return "tag-delete.png@" + GetType ().Assembly.FullName; }
		}
		
		public override IEnumerable<Type> SupportedItemTypes {
			get { 
				yield return typeof (RTMTaskItem);
				yield return typeof (RTMTaskAttributeItem);
			}
		}
		
		public override IEnumerable<Type> SupportedModifierItemTypes {
			get { yield return typeof (RTMTagItem); }
		}
		
		public override bool SupportsItem (Item item) {
			if (item is RTMTaskItem)
				return !String.IsNullOrEmpty ((item as RTMTaskItem).Tags);
			else if (item is RTMTaskAttributeItem)
				return (item as RTMTaskAttributeItem).Description == "Tags";
			else
				return false;
		}
		
		public override bool SupportsModifierItemForItems (IEnumerable<Item> item, Item modItem) 
		{
			string tagline = String.Empty;
			
			if (item.First () is RTMTaskItem)
				tagline = (item.First () as RTMTaskItem).Tags;
			else if (item.First () is RTMTaskAttributeItem)
				tagline = (item.First () as RTMTaskAttributeItem).Name;
			
			List<string> tags = new List<string> (tagline.Split (new string[] {", "}, StringSplitOptions.None));
			
			return tags.FindIndex (i => i == (modItem as RTMTagItem).Name) != -1;
		}
		
		public override IEnumerable<Item> Perform (IEnumerable<Item> items, IEnumerable<Item> modifierItems) 
		{
			RTMTaskItem task = null;
			List<string> temp_tags = new List<string> ();
			
			if (items.Any()) {
				if (items.First () is RTMTaskItem)
					task = (items.First () as RTMTaskItem);
				else if (items.First () is RTMTaskAttributeItem)
					task = (items.First () as RTMTaskAttributeItem).Parent;
			}
			
			if (modifierItems.Any () && task != null) {
				foreach (Item item in modifierItems)
					temp_tags.Add ((item as RTMTagItem).Name);
				
				Services.Application.RunOnThread (() => {
					RTM.DeleteTags (task.ListId, task.TaskSeriesId,
						task.Id, String.Join (",", temp_tags.ToArray ()));
				});
			}
			yield break;
		}
	}
}
