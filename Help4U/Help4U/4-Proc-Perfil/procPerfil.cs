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
    public partial class procPerfil : Form
    {
        public procPerfil()
        {
            InitializeComponent();
        }

        bool mover = false;
        Point Pinicial;
        public static string selectUser;

        private void lable1_MouseDown_1(object sender, MouseEventArgs e)
        {
            mover = true;
            Pinicial = new Point(e.X, e.Y);
        }

        private void lable1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                Point novo = PointToScreen(e.Location);
                Location = new Point(novo.X - this.Pinicial.X, novo.Y - this.Pinicial.Y);
            }
        }

        private void lable1_MouseUp_1(object sender, MouseEventArgs e)
        {
            mover = false;
        }


        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void procPerfil_Load(object sender, EventArgs e)
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select Id,Nome,Foto from users INner join userfotos on Id = IdUsers where Estado = 'Disponível';";

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


                    byte[] imagebyte = (byte[])(row[2]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images.Images.Add(row[2].ToString(), new Bitmap(image_stream));

                    image_stream.Close();

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;

                    item.Text = row["Nome"].ToString();
                    item.SubItems.Add(row["Id"].ToString());

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


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2RatingStar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {

            selectUser = listView1.SelectedItems[0].SubItems[1].Text;
            outroPerfil op = new outroPerfil();
            op.Show();

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
          
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select Id,Nome,Foto from users INner join userfotos on Id = IdUsers;";

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


                    byte[] imagebyte = (byte[])(row[2]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images.Images.Add(row[2].ToString(), new Bitmap(image_stream));

                    image_stream.Close();

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;

                    item.Text = row["Nome"].ToString();
                    item.SubItems.Add(row["Id"].ToString());

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

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            listView1.Clear();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=h4u;";
            string query = "Select Id,Nome,Foto from users INner join userfotos on Id = IdUsers where Nome Like '%" + guna2TextBox2.Text + "%' or Id Like '%" + guna2TextBox2.Text + "%' ;";

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


                    byte[] imagebyte = (byte[])(row[2]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images.Images.Add(row[2].ToString(), new Bitmap(image_stream));

                    image_stream.Close();

                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;

                    item.Text = row["Nome"].ToString();
                    item.SubItems.Add(row["Id"].ToString());

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

