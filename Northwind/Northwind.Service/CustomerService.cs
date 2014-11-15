using System.ServiceModel.Configuration;
using Northwind.Data;
using System.Collections.Generic;
using System.Linq;


namespace Northwind.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly NORTHWNDEntities _northwindEntities = new NORTHWNDEntities();

        public IList<Customer> GetCustomers()
        {
            return _northwindEntities.Customers.Select(c => new Customer
            {
                CustomerID = c.CustomerID,
                CompanyName = c.CompanyName
            }).ToList();
        }

        public Customer GetCustomer(string customerId)
        {
            var customer = _northwindEntities.Customers.Single(c => c.CustomerID == customerId);
            return new Customer
            {
                CustomerID = customer.CustomerID,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                Address = customer.Address,
                City = customer.City,
                Country = customer.Country,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Phone = customer.Phone,
                Orders = GetOrders(customer.Orders)

            };
        }

        private IEnumerable<Order> GetOrders(IEnumerable<Data.Order> orders)
        {
            return orders.Select(o => new Order
            {
                Freight = o.Freight,
                OrderDate = o.OrderDate,
                OrderDetails = GetOrderDetails(o),
                OrderId = o.OrderID,
                ShippedDate = o.ShippedDate
            }).ToList();
        }

        private IEnumerable<OrderDetails> GetOrderDetails(Data.Order order)
        {
            return order.Order_Details.Select(
                o => new OrderDetails()
                {
                    Product = new Product()
                    {
                        ProductId = o.Product.ProductID,
                        ProductName = o.Product.ProductName
                    },
                    Quantity = o.Quantity,
                    UnitPrice = o.UnitPrice
                }).ToList();
        }

        public void Update(Customer customer)
        {
            var customerEntity = _northwindEntities.Customers.Single(c => c.CustomerID == customer.CustomerID);

            customerEntity.CompanyName = customer.CompanyName;
            customerEntity.ContactName = customer.ContactName;
            customerEntity.Address = customer.Address;
            customerEntity.City = customer.City;
            customerEntity.Country = customer.Country;
            customerEntity.Region = customer.Region;
            customerEntity.PostalCode = customer.PostalCode;
            customerEntity.Phone = customer.Phone;

            _northwindEntities.SaveChanges();
        }
    }
}
