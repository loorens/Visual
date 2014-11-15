using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Model;

namespace Northwind.ViewModel
{
    public interface IOrderViewModelFactory
    {
        OrderViewModel CreateInstance(Order order, Customer customer);
    }
}
