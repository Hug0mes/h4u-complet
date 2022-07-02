using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;


namespace Help4U
{
    public partial class Principal : Form
    { 
        public Principal()
        {
            InitializeComponent();
        }

        MySqlConnection connectionString = new MySqlConnection("datasource = 127.0.0.1; port = 3306; username = root; password =; database = h4u;");
 


        public void loadform(object Form)
        {

         


            //databaseConnection.Open();
            //SqlCommand cmd = new SqlCommand("Select * from users Inner join userfotos on Id = IdUsers where Id = '" + Login.idlocal + "';", databaseConnection);
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //    string image = Convert.ToString(DateTime.Now.ToFileTime());
            //    byte[] bimage = (byte[])dr["Foto"];
            //    FileStream fs = new FileStream(image, FileMode.CreateNew, FileAccess.Write);
            //    fs.Write(bimage, 0, bimage.Length - 1);
            //    fs.Close();
            //    guna2CirclePictureBox2.Image = Image.FromFile(image);
            //}
            //dr.Close();
            //databaseConnection.Close();





            if (this.panel2.Controls.Count > 0)
                this.panel2.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(f);
            this.panel2.Tag = f;
            f.Show();



        }

        //Abas
        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            perfil perfil = new perfil();
            perfil.Show();
            this.Visible = false;
        }

        private void guna2PictureBox2_Click_1(object sender, EventArgs e)
        {
            //Top Ranking
            panel3.Visible = false;
            loadform(new top1());
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            loadform(new trabalho());
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            loadform(new procPerfil());
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            loadform(new maisTrabalho());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Visible = true;
            this.Close();
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();

            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {

            //imagem de Perfil
            try
            {
            String query1 = "Select * from users Inner join userfotos on Id = IdUsers where Id = '" +  Login.idlocal + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(query1, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
           
            label1.Text = dt.Rows[0][3].ToString();
            byte[] img = (byte[])dt.Rows[0][14];
            MemoryStream ms = new MemoryStream(img);
            guna2CirclePictureBox2.Image = Image.FromStream(ms);
            da.Dispose();

            }
            catch (Exception ex)
            {  // Show any error message.
                MessageBox.Show(ex.Message);}

        }
    }
}
