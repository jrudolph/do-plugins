namespace Google_DocumentsList
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.documentsView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.Export = new System.Windows.Forms.Button();
            this.exportDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // documentsView
            // 
            this.documentsView.Dock = System.Windows.Forms.DockStyle.Left;
            this.documentsView.ImageIndex = 0;
            this.documentsView.ImageList = this.imageList;
            this.documentsView.Location = new System.Drawing.Point(0, 0);
            this.documentsView.Name = "documentsView";
            this.documentsView.SelectedImageIndex = 0;
            this.documentsView.Size = new System.Drawing.Size(392, 447);
            this.documentsView.TabIndex = 1;
            this.documentsView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.documentsView_AfterCollapse);
            this.documentsView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.documentsView_AfterSelect);
            this.documentsView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.documentsView_AfterExpand);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "CLSDFOLD.BMP");
            this.imageList.Images.SetKeyName(1, "OPENFOLD.BMP");
            this.imageList.Images.SetKeyName(2, "DOC.BMP");
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGrid1.Location = new System.Drawing.Point(392, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(355, 360);
            this.propertyGrid1.TabIndex = 2;
            // 
            // Export
            // 
            this.Export.Enabled = false;
            this.Export.Location = new System.Drawing.Point(409, 378);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(85, 33);
            this.Export.TabIndex = 3;
            this.Export.Text = "&Export";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 447);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.documentsView);
            this.Name = "Form1";
            this.Text = "Not logged in yet";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView documentsView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.SaveFileDialog exportDialog;
    }
}

