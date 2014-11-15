using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Application.CustomerService;
using Customer = Northwind.Model.Customer;

namespace Northwind.Application
{
    public class UiDataProvider : IUiDataProvider
    {
        private IList<Customer> _customers;

        private readonly ICustomerService _customerServiceClient;

        public UiDataProvider(ICustomerService customerService)
        {
            _customerServiceClient = customerService;
        }



        public IList<Customer> GetCustomers()
        {
            return _customers ?? (_customers = _customerServiceClient.GetCustomers().Select(c => CustomerTranslator.Instance.CreateModel(c)).ToList());
        }


        public Customer GetCustomer(string customerId)
        {
            return CustomerTranslator.Instance.UpdateModel(_customers.First(c=>c.CustomerId == customerId), _customerServiceClient.GetCustomer(customerId));
        }

        public void Update(Customer customer)
        {
            _customerServiceClient.Update(CustomerTranslator.Instance.CreateDto(customer));
        }
    }

}
