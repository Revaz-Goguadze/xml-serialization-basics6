using System.Xml.Serialization;

namespace XmlSerializationBasics.FieldsSerialization
{
    public class BookInfo
    {
        public decimal Price;

        public string? Genre;

        private string? isbn;

        private string? publicationDate;

        public string? Title { get; set; }

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
