using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FontEditor
{
    public partial class FrmMain : Form
    {
        RasterFont getCurrentFont()
        {
            return currentFont;
        }

        private void btnNewFont_Click(object sender, EventArgs e)
        {
            currentFont = new RasterFont();
            ShowFont(currentFont);
        }

        private void btnLoadFont_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Open XML File";
            openDialog.Filter = "XML files|*.xml";
            openDialog.InitialDirectory = AppContext.BaseDirectory;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                currentFont = XmlProcessor.LoadFont(openDialog.FileName.ToString());
                ShowFont(currentFont);
            }
        }

        private void btnSaveFont_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = AppContext.BaseDirectory;
            saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                String xml = XmlProcessor.SaveFont(currentFont, saveFileDialog.FileName.ToString());
            }
        }

        private void ShowFont(RasterFont font)
        {
            if (font == null)
            {
                ForbitEditingFont();
                return;
            }

            AllowEditingFont();
            FillFontControls(font);
        }

        private void FillFontControls(RasterFont font)
        {
            if (font == null) return;
            updateFont = true;

            // textbox
            txtFontName.Text = currentFont.Name;

            // combobox
            RefillSizesComboBox();
            
            if (cboSizes.Items.Count > 0)
            {
                updateSize = true;
                cboSizes.SelectedIndex = 0;
                updateSize = false;
            }
            
            updateFont = false;

            ShowSize((SizeInfo)cboSizes.SelectedItem);
        }

        private void AllowEditingFont()
        {
            grpFont.Enabled = true;
        }

        private void ForbitEditingFont()
        {
            grpFont.Enabled = false;
            ForbitEditingSize();
        }
        private void txtFontName_TextChanged(object sender, EventArgs e)
        {
            if (updateFont) return;

            RasterFont font = getCurrentFont();
            if (font == null) return;

            font.Name = txtFontName.Text;
        }
    }
}
