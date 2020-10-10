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
        private void ShowCharacter(Character character)
        {
            if (character == null)
            {
                ForbitEditingCharacter();
                return;
            }

            AllowEditingCharacter();
            FillCharacterControls(character);
        }

        private void FillCharacterControls(Character character)
        {
            if (character == null) return;

            updateCharacter = true;

            txtCharacterName.Text = character.Name;
            txtCharacterSizeX.Text = character.Width.ToString();
            txtCharacterSizeY.Text = character.Height.ToString();

            updateCharacter = false;

            charViewHandler.RefreshPicture();
        }

        private void AllowEditingCharacter()
        {
            grpCharacter.Enabled = true;
            btnDeleteChar.Enabled = true;
        }

        private void ForbitEditingCharacter()
        {
            grpCharacter.Enabled = false;
            btnDeleteChar.Enabled = false;
        }
        private void RefillCharactersComboBox()
        {
            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            cboCharacter.Items.Clear();
            cboCharacter.SelectedItems.Clear();
            foreach (Character c in size.characters)
            {
                cboCharacter.Items.Add(c);
            }
        }
        private void cboCharacter_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (updateCharacter) return;
            ShowCharacter((Character)cboCharacter.SelectedItem);
        }

        private void btnCopyCharacter_Click(object sender, EventArgs e)
        {
            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            Character character = (Character)cboCharacter.SelectedItem;
            Character newCharacter = new Character(character.Name+"Copy", size.Width, size.Height);
            for (int x  = 0; x < newCharacter.Width; x++)
            {
                for (int y = 0; y < newCharacter.Height;y++)
                {
                    newCharacter.Matrix[x, y] = character.Matrix[x, y];
                }
            }
            

            size.characters.Add(newCharacter);
            cboCharacter.Items.Add(newCharacter);
            updateSize = true;
            cboCharacter.SelectedItems.Clear();
            cboCharacter.SelectedItem = newCharacter;
            updateSize = false;

            ShowCharacter(newCharacter);
        }


        private void btnAddChar_Click(object sender, EventArgs e)
        {
            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            Character character = new Character("new", size.Width, size.Height);

            size.characters.Add(character);
            cboCharacter.Items.Add(character);
            updateSize = true;
            cboCharacter.SelectedItems.Clear();
            cboCharacter.SelectedItem = character;
            updateSize = false;

            ShowCharacter(character);
        }

        private void btnDeleteChar_Click(object sender, EventArgs e)
        {
            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            // find combo entry
            int index = 0;
            List<Character> delList = new List<Character>();
            foreach (Object element in cboCharacter.SelectedItems)
            {
                delList.Add((Character)element);
            }

            updateCharacter = true;

            foreach (Character character in delList)
            {
                // remove from list
                size.characters.Remove(character);

                // find combo entry
                index = cboCharacter.Items.IndexOf(character);

                // remove combo entry 
                cboCharacter.Items.Remove(character);
            }


            // select next character
            if (index < cboCharacter.Items.Count)
            {
                cboCharacter.SelectedIndex = index;
            }
            else if (cboCharacter.Items.Count > 0)
            {
                cboCharacter.SelectedIndex = index - 1;
            }
            else
            {
                cboCharacter.SelectedItem = null;// last cbo entry removed
            }

            updateCharacter = false;

            ShowCharacter((Character)cboCharacter.SelectedItem);
        }


        private void txtCharacterName_TextChanged(object sender, EventArgs e)
        {

            if (updateCharacter) return;

            Character character = (Character)cboCharacter.SelectedItem;
            if (character == null) return;

            character.Name = txtCharacterName.Text;

            updateCharacter = true;
            RefillCharactersComboBox();
            cboCharacter.SelectedItem = character;
            updateCharacter = false;
        }

        private void txtCharacterSizeX_TextChanged(object sender, EventArgs e)
        {
            //TextBox textBox = (TextBox)sender;
            //if (updateCharacter) return;

            //Character character = (Character)cboCharacter.SelectedItem;
            //if (character == null) return;

            //try
            //{
            //    character.Width = Convert.ToUInt16(textBox.Text);
            //}
            //catch
            //{
            //    character.Width = 0;
            //}

            //updateCharacter = true;
            //RefillCharactersComboBox();
            //cboCharacter.SelectedItem = character;
            //updateCharacter = false;
        }

        private void txtCharacterSizeY_TextChanged(object sender, EventArgs e)
        {
            //TextBox textBox = (TextBox)sender;
            //if (updateCharacter) return;

            //Character character = (Character)cboCharacter.SelectedItem;
            //if (character == null) return;

            //try
            //{
            //    character.Height = Convert.ToUInt16(textBox.Text);
            //}
            //catch
            //{
            //    character.Height = 0;
            //}


            //updateCharacter = true;
            //RefillCharactersComboBox();
            //cboCharacter.SelectedItem = character;
            //updateCharacter = false;
        }

        private void btnResizeCharacter_Click(object sender, EventArgs e)
        {
            //TextBox textBox = (TextBox)sender;
            if (updateCharacter) return;

            Character character = (Character)cboCharacter.SelectedItem;
            if (character == null) return;


            try
            {
                character.Width = Convert.ToUInt16(txtCharacterSizeX.Text);
            }
            catch
            {
                character.Width = 0;
            }

            try
            {
                character.Height = Convert.ToUInt16(txtCharacterSizeY.Text);
            }
            catch
            {
                character.Height = 0;
            }



            updateCharacter = true;
            RefillCharactersComboBox();
            cboCharacter.SelectedItem = character;
            updateCharacter = false;


            character.ResizeMatrix();
            ShowCharacter(character);
        }

        private void AddCharacters(string characters)
        {
            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            Character character = null; ;
            foreach (char c in characters)
            {
                character = new Character(c.ToString(), size.Width, size.Height);
                Utils.CreateMatrixWithSettings(size, character, c);
                size.characters.Add(character);
            }

            updateCharacter = true;
            RefillCharactersComboBox();
            cboCharacter.SelectedItem = character;
            updateCharacter = false;

            ShowCharacter(character);
        }

        private void btnAdd_A_to_Z_upper_Click(object sender, EventArgs e)
        {
            AddCharacters("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }

        private void btnAdd_A_to_Z_lower_Click(object sender, EventArgs e)
        {
            AddCharacters("abcdefghijklmnopqrstuvwxyz");
        }

        private void btnAdd_0_to_9_lower_Click(object sender, EventArgs e)
        {
            AddCharacters("0123456789");
        }

        private void btnAddPunktuation_Click(object sender, EventArgs e)
        {
            AddCharacters(".:,;'\"(!?)+-*/=");
        }


        private char FindCharacter(Character character)
        {
            char c = 'X';
            if (txtPreviewChar.Text.Length > 0)
            {
                c = txtPreviewChar.Text[0];
            }
            else if (character != null && character.Name.Length > 0)
            {
                c = character.Name[0];
            }

            return c;
        }

        private void btnFillCharacterMatrix_Click(object sender, EventArgs e)
        {
            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            Character character = (Character)cboCharacter.SelectedItem;
            if (character == null) return;

            char c = FindCharacter(character);

            Utils.CreateMatrixWithSettings(size, character, c);
            ShowCharacter(character);
            cbxPreviewActive.Checked = false;
        }

        private void btnNewCharacter_Click(object sender, EventArgs e)
        {
            SizeInfo size = (SizeInfo)cboSizes.SelectedItem;
            if (size == null) return;

            Character character = new Character("new" + txtPreviewChar.Text, size.Width, size.Height);

            size.characters.Add(character);
            cboCharacter.Items.Add(character);
            updateCharacter = true;
            cboCharacter.SelectedItems.Clear();
            cboCharacter.SelectedItem = character;

            updateCharacter = false;
            char c = FindCharacter(character);

            Utils.CreateMatrixWithSettings(size, character, c);
            ShowCharacter(character);
            cbxPreviewActive.Checked = false;
        }

        private void cbxShowBits_CheckedChanged(object sender, EventArgs e)
        {
            charViewHandler.RefreshPicture();
        }

    }
}
