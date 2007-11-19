//  RhythmboxEnqueueCommand.cs
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
using System.Threading;
using System.Diagnostics;

using Do.Universe;

namespace Do.Addins.Rhythmbox
{

	public class RhythmboxEnqueueCommand : ICommand
	{
		
		public RhythmboxEnqueueCommand ()
		{
		}
		
		public string Name {
			get { return "Add to Play Queue"; }
		}
		
		public string Description {
			get { return "Add an item to Rhythmbox's play queue."; }
		}
		
		public string Icon {
			get { return "add"; }
		}
		
		public Type[] SupportedItemTypes {
			get {
				return new Type[] {
					typeof (MusicItem),
				};
			}
		}
		
		public Type[] SupportedModifierItemTypes {
			get { return null; }
		}

		public bool SupportsItem (IItem item) {
			return true;
		}
		
		public bool SupportsModifierItemForItems (IItem[] items, IItem modItem)
		{
			return false;
		}
		
		public void Perform (IItem[] items, IItem[] modifierItems)
		{
			new Thread ((ThreadStart) delegate {
				Rhythmbox.StartIfNeccessary ();
				
				foreach (IItem item in items) {
					string enqueue;
					
					enqueue = "--no-present ";
					foreach (TrackMusicItem track in Rhythmbox.TracksFor (item as MusicItem))
						enqueue += string.Format ("--enqueue \"{0}\" ", track.File);
					Rhythmbox.Client (enqueue);
				}
			}).Start ();
		}
	}
}
