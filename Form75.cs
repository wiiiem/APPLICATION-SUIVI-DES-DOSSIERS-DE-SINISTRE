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
    public partial class Form75 : Form
    {
        MySqlConnection connection;
        public Form75()
        {
            InitializeComponent();
        }

        private void Form75_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            try
            {
                connection.Open();
                string query = "SELECT * FROM `type_opération` ";
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
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            string query = "SELECT * FROM `type_opération` WHERE `ID opération`='" + comboBox1.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string id = rd.GetInt64(0).ToString();
                string t = rd.GetString(1);


                comboBox1.Text = id;
                textBox1.Text = t;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            this.Hide();
            f16.Show();
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
                string query3 = "DELETE FROM `type_opération` WHERE `ID opération `='" + comboBox1.Text + "' ";
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

    }
}
