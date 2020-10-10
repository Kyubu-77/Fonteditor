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
        private void ShowSize(SizeInfo size)
        {
            if (size == null)
            {
                ForbitEditingSize();
                return;
            }

            AllowEditingSize();
            FillSizeControls(size);
        }

        private void FillSizeControls(SizeInfo size)
        {
            if (size == null) return;

            updateSize = true;

            txtSizeName.Text = size.Name;
            txtSizeX.Text = size.Width.ToString();
            txtSizeY.Text = size.Height.ToString();

            txtPreviewFontName.Text = size.PreviewFont.FontFamily.Name;
            txtPreviewPreviewFontSize.Text = size.PreviewFont.Size.ToString();
            txtPreviewOffsetX.Text = size.PreviewOffsetX;
            txtPreviewOffsetY.Text = size.PreviewOffsetY;
            txtPreviewChar.Text = size.PreviewChar;
            txtBasePaletteIndex.Text = size.GenBasePaletteIndex.ToString();

            trbRedBackground.Value = size.PalletteBackgroundRed;
            trbGreenBackground.Value = size.PalletteBackgroundGreen;
            trbBlueBackground.Value = size.PalletteBackgroundBlue;
            trbRedForeground.Value = size.PalletteForegroundRed;
            trbGreenForeground.Value = size.PalletteForegroundGreen;
            trbBlueForeground.Value = size.PalletteForegroundBlue;

            RefillCharactersComboBox();


            if (cboCharacter.Items.Count > 0)
            {
                updateCharacter = true;
                cboCharacter.SelectedIndex = 0;
                updateCharacter = false;
            }

            updateSize = false;

            UpdatePaletteColor();

            ShowCharacter((Character)cboCharacter.SelectedItem);
        }



        private void AllowEditingSize()
        {
            grpSize.Enabled = true;
            btnDeleteSize.Enabled = true;
        }

        private void ForbitEditingSize()
        {
            grpSize.Enabled = false;
            ForbitEditingCharacter();

            btnDeleteSize.Enabled = false;
        }

        private void RefillSizesComboBox()
        {
            RasterFont font = getCurrentFont();

            cboSizes.Items.Clear();
            cboCharacter.SelectedItems.Clear();
            foreach (SizeInfo s in font.SizeInfos)
            {
                cboSizes.Items.Add(s);
            }
        }

        private void cboSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updateSize) return;
            ShowSize((SizeInfo)cboSizes.SelectedItem);
        }

        private void btnAddSize_Click(object sender, EventArgs e)
        {
            RasterFont font = getCurrentFont();
            if (font == null) return;

            SizeInfo size = new SizeInfo("new_Size", 10, 10);

            updateSize = true;
            font.SizeInfos.Add(size);
            cboSizes.Items.Add(size);
            cboSizes.SelectedItem = size;
            updateSize = false;

            ShowSize(size);
        }

        private void btnDeleteSize_Click(object sender, EventArgs e)
        {
            RasterFont font = getCurrentFont();
            if (font == null) return;

            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            updateSize = true;

            // remove from list
            font.SizeInfos.Remove(size);

            // find combo entry
            int index = cboSizes.Items.IndexOf(size);

            // remove combo entry 
            cboSizes.Items.Remove(size);

            // select next size
            if (index < cboSizes.Items.Count)
            {
                cboSizes.SelectedIndex = index;
            }
            else if (cboSizes.Items.Count > 0)
            {
                cboSizes.SelectedIndex = index - 1;
            }
            else
            {
                cboSizes.SelectedItem = null;// last cbo entry removed
            }

            updateSize = false;

            ShowSize((SizeInfo)cboSizes.SelectedItem);
        }


        private void txtSizeName_TextChanged(object sender, EventArgs e)
        {
            if (updateSize) return;

            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            size.Name = txtSizeName.Text;

            updateSize = true;
            RefillSizesComboBox();
            cboSizes.SelectedItem = size;
            updateSize = false;

        }

        private void txtSizeX_TextChanged(object sender, EventArgs e)
        {
            if (updateSize) return;

            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            try
            {
                size.Width = Convert.ToUInt16(txtSizeX.Text);
            }
            catch
            {
                size.Width = 0;
            }

            updateSize = true;
            RefillSizesComboBox();
            cboSizes.SelectedItem = size;
            updateSize = false;
        }

        private void txtSizeY_TextChanged(object sender, EventArgs e)
        {
            if (updateSize) return;

            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            try
            {
                size.Height = Convert.ToUInt16(txtSizeY.Text);
            }
            catch
            {
                size.Height = 0;
            }


            updateSize = true;
            RefillSizesComboBox();
            cboSizes.SelectedItem = size;
            updateSize = false;
        }


        private void cbxPreviewActive_CheckedChanged(object sender, EventArgs e)
        {
            charViewHandler.RefreshPicture();
            if (cbxPreviewActive.Checked)
            {
                cboCharacter.Enabled = false;
            } else
            {
                cboCharacter.Enabled = true;
            }
        }

        private void txtPreviewOffsetX_TextChanged(object sender, EventArgs e)
        {
            if (updateSize) return;

            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            size.PreviewOffsetX = txtPreviewOffsetX.Text;


            if (cbxPreviewActive.Checked)
            {
                charViewHandler.RefreshPicture();
            }
        }

        private void txtPreviewOffsetY_TextChanged(object sender, EventArgs e)
        {
            if (updateSize) return;

            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            size.PreviewOffsetY = txtPreviewOffsetY.Text;

            if (cbxPreviewActive.Checked)
            {
                charViewHandler.RefreshPicture();
            }
        }

        private void txtPreviewChar_TextChanged(object sender, EventArgs e)
        {
            if (updateSize) return;

            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            size.PreviewChar = txtPreviewChar.Text;

            if (cbxPreviewActive.Checked)
            {
                charViewHandler.RefreshPicture();
            }
        }

        private void btnPreviewFontSizeUp_Click(object sender, EventArgs e)
        {
            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            double fontSize;
            try
            {
                fontSize = Convert.ToDouble(size.PreviewFont.Size);
                fontSize++;
                size.PreviewFont = new Font(size.PreviewFont.Name, (float)fontSize, size.PreviewFont.Style);
                txtPreviewPreviewFontSize.Text = size.PreviewFont.Size.ToString();
                if (cbxPreviewActive.Checked)
                {
                    charViewHandler.RefreshPicture();
                }
            }
            catch
            {
                return;
            }
        }

        private void btnPreviewFontSizeUp_Down(object sender, EventArgs e)
        {
            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            double fontSize;
            try
            {
                fontSize = Convert.ToDouble(size.PreviewFont.Size);
                fontSize--;
                size.PreviewFont = new Font(size.PreviewFont.Name, (float)fontSize, size.PreviewFont.Style);
                txtPreviewPreviewFontSize.Text = size.PreviewFont.Size.ToString();
                if (cbxPreviewActive.Checked)
                {
                    charViewHandler.RefreshPicture();
                }
            }
            catch
            {
                return;
            }
        }

        private void btnPreviewXDown_Click(object sender, EventArgs e)
        {
            int offsetX;
            try
            {
                offsetX = Convert.ToInt32(txtPreviewOffsetX.Text);
                offsetX--;
                txtPreviewOffsetX.Text = offsetX.ToString();
                if (cbxPreviewActive.Checked)
                {
                    charViewHandler.RefreshPicture();
                }
            }
            catch
            {
                return;
            }
        }

        private void btnPreviewXUp_Click(object sender, EventArgs e)
        {
            int offsetX;
            try
            {
                offsetX = Convert.ToInt32(txtPreviewOffsetX.Text);
                offsetX++;
                txtPreviewOffsetX.Text = offsetX.ToString();
                if (cbxPreviewActive.Checked)
                {
                    charViewHandler.RefreshPicture();
                }
            }
            catch
            {
                return;
            }

        }

        private void btnPreviewYUp_Click(object sender, EventArgs e)
        {
            int offsetY;
            try
            {
                offsetY = Convert.ToInt32(txtPreviewOffsetY.Text);
                offsetY++;
                txtPreviewOffsetY.Text = offsetY.ToString();
                if (cbxPreviewActive.Checked)
                {
                    charViewHandler.RefreshPicture();
                }
            }
            catch
            {
                return;
            }
        }

        private void btnPreviewYDown_Click(object sender, EventArgs e)
        {
            int offsetY;
            try
            {
                offsetY = Convert.ToInt32(txtPreviewOffsetY.Text);
                offsetY--;
                txtPreviewOffsetY.Text = offsetY.ToString();
                if (cbxPreviewActive.Checked)
                {
                    charViewHandler.RefreshPicture();
                }
            }
            catch
            {
                return;
            }
        }

        private void btnPreviewSelectFont_Click(object sender, EventArgs e)
        {
            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;


            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = size.PreviewFont;
            DialogResult result = fontDialog.ShowDialog();
            if (result == DialogResult.OK)
            {

                txtPreviewFontName.Text = fontDialog.Font.FontFamily.Name;
                txtPreviewPreviewFontSize.Text = fontDialog.Font.Size.ToString();
                size.PreviewFont = fontDialog.Font;
            }
            if (cbxPreviewActive.Checked)
            {
                charViewHandler.RefreshPicture();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export.ExportFontInSizeToFile((SizeInfo)cboSizes.SelectedItem, cbxRotate90CC.Checked, cbxAddGreeble.Checked);
        }

        private void UpdatePaletteColor()
        {
            if (updateSize) return;
            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            size.PalletteBackgroundRed = (byte)trbRedBackground.Value;
            size.PalletteBackgroundGreen = (byte)trbGreenBackground.Value;
            size.PalletteBackgroundBlue = (byte)trbBlueBackground.Value;
            size.PalletteForegroundRed = (byte)trbRedForeground.Value;
            size.PalletteForegroundGreen = (byte)trbGreenForeground.Value;
            size.PalletteForegroundBlue = (byte)trbBlueForeground.Value;

            Constants.RecalcColors((byte)trbRedBackground.Value, (byte)trbGreenBackground.Value, (byte)trbBlueBackground.Value,
                (byte)trbRedForeground.Value, (byte)trbGreenForeground.Value, (byte)trbBlueForeground.Value);
            picColorSelector.Refresh();
            charViewHandler.RefreshPicture();
        }

        private void trbRed_Scroll(object sender, EventArgs e)
        {
            UpdatePaletteColor();
        }


        private void trbGreen_Scroll(object sender, EventArgs e)
        {
            UpdatePaletteColor();
        }

        private void trbBlue_Scroll(object sender, EventArgs e)
        {

            UpdatePaletteColor();
        }

        private void trbRedForeground_Scroll(object sender, EventArgs e)
        {
            UpdatePaletteColor();
        }

        private void trbGreenForeground_Scroll(object sender, EventArgs e)
        {
            UpdatePaletteColor();
        }

        private void trbBlueForeground_Scroll(object sender, EventArgs e)
        {
            UpdatePaletteColor();
        }


        private void txtBasePaletteIndex_TextChanged(object sender, EventArgs e)
        {
            if (updateSize) return;

            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            size.GenBasePaletteIndex = Convert.ToByte(txtBasePaletteIndex.Text);


            if (cbxPreviewActive.Checked)
            {
                charViewHandler.RefreshPicture();
            }
        }

        
        private void genGreeble(bool onlySelected)
        {
            byte GreebleRange = 4;

            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;


            foreach (Character character in size.characters)
            {
                if (onlySelected )
                {
                    if (!cboCharacter.SelectedItems.Contains(character)) {
                        continue;
                    }
                }

                for (int y = 0; y < character.Width; y++)
                {

                    for (int x = 0; x < character.Height; x++)
                    {
                        if (character.Matrix[x, y] == 0) continue;
                        // propability for greeble
                        if (Constants.Rnd.NextDouble() < 0.7f)
                        {
                            int add = Constants.Rnd.Next(GreebleRange + 1) - GreebleRange / 2;

                            int newVal = (int)(character.Matrix[x, y] + add);

                            // don't change background
                            {
                                if (0 <= newVal && newVal < Constants.colors.Count())
                                {
                                    character.Matrix[x, y] = (byte)newVal;
                                }
                            }



                            if (Constants.Rnd.NextDouble() < 0.2f)
                            {
                                character.Matrix[x, y] = (byte)(Constants.colors.Count() - 1);
                            }

                        }
                    }
                }
            }
            charViewHandler.RefreshPicture();
        }

        private void btnGreebleToSel_Click(object sender, EventArgs e)
        {
            genGreeble(true);
        }

        private void btnGreebleToAll_Click(object sender, EventArgs e)
        {
            genGreeble(false);
        }

        private void btnPaletteUp_Click(object sender, EventArgs e)
        {
            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;


            foreach (Character character in size.characters)
            {
                for (int y = 0; y < character.Width; y++)
                {

                    for (int x = 0; x < character.Height; x++)
                    {
                        if (character.Matrix[x, y] == 0) continue;
                        if (character.Matrix[x, y] == Constants.colors.Count() - 1) continue;
                        character.Matrix[x, y] = (byte)(character.Matrix[x, y] + 1);
                    }
                }
            }
            charViewHandler.RefreshPicture();
        }


        private void btnPaletteDown_Click(object sender, EventArgs e)
        {

            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;


            foreach (Character character in size.characters)
            {
                for (int y = 0; y < character.Width; y++)
                {

                    for (int x = 0; x < character.Height; x++)
                    {
                        if (character.Matrix[x, y] == 0) continue;
                        character.Matrix[x, y] = (byte)(character.Matrix[x, y] - 1);
                    }
                }
            }
            charViewHandler.RefreshPicture();
        }
    }


}
