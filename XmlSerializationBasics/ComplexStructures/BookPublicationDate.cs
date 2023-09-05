using System.Xml.Serialization;

namespace XmlSerializationBasics.ComplexStructures
{
    [XmlRoot("date")]
    public class BookPublicationDate
    {
        [XmlElement("day")]
        public int Day { get; set; }

        [XmlElement("month")]
        public int Month { get; set; }

        [XmlElement("year")]
        public int Year { get; set; }

        [XmlAttribute("first-publication")]
        public bool FirstPublication { get; set; }
    }
}
