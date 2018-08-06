using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form70 : Form
    {
        public Form70()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f3 = new Form2();
            this.Hide();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form71 f3 = new Form71();
            this.Hide();
            f3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 f3 = new Form9();
            this.Hide();
            f3.Show();
        }

          }
}
