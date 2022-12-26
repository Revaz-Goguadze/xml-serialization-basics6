using System.Globalization;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Org.XmlUnit.Builder;
using Org.XmlUnit.Diff;

[assembly: CLSCompliant(true)]

namespace XmlSerializationBasics.Tests
{
    public abstract class SerializationTestFixtureBase
    {
        private readonly CultureInfo cultureInfo = CultureInfo.GetCultureInfo("en-US");

        protected Diff SerializeAndCompareWithSample<T>(T obj, string testFileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(stringBuilder, this.cultureInfo);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(stringWriter, obj);

            // Add a breakpoint here to inspect the values of actualXml and expectedXml variables.
            string actualXml = stringBuilder.ToString();
            Stream? stream = ReadTestXmlStreamReader(testFileName);
            using StreamReader stringReader = new StreamReader(stream!);
            string expectedXml = stringReader.ReadToEnd();

            var input = Input.FromString(actualXml);
            var output = Input.FromString(expectedXml);

            Diff diff = DiffBuilder.Compare(input)
                .CheckForSimilar()
                .WithTest(output)
                .Build();

            return diff;
        }

        private static Stream? ReadTestXmlStreamReader(string testXmlFileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string manifestResourceName = assembly.GetName().Name + "." + testXmlFileName;
            return assembly.GetManifestResourceStream(manifestResourceName);
        }
    }
}
