using System;
using System.Drawing;
//
namespace FontEditor
{
    class Constants
    {
        public static Random Rnd = new Random();

        public static Color[] colors = new Color[16];
        public static byte BACKGROUND_COLOR_ID = 0;
        public static byte FOREGROUND_COLOR_ID = 15;

        static Constants()
        {
            // create color palette
            float fac = 255.0f / 15;
            for (int i = 0; i < 16; i++)
            {
                colors[i] = Color.FromArgb(255, 255 - (byte)(i * fac), 255 - (byte)(i * fac), 255 - (byte)(i * fac));
            }
        }

        public static void RecalcColors(byte redBackGround, byte greenBackGround, byte blueBackGround, byte redForeGround, byte greenForeGround, byte blueForeGround)
        {
            // create color palette, think of a black background for formula
            float facR = (float)(redForeGround - redBackGround) / 15.0f;
            float facG = (float)(greenForeGround - greenBackGround) / 15.0f;
            float facB = (float)(blueForeGround - blueBackGround) / 15.0f;

            for (int i = 0; i < 16; i++)
            {
                colors[i] = Color.FromArgb(255,
                   (byte)(redBackGround + i * facR),
                   (byte)(greenBackGround + i * facG),
                   (byte)(blueBackGround + i * facB));
            }
        }
    }
}

