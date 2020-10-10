using System;
using System.Drawing;
using System.Xml;
//
namespace FontEditor
{
    public class Character
    {
        public string Name;
        public UInt16 Width;
        public UInt16 Height;
        public byte[,] Matrix;


        public Character(string name, UInt16 width, UInt16 height)
        {
            Name = name;
            Width = width;
            Height = height;
            Matrix = new byte[Width, Height];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Matrix[x, y] = Constants.BACKGROUND_COLOR_ID;
                }
            }
        }

        public void ResizeMatrix()
        {
            UInt16 oldWidth = (UInt16)Matrix.GetLength(0);
            UInt16 oldHeight = (UInt16)Matrix.GetLength(1);
            byte[,] matrixNew = new byte[Width, Height];

            for (int y = 0; y < Math.Min(oldHeight, Height); y++)
            {
                for (int x = 0; x < Math.Min(oldWidth, Width); x++)
                {
                    matrixNew[x, y] = Matrix[x, y];
                }
            }

            Matrix = matrixNew;
        }

        String getMatrixAsString()
        {
            return ArrayUtil.ByteArray2dToString(Matrix, Width, Height);
        }

        void setMatrixFromString(String text)
        {
            Matrix = ArrayUtil.Read2dArrayFromString(text, Width, Height);
        }


        /// <summary>
        /// Used for listentry
        /// </summary>
        public override string ToString()
        {
            return Name + " (" + Width.ToString() + " x " + Height.ToString() + ")";
        }

        public XmlElement ToXml(XmlDocument doc)
        {
            XmlElement elem = doc.CreateElement("Character");
            elem.SetAttribute("Name", Name);
            elem.SetAttribute("Width", Width.ToString());
            elem.SetAttribute("Height", Height.ToString());

            XmlElement matrixElem = doc.CreateElement("Matrix");
            matrixElem.InnerText = getMatrixAsString();

            elem.AppendChild(matrixElem);
            return elem;
        }

        public static Character FromXML(XmlElement elem)
        {
            Character character = new Character(
                elem.Attributes["Name"].Value,
                Convert.ToUInt16(elem.Attributes["Width"].Value),
                Convert.ToUInt16(elem.Attributes["Height"].Value));

            foreach (XmlNode elemMatrix in elem.ChildNodes)
            {
                if (elemMatrix.Name != "Matrix") continue;

                character.setMatrixFromString(elem.InnerText);

            }
            return character;
        }

        /// <summary>
        /// Fills the characters palette entry matrix with the image of a character in a given font
        /// </summary>
        public void FillMatrixFromCharacter(char c, Font font, int offsetX, int offsetY, byte paletteIndex)
        {
            int picWidth = Width;
            int picHeight = Height;

            Bitmap b = Utils.CreateFontPicture(c, font, picWidth, picHeight,  offsetX, offsetY);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int colorID = Constants.BACKGROUND_COLOR_ID;

                    Color color = b.GetPixel(x, y);
                    if (color.R < 128)
                    {
                        colorID = paletteIndex;
                    }

                    Matrix[x, y] = (byte)colorID;
                }
            }
        }
    }
}

