using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace FontEditor
{
    public class SizeInfo
    {
        public string Name;
        public UInt16 Width;
        public UInt16 Height;

        public List<Character> characters;
        public string PreviewChar;
        public string PreviewOffsetY;
        public string PreviewOffsetX;
        public Font PreviewFont;


        public byte PalletteForegroundRed;
        public byte PalletteForegroundGreen;
        public byte PalletteForegroundBlue;
        public byte PalletteBackgroundRed;
        public byte PalletteBackgroundGreen;
        public byte PalletteBackgroundBlue;

        public byte GenBasePaletteIndex;

        public SizeInfo(string name, UInt16 x, UInt16 y)
        {
            Name = name;
            Width = x;
            Height = y;
            characters = new List<Character>();
            PreviewFont = new Font("Arial", 9);
            PreviewOffsetX = "0";
            PreviewOffsetY = "0";
            PreviewChar = "X";
            PalletteForegroundRed = 0;
            PalletteForegroundGreen = 0;
            PalletteForegroundBlue = 0;
            PalletteBackgroundRed = 255;
            PalletteBackgroundGreen = 255;
            PalletteBackgroundBlue = 255;

            GenBasePaletteIndex = Constants.FOREGROUND_COLOR_ID;
        }

        public override string ToString()
        {
            return Name + " (" + Width.ToString() + " x " + Height.ToString() + ")";
        }

        public XmlElement ToXml(XmlDocument doc)
        {
            XmlElement elem = doc.CreateElement("Size");
            elem.SetAttribute("Name", Name);
            elem.SetAttribute("Width", Width.ToString());
            elem.SetAttribute("Height", Height.ToString());

            elem.SetAttribute("PreviewFontFamilyName", PreviewFont.FontFamily.Name);
            elem.SetAttribute("PreviewFontSize", PreviewFont.Size.ToString());
            elem.SetAttribute("PreviewFontBold", PreviewFont.Bold.ToString());
            elem.SetAttribute("PreviewFontItalic", PreviewFont.Italic.ToString());
            elem.SetAttribute("PreviewOffsetX", PreviewOffsetX.ToString());
            elem.SetAttribute("PreviewOffsetY", PreviewOffsetY.ToString());
            elem.SetAttribute("PreviewChar", PreviewChar.ToString());

            elem.SetAttribute("PalletteForegroundRed", PalletteForegroundRed.ToString());
            elem.SetAttribute("PalletteForegroundGreen", PalletteForegroundGreen.ToString());
            elem.SetAttribute("PalletteForegroundBlue", PalletteForegroundBlue.ToString());
            elem.SetAttribute("PalletteBackgroundRed", PalletteBackgroundRed.ToString());
            elem.SetAttribute("PalletteBackgroundGreen", PalletteBackgroundGreen.ToString());
            elem.SetAttribute("PalletteBackgroundBlue", PalletteBackgroundBlue.ToString());

            elem.SetAttribute("GenBasePaletteIndex", GenBasePaletteIndex.ToString());

            XmlElement charactersElem = doc.CreateElement("Characters");
            foreach (Character c in characters)
            {
                charactersElem.AppendChild(c.ToXml(doc));
            }

            elem.AppendChild(charactersElem);
            return elem;
        }

        public static SizeInfo FromXML(XmlElement elem)
        {
            SizeInfo size = new SizeInfo(
                elem.Attributes["Name"].Value,
                Convert.ToUInt16(elem.Attributes["Width"].Value),
                Convert.ToUInt16(elem.Attributes["Height"].Value)
            );

            String previewFontFamilyName = elem.Attributes["PreviewFontFamilyName"].Value;
            String previewFontSize = elem.Attributes["PreviewFontSize"].Value;

            Font font = new Font(previewFontFamilyName, (float)Convert.ToDouble(previewFontSize));
            FontStyle fontStyle = font.Style;

            if (elem.Attributes["PreviewFontBold"].Value == "True")
            {
                fontStyle &= FontStyle.Bold;
            }


            if (elem.Attributes["PreviewFontItalic"].Value == "True")
            {
                fontStyle &= FontStyle.Italic;
            }

            size.PreviewFont = new Font(font, fontStyle);

            size.PreviewOffsetX = elem.Attributes["PreviewOffsetX"].Value;
            size.PreviewOffsetY = elem.Attributes["PreviewOffsetY"].Value;
            size.PreviewChar = elem.Attributes["PreviewChar"].Value;

            size.PalletteForegroundRed = Convert.ToByte(elem.Attributes["PalletteForegroundRed"].Value);
            size.PalletteForegroundGreen = Convert.ToByte(elem.Attributes["PalletteForegroundGreen"].Value);
            size.PalletteForegroundBlue = Convert.ToByte(elem.Attributes["PalletteForegroundBlue"].Value);

            size.PalletteBackgroundRed = Convert.ToByte(elem.Attributes["PalletteBackgroundRed"].Value);
            size.PalletteBackgroundGreen = Convert.ToByte(elem.Attributes["PalletteBackgroundGreen"].Value);
            size.PalletteBackgroundBlue = Convert.ToByte(elem.Attributes["PalletteBackgroundBlue"].Value);


            if (elem.Attributes["GenBasePaletteIndex"] != null)
            {
                size.GenBasePaletteIndex = Convert.ToByte(elem.Attributes["GenBasePaletteIndex"].Value);
            }

            foreach (XmlNode elemCharacters in elem.ChildNodes)
            {
                if (elemCharacters.Name != "Characters") continue;

                foreach (XmlNode s in elemCharacters.ChildNodes)
                {
                    Character character = Character.FromXML((XmlElement)s);
                    size.characters.Add(character);
                }
            }
            return size;
        }
    }
}

