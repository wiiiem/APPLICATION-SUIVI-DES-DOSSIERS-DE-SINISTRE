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
    public partial class Form56 : Form
    {
        public Form56()
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
            Form43 f3 = new Form43();
            this.Hide();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form44 f3 = new Form44();
            this.Hide();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form46 f3 = new Form46();
            this.Hide();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form45 f3 = new Form45();
            this.Hide();
            f3.Show();
        }
    }
}
