using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Help4U
{
    public partial class InfoTrabalho : Form
    {
        public InfoTrabalho()
        {
            InitializeComponent();
        }

        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";


        private void InfoTrabalho_Load(object sender, EventArgs e)
        {
            try
            {
                String query1 = "Select * from trabalho Inner join trabalho_fotos on IdTrabalho = Id_Trabalho INNER JOIN users ON IdUser = Id INNER JOIN userfotos ON id = IdUsers where IdTrabalho = '" + trabalho.selectwork +"' ";
                MySqlDataAdapter da = new MySqlDataAdapter(query1, connectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);


                label2.Text = dt.Rows[0][2].ToString();
                label3.Text = dt.Rows[0][18].ToString();
                label4.Text = dt.Rows[0][16].ToString();
                label16.Text = dt.Rows[0][7].ToString();
                label12.Text = dt.Rows[0][3].ToString();
                label13.Text = dt.Rows[0][4].ToString();
                label14.Text = dt.Rows[0][5].ToString();
                label15.Text = dt.Rows[0][6].ToString();
                label16.Text = dt.Rows[0][7].ToString();
                label17.Text = dt.Rows[0][8].ToString();
                textBox1.Text = dt.Rows[0][11].ToString();



                byte[] img = (byte[])dt.Rows[0][31];
                MemoryStream ms = new MemoryStream(img);
                guna2CirclePictureBox1.Image = Image.FromStream(ms);
                

                byte[] img1 = (byte[])dt.Rows[0][13];
                MemoryStream ms1 = new MemoryStream(img1);
                guna2PictureBox1.Image = Image.FromStream(ms1);

                byte[] img2 = (byte[])dt.Rows[1][13];
                MemoryStream ms2 = new MemoryStream(img2);
                guna2PictureBox2.Image = Image.FromStream(ms2);

                byte[] img3 = (byte[])dt.Rows[2][13];
                MemoryStream ms3 = new MemoryStream(img3);
                guna2PictureBox3.Image = Image.FromStream(ms3);

                byte[] img4 = (byte[])dt.Rows[3][13];
                MemoryStream ms4 = new MemoryStream(img4);
                guna2PictureBox4.Image = Image.FromStream(ms4);

                byte[] img5 = (byte[])dt.Rows[4][13];
                MemoryStream ms5 = new MemoryStream(img5);
                guna2PictureBox5.Image = Image.FromStream(ms5);


            }
            catch (Exception ex)
            {  // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show(" Quer realizar este trabalho? ",
              " Tem certeza que... ",
              MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
              
                string query = "Update `trabalho` SET `Estado1`= 'Pendente' , `QuemRealizou` = '" + Login.idlocal + "' where IdTrabalho =  '" + trabalho.selectwork + "'  ";

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;

                try
                {
                    databaseConnection.Open();
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();

                    this.Close();
                    //MessageBox.Show("Trabalho inserido");

                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }


            }
        }
    }
}
