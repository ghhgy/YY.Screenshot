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
         
            hkl.Add(hotkey1);
            hkl.HotkeyPressed += Hkl_HotkeyPressed;

            label1.Text = "快捷键:" + hotkey1;
        }

        private HotkeyListener hkl = new HotkeyListener();
        private Hotkey hotkey1 = new Hotkey(Keys.Control | Keys.Shift, Keys.J);
        private Screenshot screenshot = new Screenshot();

        private void Hkl_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (e.Hotkey == hotkey1)
            {
                Image image = this.screenshot.start(this, true, true);
                this.pictureBox1.Image = image;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image image = this.screenshot.start(this, true, true);
            this.pictureBox1.Image = image;
        }
    }
}
