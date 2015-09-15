using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CryptorEngine;

namespace PXEN
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtClearText.Text == "")
            {
                error.SetError(txtClearText, "Enter the text you want to encrypt");
            }
            else
            {
                error.Clear();
                string clearText = txtClearText.Text.Trim();
                string cipherText = CryptorEngine.CryptorEngine.Encrypt(clearText, vars.user2, true);
                txtCipherText.Text = cipherText;
                btnDecrypt.Enabled = true;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string clearText = txtClearText.Text.Trim();
            string decryptedText = CryptorEngine.CryptorEngine.Decrypt(clearText, vars.user2, true);
            txtDecryptedText.Text = decryptedText;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                vars.user2 = listBox1.SelectedItem.ToString();
            }
            else
            {
                vars.user2 = ".";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Text = "";
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] lines = new string[listBox1.Items.Count];
            listBox1.Items.CopyTo(lines, 0);
            File.WriteAllLines(vars.dir + @"\Userlist.dat", lines);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            vars.dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            if (File.Exists(vars.dir + @"\Userlist.dat") == true)
            {
                string[] lines = File.ReadAllLines(vars.dir + @"\Userlist.dat");
                listBox1.Items.AddRange(lines);
            }
            else File.Create(vars.dir + @"\Userlist.dat");

            if (listBox1.SelectedIndex > 0)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex - 1;
            }
            else if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
            }
            vars.helpOpen = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem.ToString());
            textBox1.Text = "";
            if (listBox1.SelectedIndex > 0)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex - 1;
            }
            else if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (vars.helpOpen == true)
            {

            }
            else if (vars.helpOpen == false)
            {
                Help hlp = new Help();
                hlp.Show();
                vars.helpOpen = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}