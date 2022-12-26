using System.Xml.Serialization;

namespace XmlSerializationBasics.ComplexStructures
{
    public class BookPrice
    {
        public decimal Price { get; set; }

        public string? Currency { get; set; }
    }
}
