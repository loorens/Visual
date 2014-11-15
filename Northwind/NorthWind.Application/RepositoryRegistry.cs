using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Application.CustomerService;
using StructureMap.Configuration.DSL;

namespace Northwind.Application
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            For<IUiDataProvider>().Singleton();
            For<ICustomerService>().Singleton().Use(() => new CustomerServiceClient());
        }
    }
}
