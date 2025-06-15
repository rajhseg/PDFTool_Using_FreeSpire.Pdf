using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFTextEdit
{
    public partial class ImagesToPdf : Form
    {
        List<string> imageFiles = new List<string>();

        public ImagesToPdf()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BrowseFiles.Multiselect = true;
            BrowseFiles.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            BrowseFiles.Title = "Select Images to Convert to PDF";
            BrowseFiles.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            BrowseFiles.RestoreDirectory = true;
            BrowseFiles.ShowDialog();

            if (BrowseFiles.FileNames.Length > 0)
            {
                imageFiles.AddRange(BrowseFiles.FileNames);
                SelectedFiles.Items.AddRange(BrowseFiles.FileNames);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imageFiles.Clear();
            SelectedFiles.Items.Clear();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (imageFiles.Count == 0)
            {
                MessageBox.Show("Please select images first.");
                return;
            }


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.Title = "Save PDF File";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ShowDialog();


            if (saveFileDialog.FileName != "")
            {
                try
                {
                    using (Spire.Pdf.PdfDocument pdfDocument = new Spire.Pdf.PdfDocument())
                    {
                        pdfDocument.PageSettings.Orientation = (Spire.Pdf.PdfPageOrientation)Enum.Parse(typeof(Spire.Pdf.PdfPageOrientation), pdfOrientation.SelectedItem.ToString());
                        pdfDocument.PageSettings.Size = GetSize();
                        pdfDocument.PageSettings.SetMargins(float.Parse(marginSize.Value.ToString()));

                        await Task.Run(() =>
                        {
                            foreach (var imageFile in imageFiles)
                            {
                                Spire.Pdf.Graphics.PdfImage image = Spire.Pdf.Graphics.PdfImage.FromFile(imageFile);
                                Spire.Pdf.PdfPageBase page = pdfDocument.Pages.Add();

                                page.Canvas.DrawImage(image, 0, 0, page.Canvas.ClientSize.Width, page.Canvas.ClientSize.Height);

                            }

                            pdfDocument.SaveToFile(saveFileDialog.FileName);

                        });
                    }


                    MessageBox.Show("Images converted to PDF successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private SizeF GetSize()
        {
            switch(pdfSize.SelectedItem.ToString())
            {
                case "Letter":
                    return Spire.Pdf.PdfPageSize.Letter;
                case "Note":
                    return Spire.Pdf.PdfPageSize.Note;
                case "Ledger":
                    return Spire.Pdf.PdfPageSize.Ledger;
                case "A0":
                    return Spire.Pdf.PdfPageSize.A0;
                case "A1":
                    return Spire.Pdf.PdfPageSize.A1;
                case "A2":
                    return Spire.Pdf.PdfPageSize.A2;
                case "A4":
                    return Spire.Pdf.PdfPageSize.A4;
                case "A3":
                    return Spire.Pdf.PdfPageSize.A3;
                case "A5":
                    return Spire.Pdf.PdfPageSize.A5;
                case "A6":
                    return Spire.Pdf.PdfPageSize.A6;
                case "A7":
                    return Spire.Pdf.PdfPageSize.A7;
                case "A8":
                    return Spire.Pdf.PdfPageSize.A8;
                case "A9":
                    return Spire.Pdf.PdfPageSize.A9;
                case "A10":
                    return Spire.Pdf.PdfPageSize.A10;
                case "Legal":
                    return Spire.Pdf.PdfPageSize.Legal;
                case "ArchA":
                    return Spire.Pdf.PdfPageSize.ArchA;
                case "ArchB":
                    return Spire.Pdf.PdfPageSize.ArchB;
                case "ArchC":
                    return Spire.Pdf.PdfPageSize.ArchC;
                case "ArchD":
                    return Spire.Pdf.PdfPageSize.ArchD;
                case "ArchE":
                    return Spire.Pdf.PdfPageSize.ArchE;
                default:
                    return Spire.Pdf.PdfPageSize.A4; // Default size if none matched
            }
        }
    }
}
