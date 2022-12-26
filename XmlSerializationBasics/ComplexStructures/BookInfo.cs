using System.Xml.Serialization;

namespace XmlSerializationBasics.ComplexStructures
{
    public class BookInfo
    {
        public BookTitle? Title { get; set; }

        public BookPrice? Price { get; set; }

        public string? Genre { get; set; }

        public string? Isbn { get; set; }

        public BookPublicationDate? PublicationDate { get; set; }
    }
}
