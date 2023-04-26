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

namespace Library_Management_System
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userId = txtuserID.Text;
            string password = txtPassword.Text;

            if (IsValidUser(userId, password))
            {
                // Instantiate the next form

                UserDashboard userdashboard = new UserDashboard(userId);

                // Show the next form as a dialog box

                userdashboard.ShowDialog();

            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }

       private  bool IsValidUser(string userId, string password)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source=localhost\\sqlexpress; database=LibraryDB; integrated security=True;";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText = "select * from NewMember where mID='" + userId + "' and mPassword='" + password + "'";


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddMember addMember = new AddMember();
            addMember.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you really Exit", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtuserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserLogin_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotUserPassword fup = new ForgotUserPassword();
            fup.ShowDialog();
        }
    }
}
