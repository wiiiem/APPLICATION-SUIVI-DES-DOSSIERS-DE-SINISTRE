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
    public partial class Form17 : Form
    {
        MySqlConnection connection;
        public Form17()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
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
            string pass = maskedTextBox1.Text;
            if (user == "" || pass == "")
            {
                MessageBox.Show("Veuillez remplir les champs vides ");
                return;
            }
            bool r = checklogin(user);

            if (r)
            {
                connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
                string query1 = "UPDATE `utilisateur` SET `mot de passe`='" + maskedTextBox2.Text + "' WHERE `ID utilisateur`='" + textBox1.Text + "' ";
                try
                {
                    connection.Open();
                    MySqlCommand cmd1 = new MySqlCommand();
                    cmd1.CommandText = query1;
                    cmd1.Connection = connection;
                    cmd1.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Modification terminée avec succèes");
                    Form2 f2 = new Form2();
                    this.Hide();
                    f2.Show();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
            else
                MessageBox.Show("Vérifiez vos paramètres");

           
                

           
           
        }

       
    }
}
