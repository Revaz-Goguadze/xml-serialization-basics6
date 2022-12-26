using System.Xml.Serialization;

namespace XmlSerializationBasics.PurchaseOrderExample
{
    public class Address
    {
        public string? Name { get; set; }

        public string? Line1 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Zip { get; set; }
    }
}
