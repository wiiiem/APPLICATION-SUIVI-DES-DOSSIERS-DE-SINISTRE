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
    public partial class Form35 : Form
    {
        MySqlConnection connection;
        public Form35()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;
            string t1 = textBox1.Text;


            if (id == "" || t1 == "")
            {
                MessageBox.Show("veuillez remplir les champs");
            }
            else
            {
                connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
                try
                {

                    connection.Open();
                    string query = "INSERT INTO `délégation`(`ID délégation`, `Nom_territoire`)   VALUES ('" + textBox2.Text + "','" + textBox1.Text + "') ";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Ajout terminée avec succès");
                    Form16 f16 = new Form16();
                    this.Hide();
                    f16.Show();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            this.Hide();
            f16.Show();
        }

      
    }
}
