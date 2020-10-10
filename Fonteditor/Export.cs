using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FontEditor
{
    class Export
    {
        static string CRLF = System.Environment.NewLine;

        static string LoadTemplate()
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                StreamReader textStreamReader = new StreamReader(assembly.GetManifestResourceStream("FontEditor.HeaderTemplate.txt"));
                return textStreamReader.ReadToEnd();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Save a font in a given size into a c header for use in Arduino projects
        /// </summary>
        /// <param name="document"></param>
        public static void ExportFontInSizeToFile( SizeInfo sizeInfo,bool rotate90cc, bool addGreeble)
        {
            if (sizeInfo == null) return;

            Dictionary<string, string> tmplates = new Dictionary<string, string>();
            string name = sizeInfo.Name.Replace(" ", "");

            tmplates.Add("NAME_PALETTE_ARRAY", name + "_Palette");
            tmplates.Add("COLOR_ENTRIES",getCOLOR_ENTRIES());

            tmplates.Add("NAME_BITMAP_ARRAY", name + "_BitmapData");
            tmplates.Add("BITMAP_ARRAY", getBITMAP_ARRAY(sizeInfo, rotate90cc, addGreeble));

            tmplates.Add("NAME_GLYPH_ENTRIES_LENGTH", name + "_GlyphDataLength");
            tmplates.Add("GLYPH_ENTRIES_LENGTH", sizeInfo.characters.Count().ToString());

            tmplates.Add("NAME_GLYPH_ARRAY", name + "_GlyphData");
            tmplates.Add("GLYPH_ENTRIES", getGLYPH_ENTRIES(sizeInfo));

            tmplates.Add("FONT_NAME", sizeInfo.Name);

            tmplates.Add("NAME_PALETTE_ARRAY_REF", name + "_Palette,");
            tmplates.Add("PALETTE_SIZE", Constants.colors.Count().ToString() + ",");

            tmplates.Add("NAME_BITMAP_ARRAY_REF", name + "_BitmapData,".PadRight(45, ' '));
            tmplates.Add("YADVANCE", sizeInfo.Width.ToString() + ",");

            tmplates.Add("NAME_GLYPH_ARRAY_REF", name + "_GlyphData,".PadRight(45, ' '));

            string document = LoadTemplate();
            foreach (KeyValuePair<string, string> kv in tmplates)
            {
                document = document.Replace("{{{" + kv.Key + "}}}", kv.Value);
            }

            SaveHeader(document);
        }

        private static void SaveHeader(string document)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"H:\Projekte\Arduino\Teensy\Matrix\Matrix44\Matrix44\font";
            saveFileDialog.Filter = "h files (*.h)|*.h|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName.ToString(), document);
            }
        }

        private static string getGLYPH_ENTRIES(SizeInfo sizeInfo)
        {
            string tmp = "";
            int offset = 0;
            List<string> lines = new List<string>();
            foreach (Character character in sizeInfo.characters)
            {
                tmp = "    {";
                tmp += offset.ToString() + ", ";
                tmp += character.Width.ToString() + ", ";
                tmp += character.Height.ToString() + ", ";
                tmp += (character.Width + 2).ToString() + ", "; // Advance
                tmp += (0).ToString() + ", ";
                tmp += (-1 * character.Height).ToString();
                tmp += "}";
                lines.Add(tmp);
                offset += (character.Width + character.Width % 2) / 2 * character.Height;
            }
            return String.Join(", " + CRLF, lines.ToArray());
        }

        private static string getBITMAP_ARRAY(SizeInfo sizeInfo, bool rotate90cc, bool addGreeble)
        {
            List<string> blocks = new List<string>();
            foreach (Character character in sizeInfo.characters)
            {
                string tmp = "    // " + character.Name + CRLF;

                byte left = 0;
                byte right = 0;

                // rotate counter clock wise
                if (rotate90cc)
                {
                    if (character.Width != character.Height)
                    {
                        MessageBox.Show("For rotating character must be square");
                    }
                }
                byte[,] Matrix = new byte[character.Width, character.Width];

                ushort n = character.Width;
                for (int i = 0; i < n / 2; i++)
                {
                    for (int j = 0; j < (n + 1) / 2; j++)
                    {
                        Matrix[i, j] = character.Matrix[n - 1 - j, i];
                        Matrix[n - 1 - j, i] = character.Matrix[n - 1 - i, n - 1 - j];
                        Matrix[n - 1 - i, n - 1 - j] = character.Matrix[j, n - 1 - i];
                        Matrix[j, n - 1 - i] = character.Matrix[i, j];
                    }
                }

                if (addGreeble)
                {
                    for (int y = 0; y < character.Width; y++)
                    {

                        for (int x = 0; x < character.Height; x++)
                        {
                            if (Constants.Rnd.NextDouble() < .2f)
                            {
                                int add = Constants.Rnd.Next(5) - 2;

                                int newVal = (int)(Matrix[x, y] + add);

                                if (Matrix[x, y] > 0) // don't change background
                                {
                                    if (0 <= newVal && newVal < 16)
                                    {
                                        Matrix[x, y] = (byte)newVal;
                                    }
                                }
                            }
                        }
                    }
                }

                List<string> block = new List<string>();
                for (int y = 0; y < character.Width; y++)
                {
                    int w2 = (character.Width + character.Width % 2) / 2;
                    List<string> rowEntries = new List<string>();
                    for (int x = 0; x < w2; x++)
                    {
                        left = Matrix[x * 2, y];
                        if (x * 2 - 1 < character.Width)
                        {
                            right = Matrix[x * 2 + 1, y];
                        }
                        else
                        {
                            right = 0;
                        }

                        rowEntries.Add(Utils.ByteToStringHex(left << 4 | right));
                    }
                    block.Add("    " + String.Join(",", rowEntries.ToArray()));
                }
                blocks.Add(tmp + String.Join("," + CRLF, block));
            }

            return String.Join("," + CRLF, blocks);
        }

        private static string getCOLOR_ENTRIES()
        {
            string tmp = "";

            List<string> colors = new List<string>();
            for (int i = 0; i < Constants.colors.Count(); i++)
            {
                Color c = Constants.colors[Constants.colors.Count() - i-1];

                tmp = Utils.ByteToStringHex(c.R) + ",";
                tmp += Utils.ByteToStringHex(c.G) + ",";
                tmp += Utils.ByteToStringHex(c.B);
                if (i == 0)
                {
                    tmp += ",   // Background";
                }
                else if (i == 15)
                {
                    tmp += "   // Foreground";
                }
                else
                {
                    tmp += ",";
                }
                colors.Add(tmp);
            }

            return String.Join(CRLF, colors.ToArray());
        }
    }
}
