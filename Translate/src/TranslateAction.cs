// TranslateAction.cs
// 
// Copyright (C) 2008 Chris Szikszoy
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
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Mono.Unix;

using Do.Universe;
using Do.Universe.Common;
using Do.Platform;
using Do.Platform.Linux;

namespace Translate
{

	public class TranslateAction : Act, IConfigurable
	{

		const string UrlPattern = "^ (https?://)"
			+ "? ( ([0-9a-zA-Z_!~*' ().&=+$%-]+: )?[0-9a-zA-Z_!~*' ().&=+$%-]+@)?" //user@
			+ @" ( ([0-9]{1, 3}\.){3}[0-9]{1, 3}" // IP- 199.194.52.184
			+ "|" // allows either IP or domain
			+ @" ([0-9a-zA-Z_!~*' ()-]+\.)*" // tertiary domain (s)- www.
			+ @" ([0-9a-zA-Z][0-9a-zA-Z-]{0, 61})?[0-9a-zA-Z]\." // second level domain
			+ "[a-zA-Z]{2, 6})" // first level domain- .com or .museum
			+ " (:[0-9]{1, 4})?" // port number- :80
			+ " ( (/?)|" // a slash isn't required if there is no file name
			+ " (/[0-9a-zA-Z_!~*' ().;?:@&=+$, %#-]+)+/?)$";

		Regex url_regex;
		IPreferences prefs;

		public TranslateAction ()
		{
			url_regex = new Regex (UrlPattern, RegexOptions.Compiled);
			prefs = Services.Preferences.Get<Translate.ConfigUI> ();
		}

		public override string Name {
			get { return Catalog.GetString ("Translate"); }
		}

		public override string Icon {
			get { return "globe.png@" + GetType ().Assembly.FullName; }
		}

		public override string Description {
			get { return Catalog.GetString ("Translates text"); }
		}

		public override IEnumerable<Type> SupportedItemTypes {
			get {
				yield return typeof (TextItem);
				yield return typeof (IUrlItem);
			}
		}
		
		public override bool SupportsItem (Item item)
		{
			ITranslateProvider Translator = TranslateEngine.Translator;
			if (Translator.SupportsUrlTranslate)
				return true;
			else if (!(url_regex.IsMatch ((item as ITextItem).Text)) || (item is IUrlItem))
				return false;
			return true;
		}

		public override IEnumerable<Type> SupportedModifierItemTypes {
			get { yield return typeof (LanguageItem); }
		}

		public override IEnumerable<Item> DynamicModifierItemsForItem (Item item)
		{
			ITranslateProvider Translator = TranslateEngine.Translator;
			foreach (LanguageItem Language in Translator.SupportedLanguages) {
				if (prefs.Get (Language.Code, false))
					yield return Language;
			}
		}

		public override IEnumerable<Item> Perform (IEnumerable<Item> items, IEnumerable<Item> modItems)
		{
			ITranslateProvider Translator = TranslateEngine.Translator;
			string url = null;
			LanguageItem ToLang = (modItems.First () as LanguageItem);

			if (ToLang != null) {
				if (Translator.SupportsUrlTranslate && url_regex.IsMatch ( (items.First () as ITextItem).Text))
					url = Translator.BuildUrlRequestUrl (ConfigUI.SelectedIfaceLang, ToLang.Code, ConfigUI.SelectedSourceLang, (items.First () as ITextItem).Text);
				else
					url = Translator.BuildTextRequestUrl (ConfigUI.SelectedIfaceLang, ToLang.Code, ConfigUI.SelectedSourceLang, (items.First () as ITextItem).Text);

				if (!string.IsNullOrEmpty (url))
					Services.Environment.OpenUrl (url);
			}
			yield break;
		}

		public Gtk.Bin GetConfiguration ()
		{
			return new ConfigUI ();
		}	
	}
}
