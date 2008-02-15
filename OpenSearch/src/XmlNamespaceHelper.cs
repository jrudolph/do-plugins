//  XmlNamespaceHelper.cs
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
	public static class XmlNamespaceHelper
	{		
		public static XmlNamespaceManager PopulateNamespaceManager (XmlDocument doc)
		{
		    XmlNamespaceManager namespaceManager = new XmlNamespaceManager ( doc.NameTable) ;
		    foreach (XmlAttribute attr in doc.SelectSingleNode ( "/*") .Attributes)
			{
		        if (attr.Prefix == "xmlns") 
					namespaceManager.AddNamespace (attr.LocalName , attr.Value);
				if (attr.Name == "xmlns")
					namespaceManager.AddNamespace ("default",attr.Value);
			}
		    return namespaceManager;
		} 
	}
}