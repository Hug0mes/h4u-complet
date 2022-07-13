using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Help4U
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        bool mover = false;
        Point Pinicial;
        public static string idlocal;
        string estd;

        // Minimizar
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Abrir Insta 
       private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "https://www.instagram.com/help4u.official/");
        }

        //Abrir Email
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // help4u.604@gmail.com  
        }

        //Abrir Principal
        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text.Length == 0 || guna2TextBox2.Text.Length == 0)
            {
                label1.Visible = true;
            }

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select * from users where Email = '" + guna2TextBox1.Text.Trim() + "' and Password = '" + guna2TextBox2.Text.Trim() + "'";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);


            if (dataTable.Rows.Count >= 1)
            {
                //guardar id do utilizador currente
                foreach (DataRow row in dataTable.Rows)
                {
                    idlocal = row["Id"].ToString();
                     estd = row[8].ToString();

                }


                //adicionar foto de perfil caso não tenha
                string query1 = "Select * from userfotos where IdUsers = '" + idlocal + "'";
                MySqlDataAdapter sda1 = new MySqlDataAdapter(query1, connectionString);
                DataTable dataTable1 = new DataTable();
                sda1.Fill(dataTable1);

                if (dataTable1.Rows.Count < 1)
                {
           
                    

                    string query2 = "INSERT INTO userfotos(`IdUsers`, `Foto`) VALUES ('" + idlocal + "', LOAD_FILE('C:/Users/2005h/Desktop/Git_Projects/h4u-complet/Help4U/Help4U/Resources/user.png') )";

                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query2, databaseConnection);
                    commandDatabase.CommandTimeout = 60;



                    try
                    {
                        databaseConnection.Open();
                        MySqlDataReader myReader = commandDatabase.ExecuteReader();
                        databaseConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        // Show any error message.
                        MessageBox.Show(ex.Message);
                    }

                }

                if (estd == "banido")
                {
                    MessageBox.Show("Voçe foi banido!!");

                }
                else
                {
                    Principal principal = new Principal();
                    principal.Show();
                    this.Visible = false;
                }
              
            }
            else
            {
                label1.Visible = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2TextBox2.PasswordChar = '●';

        }
        
        //Mover Form
        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            mover = true;
            Pinicial = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                Point novo = PointToScreen(e.Location);
                Location = new Point(novo.X - this.Pinicial.X, novo.Y - this.Pinicial.Y);
            }
        }

        private void panel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            mover = false;
        }

        private void guna2TextBox1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void guna2TextBox2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://127.0.0.1:5501/public/Register.html");
        }
    }
}
