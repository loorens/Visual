using ParsingPLAN;
using System;
using System.Collections.Generic;
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
using Newtonsoft.Json;

namespace PLAN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Parser pars = new Parser("http://www.mech.pk.edu.pl/~podzial/stacjonarne/plany/o74.html");
            string json = pars.Parsing();
            int n =7;

            Dictionary<string,string>[] dict = new Dictionary<string,string>[n];
            for (int i = 0; i < n; i++)
            {
                dict[i] = new Dictionary<string, string>();
            }
            dict = JsonConvert.DeserializeObject<Dictionary<string, string>[]>(json);
            int nn;
        }
    }
}
