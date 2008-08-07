// Configuration.cs
// 
// GNOME Do is the legal property of its developers, whose names are too
// numerous to list here.  Please refer to the COPYRIGHT file distributed with
// this source distribution.
// 
// This program is free software: you can redistribute it and/or modify it under
// the terms of the GNU General Public License as published by the Free Software
// Foundation, either version 3 of the License, or (at your option) any later
// version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more
// details.
// 
// You should have received a copy of the GNU General Public License along with
// this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System;

using Do.UI;
using Do.Addins;

namespace DoTwitter
{
	public class Configuration : AbstractLoginWidget
	{
		public Configuration () : 
			base ("Twitter")
		{
			GetAccountButton.Uri = "https://twitter.com/signup";
		}
		
		protected override bool Validate (string username, string password)
		{
			//return TwitterAction.TryConnect (username, password);
			// we had too many problems with this failing for valid data,
			// we're just going to return true until I find a better way
			return TwitterAction.Connect (username, password);
		}
	}
}
