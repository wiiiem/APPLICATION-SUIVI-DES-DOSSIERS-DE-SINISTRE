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
    public partial class Form7 : Form
    {
        MySqlConnection connection;
        public Form7()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            //open connection
            try
            {
                connection.Open();
                string query = "SELECT * FROM `sinistre` where `N°Sinstre`='"+textBox1.Text+"' ";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter dp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("sinistre");
                dp.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                dp.Update(dt);
                connection.Close();


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["N° sinistre"].Value.ToString();   

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            this.Hide();
            f8.Show();
            
        }
        private bool checklogin(string r)
        {

            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            string query = "SELECT * FROM `sinistre` where `N°Sinstre`=@num";
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

        private void button3_Click(object sender, EventArgs e)
        {
            string num = textBox1.Text;

            if (num == "")
            {
                MessageBox.Show(" Veuillez donner le numéro du sinistre ");
                return;
            }
             bool r = checklogin(num);

            if (r)
            {
           
             //delete
                string query3 = "DELETE FROM `sinistre` WHERE `N°Sinstre`=@num ";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query3, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("suppression terminée");
                Form3 f3 = new Form3();
                this.Hide();
                f3.Show();
            }
             else
                MessageBox.Show(" Vérifiez Le numéro du sinistre ");
            
        }
            
        
    }
}
