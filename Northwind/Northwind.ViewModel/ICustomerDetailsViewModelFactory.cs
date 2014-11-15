using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.ViewModel
{
    public interface ICustomerDetailsViewModelFactory
    {
        CustomerDetailsViewModel CreateInstanec(string customerId);
    }
}
