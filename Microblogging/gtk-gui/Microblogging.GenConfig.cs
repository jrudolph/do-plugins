// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Microblogging {
    
    
    public partial class GenConfig {
        
        private Gtk.VBox vbox1;
        
        private Gtk.Frame frame1;
        
        private Gtk.Alignment GtkAlignment;
        
        private Gtk.VBox vbox2;
        
        private Gtk.CheckButton show_updates_chk;
        
        private Gtk.CheckButton show_dms_chk;
        
        private Gtk.Label GtkLabel1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget Microblogging.GenConfig
            Stetic.BinContainer.Attach(this);
            this.Name = "Microblogging.GenConfig";
            // Container child Microblogging.GenConfig.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            this.vbox1.BorderWidth = ((uint)(5));
            // Container child vbox1.Gtk.Box+BoxChild
            this.frame1 = new Gtk.Frame();
            this.frame1.Name = "frame1";
            this.frame1.ShadowType = ((Gtk.ShadowType)(0));
            // Container child frame1.Gtk.Container+ContainerChild
            this.GtkAlignment = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment.Name = "GtkAlignment";
            this.GtkAlignment.LeftPadding = ((uint)(12));
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.show_updates_chk = new Gtk.CheckButton();
            this.show_updates_chk.CanFocus = true;
            this.show_updates_chk.Name = "show_updates_chk";
            this.show_updates_chk.Label = Mono.Addins.AddinManager.CurrentLocalizer.GetString("Show friend status updates");
            this.show_updates_chk.Active = true;
            this.show_updates_chk.DrawIndicator = true;
            this.show_updates_chk.UseUnderline = true;
            this.vbox2.Add(this.show_updates_chk);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox2[this.show_updates_chk]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            w1.Padding = ((uint)(5));
            // Container child vbox2.Gtk.Box+BoxChild
            this.show_dms_chk = new Gtk.CheckButton();
            this.show_dms_chk.CanFocus = true;
            this.show_dms_chk.Name = "show_dms_chk";
            this.show_dms_chk.Label = Mono.Addins.AddinManager.CurrentLocalizer.GetString("Show direct messages");
            this.show_dms_chk.Active = true;
            this.show_dms_chk.DrawIndicator = true;
            this.show_dms_chk.UseUnderline = true;
            this.vbox2.Add(this.show_dms_chk);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox2[this.show_dms_chk]));
            w2.Position = 1;
            w2.Expand = false;
            w2.Fill = false;
            this.GtkAlignment.Add(this.vbox2);
            this.frame1.Add(this.GtkAlignment);
            this.GtkLabel1 = new Gtk.Label();
            this.GtkLabel1.Name = "GtkLabel1";
            this.GtkLabel1.LabelProp = Mono.Addins.AddinManager.CurrentLocalizer.GetString("<b>General</b>");
            this.GtkLabel1.UseMarkup = true;
            this.frame1.LabelWidget = this.GtkLabel1;
            this.vbox1.Add(this.frame1);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox1[this.frame1]));
            w5.Position = 0;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.show_updates_chk.Clicked += new System.EventHandler(this.OnShowUpdatesChkClicked);
            this.show_dms_chk.Clicked += new System.EventHandler(this.OnShowDMsChkClicked);
        }
    }
}
