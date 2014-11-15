using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Service = Northwind.Application.CustomerService;
using Northwind.Application.CustomerService;

namespace Northwind.Application.Tests
{
    [TestClass]
    public class UIDataProviderTests
    {
        [TestMethod]
        public void GetCustomers_Always_CallsGetCustomers()
        {
            ICustomerService customerServiceMock = MockRepository.GenerateMock<ICustomerService>();

            UiDataProvider target = new UiDataProvider(customerServiceMock);

            var customerDtos = new[] { new Customer() };
            customerServiceMock.Stub(c => c.GetCustomers()).Return(customerDtos);

            target.GetCustomers();

            customerServiceMock.AssertWasCalled(c => c.GetCustomers());
        }


        [TestMethod]
        public void GetCustomers_ServiceReturnsDto_DtoPassedToTranslator()
        {
            ICustomerService customerServiceStub = MockRepository.GenerateStub<ICustomerService>();

            CustomerTranslator.Instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer, Customer>>();

            UiDataProvider target = new UiDataProvider(customerServiceStub);

            var expected = new Customer();
            var customersDtos = new[] { expected };
            customerServiceStub.Stub(c => c.GetCustomers()).Return(customersDtos);

            target.GetCustomers();

            CustomerTranslator.Instance.AssertWasCalled(c => c.CreateModel(expected));

        }

        [TestMethod]
        public void GetCustomers_ServiceReturnsDto_ModelReturnedFromTranslator()
        {
            ICustomerService customerServiceStub = MockRepository.GenerateStub<ICustomerService>();

            CustomerTranslator.Instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer, Customer>>();

            UiDataProvider target = new UiDataProvider(customerServiceStub);
            var dto = new Customer();
            var expected = new Model.Customer();
            var customersDtos = new[] { dto };
            customerServiceStub.Stub(c => c.GetCustomers()).Return(customersDtos);
            CustomerTranslator.Instance.Stub(c => c.CreateModel(dto)).Return(expected);

            var actual = target.GetCustomers();

            Assert.AreSame(expected, actual[0]);
        }

        [TestMethod]
        public void GetCustomer_Always_CallsGetCustomer()
        {
            const string expectedID = "expectedID";

            ICustomerService customerServiceMock = MockRepository.GenerateMock<ICustomerService>();

            CustomerTranslator.Instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer, Customer>>();
            UiDataProvider target = new UiDataProvider(customerServiceMock);

            var dto = new Customer { CustomerID = expectedID };
            var model = new Model.Customer { CustomerId = expectedID };
            var customerDtos = new[] { dto };

            customerServiceMock.Stub(c => c.GetCustomers()).Return(customerDtos);
            CustomerTranslator.Instance.Stub(c => c.CreateModel(dto)).Return(model);
            target.GetCustomers();
            target.GetCustomer(expectedID);

            customerServiceMock.AssertWasCalled(c => c.GetCustomer(expectedID));
        }

    }
}
