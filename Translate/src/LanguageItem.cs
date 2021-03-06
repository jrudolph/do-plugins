// LanguageItem.cs
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
using Do.Universe;

namespace Translate
{
	
	public class LanguageItem  : Item
	{
		private string name, desc, code, flag;
		
		public LanguageItem (string na, string de, string co, string fl)
		{
			this.name = na;
			this.desc = de;
			this.code = co;
			this.flag = fl;
		}
		
		public override string Name
		{
			get { return name; }
		}
		public override string Description
		{
			get { return desc; }
		}
		public string Code
		{
			get { return code; }
		}
		public override string Icon
		{
			get { return flag+".png@"+GetType().Assembly.FullName; }
		}
	}
}
