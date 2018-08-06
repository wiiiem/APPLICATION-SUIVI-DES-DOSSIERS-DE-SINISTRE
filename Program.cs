using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MySqlConnection connection;
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
            //requete insert
            /*{
                string query = "INSERT INTO `agence`(`ID agence`, `nom_chef d'agence`, `Code_agence`, `ID délégation`) VALUES (A1,[Imed],[128],[Tunis]))";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("insertion terminée");
                Console.ReadLine();
            }
           */
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
