using System.Xml.Serialization;

namespace XmlSerializationBasics.ComplexStructures
{
    public class BookPublicationDate
    {
        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public bool FirstPublication { get; set; }
    }
}
