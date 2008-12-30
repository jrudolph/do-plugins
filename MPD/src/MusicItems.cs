//  MusicItems.cs
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

using System;
using System.Collections.Generic;


using Do.Universe;

namespace MPD
{
	public abstract class MusicItem : Item
	{
		protected string name, artist, year, cover;

		public MusicItem ()
		{
		}

		public MusicItem (string name, string artist, string year, string cover):
			this ()
		{
			this.name = name;
			this.artist = artist;
			this.year = year;
			this.cover = cover;
		}

		public override string Name { get { return name; } }
		public override string Description { get { return artist; } }
		public override string Icon { get { return Cover ?? "gtk-cdrom"; } }

		public virtual string Artist { get { return artist; } }
		public virtual string Year { get { return year; } }
		public virtual string Cover { get { return cover; } }

	}

	public class AlbumMusicItem : MusicItem
	{
		public AlbumMusicItem (string name, string artist, string year, string cover):
			base (name, artist, year, cover)
		{
		}
	}

	public class ArtistMusicItem : MusicItem
	{
		public ArtistMusicItem (string artist, string cover):
			base ()
		{
			this.artist = this.name = artist;
			this.cover = cover;
		}

		public override string Description
		{
			get {
				return string.Format ("All music by {0}", artist);
			}
		}
	}

	public class SongMusicItem : MusicItem
	{
		string album, file;
		int number;
		
		public SongMusicItem (string name, string artist, string album, string cover, string file, int number):
			base (name, artist, "", cover)
		{
			this.file = file;
			this.album = album;
			this.number = number;
		}

		public override string Icon { get { return "gnome-mime-audio"; } }
		public override string Description
		{
			get {
				return string.Format ("{0} - {1}", artist, album);
			}
		}
		public virtual string Album { get { return album; } }
		public virtual string File { get { return file; } }
		public virtual int Number { get {return number; } }
	}
}
