// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Pastebin {
    
    
    public partial class PastebinConfig {
        
        private Gtk.VBox vbox1;
        
        private Gtk.Frame frame1;
        
        private Gtk.Alignment GtkAlignment;
        
        private Gtk.VBox vbox2;
        
        private Gtk.RadioButton Paste2RadioButton;
        
        private Gtk.RadioButton PastebinCARadioButton;
        
        private Gtk.RadioButton LodgeItRadioButton;
        
        private Gtk.Label GtkLabel2;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget Pastebin.PastebinConfig
            Stetic.BinContainer.Attach(this);
            this.Name = "Pastebin.PastebinConfig";
            // Container child Pastebin.PastebinConfig.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
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
            this.Paste2RadioButton = new Gtk.RadioButton(Mono.Unix.Catalog.GetString("Paste2.org"));
            this.Paste2RadioButton.CanFocus = true;
            this.Paste2RadioButton.Name = "Paste2RadioButton";
            this.Paste2RadioButton.Active = true;
            this.Paste2RadioButton.DrawIndicator = true;
            this.Paste2RadioButton.UseUnderline = true;
            this.Paste2RadioButton.Group = new GLib.SList(System.IntPtr.Zero);
            this.vbox2.Add(this.Paste2RadioButton);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox2[this.Paste2RadioButton]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.PastebinCARadioButton = new Gtk.RadioButton(Mono.Unix.Catalog.GetString("pastebin.ca"));
            this.PastebinCARadioButton.CanFocus = true;
            this.PastebinCARadioButton.Name = "PastebinCARadioButton";
            this.PastebinCARadioButton.DrawIndicator = true;
            this.PastebinCARadioButton.UseUnderline = true;
            this.PastebinCARadioButton.Group = this.Paste2RadioButton.Group;
            this.vbox2.Add(this.PastebinCARadioButton);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox2[this.PastebinCARadioButton]));
            w2.Position = 1;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.LodgeItRadioButton = new Gtk.RadioButton(Mono.Unix.Catalog.GetString("paste.pocoo.org"));
            this.LodgeItRadioButton.CanFocus = true;
            this.LodgeItRadioButton.Name = "LodgeItRadioButton";
            this.LodgeItRadioButton.DrawIndicator = true;
            this.LodgeItRadioButton.UseUnderline = true;
            this.LodgeItRadioButton.Group = this.Paste2RadioButton.Group;
            this.vbox2.Add(this.LodgeItRadioButton);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.LodgeItRadioButton]));
            w3.Position = 2;
            w3.Expand = false;
            w3.Fill = false;
            this.GtkAlignment.Add(this.vbox2);
            this.frame1.Add(this.GtkAlignment);
            this.GtkLabel2 = new Gtk.Label();
            this.GtkLabel2.Name = "GtkLabel2";
            this.GtkLabel2.LabelProp = Mono.Unix.Catalog.GetString("<b>Pastebin Provider</b>");
            this.GtkLabel2.UseMarkup = true;
            this.frame1.LabelWidget = this.GtkLabel2;
            this.vbox1.Add(this.frame1);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox1[this.frame1]));
            w6.Position = 0;
            w6.Expand = false;
            w6.Fill = false;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.Paste2RadioButton.Toggled += new System.EventHandler(this.OnPaste2Toggled);
            this.PastebinCARadioButton.Toggled += new System.EventHandler(this.OnPastebinCAToggled);
            this.LodgeItRadioButton.Toggled += new System.EventHandler(this.OnPastebinCAToggled);
        }
    }
}
