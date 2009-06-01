// Configuration.cs
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
using Mono.Unix;
using RtmNet;
using Do.Platform;

using Gtk;


namespace RememberTheMilk
{
	public partial class Configuration : Gtk.Bin
	{
		//private static IPreferences prefs;
		private LinkButton rtm_ref_btn;
		private string frob;
		
		public Configuration ()
		{
			this.Build();
			rtm_ref_btn = new LinkButton ("Visit Remember The Milk website for more information.",
			                              "List of available operators");
			info_hbox.Add (rtm_ref_btn);
			Box.BoxChild wInt = info_hbox [rtm_ref_btn] as Box.BoxChild;
			wInt.Position = 1;
			rtm_ref_btn.Clicked += OnRtmRefBtnClicked;
			
			if (!System.String.IsNullOrEmpty (RTMPreferences.Token)) {
				SetStateComplete ();
			}
		}
		
		static Configuration ()
		{
		}

		protected virtual void OnConfirmChkbtnClicked (object sender, System.EventArgs e)
		{
			RTMPreferences.ActionNotification = confirm_chkbtn.Active;
		}

		protected virtual void OnOverdueChkbtnClicked (object sender, System.EventArgs e)
		{
			RTMPreferences.OverdueNotification = overdue_chkbtn.Active;
			overdue_interval_spinbtn.Sensitive = overdue_chkbtn.Active;
			overdue_interval_spinbtn.Value = RTMPreferences.OverdueInterval;
			
		}
		
		protected virtual void OnReturnNewChkBtnClicked (object sender, System.EventArgs e)
		{
			RTMPreferences.ReturnNewTask = returnnew_chkbtn.Active;
		}
		
		protected virtual void OnAuthBtnClicked (object sender, System.EventArgs e)
		{
			frob = RTM.AuthInit ();
			authinfo_lbl.Text = Catalog.GetString ("A webpage from Remember The Milk should be opened"
			     + " in your web browser now. Please follow the instructions there and come back to complete"
			     + " the authrozation by clicking the button below.");
			RTMPreferences.Token = "";
			RTMPreferences.Username = "";
			notification_frm.Sensitive = false;
			filter_frm.Sensitive = false;
			Widget image = auth_btn.Image;
			auth_btn.Label = Catalog.GetString ("Complete authorization");
			auth_btn.Image = image;
			auth_btn.Clicked -= new EventHandler (OnAuthBtnClicked);
			auth_btn.Clicked += new EventHandler (OnCompleteBtnClicked);
		}
		
		protected virtual void OnCompleteBtnClicked (object sender, EventArgs e)
		{
			Auth auth;
			auth = RTM.AuthComplete (frob);
			if (auth != null ) {
				RTMPreferences.Token = auth.Token;
				RTMPreferences.Username = auth.User.Username;
				auth_btn.Clicked -= new EventHandler (OnCompleteBtnClicked);
				auth_btn.Clicked += new EventHandler (OnAuthBtnClicked);
				SetStateComplete ();
			} else {
				authinfo_lbl.Text = Catalog.GetString ("Fail to complete authorization.");
				auth_btn.Clicked -= new EventHandler (OnCompleteBtnClicked);
				auth_btn.Clicked += new EventHandler (OnAuthBtnClicked);
				auth_btn.Label = Catalog.GetString ("Authorize again");
			}
		}
		
		private void SetStateComplete ()
		{
			authinfo_lbl.Text = String.Format (Catalog.GetString ("Thank you {0}, "
			    + "RTM plugin is now authorized to operate on your account."), RTMPreferences.Username);
			auth_btn.Label = "Sign in as a different user";
			notification_frm.Sensitive = true;
			filter_frm.Sensitive = true;
			confirm_chkbtn.Active = RTMPreferences.ActionNotification;
			overdue_chkbtn.Active = RTMPreferences.OverdueNotification;
			overdue_interval_spinbtn.Sensitive = overdue_chkbtn.Active;
			overdue_interval_spinbtn.Value = RTMPreferences.OverdueInterval;
			returnnew_chkbtn.Active = RTMPreferences.ReturnNewTask;
			filter_entry.Text = RTMPreferences.Filter;
		}

		protected virtual void OnFilterEntryChanged (object sender, System.EventArgs e)
		{
			RTMPreferences.Filter = filter_entry.Text;
		}

		protected virtual void OnRtmRefBtnClicked (object sender, EventArgs e)
		{
			Do.Platform.Services.Environment.OpenUrl("http://www.rememberthemilk.com/help/answers/search/advanced.rtm");
		}

		protected virtual void OnOverdueIntervalChanged (object sender, System.EventArgs e)
		{
			RTMPreferences.OverdueInterval = overdue_interval_spinbtn.Value;
		}
	}
}
