using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MvvmLines
{
    public class MainViewModel : INotifyPropertyChanged
    {

        #region Properties

        private ObservableCollection<Node> _nodes;
        public ObservableCollection<Node> Nodes
        {
            get { return _nodes; }
            set
            {
                _nodes = value;
                OnPropertyChanged("Nodes");
            }
        }

        private ObservableCollection<Line> _lines;
        public ObservableCollection<Line> Lines
        {
            get { return _lines; }
            set
            {
                _lines = value;
                OnPropertyChanged("Lines");
            }
        }

        private DiagramObject _selected;
        public DiagramObject Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged("Selected");
            }
        }



        #endregion

        public MainViewModel()
        {
            _nodes = new ObservableCollection<Node>(ObjectsDataSource.GetRandomNodes(10));
            _lines = new ObservableCollection<Line>(ObjectsDataSource.GetRandomLines(_nodes));


        }


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


    }
}
