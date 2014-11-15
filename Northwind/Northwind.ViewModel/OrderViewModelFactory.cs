using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Model;
using StructureMap;

namespace Northwind.ViewModel
{
    public class OrderViewModelFactory : IOrderViewModelFactory
    {
        private readonly IContainer _container;

        public OrderViewModelFactory(IContainer container)
        {
            _container = container;
        }

        public OrderViewModel CreateInstance(Order order, Customer customer)
        {
            return _container
                .With("model")
                .EqualTo(order)
                .With("customer")
                .EqualTo(customer)
                .GetInstance<OrderViewModel>();
        }
    }
}
