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
    public partial class Form23 : Form
    {
        MySqlConnection connection;
        
        public Form23()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            //open connection
            try
            {
                connection.Open();
                string query = "SELECT * FROM `gestionnaire`";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter dp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("gest");
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

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }
    }
}
