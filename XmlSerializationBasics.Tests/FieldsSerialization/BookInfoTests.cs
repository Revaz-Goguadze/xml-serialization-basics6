using System.Reflection;
using NUnit.Framework;
using Org.XmlUnit.Diff;
using XmlSerializationBasics.FieldsSerialization;

namespace XmlSerializationBasics.Tests.FieldsSerialization
{
    [TestFixture]
    public class BookInfoTests : SerializationTestFixtureBase
    {
        private const string SampleFileName = "FieldsSerialization.fields-serialization.xml";

        [Test]
        public void SerializeAndCompareWithSample()
        {
            // Arrange
            var book = new BookInfo();

            Type bookInfoType = typeof(BookInfo);
            bookInfoType.GetProperty("Title")?.SetValue(book, "Pride And Prejudice");
            bookInfoType.GetField("Price")?.SetValue(book, 24.95m);
            bookInfoType.GetField("Genre")?.SetValue(book, "novel");
            bookInfoType.GetField("isbn", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(book, "1-861001-57-8");
            bookInfoType.GetField("publicationDate", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(book, "1823-01-28");

            // Act
            Diff diff = this.SerializeAndCompareWithSample(book, SampleFileName);

            // Assert
            Assert.IsFalse(diff.HasDifferences(), diff.ToString());
        }
    }
}
