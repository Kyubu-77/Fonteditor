using System;
//
namespace FontEditor
{
    class ArrayUtil
    {
        /// <summary>
        /// Reads simple stringfied array into a 1d array of strings
        /// </summary>
        /// <param name="arrayAsText">
        /// Input string E.g.: "[[1,0,0,0,0,1],[1,0,0,0,0,1],[1,0,0,0,0,1],[1,0,0,0,0,1],[1,0,0,0,0,1],[1,0,0,0,0,1]]"
        /// </param>
        /// <param name="width">Character width</param>
        /// <param name="height">Character height</param>
        /// <returns>
        /// string array E.g.: "1","0","0","0","0","1","1","0","0","0","0","1","1","0","0","0","0","1","1","0","0","0","0","1","1","0","0","0","0","1","1","0","0","0","0","1"
        /// </returns>
        public static string[] SplitAtComma(string arrayAsText, UInt16 width, UInt16 height)
        {
            String[] byteStrings = new String[width * height];

            int i = 0;
            bool justAdded = false;
            foreach (char c in arrayAsText)
            {
                if (c == ',')
                {
                    if (!justAdded)
                    {
                        i++;
                        byteStrings[i] = "";
                        justAdded = true;
                    }
                }
                else if (!(c == '[' || c == ']'))
                {
                    byteStrings[i] += c;
                    justAdded = false;
                }
            }

            return byteStrings;
        }

        /// <summary>
        /// Reads simple stringfied array into a 2d array of bytes
        /// </summary>
        /// <param name="arrayAsText"></param>
        /// <param name="width">Character width</param>
        /// <param name="height">Character height</param>
        /// <returns>2d byte array of palette indexes</returns>
        public static byte[,] Read2dArrayFromString(string arrayAsText, UInt16 width, UInt16 height)
        {
            byte[,] retMatrix = new byte[width, height];
            String[] byteStrings = SplitAtComma(arrayAsText, width, height);

            int d = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    retMatrix[x, y] = Convert.ToByte(byteStrings[d++]);
                }
            }

            return retMatrix;
        }

        public static string ByteArray2dToString(byte [,] array, UInt16 Width, UInt16 Height )
        {
            string ret = "[";
            for (int y = 0; y < Height; y++)
            {
                if (y != 0) ret += ',';
                ret += "[";
                for (int x = 0; x < Width; x++)
                {
                    if (x != 0) ret += ',';
                    ret += array[x, y].ToString();
                }
                ret += "]";
            }
            ret += "]";
            return ret;
        }
    }
}
