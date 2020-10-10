using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FontEditor
{
    public partial class FrmMain : Form
    {

        CharViewHandler charViewHandler;
        RasterFont currentFont = null;
        bool updateFont = false;
        private bool updateSize;
        private bool updateCharacter;

        public FrmMain()
        {
            InitializeComponent();

            charViewHandler = new CharViewHandler(picChar, picColorSelector);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ShowFont(null);
        }

        
    }
}