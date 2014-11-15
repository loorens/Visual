using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Model;
using Northwind.Application;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;


namespace Northwind.ViewModel
{
    public class MainWindowViewModel
    {
        private readonly IUiDataProvider _dataProvider;
        private readonly IToolManager _toolManager;
        public string Name { get { return "Northwind"; } }
        public string ControlPanelName { get { return "Control Panel"; } }




        public ObservableCollection<ToolViewModel> Tools
        {
            get { return _toolManager.Tools; }
        }

        private IList<Customer> _customers;
        private RelayCommand _showDetailsRelayCommand;
        private string _selectedCustomerId;

        public IList<Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    GetCustomers();
                }
                return _customers;
            }
        }

        public string SelectedCustomerId
        {
            get { return _selectedCustomerId; }
            set
            {
                _selectedCustomerId = value;
                ShowDetailsCommand.RaiseCanExecuteChanged();
            }
        }


        public RelayCommand ShowDetailsCommand
        {
            get
            { 
                return _showDetailsRelayCommand ?? 
                (_showDetailsRelayCommand = new RelayCommand(
                    ShowCustomerDetails,
                    IsCustomerSelected));
            }
        }

        private bool IsCustomerSelected()
        {
            return !string.IsNullOrEmpty(SelectedCustomerId);
        }


        public MainWindowViewModel(IUiDataProvider dataProvider, IToolManager toolManager)
        {
            _dataProvider = dataProvider;
            _toolManager = toolManager;

            //Tools = new ObservableCollection<ToolViewModel>();
            //Tools.Add(new CustomerDetailsViewModel(_dataProvider, "ALFKI"));
        }


        private void GetCustomers()
        {
            _customers = _dataProvider.GetCustomers();
        }

        public void ShowCustomerDetails()
        {
            if (!IsCustomerSelected())
            {
                throw new InvalidOperationException("customerID can't be null");   
            }
            _toolManager.OpenCustomerDetails(SelectedCustomerId);
            //_toolManager.OpenTool(c=> c.Customer.CustomerId == SelectedCustomerId, () => new CustomerDetailsViewModel(_dataProvider,SelectedCustomerId,_toolManager));
            /*
            CustomerDetailsViewModel customerDetailsViewModel = GetCustomerDetailsTool(SelectedCustomerId);
            if (customerDetailsViewModel == null)
            {
                customerDetailsViewModel = new CustomerDetailsViewModel(_dataProvider, SelectedCustomerId);
                Tools.Add(customerDetailsViewModel);
            }
            SetCurrentTool(customerDetailsViewModel);*/
        }

        //private void SetCurrentTool(CustomerDetailsViewModel currentTool)
        //{
        //    ICollectionView collectionView = CollectionViewSource.GetDefaultView(Tools);
        //    if (collectionView != null)
        //    {
        //        if (collectionView.MoveCurrentTo(currentTool) != true)
        //        {
        //            throw new InvalidOperationException("Could not find the current tool");
        //        }
        //    }
        //}

        //private CustomerDetailsViewModel GetCustomerDetailsTool(string customerId)
        //{
        //    return Tools.OfType<CustomerDetailsViewModel>().FirstOrDefault(c => c.Customer.CustomerId == customerId);
        //}
    }
}
