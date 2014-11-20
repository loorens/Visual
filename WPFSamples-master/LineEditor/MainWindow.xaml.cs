using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Diagnostics;

namespace LineEditor
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// An ObservableCollection that will serve as ItemsSource for the ListBox
        /// </summary>
        public ObservableCollection<LineViewModel> Lines { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Lines = new ObservableCollection<LineViewModel>(LinesDataSource.GetRandomLines());

            DataContext = Lines;
        }

        private void AddLine_Click(object sender, RoutedEventArgs e)
        {
            var newline = LinesDataSource.GetRandomLine(Lines.Count);
            Lines.Add(newline);
            
            lst.SelectedItem = newline;
        }

        private void RemoveLine_Click(object sender, RoutedEventArgs e)
        {
            var item = lst.SelectedItem as LineViewModel;
            if (item != null)
            {
                item.StopTimer();
                Lines.Remove(item);
                lst.SelectedItem = null;
            }
        }

        private void TextBox_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var txt = sender as TextBox;

            if (txt == null)
                return;

            int txtvalue;
            if (int.TryParse(txt.Text,out txtvalue))
            {
                txt.Text = (txtvalue + e.Delta / 10).ToString();
            }
        }

        private int ZIndex = 99;

        private void BringToTop_Click(object sender, RoutedEventArgs e)
        {
            var line = lst.SelectedItem as LineViewModel;
            if (line != null)
            {
                var listboxitem = lst.ItemContainerGenerator.ContainerFromItem(line) as ListBoxItem;
                if (listboxitem != null)
                    Panel.SetZIndex(listboxitem,ZIndex++);
            }
        }

        private void HyperLink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            var hyperlink = sender as Hyperlink;
            if (hyperlink != null)
            {
                Process.Start(hyperlink.NavigateUri.AbsoluteUri);
            }
        }
    }
}
