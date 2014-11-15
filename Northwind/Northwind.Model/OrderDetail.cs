using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    public class OrderDetail : ModelBase
    {
        /// <summary>
        /// The <see cref="Product" /> property's name.
        /// </summary>
        public const string ProductPropertyName = "Product";

        private Product _product;

        /// <summary>
        /// Sets and gets the Product property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Product Product
        {
            get
            {
                return _product;
            }

            set
            {
                if (_product == value)
                {
                    return;
                }

                _product = value;
                RaisePropertyChanged(ProductPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Quantity" /> property's name.
        /// </summary>
        public const string QuantityPropertyName = "Quantity";

        private int _quantity;

        /// <summary>
        /// Sets and gets the Quantity property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                if (_quantity == value)
                {
                    return;
                }

                _quantity = value;
                RaisePropertyChanged(QuantityPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="UnitPrice" /> property's name.
        /// </summary>
        public const string UnitPricePropertyName = "UnitPrice";

        private decimal _unitPrice;

        /// <summary>
        /// Sets and gets the UnitPrice property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal UnitPrice
        {
            get
            {
                return _unitPrice;
            }

            set
            {
                if (_unitPrice == value)
                {
                    return;
                }

                _unitPrice = value;
                RaisePropertyChanged(UnitPricePropertyName);
            }
        }

    }
}
