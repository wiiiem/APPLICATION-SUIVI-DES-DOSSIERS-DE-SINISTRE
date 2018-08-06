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
    public partial class Form9 : Form
    {
        MySqlConnection connection;
        public Form9()
        {
            InitializeComponent();
        }


         private bool checklogin(string user)
        {

            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            string query = "Select * from sinistre where `N°Sinstre`=@user ";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@user", user);
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            
            if (user == "")
            {
                MessageBox.Show("Veuillez remplir le champs vide ");
                return;
            }
            bool r = checklogin(user);

            if (r)
            {
                
            Form13 f13 = new Form13(textBox1.Text);
            this.Hide();
            f13.ShowDialog();

            }
            else
                MessageBox.Show("Vérifiez le numéro du sinistre");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        
    }
}
