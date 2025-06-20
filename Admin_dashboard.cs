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
using System.Data.SqlClient;

namespace SupermarketManagmentSystem
{
    public partial class Admin_dashboard : Form
    {
        BindingSource customerBindingSource = new BindingSource();
        public Admin_dashboard()
        {
            InitializeComponent();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Supermarket Management System Admin Dashboard is a powerful tool designed to help administrators efficiently manage products, inventory, sales, and staff records. It provides a user-friendly interface to monitor supermarket activities in real-time and ensures smooth and secure management of all supermarket operations.");
        }

        private void Admin_dashboard_Load(object sender, EventArgs e)
        {
            // Load Customer data into the dataset
            this.customer_LoginTableAdapter.Fill(this.supermarkerMangementSystemDataSet3.Customer_Login);
            customerBindingSource.DataSource = supermarkerMangementSystemDataSet3.Customer_Login;
            guna2DataGridView3.DataSource = customerBindingSource;
            guna2DataGridView3.ReadOnly = false;
            guna2DataGridView3.AllowUserToAddRows = false;
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = customer_LoginTableAdapter.Connection;
            updateCommand.CommandText =
                "UPDATE Customer_Login SET " +
                "[Full Name] = @FullName, " +
                "[Email] = @Email, " +
                "[Password] = @Password, " +
                "[Phone] = @Phone, " +
                "[Date Of Birth] = @DateOfBirth " +
                "WHERE [User Name] = @UserName";
            updateCommand.Parameters.Clear();
            updateCommand.Parameters.Add("@FullName", SqlDbType.VarChar, 50, "Full Name");
            updateCommand.Parameters.Add("@Email", SqlDbType.VarChar, 50, "Email");
            updateCommand.Parameters.Add("@Password", SqlDbType.VarChar, 50, "Password");
            updateCommand.Parameters.Add("@Phone", SqlDbType.VarChar, 15, "Phone");
            updateCommand.Parameters.Add("@DateOfBirth", SqlDbType.DateTime, 0, "Date Of Birth");
            SqlParameter param = updateCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50, "User Name");
            param.SourceVersion = DataRowVersion.Original;
            customer_LoginTableAdapter.Adapter.UpdateCommand = updateCommand;
            this.orderssTableAdapter.Fill(this.supermarkerMangementSystemDataSet2.Orderss);
            this.manage_ProductTableAdapter.Fill(this.supermarkerMangementSystemDataSet1.Manage_Product);
            guna2DataGridView1.Visible = false;
            guna2DataGridView2.Visible = false;
            guna2DataGridView3.Visible = false;
            guna2Button1.Visible = false;
        }
        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void viewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Visible = true;
            guna2DataGridView1.Columns[5].Visible = false;
        }

        private void hideProductViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Visible = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2DataGridView2.Visible=true;
        }

        private void aboutToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {
            guna2DataGridView2.Visible=false;
        }

        private void hideOrderHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2DataGridView2.Visible =false;
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2DataGridView3.Visible=true;
            guna2Button1.Visible = true;
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2DataGridView3.Visible=false;
            guna2Button1.Visible=false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                customerBindingSource.EndEdit();

                this.customer_LoginTableAdapter.Update(this.supermarkerMangementSystemDataSet3.Customer_Login);

                this.supermarkerMangementSystemDataSet3.Customer_Login.Clear();
                this.customer_LoginTableAdapter.Fill(this.supermarkerMangementSystemDataSet3.Customer_Login);

                MessageBox.Show("Update Successful and Data Reloaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

