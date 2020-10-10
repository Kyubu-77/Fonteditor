using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FontEditor
{
    public struct GI
    {
        public Bitmap b;
        public Graphics g;
    }

    class Utils
    {
        public static string ByteToString(int v)
        {
            return Convert.ToString(v, 2).PadLeft(4, '0');
        }

        public static string ByteToStringHex(int v)
        {
            return "0x" + Convert.ToString(v, 16).ToUpper().PadLeft(2, '0'); ;
        }

        public static GI getMemoryGraphics(int w, int h)
        {
            GI ret;
            ret.b = new Bitmap(w, h);
            ret.g = Graphics.FromImage(ret.b);
            return ret;
        }

        public static Font ScaleFont(Graphics graphics, Font fontData, string Text, Size fitToSize)
        {
            //you should perform some scale functions!!!
            SizeF actualSize = graphics.MeasureString(Text, fontData);

            float WidthFactor = fitToSize.Width / actualSize.Width;
            float HeightFactor = fitToSize.Height / actualSize.Height;
            // get better scale direction
            float ScaleRatio = (HeightFactor < WidthFactor) ? ScaleRatio = HeightFactor : ScaleRatio = WidthFactor;
            float ScaleFontSize = fontData.Size * ScaleRatio;
            return new Font(fontData.FontFamily, ScaleFontSize);
        }

        public static Bitmap CreateFontPicture(char c, Font font, int picWidth, int picHeight, int x, int y)
        {
            GI gi = Utils.getMemoryGraphics(picWidth, picHeight);

            Pen p = new Pen(Color.Black);
            Brush bWhite = new SolidBrush(Color.White);
            Brush bBlack = new SolidBrush(Color.Black);

            gi.g.FillRectangle(bWhite, 0, 0, picWidth, picHeight);
            gi.g.DrawString(c.ToString(), font, bBlack, x, y);
            return gi.b;
        }
        public static void CreateMatrixWithSettings(SizeInfo size, Character character, char c)
        {
            if (size == null) return;

            int offsetX;
            int offsetY;

            try
            {
                offsetX = Convert.ToInt32(size.PreviewOffsetX);
                offsetY = Convert.ToInt32(size.PreviewOffsetY);
            }
            catch
            {
                return;
            }

            character.FillMatrixFromCharacter(c, size.PreviewFont, offsetX, offsetY, size.GenBasePaletteIndex);
        }
    }
}
