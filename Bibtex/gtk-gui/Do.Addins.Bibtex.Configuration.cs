// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Do.Addins.Bibtex {
    
    
    public partial class Configuration {
        
        private Gtk.Alignment alignment1;
        
        private Gtk.Table table1;
        
        private Gtk.Label bibtexFileLabel;
        
        private Gtk.FileChooserButton chooseBibtexFileButton;
        
        private Gtk.FileChooserButton chooseDocsFolderButton;
        
        private Gtk.Label docFolderLable;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget Do.Addins.Bibtex.Configuration
            Stetic.BinContainer.Attach(this);
            this.Name = "Do.Addins.Bibtex.Configuration";
            // Container child Do.Addins.Bibtex.Configuration.Gtk.Container+ContainerChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            // Container child alignment1.Gtk.Container+ContainerChild
            this.table1 = new Gtk.Table(((uint)(2)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            // Container child table1.Gtk.Table+TableChild
            this.bibtexFileLabel = new Gtk.Label();
            this.bibtexFileLabel.Name = "bibtexFileLabel";
            this.bibtexFileLabel.LabelProp = Mono.Unix.Catalog.GetString("Choose BibTeX file");
            this.table1.Add(this.bibtexFileLabel);
            Gtk.Table.TableChild w1 = ((Gtk.Table.TableChild)(this.table1[this.bibtexFileLabel]));
            w1.XOptions = ((Gtk.AttachOptions)(4));
            w1.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.chooseBibtexFileButton = new Gtk.FileChooserButton(Mono.Unix.Catalog.GetString("Select A File"), ((Gtk.FileChooserAction)(0)));
            this.chooseBibtexFileButton.Name = "chooseBibtexFileButton";
            this.table1.Add(this.chooseBibtexFileButton);
            Gtk.Table.TableChild w2 = ((Gtk.Table.TableChild)(this.table1[this.chooseBibtexFileButton]));
            w2.LeftAttach = ((uint)(1));
            w2.RightAttach = ((uint)(2));
            w2.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.chooseDocsFolderButton = new Gtk.FileChooserButton(Mono.Unix.Catalog.GetString("Select your documents folder"), ((Gtk.FileChooserAction)(2)));
            this.chooseDocsFolderButton.Name = "chooseDocsFolderButton";
            this.chooseDocsFolderButton.ShowHidden = true;
            this.table1.Add(this.chooseDocsFolderButton);
            Gtk.Table.TableChild w3 = ((Gtk.Table.TableChild)(this.table1[this.chooseDocsFolderButton]));
            w3.TopAttach = ((uint)(1));
            w3.BottomAttach = ((uint)(2));
            w3.LeftAttach = ((uint)(1));
            w3.RightAttach = ((uint)(2));
            w3.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.docFolderLable = new Gtk.Label();
            this.docFolderLable.Name = "docFolderLable";
            this.docFolderLable.LabelProp = Mono.Unix.Catalog.GetString("Choose documents folder");
            this.table1.Add(this.docFolderLable);
            Gtk.Table.TableChild w4 = ((Gtk.Table.TableChild)(this.table1[this.docFolderLable]));
            w4.TopAttach = ((uint)(1));
            w4.BottomAttach = ((uint)(2));
            w4.XOptions = ((Gtk.AttachOptions)(4));
            w4.YOptions = ((Gtk.AttachOptions)(4));
            this.alignment1.Add(this.table1);
            this.Add(this.alignment1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.chooseDocsFolderButton.SelectionChanged += new System.EventHandler(this.OnChooseDocsFolderButtonSelectionChanged);
            this.chooseBibtexFileButton.SelectionChanged += new System.EventHandler(this.OnChooseBibtexFileButtonSelectionChanged);
        }
    }
}
