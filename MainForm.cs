﻿
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.General.Find;
using Spire.Pdf.Texts;

namespace PDFTextEdit
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
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
			string pdfPath = textBox3.Text;
			
			if(!string.IsNullOrEmpty(pdfPath)){
				string filename = (new FileInfo(pdfPath)).Name;
				string uniqueID = Guid.NewGuid().ToString();
				string savePath = Path.Combine((new FileInfo(pdfPath)).Directory.FullName,"replaced_"+uniqueID+"_"+filename);
				if(!string.IsNullOrEmpty(pdfPath))  {
					PdfDocument doc = new PdfDocument(pdfPath);
	            	Dictionary<string, string> dictionary = new Dictionary<string, string>(); 
					
	            	if(!string.IsNullOrEmpty(textBox1.Text))
	            	{
	            		dictionary.Add(textBox1.Text, textBox2.Text);
	            		FindTextInPDFAndReplaceIt(doc, dictionary); 
	            	}
	            	 
	            	doc.SaveToFile(savePath, FileFormat.PDF);
	            	MessageBox.Show("Text replaced "+savePath);
				}
			}
		}
		
		public static void FindTextInPDFAndReplaceIt(PdfDocument documents, Dictionary<string, string> dictionary)  
        {  
            PdfTextFind[] result = null;  
            foreach (var word in dictionary)  
            {  
                foreach (PdfPageBase page in documents.Pages)  
                {  
                	PdfTextReplacer replacer = new PdfTextReplacer(page);
                	PdfTextReplaceOptions options = new PdfTextReplaceOptions();
                	
                	options.ReplaceType = PdfTextReplaceOptions.ReplaceActionType.IgnoreCase;                	
                	replacer.Options = options;                	
                	replacer.ReplaceAllText(word.Key, word.Value);                	 
                }  
            }  
        }  
		
		void Button2Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Pdf Files|*.pdf";
			openFileDialog1.FileName = "";
			openFileDialog1.ShowDialog();
			
			if(!string.IsNullOrEmpty(openFileDialog1.FileName)) {
				textBox3.Text = openFileDialog1.FileName;
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			string pdfPath = textBox3.Text;
			
			if(!string.IsNullOrEmpty(pdfPath)){
				string filename = (new FileInfo(pdfPath)).Name;
				string uniqueID = Guid.NewGuid().ToString();
				
				string savePath = Path.Combine((new FileInfo(pdfPath)).Directory.FullName,"converted_"+filename.Split('.')[0]+"_"+uniqueID+".docx");
				if(!string.IsNullOrEmpty(pdfPath))  {
					PdfDocument doc = new PdfDocument(pdfPath);	         

					Dictionary<string, string> dictionary = new Dictionary<string, string>();  
	            		            	
	            	if(!string.IsNullOrEmpty(textBox1.Text))
	            	{
	            		dictionary.Add(textBox1.Text, textBox2.Text);
	            		FindTextInPDFAndReplaceIt(doc, dictionary); 
	            	}
	            	
	            	doc.SaveToFile(savePath, FileFormat.DOCX);
	            	
	            	MessageBox.Show("Converted to Word "+savePath);
				}
			}
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			string pdfPath = textBox3.Text;
			
			if(!string.IsNullOrEmpty(pdfPath)){
				string filename = (new FileInfo(pdfPath)).Name;
				string uniqueID = Guid.NewGuid().ToString();
				
				string savePath = Path.Combine((new FileInfo(pdfPath)).Directory.FullName,"converted_"+filename.Split('.')[0]+"_"+uniqueID+".html");
				if(!string.IsNullOrEmpty(pdfPath))  {
					PdfDocument doc = new PdfDocument(pdfPath);	      

					Dictionary<string, string> dictionary = new Dictionary<string, string>();  
	            	
	            	if(!string.IsNullOrEmpty(textBox1.Text))
	            	{
	            		dictionary.Add(textBox1.Text, textBox2.Text);
	            		FindTextInPDFAndReplaceIt(doc, dictionary); 
	            	}
	            	
	            	doc.SaveToFile(savePath, FileFormat.HTML);
	            	
	            	MessageBox.Show("Converted to Html "+savePath);
				}
			}
			
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			MergePdfForm mergeForm = new MergePdfForm();
			mergeForm.ShowDialog();
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			SplitPdfForm splitForm = new SplitPdfForm();
			splitForm.ShowDialog();
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			FindTextAndHighlight obj =new FindTextAndHighlight();
			obj.ShowDialog();
		}

        private async void button8_Click(object sender, EventArgs e)
        {
            string pdfPath = textBox3.Text;

			if (!string.IsNullOrEmpty(pdfPath))
			{
				await Task.Run(() => ConvertPdfToImages(pdfPath));
            }
			else 
			{ 
				MessageBox.Show("Please select a PDF file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void ConvertPdfToImages(string pdfPath)
        {
            PdfDocument doc = new PdfDocument(pdfPath);

            var resX = !string.IsNullOrEmpty(resolutionX.Text) ? int.Parse(resolutionX.Text) : 300;
            var resY = !string.IsNullOrEmpty(resolutionY.Text) ? int.Parse(resolutionY.Text) : 300;

            for (int i = 0; i < doc.Pages.Count; i++)
            {
                FileInfo fi = new FileInfo(pdfPath);
                var finame = fi.Name.Substring(0, fi.Name.LastIndexOf('.'));
                var img = doc.SaveAsImage(i, Spire.Pdf.Graphics.PdfImageType.Bitmap, resX, resY);
                img.Save(Path.Combine(Path.GetDirectoryName(pdfPath), $"{finame}_Page_{i + 1}.png"), System.Drawing.Imaging.ImageFormat.Png);
            }

            MessageBox.Show("PDF pages converted to images successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button9_Click(object sender, EventArgs e)
        {
			ImagesToPdf imagesToPdf = new ImagesToPdf();
            imagesToPdf.ShowDialog();
        }
    }
}
