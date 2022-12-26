using NUnit.Framework;
using Org.XmlUnit.Diff;
using XmlSerializationBasics.ComplexStructures;

namespace XmlSerializationBasics.Tests.ComplexStructures
{
    [TestFixture]
    public class BookInfoTests : SerializationTestFixtureBase
    {
        private const string SampleFileName = "ComplexStructures.complex-structures.xml";

        [Test]
        public void SerializeAndCompareWithSample()
        {
            // Arrange
            var book = new BookInfo
            {
                Title = new BookTitle { Title = "Pride And Prejudice", Language = "English", },
                Price = new BookPrice { Price = 24.95m, Currency = "USD", },
                Genre = "novel",
                Isbn = "1-861001-57-8",
                PublicationDate = new BookPublicationDate
                {
                    Day = 28,
                    Month = 01,
                    Year = 1823,
                    FirstPublication = true,
                },
            };

            // Act
            Diff diff = this.SerializeAndCompareWithSample(book, SampleFileName);

            // Assert
            Assert.IsFalse(diff.HasDifferences(), diff.ToString());
        }
    }
}
