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
    public partial class Form54 : Form
    {
        MySqlConnection connection;
        public Form54()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string num = comboBox1.Text;

            if (num == "")
            {
                MessageBox.Show("Veuillez donner l'identifiant");
                return;
            }
            else
            {  //delete
                string query3 = "DELETE FROM `branche`WHERE `ID branche`='" + comboBox1.Text + "' ";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query3, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("suppression terminée");
                Form16 f2 = new Form16();
                this.Hide();
                f2.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form16 f2 = new Form16();
            this.Hide();
            f2.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            string query = "SELECT * FROM `branche` where `ID branchee`='" + comboBox1.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string c1 = rd.GetInt64(0).ToString();
                string nom = rd.GetInt64(0).ToString();

                comboBox1.Text = c1;
                textBox1.Text = nom;


            } rd.Close();


        }

        private void Form54_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            try
            {
                connection.Open();
                string query = "SELECT * FROM `branche` ";
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
    }
}
