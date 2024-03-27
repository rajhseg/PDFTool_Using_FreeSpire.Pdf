
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PDFTextEdit
{
	/// <summary>
	/// Description of AddTextForm.
	/// </summary>
	public partial class AddTextForm : Form
	{
		public string TextToSearch {get;set;}
		
		public Color HighlightColor {get;set;}
		
		public AddTextForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			HighlightColor = Color.AliceBlue;
			colorpanel.BackColor = HighlightColor;
			
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			colorDialog1.ShowHelp = true;			
			colorDialog1.AllowFullOpen = true;
			var result = colorDialog1.ShowDialog();
			
			if(result== DialogResult.OK) {
				colorpanel.BackColor = colorDialog1.Color;
				HighlightColor = colorDialog1.Color;
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			TextToSearch = textBox1.Text;
			this.Close();
		}
	}
}
