using CustomParser.Model;
using CustomParser.Model.Utility;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace CustomParser
{
    public class CustomXmlParser
    {
        public static string ToXml(string textValue)
        {
            Text textObj=UtiliMethods.populateObject(textValue);
            return (textObj != null) ? ConvertTextToXml(textObj) : String.Empty; ;
        }

        /// <summary>
        /// Convert the model class to xml string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        private static string ConvertTextToXml<T>(T data)
        {
            using (var sw = new Utf8StringWriter())
            using (var xw = XmlWriter.Create(sw, new XmlWriterSettings { Indent = true }))
            {
                xw.WriteStartDocument(true); // that bool parameter is called "standalone"

                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                var xmlSerializer = new XmlSerializer(data.GetType());
                xmlSerializer.Serialize(xw, data, namespaces);

                return sw.ToString();
            }
        }
    }
}
