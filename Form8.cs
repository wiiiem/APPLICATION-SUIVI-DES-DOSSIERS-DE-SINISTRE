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
    public partial class Form8 : Form
    {
        MySqlConnection connection;
        public Form8()
        {
            InitializeComponent();
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            //open connection
            try
            {
                connection.Open();
                string query = "SELECT * FROM `sinistre` ";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string id = rd.GetString(0);
                    string num = rd.GetDouble(1).ToString();
                    string ag = rd.GetInt64(2).ToString();
                    string uti = rd.GetString(3);
                    string d1 = rd.GetDateTime(4).ToString();
                    string d2 = rd.GetDateTime(5).ToString(); 
                    string d3 = rd.GetDateTime(6).ToString();
                    string mt = rd.GetFloat(7).ToString();
                    decimal tx = Convert.ToDecimal(rd[8]);
                    string c2 = rd.GetInt64(9).ToString(); 
                    string c3 = rd.GetInt64(10).ToString(); 
                    string c4 = rd.GetInt64(11).ToString();
                    string c5 = rd.GetInt64(12).ToString();
                    

                    textBox2.Text = id;
                    textBox1.Text = num;
                    numericUpDown1.Value= tx;
                    dateTimePicker1.Text = d2;
                    dateTimePicker2.Text = d1;
                    dateTimePicker3.Text = d3;
                    comboBox2.Text = ag;
                    comboBox5.Text = uti; 
                    comboBox3.Text = c3;
                    comboBox7.Text = c2;
                    comboBox4.Text = c5;
                    comboBox6.Text = c4;
                    comboBox2.Text = ag;
                    textBox4.Text = mt;
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
   private void button1_Click(object sender, EventArgs e)
        {
            //update 
            {
                string query1 = "UPDATE `sinistre` SET `ID agence`='" + comboBox2.Text + "',`ID utilisateur`='" + comboBox5.Text + "',`date de sinistre`='" + dateTimePicker2.Text+ "',`date d'ouverture dossier`='" + dateTimePicker1.Text + "',`date de règlement`='"+ dateTimePicker3.Text + "',`Montant sinistre`='" + textBox4.Text + "',`Taux de responsabilité`='" + numericUpDown1.Value+ "',`ID Branche`='" + comboBox7.Text + "',`ID Catégorie`='" + comboBox3.Text + "',`ID procédure`='" + comboBox6.Text + "',`ID tiers`='" + comboBox4.Text + "' WHERE `ID sinistre`='" + textBox2.Text + "' ";
                connection.Open();
                MySqlCommand cmd1 = new MySqlCommand();
                cmd1.CommandText = query1;
                cmd1.Connection = connection;
                cmd1.ExecuteNonQuery();
                connection.Close();
            }


            MessageBox.Show("Modification terminée avec succèes");
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 f13 = new Form13(textBox1.Text);
            f13.Show();
        }

       
    }
}
