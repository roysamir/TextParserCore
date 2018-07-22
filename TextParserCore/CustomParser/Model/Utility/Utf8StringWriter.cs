using System.IO;
using System.Text;

namespace CustomParser.Model.Utility
{
    public sealed class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding { get { return Encoding.UTF8; } }
    }
}
