using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Northwind.Service
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public DateTime? OrderDate { get; set; }

        [DataMember]
        public DateTime? ShippedDate { get; set; }

        [DataMember]
        public decimal? Freight { get; set; }

        [DataMember]
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }


}
