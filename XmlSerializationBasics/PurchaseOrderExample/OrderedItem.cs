using System.Xml.Serialization;

namespace XmlSerializationBasics.PurchaseOrderExample
{
    public class OrderedItem
    {
        public string? ItemName { get; set; }

        public string? Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal LineTotal { get; set; }

        public void CalculateLineTotal()
        {
            this.LineTotal = this.UnitPrice * this.Quantity;
        }
    }
}
