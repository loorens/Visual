using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Application.CustomerService;
using Rhino.Mocks;
using System.Windows.Data;
using Northwind.Application;
using Customer = Northwind.Model.Customer;


namespace Northwind.ViewModel.Tests
{
    /*[TestClass]
    public class CustomerDetailsViewModelTests
    {
        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void ShowCustomerDetails_SelectedCustomerIDIsNull_ThrowsException()
        {
            //MainWindowViewModel target = new MainWindowViewModel(new UiDataProvider(n()), );

            //target.ShowCustomerDetails();
        }

        [TestMethod]
        public void ShowCustomerDetails_ToolNotFound_AddNewTool()
        {
            const string expectedCustomerID = "EXPECTEDID";
            MainWindowViewModel target = GetShowCustomerDetailsTarget(new Customer { CustomerId = expectedCustomerID });
            target.ShowCustomerDetails();

            CustomerDetailsViewModel actual = target.Tools.Cast<CustomerDetailsViewModel>().FirstOrDefault(v => v.Customer.CustomerId == expectedCustomerID);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void ShowCustomerDetails_Always_ToolIsSetToCurrent()
        {
            Customer expected = new Customer { CustomerId = "EXPECTEDID" };
            MainWindowViewModel target = GetShowCustomerDetailsTarget(expected);

            target.ShowCustomerDetails();

            CustomerDetailsViewModel actual = CollectionViewSource.GetDefaultView(target.Tools).CurrentItem as CustomerDetailsViewModel;

            Assert.AreSame(expected, actual.Customer);
        }

        private static MainWindowViewModel GetShowCustomerDetailsTarget(Customer customer)
        {
            IUiDataProvider uiDataProviderStub = MockRepository.GenerateStub<IUiDataProvider>();

            MainWindowViewModel target = new MainWindowViewModel(uiDataProviderStub);
            target.SelectedCustomerId = customer.CustomerId;
            uiDataProviderStub.Stub(d => d.GetCustomer(customer.CustomerId)).Return(customer);
            return target;
        }


        [TestMethod]
        public void UpdateCustomer_Always_CallsUpdateWithCustomer()
        {
            var uiDataProviderMock = MockRepository.GenerateMock<IUiDataProvider>();
            var expectedCustomer = new Customer { CustomerId = "EXPECTEDID" };
            uiDataProviderMock.Stub(u => u.GetCustomer(Arg<string>.Is.Anything)).Return(expectedCustomer);
            var viewModel = new CustomerDetailsViewModel(uiDataProviderMock, string.Empty, TODO);
            var target = viewModel.UpdateCommand;
            viewModel.Customer.CompanyName = "NAME";
            target.Execute(null);
            uiDataProviderMock.AssertWasCalled(u => u.Update(expectedCustomer));
        }


        [TestMethod]
        public void CanUpdateCustomer_NotDirty_RetursFalse()
        {
            var uiDataProviderMock = MockRepository.GenerateMock<IUiDataProvider>();
            var expectedCustomer = new Customer { CustomerId = "EXPECTEDID" };
            uiDataProviderMock.Stub(u => u.GetCustomer(Arg<string>.Is.Anything)).Return(expectedCustomer);
            var viewModel = new CustomerDetailsViewModel(uiDataProviderMock, string.Empty, TODO);
            var target = viewModel.UpdateCommand;


            var actual = target.CanExecute(null);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CanUpdateCustomer_NotDirty_RetursTrue()
        {
            var uiDataProviderMock = MockRepository.GenerateMock<IUiDataProvider>();
            var expectedCustomer = new Customer { CustomerId = "EXPECTEDID" };
            uiDataProviderMock.Stub(u => u.GetCustomer(Arg<string>.Is.Anything)).Return(expectedCustomer);
            var viewModel = new CustomerDetailsViewModel(uiDataProviderMock, string.Empty, TODO);
            var target = viewModel.UpdateCommand;
            expectedCustomer.RaisePropertyChanged("CompanyName");

            var actual = target.CanExecute(null);
            Assert.IsTrue(actual);
        }
    }*/
}
