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
    public partial class Form66 : Form
    {
        MySqlConnection connection;
        public Form66()
        {
            InitializeComponent();
        }

        private void Form66_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            try
            {
                connection.Open();
                string query = "SELECT * FROM `tiers` ";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox3.Items.Add(rd.GetString(0));
                    comboBox2.Items.Add(rd.GetString(2));

                } rd.Close();

                connection.Close();
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            string query = "SELECT * FROM `tiers`  WHERE  `ID tiers`='" + comboBox3.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string id = rd.GetInt64(0).ToString();
                string t = rd.GetString(1);
                string id2 = rd.GetInt64(2).ToString();


                comboBox3.Text = id;
                textBox2.Text = t;
                comboBox2.Text = id2;

            } rd.Close();
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form16 f2 = new Form16();
            this.Hide();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string num = comboBox3.Text;

            if (num == "")
            {
                MessageBox.Show("Veuillez donner l'identifiant");
                return;
            }
            else
            {  //delete
                string query3 = "DELETE FROM `tiers` WHERE `ID tiers`='" + comboBox3.Text + "' ";
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
