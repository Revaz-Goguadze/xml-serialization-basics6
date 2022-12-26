using NUnit.Framework;
using Org.XmlUnit.Diff;
using XmlSerializationBasics.Arrays;

namespace XmlSerializationBasics.Tests.Arrays
{
    [TestFixture]
    public class BookInfoTests : SerializationTestFixtureBase
    {
        private const string SampleFileName = "Arrays.arrays.xml";

        [Test]
        public void SerializeAndCompareWithSample()
        {
            // Arrange
            var book = new BookInfo();

            Type bookInfoType = typeof(BookInfo);
            bookInfoType.GetProperty("Titles")?.SetValue(book, new string[] { "Pride And Prejudice", "Гордость и предубеждение" });
            bookInfoType.GetProperty("Prices")?.SetValue(book, new decimal[] { 24.95m, 9.44m });
            bookInfoType.GetProperty("Genres")?.SetValue(book, new string[] { "Classic Regency novel", "Romance novel", "Роман" });
            bookInfoType.GetProperty("Codes")?.SetValue(book, new string[] { "1-861001-57-8", "978-5-17-057808-5" });
            bookInfoType.GetProperty("PublicationDates")?.SetValue(book, new string[] { "1823-01-28", "2015-01-01" });

            // Act
            Diff diff = this.SerializeAndCompareWithSample(book, SampleFileName);

            // Assert
            Assert.IsFalse(diff.HasDifferences(), diff.ToString());
        }
    }
}
