﻿using System;
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
    public partial class Form64 : Form
    {
        MySqlConnection connection;
        public Form64()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string query1 = "UPDATE `tiers` SET `Nom tiers`='" + textBox1.Text + "',`ID bénéficiaire`='" + comboBox2.Text + "' WHERE `ID tiers`='" + comboBox1.Text + "'";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            string query = "SELECT * FROM `tiers`  WHERE  `ID tiers`='" + comboBox1.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string id = rd.GetInt64(0).ToString();
                string t = rd.GetString(1);
                string id2 = rd.GetInt64(2).ToString();


                comboBox1.Text = id;
                textBox1.Text = t;
                comboBox2.Text = id2;

            } rd.Close();
            connection.Close();
        }

        private void Form64_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(@"Database=data_base;Data Source=localhost;User Id=root;Password=");
            try
            {
                connection.Open();
                string query = "SELECT * FROM `tiers` ";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(rd.GetString(0));
                    comboBox2.Items.Add(rd.GetString(2));

                } rd.Close();

                connection.Close();
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form16 f2 = new Form16();
            this.Hide();
            f2.Show();
        }
    }
}
