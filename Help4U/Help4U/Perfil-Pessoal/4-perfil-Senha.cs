using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Help4U
{
    public partial class perfil_Senha : Form
    {
        public perfil_Senha()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {




            if (guna2TextBox2.Text != guna2TextBox3.Text)
            {
                label9.Visible = true;
            }
            else
            {
                label9.Visible = false;

                try
                {



                    //verificar de a password está correta
                    string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
                    string query = "Select * from users where Id = '" + Login.idlocal + "' and Password = '" + guna2TextBox1.Text + "'";

                    MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
                    DataTable dataTable = new DataTable();
                    sda.Fill(dataTable);


                    if (dataTable.Rows.Count >= 1)
                    {
                        //atualizar password
                        string query1 = "Update users Set `Password` = '" + guna2TextBox3.Text + "' where Id = '" + Login.idlocal + "' ;";


                        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                        MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);

                        commandDatabase.CommandTimeout = 60;
                        MySqlDataReader reader;


                        databaseConnection.Open();
                        reader = commandDatabase.ExecuteReader();
                        databaseConnection.Close();

                    }
                    else
                    {
                        label8.Visible = true;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //Salvar na BD 

                
                guna2TextBox1.Clear();
                guna2TextBox2.Clear();
                guna2TextBox3.Clear();
                label9.Visible = false;
                label8.Visible = false;
                MessageBox.Show("Palavra-passe alterada :)");
            }
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            perfil perfil = new perfil();
            perfil.Show();
            this.Close();   
        }

        private void perfil_Senha_Load(object sender, EventArgs e)
        {
            guna2TextBox1.PasswordChar = '●';
            guna2TextBox2.PasswordChar = '●';
            guna2TextBox3.PasswordChar = '●';
        }

       

        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
          
        }
    }
}

