/* UploadAction.cs
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
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using Mono.Unix;

using Do.Universe;
using Do.Platform;
using Do.Platform.Linux;

using FlickrNet;

namespace Flickr
{	
	public class UploadAction : Act, IConfigurable
	{
		static object count_lock = new object ();
		static int upload_num;
		
		const string ImageExtensions = ".jpg .jpef .gif .png .tiff";
		
		public override string Name {
			get { return Catalog.GetString ("Upload photo"); }
		}
		
		public override string Description {
			get { return Catalog.GetString ("Upload one or more photos to Flickr"); }
		}
		
		/*
		 * Thank you Jeremy Roux for the great icon
		 * http://www.soulvisual.com/blog/
		 */
		public override string Icon {
			get { return "flickr.png@" + GetType ().Assembly.FullName; }
		}
		
		public override IEnumerable<Type> SupportedItemTypes {
			get { 
				return new Type [] { typeof (IFileItem) };
			}
		}
		
		public override IEnumerable<Type> SupportedModifierItemTypes {
			get {
				return new Type [] { typeof (ITextItem) };
			}
		}
		
		public override bool ModifierItemsOptional {
			get { return true; }
		}
		
		public override bool SupportsItem (Item item)
		{
			IFileItem file = item as IFileItem;
			return Directory.Exists (file.Path) || FileIsPicture (file);
		}
		
		public override IEnumerable<Item> Perform (IEnumerable<Item> items, IEnumerable<Item> modItems)
		{
			string tags;
			tags = AccountConfig.Tags + " ";
			
			if (modItems.Any ()) {
				foreach (Item modItem in modItems) {
					ITextItem tag = (modItem as ITextItem);
					tags += tag.Text + " ";
				}
			}
			
			//Build a list of all of the files to upload.
			List<IFileItem> uploads = new List<IFileItem> ();
			foreach (Item item in items) {
				IFileItem file = item as IFileItem;
				if (Directory.Exists (file.Path)) {
					DirectoryInfo dinfo = new DirectoryInfo (file.Path);
					FileInfo [] finfo = dinfo.GetFiles ();
					foreach (FileInfo f in finfo) {
						if (FileIsPicture (f.FullName))
							uploads.Add (Services.UniverseFactory.NewFileItem (f.FullName));
					}
				} else {
					uploads.Add (file);
				}
				upload_num = 1;
				foreach (IFileItem photo in uploads) {
					AsyncUploadToFlickr (photo, tags, uploads.Count);
				}
			}
			
			return null;
		}
		
		public static void AsyncUploadToFlickr (IFileItem photo, string tags, int num)
		{			
			FlickrNet.Flickr flickr = new FlickrNet.Flickr (AccountConfig.ApiKey,
				AccountConfig.ApiSecret, AccountConfig.AuthToken);
				
			new Thread ((ThreadStart) delegate {
				try {
					int thisUpload;
					
					flickr.UploadPicture (photo.Path, photo.Name, "", tags,
						AccountConfig.IsPublic, AccountConfig.FamilyAllowed,
						AccountConfig.FriendsAllowed);
					
					lock (count_lock) {
						thisUpload = upload_num;
						upload_num++;
					}
					
					Services.Notifications.Notify ("Flickr",
						String.Format ("Uploaded {0}. ({1} of {2})", photo.Name,
						thisUpload, num), photo.Path); 
				} catch (FlickrNet.FlickrException e) {
					Console.Error.WriteLine (e.Message);
				}
			}).Start ();
		}
		
		public Gtk.Bin GetConfiguration ()
		{
			return new UploadConfig ();
		}
		
		bool FileIsPicture (IFileItem item)
		{
			return FileIsPicture (item.Path);
		}
		
		bool FileIsPicture (string path)
		{
			return ImageExtensions.Contains (Path.GetExtension (path).ToLower ());
		}
	}
}
