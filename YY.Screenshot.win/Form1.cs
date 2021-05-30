using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YY.Screenshot.win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            screenshot = new Screenshot();
        }
        Screenshot screenshot;
        private void button1_Click(object sender, EventArgs e)
        { 
            Image image = this.screenshot.start(this, true, true);
            this.pictureBox1.Image = image;
        }
    }
}
