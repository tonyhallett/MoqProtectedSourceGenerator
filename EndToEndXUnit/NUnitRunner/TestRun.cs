using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace EndToEndTests
{
    [XmlRoot(ElementName = "test-run")]
    public class TestRun
    {
        [XmlElement(ElementName = "command-line")]
        public List<string> CommandLine { get; set; }

        [XmlElement(ElementName = "test-suite")]
        public List<TestSuite> TestSuites { get; set; }


        public static TestRun Create(XmlNode xmlNode)
        {
            using var memoryStream = new MemoryStream();
            var serializer = new XmlSerializer(typeof(TestRun));

            using var xmlNodeReader = new XmlNodeReader(xmlNode);
            return serializer.Deserialize(xmlNodeReader) as TestRun;
        }
    }
}
