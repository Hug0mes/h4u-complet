using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Help4U
{
    public partial class Perfil_Config : Form
    {
        public Perfil_Config()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           panel1.Visible = false;
           panel3.Visible = true;
           panel4.Visible = false;

            comboBox1.Items.Add("Masculino");
            comboBox1.Items.Add("Feminino");
            comboBox1.Items.Add("Outro...");

            comboBox2.Items.Add("Aveiro");
            comboBox2.Items.Add("Beja");
            comboBox2.Items.Add("Braga");
            comboBox2.Items.Add("Bragança");
            comboBox2.Items.Add("Castelo Branco");
            comboBox2.Items.Add("Coimbra");
            comboBox2.Items.Add("Faro");
            comboBox2.Items.Add("Guarda");
            comboBox2.Items.Add("Leiria");
            comboBox2.Items.Add("Lisboa");
            comboBox2.Items.Add("Portalegre");
            comboBox2.Items.Add("Porto");
            comboBox2.Items.Add("Santarém");
            comboBox2.Items.Add("Setúbal");
            comboBox2.Items.Add("Viana do Castelo");
            comboBox2.Items.Add("Vila Real");
            comboBox2.Items.Add("Viseu");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel1.Visible = true;
            panel4.Visible = true;

            guna2TextBox2.Clear();
           
            guna2TextBox4.Clear();
            guna2TextBox1.Clear();
            
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            maskedTextBox1.Clear();
            
        }

        private void Perfil_Config_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";

            try
            {
                String query1 = "Select * from users where Id = '" + Login.idlocal + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(query1, connectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                label1.Text = dt.Rows[0][3].ToString();

                label16.Text = dt.Rows[0][1].ToString();
                label10.Text = dt.Rows[0][3].ToString();
                label11.Text = dt.Rows[0][4].ToString();
                label25.Text = dt.Rows[0][6].ToString();
                label22.Text = dt.Rows[0][9].ToString();
                label23.Text = dt.Rows[0][10].ToString();
                label24.Text = dt.Rows[0][5].ToString();


                da.Dispose();

            }
            catch (Exception ex)
            {  // Show any error message.
                MessageBox.Show(ex.Message);
            }



            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {



            if (guna2TextBox2.Text  == "" || guna2TextBox4.Text == "" | comboBox1.Text == "" | comboBox2.Text == "")
            {
                MessageBox.Show("Preencha todos os campos");
            }else
            {


                try
                {

                    //Salvar na info na BD e limpar 
                    string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";

                string query1 =" UPDATE `users` SET `Email`= '"+guna2TextBox1.Text+"',`Nome`= '"+guna2TextBox2.Text+"',`Genero`= '"+comboBox1.SelectedItem.ToString() +"',`Dtn`= '"+ dateTimePicker1.Value.ToString("yyyy-MM-dd")+"',`Regiao`= '"+ comboBox2.SelectedItem.ToString() +"',`Morada`= '"+guna2TextBox4.Text +"',`Codigo_Postal`= '"+ maskedTextBox1.Text +"' WHERE Id = '" + Login.idlocal+"' ";

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);

                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;


                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();




                    String query2 = "Select * from users where Id = '" + Login.idlocal + "'";
                    MySqlDataAdapter da = new MySqlDataAdapter(query2, connectionString);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    label1.Text = dt.Rows[0][3].ToString();

                    label16.Text = dt.Rows[0][1].ToString();
                    label10.Text = dt.Rows[0][3].ToString();
                    label11.Text = dt.Rows[0][4].ToString();
                    label25.Text = dt.Rows[0][6].ToString();
                    label22.Text = dt.Rows[0][9].ToString();
                    label23.Text = dt.Rows[0][10].ToString();
                    label24.Text = dt.Rows[0][5].ToString();


                    da.Dispose();

                }
                catch (Exception ex)
                {  // Show any error message.
                    MessageBox.Show(ex.Message);
                }





                panel3.Visible = false;
                panel1.Visible = true;
                panel4.Visible = true;

                guna2TextBox2.Clear();
               
                guna2TextBox4.Clear();
                guna2TextBox1.Clear();

                comboBox1.Items.Clear();
                comboBox2.Items.Clear();

                maskedTextBox1.Clear();
            }
          
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void guna2TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {  
            
          
            definicoes_perfilPessoal f1 = new definicoes_perfilPessoal();
            f1.Close();
             this.Close();
        }
    }
}

//REMOVER AS LETRAS 
//if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
//{
  //  e.Handled = true;
//}