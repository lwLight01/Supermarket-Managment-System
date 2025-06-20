using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlClient;

namespace SupermarketManagmentSystem
{
    public partial class Customer_Dashboard : Form
    {
        public Customer_Dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Dashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'supermarkerMangementSystemDataSet.Manage_Product' table. You can move, or remove it, as needed.
            this.manage_ProductTableAdapter.Fill(this.supermarkerMangementSystemDataSet.Manage_Product);
            guna2DataGridView1.Visible = false;
            guna2DataGridView1.Columns[5].Visible = false;
            panel1.Visible = false;
            guna2DataGridView2.Columns.Add("ProductId", "Product Id");
            guna2DataGridView2.Columns.Add("ProductName", "Product Name");
            guna2DataGridView2.Columns.Add("Price", "Price");
        }
        public class CartItem
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
        }
        List<CartItem> cart = new List<CartItem>();

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int newRowIndex = guna2DataGridView2.Rows.Add();

                guna2DataGridView2.Rows[newRowIndex].Cells[0].Value = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); // Product ID
                guna2DataGridView2.Rows[newRowIndex].Cells[1].Value = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); // Product Name
                guna2DataGridView2.Rows[newRowIndex].Cells[2].Value = guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); // Price
               
                CalculateTotalPrice();                                                                                                                  
            }
        }
        private double CalculateTotalPrice()
        {
            double totalPrice = 0;

            foreach (DataGridViewRow row in guna2DataGridView2.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    double price = 0;
                    bool isPriceValid = double.TryParse(row.Cells[2].Value.ToString(), out price);

                    if (isPriceValid)
                    {
                        totalPrice += price;
                    }
                }
            }

            labeltotal.Text = "Total: " + totalPrice.ToString("0.00") + " Tk";

            return totalPrice;
        }



        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Visible=true;
        }
        private void InsertOrderData()
        {
            string connectionString = @"Data Source=TUTUL\SQLEXPRESS;Initial Catalog=SupermarkerMangementSystem;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            try
            {
                string uname = guna2TextBox1.Text;
                DateTime date = DateTime.Now;
                double total = CalculateTotalPrice();

                StringBuilder productIds = new StringBuilder();
                StringBuilder productNames = new StringBuilder();

                foreach (DataGridViewRow row in guna2DataGridView2.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        productIds.Append(row.Cells[0].Value.ToString() + ", ");
                        productNames.Append(row.Cells[1].Value.ToString() + ", ");
                    }
                }
                if (productIds.Length > 0) productIds.Length -= 2;
                if (productNames.Length > 0) productNames.Length -= 2;

                string q = @"INSERT INTO Orderss
        ([User Name], [Product Id], [Product Name], [Price], [Date of product], [Total]) 
        VALUES (@uname, @pid, @pname, @price, @date, @total)";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@pid", productIds.ToString());
                cmd.Parameters.AddWithValue("@pname", productNames.ToString());
                cmd.Parameters.AddWithValue("@price", total);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Order Placed Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void Placeorbtn_Click(object sender, EventArgs e)
        {
            InsertOrderData();
            panel1.Visible = false;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Placeorbtn_DoubleClick(object sender, EventArgs e)
        {
            guna2DataGridView2.Visible
                = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close
                ();
        }
    }
}
