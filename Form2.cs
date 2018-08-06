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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3= new Form3();
            this.Hide();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form42 f42= new Form42() ;
            this.Hide();
            f42.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form70 f9= new Form70();
            this.Hide();
            f9.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            this.Hide();
            f14.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            this.Hide();
            f15.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            this.Hide();
            f16.Show();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            this.Hide();
            f17.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

      

        
    }
}
