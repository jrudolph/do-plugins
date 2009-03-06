// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace RequestTracker {
    
    
    public partial class RTPrefs {
        
        private Gtk.VBox vbox1;
        
        private Gtk.Label label1;
        
        private Gtk.HBox hbox1;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.NodeView RTTree;
        
        private Gtk.VButtonBox vbuttonbox1;
        
        private Gtk.Button add_btn;
        
        private Gtk.Button remove_btn;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget RequestTracker.RTPrefs
            Stetic.BinContainer.Attach(this);
            this.Name = "RequestTracker.RTPrefs";
            // Container child RequestTracker.RTPrefs.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("<b>Request Trackers</b>\n\nUse the list below to add/configure your Request Tracker sites.\n\n<i>The ticket number will be inserted into the URL at the place specified by the string: {0}</i>");
            this.label1.UseMarkup = true;
            this.label1.Wrap = true;
            this.label1.Justify = ((Gtk.Justification)(2));
            this.vbox1.Add(this.label1);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.vbox1[this.label1]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.RTTree = new Gtk.NodeView();
            this.RTTree.CanFocus = true;
            this.RTTree.Name = "RTTree";
            this.GtkScrolledWindow.Add(this.RTTree);
            this.hbox1.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox1[this.GtkScrolledWindow]));
            w3.Position = 0;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vbuttonbox1 = new Gtk.VButtonBox();
            this.vbuttonbox1.Name = "vbuttonbox1";
            this.vbuttonbox1.LayoutStyle = ((Gtk.ButtonBoxStyle)(3));
            // Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
            this.add_btn = new Gtk.Button();
            this.add_btn.CanFocus = true;
            this.add_btn.Name = "add_btn";
            this.add_btn.UseStock = true;
            this.add_btn.UseUnderline = true;
            this.add_btn.Label = "gtk-add";
            this.vbuttonbox1.Add(this.add_btn);
            Gtk.ButtonBox.ButtonBoxChild w4 = ((Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.add_btn]));
            w4.Expand = false;
            w4.Fill = false;
            // Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
            this.remove_btn = new Gtk.Button();
            this.remove_btn.CanFocus = true;
            this.remove_btn.Name = "remove_btn";
            this.remove_btn.UseStock = true;
            this.remove_btn.UseUnderline = true;
            this.remove_btn.Label = "gtk-remove";
            this.vbuttonbox1.Add(this.remove_btn);
            Gtk.ButtonBox.ButtonBoxChild w5 = ((Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.remove_btn]));
            w5.Position = 1;
            w5.Expand = false;
            w5.Fill = false;
            this.hbox1.Add(this.vbuttonbox1);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbuttonbox1]));
            w6.Position = 1;
            w6.Expand = false;
            w6.Fill = false;
            this.vbox1.Add(this.hbox1);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
            w7.Position = 1;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Hide();
            this.add_btn.Clicked += new System.EventHandler(this.OnAddBtnClicked);
            this.remove_btn.Clicked += new System.EventHandler(this.OnRemoveBtnClicked);
        }
    }
}
