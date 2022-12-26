using NUnit.Framework;
using Org.XmlUnit.Diff;
using XmlSerializationBasics.SerializationWithOrder;

namespace XmlSerializationBasics.Tests.SerializationWithOrder
{
    [TestFixture]
    public class BookInfoTests : SerializationTestFixtureBase
    {
        private const string SampleFileName = "SerializationWithOrder.serialization-with-xml-root.xml";

        [Test]
        public void SerializeAndCompareWithSample()
        {
            // Arrange
            var book = new BookInfo();

            Type bookInfoType = typeof(BookInfo);
            bookInfoType.GetProperty("Title")?.SetValue(book, "Pride And Prejudice");
            bookInfoType.GetProperty("Price")?.SetValue(book, 24.95m);
            bookInfoType.GetProperty("Genre")?.SetValue(book, "novel");
            bookInfoType.GetProperty("Isbn")?.SetValue(book, "1-861001-57-8");
            bookInfoType.GetProperty("PublicationDate")?.SetValue(book, "1823-01-28");

            // Act
            Diff diff = this.SerializeAndCompareWithSample(book, SampleFileName);

            // Assert
            Assert.IsFalse(diff.HasDifferences(), diff.ToString());
        }
    }
}
