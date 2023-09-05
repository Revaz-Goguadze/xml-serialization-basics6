using System.Xml.Serialization;

namespace XmlSerializationBasics.SerializationWithXmlElement
{
    [XmlRoot(ElementName = "book")]
    public class BookInfo
    {
        // Auto-implemented properties with public access modifier
        [XmlElement(ElementName = "book-title")]
        public string Title { get; set; } = null!;

        [XmlElement(ElementName = "book-price")]
        public decimal Price { get; set; }

        [XmlElement(ElementName = "book-genre")]
        public string Genre { get; set; } = null!;

        [XmlElement(ElementName = "book-isbn")]
        public string Isbn { get; set; } = null!;

        [XmlElement(ElementName = "book-publication-date")]
        public string PublicationDate { get; set; } = null!;
    }
}
