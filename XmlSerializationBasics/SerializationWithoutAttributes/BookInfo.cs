namespace XmlSerializationBasics.SerializationWithoutAttributes
{
    public class BookInfo
    {
        public string Title { get; set; } = null!;

        public decimal Price { get; set; }

        public string Genre { get; set; } = null!;

        public string Isbn { get; set; } = null!;

        public string PublicationDate { get; set; } = null!;
    }
}
