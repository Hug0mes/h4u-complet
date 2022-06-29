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
            string query = "Select Id,Nome,Foto from users INner join userfotos on Id = IdUsers;";

            MySqlDataAdapter sda = new MySqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = 0;

            ImageList images = new ImageList();

            foreach (DataRow row in dt.Rows)
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


                i += 1;

                this.listView1.Items.Add(item);

            }
    }

       
    }
}
