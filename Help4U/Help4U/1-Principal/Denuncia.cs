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
    public partial class Denuncia : Form
    {
        public Denuncia()
        {
            InitializeComponent();
        }

        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text.Length > 0)
            {

                string query = "INSERT INTO denuncia(`IdDenuncia`, `IdUser`, `IdUser2`, `Motivo`, `Estado`) VALUES (NULL, '" + Login.idlocal + "', '" + procPerfil.selectUser + "', '" + guna2TextBox1.Text.Trim() + "', 'Por fazer')";

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


            }



            MessageBox.Show("Obrigado por denunciar este user :)");
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Denuncia_Load(object sender, EventArgs e)
        {
            try { 
           
            String query1 = "Select * from users where Id = '" + procPerfil.selectUser + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(query1, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            label2.Text = dt.Rows[0][3].ToString( );

        }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }


}
    }
}
