using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmLines
{
    public class Line : DiagramObject
    {
        private Node _start;
        public Node Start
        {
            get { return _start; }
            set
            {
                _start = value;
                OnPropertyChanged("Start");
            }
        }

        private Node _end;
        public Node End
        {
            get { return _end; }
            set
            {
                _end = value;
                OnPropertyChanged("End");
            }
        }
    }
}
