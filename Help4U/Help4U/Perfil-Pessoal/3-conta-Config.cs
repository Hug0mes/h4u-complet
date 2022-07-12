using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace Help4U
{
    public partial class Conta_Config : Form
    {
        public Conta_Config()
        {
            InitializeComponent();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            perfil perfil = new perfil();
            perfil.Show();
            this.Close();
        }

        private void Conta_Config_Load(object sender, EventArgs e)
        {

            try
            {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";

                String query1 = "Select * from users where Id = '" + Login.idlocal + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(query1, connectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);


                string estadooo = dt.Rows[0][8].ToString();

                if (estadooo == "Disponível")
                {
                    checkBox1.Checked = true;
                }else if (estadooo == "inativo")
                {
                    checkBox3.Checked = true;
                }
                else
                {

                }

                label1.Text = dt.Rows[0][3].ToString();

            }
            catch (Exception ex)
            {  // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
           if (checkBox3.Checked)
            {
                checkBox1.Checked = false;

            }
            try
            {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                string query1 = "UPDATE users SET Estado = 'inativo' WHERE id = '" + Login.idlocal + "' ";

                MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();




            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }




        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox3.Checked = false;

            }


            try
            {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                string query1 = "UPDATE users SET Estado = 'Disponível' WHERE id = '" + Login.idlocal + "' ";

                MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;


                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();




            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

             string pass = Interaction.InputBox("Insira a sua password ", "Esta ação é irreversível!", "", -1, -1);

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select * from users where Id = '" + Login.idlocal + "' and Password = '" + pass  + "'";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            if (dataTable.Rows.Count >= 1)
            {
                string query1 = "Delete from users where Id = '" + Login.idlocal + "' ";


                MySqlConnection databaseConnection = new MySqlConnection(connectionString);

                MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();



                Login login = new Login();
                Conta_Config conta_Config = new Conta_Config();
                definicoes_perfilPessoal df = new definicoes_perfilPessoal();




                Application.Exit();

            }
            else
            {
                MessageBox.Show("Password incorreta");
            }
        }
    }
}
