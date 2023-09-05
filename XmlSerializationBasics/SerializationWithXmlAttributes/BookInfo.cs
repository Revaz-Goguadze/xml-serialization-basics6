using System.Xml.Serialization;

namespace XmlSerializationBasics.SerializationWithXmlAttributes
{
    [XmlRoot("book", Namespace = "http://contoso.com/book")]
    public class BookInfo
    {
        // Auto-implemented properties with public access modifier and XmlAttribute attributes
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("genre")]
        public string Genre { get; set; }

        [XmlAttribute("isbn")]
        public string Isbn { get; set; }

        [XmlAttribute("publication-date")]
        public string PublicationDate { get; set; }
    }
}
