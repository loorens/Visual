﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.ViewModel
{
    public interface IToolManager
    {
        ObservableCollection<ToolViewModel> Tools { get; set; }

        //void OpenTool<T>(Func<T, bool> predicate, Func<T> toolFactory) where T : ToolViewModel;
        void OpenCustomerDetails(string customerId);
        void CloseTool(ToolViewModel tool);
    }
}
