using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace PodzialObrazow
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("spike2");
            string[] pliki = Directory.GetFiles(Directory.GetCurrentDirectory() + "/spike");
            int i = 1;
            foreach (var plik in pliki)
            {
                
                Bitmap bmp = Bitmap.FromFile(plik) as Bitmap;
                Bitmap bmp2 = bmp.Clone(new Rectangle(0, 0, bmp.Width, 840), bmp.PixelFormat);
                bmp.Dispose();
                bmp2.Save(Directory.GetCurrentDirectory() + "/spike2/"+i.ToString()+".png",ImageFormat.Png);
                i++;
                /*bmp2 = bmp.Clone(new Rectangle(bmp.Width / 2, 0, bmp.Width / 2, bmp.Height / 2), bmp.PixelFormat);
                bmp2.Save(Directory.GetCurrentDirectory() + "/lotto2/" + i.ToString() + ".png");
                i++;
                bmp2 = bmp.Clone(new Rectangle(0, bmp.Height / 2, bmp.Width / 2, bmp.Height / 2), bmp.PixelFormat);
                bmp2.Save(Directory.GetCurrentDirectory() + "/lotto2/" + i.ToString() + ".png");
                i++;
                bmp2 = bmp.Clone(new Rectangle(bmp.Width / 2, bmp.Height / 2, bmp.Width / 2, bmp.Height / 2), bmp.PixelFormat);
                bmp2.Save(Directory.GetCurrentDirectory() + "/lotto2/" + i.ToString() + ".png");
                i++;*/
                    
            }


        }
    }
}
