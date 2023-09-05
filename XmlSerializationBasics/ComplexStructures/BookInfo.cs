using System.Xml.Serialization;

namespace XmlSerializationBasics.ComplexStructures
{
    [XmlRoot("book-description", Namespace = "http://contoso.com/book-description")]
    public class BookInfo
    {
        [XmlElement("title")]
        public BookTitle? Title { get; set; }

        [XmlElement("price")]
        public BookPrice? Price { get; set; }

        [XmlElement("genre")]
        public string? Genre { get; set; }

        [XmlElement("isbn")]
        public string? Isbn { get; set; }

        [XmlElement("publication-date")]
        public BookPublicationDate? PublicationDate { get; set; }
    }
}
