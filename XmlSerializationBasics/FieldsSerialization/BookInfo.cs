using System.Xml.Serialization;

namespace XmlSerializationBasics.FieldsSerialization
{
    [XmlRoot("book.info", Namespace = "http://contoso.com/book-info")]
    public class BookInfo
    {
        [XmlElement(ElementName = "sell.price", Order = 4)]
        public decimal Price;

        [XmlElement(ElementName = "category", Order = 1)]
        public string? Genre;

        [XmlIgnore]
        private string? isbn;

        [XmlIgnore]
        private string? publicationDate;

        [XmlElement(ElementName = "book.title", Order = 2)]
        public string? Title { get; set; }

        [XmlElement(ElementName = "book.number", Order = 5)]
        public string? Isbn
        {
            get
            {
                return this.isbn;
            }

            set
            {
                this.isbn = value;
            }
        }

        [XmlElement(ElementName = "pub.date", Order = 3)]
        public string? PublicationDate
        {
            get
            {
                return this.publicationDate;
            }

            set
            {
                this.publicationDate = value;
            }
        }
    }
}
