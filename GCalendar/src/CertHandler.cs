/* CertHandler.cs
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
using System.Net;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace GCalendar
{	
	
	public class CertHandler : ICertificatePolicy
	{
		private Hashtable ht;
		private void Load ()
		{
			if (ht == null)
				ht = new Hashtable ();
		}
		
		public bool CheckValidationResult (ServicePoint sp, X509Certificate cert,
		                                   WebRequest request, int error)
		{
			return true;
			/*
			if (error == 0) return true;
			if (error != -2146762486) return false;
			
			Load ();
			string thumbprint = cert.GetCertHashString ();
			object result = ht [thumbprint];
			if ((result is int) && ((int) result == error))
				return true;
			
			return false;
			*/
		}
	}
}