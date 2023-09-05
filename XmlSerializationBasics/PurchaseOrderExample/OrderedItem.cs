using System.Xml.Serialization;

namespace XmlSerializationBasics.PurchaseOrderExample
{
    public class OrderedItem
    {
        [XmlElement("order-item-name")]
        public string? ItemName { get; set; }

        [XmlElement("order-item-description")]
        public string? Description { get; set; }

        [XmlAttribute("unit-price")]
        public decimal UnitPrice { get; set; }

        [XmlAttribute("quantity")]
        public int Quantity { get; set; }

        [XmlAttribute("line-total")]
        public decimal LineTotal { get; set; }

        public void CalculateLineTotal()
        {
            this.LineTotal = this.UnitPrice * this.Quantity;
        }
    }
}
