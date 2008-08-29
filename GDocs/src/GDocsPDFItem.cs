/* GDocsPDFItem.cs
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
using System.Text;
using Mono.Unix;

using Do.Addins;
using Do.Universe;

namespace GDocs
{
    public class GDocsPDFItem : GDocsItem
    {

        public GDocsPDFItem (string name, string url) : base (name, url) {}
		
		public override string Description {
            get { return Catalog.GetString ("Google Docs PDF Document"); }
        }

        public override string Icon {
            get { return "gnome-mime-application-pdf"; }
        }

    }
}
