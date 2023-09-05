using System.Xml.Serialization;

[assembly: CLSCompliant(true)]

namespace XmlSerializationBasics.Arrays
{
    [XmlRoot("book-shop-item", Namespace = "http://contoso.com/book-shop-item")]
    public class BookInfo
    {
        [XmlArray("titles")]
        [XmlArrayItem("title")]
        public string[]? Titles { get; set; }

        [XmlArray("prices")]
        [XmlArrayItem("price")]
        public decimal[]? Prices { get; set; }

        [XmlArray("genres")]
        [XmlArrayItem("genre")]
        public string[]? Genres { get; set; }

        [XmlArray("international-standard-book-numbers")]
        [XmlArrayItem("international-standard-book-number")]
        public string[]? Codes { get; set; }

        [XmlArray("publication-dates")]
        [XmlArrayItem("publication-date")]
        public string[]? PublicationDates { get; set; }
    }
}
