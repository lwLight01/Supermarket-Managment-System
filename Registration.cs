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
using System.Xml.Linq;
using static Azure.Core.HttpHeader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SupermarketManagmentSystem
{
    
    public partial class Registration : Form
    {

        public Registration()
        {
            InitializeComponent();
        }
        private string fullname, email, uname, pass, dob, phone;

        private void bcklogin_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void signup_Click(object sender, EventArgs e)
        {
            fullname = nametxtbox.Text;
            uname= Unametxtbox.Text;
            email = emailtxtbox.Text;
            pass = Passwordtxtbox.Text;
            phone = phonetxtbox.Text;
            dob = dobpicker.Text;
            insert();
            MessageBox.Show("Registration Succesful.");
        }

        private void insert()
        {
            string connectionString = @"Data Source=TUTUL\SQLEXPRESS;Initial Catalog=SupermarkerMangementSystem;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string q = @"INSERT INTO Customer_Login 
([Full Name], [User Name], [Email], [Password], [Phone], [Date Of Birth])
VALUES ('"+nametxtbox.Text+"','"+Unametxtbox.Text+"','"+emailtxtbox.Text+"','"+Passwordtxtbox.Text+"','"+ phonetxtbox.Text+"','"+ dobpicker.Text+"')";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
