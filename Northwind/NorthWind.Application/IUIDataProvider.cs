using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Model;

namespace Northwind.Application
{
    public interface IUiDataProvider
    {
        IList<Customer> GetCustomers();
        Customer GetCustomer(string customerId);

        void Update(Customer customer);
    }
}
