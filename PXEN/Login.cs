using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace PXEN
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vars.mainLogin = textBox1.Text;

            frmMain main = new frmMain();
            this.Hide();
            main.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            vars.dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (textBox2.Text == "")
                {

                }
                else if (textBox1.Text == "")
                {

                }
                else
                {
                    button1.PerformClick();
                }                
            }
            else
            {

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                button1.PerformClick();
            }
            else
            {

            }
        }
    }
}
