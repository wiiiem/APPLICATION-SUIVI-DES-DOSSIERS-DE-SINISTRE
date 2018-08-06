using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form12 : Form
    {
        MySqlConnection connection;
        public Form12()
        {
            InitializeComponent();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
             try
            {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
           
           string query = " SELECT AVG (TIMESTAMPDIFF(MONTH ,`date d'ouverture dossier`,`date de règlement`))  FROM `sinistre`WHERE EXTRACT(YEAR FROM `date d'ouverture dossier`)='"+textBox2.Text+"'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            textBox1.Text = cmd.ExecuteScalar().ToString();
            }
             catch (MySqlException ex)
             {
                 MessageBox.Show(ex.Message);

             }
          
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
             try
            {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            string query = "SELECT TIMESTAMPDIFF(DAY ,`date d'ouverture dossier`,`Date opération`)FROM `sinistre`s inner join `Opération sur dossier` O ON S.`id sinistre` =O.`id sinistre` WHERE EXTRACT(YEAR FROM `date d'ouverture dossier`)='" + textBox3.Text + "' and `ID type`=101";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            textBox6.Text = cmd.ExecuteScalar().ToString();
            }
             catch (MySqlException ex)
            {
                   MessageBox.Show(ex.Message);
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
                connection.Open();
                string query = "SELECT TIMESTAMPDIFF(DAY ,`date d'ouverture dossier`,`Date opération`)FROM `sinistre`s inner join `Opération sur dossier` O ON S.`id sinistre` =O.`id sinistre` WHERE EXTRACT(YEAR FROM `date d'ouverture dossier`)='"+textBox4.Text+"' and `ID type`=78";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                
                textBox8.Text = cmd.ExecuteScalar().ToString();
            }
             catch (MySqlException ex)
            {
                   MessageBox.Show(ex.Message);
               
            }
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            Form42 f42 = new Form42();
            this.Hide();
            f42.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
                connection.Open();
                string query = "SELECT Count(*) FROM `sinistre`S INNER JOIN `Opération sur dossier` O ON S.`id sinistre` =O.`id sinistre` WHERE `ID type`=22 and EXTRACT(YEAR FROM `date d'ouverture dossier`)='"+ textBox5.Text + "'" ;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                textBox7.Text = cmd.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
       
       

       

       
    }
}
