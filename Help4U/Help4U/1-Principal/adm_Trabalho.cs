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
    public partial class adm_Trabalho : Form
    {
        public adm_Trabalho()
        {
            InitializeComponent();
        }

        int j;


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            j = 1;
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "SELECT Id, Email, Nome, Genero, Dtn, Regiao, Adm, Estado,Morada,Codigo_Postal,Interesses, Descricao FROM users;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

            guna2Button16.Visible = true;
            guna2Button6.Visible = true;
            guna2Button2.Visible =true;
            guna2Button7.Visible = false;
            guna2Button8.Visible = true;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            j = 2;
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select IdTrabalho,IdUser, Titulo, Data, Localização, Rua, Cod_postal, Tipo, Preço, Estado1,QuemRealizou, Descricao1 from trabalho ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

            guna2Button16.Visible = false;
            guna2Button6.Visible = false;
            guna2Button2.Visible = false;
            guna2Button7.Visible = false;
            guna2Button8.Visible = false;

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            j = 3;

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select * from pedido";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

            guna2Button16.Visible = false;
            guna2Button6.Visible = false;
            guna2Button2.Visible = false;
            guna2Button7.Visible = false;
            guna2Button8.Visible = false;


        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            label2.Text = "";

            j = 4;

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select * from denuncia";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

            guna2Button16.Visible = false;
            guna2Button6.Visible = false;
            guna2Button2.Visible = false;
            guna2Button7.Visible = true;
            guna2Button8.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            label2.Text = Convert.ToString(selectedRow.Cells[0].Value);
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Update users Set `Adm` = '1' where Id = '"+ label2.Text +"' ;";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);

            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;


            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Update users Set `Adm` = '0' where Id = '" + label2.Text + "' ;";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);

            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;


            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Update denuncia Set `Estado` = 'Resolvida' where IdDenuncia = '" + label2.Text + "' ;";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);

            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;


            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();

        
        }

        private void adm_Trabalho_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Update users Set `Estado` = 'banido' where Id = '" + label2.Text + "' ;";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);

            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;


            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Update users Set `Estado` = 'inativo' where Id = '" + label2.Text + "' ;";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);

            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;


            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();
        }
    }
}
