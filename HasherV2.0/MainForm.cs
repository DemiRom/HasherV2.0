using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HasherV2._0
{
    public partial class MainForm : Form
    {
        Hasher hasher;

        HelpDialog helpDialog;
        Dialog dialog;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hasher = new Hasher();
            helpDialog = new HelpDialog();
            dialog = new Dialog();

            textBox1.Text = "Hash Key or Input Text";
            textBox2.Text = "Length";
            textBox3.Text = "Known Letters";

            textBox2.Enabled = false;
            textBox3.Enabled = false;
            richTextBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            helpDialog.Open("Help","If you know some of the characters put them here in \nthe correct order anthing you don't know just leave an 'a' there.");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(!textBox3.Enabled){
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.AddExtension = true;
            openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked){
                richTextBox1.Text = "Key: ";
                richTextBox1.Text += hasher.Hash(textBox1.Text).ToString();
                richTextBox1.Text += "\n";
                richTextBox1.Text += "Length: ";
                richTextBox1.Text += textBox1.Text.Length.ToString();
                progressBar1.Value = 100;
            }else if(radioButton2.Checked){
                //dehash
            }
            else
            {
                dialog.Open("Error", "Please select either Hash, or De Hash");
            }
        }

    }
}
