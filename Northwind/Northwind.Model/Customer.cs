using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    public class Customer : ModelBase
    {

        private string _customerId;
                
        public string CustomerId
        {
            get { return _customerId; }
            set 
            {
                if (_customerId == value)
                    return;
                RaisePropertyChanged("CustomerId");
                _customerId = value; 
            }
        }


        private string _companyName;

        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (_companyName == value)
                    return;
                RaisePropertyChanged("CompanyName");
                _companyName = value;
            }
        }


        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone == value)
                    return;
                RaisePropertyChanged("Phone");
                _phone = value;
            }
        }

        private string _postalCode;

        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                if (_postalCode == value)
                    return;
                RaisePropertyChanged("PostalCode");
                _postalCode = value;
            }
        }


        private string _country;

        public string Country
        {
            get { return _country; }
            set
            {
                if (_country == value)
                    return;
                RaisePropertyChanged("Country");
                _country = value;
            }
        }


        private string _region;

        public string Region
        {
            get { return _region; }
            set
            {
                if (_region == value)
                    return;
                RaisePropertyChanged("Region");
                _region = value;
            }
        }



        private string _address;

        public string Address
        {
            get { return _address; }
            set
            {
                if (_address == value)
                    return;
                RaisePropertyChanged("Address");
                _address = value;
            }
        }



        private string _city;

        public string City
        {
            get { return _city; }
            set
            {
                if (_city == value)
                    return;
                RaisePropertyChanged("City");
                _city = value;
            }
        }

        private string _contactName;

        public string ContactName
        {
            get { return _contactName; }
            set
            {
                if (_contactName == value)
                    return;
                RaisePropertyChanged("ContactName");
                _contactName = value;
            }
        }



        /// <summary>
        /// The <see cref="Orders" /> property's name.
        /// </summary>
        public const string OrdersPropertyName = "Orders";

        private ObservableCollection<Order> _orders;

        /// <summary>
        /// Sets and gets the Orders property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Order> Orders
        {
            get
            {
                return _orders;
            }

            set
            {
                if (_orders == value)
                {
                    return;
                }

                _orders = value;
                RaisePropertyChanged(OrdersPropertyName);
            }
        }

    }
}
