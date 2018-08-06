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
    public partial class Form19 : Form
    {
        MySqlConnection connection;
        public Form19()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;
            string nom = textBox1.Text;
            string mdp = textBox1.Text;
            string mat = textBox1.Text;
            if (id == "" || nom == ""|| mdp== ""|| mat == "")
            {
                MessageBox.Show("veuillez remplir les champs");
            }
            else
            { 
              connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
                try
                {
                   
                    connection.Open();
                    string query = "INSERT INTO `gestionnaire` (`ID gestionnaire`, `Nom`, `Prenom`, `Matricule`)VALUES ('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "') ";
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

         private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 f3 = new Form2();
            this.Hide();
            f3.Show();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
        
        }

    


        
    }
}
