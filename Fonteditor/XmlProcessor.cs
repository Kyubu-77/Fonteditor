using System.IO;
using System.Xml;

namespace FontEditor
{
    class XmlProcessor
    {
        public static string SaveFont(RasterFont font, string filename)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement xmlFont = font.ToXml(doc);
            doc.AppendChild(xmlFont);

            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlTextWriter.Indentation = 4;
            doc.WriteTo(xmlTextWriter);

            string text = stringWriter.ToString();

            File.WriteAllText(filename, text);

            return text;
        }

        public static RasterFont LoadFont(string filenName)
        {
            string text = File.ReadAllText(filenName);
            XmlDocument doc = new XmlDocument();
            doc.Load(new StringReader(text));

            return RasterFont.FromXML(doc.DocumentElement);
        }


    }
}
