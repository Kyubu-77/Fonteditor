using System;
using System.Drawing;
using System.Windows.Forms;
//
namespace FontEditor
{
    public class CharViewHandler
    {
        private PictureBox picture;
        
        public byte SelectedPaletteEntry;

        // Layout
        public static float cBorderFactor = 0.5f;        // BBB XXXXCHARXXXX BBB -> 3 12 3   -> 12 * 0.5 = 3+3

        public CharViewHandler(PictureBox picture, PictureBox picColorSelector)
        {
            this.picture = picture;

            SelectedPaletteEntry = 0;
        }

        public void RefreshPicture()
        {
            picture.Refresh();
        }

        private void PaintPixel(MouseEventArgs e, Character character)
        {
            if ((e.Button == MouseButtons.Left) || (e.Button == MouseButtons.Right))
            {
                int usedWidth = character.Width;
                int usedHeight = character.Height;

                int bX = (int)Math.Ceiling(usedWidth * cBorderFactor); bX += bX % 2;
                int bY = (int)Math.Ceiling(usedHeight * cBorderFactor); bY += bY % 2;
                int bX2 = bX / 2;
                int bY2 = bY / 2;

                float w = (float)picture.Width / (usedWidth + bX);
                float h = (float)picture.Height / (usedHeight + bY);

                int x = (byte)((e.X - w * bX2) / w);
                int y = (byte)((e.Y - w * bY2) / h);

                byte colodId = Constants.BACKGROUND_COLOR_ID;
                if (e.Button == MouseButtons.Left)
                {
                    colodId = SelectedPaletteEntry;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    character.Matrix[x, y] = Constants.BACKGROUND_COLOR_ID;
                }

                if ((0 <= x && x < character.Width) && (0 <= y && y < character.Height))
                {
                    character.Matrix[x, y] = colodId;
                    RefreshPicture();
                }
            }
        }

        public void MouseMove(MouseEventArgs e, Character c)
        {
            PaintPixel(e, c);
        }


        public void MouseUp(MouseEventArgs e, Character c)
        {
            PaintPixel(e, c);
        }

        /// <summary>
        /// Draws a character preview in the given picture box
        /// and uses the border space to draw overlapping part of the character if the character does not fit
        /// The parameters offsX and offsY are used to move the perview character into the correct position before rasterising it
        /// </summary>
        public void DrawPreview(Graphics graphics, SizeInfo size, Character character, char c, Font font, int offsX, int offsY)
        {
            int usedWidth = size.Width;
            int usedHeight = size.Height;
            if (character != null)
            {
                usedWidth = character.Width;
                usedHeight = character.Height;
            }

            int bX = (int)Math.Ceiling(usedWidth * cBorderFactor); bX += bX % 2;
            int bY = (int)Math.Ceiling(usedHeight* cBorderFactor); bY += bY % 2;
            int fullWidth = usedWidth + bX;
            int fullHeight = usedHeight + bY;

            Bitmap b = Utils.CreateFontPicture(c, font, fullWidth , fullHeight , bX/2+offsX, bY/2+ offsY);

            byte[,] matrix = new byte[fullWidth , fullHeight ];
            for (int y = 0; y < fullHeight  ; y++)
            {
                for (int x = 0; x < fullWidth ; x++)
                {
                    byte colorID = Constants.BACKGROUND_COLOR_ID;
                    Color color = b.GetPixel(x, y);
                    if (color.R < 128)
                    {
                        colorID = Constants.FOREGROUND_COLOR_ID;
                    }
                    matrix[x, y] = colorID;
                }
            }

            DrawMatrix(graphics, matrix, fullWidth, fullHeight , false, true, usedWidth, usedHeight);
        }


        /// <summary>
        /// Draws a character in the given picture box
        /// </summary>
        public void Draw(Graphics graphics, Character character, bool showBits, bool showBoundary = false)
        {
            if (character == null) return;

            int usedWidth = character.Width;
            int usedHeight = character.Height;

            int bX = (int)Math.Ceiling(usedWidth * cBorderFactor); bX += bX % 2;
            int bY = (int)Math.Ceiling(usedHeight * cBorderFactor); bY += bY % 2;
            int fullWidth = usedWidth + bX;
            int fullHeight = usedHeight + bY;

            byte[,] matrix = new byte[fullWidth, fullHeight];
            int xOffs= (fullWidth - usedWidth) / 2;
            int yOffs= (fullHeight- usedHeight) / 2;

            for (int y = 0; y < usedWidth; y++)
            {
                for (int x = 0; x < usedHeight; x++)
                {
                    matrix[xOffs + x, yOffs + y] = character.Matrix[x, y];
                }
            }

            DrawMatrix(graphics, matrix, fullWidth, fullHeight, showBits, showBoundary, usedWidth, usedHeight);
        }


        /// <summary>
        /// Draws a matrix with palette indices in the given picture box
        /// </summary>
        public void DrawMatrix(Graphics graphics, byte[,] matrix, int matrixWidth, int matrixHeight, bool showBits, bool drawBoundary = false, int boundaryWidth = 0, int boundaryHeight = 0)
        {
            float w = (float)picture.Width / matrixWidth;
            float h = (float)picture.Height / matrixHeight;

            Font fontForBits = null;
            if (showBits)
            {
                fontForBits = new Font("Arial", 10);
                fontForBits = Utils.ScaleFont(graphics, fontForBits, "--0000--", new Size((int)w, (int)h));
            }

            Brush blackBrush = new SolidBrush(Color.Black);
            Brush whiteBrush = new SolidBrush(Color.White);
            Brush backGroundBrush = new SolidBrush(Constants.colors[Constants.BACKGROUND_COLOR_ID]);

            // clear
            graphics.FillRectangle(backGroundBrush, 0, 0, picture.Width, picture.Height);

            for (int y = 0; y < matrixHeight; y++)
            {
                for (int x = 0; x < matrixWidth; x++)
                {
                    int colorId = matrix[x, y];
                    Brush boxBrush = new SolidBrush(Constants.colors[colorId]);

                    // draw box
                    graphics.FillRectangle(boxBrush, (x) * w, (y) * h, w, h);

                    if (showBits)
                    {
                        String bits = Utils.ByteToString(colorId);
                        SizeF bitsSize = graphics.MeasureString(bits, fontForBits);

                        // draw bits
                        if (colorId < 8)
                        {
                            graphics.DrawString(bits, fontForBits, blackBrush, x * w + w / 2 - bitsSize.Width / 2, y * h + 2);
                        }
                        else
                        {
                            graphics.DrawString(bits, fontForBits, whiteBrush, x * w + w / 2 - bitsSize.Width / 2, y * h + 2);
                        }
                    }
                }
            }

            if (drawBoundary)
            {
                Pen penRed = new Pen(Color.Red);
                graphics.DrawRectangle(penRed, (matrixWidth - boundaryWidth) / 2 * w, (matrixHeight - boundaryHeight) / 2 * h, boundaryWidth*w , boundaryHeight*h);
            }
        }
    }
}
