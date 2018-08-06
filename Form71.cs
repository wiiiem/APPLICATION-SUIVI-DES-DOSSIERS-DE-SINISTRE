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
    public partial class Form71 : Form
    {
        MySqlConnection connection;
        public Form71()
        {
            InitializeComponent();
        }

        private void Form71_Load(object sender, EventArgs e)
        {

            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            //open connection
            try
            {
                connection.Open();
                string query = "SELECT * FROM  `opération sur dossier`  where `id sinistre`='" + comboBox5.Text + "'and `ID`='" + comboBox4.Text + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string id = rd.GetString(0);
                    string d1 = rd.GetDateTime(1).ToString();
                    string d2 = rd.GetDateTime(2).ToString();
                    string uti = rd.GetString(3);
                    string c4 = rd.GetInt64(4).ToString();
                    string c5 = rd.GetInt64(5).ToString();
                    string id1 = rd.GetString(6);
                   
                    
                    comboBox4.Text = id;
                    comboBox5.Text = id1;
                    dateTimePicker1.Text = d2;
                    dateTimePicker2.Text = d1;
                    comboBox1.Text = c5;
                    comboBox2.Text = c4;
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
                {
                    string query1 = "SELECT * FROM `sinistre` ";
                    MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                    MySqlDataReader rd1 = cmd1.ExecuteReader();
                    while (rd1.Read())
                    {
                        comboBox5.Items.Add(rd1.GetString(0));

                    } rd1.Close();

                }
                {
                    string query1 = "SELECT * FROM `opération sur dossier`";
                    MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                    MySqlDataReader rd1 = cmd1.ExecuteReader();
                    while (rd1.Read())
                    {
                        comboBox4.Items.Add(rd1.GetString(0));

                    } rd1.Close();

                } connection.Close();



            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            //open connection
            //update 
            {
                string query1 = "UPDATE `opération sur dossier` SET `Date création opération`='" + dateTimePicker2.Text+ "',`Date opération`='" + dateTimePicker1.Text + "',`ID utilisateur`='" + comboBox3.Text + "',`ID gestionnaire`='" + comboBox2.Text + "',`Id type`='" + comboBox1.Text + "',`id sinistre`='" + comboBox5.Text + "' WHERE`ID`='" + comboBox4.Text + "'";
                connection.Open();
                MySqlCommand cmd1 = new MySqlCommand();
                cmd1.CommandText = query1;
                cmd1.Connection = connection;
                cmd1.ExecuteNonQuery();
                connection.Close();
            }
            MessageBox.Show("Modification terminée avec succèes");
            Form2 f3 = new Form2();
            this.Hide();
            f3.Show();
                
       }

        private void button3_Click(object sender, EventArgs e)
        {
            string num = comboBox1.Text;

            if (num == "")
            {
                MessageBox.Show("Veuillez donner l'identifiant");
                return;
            }
            else
            {  //delete
                string query3 = "DELETE FROM `opération sur dossier` WHERE `ID `='" + comboBox4.Text + "' ";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query3, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("suppression terminée");
                MessageBox.Show("Modification terminée avec succèes");
                Form2 f3 = new Form2();
                this.Hide();
                f3.Show();

            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            //open connection
            connection.Open();
            string query = "SELECT * FROM  `opération sur dossier`  where `id sinistre`='" + comboBox5.Text + "'and `ID`='" + comboBox4.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string id = rd.GetString(0);
                string d1 = rd.GetDateTime(1).ToString();
                string d2 = rd.GetDateTime(2).ToString();
                string uti = rd.GetString(3);
                string c4 = rd.GetInt64(4).ToString();
                string c5 = rd.GetInt64(5).ToString();
                string id1 = rd.GetString(6);


                comboBox4.Text = id;
                comboBox5.Text = id1;
                dateTimePicker1.Text = d2;
                dateTimePicker2.Text = d1;
                comboBox1.Text = c5;
                comboBox2.Text = c4;
                comboBox3.Text = uti;


            } rd.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modification terminée avec succèes");
            Form2 f3 = new Form2();
            this.Hide();
            f3.Show();
        }

}
}
