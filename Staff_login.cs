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
    public partial class Staff_login : Form
    {
        public Staff_login()
        {
            InitializeComponent();
        }
        private string name, uname, email, pass, phone, role;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            name = fnametxt.Text;
            uname= unametxt.Text;
            email = emailtxt.Text;
            pass= passtxt.Text;
            phone = phonetxt.Text;
            role = stacmd.Text;
            insert();
            MessageBox.Show("Registration Succesfull, Please Login Now");
            fnametxt.Text = "";
            unametxt.Text = "";
            passtxt.Text = "";
            emailtxt.Text = "";
            phonetxt.Text = "";
            stacmd.SelectedIndex = 0;
        }
        private void insert()
        {
            string connectionString = @"Data Source=TUTUL\SQLEXPRESS;Initial Catalog=SupermarkerMangementSystem;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string q = @"INSERT INTO Staff_registration 
             ([Full Name], [User Name], [Email], [Password], [Phone], [Role])
             VALUES ('" + fnametxt.Text + "','" + unametxt.Text + "','" + emailtxt.Text + "','" + passtxt.Text + "','" + phonetxt.Text + "','" + stacmd.Text + "')";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Staff_login_Load(object sender, EventArgs e)
        {
            stacmd.SelectedIndex = 0;
        }
    }
}
