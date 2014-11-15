using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Northwind.Model;

namespace Northwind.ViewModel
{
    public class OrderViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="Order" /> property's name.
        /// </summary>
        public const string ModelPropertyName = "Order";

        private Order _order;
        private Customer _customer;
        private IToolManager _toolManager;


        /// <summary>
        /// Sets and gets the Order property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Order Order
        {
            get
            {
                return _order;
            }

            set
            {
                if (_order == value)
                {
                    return;
                }

                _order = value;
                RaisePropertyChanged(ModelPropertyName);
                RaisePropertyChanged(TotalPropertyName);
            }
        }

        public const string TotalPropertyName = "Total";

        public decimal Total
        {
            get { return _order.OrderDetails.Sum(o => o.Quantity + o.UnitPrice); }

        }

        public OrderViewModel(Order order, Customer customer, IToolManager toolManager)
        {
            _customer = customer;
            _order = order;
            _toolManager = toolManager;
            SubscribeToOrderDetailsChanged(_order);
        }

        private void SubscribeToOrderDetailsChanged(Order order)
        {
            order.PropertyChanged += Order_PropertyChanged;
            foreach (var orderDetails in order.OrderDetails)
            {
                orderDetails.PropertyChanged += Order_PropertyChanged;
            }
        }

        private void UnSubscribeToOrderDetailsChanged(Order order)
        {
            order.PropertyChanged -= Order_PropertyChanged;
            foreach (var orderDetails in order.OrderDetails)
            {
                orderDetails.PropertyChanged -= Order_PropertyChanged;
            }
        }

        private void Order_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case Order.FreightPropertyName:
                case OrderDetail.QuantityPropertyName:
                case OrderDetail.UnitPricePropertyName:
                    RaisePropertyChanged(TotalPropertyName);
                    break;
            }
        }

        public override void Cleanup()
        {
            UnSubscribeToOrderDetailsChanged(Order);
            base.Cleanup();
        }
    }
}
