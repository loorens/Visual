using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmLines
{
    public class Node : DiagramObject
    {
        private int _x;
        public int X
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged("X");
            }
        }

        private int _y;
        public int Y
        {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged("Y");
            }
        }
    }
}
