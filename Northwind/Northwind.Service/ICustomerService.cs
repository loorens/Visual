using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Service
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        IList<Customer> GetCustomers();

        [OperationContract]
        Customer GetCustomer(string customerId);

        [OperationContract]
        void Update(Customer customer);
    }
}
