using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Ocr
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(@"D:\test2.png");
            pictureBox1.Image = bmp;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OCR ocr = new OCR(bmp);
            ocr.FindOCRObjects();
            pictureBox1.Image = ocr.DrawRect();
            /*
            Deskew deskew = new Deskew(bmp);
            pictureBox1.Image = deskew.DeskewImage();*/

        }
    }
}
