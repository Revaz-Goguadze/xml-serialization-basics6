using System.Xml.Serialization;

namespace XmlSerializationBasics.PurchaseOrderExample
{
    public class PurchaseOrder
    {
        public Address? ShipTo { get; set; }

        public string? OrderDate { get; set; }

        public DeliveryDate? DeliveryDate { get; set; }

        public OrderedItem[]? OrderedItems { get; set; }

        public decimal SubTotal { get; set; }

        public decimal ShipCost { get; set; }

        public decimal TotalCost { get; set; }

        public void CalculateSubTotal()
        {
            if (this.OrderedItems is not null)
            {
                decimal subTotal = 0;
                foreach (var item in this.OrderedItems)
                {
                    subTotal += item.LineTotal;
                }

                this.SubTotal = subTotal;
            }
        }

        public void CalculateTotalCost()
        {
            this.TotalCost = this.SubTotal + this.ShipCost;
        }
    }
}
