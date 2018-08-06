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
    public partial class Form21 : Form
    {
        MySqlConnection connection;
        public Form21()
        {
            InitializeComponent();
        }

      
        private void Form21_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password="); 
            try {
                    connection.Open();
                    string query = "SELECT * FROM `gestionnaire` ";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        comboBox1.Items.Add(rd.GetString(0));

                    } rd.Close();

                    connection.Close();
                }
            
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            string query = "SELECT * FROM `gestionnaire`where `ID gestionnaire`='" + comboBox1.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string c2 = rd.GetInt64(0).ToString();
                string nom = rd.GetString(1);
                string pr = rd.GetString(2);
                string mat = rd.GetString(3);
                

                comboBox1.Text = c2;
                textBox1.Text = nom;
                textBox3.Text = pr;
                textBox4.Text =mat;
               
            } rd.Close();
            connection.Close();
        }
        private bool checklogin(string r)
        {

            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            string query = "SELECT * FROM `gestionnaire` where `ID gestionnaire`=@num";
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
            string num = comboBox1.Text;

            if (num == "")
            {
                MessageBox.Show("Veuillez donner l'identifiant");
                return;
            }
            bool r = checklogin(num);

            if (r)
            {
                string query1 = "UPDATE `gestionnaire` SET `Nom`='" + textBox1.Text + "',`Prenom`='" + textBox3.Text + "',`Matricule`='" + textBox4.Text + "' WHERE `ID gestionnaire`='" + comboBox1.Text + "'";
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
            else
                MessageBox.Show("Vérifiez vos paramètres");



        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }


    }
}
