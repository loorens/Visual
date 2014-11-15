using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void RaisePropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        private void VerifyPropertyName(string propertyName)
        {
            if(TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new InvalidOperationException(String.Format("Property {0} wasn't found",propertyName));
            }
        }
    }
}
