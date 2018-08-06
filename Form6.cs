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
    public partial class Form6 : Form
    {

        MySqlConnection connection;
     

        public Form6()
        {
            InitializeComponent();
           
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            //open connection
            try
            {
                connection.Open();

            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }

            }
           
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            string query = "SELECT * FROM `agence` ";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd.GetString(0));

            } rd.Close();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            //open connection
            try
            {
                connection.Open();
                if (comboBox1.Text == "")
                {
                    string query = "SELECT distinct * FROM `sinistre` s inner join `Opération sur dossier` o on s.`id sinistre` =o.`id sinistre`";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    MySqlDataAdapter dp = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable("sinistre");
                    dp.Fill(dt);
                    dataGridView1.DataSource = dt.DefaultView;
                    dp.Update(dt);
                }
                
                else
                {
                    string query = "SELECT * FROM `sinistre`where `ID agence`='" + comboBox1.Text + "' ";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    MySqlDataAdapter dp = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable("sinistre");
                    dp.Fill(dt);
                    dataGridView1.DataSource = dt.DefaultView;
                    dp.Update(dt);
                }

                
                
                connection.Close();


            }
            catch (MySqlException ex)
            {
                   MessageBox.Show(ex.Message);
               
            }
           
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
