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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection connection;
        private bool checklogin(string user, string pass)
        {
           
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            string query = "Select * from utilisateur where `login`=@user and `mot de passe`=@pass";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

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

         private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = maskedTextBox1.Text;
            if (user == "" || pass == "")
            {
                MessageBox.Show("Veuillez remplir les champs vides ");
                return;
            }
            bool r = checklogin(user, pass);

            if (r)
            {
                MessageBox.Show("Connexion valide");
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();

            }
            else
                MessageBox.Show("Vérifiez vos paramètres");
        }

         private void button2_Click(object sender, EventArgs e)
         {
             this.Hide();
         }

       

       
        
    }
}
