using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Help4U
{
    public partial class TrabalhoHistorico : Form
    {
        public TrabalhoHistorico()
        {
            InitializeComponent();
        }
        int i;
     
        private void PedidosHistorico_Load(object sender, EventArgs e)
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select IdTrabalho, Titulo, Data, Localização, Rua, Cod_postal, Tipo, Preço, Estado1, Descricao1 from trabalho where IdUser  = '" + Login.idlocal + "' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

         

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            i = 3;

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select IdTrabalho, Titulo, Data, Localização, Rua, Cod_postal, Tipo, Preço, Estado1, Descricao1 from trabalho where IdUser  = '" + Login.idlocal + "' and Estado1 = 'Aceite' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;


            guna2Button4.Visible = true;
            guna2Button5.Visible = false;
            guna2Button6.Visible = false;
            guna2Button8.Visible = false;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            i = 2;
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "SELECT IdTrabalho, Titulo, Data, Localização, Rua, Cod_postal, Tipo, Preço, Estado1, QuemRealizou, Descricao1 from trabalho where IdUser = '" + Login.idlocal + "' and Estado1 = 'Pendente' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;


            guna2Button4.Visible = false;
            guna2Button5.Visible = true;
            guna2Button6.Visible = true;
            guna2Button8.Visible = false;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            i = 1;
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select IdTrabalho, Titulo, Data, Localização, Rua, Cod_postal, Tipo, Preço, Estado1, Descricao1 from trabalho where IdUser  = '"+ Login.idlocal +"' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

         
            guna2Button4.Visible = true;
            guna2Button5.Visible = false;
            guna2Button6.Visible = false;
            guna2Button8.Visible = false;
        } 

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            label3.Text = Convert.ToString(selectedRow.Cells["IdTrabalho"].Value);

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Delete from trabalho where IdTrabalho  = '" + label3.Text + "' ;";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);

            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;


            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
         
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
           i = 1;
           string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select IdTrabalho,IdUser,  Titulo, Data, Localização, Rua, Cod_postal, Tipo, Preço, Estado1, Descricao1 from trabalho where QuemRealizou  = '" + Login.idlocal + "' and Estado1 = 'Aceite' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;


            guna2Button4.Visible = false;
            guna2Button5.Visible = false;
            guna2Button6.Visible = false;
            guna2Button8.Visible = true;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Update trabalho Set Estado1 = 'Aceite' where IdTrabalho = '" + label3.Text + "' ;";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);

            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
             
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();


            i = 2;
            string query = "SELECT  IdTrabalho, Titulo, Data, Localização, Rua, Cod_postal, Tipo, Preço, Estado1, QuemRealizou, Descricao1 from trabalho where IdUser = '" + Login.idlocal + "' and Estado1 = 'Pendente' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;


            guna2Button4.Visible = false;
            guna2Button5.Visible = true;
            guna2Button6.Visible = true;
            guna2Button8.Visible = false;

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Update trabalho Set Estado1 = 'Ativo' where IdTrabalho = '" + label3.Text + "' ;";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);

            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();

            i = 1;
            string query = "Select IdTrabalho,IdUser,  Titulo, Data, Localização, Rua, Cod_postal, Tipo, Preço, Estado1, Descricao1 from trabalho where QuemRealizou  = '" + Login.idlocal + "' and Estado1 = 'Aceite' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;




        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Update trabalho Set Estado1 = 'Negado' where IdTrabalho = '" + label3.Text + "' ;";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);

            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            databaseConnection.Close();


            i = 2;
            string query = "SELECT  IdTrabalho, Titulo, Data, Localização, Rua, Cod_postal, Tipo, Preço, Estado1, QuemRealizou, Descricao1 from trabalho where IdUser = '" + Login.idlocal + "' and Estado1 = 'Pendente' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;


            guna2Button4.Visible = false;
            guna2Button5.Visible = true;
            guna2Button6.Visible = true;
            guna2Button8.Visible = false;

        }
    }
}
