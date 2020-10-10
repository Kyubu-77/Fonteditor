using System;
using System.Windows.Forms;

namespace FontEditor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmMain f = new FrmMain();
            f.StartPosition = FormStartPosition.Manual;

            // Show app on left screen ...
            Screen leftScreen = null;
            foreach (Screen screen in Screen.AllScreens)
            {
                if (leftScreen == null)
                {
                    leftScreen = screen;
                }
                else
                {
                    if (screen.Bounds.Left < leftScreen.Bounds.Left)
                    {
                        leftScreen = screen;
                    }
                }
            }

            
            f.Location = leftScreen.Bounds.Location;
            
            Application.Run(f);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
