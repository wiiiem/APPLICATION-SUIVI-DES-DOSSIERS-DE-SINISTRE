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
    public partial class Form57 : Form
    {
        public Form57()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form16 f2 = new Form16();
            this.Hide();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form51 f3 = new Form51();
            this.Hide();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form52 f3 = new Form52();
            this.Hide();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form53 f3 = new Form53();
            this.Hide();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form54 f3 = new Form54();
            this.Hide();
            f3.Show();
        }
    }
}
