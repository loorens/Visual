using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    public class Product : ModelBase
    {
        /// <summary>
        /// The <see cref="ProductId" /> property's name.
        /// </summary>
        public const string ProductIdPropertyName = "ProductId";

        private int _productId;

        /// <summary>
        /// Sets and gets the ProductId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ProductId
        {
            get
            {
                return _productId;
            }

            set
            {
                if (_productId == value) return;
                _productId = value;
                RaisePropertyChanged(ProductIdPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ProductName" /> property's name.
        /// </summary>
        public const string ProductNamePropertyName = "ProductName";

        private string _productName;

        /// <summary>
        /// Sets and gets the ProductName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ProductName
        {
            get
            {
                return _productName;
            }

            set
            {
                if (_productName == value)
                {
                    return;
                }

                _productName = value;
                RaisePropertyChanged(ProductNamePropertyName);
            }
        }
    }
}
