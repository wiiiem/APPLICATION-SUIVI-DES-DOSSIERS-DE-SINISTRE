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
    public partial class Form41 : Form
    {
        public Form41()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form16 f3 = new Form16();
            this.Hide();
            f3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form31 f3 = new Form31();
            this.Hide();
            f3.Show();
        }

    
        private void button2_Click(object sender, EventArgs e)
        {
            Form32 f3 = new Form32();
            this.Hide();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form33 f3 = new Form33();
            this.Hide();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form34 f3 = new Form34();
            this.Hide();
            f3.Show();

        }
    }
}
