using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace Northwind.ViewModel.Tests
{
    [TestClass]
    public class StructureMapTests
    {
        [TestMethod]
        public void StructureMapInitializeTest()
        {
        
            ObjectFactory.Initialize( i => i.AddRegistry<RepositoryRegistry>());

            ObjectFactory.Container.AssertConfigurationIsValid();
        }
    }
}
