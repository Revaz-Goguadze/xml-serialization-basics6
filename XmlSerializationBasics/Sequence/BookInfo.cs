using System.Xml.Serialization;

namespace XmlSerializationBasics.Sequence
{
    [XmlRoot("book-shop-item", Namespace = "http://contoso.com/book-shop-item")]
    public class BookInfo
    {
        [XmlElement("genre", Order = 1)]
        public string[]? Genres { get; set; }

        [XmlElement("international-standard-book-number", Order = 2)]
        public string[]? Codes { get; set; }

        [XmlElement("title", Order = 3)]
        public string[]? Titles { get; set; }

        [XmlElement("price", Order = 4)]
        public decimal[]? Prices { get; set; }

        [XmlElement("publication-date", Order = 5)]
        public string[]? PublicationDates { get; set; }
    }
}
