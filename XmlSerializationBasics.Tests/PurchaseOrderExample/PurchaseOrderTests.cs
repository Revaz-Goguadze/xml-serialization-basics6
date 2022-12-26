using NUnit.Framework;
using Org.XmlUnit.Diff;
using XmlSerializationBasics.PurchaseOrderExample;

namespace XmlSerializationBasics.Tests.PurchaseOrderExample
{
    [TestFixture]
    public class PurchaseOrderTests : SerializationTestFixtureBase
    {
        private const string SampleFileName = "PurchaseOrderExample.purchase-order.xml";

        [Test]
        public void SerializeAndCompareWithSample()
        {
            // Arrange
            var purchaseOrder = new PurchaseOrder
            {
                ShipTo = new Address
                {
                    Name = "Teresa Atkinson",
                    Line1 = "1 Main St.",
                    City = "AnyTown",
                    State = "WA",
                    Zip = "10204",
                },
                OrderDate = "5/24/2021",
                DeliveryDate = new DeliveryDate
                {
                    DeliveryDay = 14,
                    DeliveryMonth = 9,
                    DeliveryYear = 2021,
                },
                OrderedItems = new[]
                {
                    new OrderedItem
                    {
                        ItemName = "Widget S",
                        Description = "Small widget",
                        UnitPrice = 5.23m,
                        Quantity = 3,
                        LineTotal = 5.23m * 3,
                    },
                },
                SubTotal = 5.23m * 3,
                ShipCost = 12.51m,
                TotalCost = 12.51m + (5.23m * 3),
            };

            purchaseOrder.OrderedItems[0].CalculateLineTotal();
            purchaseOrder.CalculateSubTotal();
            purchaseOrder.CalculateTotalCost();

            // Act
            Diff diff = this.SerializeAndCompareWithSample(purchaseOrder, SampleFileName);

            // Assert
            Assert.IsFalse(diff.HasDifferences(), diff.ToString());
        }
    }
}
