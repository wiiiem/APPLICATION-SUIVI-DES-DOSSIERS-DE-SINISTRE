﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Hide();
            f4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f6= new Form6();
            this.Hide();
            f6.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            this.Hide();
            f7.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
       
        {
            Form10 f10 = new Form10();
            this.Hide();
            f10.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

       
      
    }
}
