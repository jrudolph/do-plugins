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
    
    
    public partial class Configuration {
        
        private Gtk.VBox vbox1;
        
        private Gtk.Frame frame1;
        
        private Gtk.Alignment GtkAlignment;
        
        private Gtk.Alignment alignment1;
        
        private Gtk.VBox vbox2;
        
        private Gtk.Label label3;
        
        private Gtk.Button auth_btn;
        
        private Gtk.Label label4;
        
        private Gtk.Label auth_lbl;
        
        private Gtk.VBox vbox4;
        
        private Gtk.HSeparator hseparator2;
        
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
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget Flickr.Configuration
            Stetic.BinContainer.Attach(this);
            this.Name = "Flickr.Configuration";
            // Container child Flickr.Configuration.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            this.vbox1.BorderWidth = ((uint)(8));
            // Container child vbox1.Gtk.Box+BoxChild
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
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("Do needs your authorization in order to upload photos to your flickr account. Press the \"Authorize\" button to open a web browser and give Do authorization. ");
            this.label3.Wrap = true;
            this.vbox2.Add(this.label3);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox2[this.label3]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.auth_btn = new Gtk.Button();
            this.auth_btn.CanFocus = true;
            this.auth_btn.Name = "auth_btn";
            this.auth_btn.UseUnderline = true;
            // Container child auth_btn.Gtk.Container+ContainerChild
            Gtk.Alignment w2 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w3 = new Gtk.HBox();
            w3.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w4 = new Gtk.Image();
            w4.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-yes", Gtk.IconSize.Menu, 16);
            w3.Add(w4);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w6 = new Gtk.Label();
            w6.LabelProp = Mono.Unix.Catalog.GetString("_Authorize");
            w6.UseUnderline = true;
            w3.Add(w6);
            w2.Add(w3);
            this.auth_btn.Add(w2);
            this.vbox2.Add(this.auth_btn);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox2[this.auth_btn]));
            w10.Position = 1;
            w10.Expand = false;
            w10.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = "";
            this.vbox2.Add(this.label4);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.vbox2[this.label4]));
            w11.Position = 2;
            w11.Expand = false;
            w11.Fill = false;
            this.alignment1.Add(this.vbox2);
            this.GtkAlignment.Add(this.alignment1);
            this.frame1.Add(this.GtkAlignment);
            this.auth_lbl = new Gtk.Label();
            this.auth_lbl.Name = "auth_lbl";
            this.auth_lbl.LabelProp = Mono.Unix.Catalog.GetString("<b>Account</b>");
            this.auth_lbl.UseMarkup = true;
            this.frame1.LabelWidget = this.auth_lbl;
            this.vbox1.Add(this.frame1);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox1[this.frame1]));
            w15.Position = 0;
            w15.Expand = false;
            w15.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.vbox4 = new Gtk.VBox();
            this.vbox4.Name = "vbox4";
            this.vbox4.Spacing = 6;
            // Container child vbox4.Gtk.Box+BoxChild
            this.hseparator2 = new Gtk.HSeparator();
            this.hseparator2.Name = "hseparator2";
            this.vbox4.Add(this.hseparator2);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(this.vbox4[this.hseparator2]));
            w16.Position = 0;
            w16.Expand = false;
            w16.Fill = false;
            w16.Padding = ((uint)(5));
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
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.vbox6[this.private_radio]));
            w17.Position = 0;
            w17.Expand = false;
            w17.Fill = false;
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
            Gtk.Box.BoxChild w18 = ((Gtk.Box.BoxChild)(this.vbox7[this.friends_chk]));
            w18.Position = 0;
            w18.Expand = false;
            w18.Fill = false;
            // Container child vbox7.Gtk.Box+BoxChild
            this.family_chk = new Gtk.CheckButton();
            this.family_chk.CanFocus = true;
            this.family_chk.Name = "family_chk";
            this.family_chk.Label = Mono.Unix.Catalog.GetString("Visible to family");
            this.family_chk.DrawIndicator = true;
            this.family_chk.UseUnderline = true;
            this.vbox7.Add(this.family_chk);
            Gtk.Box.BoxChild w19 = ((Gtk.Box.BoxChild)(this.vbox7[this.family_chk]));
            w19.Position = 1;
            w19.Expand = false;
            w19.Fill = false;
            this.alignment4.Add(this.vbox7);
            this.vbox6.Add(this.alignment4);
            Gtk.Box.BoxChild w21 = ((Gtk.Box.BoxChild)(this.vbox6[this.alignment4]));
            w21.Position = 1;
            w21.Expand = false;
            w21.Fill = false;
            // Container child vbox6.Gtk.Box+BoxChild
            this.public_radio = new Gtk.RadioButton(Mono.Unix.Catalog.GetString("Public"));
            this.public_radio.CanFocus = true;
            this.public_radio.Name = "public_radio";
            this.public_radio.DrawIndicator = true;
            this.public_radio.UseUnderline = true;
            this.public_radio.Group = this.private_radio.Group;
            this.vbox6.Add(this.public_radio);
            Gtk.Box.BoxChild w22 = ((Gtk.Box.BoxChild)(this.vbox6[this.public_radio]));
            w22.Position = 2;
            w22.Expand = false;
            w22.Fill = false;
            this.GtkAlignment2.Add(this.vbox6);
            this.frame3.Add(this.GtkAlignment2);
            this.GtkLabel5 = new Gtk.Label();
            this.GtkLabel5.Name = "GtkLabel5";
            this.GtkLabel5.LabelProp = Mono.Unix.Catalog.GetString("<b>Viewing permissions</b>");
            this.GtkLabel5.UseMarkup = true;
            this.frame3.LabelWidget = this.GtkLabel5;
            this.vbox4.Add(this.frame3);
            Gtk.Box.BoxChild w25 = ((Gtk.Box.BoxChild)(this.vbox4[this.frame3]));
            w25.Position = 1;
            w25.Expand = false;
            w25.Fill = false;
            this.vbox1.Add(this.vbox4);
            Gtk.Box.BoxChild w26 = ((Gtk.Box.BoxChild)(this.vbox1[this.vbox4]));
            w26.Position = 1;
            w26.Expand = false;
            w26.Fill = false;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.auth_btn.Clicked += new System.EventHandler(this.OnAuthBtnClicked);
            this.private_radio.Toggled += new System.EventHandler(this.OnPrivateRadioToggled);
            this.friends_chk.Clicked += new System.EventHandler(this.OnFriendsChkClicked);
            this.family_chk.Clicked += new System.EventHandler(this.OnFamilyChkClicked);
            this.public_radio.Clicked += new System.EventHandler(this.OnPublicRadioClicked);
        }
    }
}
