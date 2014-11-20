﻿using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = Enumerable.Range(0,1000)
                                    .Select(x => new DataItem
                                    {
                                        DisplayName = "Item" + x.ToString(),
                                        IsHighlighted = x % 2 == 0 && x > 500
                                    })
                                    .ToList();
        }
    }
}
