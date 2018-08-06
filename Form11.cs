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
    public partial class Form11 : Form
    {
        MySqlConnection connection;
        public Form11()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }
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

            if (num == "")
            {
                MessageBox.Show(" Veuillez donner le numéro du sinistre ");
                return;
            }
            bool r = checklogin(num);

            if (r)
            {
                //delete
                string query3 = "DELETE FROM `sinistre` WHERE `N°Sinstre`=@num ";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query3, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("suppression terminée");
                Form3 f3 = new Form3();
                this.Hide();
                f3.Show();
            }
            else
                MessageBox.Show(" Vérifiez Le numéro du sinistre ");
            
        }

        
    }
}
