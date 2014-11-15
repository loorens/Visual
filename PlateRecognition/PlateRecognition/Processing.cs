using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlateRecognition
{
    public static class Converter
    {
        public static Bitmap RgbToGray(Bitmap bmp)
        {
            Bitmap gray = new Bitmap(bmp.Width, bmp.Height);
            Color c;
            int g;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i,j);
                    // Y=0.299*R+0.587*G+0.114*B
                    g = (int)(0.299 * (float)c.R + 0.587 * (float)c.G + 0.114 * (float)c.B);
                    gray.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }

            return gray;
        }

        public static Bitmap GrayToBinary(Bitmap bmp, int treshold)
        {
            Bitmap binary = new Bitmap(bmp.Width, bmp.Height);
            Color c;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if(c.R < treshold)
                        binary.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    else
                        binary.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            }
            return binary;
        }

        public static Bitmap RgbToBinary(Bitmap bmp, int treshold)
        {
            return GrayToBinary(RgbToGray(bmp), treshold);
        }
    }


    public static class ImageProcessing
    {
        public static Bitmap Erosion(Bitmap bmp, int filterWidth, int filterHeight)
        {
            int filterOffsetWidth = (filterWidth - 1) / 2;
            int filterOffsetHeight = (filterHeight - 1) / 2;
            Color c;
            Bitmap b = new Bitmap(bmp);

            for (int i = filterOffsetHeight; i < b.Height - filterOffsetHeight; i++)
            {
                for (int j = filterOffsetWidth; j < b.Width - filterOffsetWidth; j++)
                {
                    //spardz kolor
                    c = bmp.GetPixel(j, i);
                    if (c.R == 255)
                        continue;
                    //wykonuj tylko dla czarnych pixeli
                    for (int k = -filterOffsetHeight; k <= filterOffsetHeight; k++)
                    {
                        for (int l = -filterOffsetWidth; l <= filterOffsetWidth; l++)
                        {
                            c = bmp.GetPixel(j + l, i + k);
                            if (c.R == 255)
                            {
                                b.SetPixel(j, i, Color.White);
                                //zakoncz 2 wewnetrzne petle
                                k = filterHeight;
                                l = filterWidth;
                            }
                        }
                    }
                }
            }
            return b;
        }

        public static Bitmap Dilation(Bitmap bmp, int filterWidth, int filterHeight)
        {
            int filterOffsetWidth = (filterWidth - 1) / 2;
            int filterOffsetHeight = (filterHeight - 1) / 2;
            Color c;
            Bitmap b = new Bitmap(bmp);

            for (int i = filterOffsetHeight; i < b.Height - filterOffsetHeight; i++)
            {
                for (int j = filterOffsetWidth; j < b.Width - filterOffsetWidth; j++)
                {
                    //spardz kolor
                    c = bmp.GetPixel(j, i);
                    if (c.R == 0)
                        continue;
                    //wykonuj tylko dla bialych pixeli
                    for (int k = -filterOffsetHeight; k <= filterOffsetHeight; k++)
                    {
                        for (int l = -filterOffsetWidth; l <= filterOffsetWidth; l++)
                        {
                            c = bmp.GetPixel(j + l, i + k);
                            if (c.R == 0)
                            {
                                b.SetPixel(j, i, Color.Black);
                                //zakoncz 2 wewnetrzne petle
                                k = filterHeight;
                                l = filterWidth;
                            }
                        }
                    }
                }
            }
            return b;
        }

        public static Bitmap Closing(Bitmap bmp, int filterWidth, int filterHeight)
        {
            return Erosion(Dilation(bmp, filterWidth, filterHeight), filterWidth, filterHeight);
        }

        public static Bitmap Opening(Bitmap bmp, int filterWidth, int filterHeight)
        {
            return Dilation(Erosion(bmp, filterWidth, filterHeight), filterWidth, filterHeight);
        }

        public static Bitmap FindingLineWithPlate(Bitmap bmp)
        {
            //Bitmap b = new Bitmap(bmp);
            int minNumberOfChange = 10; // minimalna ilość zmian z bialego na czern to 10
            int minAreaHeight = (int)bmp.Height / 10; //minimalna wysokosc tablicy to 10% obrazka

            //policz iliść zmian w każdej lini obrazu i zapisz w tablicy
            int[] numberOfChange = new int[bmp.Height];
            for (int i = 0; i < bmp.Height; i++)
            {
                int count = 0;
                for (int j = 0; j < bmp.Width - 1; j++)
                {
                    if (bmp.GetPixel(j, i).R != bmp.GetPixel(j + 1, i).R)
                        count++;
                }
                numberOfChange[i] = count;
            }


            //stowrz listę prostokątow które reprezentuja obszary w korych może wystąpic tablica
            // znajdz takie fragmenty gdzie ich wysokosc ma co najmniej 10% obrazu
            //dopuśc możliwość wystąpienia max 1 lini w któreych ilość zmian jest za mała
            List<Rectangle> areas = new List<Rectangle>();
            int areaHeight = 0, flag = 0, top = 0, bot = 0;
            for (int i = 0; i < numberOfChange.Length; i++)
            {
                if (numberOfChange[i] >= minNumberOfChange)
                {
                    areaHeight++;
                    bot=i;
                    if (top == 0) top = i;
                }
                else if (numberOfChange[i] < minNumberOfChange && flag < 1)
                {
                    areaHeight++;
                    bot=i;
                    flag++;
                }
                else
                {
                    if(areaHeight > minAreaHeight) areas.Add(new Rectangle(0, top, bmp.Width, areaHeight));
                    flag = 0;
                    areaHeight = 0;
                    bot = 0;
                    top = 0;
                }
            }

            /*
            for (int i = 0; i < numberOfChange.Length; i++)
            {
                if (numberOfChange[i] >= minNumberOfChange)
                {
                    numberOfChange[i] = 1;
                }
                else

                    numberOfChange[i] = 0;

            }*/


            if (areas.Count == 1)
            {
                return bmp.Clone(areas[0], bmp.PixelFormat);
            }
            else if (areas.Count > 1)
            {
                System.Windows.Forms.MessageBox.Show("Znaleziono za duzo tablic");
                return null;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nie znaleniono tablic");
                return null;
            }
            /*
            List<Bitmap> bmps = new List<Bitmap>();
            foreach (var item in areas)
            {
                var bbb = bmp.Clone(item, bmp.PixelFormat);
                bmps.Add(FilterProcessImage(bbb));
            }*/

        }


        //http://fukyo-it.blogspot.com/2012/09/image-processing-c-tutorial-3-edge.html
        public static Bitmap FilterProcessImage(Bitmap image)
         {
           Bitmap ret = new Bitmap(image.Width, image.Height);
           for (int i = 1; i < image.Width - 1; i++)
           {
               for (int j = 1; j < image.Height - 1; j++)
               {
                  Color cr = image.GetPixel(i + 1, j);
                  Color cl = image.GetPixel(i - 1, j);
                  Color cu = image.GetPixel(i, j - 1);
                  Color cd = image.GetPixel(i, j + 1);
                  Color cld = image.GetPixel(i - 1, j + 1);
                  Color clu = image.GetPixel(i - 1, j - 1);
                  Color crd = image.GetPixel(i + 1, j + 1);
                  Color cru = image.GetPixel(i + 1, j - 1);
                  int power = getMaxD(cr.R, cl.R, cu.R, cd.R, cld.R, clu.R, cru.R, crd.R);
                   if (power > 50)
                     ret.SetPixel(i, j, Color.Yellow);
                   else
                      ret.SetPixel(i, j, Color.Black);
                  }
              }
              return ret;
        }

        private static int getD(int cr, int cl, int cu, int cd, int cld, int clu, int cru, int crd, int[,] matrix)
        {
           return Math.Abs(  matrix[0, 0]*clu + matrix[0, 1]*cu + matrix[0, 2]*cru
              + matrix[1, 0]*cl + matrix[1, 2]*cr
                 + matrix[2, 0]*cld + matrix[2, 1]*cd + matrix[2, 2]*crd);
        }
        private static int getMaxD(int cr, int cl, int cu, int cd, int cld, int clu, int cru, int crd)
        {
           int max = int.MinValue;
           for (int i = 0; i < templates.Count; i++)
           {
              int newVal = getD(cr, cl, cu, cd, cld, clu, cru, crd, templates[i]);
              if (newVal > max)
                 max = newVal;
            }
            return max;
        }
        private static List<int[,]> templates = new List<int[,]> 
        {
           new int[,] {{ -3, -3, 5 }, { -3, 0, 5 }, { -3, -3, 5 } },
           new int[,] {{ -3, 5, 5 }, { -3, 0, 5 }, { -3, -3, -3 } },
           new int[,] {{ 5, 5, 5 }, { -3, 0, -3 }, { -3, -3, -3 } },
           new int[,] {{ 5, 5, -3 }, { 5, 0, -3 }, { -3, -3, -3 } },
           new int[,] {{ 5, -3, -3 }, { 5, 0, -3 }, { 5, -3, -3 } },
           new int[,] {{ -3, -3, -3 }, { 5, 0, -3 }, { 5, 5, -3 } },
           new int[,] {{ -3, -3, -3 }, { -3, 0, -3 }, { 5, 5, 5 } },
           new int[,] {{ -3, -3, -3 }, { -3, 0, 5 }, { -3, 5, 5 } }
        };


    }

    public static class MyClass
    {
        private static Bitmap SubtractAddFactorImage( 
                              this Bitmap subtractFrom, 
                                  Bitmap subtractValue, 
                                   float factor = 1.0f) 
        { 
            BitmapData sourceData =  
                       subtractFrom.LockBits(new Rectangle (0, 0, 
                       subtractFrom.Width, subtractFrom.Height), 
                       ImageLockMode.ReadOnly, 
                       PixelFormat.Format32bppArgb); 

  
            byte[] sourceBuffer = new byte[sourceData.Stride *  
                                           sourceData.Height]; 

  
            Marshal.Copy(sourceData.Scan0, sourceBuffer, 0,  
                                        sourceBuffer.Length); 

  
            byte[] resultBuffer = new byte[sourceData.Stride *  
                                           sourceData.Height]; 

  
            BitmapData subtractData =  
                       subtractValue.LockBits(new Rectangle (0, 0, 
                       subtractValue.Width, subtractValue.Height), 
                       ImageLockMode.ReadOnly, 
                       PixelFormat.Format32bppArgb); 

  
            byte[] subtractBuffer = new byte[subtractData.Stride * 
                                             subtractData.Height]; 

  
            Marshal.Copy(subtractData.Scan0, subtractBuffer, 0, 
                                         subtractBuffer.Length); 

  
            subtractFrom.UnlockBits(sourceData); 
            subtractValue.UnlockBits(subtractData); 

  
            double blue = 0; 
            double green = 0; 
            double red = 0; 

  
            for (int k = 0; k < resultBuffer.Length && 
                           k < subtractBuffer.Length; k += 4) 
            { 
                blue = sourceBuffer[k] +  
                      (sourceBuffer[k] - 
                       subtractBuffer[k]) * factor; 

  
                green = sourceBuffer[k + 1] +  
                       (sourceBuffer[k + 1] - 
                        subtractBuffer[k + 1]) * factor; 

  
                red = sourceBuffer[k + 2] +  
                     (sourceBuffer[k + 2] - 
                      subtractBuffer[k + 2]) * factor; 

  
                blue = (blue < 0 ? 0 : (blue > 255 ? 255 : blue)); 
                green = (green < 0 ? 0 : (green > 255 ? 255 : green)); 
                red = (red < 0 ? 0 : (red > 255 ? 255 : red)); 

  
                resultBuffer[k] = (byte )blue; 
                resultBuffer[k + 1] = (byte )green; 
                resultBuffer[k + 2] = (byte )red; 
                resultBuffer[k + 3] = 255; 
            }

  
            Bitmap resultBitmap = new Bitmap (subtractFrom.Width,  
                                             subtractFrom.Height); 

  
            BitmapData resultData =  
                       resultBitmap.LockBits(new Rectangle (0, 0, 
                       resultBitmap.Width, resultBitmap.Height), 
                       ImageLockMode.WriteOnly, 
                       PixelFormat.Format32bppArgb); 

  
            Marshal.Copy(resultBuffer, 0, resultData.Scan0,  
                                       resultBuffer.Length); 

  
            resultBitmap.UnlockBits(resultData); 

  
            return resultBitmap; 
        }

        public static class Matrix
        {
            public static double[,] Gaussian3x3
            {
                get
                {
                    return new double[,]
            { { 1, 2, 1, }, 
              { 2, 4, 2, }, 
              { 1, 2, 1, }, };
                }
            }


            public static double[,] Gaussian5x5Type1
            {
                get
                {
                    return new double[,]
            { { 2, 04, 05, 04, 2 }, 
              { 4, 09, 12, 09, 4 },
              { 5, 12, 15, 12, 5 },
              { 4, 09, 12, 09, 4 },
              { 2, 04, 05, 04, 2 }, };
                }
            }


            public static double[,] Mean3x3
            {
                get
                {
                    return new double[,]
            { { 1, 1, 1, }, 
              { 1, 1, 1, }, 
              { 1, 1, 1, }, };
                }
            }


            public static double[,] Mean5x5
            {
                get
                {
                    return new double[,]
            { { 1, 1, 1, 1, 1 }, 
              { 1, 1, 1, 1, 1 },
              { 1, 1, 1, 1, 1 },
              { 1, 1, 1, 1, 1 },
              { 1, 1, 1, 1, 1 }, };
                }
            }


        }


        /*
        public static Bitmap UnsharpGaussian3x3(
                                 this Bitmap sourceBitmap,
                                 float factor = 1.0f)
        {
            Bitmap blurBitmap = ExtBitmap.ConvolutionFilter(
                                          sourceBitmap,
                                          Matrix.Gaussian3x3,
                                          1.0 / 16.0);


            Bitmap resultBitmap =
                   sourceBitmap.SubtractAddFactorImage(
                                blurBitmap, factor);


            return resultBitmap;
        }


        public static Bitmap UnsharpGaussian5x5(
                                         this Bitmap sourceBitmap,
                                         float factor = 1.0f)
        {
            Bitmap blurBitmap = ExtBitmap.ConvolutionFilter(
                                          sourceBitmap,
                                          Matrix.Gaussian5x5Type1,
                                          1.0 / 159.0);


            Bitmap resultBitmap =
                   sourceBitmap.SubtractAddFactorImage(
                                blurBitmap, factor);


            return resultBitmap;
        }

        public static Bitmap UnsharpMean3x3(
                                         this Bitmap sourceBitmap,
                                         float factor = 1.0f)
        {
            Bitmap blurBitmap = ExtBitmap.ConvolutionFilter(
                                          sourceBitmap,
                                          Matrix.Mean3x3,
                                          1.0 / 9.0);


            Bitmap resultBitmap =
                   sourceBitmap.SubtractAddFactorImage(
                                blurBitmap, factor);


            return resultBitmap;
        }


        public static Bitmap UnsharpMean5x5(
                                         this Bitmap sourceBitmap,
                                         float factor = 1.0f)
        {
            Bitmap blurBitmap = ExtBitmap.ConvolutionFilter(
                                          sourceBitmap,
                                          Matrix.Mean5x5,
                                          1.0 / 25.0);


            Bitmap resultBitmap =
                   sourceBitmap.SubtractAddFactorImage(
                                blurBitmap, factor);


            return resultBitmap;
        }*/
    }
}
