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
    public partial class PedidosHistorico : Form
    {
        public PedidosHistorico()
        {
            InitializeComponent();
        }
        int trabalhoId;

        private void PedidosHistorico_Load(object sender, EventArgs e)
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select IdTrabalho, Titulo, Data, Localização, Rua, Cod_postal, Tipo, Preço, Estado, Descricao from trabalho where IdUser  = '" + Login.idlocal + "' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

            label3.Text = trabalhoId.ToString();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select IdTrabalho, Titulo, Data, Localização, Rua, Cod_postal, Tipo, Preço, Estado, Descricao from trabalho where IdUser  = '"+ Login.idlocal +"' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

         
            guna2Button4.Visible = true;
            guna2Button5.Visible = false;
            guna2Button6.Visible = false;
      
        } 

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            label3.Text = Convert.ToString(selectedRow.Cells["IdTrabalho"].Value);

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            label3.Text = Convert.ToString(selectedRow.Cells["IdTrabalho"].Value);

        }
    }
}
