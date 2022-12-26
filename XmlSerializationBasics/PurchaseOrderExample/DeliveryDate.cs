using System.Xml.Serialization;

namespace XmlSerializationBasics.PurchaseOrderExample
{
    public class DeliveryDate
    {
        public int DeliveryDay { get; set; }

        public int DeliveryMonth { get; set; }

        public int DeliveryYear { get; set; }
    }
}
