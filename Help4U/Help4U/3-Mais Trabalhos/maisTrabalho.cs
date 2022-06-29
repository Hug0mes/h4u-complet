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
    public partial class maisTrabalho : Form
    {
        public maisTrabalho()
        {
            InitializeComponent();
        }

        public static string idlocal = "11";
        public static string IdTrabalhoAtual;
        public static int lastrow;

        private void maisTrabalho_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

            //Guardar informação do trabalho
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "INSERT INTO trabalho(`IdTrabalho`, `IdUser`, `Titulo`, `Data`, `Localização`, `Tipo`, `Preço`, `Estado`, `Descricao`) VALUES (NULL, '" + idlocal + "', '" + textBox1.Text + "', '" + dateTimePicker1.Text + "','" + comboBox1.SelectedText + "','" + comboBox2.SelectedText + "', '" + textBox2.Text + "', 'Ativo' , '" + textBox6.Text + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            //Guardar Id do trabalho a cima
            string query1 = "Select IdTrabalho from trabalho";
            MySqlDataAdapter sda = new MySqlDataAdapter(query1, connectionString);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            lastrow = dataTable.Rows.Count;



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(open.FileName);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(open.FileName);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = new Bitmap(open.FileName);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox5.Image = new Bitmap(open.FileName);
            }
        }

        }
}
