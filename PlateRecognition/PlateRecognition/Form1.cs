using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtsuThreshold;


///http://www.slideshare.net/zafergenc/finding-licence-plates-algorithm
///http://www.mif.pg.gda.pl/homepages/marcin/Wyklad3.pdf
///http://www.codeproject.com/Articles/38319/Famous-Otsu-Thresholding-in-C


namespace PlateRecognition
{
    public partial class Form1 : Form
    {
        List<string> files;
        List<Bitmap> bitmaps;
        public Form1()
        {
            InitializeComponent();
            trackBar1_ValueChanged(null, null);
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Images (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF*;*.PNG|" + "All files (*.*)|*.*";
            openDialog.Multiselect = true;
            openDialog.Title = "Wybierz zdjecia";
            DialogResult dr = openDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                files = openDialog.FileNames.ToList<string>();
                bitmaps = new List<Bitmap>();
                flowLayoutPanel1.Controls.Clear();
                foreach (var file in openDialog.FileNames)
                {
                    try
                    {
                        PictureBox pb = new PictureBox();
                        Image loadedImage = Bitmap.FromFile(file);// .FromFile(file);
                        bitmaps.Add(new Bitmap(loadedImage));
                        pb.Height = 100;
                        pb.Width = 100;
                        pb.Image = new Bitmap(loadedImage, new Size(100, 100));
                        flowLayoutPanel1.Controls.Add(pb);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Wystąpił problem podczas otwierania pliku");
                        //throw;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bitmaps.Count; i++)
            {
                try
                {
                    //bitmaps[i] = Converter.RgbToBinary(bitmaps[i],trackBar1.Value);
                    //((flowLayoutPanel1.Controls[i]) as PictureBox).Image = new Bitmap(bitmaps[i],100,100);
                    Otsu otsu = new Otsu();
                    otsu.Convert2GrayScaleFast(bitmaps[i]);
                    int tre = otsu.getOtsuThreshold(bitmaps[i]);

                    //otsu.threshold(bitmaps[i], tre);
                    bitmaps[i] = Converter.GrayToBinary(bitmaps[i], tre);
                    ((flowLayoutPanel1.Controls[i]) as PictureBox).Image = new Bitmap(bitmaps[i], 100, 100);
                    bitmaps[i].Save(@"E:\ocr\out0.jpg");
                    bitmaps[i] = ImageProcessing.Closing(bitmaps[i], 3, 3);
                    var bmpp = ImageProcessing.FindingLineWithPlate(bitmaps[i]);
                    bmpp.Save(@"E:\ocr\out3.jpg");
                }
                catch (Exception)
                {

                    MessageBox.Show("Blad");
                }

            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap tmp = ImageProcessing.Closing(bitmaps[0], 5, 5);
            tmp.Save(@"E:\ocr\out1.jpg");
            Bitmap tmp2 = ImageProcessing.Closing(bitmaps[0], 3, 3);
            tmp2.Save(@"E:\ocr\out2.jpg");
            MessageBox.Show("Done");
        }
    }
}

