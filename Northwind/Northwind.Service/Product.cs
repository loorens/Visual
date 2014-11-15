using System.Runtime.Serialization;


namespace Northwind.Service
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string ProductName { get; set; }
    }
}
