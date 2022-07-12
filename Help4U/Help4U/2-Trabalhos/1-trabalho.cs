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
using System.IO;


namespace Help4U
{
    public partial class trabalho : Form
    {
        public trabalho()
        {
            InitializeComponent();
        }

        public static string selectwork;
        public void loadform(object Form)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(f);
            this.panel1.Tag = f;
            f.Show();
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void trabalho_Load(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select * from trabalho INner join trabalho_fotos on IdTrabalho = Id_Trabalho where N_foto = 1 and Estado1 = 'Ativo' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = 0;

            ImageList images = new ImageList();

            foreach (DataRow row in dt.Rows)
            {
                try
                {

                    images.ColorDepth = ColorDepth.Depth32Bit;

                    listView1.LargeImageList = images;
                    listView1.LargeImageList.ImageSize = new System.Drawing.Size(110, 110);


                    byte[] imagebyte = (byte[])(row[13]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images.Images.Add(row[2].ToString(), new Bitmap(image_stream));

                    image_stream.Close();

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;


                    item.Text = row["Titulo"].ToString() + "\r\n \r\n" + row["Localização"].ToString();
                    item.SubItems.Add(row["IdTrabalho"].ToString());


                    i += 1;

                    this.listView1.Items.Add(item);


                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }
               

            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            InfoTrabalho ti = new InfoTrabalho();
            selectwork = listView1.SelectedItems[0].SubItems[1].Text;
            ti.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void construçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Select * from trabalho INner join trabalho_fotos on IdTrabalho = Id_Trabalho where N_foto = 1 and Estado1 = 'Ativo' and Tipo = 'construção' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query1, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = 0;

            ImageList images = new ImageList();

            foreach (DataRow row in dt.Rows)
            {
                try
                {

                    images.ColorDepth = ColorDepth.Depth32Bit;

                    listView1.LargeImageList = images;
                    listView1.LargeImageList.ImageSize = new System.Drawing.Size(110, 110);


                    byte[] imagebyte = (byte[])(row[13]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images.Images.Add(row[2].ToString(), new Bitmap(image_stream));

                    image_stream.Close();

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;


                    item.Text = row["Titulo"].ToString() + "\r\n \r\n" + row["Localização"].ToString();
                    item.SubItems.Add(row["IdTrabalho"].ToString());

                    i += 1;

                    this.listView1.Items.Add(item);
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void designToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Select * from trabalho INner join trabalho_fotos on IdTrabalho = Id_Trabalho where N_foto = 1 and Estado1 = 'Ativo' and Tipo = 'design' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query1, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = 0;

            ImageList images = new ImageList();

            foreach (DataRow row in dt.Rows)
            {
                try
                {

                    images.ColorDepth = ColorDepth.Depth32Bit;

                    listView1.LargeImageList = images;
                    listView1.LargeImageList.ImageSize = new System.Drawing.Size(110, 110);


                    byte[] imagebyte = (byte[])(row[13]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images.Images.Add(row[2].ToString(), new Bitmap(image_stream));

                    image_stream.Close();

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;


                    item.Text = row["Titulo"].ToString() + "\r\n \r\n" + row["Localização"].ToString();
                    item.SubItems.Add(row["IdTrabalho"].ToString());

                    i += 1;

                    this.listView1.Items.Add(item);
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void escritaETraduçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Select * from trabalho INner join trabalho_fotos on IdTrabalho = Id_Trabalho where N_foto = 1 and Estado1 = 'Ativo' and Tipo = 'Escrita e tradução' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query1, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = 0;

            ImageList images = new ImageList();

            foreach (DataRow row in dt.Rows)
            {
                try
                {

                    images.ColorDepth = ColorDepth.Depth32Bit;

                    listView1.LargeImageList = images;
                    listView1.LargeImageList.ImageSize = new System.Drawing.Size(110, 110);


                    byte[] imagebyte = (byte[])(row[13]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images.Images.Add(row[2].ToString(), new Bitmap(image_stream));

                    image_stream.Close();

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;


                    item.Text = row["Titulo"].ToString() + "\r\n \r\n" + row["Localização"].ToString();
                    item.SubItems.Add(row["IdTrabalho"].ToString());

                    i += 1;

                    this.listView1.Items.Add(item);
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void estiloDeVidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Select * from trabalho INner join trabalho_fotos on IdTrabalho = Id_Trabalho where N_foto = 1 and Estado1 = 'Ativo' and Tipo = 'Estilo de Vida' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query1, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = 0;

            ImageList images = new ImageList();

            foreach (DataRow row in dt.Rows)
            {
                try
                {

                    images.ColorDepth = ColorDepth.Depth32Bit;

                    listView1.LargeImageList = images;
                    listView1.LargeImageList.ImageSize = new System.Drawing.Size(110, 110);


                    byte[] imagebyte = (byte[])(row[13]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images.Images.Add(row[2].ToString(), new Bitmap(image_stream));

                    image_stream.Close();

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;


                    item.Text = row["Titulo"].ToString() + "\r\n \r\n" + row["Localização"].ToString();
                    item.SubItems.Add(row["IdTrabalho"].ToString());

                    i += 1;

                    this.listView1.Items.Add(item);
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void marketingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Select * from trabalho INner join trabalho_fotos on IdTrabalho = Id_Trabalho where N_foto = 1 and Estado1 = 'Ativo' and Tipo = 'Marketing' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query1, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = 0;

            ImageList images = new ImageList();

            foreach (DataRow row in dt.Rows)
            {
                try
                {

                    images.ColorDepth = ColorDepth.Depth32Bit;

                    listView1.LargeImageList = images;
                    listView1.LargeImageList.ImageSize = new System.Drawing.Size(110, 110);


                    byte[] imagebyte = (byte[])(row[13]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images.Images.Add(row[2].ToString(), new Bitmap(image_stream));

                    image_stream.Close();

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;


                    item.Text = row["Titulo"].ToString() + "\r\n \r\n" + row["Localização"].ToString();
                    item.SubItems.Add(row["IdTrabalho"].ToString());

                    i += 1;

                    this.listView1.Items.Add(item);
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void negóciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Select * from trabalho INner join trabalho_fotos on IdTrabalho = Id_Trabalho where N_foto = 1 and Estado1 = 'Ativo' and Tipo = 'Animação e vídeo' or Tipo = 'Áudio e musica' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query1, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = 0;

            ImageList images = new ImageList();

            foreach (DataRow row in dt.Rows)
            {
                try
                {

                    images.ColorDepth = ColorDepth.Depth32Bit;

                    listView1.LargeImageList = images;
                    listView1.LargeImageList.ImageSize = new System.Drawing.Size(110, 110);


                    byte[] imagebyte = (byte[])(row[13]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images.Images.Add(row[2].ToString(), new Bitmap(image_stream));

                    image_stream.Close();

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;


                    item.Text = row["Titulo"].ToString() + "\r\n \r\n" + row["Localização"].ToString();
                    item.SubItems.Add(row["IdTrabalho"].ToString());

                    i += 1;

                    this.listView1.Items.Add(item);
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void tecnologiaEProgramaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Select * from trabalho INner join trabalho_fotos on IdTrabalho = Id_Trabalho where N_foto = 1 and Estado1 = 'Ativo' and Tipo = 'Negocios' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query1, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = 0;

            ImageList images = new ImageList();

            foreach (DataRow row in dt.Rows)
            {
                try
                {

                    images.ColorDepth = ColorDepth.Depth32Bit;

                    listView1.LargeImageList = images;
                    listView1.LargeImageList.ImageSize = new System.Drawing.Size(110, 110);


                    byte[] imagebyte = (byte[])(row[13]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images.Images.Add(row[2].ToString(), new Bitmap(image_stream));

                    image_stream.Close();

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;


                    item.Text = row["Titulo"].ToString() + "\r\n \r\n" + row["Localização"].ToString();
                    item.SubItems.Add(row["IdTrabalho"].ToString());

                    i += 1;

                    this.listView1.Items.Add(item);
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void trabalhosManuaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Select * from trabalho INner join trabalho_fotos on IdTrabalho = Id_Trabalho where N_foto = 1 and Estado1 = 'Ativo' and Tipo = 'Tecnologia e Programação' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query1, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = 0;

            ImageList images = new ImageList();

            foreach (DataRow row in dt.Rows)
            {
                try
                {

                    images.ColorDepth = ColorDepth.Depth32Bit;

                    listView1.LargeImageList = images;
                    listView1.LargeImageList.ImageSize = new System.Drawing.Size(110, 110);


                    byte[] imagebyte = (byte[])(row[13]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images.Images.Add(row[2].ToString(), new Bitmap(image_stream));

                    image_stream.Close();

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;


                    item.Text = row["Titulo"].ToString() + "\r\n \r\n" + row["Localização"].ToString();
                    item.SubItems.Add(row["IdTrabalho"].ToString());

                    i += 1;

                    this.listView1.Items.Add(item);
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void trabalhosManuaisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Select * from trabalho INner join trabalho_fotos on IdTrabalho = Id_Trabalho where N_foto = 1 and Estado1 = 'Ativo' and Tipo = 'Trabalhos Manuais' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query1, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = 0;

            ImageList images = new ImageList();

            foreach (DataRow row in dt.Rows)
            {
                try
                {

                    images.ColorDepth = ColorDepth.Depth32Bit;

                    listView1.LargeImageList = images;
                    listView1.LargeImageList.ImageSize = new System.Drawing.Size(110, 110);


                    byte[] imagebyte = (byte[])(row[13]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images.Images.Add(row[2].ToString(), new Bitmap(image_stream));

                    image_stream.Close();

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;


                    item.Text = row["Titulo"].ToString() + "\r\n \r\n" + row["Localização"].ToString();
                    item.SubItems.Add(row["IdTrabalho"].ToString());

                    i += 1;

                    this.listView1.Items.Add(item);
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Clear();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query1 = "Select * from trabalho INner join trabalho_fotos on IdTrabalho = Id_Trabalho where N_foto = 1 and Estado1 = 'Ativo' and Titulo like '%"+ guna2TextBox1.Text +"%' ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query1, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt); 

            int i = 0;

            ImageList images = new ImageList();

            foreach (DataRow row in dt.Rows)
            {
                try
                {

                    images.ColorDepth = ColorDepth.Depth32Bit;

                    listView1.LargeImageList = images;
                    listView1.LargeImageList.ImageSize = new System.Drawing.Size(110, 110);


                    byte[] imagebyte = (byte[])(row[13]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images.Images.Add(row[2].ToString(), new Bitmap(image_stream));

                    image_stream.Close();

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;


                    item.Text = row["Titulo"].ToString() + "\r\n \r\n" + row["Localização"].ToString();
                    item.SubItems.Add(row["IdTrabalho"].ToString());

                    i += 1;

                    this.listView1.Items.Add(item);
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }


            }
        }
    }
}
