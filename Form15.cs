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
    public partial class Form15 : Form
    {
        public Form15()
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

            Form18 f18 = new Form18();
            this.Hide();
            f18.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form20 f20 = new Form20();
            this.Hide();
            f20.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form24 f24 = new Form24();
            this.Hide();
            f24.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            Form22 f22 = new Form22();
            this.Hide();
            f22.Show();
        }
    }
}
