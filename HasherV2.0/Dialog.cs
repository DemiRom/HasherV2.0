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
    public partial class Dialog : Form
    {
        String Title;
        String Message;

        public Dialog()
        {
            InitializeComponent();
        }

        public void Open(String title, String message)
        {
            this.Message = message;
            this.Title = title;

            this.Text = Title;
            label1.Text = Message;

            this.Show();
        }

        //getters and setters
        public String getMessage()
        {
            return this.Message;
        }
        public void setMessage(String Message)
        {
            this.Message = Message;
        }
        public String getText()
        {
            return this.Title;
        }
        public void setText(String text)
        {
            this.Title = text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
