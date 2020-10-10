using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FontEditor
{
    class RasterFont
    {
        public string Name;

        public List<SizeInfo> SizeInfos = new List<SizeInfo>();

        public RasterFont()
        {
            Name = "new" + (int)(Constants.Rnd.Next(10000));
        }

        public XmlElement ToXml(XmlDocument doc)
        {
            XmlElement elem = doc.CreateElement("Font");
            elem.SetAttribute("Name", Name);
            
            XmlElement sizesElem = doc.CreateElement("Sizes");
            foreach (SizeInfo s in SizeInfos)
            {
                sizesElem.AppendChild(s.ToXml(doc));
            }

            elem.AppendChild(sizesElem);
            return elem;
        }

        public static RasterFont FromXML(XmlElement elem)
        {

            RasterFont font = new RasterFont();
            font.Name = elem.Attributes["Name"].Value;

            foreach (XmlNode elemSizes in elem.ChildNodes)
            {
                if (elemSizes.Name != "Sizes") continue;

                foreach (XmlNode s in elemSizes.ChildNodes)
                {
                    SizeInfo size = SizeInfo.FromXML((XmlElement)s);
                    font.SizeInfos.Add(size);
                }
            }
            return font;
        }
    }
}
