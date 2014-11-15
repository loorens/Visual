using System.Runtime.Serialization;



namespace Northwind.Service
{
    [DataContract]
    public class OrderDetails
    {
        [DataMember]
        public Product Product { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public decimal UnitPrice { get; set; }

    }
}
