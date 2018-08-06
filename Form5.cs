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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        MySqlConnection connection;
        private bool checklogin(string r)
        {

            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            string query = "SELECT * FROM `sinistre` where `N°Sinstre`=@num";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@num", r);
            MySqlDataReader test = cmd.ExecuteReader();
            if (test.Read())
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string num = textBox1.Text;
            
            if (num == "" )
            {
                MessageBox.Show("Veuillez donner le numéro du sinistre");
                return;
            }
            bool r = checklogin(num);

            if (r)
            {  
                Form8 f8 = new Form8();
                this.Hide();
                f8.Show();

            }
            else
                MessageBox.Show("Vérifiez vos paramètres");
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }
    }
}
