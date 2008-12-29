// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Flickr {
    
    
    public partial class UploadConfig {
        
        private Gtk.VBox vbox3;
        
        private Gtk.VBox vbox4;
        
        private Gtk.Frame frame3;
        
        private Gtk.Alignment GtkAlignment2;
        
        private Gtk.VBox vbox6;
        
        private Gtk.RadioButton private_radio;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.VBox vbox7;
        
        private Gtk.CheckButton friends_chk;
        
        private Gtk.CheckButton family_chk;
        
        private Gtk.RadioButton public_radio;
        
        private Gtk.Label GtkLabel5;
        
        private Gtk.Frame frame1;
        
        private Gtk.Alignment GtkAlignment;
        
        private Gtk.Alignment alignment1;
        
        private Gtk.VBox vbox5;
        
        private Gtk.Label label1;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TextView tags_text;
        
        private Gtk.Label GtkLabel4;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget Flickr.UploadConfig
            Stetic.BinContainer.Attach(this);
            this.Name = "Flickr.UploadConfig";
            // Container child Flickr.UploadConfig.Gtk.Container+ContainerChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            this.vbox3.BorderWidth = ((uint)(5));
            // Container child vbox3.Gtk.Box+BoxChild
            this.vbox4 = new Gtk.VBox();
            this.vbox4.Name = "vbox4";
            this.vbox4.Spacing = 6;
            // Container child vbox4.Gtk.Box+BoxChild
            this.frame3 = new Gtk.Frame();
            this.frame3.Name = "frame3";
            this.frame3.ShadowType = ((Gtk.ShadowType)(0));
            // Container child frame3.Gtk.Container+ContainerChild
            this.GtkAlignment2 = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment2.Name = "GtkAlignment2";
            this.GtkAlignment2.LeftPadding = ((uint)(12));
            // Container child GtkAlignment2.Gtk.Container+ContainerChild
            this.vbox6 = new Gtk.VBox();
            this.vbox6.Name = "vbox6";
            this.vbox6.Spacing = 6;
            // Container child vbox6.Gtk.Box+BoxChild
            this.private_radio = new Gtk.RadioButton(Mono.Unix.Catalog.GetString("Private"));
            this.private_radio.CanFocus = true;
            this.private_radio.Name = "private_radio";
            this.private_radio.Active = true;
            this.private_radio.DrawIndicator = true;
            this.private_radio.UseUnderline = true;
            this.private_radio.Group = new GLib.SList(System.IntPtr.Zero);
            this.vbox6.Add(this.private_radio);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox6[this.private_radio]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox6.Gtk.Box+BoxChild
            this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment4.Name = "alignment4";
            this.alignment4.LeftPadding = ((uint)(24));
            // Container child alignment4.Gtk.Container+ContainerChild
            this.vbox7 = new Gtk.VBox();
            this.vbox7.Name = "vbox7";
            this.vbox7.Spacing = 6;
            // Container child vbox7.Gtk.Box+BoxChild
            this.friends_chk = new Gtk.CheckButton();
            this.friends_chk.CanFocus = true;
            this.friends_chk.Name = "friends_chk";
            this.friends_chk.Label = Mono.Unix.Catalog.GetString("Visible to friends");
            this.friends_chk.DrawIndicator = true;
            this.friends_chk.UseUnderline = true;
            this.vbox7.Add(this.friends_chk);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox7[this.friends_chk]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox7.Gtk.Box+BoxChild
            this.family_chk = new Gtk.CheckButton();
            this.family_chk.CanFocus = true;
            this.family_chk.Name = "family_chk";
            this.family_chk.Label = Mono.Unix.Catalog.GetString("Visible to family");
            this.family_chk.DrawIndicator = true;
            this.family_chk.UseUnderline = true;
            this.vbox7.Add(this.family_chk);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox7[this.family_chk]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            this.alignment4.Add(this.vbox7);
            this.vbox6.Add(this.alignment4);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox6[this.alignment4]));
            w5.Position = 1;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox6.Gtk.Box+BoxChild
            this.public_radio = new Gtk.RadioButton(Mono.Unix.Catalog.GetString("Public"));
            this.public_radio.CanFocus = true;
            this.public_radio.Name = "public_radio";
            this.public_radio.DrawIndicator = true;
            this.public_radio.UseUnderline = true;
            this.public_radio.Group = this.private_radio.Group;
            this.vbox6.Add(this.public_radio);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox6[this.public_radio]));
            w6.Position = 2;
            w6.Expand = false;
            w6.Fill = false;
            this.GtkAlignment2.Add(this.vbox6);
            this.frame3.Add(this.GtkAlignment2);
            this.GtkLabel5 = new Gtk.Label();
            this.GtkLabel5.Name = "GtkLabel5";
            this.GtkLabel5.LabelProp = Mono.Unix.Catalog.GetString("<b>Viewing permissions</b>");
            this.GtkLabel5.UseMarkup = true;
            this.frame3.LabelWidget = this.GtkLabel5;
            this.vbox4.Add(this.frame3);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.vbox4[this.frame3]));
            w9.Position = 0;
            w9.Expand = false;
            w9.Fill = false;
            this.vbox3.Add(this.vbox4);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox3[this.vbox4]));
            w10.Position = 0;
            w10.Expand = false;
            w10.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.frame1 = new Gtk.Frame();
            this.frame1.Name = "frame1";
            this.frame1.ShadowType = ((Gtk.ShadowType)(0));
            // Container child frame1.Gtk.Container+ContainerChild
            this.GtkAlignment = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment.Name = "GtkAlignment";
            this.GtkAlignment.LeftPadding = ((uint)(12));
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            this.alignment1.LeftPadding = ((uint)(12));
            // Container child alignment1.Gtk.Container+ContainerChild
            this.vbox5 = new Gtk.VBox();
            this.vbox5.Name = "vbox5";
            this.vbox5.Spacing = 6;
            // Container child vbox5.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.Xalign = 0F;
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Default tags to use on images posted with Do. Seperate tags with a space; for multiple word tags use quotes. ex.) concert \"Mars Volta\" Omar");
            this.label1.Wrap = true;
            this.vbox5.Add(this.label1);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.vbox5[this.label1]));
            w11.Position = 0;
            w11.Expand = false;
            w11.Fill = false;
            // Container child vbox5.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.HscrollbarPolicy = ((Gtk.PolicyType)(2));
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.tags_text = new Gtk.TextView();
            this.tags_text.CanFocus = true;
            this.tags_text.Name = "tags_text";
            this.tags_text.AcceptsTab = false;
            this.tags_text.WrapMode = ((Gtk.WrapMode)(2));
            this.GtkScrolledWindow.Add(this.tags_text);
            this.vbox5.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox5[this.GtkScrolledWindow]));
            w13.Position = 1;
            this.alignment1.Add(this.vbox5);
            this.GtkAlignment.Add(this.alignment1);
            this.frame1.Add(this.GtkAlignment);
            this.GtkLabel4 = new Gtk.Label();
            this.GtkLabel4.Name = "GtkLabel4";
            this.GtkLabel4.LabelProp = Mono.Unix.Catalog.GetString("<b>Tags</b>");
            this.GtkLabel4.UseMarkup = true;
            this.frame1.LabelWidget = this.GtkLabel4;
            this.vbox3.Add(this.frame1);
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.vbox3[this.frame1]));
            w17.Position = 1;
            this.Add(this.vbox3);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.private_radio.Toggled += new System.EventHandler(this.OnPrivateRadioToggled);
            this.friends_chk.Clicked += new System.EventHandler(this.OnFriendsChkClicked);
            this.family_chk.Clicked += new System.EventHandler(this.OnFamilyChkClicked);
            this.public_radio.Toggled += new System.EventHandler(this.OnPublicRadioToggled);
        }
    }
}
