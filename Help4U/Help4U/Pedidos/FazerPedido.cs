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
    public partial class FazerPedido : Form
    {
        public FazerPedido()
        {
            InitializeComponent();
        }

        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";

        public static string  idPedidoAtual;

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        



                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || maskedTextBox1.Text.Length == 0 || textBox6.Text.Length == 0 || comboBox1.SelectedIndex == 0)
                {
                    label2.Visible = true;
                }
                else
                {


                    //Guardar informação do trabalho
                    string query = "INSERT INTO pedido( `IdUser1`,`IdUser2`, `Titulo`, `Data`, `Localização` , `Rua`, `Cod_postal`, `Tipo`, `Estado2`, `Descricao2`, `Preco` ) VALUES ( '" + Login.idlocal
                    + "', '" + procPerfil.selectUser + "', '" + textBox1.Text + "' ,'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + comboBox1.GetItemText(comboBox1.SelectedItem) + "','" + textBox3.Text 
                    + "','" + maskedTextBox1.Text + "','" + comboBox2.GetItemText(comboBox2.SelectedItem) + "', 'Pendente' , '" + textBox6.Text + "', '" + textBox2.Text + "')";

                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.CommandTimeout = 60;

                try
                {
                    databaseConnection.Open();
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();


                    MessageBox.Show("Trabalho inserido");

                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }


                //Guardar Id do trabalho a cima
                string query1 = "SELECT IdPedido FROM pedido ORDER BY IdPedido DESC LIMIT 1;";
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
                                idPedidoAtual = reader.GetString(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Não foram encontradas Colunas");
                        }

                        databaseConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                MessageBox.Show("Pedido enviado");
                this.Close();

            }
        }

        private void FazerPedido_Load(object sender, EventArgs e)
        {
            try
            {
                String query1 = "Select * from users where Id = '" + procPerfil.selectUser + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(query1, connectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                label1.Text = dt.Rows[0][3].ToString();
         
                da.Dispose();

            }
            catch (Exception ex)
            {  // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ControlBox2_Click_1(object sender, EventArgs e)
        {

        }
    }
}