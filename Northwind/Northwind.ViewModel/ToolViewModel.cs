using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Northwind.ViewModel
{
    public class ToolViewModel
    {
        protected readonly IToolManager _toolManager;
        private ICommand _closeCommand;
        public string DisplayName { get; set; }

        public ICommand CloseCommand
        {
            get 
            { 
                return _closeCommand ?? (_closeCommand = new RelayCommand(Close));
            }

        }

        public ToolViewModel(IToolManager toolManager)
        {
            _toolManager = toolManager;
        }

        private void Close()
        {
            _toolManager.CloseTool(this);
        }
    }


}
