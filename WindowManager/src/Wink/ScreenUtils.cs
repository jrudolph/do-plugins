//  
//  Copyright (C) 2009 GNOME Do
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
// 

using System;
using System.Collections.Generic;
using System.Linq;

using Mono.Unix;

using Wnck;

namespace WindowManager.Wink
{
	
	
	public static class ScreenUtils
	{
		static bool initialized;
		static string ViewportFormatString = Catalog.GetString ("Desktop") + " {0}";
		static Dictionary<Workspace, Viewport [,]> layouts;
		
		public static event EventHandler ViewportsChanged;
		
		public static Viewport ActiveViewport {
			get {
				Workspace wsp = Wnck.Screen.Default.ActiveWorkspace;
				Gdk.Rectangle geo = new Gdk.Rectangle (wsp.ViewportX, wsp.ViewportY, wsp.Screen.Width, wsp.Screen.Height);
				if (Viewports.Any (vp => vp.IsActive))
					return Viewports.First (vp => vp.IsActive);
				return null;
			}
		}
		
		public static IEnumerable<Viewport> Viewports {
			get { 
				foreach (Viewport [,] layout in layouts.Values) {
					foreach (Viewport viewport in layout)
						yield return viewport;
				}
			}
		}
		
		public static void Initialize ()
		{
			if (initialized)
				return;
			
			initialized = true;
			Wnck.Global.ClientType = Wnck.ClientType.Pager;
			
			Wnck.Screen.Default.ViewportsChanged += HandleViewportsChanged;
			Wnck.Screen.Default.WorkspaceCreated += HandleWorkspaceCreated;
			Wnck.Screen.Default.WorkspaceDestroyed += HandleWorkspaceDestroyed;
			
			UpdateViewports ();
		}
		
		static void HandleWorkspaceDestroyed(object o, WorkspaceDestroyedArgs args)
		{
			UpdateViewports ();
		}

		static void HandleWorkspaceCreated(object o, WorkspaceCreatedArgs args)
		{
			UpdateViewports ();
		}

		static void HandleViewportsChanged(object sender, EventArgs e)
		{
			UpdateViewports ();
		}
		
		public static bool DesktopShown (Screen screen)
		{
			return screen.ShowingDesktop;
		}
		
		public static void ShowDesktop (Screen screen)
		{
			if (!screen.ShowingDesktop)
				screen.ToggleShowingDesktop (true);
		}
		
		public static void UnshowDesktop (Screen screen)
		{
			if (screen.ShowingDesktop)
				screen.ToggleShowingDesktop (false);
		}
		
		public static Viewport [,] ViewportLayout ()
		{
			return ViewportLayout (Wnck.Screen.Default.ActiveWorkspace);
		}
		
		public static Viewport [,] ViewportLayout (Workspace workspace)
		{
			if (!layouts.ContainsKey (workspace))
				return new Viewport [0,0];
			
			return layouts [workspace];
		}
		
		static void UpdateViewports ()
		{
			layouts = new Dictionary<Workspace, Viewport [,]> ();

			int currentViewport = 1;
			foreach (Wnck.Workspace workspace in Wnck.Screen.Default.Workspaces) {
				
				if (workspace.IsVirtual) {
					int viewportWidth;
					int viewportHeight;
					viewportWidth = workspace.Screen.Width;
					viewportHeight = workspace.Screen.Height;
					
					int rows = workspace.Height / viewportHeight;
					int columns = workspace.Width / viewportWidth;
					
					layouts [workspace] = new Viewport [rows, columns];
					
					for (int i = 0; i < rows; i++) {
						for (int j = 0; j < columns; j++) {
							Gdk.Rectangle area = new Gdk.Rectangle (j * viewportWidth,
							                                        i * viewportHeight,
							                                        viewportWidth,
							                                        viewportHeight);
							layouts [workspace] [i, j] = new Viewport (string.Format (ViewportFormatString, currentViewport),
							                                           area,
							                                           workspace);
							currentViewport++;
						}
					}
				} else {
					layouts [workspace] = new Viewport [1,1];
					Viewport viewport = new Viewport (string.Format (ViewportFormatString, currentViewport),
					                                  new Gdk.Rectangle (0, 0, workspace.Width, workspace.Height),
					                                  workspace);
					layouts [workspace] [0,0] = viewport;
					currentViewport++;
				}
			}
			if (ViewportsChanged != null)
				ViewportsChanged (new object (), EventArgs.Empty);
		}
	}
}
