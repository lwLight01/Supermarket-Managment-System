using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SupermarketManagmentSystem
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }
        private string pname, pid, catagory;
        private double price, quantity;

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picturebox1.Image = new Bitmap(openFileDialog1.FileName);
                picturebox1.Tag = openFileDialog1.FileName;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pname = txtProdName.Text;
            pid = txtpid.Text;
            catagory = textBox1.Text;
            price = Convert.ToDouble(txtPrice.Text);
            quantity = Convert.ToDouble(txtQty.Text);
            insert();
            MessageBox.Show("Product Adding Succenfull.");
        }

        private void insert()
        {
            string connectionString = @"Data Source=TUTUL\SQLEXPRESS;Initial Catalog=SupermarkerMangementSystem;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string q = @"INSERT INTO Manage_Product 
([Product Name], [Prodect Id], [Catagory], [Price], [Quantity], [Picture])
VALUES ('" + txtProdName.Text + "','" + txtpid.Text + "','" + textBox1.Text + "','" + txtPrice.Text + "','" + txtQty.Text + "','" + picturebox1.Image + "')";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
