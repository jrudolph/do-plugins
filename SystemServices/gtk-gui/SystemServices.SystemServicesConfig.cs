// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace SystemServices {
    
    
    public partial class SystemServicesConfig {
        
        private Gtk.VBox vbox1;
        
        private Gtk.Label label1;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Entry eCommand;
        
        private Gtk.Button btnSelectFile;
        
        private Gtk.Label label2;
        
        private Gtk.ScrolledWindow scrolledwindow1;
        
        private Gtk.VBox boxServicesList;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget SystemServices.SystemServicesConfig
            Stetic.BinContainer.Attach(this);
            this.Name = "SystemServices.SystemServicesConfig";
            // Container child SystemServices.SystemServicesConfig.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            this.vbox1.BorderWidth = ((uint)(4));
            // Container child vbox1.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.Xalign = 0F;
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Command for start/stop services (gksudo, etc):");
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
            this.eCommand = new Gtk.Entry();
            this.eCommand.CanFocus = true;
            this.eCommand.Name = "eCommand";
            this.eCommand.IsEditable = true;
            this.eCommand.InvisibleChar = '●';
            this.hbox1.Add(this.eCommand);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox1[this.eCommand]));
            w2.Position = 0;
            // Container child hbox1.Gtk.Box+BoxChild
            this.btnSelectFile = new Gtk.Button();
            this.btnSelectFile.TooltipMarkup = "Select file";
            this.btnSelectFile.CanFocus = true;
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.UseUnderline = true;
            this.btnSelectFile.Label = Mono.Unix.Catalog.GetString("...");
            this.hbox1.Add(this.btnSelectFile);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox1[this.btnSelectFile]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            this.vbox1.Add(this.hbox1);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
            w4.Position = 1;
            w4.Expand = false;
            w4.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.Xalign = 0F;
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Services to control:");
            this.vbox1.Add(this.label2);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox1[this.label2]));
            w5.Position = 2;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.scrolledwindow1 = new Gtk.ScrolledWindow();
            this.scrolledwindow1.CanFocus = true;
            this.scrolledwindow1.Name = "scrolledwindow1";
            this.scrolledwindow1.ShadowType = ((Gtk.ShadowType)(1));
            // Container child scrolledwindow1.Gtk.Container+ContainerChild
            Gtk.Viewport w6 = new Gtk.Viewport();
            w6.ShadowType = ((Gtk.ShadowType)(0));
            // Container child GtkViewport.Gtk.Container+ContainerChild
            this.boxServicesList = new Gtk.VBox();
            this.boxServicesList.Name = "boxServicesList";
            this.boxServicesList.Spacing = 2;
            w6.Add(this.boxServicesList);
            this.scrolledwindow1.Add(w6);
            this.vbox1.Add(this.scrolledwindow1);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.vbox1[this.scrolledwindow1]));
            w9.Position = 3;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.eCommand.Changed += new System.EventHandler(this.OnECommandChanged);
            this.btnSelectFile.Clicked += new System.EventHandler(this.OnBtnSelectFileClicked);
        }
    }
}
