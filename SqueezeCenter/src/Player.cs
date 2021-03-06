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
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using Do.Universe;

namespace SqueezeCenter
{
	public class Player : SqueezeCenterItem
	{
		static Dictionary<string, Player> players = new Dictionary<string, Player> ();
		
		public static void CreatePlayer (string id, string name, string model, bool connected, bool poweredOn, bool canPowerOff)
		{
			// check if player was created before
			lock (Player.players) {
				Player p;
				if (!Player.players.TryGetValue (id, out p)) {
#if VERBOSE_OUTPUT
					Console.WriteLine("SQC: New player " + name);
#endif
					p = new Player (id);	
					Player.players.Add (id, p);
				}
				p.name = name;
				p.model = model;				
				p.canPowerOff = canPowerOff;
				
				if (!connected) {
					p.Status = PlayerStatus.Disconnected;
				} else {
					if (!poweredOn)
						p.Status = PlayerStatus.TurnedOff;					
					else 
						p.Status = PlayerStatus.Stopped; // this we don't know, but it'll be updated later.
				}
				p.syncedWith.Clear ();
				p.Available = true;
#if VERBOSE_OUTPUT
				Console.WriteLine("SQC: Existing player " + name);
#endif
			}
		}
		
		public static Player GetFromId(string id)
		{
			Player p;
			lock (Player.players)
				if (!Player.players.TryGetValue (id, out p))
					p = null;
			return p;
		}
		
		public static Player[] GetAllPlayers()
		{			
			lock (Player.players)
				return Player.players.Values.Where (p => p.Available).ToArray ();
		}
		
		public static Player[] GetAllConnectedPlayers()
		{			
			lock (Player.players)
				return Player.players.Values.Where (p => p.Available && p.Status != PlayerStatus.Disconnected).ToArray();
		}
		
		string id, name, model;
		bool canPowerOff;
		List<Player> syncedWith;
		string syncedWithStr;
		PlayerStatus status;
		
		Player(string id)
		{
			this.id = id;
			this.syncedWith = new List<Player> ();
		}
		
		public string Id 
		{
			get {
				return id;
			}
		}	

		public override string Name 
		{
			get {
				return name;
			}
		}
				
		public override string Icon 
		{
			get {
				return (PoweredOn ? "SB_on" : "SB_off") + ".png@" + this.GetType ().Assembly.FullName;				
			}
		}		
		
		public override string Description 
		{
			get {
				// make local copy of synchedWithStr, as it is set from a thread
				string syncStr = syncedWithStr;
				
				return string.Format("{0} ({1}){2}", 
				                     model, 
				                     PoweredOn ? "On" : "Off", 
				                     syncStr == null ? string.Empty : " synced with " + syncStr);
			}
		}
		
		public bool PoweredOn 
		{
			get {			
				switch (status)
				{
				case PlayerStatus.Disconnected:
				case PlayerStatus.TurnedOff:
					return false;
					
				default :
					return true;
				}
			}
		}
		
		public bool CanPowerOff
		{
			get {
				return canPowerOff;
			}
			set {
				canPowerOff = value;
			}
		}
				
		public PlayerStatus Status
		{
			get {
				return status;
			}
			set {
				status = value;
			}
		}
		
		public Player[] SyncedPlayers
		{
			get {
				lock (syncedWith)
					return syncedWith.ToArray ();
			}
		}
		
		public void SetSynchedPlayers (IEnumerable<Player> players) {
			
			StringBuilder syncStr = new StringBuilder ();
			
			lock (syncedWith) {
				syncedWith.Clear ();
				if (players != null)
					syncedWith.AddRange (players);
								
				foreach (Player p in syncedWith)
					syncStr.AppendFormat ("{0}, ", p.name);
				
				System.Threading.Interlocked.Exchange<string> (ref syncedWithStr, 
				                                               syncStr.Length == 0 ? null : syncStr.ToString (0, syncStr.Length-2));
			}
		}
		
		public bool IsSynced
		{
			get {
				lock (syncedWith) 
					return syncedWith.Any ();
			}
		}		
	}
	
	public enum PlayerStatus
	{
		Disconnected,
		TurnedOff,
		
		// one of the following means the player is turned on
		Stopped,
		Paused,
		Playing
	}
}
