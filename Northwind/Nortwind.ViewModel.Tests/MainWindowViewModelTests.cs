using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Model;
using Northwind.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
namespace Northwind.ViewModel.Tests
{
/*    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void ConstructorAlwaysCallsGetCustomers()
        {




            IUiDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUiDataProvider>();
            uiDataProviderMock.Expect(c => c.GetCustomers());

            MainWindowViewModel target = new MainWindowViewModel(uiDataProviderMock);
            IList<Customer> customers = target.Customers;
            uiDataProviderMock.VerifyAllExpectations();

        }

        [TestMethod]
        public void ConstructorAlwaysCallsGetCustomer()
        {
            IUiDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUiDataProvider>();
            const string expectedID = "EXPECTEDID";
            uiDataProviderMock.Expect(c => c.GetCustomer(expectedID)).Return(new Customer());

            CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderMock, expectedID, TODO);

            uiDataProviderMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void Customer_Always_ReturnsCustomerFromGetCustomer()
        {
            IUiDataProvider uiDataProviderStub = MockRepository.GenerateStub<IUiDataProvider>();
            const string expectedID = "EXPECTEDID";
            Customer expectedCutomer = new Customer { CustomerId = expectedID };

            uiDataProviderStub.Stub(c => c.GetCustomer(expectedID)).Return(expectedCutomer);
            CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderStub, expectedID, TODO);

            Assert.AreSame(expectedCutomer, target.Customer);
        }

        [TestMethod]
        public void DisplaName_Always_ReturnsCompanyName()
        {
            IUiDataProvider uiDataProviderStub = MockRepository.GenerateStub<IUiDataProvider>();
            const string expectedID = "EXPECTEDID";
            const string expectedCompanyName = "EXPECTEDNAME";
            Customer expectedCutomer = new Customer { CustomerId = expectedID, CompanyName = expectedCompanyName };

            uiDataProviderStub.Stub(c => c.GetCustomer(expectedID)).Return(expectedCutomer);
            CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderStub, expectedID, TODO);

            Assert.AreSame(expectedCompanyName, target.DisplayName);
        }

        //private IList<Customer> GetCustomers
        //    ()
        //{
        //    const int numberOfCustomers = 10;
        //    IList<Customer> customers = new List<Customer>();

        //    for (int i = 0; i < numberOfCustomers; i++)
        //    {
        //        customers.Add(new Customer 
        //        { 
        //            CustomerID = "CustomerID " + i,
        //            CompanyName = "CompanyName " + i 
        //        });
        //    }

        //    return customers;
        //}

        //private class UIDataProviderStub : UIDataProvider
        //{
        //    public IList<Customer> Customers { private get; set; }

        //    public IList<Customer> GetCustomers()
        //    {
        //        return Customers;
        //    }
        //}
    }*/
}
