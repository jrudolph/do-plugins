//  PhoneContactDetailItem.cs
//
//  GNOME Do is the legal property of its developers.
//  Please refer to the COPYRIGHT file distributed with this
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
using Do.Universe;
using Mono.Unix;

namespace Evolution
{
	class PhoneContactDetailItem : ContactDetailItem {
		public PhoneContactDetailItem (ContactItem owner, string detail) :
			base (owner, detail)
		{
		}

		public override string Name {
			get {
				if (Key.Contains (".work")) return Catalog.GetString ("Work Phone");
				if (Key.Contains (".home")) return Catalog.GetString ("Home Phone");
				if (Key.Contains (".mobile")) return Catalog.GetString ("Mobile Phone");
				return "Phone";
			}
		}

		public override string Icon {
			get { return "phone.png@" + GetType ().Assembly.FullName; }
		}
	}
}
