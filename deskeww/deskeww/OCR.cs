using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Ocr
{
    /// <summary>
    /// definuje graniczne wspolzedne punktow i listę tych punktów
    /// </summary>
    public class OCRObject
    {
        public int Top { get; set; }
        public int Bottom { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public List<Point> Points { get; set; }
        public OCRObject()
        {
            Points = new List<Point>();
        }
        public OCRObject(int top, int bot, int left, int right, List<Point> points)
        {
            Points = points;
            Top = top;
            Bottom = bot;
            Left = left;
            Right = right;
        }
    }

    /// <summary>
    /// klasa wyszukajaca połączonych ze sobą zbiorów punktów
    /// </summary>
    public class OCR
    {
        Bitmap bitmap;
        Color color;
        double luminance;
        bool[,] visited;
        int width, height;
        List<Point> obiekty;
        List<List<Point>> listaObiektow; //lista listy punktow
        List<OCRObject> listaOCR; // lista znalezionych obektow
        public OCR(Bitmap bmp)
        {
            bitmap = bmp;
            width = bitmap.Width;
            height = bitmap.Height;
            visited = new bool[width, height];
            listaObiektow = new List<List<Point>>();
        }

        /// <summary>
        /// główna funkcja szukająca czarnych grup obiektów
        /// </summary>
        /// <returns></returns>
        public int FindOCRObjects()
        {
            //znajdowanie grup punktów
            DateTime start = DateTime.Now;
            for (int i = 1; i < width; i++)
            {
                for (int j = 1; j < height; j++)
                {
                    if( IsBlack(i,j) && visited[i,j] == false)
                    {
                        FindOBJ(i, j);
                    }
                }
            }

            //tworzenie listy obiektów z znalezionych grup
            listaOCR = new List<OCRObject>();
            foreach (var obiekt in listaObiektow)
            {
                if(obiekt.Count > 2)
                {
                    OCRObject obj = new OCRObject(obiekt[0].X, obiekt[0].X, obiekt[0].Y, obiekt[0].Y, obiekt);
                    for (int i = 1; i < obiekt.Count; i++)
                    {
                        if (obiekt[i].X < obj.Top) obj.Top = obiekt[i].X;
                        if (obiekt[i].X > obj.Bottom) obj.Bottom = obiekt[i].X;
                        if (obiekt[i].Y < obj.Left) obj.Left = obiekt[i].Y;
                        if (obiekt[i].Y > obj.Right) obj.Right = obiekt[i].Y;
                    }
                    listaOCR.Add(obj);
                }
            }

            //System.Windows.Forms.MessageBox.Show(listaOCR.Count.ToString());
            return 0;
        }


        /// <summary>
        /// funkcja znajduje punkty połączone ze sobą i zapisuje je do listy listy punktów
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void FindOBJ(int i, int j)
        {
            int x = i, y = j;
            visited[i, j] = true;
            obiekty = new List<Point>();
            List<Point> obiektyTemp = new List<Point>();
            obiekty.Add(new Point(i, j));
            obiektyTemp.Add(new Point(i, j));
            bool flaga = true;
            while(flaga)
            {
                flaga = false;
                for (int k = obiektyTemp.Count - 1; k >= 0; k--)
                {
                    x = obiektyTemp[k].X;
                    y = obiektyTemp[k].Y;
                    if (x > 0 && IsBlack(x -1 , y) && !visited[x-1,y])
                    {
                        obiekty.Add(new Point(x - 1, y));
                        obiektyTemp.Add(new Point(x - 1, y));
                        visited[x - 1, y] = true;
                        flaga = true;
                    }
                    if (x < width && IsBlack(x + 1, y) && !visited[x + 1, y])
                    {
                        obiekty.Add(new Point(x + 1, y));
                        obiektyTemp.Add(new Point(x + 1, y));
                        visited[x + 1, y] = true;
                        flaga = true;
                    }
                    if (y > 0 && IsBlack(x, y - 1) && !visited[x, y - 1])
                    {
                        obiekty.Add(new Point(x, y - 1));
                        obiektyTemp.Add(new Point(x, y - 1));
                        visited[x, y - 1] = true;
                        flaga = true;
                    }
                    if (y < height && IsBlack(x, y + 1) && !visited[x, y + 1])
                    {
                        obiekty.Add(new Point(x, y + 1));
                        obiektyTemp.Add(new Point(x, y + 1));
                        visited[x, y + 1] = true;
                        flaga = true;
                    }
                    obiektyTemp.RemoveAt(k);
                }

            }
            listaObiektow.Add(obiekty);
        }

        private bool IsBlack(Point p)
        {
            return IsBlack(p.X, p.Y);
        }

        private bool IsBlack(int x, int y)
        {
            color = bitmap.GetPixel(x, y);
            luminance = (color.R * 0.299) + (color.G * 0.587) + (color.B * 0.114);
            return luminance < 140;
        }

        /// <summary>
        /// rysowanie prostokąta na znalezionych obiektach
        /// </summary>
        /// <returns></returns>
        public Bitmap DrawRect()
        {

            Rectangle[] rect = new Rectangle[listaOCR.Count];
            for (int i = 0; i < listaOCR.Count; i++)
			{
			    rect[i] = new Rectangle(listaOCR[i].Top-1, listaOCR[i].Left-1, listaOCR[i].Bottom + 1 - listaOCR[i].Top,  listaOCR[i].Right + 1 - listaOCR[i].Left);
			}
            Pen blackPen = new Pen(Color.Red, 1);
            Bitmap tmp = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format32bppRgb);
            tmp.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);

            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawRectangles(blackPen, rect);
            }
           
            return bitmap;

        }


    }
}
