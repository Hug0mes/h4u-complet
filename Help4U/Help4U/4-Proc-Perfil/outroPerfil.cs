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
using MySql.Data.MySqlClient;

namespace Help4U
{
    public partial class outroPerfil : Form
    {
        public outroPerfil()
        {
            InitializeComponent();
        }

        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void outroPerfil_Load(object sender, EventArgs e)
        {

            try
            {
                String query1 = "Select * from users Inner join userfotos on Id = IdUsers where Id = '" + procPerfil.selectUser + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(query1, connectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                label1.Text = dt.Rows[0][3].ToString();
                label4.Text = dt.Rows[0][1].ToString();
                label9.Text = dt.Rows[0][8].ToString();
                label6.Text = dt.Rows[0][6].ToString();
                guna2TextBox1.Text = dt.Rows[0][12].ToString();
                label5.Text = dt.Rows[0][11].ToString();
                label8.Text = dt.Rows[0][4].ToString();
                label10.Text = dt.Rows[0][0].ToString();


                byte[] img = (byte[])dt.Rows[0][16];
                MemoryStream ms = new MemoryStream(img);
                guna2CirclePictureBox1.Image = Image.FromStream(ms);
                da.Dispose();

            }
            catch (Exception ex)
            {  // Show any error message.
                MessageBox.Show(ex.Message);
            }

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        FazerPedido fp = new FazerPedido();
            fp.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Denuncia dn = new Denuncia();
            dn.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
    }

