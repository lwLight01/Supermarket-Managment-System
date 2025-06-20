using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SupermarketManagmentSystem
{
   
    public partial class Form1: Form
    {
        string connectionString = @"Data Source=TUTUL\SQLEXPRESS;Initial Catalog=SupermarkerMangementSystem;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox1.Text.Trim();
            string password = guna2TextBox2.Text.Trim();
            string role = cmbRole.SelectedItem.ToString();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();

                    if (role == "Customer")
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Customer_Login WHERE [User Name] = @username AND [Password] = @password", conn);
                    }
                    else if (role == "Staff")
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Staff_Login WHERE [User Name] = @username AND [Password] = @password", conn);
                    }
                    else if (role == "Seller")
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Seller_Login WHERE [User Name] = @username AND [Password] = @password", conn);
                    }

                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Login Successful!");

                        if (role == "Customer")
                        {
                            Customer_Dashboard customerDashboard = new Customer_Dashboard();
                            this.Hide();
                            customerDashboard.Show();
                        }
                        else if (role == "Staff")
                        {
                            Staffdashboad staffDashboard = new Staffdashboad();
                            this.Hide();
                            staffDashboard.Show();
                        }
                        else if (role == "Seller")
                        {
                            sellerdashboard sellerDashboard = new sellerdashboard();
                            this.Hide();
                            sellerDashboard.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbRole.SelectedIndex = 0;
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Select_role s = new Select_role();
            this.Hide();
            s.Show();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void sellerloginpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
