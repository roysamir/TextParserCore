using System.Collections.Generic;
using System.Xml.Serialization;

namespace CustomParser.Model
{
    [XmlRoot(ElementName = "text")]
    public class Text
    {
        [XmlElement(ElementName = "sentence")]
        public List<Sentence> Sentence { get; set; }
    }

}
