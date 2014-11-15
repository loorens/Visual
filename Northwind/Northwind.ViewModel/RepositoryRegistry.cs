using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap.Configuration.DSL;

namespace Northwind.ViewModel
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            For<IToolManager>().Singleton();
            For<ICustomerDetailsViewModelFactory>().Singleton();
            For<IOrderViewModelFactory>().Singleton();
            For<IOrdersViewModelFactory>().Singleton();
        }
    }
}
