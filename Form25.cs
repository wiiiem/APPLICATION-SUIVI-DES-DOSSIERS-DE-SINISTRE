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
    public partial class Form25 : Form
    {
        MySqlConnection connection;
        public Form25()
        {
            InitializeComponent();
        }

       
       
        private void Form25_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            try
            {
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
                
                string nom = rd.GetString(1);
                string pr = rd.GetString(2);
                string mat = rd.GetString(3);
                
                string c2 = rd.GetInt64(0).ToString();

               
                textBox1.Text = nom;
                textBox3.Text = pr;
                textBox4.Text = mat;
                comboBox1.Text = c2;
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

        private void button1_Click_1(object sender, EventArgs e)
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
                //delete
                string query3 = "DELETE FROM `gestionnaire` WHERE `ID gestionnaire`='" + comboBox1.Text + "' ";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query3, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("suppression terminée");
                Form2 f2 = new Form2();
                this.Hide();
                f2.Show();

            }
            else
                MessageBox.Show(" Vérifiez L'identifiant ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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
                string log = rd.GetString(3);
               
                

                comboBox1.Text = c2;
                textBox1.Text = nom;
                textBox3.Text = pr;
                textBox4.Text = log;
                              
            } rd.Close();
        }

        
      
     
       

      
    }
}
