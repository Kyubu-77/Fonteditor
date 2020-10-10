using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FontEditor
{
    public partial class FrmMain : Form
    {
        private void picCharacter_MouseMove(object sender, MouseEventArgs e)
        {
            Character character = (Character)cboCharacter.SelectedItem;
            if (character == null) return;

            charViewHandler.MouseMove(e, character);
        }

        private void picCharacter_MouseUp(object sender, MouseEventArgs e)
        {
            Character character = (Character)cboCharacter.SelectedItem;
            if (character == null) return;

            charViewHandler.MouseUp(e, character);
        }
        private void picColorSelector_MouseUp(object sender, MouseEventArgs e)
        {
            byte x = (byte)(e.X / (picColorSelector.Width / 2));
            byte y = (byte)(e.Y / (picColorSelector.Height / 8));


            charViewHandler.SelectedPaletteEntry = (byte)(x + y * 2);

            picColorSelector.Refresh();
        }

        private void picColorSelector_Paint(object sender, PaintEventArgs e)
        {

            float w = picColorSelector.Width / 2.0f;
            float h = picColorSelector.Height / 8.0f;

            Pen penBlack = new Pen(Color.Black);
            Pen penRed = new Pen(Color.Red);
            e.Graphics.DrawRectangle(penBlack, 0, 0, picColorSelector.Width - 1, picColorSelector.Height - 1);
            StringFormat format = new StringFormat();
            Font font = new Font("Arial", 10);
            font = Utils.ScaleFont(e.Graphics, font, "--0000--", new Size((int)w, (int)h));

            Brush blackBrush = new SolidBrush(Color.Black);
            Brush whiteBrush = new SolidBrush(Color.White);
            for (byte y = 0; y < 8; y++)
            {
                for (byte x = 0; x < 2; x++)
                {
                    int colorId = x + y * 2;
                    Color boxColor = Constants.colors[colorId];
                    Pen boxPen = new Pen(boxColor);
                    Brush boxBrush = new SolidBrush(boxColor);
                    String bits = Utils.ByteToString(colorId);
                    SizeF bitsSize = e.Graphics.MeasureString(bits, font);

                    // draw solid box
                    e.Graphics.FillRectangle(boxBrush, x * w + 2, y * h + 2, w - 4, h - 4);

                    // draw bits
                    if (colorId < 8)
                    {
                        e.Graphics.DrawString(bits, font, blackBrush, x * w + w / 2 - bitsSize.Width / 2, y * h + 2);
                    }
                    else
                    {
                        e.Graphics.DrawString(bits, font, whiteBrush, x * w + w / 2 - bitsSize.Width / 2, y * h + 2);
                    }

                    // draw selected
                    if (colorId == charViewHandler.SelectedPaletteEntry)
                    {
                        e.Graphics.DrawRectangle(penRed, x * w + 2, y * h + 2, w - 4, h - 4);
                    }
                }
            }

        }

        
        private void picChar_Paint(object sender, PaintEventArgs e)
        {
            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;
            Character character = (Character)cboCharacter.SelectedItem;
            if (!cbxPreviewActive.Checked)
            {
                charViewHandler.Draw(e.Graphics, (Character)cboCharacter.SelectedItem, cbxShowBits.Checked);
            }
            else
            {
                char c = ' ';
                if (txtPreviewChar.Text.Length > 0)
                {
                    c = txtPreviewChar.Text[0];
                }
                else if (character != null && character.Name.Length > 0)
                {
                    c = character.Name[0];
                }

                int offsetX;
                int offsetY;
                try
                {
                    offsetX = Convert.ToInt32(txtPreviewOffsetX.Text);
                    offsetY = Convert.ToInt32(txtPreviewOffsetY.Text);
                }
                catch
                {
                    return;
                }

                charViewHandler.DrawPreview(e.Graphics, (SizeInfo)cboSizes.SelectedItem, (Character)cboCharacter.SelectedItem, c, size.PreviewFont, offsetX, offsetY);
            }
        }
    }
}
