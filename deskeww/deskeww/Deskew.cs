using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace Ocr
{
    public class Deskew
    {
        /*
         * http://www.codeproject.com/Articles/13615/How-to-deskew-an-image
         * 
        */
        //Reprezentacja lini w obrazie
        public class HoughLine
        {
            // Liczba punktów na jednej lini
            public int Count;
            // index w matryce Hugha
            public int Index;
            //' The line is represented as all x,y that solve y*cos(alpha)-x*sin(alpha)=d
            public double Alpha;
            public double d;
        }

        // Bitmapa do przekształcen
        Bitmap bitmap;
        // Zakres kątów do sprawdzania
        int alphaStart; //kąt minimalny
        double alphaStep; //krok kąta
        int alphaStepsCount; //ilość kroków kąta
        // -45, 0.2, 450 -> od -45 do +45 co 0.2 stopnia
        // tablice sin i cos dla wszystkich kątów alpha
        double[] sinAlpha;
        double[] cosAlpha;
        // zmienne pomocnicze
        double dMin;
        double dStep = 1;
        int dCount; //liczba punktów na jednej lini
        //tablica Hougha na wszystkie możliwe linie
        int[] HoughMatrix;

        //zmienne pomocnicze
        Color color;
        double luminance;

        /// <summary>
        /// Konstuktor klasy tworzący obiekt obrazu oraz podaje parametry kątów przetwarzania
        /// </summary>
        /// <param name="bmp">Bitmapa do przetworzenia</param>
        /// <param name="aStart">Kąt początkowy</param>
        /// <param name="aStep">Krok dla kąta</param>
        /// <param name="aStepsCount">Liczba kroków dla kąta</param>
        public Deskew(Bitmap bmp, int aStart = -45, double aStep = 0.2, int aStepsCount = 450 )
        {
            bitmap = bmp;
            alphaStart = aStart;
            alphaStep = aStep;
            alphaStepsCount = aStepsCount; 
            // 450 = (45*2 / 0.2)
        }
        /// <summary>
        /// Funkcja "prostująca" bitmapę
        /// </summary>
        /// <returns>wyprostowana bitmapa</returns>
        public Bitmap DeskewImage()
        {
            return Deskew.RotateImage(this.bitmap, GetSkewAngle());
        }

        /// <summary>
        /// Obliczanie kąta obrotu obrazu
        /// </summary>
        /// <returns>kąt obrotu</returns>
        public double GetSkewAngle()
        {
            // Hough Transformation
            Calc();

            // Wyznaczenie 20 lini z najwieksza iloscia punktów
            int count = 20;
            HoughLine[] hl = GetTop(20);

            //Obliczenie średniego kąta
            double sum = 0;
            for (int i = 0; i < count; i++)
                sum += hl[i].Alpha;

            return -(sum / count);
        }

        /// <summary>
        /// Funkcja wybiera linie z największą liczbą punktów
        /// </summary>
        /// <param name="Count">Liczba lini którą ma zwrócić funkcja</param>
        /// <returns>Tablica linii o najwiekszej ilości punktów</returns>
        private HoughLine[] GetTop(int Count)
        {
            int j;
            HoughLine tmp;
            int AlphaIndex, dIndex;
            HoughLine[]  hl = new HoughLine[Count];
            for (int i = 0; i < Count; i++)
                hl[i] = new HoughLine();

            for (int i = 0; i < HoughMatrix.Length - 1; i++)
            {
                // jeżeli wynik danej lini jest lepszy niż najgorszy wynik w tabeli top
                if (HoughMatrix[i] > hl[Count - 1].Count)
                {
                    hl[Count - 1].Count = HoughMatrix[i];
                    hl[Count - 1].Index = i;
                    j = Count - 1;
                    //sortowanie przez przesówanie "w górę" tablicy
                    while (j > 0 && hl[j].Count > hl[j - 1].Count)
                    {
                        tmp = hl[j];
                        hl[j] = hl[j - 1];
                        hl[j - 1] = tmp;
                        j -= 1;
                    }
                }
            }
            // obliczanie kątów
            for (int i = 0; i < Count; i++)
            {
                dIndex = hl[i].Index / alphaStepsCount;
                AlphaIndex = hl[i].Index - dIndex * alphaStepsCount;
                hl[i].Alpha = GetAlpha(AlphaIndex);
                hl[i].d = dIndex + dMin;
            }
            return hl;
        }


        /// <summary>
        /// Transformacja Hougha
        /// </summary>
        private void Calc()
        {
            int hMin = bitmap.Height / 4;
            int hMax = bitmap.Height * 3 / 4;
            //inicjalizacja tablic
            Init();
            for (int y = hMin; y < hMax; y++)
            {
                for (int x = 1; x < bitmap.Width - 2; x++)
                {
                    // Tylko punkty które są czarne a pod nimi są punkty białe
                    if (IsBlack(x, y) == true && IsBlack(x, y + 1) == false)
                    {
                        Calc(x, y);
                    }
                }
            }
        }

        /// <summary>
        /// Obliczenia dla lini przechodzących przez podany punkt
        /// </summary>
        /// <param name="x">współrzędna x punktu</param>
        /// <param name="y">współrzędna y punktu</param>
        private void Calc(int x, int y)
        {
            double d;
            int dIndex;
            int Index;
            for (int alpha = 0; alpha < alphaStepsCount; alpha++)
            {
                d = y * cosAlpha[alpha] - x * sinAlpha[alpha]; // where the magic happens
                dIndex = Convert.ToInt32(d - dMin);
                Index = dIndex * alphaStepsCount + alpha;
                try
                {
                    HoughMatrix[Index] += 1;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Sprawdzanie czy punkt jest czarny
        /// </summary>
        /// <param name="x">wsp. x pkt</param>
        /// <param name="y">wsp. y pkt</param>
        /// <returns>Czy punkt jest czarny</returns>
        private bool IsBlack(int x, int y)
        {
            color = bitmap.GetPixel(x, y);
            luminance = (color.R * 0.299) + (color.G * 0.587) + (color.B * 0.114);
            return luminance < 140;
        }
        /// <summary>
        /// Inicjalizacja tablicy sin i cos, i tablicy lini Hougha
        /// </summary>
        private void Init()
        {
            double angle;
            // Obliczanie tablicy sin i cos dla każdego możliwego kąta alpha
            sinAlpha = new double[alphaStepsCount];
            cosAlpha = new double[alphaStepsCount];
            for (int i = 0; i < alphaStepsCount; i++)
            {
                angle = GetAlpha(i) * Math.PI / 180.0;
                sinAlpha[i] = Math.Sin(angle);
                cosAlpha[i] = Math.Cos(angle);
            }
            
            //zmienne pomocnicze do tablicy Hougha
            dMin = -bitmap.Width;
            dCount = (int)(2 * (bitmap.Width + bitmap.Height) / dStep);
            HoughMatrix = new int[dCount * alphaStepsCount];
        }
        /// <summary>
        /// Funkcja zwracająca kąt alpha + index od początkowego kąta
        /// </summary>
        /// <param name="index">Index kąta do przesunięcia</param>
        /// <returns>kąt alhpa</returns>
        public double GetAlpha(int index)
        {
            return (double)alphaStart + index * alphaStep;
        }
        /// <summary>
        /// Funkcja obracająca bitmapę o zadany kąt
        /// </summary>
        /// <param name="bmp">Bitmapa do obrócenia</param>
        /// <param name="angle">kąt obrotu</param>
        /// <returns>Bitmapa obrócona o kąt</returns>
        public static Bitmap RotateImage(Bitmap bmp, double angle)
        {
            Bitmap tmp = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppRgb);
            tmp.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);
            Graphics g = Graphics.FromImage(tmp);
            try
            {
                g.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
                g.RotateTransform((float)angle);
                g.DrawImage(bmp, 0, 0);
            }
            finally
            {
                g.Dispose();
            }
            return tmp;
        }

    }
}
