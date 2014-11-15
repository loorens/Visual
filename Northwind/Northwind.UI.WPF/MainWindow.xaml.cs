using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Northwind.ViewModel;

namespace Northwind.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        //private MainWindowViewModel ViewModel
        //{
        //    get { return (MainWindowViewModel)DataContext; }
        //}
        //private void Hyperlink_Click(object sender, RoutedEventArgs e)
        //{
        //    ViewModel.ShowCustomerDetails();
        //}
        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((MainWindowViewModel)DataContext).ShowDetailsCommand.Execute(null);
        }
    }
}
