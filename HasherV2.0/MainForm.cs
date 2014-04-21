using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using HasherV2._0.Properties;

namespace HasherV2._0
{
    public partial class MainForm : Form
    {
        Hasher _hasher;
        DeHasher _deHasher;

        HelpDialog _helpDialog;
        Dialog _dialog;

        String _fileName;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _hasher = new Hasher();
            _deHasher = new DeHasher();
            _helpDialog = new HelpDialog();
            _dialog = new Dialog();

            textBox1.Text = Resources.MainForm_Form1_Load_Hash_Key_or_Input_Text;
            textBox2.Text = Resources.MainForm_Form1_Load_Length;
            textBox3.Text = Resources.MainForm_Form1_Load_Known_Letters;

            textBox2.Enabled = false;
            textBox3.Enabled = false;
            richTextBox1.Enabled = false;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _helpDialog.Open("Help","If you know some of the characters put them here in \nthe correct order anthing you don't know just leave an 'a' there.");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = !textBox3.Enabled;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            button2.Enabled = true;
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
            long key;
            long length;
            if (radioButton2.Checked)
            {

                try
                {
                    key = Convert.ToInt64(textBox1.Text);
                    length = Convert.ToInt64(textBox2.Text);
                }
                catch (Exception)
                {
                    _dialog = new Dialog();
                    _dialog.Open("Error", "Invalid Input.");
                    key = 0;
                    length = 0;
                }
            }
            else
            {
                key = 0;
                length = 0;
            }

        var guess = textBox3.Text ?? "";
            
            if(radioButton1.Checked){
                progressBar1.Value = 0;
                richTextBox1.Text = Resources.MainForm_button2_Click_Key__;
                richTextBox1.Text += _hasher.Hash(textBox1.Text).ToString(CultureInfo.InvariantCulture);
                richTextBox1.Text += Resources.MainForm_button2_Click_;
                richTextBox1.Text += Resources.MainForm_button2_Click_Length__;
                richTextBox1.Text += textBox1.Text.Length.ToString(CultureInfo.InvariantCulture);
                progressBar1.Value = 100;
            }else if(radioButton2.Checked){
                progressBar1.Value = 0;
                
                _deHasher.DeHash(key, length, guess);
                
            }
            else
            {
                _dialog.Open("Error", "Please select either Hash, or De Hash");
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save.FileName = "*.txt";
            Save.ShowDialog();
            try
            {
                var writer = new System.IO.StreamWriter(_fileName);
                writer.Write(richTextBox1.Text);
                writer.Close();
            }
            catch (Exception)
            {
                _dialog = new Dialog();
                _dialog.Open("Error", "Oops Somethign went wrong!");
            }
        }

        private void Save_FileOk(object sender, CancelEventArgs e)
        {
            _fileName = Save.FileName;
        }

    }
}
