using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PXEN
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://pxen.px-scripts.herobo.com/");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Help_FormClosed(object sender, FormClosedEventArgs e)
        {
            vars.helpOpen = false;
        }
    }
}
