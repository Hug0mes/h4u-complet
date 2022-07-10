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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.Visible = false;
       
            guna2TextBox1.Enabled = true;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Button1.Visible = true;
         
            guna2TextBox1.Enabled = false;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            definicoes_perfilPessoal f1 = new definicoes_perfilPessoal();
            f1.Show();
            this.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Button1.Visible = true;
         

            guna2TextBox1.Enabled = false;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
           

                if (i > 0 || j >0)
            {
                
                DialogResult dialogResult = MessageBox.Show("Realizou mudanças ao seu perfil", "Deseja guardar as alterações feiras? ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {


                    try
                    {

                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";


                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MemoryStream ms1 = new MemoryStream();
                guna2CirclePictureBox1.Image.Save(ms1, ImageFormat.Png);
                byte[] pic_arr1 = new byte[ms1.Length];
                ms1.Position = 0;
                ms1.Read(pic_arr1, 0, pic_arr1.Length);

                databaseConnection.Open();

                MySqlCommand cmd1 = new MySqlCommand("update userfotos set foto = @img1 where idUsers = '"+ Login.idlocal +"' ", databaseConnection);
                cmd1.Parameters.AddWithValue("@img1", pic_arr1);

                int n1 = cmd1.ExecuteNonQuery();

                databaseConnection.Close();


                        string query1 = "UPDATE users SET Interesses = ''  WHERE id = '" + Login.idlocal + "'";

                       

                        switch (j) {
                        case 11:

                                query1 = "UPDATE users SET Interesses = 'design' WHERE id = '" + Login.idlocal + "' ";

                                break;
                        case 12:

                                query1 = "UPDATE users SET Interesses = 'Escrita e tradução' WHERE id = '" + Login.idlocal + "' ";


                                break;
                        case 13:


                                query1 = "UPDATE users SET Interesses = 'Animação e vídeo' WHERE id = '" + Login.idlocal + "' ";

                                break;
                        case 14:

                                query1 = "UPDATE users SET Interesses = 'Áudio e musica' WHERE id = '" + Login.idlocal + "' ";


                                break;
                        case 15:

                                query1 = "UPDATE users SET Interesses = 'Tecnologia e Programação' WHERE id = '" + Login.idlocal + "' ";


                                break;
                        case 16:

                                query1 = "UPDATE users SET Interesses = 'Negocios' WHERE id = '" + Login.idlocal + "' ";


                                break;
                        case 17:

                                query1 = "UPDATE users SET Interesses = 'Estilo de Vida' WHERE id = '" + Login.idlocal + "' ";

                                break;
                    }


            

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
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }

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

                i = 1;
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
            pictureBox11.BorderStyle = BorderStyle.Fixed3D;
            pictureBox12.BorderStyle = BorderStyle.None;
            pictureBox13.BorderStyle = BorderStyle.None;
            pictureBox14.BorderStyle = BorderStyle.None;
            pictureBox15.BorderStyle = BorderStyle.None;
            pictureBox16.BorderStyle = BorderStyle.None;
            pictureBox17.BorderStyle = BorderStyle.None;
            i = 1;
            label4.Visible = true;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

            j = 12;
            pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox12.BorderStyle = BorderStyle.Fixed3D;
            pictureBox13.BorderStyle = BorderStyle.None;
            pictureBox14.BorderStyle = BorderStyle.None;
            pictureBox15.BorderStyle = BorderStyle.None;
            pictureBox16.BorderStyle = BorderStyle.None;
            pictureBox17.BorderStyle = BorderStyle.None;
            i = 1;
            label4.Visible = true;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

            j = 13;
            pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox12.BorderStyle = BorderStyle.None;
            pictureBox13.BorderStyle = BorderStyle.Fixed3D;
            pictureBox14.BorderStyle = BorderStyle.None;
            pictureBox15.BorderStyle = BorderStyle.None;
            pictureBox16.BorderStyle = BorderStyle.None;
            pictureBox17.BorderStyle = BorderStyle.None;
            i=1;
            label4.Visible = true;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

            j = 14;
            pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox12.BorderStyle = BorderStyle.None;
            pictureBox13.BorderStyle = BorderStyle.None;
            pictureBox14.BorderStyle = BorderStyle.Fixed3D;
            pictureBox15.BorderStyle = BorderStyle.None;
            pictureBox16.BorderStyle = BorderStyle.None;
            pictureBox17.BorderStyle = BorderStyle.None;
            i = 1;
            label4.Visible = true;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

            j = 15;
            pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox12.BorderStyle = BorderStyle.None;
            pictureBox13.BorderStyle = BorderStyle.None;
            pictureBox14.BorderStyle = BorderStyle.None;
            pictureBox15.BorderStyle = BorderStyle.Fixed3D;
            pictureBox16.BorderStyle = BorderStyle.None;
            pictureBox17.BorderStyle = BorderStyle.None;
            i = 1;
            label4.Visible = true;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

            j = 16;
            pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox12.BorderStyle = BorderStyle.None;
            pictureBox13.BorderStyle = BorderStyle.None;
            pictureBox14.BorderStyle = BorderStyle.None;
            pictureBox15.BorderStyle = BorderStyle.None;
            pictureBox16.BorderStyle = BorderStyle.Fixed3D;
            pictureBox17.BorderStyle = BorderStyle.None;
            i = 1;
            label4.Visible = true;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

            j = 17;
            pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox12.BorderStyle = BorderStyle.None;
            pictureBox13.BorderStyle = BorderStyle.None;
            pictureBox14.BorderStyle = BorderStyle.None;
            pictureBox15.BorderStyle = BorderStyle.None;
            pictureBox16.BorderStyle = BorderStyle.None;
            pictureBox17.BorderStyle = BorderStyle.Fixed3D;
            i = 1;
            label4.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";

            try
            {
                String query1 = "Select * from users Inner join userfotos on Id = IdUsers where Id = '" + Login.idlocal + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(query1, connectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                label1.Text = dt.Rows[0][3].ToString();

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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
