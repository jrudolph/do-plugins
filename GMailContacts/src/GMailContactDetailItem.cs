/*
 * GMailContactDetailItem.cs
 * 
 * GNOME Do is the legal property of its developers, whose names are too numerous
 * to list here.  Please refer to the COPYRIGHT file distributed with this
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
using Do.Universe;

namespace GMailContacts
{
	public class GMailContactDetailItem : IContactDetailItem 
	{
		private string type, email, icon;
		
		public GMailContactDetailItem (string type, string email)
		{
			this.type = type;
			this.email = email;
			this.icon = "gmail-logo.png@" + GetType ().Assembly.FullName;
		}
		
		public GMailContactDetailItem (string type, string email, string icon) :
			this (type, email)
		{
			this.icon = icon;
		}
		
		public string Name {
			get {
				switch (type.ToLower ()) {
				case "email.gmail":
					return "Primary Email";
				case "email.gmail.home":
					return "Home Email";
				case "email.gmail.work":
					return "Work Email";
				default:
					return "Other Email";
				}
			}
		}
		
		public string Description {
			get { return email; }
		}
		
		public string Icon {
			get { return icon; }
		}
		
		public string Key {
			get { 
				return "email.gmail";
			}
		}
		
		public string Value {
			get { 
				return email;
			}
		}
	}
}
