using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Help4U
{
    public partial class perfil : Form
    {
        public perfil()
        {
            InitializeComponent();
        }

        int i = 0;
        int j = 0;
        int x = 0;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
         
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
         
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            definicoes_perfilPessoal f1 = new definicoes_perfilPessoal();
            f1.Show();
            this.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
         
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
          
            Principal principal = new Principal();
            principal.Show();
            this.Close();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
               guna2CirclePictureBox1.Image = new Bitmap(open.FileName);

                x = 1;
                label4.Visible = true;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            i = 1;
            label4.Visible = true;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

            j = 11;
           
            i = 1;
            label4.Visible = true;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

            j = 12;
         
            i = 1;
            label4.Visible = true;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

            j = 13;
           
            label4.Visible = true;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

            j = 14;
       
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);


            string query1 = "UPDATE users SET Interesses = '"+ comboBox2.SelectedItem.ToString() +"'  WHERE id = '" + Login.idlocal + "'";

            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;


            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();

            databaseConnection.Close();

        }
    catch (Exception ex)
                {
                    // Ops, maybe the id doesn't exists ?
                    MessageBox.Show(ex.Message);
                }

}

        private void perfil_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";

            try
            {
                String query1 = "Select * from users Inner join userfotos on Id = IdUsers where Id = '" + Login.idlocal + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(query1, connectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                label10.Text = dt.Rows[0][0].ToString();
                label7.Text = dt.Rows[0][1].ToString();
                label6.Text = dt.Rows[0][6].ToString();
                label1.Text = dt.Rows[0][3].ToString();
                label9.Text = dt.Rows[0][8].ToString();

                comboBox2.Text = dt.Rows[0][11].ToString();
                textBox1.Text = dt.Rows[0][12].ToString();


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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {

                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);


                string query1 = "UPDATE users SET Descricao = '" + textBox1.Text + "'  WHERE id = '" + Login.idlocal + "'";

                MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;


                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                databaseConnection.Close();

            }
            catch (Exception ex)
            {  // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }
        }
}
