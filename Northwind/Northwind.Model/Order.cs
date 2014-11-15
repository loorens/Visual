using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    public class Order : ModelBase
    {
        /// <summary>
        /// The <see cref="OrderId" /> property's name.
        /// </summary>
        public const string OrderIdPropertyName = "OrderId";

        private int _orderId;

        /// <summary>
        /// Sets and gets the OrderId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OrderId
        {
            get
            {
                return _orderId;
            }

            set
            {
                if (_orderId == value)
                {
                    return;
                }

                _orderId = value;
                RaisePropertyChanged(OrderIdPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="OrderDate" /> property's name.
        /// </summary>
        public const string OrderDatePropertyName = "OrderDate";

        private DateTime? _orderDate;

        /// <summary>
        /// Sets and gets the OrderDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? OrderDate
        {
            get
            {
                return _orderDate;
            }

            set
            {
                if (_orderDate == value)
                {
                    return;
                }

                _orderDate = value;
                RaisePropertyChanged(OrderDatePropertyName);
            }
        }


        /// <summary>
        /// The <see cref="ShippedDate" /> property's name.
        /// </summary>
        public const string ShippedDatePropertyName = "ShippedDate";

        private DateTime? _shippedDate;

        /// <summary>
        /// Sets and gets the ShippedDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? ShippedDate
        {
            get
            {
                return _shippedDate;
            }

            set
            {
                if (_shippedDate == value)
                {
                    return;
                }

                _shippedDate = value;
                RaisePropertyChanged(ShippedDatePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Freight" /> property's name.
        /// </summary>
        public const string FreightPropertyName = "Freight";

        private decimal? _freight;

        /// <summary>
        /// Sets and gets the Freight property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? Freight
        {
            get
            {
                return _freight;
            }

            set
            {
                if (_freight == value)
                {
                    return;
                }

                _freight = value;
                RaisePropertyChanged(FreightPropertyName);
            }
        }


        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
