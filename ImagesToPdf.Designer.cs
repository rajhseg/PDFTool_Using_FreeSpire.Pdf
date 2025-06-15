namespace PDFTextEdit
{
    partial class ImagesToPdf
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
            this.SelectedFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.marginSize = new System.Windows.Forms.NumericUpDown();
            this.savePdf = new System.Windows.Forms.SaveFileDialog();
            this.BrowseFiles = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pdfOrientation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pdfSize = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.marginSize)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectedFiles
            // 
            this.SelectedFiles.FormattingEnabled = true;
            this.SelectedFiles.ItemHeight = 16;
            this.SelectedFiles.Location = new System.Drawing.Point(39, 41);
            this.SelectedFiles.Name = "SelectedFiles";
            this.SelectedFiles.Size = new System.Drawing.Size(607, 372);
            this.SelectedFiles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(666, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "PDF Margin :";
            // 
            // marginSize
            // 
            this.marginSize.Location = new System.Drawing.Point(669, 233);
            this.marginSize.Name = "marginSize";
            this.marginSize.Size = new System.Drawing.Size(51, 22);
            this.marginSize.TabIndex = 2;
            // 
            // BrowseFiles
            // 
            this.BrowseFiles.FileName = "openFileDialog1";
            this.BrowseFiles.Multiselect = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(669, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "Browse Images";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(669, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "Covert To PDF";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(669, 89);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 37);
            this.button3.TabIndex = 5;
            this.button3.Text = "Clear Images";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(666, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Orientation :";
            // 
            // pdfOrientation
            // 
            this.pdfOrientation.FormattingEnabled = true;
            this.pdfOrientation.Items.AddRange(new object[] {
            "Portrait",
            "Landscape"});
            this.pdfOrientation.Location = new System.Drawing.Point(669, 290);
            this.pdfOrientation.Name = "pdfOrientation";
            this.pdfOrientation.Size = new System.Drawing.Size(121, 24);
            this.pdfOrientation.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(666, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Size :";
            // 
            // pdfSize
            // 
            this.pdfSize.FormattingEnabled = true;
            this.pdfSize.Items.AddRange(new object[] {
            "Note",
            "Legal",
            "Letter",
            "Ledger",
            "A0",
            "A1",
            "A2",
            "A3",
            "A4",
            "A5",
            "A6",
            "A7",
            "A8",
            "A9",
            "A10"});
            this.pdfSize.Location = new System.Drawing.Point(669, 344);
            this.pdfSize.Name = "pdfSize";
            this.pdfSize.Size = new System.Drawing.Size(121, 24);
            this.pdfSize.TabIndex = 9;
            // 
            // ImagesToPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 450);
            this.Controls.Add(this.pdfSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pdfOrientation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.marginSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectedFiles);
            this.MaximumSize = new System.Drawing.Size(853, 497);
            this.Name = "ImagesToPdf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImagesToPdf";
            ((System.ComponentModel.ISupportInitialize)(this.marginSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox SelectedFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown marginSize;
        private System.Windows.Forms.SaveFileDialog savePdf;
        private System.Windows.Forms.OpenFileDialog BrowseFiles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox pdfOrientation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox pdfSize;
    }
}