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
    public partial class Form18 : Form
    {
        MySqlConnection connection;
        public Form18()
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
             connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            //open connection
            try
            {
                {
                    connection.Open();
                    string query = "SELECT * FROM `utilisateur` ";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        comboBox2.Items.Add(rd.GetString(5));

                    } rd.Close();
                }
            }
                catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;
            string num = textBox1.Text;
            if (id == "" || num == "")
            {
                MessageBox.Show("veuillez remplir les champs");
            }
            else
            { 
              connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
                try
                {
                   
                    connection.Open();
                    string query = "INSERT INTO `utilisateur` (`ID utilisateur`, `Nom`, `Prenom`, `login`, `mot de passe`, `HACC`) VALUES ('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"+comboBox2.Text+"') ";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Ajout terminée avec succès");
                    Form3 f3 = new Form3();
                    this.Hide();
                    f3.Show();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);

                }


            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f3 = new Form2();
            this.Hide();
            f3.Show();
        }

       
    }
}
