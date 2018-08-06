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
    public partial class Form28 : Form
    {
          MySqlConnection connection;
        public Form28()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
                    string query1 = "UPDATE `agence` SET `nom_chef d'agence`='"+ textBox1.Text +"',`Code_agence`='" + textBox3.Text + "',`ID délégation`='" + comboBox2.Text + "'WHERE `ID agence`='" + comboBox1.Text + "'";
                    connection.Open();
                    MySqlCommand cmd1 = new MySqlCommand();
                    cmd1.CommandText = query1;
                    cmd1.Connection = connection;
                    cmd1.ExecuteNonQuery();
                    connection.Close();
                MessageBox.Show("Modification terminée avec succèes");
                Form16 f2 = new Form16();
                this.Hide();
                f2.Show();

            
                }


        private void button2_Click(object sender, EventArgs e)
        {
            Form16 f2 = new Form16();
            this.Hide();
            f2.Show();
        }
           
       
             private void Form28_Load_1(object sender, EventArgs e)
        {
 connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password="); 
            try
            {

                {
                    connection.Open();
                    string query = "SELECT * FROM `agence` ";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        comboBox2.Items.Add(rd.GetString(3));
                        comboBox1.Items.Add(rd.GetString(0));


                    } rd.Close();
                    connection.Close();
                }
  }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
               
       }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            connection.Open();
            string query = "SELECT * FROM `agence`where `ID agence`='" + comboBox1.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string id = rd.GetInt64(0).ToString();
                string nom = rd.GetString(1);
                string pr = rd.GetInt64(2).ToString();
                string c2 = rd.GetInt64(3).ToString();

                comboBox1.Text = id;
                textBox1.Text = nom;
                textBox3.Text = pr;
                comboBox2.Text = c2;
            } rd.Close();
            connection.Close();

        }

    
       
             }
    }

