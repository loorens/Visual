using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Northwind.Application.CustomerService;

namespace Northwind.ViewModel
{
    public class OrdersViewModel : ViewModelBase
    {
        public ObservableCollection<OrderViewModel> Orders { get; set; }

        public OrdersViewModel(Model.Customer model, IOrderViewModelFactory orderViewModelFactory)
        {
            Orders = new ObservableCollection<OrderViewModel>(model.Orders.Select(o => orderViewModelFactory.CreateInstance(o,model)));
        }
    }
}
