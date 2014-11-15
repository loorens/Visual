using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2048
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Gra gra;
        public MainWindow()
        {
            InitializeComponent();
            
            gra = new Gra();
            gra.Random();
            gra.Random();
            Odswierz();
        }

        private void Odswierz()
        {
            c00.Text = gra.Get(0, 0).ToString();
            c01.Text = gra.Get(0, 1).ToString();
            c02.Text = gra.Get(0, 2).ToString();
            c03.Text = gra.Get(0, 3).ToString();

            c10.Text = gra.Get(1, 0).ToString();
            c11.Text = gra.Get(1, 1).ToString();
            c12.Text = gra.Get(1, 2).ToString();
            c13.Text = gra.Get(1, 3).ToString();

            c20.Text = gra.Get(2, 0).ToString();
            c21.Text = gra.Get(2, 1).ToString();
            c22.Text = gra.Get(2, 2).ToString();
            c23.Text = gra.Get(2, 3).ToString();

            c30.Text = gra.Get(3, 0).ToString();
            c31.Text = gra.Get(3, 1).ToString();
            c32.Text = gra.Get(3, 2).ToString();
            c33.Text = gra.Get(3, 3).ToString();
        }

        private void Board_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left)
            {
                gra.MoveLeft();
            }
            else if (e.Key == Key.Right)
            {
                gra.MoveRight();
            }
            else if (e.Key == Key.Up)
            {
                gra.MoveUp();
            }
            else if (e.Key == Key.Down)
            {
                gra.MoveDown();
            }
            if(e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Down || e.Key == Key.Up)
            {
                gra.Random();
                Odswierz();
            }

            
        }

        private void Board_Loaded(object sender, RoutedEventArgs e)
        {
            Board.Focus();
        }
    }
}
