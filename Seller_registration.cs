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
    public partial class Seller_registration : Form
    {
        public Seller_registration()
        {
            InitializeComponent();
        }
        private string fname, sid, pass, phone, email;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            fname = fnametxt.Text;
            sid = sidtxt.Text;
            pass = passtxt.Text;
            email = emailtxt.Text;
            phone = phonetxt.Text;
            insert();
            MessageBox.Show("Registration Succesful.");
            fnametxt.Text = "";
            sidtxt.Text = "";
            passtxt.Text= "";
            emailtxt.Text = "";
            phonetxt.Text = "" ;
        }
        private void insert()
        {
            string connectionString = @"Data Source=TUTUL\SQLEXPRESS;Initial Catalog=SupermarkerMangementSystem;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string q = @"INSERT INTO Seller_registration 
            ([Full Name], [Seller Id],[Password],[Phone], [Email])
            VALUES ('" + fnametxt.Text + "','" + sidtxt.Text + "','" + passtxt.Text + "','" + phonetxt.Text + "','" + emailtxt.Text + "')";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
