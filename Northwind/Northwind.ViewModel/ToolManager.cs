using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Northwind.ViewModel
{
    public class ToolManager: IToolManager
    {
        private readonly ICustomerDetailsViewModelFactory _customerDetailsFactory;
        private readonly ICollectionView _toolCollectionView;
        public ObservableCollection<ToolViewModel> Tools { get; set; }

        public ToolManager(ICustomerDetailsViewModelFactory customerDetailsFactory)
        {
            _customerDetailsFactory = customerDetailsFactory;
            Tools = new ObservableCollection<ToolViewModel>();
            _toolCollectionView = CollectionViewSource.GetDefaultView(Tools);
        }

        private void OpenTool<T>(Func<T, bool> predicate, Func<T> toolFactory) where T : ToolViewModel
        {
            var tool = Tools.Where(t => t.GetType() == typeof(T)).FirstOrDefault(t => predicate.Invoke((T)t));
            if (tool == null)
            {
                tool = toolFactory.Invoke();
                Tools.Add(tool);
            }
            SetCurrentTool(tool);
        }

        private void SetCurrentTool(ToolViewModel tool)
        {
            if (_toolCollectionView.MoveCurrentTo(tool) != true)
            {
                throw new InvalidOperationException("Could not find the current tool");
            }
        }

        public void OpenCustomerDetails(string customerId)
        {
            OpenTool(c => c.Customer.CustomerId == customerId, () => _customerDetailsFactory.CreateInstanec(customerId));
        }

        public void CloseTool(ToolViewModel tool)
        {
            Tools.Remove(tool);
        }


    }
}
