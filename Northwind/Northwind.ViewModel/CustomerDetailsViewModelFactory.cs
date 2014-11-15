using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace Northwind.ViewModel
{
    public class CustomerDetailsViewModelFactory : ICustomerDetailsViewModelFactory
    {
        private readonly IContainer _container;

        public CustomerDetailsViewModelFactory(IContainer container)
        {
            _container = container;
        }

        public CustomerDetailsViewModel CreateInstanec(string customerId)
        {
            return _container
                .With("customerId")
                .EqualTo(customerId)
                .GetInstance<CustomerDetailsViewModel>();

        }
    }
}
