
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Spire.Pdf;
using Spire.Pdf.General.Find;
using Spire.Pdf.Texts;

namespace PDFTextEdit
{
	/// <summary>
	/// Description of FindTextAndHighlight.
	/// </summary>
	public partial class FindTextAndHighlight : Form
	{
		List<ListViewHighlightModel> models = new List<ListViewHighlightModel>();
		
		public FindTextAndHighlight()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			listView1.View = View.List;
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Pdf files|*.pdf";
			openFileDialog1.Multiselect = false;
			openFileDialog1.ShowDialog();
			
			if(!string.IsNullOrEmpty(openFileDialog1.FileName))
			{
				textBox1.Text = openFileDialog1.FileName;
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			AddTextForm obj = new AddTextForm();
			obj.ShowDialog();
			
			if(!string.IsNullOrEmpty(obj.TextToSearch)){
				
				models.Add(new ListViewHighlightModel{HighlightColor = obj.HighlightColor, Text =obj.TextToSearch });
				
				listView1.Clear();
				
				foreach (var element in models) {
					ListViewItem item = new ListViewItem();
					item.BackColor = element.HighlightColor;
					item.ForeColor = Color.WhiteSmoke;
					item.Text = element.Text;
					listView1.Items.Add(item);
				}
				
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			if(!string.IsNullOrEmpty(textBox1.Text)){
			   var doc = new PdfDocument(textBox1.Text);						  
               FindTextInPDFAndReplaceIt(doc, models);
               
               string filename = (new FileInfo(textBox1.Text)).Name;
			   string uniqueID = Guid.NewGuid().ToString();
				
               string savePath = Path.Combine((new FileInfo(textBox1.Text)).Directory.FullName,"Find_Highlight_"+uniqueID+"_"+filename);
               doc.SaveToFile(savePath, Spire.Pdf.FileFormat.PDF);			
               MessageBox.Show("Texts highlight. path: "+savePath);
			}
		}
		
		 public static void FindTextInPDFAndReplaceIt(PdfDocument documents, List<ListViewHighlightModel> dictionary)
           {               
               foreach (var word in dictionary)
               {
                   foreach (PdfPageBase page in documents.Pages)
                   {
                   	                   	
					PdfTextFindOptions findOptions = new PdfTextFindOptions();            
            		findOptions.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase;               
                	PdfTextFinder finder = new PdfTextFinder(page);

	                //Set the text finding option	
	                finder.Options = findOptions;
	
	                //Find a specific text	
	                List<PdfTextFragment> results = finder.Find(word.Text);

                       foreach (var find in results)
                       {
                       	 find.HighLight(word.HighlightColor);                       	 
                       }
                   }
               }
           }

	}
}
