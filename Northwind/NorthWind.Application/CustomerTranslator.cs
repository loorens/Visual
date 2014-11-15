using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using Northwind.Model;
using Service = Northwind.Application.CustomerService;

namespace Northwind.Application
{
    public class CustomerTranslator : IEntityTranslator<Model.Customer, Service.Customer>
    {
        private static IEntityTranslator<Model.Customer, Service.Customer> _instance;

        public static IEntityTranslator<Model.Customer, Service.Customer> Instance
        {
            set { _instance = value; }
            get
            {
                return _instance ?? (_instance = new CustomerTranslator());
            }
        }


        public Model.Customer CreateModel(Service.Customer dto)
        {
            return UpdateModel(new Model.Customer(), dto);
        }

        public Model.Customer UpdateModel(Model.Customer model, Service.Customer dto)
        {
            model.CustomerId = dto.CustomerID;
            model.CompanyName = dto.CompanyName;
            model.ContactName = dto.ContactName;
            model.Address = dto.Address;
            model.Region = dto.Region;
            model.Country = dto.Country;
            model.PostalCode = dto.PostalCode;
            model.Phone = dto.Phone;
            model.City = dto.City;

            if (dto.Orders != null)
            {
                model.Orders = GetOrdersFromDto(dto);
            }
            return model;
        }

        private ObservableCollection<Order> GetOrdersFromDto(Service.Customer dto)
        {
            IEnumerable<Order> orders = dto.Orders.Select(o => new Order
            {
                OrderId = o.OrderId,
                OrderDetails = GetOrderDetailsFromDto(o),
                Freight = o.Freight,
                OrderDate = o.OrderDate,
                ShippedDate = o.ShippedDate
            });
            return new ObservableCollection<Order>(orders);
        }

        private IEnumerable<OrderDetail> GetOrderDetailsFromDto(Service.Order order)
        {
            return order.OrderDetails.Select(o => new OrderDetail()
            {
                Product = GetProductFromDto(o),
                Quantity = o.Quantity,
                UnitPrice = o.UnitPrice
            });
        }

        private Product GetProductFromDto(Service.OrderDetails orderDetails)
        {
            return new Product
            {
                ProductId = orderDetails.Product.ProductId,
                ProductName = orderDetails.Product.ProductName
            };
        }

        public Service.Customer CreateDto(Model.Customer model)
        {
            return UpdateDto(new Service.Customer(), model);
        }

        public Service.Customer UpdateDto(Service.Customer dto, Model.Customer model)
        {
            dto.CustomerID = model.CustomerId;
            dto.CompanyName = model.CompanyName;
            return dto;
        }
    }
}
