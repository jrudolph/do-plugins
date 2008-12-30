/* StatusUpdatedEventArgs.cs 
 *
 * GNOME Do is the legal property of its developers. Please refer to the
 * COPYRIGHT file distributed with this
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

namespace Microblogging
{
	
	public class StatusUpdatedEventArgs : EventArgs
	{
		public string Status { get; private set; }
		public string ErrorMessage { get; private set; }
		
		public StatusUpdatedEventArgs (string status) : 
			this (status, "")
		{
		}

		public StatusUpdatedEventArgs (string status, string errorMessage)
		{
			Status = status;
			ErrorMessage = errorMessage;
		}
	}
}
