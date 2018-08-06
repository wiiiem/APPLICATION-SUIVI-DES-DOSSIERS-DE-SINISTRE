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
    public partial class Form10 : Form
    {
        MySqlConnection connection;
        public Form10()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }
        private bool checklogin(string user)
        {

            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            string query = "Select * from utilisateur where `ID utilisateur`=@user ";
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

        private void button1_Click(object sender, EventArgs e)
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
                this.Hide();
                Form11 f11 = new Form11();
                f11.Show();

            }
            else
                MessageBox.Show("Vérifiez votre identifiant");
        }

       
       
    }
}
