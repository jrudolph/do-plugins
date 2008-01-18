//  OpenSearchFile.cs
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

using System.Xml;

namespace Do.Plugins.OpenSearch
{	
	public class OpenSearchFile : IOpenSearchFile
	{
		private string path;
		
		public OpenSearchFile (string path)
		{
			this.path = path;
		}
		
		public OpenSearchItem CreateOpenSearchItem ()
		{
			XmlDocument doc = new XmlDocument ();
			doc.Load(path);						
			XmlNamespaceManager namespaceManager = XmlNamespaceHelper.PopulateNamespaceManager (doc);
			
			XmlNode shortName = doc.SelectSingleNode ("//*/os:ShortName", namespaceManager);		
			XmlNode description = doc.SelectSingleNode ("//*/os:Description", namespaceManager);	
			XmlNode url = doc.SelectSingleNode ("//*/os:Url[@type='text/html' and @method='GET']", namespaceManager);

			if(shortName == null || description == null || url == null)
				return null;
			
			OpenSearchItem item = new OpenSearchItem(shortName.InnerText ,description.InnerText,url.Attributes["template"].Value);
			
			return item;
		}
	}
}
