// GDocsUploadDocument.cs
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

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mono.Addins;

using Do.Universe;

using Google.GData.Client;
using Google.GData.Documents;

namespace GDocs
{
	public sealed class GDocsUploadDocument : Act
	{
		const string ExtPattern = @"\.(txt|doc|docx|html|htm|odt|rtf|xls|xlsx|ods|csv|tsv|tsb|ppt|pps|sxw|pdf)$";
				
		public override string Name {
			get { return AddinManager.CurrentLocalizer.GetString ("Upload Document"); }
		}
		
		public override string Description {
			get { return AddinManager.CurrentLocalizer.GetString ("Upload a document to Google Docs"); }
		}
			
		public override string Icon {
			get { return "document-send"; }
		}
		
		public override IEnumerable<Type> SupportedItemTypes {
			get { yield return typeof (IFileItem); }
		}
		
		public override IEnumerable<Type> SupportedModifierItemTypes {
		    get { yield return typeof (ITextItem); }
		}
		
		public override bool ModifierItemsOptional {
			get { return true; }
		}
		
		public override bool SupportsItem (Item item) 
		{
			return IsValidFormat (item as IFileItem);
		}
		
		public override IEnumerable<Item> Perform (IEnumerable<Item> items, IEnumerable<Item> modifierItems) 
		{
			string fileName = (items.First () as IFileItem).Path;
			string documentName = (modifierItems.Any ()) ? (modifierItems.First () as ITextItem).Text : null;
			
			yield return GDocs.UploadDocument (fileName, documentName);
		}
		
		private bool IsValidFormat (IFileItem item)
		{
			// Supported uploading format by Google Docs
			//
			// Detailed info: http://documents.google.com/support/presentations/bin/answer.py?answer=50092
			//                http://documents.google.com/support/presentations/bin/answer.py?answer=37603
			
			return new Regex (ExtPattern, RegexOptions.Compiled).IsMatch (item.Path);                
		}
	}
}
