using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public class Cell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int? cell = null;
        public int? Celll
        {
            get
            {
                return cell;
            }
            set
            {
                cell = value;
                OnPropertyChanged("Cell");
            }

        }



        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
    }
    class Board : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Cell> r;

        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
    }

    public class Gra
    {
        int?[,] tab;
        int nn;
        int randMax;
        public int?[,] Tab
        {
            get { return tab; }
            set { tab = value; }
        }
        public Gra(int n=4)
        {
            randMax = 1;
            nn=n;
            tab = new int?[n, n];
        }
        public int? Get(int x,int y)
        {
            return tab[x, y];
        }
        public void Set(int x, int y, int? n)
        {
            tab[x, y] = n;
        }
        public void Random()
        {
            if (CheckFull()) return;
            Random r = new Random();
            while (true)
            {
                int x = r.Next(nn);
                int y = r.Next(nn);
                if(tab[x,y] == null)
                {
                    tab[x, y] = r.Next(1,randMax) * 2;
                    break;
                }
            }
        }

        public bool CheckFull()
        {
            for (int i = 0; i < nn; i++)
			{
			    for (int j = 0; j < nn; j++)
			    {
                    if (tab[i, j] == null)
                        return false;
			    }
			}
            return true;

        }

        public void MoveLeft()
        {
            
            for (int i = 0; i < nn; i++)
            {
                for (int j = 1; j < nn; j++)
                {
                    if (tab[i,j] != null && tab[i,j-1] == null)
                    {
                        tab[i, j-1] = tab[i, j];
                        tab[i, j] = null;
                        if (j > 1) j=0;
                    }
                    else if (tab[i,j] != null && tab[i,j-1] != null && tab[i,j] == tab[i,j-1])
                    {
                        tab[i, j - 1] *= 2;
                        tab[i, j] = null;
                    }
                }
            }
        }

        public void MoveRight()
        {

            for (int i = 0; i < nn; i++)
            {
                for (int j = nn-1; j > 0; j--)
                {
                    if (tab[i, j] == null && tab[i, j - 1] != null)
                    {
                        tab[i, j] = tab[i, j - 1];
                        tab[i, j - 1] = null;
                        j = nn;
                    }
                    else if (tab[i, j] != null && tab[i, j - 1] != null && tab[i, j] == tab[i, j - 1])
                    {
                        tab[i, j] *= 2;
                        tab[i, j - 1] = null;
                    }
                }
            }
        }

        public void MoveUp()
        {

            for (int j = 0; j < nn; j++)
            {
                for (int i = 1; i < nn; i++)
                {
                    if (tab[i, j] != null && tab[i - 1, j] == null)
                    {
                        tab[i - 1, j] = tab[i, j];
                        tab[i, j] = null;
                        i = 0;
                    }
                    else if (tab[i, j] != null && tab[i - 1, j] != null && tab[i, j] == tab[i - 1, j])
                    {
                        tab[i - 1, j] *= 2;
                        tab[i, j] = null;
                    }
                }
            }
        }

        public void MoveDown()
        {

            for (int j = 0; j < nn; j++)
            {
                for (int i = nn - 1; i > 0; i--)
                {
                    if (tab[i, j] == null && tab[i - 1, j] != null)
                    {
                        tab[i, j] = tab[i - 1, j];
                        tab[i - 1, j] = null;
                        i = nn;
                    }
                    else if (tab[i, j] != null && tab[i - 1, j] != null && tab[i, j] == tab[i - 1, j])
                    {
                        tab[i, j] *= 2;
                        tab[i - 1, j] = null;
                    }
                }
            }
        }
    }

}
