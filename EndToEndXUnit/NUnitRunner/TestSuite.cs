using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace EndToEndTests
{
    [XmlRoot(ElementName = "test-suite")]
    public class TestSuite
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "fullname")]
        public string FullName { get; set; }

        [XmlAttribute(AttributeName = "classname")]
        public string ClassName { get; set; }

        [XmlAttribute(AttributeName = "runstate")]
        public string RunState { get; set; }

        [XmlAttribute(AttributeName = "testcasecount")]
        public int TestCaseCount { get; set; }

        [XmlAttribute(AttributeName = "result")]
        public string Result { get; set; }

        [XmlAttribute(AttributeName = "start-time")]
        public string StartTime { get; set; }

        [XmlAttribute(AttributeName = "end-time")]
        public string Endtime { get; set; }

        [XmlAttribute(AttributeName = "duration")]
        public string Duration { get; set; }

        [XmlAttribute(AttributeName = "total")]
        public int Total { get; set; }

        [XmlAttribute(AttributeName = "passed")]
        public int Passed { get; set; }

        [XmlAttribute(AttributeName = "failed")]
        public int Failed { get; set; }

        [XmlAttribute(AttributeName = "warnings")]
        public string Warnings { get; set; }

        [XmlAttribute(AttributeName = "inconclusive")]
        public int Inconclusive { get; set; }

        [XmlAttribute(AttributeName = "skipped")]
        public int Skipped { get; set; }

        [XmlAttribute(AttributeName = "asserts")]
        public string Asserts { get; set; }

        [XmlElement(ElementName = "test-suite")]
        public List<TestSuite> TestSuites { get; set; }

        [XmlElement(ElementName = "test-case")]
        public List<TestCase> TestCases { get; set; }
    }
}
