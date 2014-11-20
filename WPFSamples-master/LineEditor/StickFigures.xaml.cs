using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace LineEditor
{
    public partial class StickFigures : Window
    {
        public ObservableCollection<LineViewModel> Lines { get; set; }

        public StickFigures()
        {
            InitializeComponent();

            Lines = new ObservableCollection<LineViewModel>(LinesDataSource.GetRandomLines());

            DataContext = Lines;
        }
    }
}
