using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Application;
using Northwind.Application.CustomerService;

namespace Northwind.ViewModel
{
    /*public class ViewModelLocator
    {
        private static MainWindowViewModel _mainWindowViewModel;

        public static MainWindowViewModel MainWindowViewModelStatic
        {
            get {
                return _mainWindowViewModel ??
                       (_mainWindowViewModel = new MainWindowViewModel(
                           new UiDataProvider(
                               new CustomerServiceClient()),
                           new ToolManager()));
            }
        }

    }*/
}
