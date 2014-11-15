using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.ViewModel;
using StructureMap;
using StructureMap.Graph;

namespace Northwind.UI.WPF
{
    public class BootStrapper
    {
        public MainWindowViewModel MainWindowViewModel
        {
            get { return ObjectFactory.GetInstance<MainWindowViewModel>(); }
        }

        public BootStrapper()
        {
            ObjectFactory.Initialize(
                o => o.Scan(
                    a =>
                    {
                        a.WithDefaultConventions();
                        a.AssembliesFromApplicationBaseDirectory(
                            d => d.FullName.StartsWith("Northwind"));
                        a.LookForRegistries();
                    }));
            //ObjectFactory.Initialize(o => o.AddRegistry<Application.RepositoryRegistry>());
        }
    }
    

}
