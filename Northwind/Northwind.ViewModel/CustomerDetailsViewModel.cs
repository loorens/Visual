using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using Northwind.Application;
using Northwind.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.ViewModel
{
    public class CustomerDetailsViewModel : ToolViewModel
    {
        private readonly IUiDataProvider _dataProvider;
        private readonly IOrdersViewModelFactory _ordersViewModelFactory;
        private RelayCommand _updateCommand;
        public Customer Customer { get; set; }
        private bool _isDirty;
        private OrdersViewModel _orders;

        public OrdersViewModel Orders
        {
            get
            {
                if (Customer == null)
                {
                    return null;
                }
                return _orders ??
                       (_orders = _ordersViewModelFactory.CreateInstance(Customer));
            }
            
        }

        public RelayCommand UpdateCommand
        {
            get
            {
                return _updateCommand ??
                       (_updateCommand = new RelayCommand(UpdateCustomer, CanUpdateCustomer));
            }

        }

        private bool CanUpdateCustomer()
        {
            return _isDirty;
        }

        private void UpdateCustomer()
        {
            _dataProvider.Update(Customer);
        }


        public CustomerDetailsViewModel(
            IUiDataProvider dataProvider,
            string customerId,
            IToolManager toolManager,
            IOrdersViewModelFactory ordersViewModelFactory)
            : base(toolManager)
        {
            _ordersViewModelFactory = ordersViewModelFactory;
            _dataProvider = dataProvider;
            Customer = _dataProvider.GetCustomer(customerId);
            DisplayName = Customer.CompanyName;
            Customer.PropertyChanged += Customer_PropertyChanged;
        }

        private void Customer_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _isDirty = true;
            UpdateCommand.RaiseCanExecuteChanged();
        }
    }
}
