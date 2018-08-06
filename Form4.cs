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
    public partial class Form4 : Form
    {
        MySqlConnection connection;
        public Form4()
        {
            InitializeComponent();

        }
        private void Form4_Load(object sender, EventArgs e)
        {
        connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            //open connection
            try
            {
                {
                    connection.Open();
                    string query = "SELECT * FROM `agence` ";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        comboBox2.Items.Add(rd.GetString(0));

                    } rd.Close();
                }
                {
                    string query1 = "SELECT * FROM `utilisateur` ";
                    MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                    MySqlDataReader rd1 = cmd1.ExecuteReader();
                    while (rd1.Read())
                    {
                        comboBox5.Items.Add(rd1.GetString(0));

                    } rd1.Close();
                }
                {
                    string query2 = "SELECT * FROM `catégorie` ";
                    MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                    MySqlDataReader rd2 = cmd2.ExecuteReader();
                    while (rd2.Read())
                    {
                        comboBox3.Items.Add(rd2.GetString(0));

                    } rd2.Close();

                }
                {
                    string query3 = "SELECT * FROM `branche` ";
                    MySqlCommand cmd3 = new MySqlCommand(query3, connection);
                    MySqlDataReader rd3 = cmd3.ExecuteReader();
                    while (rd3.Read())
                    {
                        comboBox7.Items.Add(rd3.GetString(0));

                    } rd3.Close();
                }
                {
                    string query4 = "SELECT * FROM `tiers` ";
                    MySqlCommand cmd4 = new MySqlCommand(query4, connection);
                    MySqlDataReader rd4 = cmd4.ExecuteReader();
                    while (rd4.Read())
                    {
                        comboBox4.Items.Add(rd4.GetString(0));

                    } rd4.Close();
                }
                {
                    string query5 = "SELECT * FROM `procédure` ";
                    MySqlCommand cmd5 = new MySqlCommand(query5, connection);
                    MySqlDataReader rd5 = cmd5.ExecuteReader();
                    while (rd5.Read())
                    {
                        comboBox6.Items.Add(rd5.GetString(0));

                    } rd5.Close();
                }
                connection.Close();

            }
            
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
           
        private void button2_Click_1(object sender, EventArgs e)
        {

            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            string id = textBox2.Text;
            string num = textBox1.Text;
            if (id == "" || num == "")
            {
                MessageBox.Show("veuillez remplir les champs");
            }
            else
            {
                try
                {
                    connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
                    connection.Open();
                    string query = "INSERT INTO `sinistre`( `ID sinistre`, `N°Sinstre`, `ID agence`, `ID utilisateur`, `date de sinistre`, `date d'ouverture dossier`, `date de règlement`, `Montant sinistre`, `Taux de responsabilité`, `ID Branche`, `ID Catégorie`, `ID procédure`, `ID tiers`) VALUES ('" + textBox2.Text + "','" + textBox1.Text + "','" + comboBox2.Text + "','" + comboBox5.Text + "','" + dateTimePicker2.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker3.Text + "','" + textBox4.Text + "','" + numericUpDown1.Text + "','" + comboBox7.Text + "','" + comboBox3.Text + "','" + comboBox6.Text + "','" + comboBox4.Text + "') ";
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

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

      
       
    }
}
