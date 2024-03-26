
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;

namespace PDFTextEdit
{
	/// <summary>
	/// Description of MergePdfForm.
	/// </summary>
	public partial class MergePdfForm : Form
	{
		
		private List<string> filenames = new List<string>();
		
		public MergePdfForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			
			openFileDialog1.Multiselect = true;
			openFileDialog1.Filter = "Pdf Files|*.pdf";
			openFileDialog1.FileName = "";
			openFileDialog1.ShowDialog();
			
			if(openFileDialog1.FileNames.Length>0) {
				
				foreach (string fname in openFileDialog1.FileNames) {				
					if(!string.IsNullOrEmpty(fname))
						filenames.Add(fname);
				}
				
				listView1.Items.Clear();
				foreach (var element in filenames) {
					listView1.Items.Add(new ListViewItem(element));
				}
			}
			
			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			PdfDocumentBase pdf = PdfDocument.MergeFiles(filenames.ToArray());
			pdf.Save(textBox1.Text, FileFormat.PDF);
			MessageBox.Show("Files Merged : "+ textBox1.Text);
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			saveFileDialog1.Filter = "Pdf Files|*.pdf";
			saveFileDialog1.ShowDialog();
			textBox1.Text = saveFileDialog1.FileName;
		}
		
		void MergePdfFormLoad(object sender, EventArgs e)
		{
			listView1.Columns.Add("File Path",200, HorizontalAlignment.Left);
			
			foreach (ColumnHeader element in listView1.Columns) {
				element.Width = -1;
			}
			
			listView1.View = View.List;
		}
	}
}
