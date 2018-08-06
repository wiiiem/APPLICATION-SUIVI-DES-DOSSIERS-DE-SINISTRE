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
    public partial class Form13 : Form
    {
        MySqlConnection connection;
        public Form13(string value)
        {
            InitializeComponent();
            textBox2.Text=value  ;
        }
        private void Form13_Load(object sender, EventArgs e)
        {
           
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            //open connection
            try
            {
                connection.Open();
                string query = "SELECT * FROM `sinistre` where `N°Sinstre`='"+textBox2.Text+"'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string id = rd.GetString(0);
                    string uti = rd.GetString(3);

                    textBox3.Text = id;
                    comboBox3.Text = uti;
                   
                } rd.Close();
                connection.Close();


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            try
            {
                {
                    connection.Open();
                    string query = "SELECT * FROM `type_opération` ";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        comboBox1.Items.Add(rd.GetString(0));

                    } rd.Close();
                }
                {
                    string query1 = "SELECT * FROM `utilisateur` ";
                    MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                    MySqlDataReader rd1 = cmd1.ExecuteReader();
                    while (rd1.Read())
                    {
                        comboBox3.Items.Add(rd1.GetString(0));

                    } rd1.Close();
                }
                {
                    string query2 = "SELECT * FROM `gestionnaire` ";
                    MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                    MySqlDataReader rd2 = cmd2.ExecuteReader();
                    while (rd2.Read())
                    {
                        comboBox2.Items.Add(rd2.GetString(0));

                    } rd2.Close();

                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f3 = new Form2();
            this.Hide();
            f3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            if (id == "")
            {
                MessageBox.Show("veuillez remplir les champs");
            }
            else
            {
                try
                {
                    connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
                    connection.Open();
                    string query = " INSERT INTO `opération sur dossier`(`ID`, `Date création opération`, `Date opération`, `ID utilisateur`, `ID gestionnaire`, `Id type`, `id sinistre`) VALUES  ('" + textBox1.Text + "','" + dateTimePicker2.Value + "','" + dateTimePicker1.Value + "','" + comboBox3.Text + "','" + comboBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "' )";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Opération Enregistrée");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);

                }


            }



        }

       
    }
}