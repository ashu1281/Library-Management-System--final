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
    public partial class ForgotUserPassword : Form
    {
        public ForgotUserPassword()
        {
            InitializeComponent();
        }

        private void btnCheckPassword_Click(object sender, EventArgs e)
        {
            if(txtuserID.Text != "" && txtUserPetName.Text != "")
            {
                String userid = txtuserID.Text;
                String petname = txtUserPetName.Text;

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";
                
                conn.Open();
                //cmd.CommandText = "select mPetName from NewMember where EnrollID='" + txtuserID.Text + "' AND mPassword='" + txtUserPetName.Text + "' ";

               
                SqlCommand cmd = new SqlCommand("select mPassword from NewMember where mID='" + txtuserID.Text + "' AND mPetName='" + txtUserPetName.Text + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string message = string.Format("Your Password is: {0}", dr[0].ToString());

                    MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You entered wrong petname.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                dr.Close();

                conn.Close();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
