
using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;

namespace PDFTextEdit
{
	/// <summary>
	/// Description of SplitPdfForm.
	/// </summary>
	public partial class SplitPdfForm : Form
	{
		public SplitPdfForm()
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
			openFileDialog1.Filter = "Pdf Files|*.pdf";			
			openFileDialog1.Multiselect = false;
			openFileDialog1.ShowDialog();
			
			if(!string.IsNullOrEmpty(openFileDialog1.FileName))
				textBox1.Text = openFileDialog1.FileName;
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			folderBrowserDialog1.ShowDialog();
			
			if(!string.IsNullOrEmpty(folderBrowserDialog1.SelectedPath)){
				textBox2.Text = folderBrowserDialog1.SelectedPath;
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			PdfDocument doc = new PdfDocument();
			doc.LoadFromFile(textBox1.Text);
			string unique = Guid.NewGuid().ToString();
			string outputPath = textBox2.Text+"\\splited_"+ unique + "_{0}.pdf";
			doc.Split(outputPath,int.Parse(numericUpDown1.Value.ToString()));
			MessageBox.Show("Files Splitted");
		}
	}
}
