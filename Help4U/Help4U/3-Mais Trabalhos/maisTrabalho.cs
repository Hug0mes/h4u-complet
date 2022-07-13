using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Help4U
{
    public partial class maisTrabalho : Form
    {
        public maisTrabalho()
        {
            InitializeComponent();
        }

     
        public static string IdTrabalhoAtual;

        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";


        private void maisTrabalho_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
            }

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(open.FileName);
            }

      
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(open.FileName);
            }
          
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = new Bitmap(open.FileName);
            }

        }


        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox5.Image = new Bitmap(open.FileName);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || maskedTextBox1.Text.Length == 0 || textBox6.Text.Length == 0 || comboBox1.SelectedIndex == 0)
            {
                label11.Visible = true;
            }
            else
            {


                //Guardar informação do trabalho
                string query = "INSERT INTO trabalho(`IdTrabalho`, `IdUser`, `Titulo`, `Data`, `Localização` , `Rua`, `Cod_postal`, `Tipo`, `Preço`, `Estado1`, `Descricao1`) VALUES (NULL, '" + Login.idlocal + "', '" + textBox1.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + comboBox1.GetItemText(comboBox1.SelectedItem) + "','" + textBox3.Text + "','" + maskedTextBox1.Text + "','" + comboBox2.GetItemText(comboBox2.SelectedItem) + "', '" + textBox2.Text + "', 'Ativo' , '" + textBox6.Text + "')";

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;

                try
                {
                    databaseConnection.Open();
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();


                    //MessageBox.Show("Trabalho inserido");

                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }


                //Guardar Id do trabalho a cima
                string query1 = "SELECT IdTrabalho FROM trabalho ORDER BY IdTrabalho DESC LIMIT 1;";
                MySqlDataAdapter sda = new MySqlDataAdapter(query1, connectionString);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);

                //ultimalinha
                MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                commandDatabase1.CommandTimeout = 60;
                MySqlDataReader reader;


                try
                {
                    databaseConnection1.Open();
                    reader = commandDatabase1.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            IdTrabalhoAtual = reader.GetString(0);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }

                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {

                    MemoryStream ms1 = new MemoryStream();
                    MemoryStream ms2 = new MemoryStream();
                    MemoryStream ms3 = new MemoryStream();
                    MemoryStream ms4 = new MemoryStream();
                    MemoryStream ms5 = new MemoryStream();


                    pictureBox1.Image.Save(ms1, ImageFormat.Png);
                    pictureBox2.Image.Save(ms2, ImageFormat.Png);
                    pictureBox3.Image.Save(ms3, ImageFormat.Png);
                    pictureBox4.Image.Save(ms4, ImageFormat.Png);
                    pictureBox5.Image.Save(ms5, ImageFormat.Png);

                    byte[] pic_arr1 = new byte[ms1.Length];
                    byte[] pic_arr2 = new byte[ms2.Length];
                    byte[] pic_arr3 = new byte[ms3.Length];
                    byte[] pic_arr4 = new byte[ms4.Length];
                    byte[] pic_arr5 = new byte[ms5.Length];

                    ms1.Position = 0;
                    ms2.Position = 0;
                    ms3.Position = 0;
                    ms4.Position = 0;
                    ms5.Position = 0;

                    ms1.Read(pic_arr1, 0, pic_arr1.Length);
                    ms2.Read(pic_arr2, 0, pic_arr2.Length);
                    ms3.Read(pic_arr3, 0, pic_arr3.Length);
                    ms4.Read(pic_arr4, 0, pic_arr4.Length);
                    ms5.Read(pic_arr5, 0, pic_arr5.Length);



                    databaseConnection.Open();
                    MySqlCommand cmd1 = new MySqlCommand("insert into trabalho_fotos(Id_Trabalho, Fotos, N_foto)values( '" + IdTrabalhoAtual + "',@img1, '1')", databaseConnection);
                    cmd1.Parameters.AddWithValue("@img1", pic_arr1);

                    MySqlCommand cmd2 = new MySqlCommand("insert into trabalho_fotos(Id_Trabalho, Fotos, N_foto)values( '" + IdTrabalhoAtual + "',@img2, '2')", databaseConnection);
                    cmd2.Parameters.AddWithValue("@img2", pic_arr2);

                    MySqlCommand cmd3 = new MySqlCommand("insert into trabalho_fotos(Id_Trabalho, Fotos, N_foto)values( '" + IdTrabalhoAtual + "',@img3, '3')", databaseConnection);
                    cmd3.Parameters.AddWithValue("@img3", pic_arr3);

                    MySqlCommand cmd4 = new MySqlCommand("insert into trabalho_fotos(Id_Trabalho, Fotos, N_foto)values( '" + IdTrabalhoAtual + "',@img4, '4')", databaseConnection);
                    cmd4.Parameters.AddWithValue("@img4", pic_arr4);

                    MySqlCommand cmd5 = new MySqlCommand("insert into trabalho_fotos(Id_Trabalho, Fotos, N_foto)values( '" + IdTrabalhoAtual + "',@img5, '5')", databaseConnection);
                    cmd5.Parameters.AddWithValue("@img5", pic_arr5);



                    int n1 = cmd1.ExecuteNonQuery();
                    int n2 = cmd2.ExecuteNonQuery();
                    int n3 = cmd3.ExecuteNonQuery();
                    int n4 = cmd4.ExecuteNonQuery();
                    int n5 = cmd5.ExecuteNonQuery();

                    databaseConnection.Close();


                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    maskedTextBox1.Clear();
                    textBox6.Clear();
                    comboBox1.Items.Clear();
                    comboBox2.Items.Clear();
                    dateTimePicker1.Text = string.Empty;
                    pictureBox1.Image = Properties.Resources.Noimage1;
                    pictureBox2.Image = Properties.Resources.Noimage1;
                    pictureBox3.Image = Properties.Resources.Noimage1;
                    pictureBox4.Image = Properties.Resources.Noimage1;
                    pictureBox5.Image = Properties.Resources.Noimage1;


                    MessageBox.Show("Trabalho insrerido");

                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }


            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
    }

