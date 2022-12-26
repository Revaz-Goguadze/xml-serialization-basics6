using System.Xml.Serialization;

[assembly: CLSCompliant(true)]

namespace XmlSerializationBasics.Arrays
{
    public class BookInfo
    {
        public string[]? Titles { get; set; }

        public decimal[]? Prices { get; set; }

        public string[]? Genres { get; set; }

        public string[]? Codes { get; set; }

        public string[]? PublicationDates { get; set; }
    }
}
