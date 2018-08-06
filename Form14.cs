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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form19 f18 = new Form19();
            this.Hide();
            f18.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form21 f20 = new Form21();
            this.Hide();
            f20.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form23 f24 = new Form23();
            this.Hide();
            f24.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form25 f25 = new Form25();
            this.Hide();
            f25.Show();
        }
    }
}
