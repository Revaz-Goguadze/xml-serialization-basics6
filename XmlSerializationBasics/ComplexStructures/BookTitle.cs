using System.Xml.Serialization;

namespace XmlSerializationBasics.ComplexStructures
{
    [XmlRoot("title")]
    public class BookTitle
    {
        [XmlElement("title")]
        public string? Title { get; set; }

        [XmlElement("language")]
        public string? Language { get; set; }
    }
}
