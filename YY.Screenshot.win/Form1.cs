using System;
using System.Drawing;
using System.Windows.Forms;
using WK.Libraries.HotkeyListenerNS;
namespace YY.Screenshot.win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            screenshot = new Screenshot();


            hkl.Add(hotkey1);
            hkl.Add(hotkey2);

            hkl.HotkeyPressed += Hkl_HotkeyPressed;
        }

        private HotkeyListener hkl = new HotkeyListener();
        private Hotkey hotkey1 = new Hotkey(Keys.Control | Keys.Shift, Keys.J);
        private Hotkey hotkey2 = new Hotkey("Control+Shift+D4");
        private Screenshot screenshot;



        private void Hkl_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (e.Hotkey == hotkey1)
            {
                Image image = this.screenshot.start(this, false, true);
                this.pictureBox1.Image = image;
            }

            if (e.Hotkey == hotkey2)
            {
                MessageBox.Show($"Second hotkey '{hotkey2}'was pressed.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
