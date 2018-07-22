using System.Collections.Generic;
using System.Xml.Serialization;

namespace CustomParser.Model
{
    public class Sentence
    {
        [XmlElement(ElementName = "word")]
        public List<string> Word { get; set; }
    }
}
