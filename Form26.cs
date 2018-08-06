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
    public partial class Form26 : Form
    {
        MySqlConnection connection;
        public Form26()
        {
            InitializeComponent();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            string query = "SELECT `ID agence` as Code_Agence,Count(*) as Nombre_Dossier FROM `sinistre`S INNER JOIN `Opération sur dossier` O ON S.`id sinistre` =O.`id sinistre` WHERE `ID type`=0 group by `ID agence`";
           MySqlCommand cmd = new MySqlCommand(query, connection);
           MySqlDataAdapter dp = new MySqlDataAdapter(cmd);
           DataTable dt = new DataTable("nb");
           dp.Fill(dt);
           dataGridView1.DataSource = dt.DefaultView;
           dp.Update(dt);
        }

       

         private void button5_Click(object sender, EventArgs e)
        {
            Form42 f42 = new Form42();
            this.Hide();
            f42.Show();
        }

        private void Form26_Load(object sender, EventArgs e)
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
                        comboBox1.Items.Add(rd.GetString(0));
                        comboBox4.Items.Add(rd.GetString(0));
                        comboBox6.Items.Add(rd.GetString(0));
                        comboBox8.Items.Add(rd.GetString(0));

                    } rd.Close();
                }
                {
                    string query2 = "SELECT * FROM `catégorie` ";
                    MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                    MySqlDataReader rd2 = cmd2.ExecuteReader();
                    while (rd2.Read())
                    {
                        comboBox5.Items.Add(rd2.GetString(0));
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
               
                connection.Close();

            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            string query = "SELECT `ID agence` as Code_Agence,Count(*) as Nombre_Dossier FROM `sinistre`S INNER JOIN `Opération sur dossier` O ON S.`id sinistre` =O.`id sinistre` WHERE `ID type`=45 and`ID Catégorie`='"+comboBox5.Text+"' group by `ID agence`";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter dp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable("nb");
            dp.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            dp.Update(dt);
        
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
         connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            string query = "SELECT `ID agence` as Code_Agence,Count(*) as Nombre_Dossier FROM `sinistre`S INNER JOIN `Opération sur dossier` O ON S.`id sinistre` =O.`id sinistre` WHERE `ID type`=92  group by `ID agence`";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter dp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable("nb");
            dp.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            dp.Update(dt);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            string query = "SELECT `ID agence` as Code_Agence,Count(*) as Nombre_Dossier FROM `sinistre`S INNER JOIN `Opération sur dossier` O ON S.`id sinistre` =O.`id sinistre` WHERE `ID type`=45 and `ID Branche`='"+comboBox7.Text+"' group by `ID agence`";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter dp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable("nb");
            dp.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            dp.Update(dt);
         
        
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            string query = "SELECT `ID agence` as Code_Agence,Count(*) as Nombre_Dossier FROM `sinistre`S INNER JOIN `Opération sur dossier` O ON S.`id sinistre` =O.`id sinistre` WHERE `ID type`=83 group by `ID agence`";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter dp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable("nb");
            dp.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            dp.Update(dt);
        
        }
        }
        
         
    }
        


        
   