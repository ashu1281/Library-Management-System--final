using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class UserManageProfile : Form
    {
        private string userId;
        public UserManageProfile(string userId)
        {
            InitializeComponent();
            this.userId=userId;
        }

        private void UserManageProfile_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryManagement;Integrated Security=True;Pooling=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select * from NewMember where EnrollID = '" + userId + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            txtName.Text = ds.Tables[0].Rows[0][2].ToString();
            txtContact.Text = ds.Tables[0].Rows[0][3].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0][4].ToString();
            txtState.Text = ds.Tables[0].Rows[0][5].ToString();
            txtCity.Text = ds.Tables[0].Rows[0][6].ToString();
            txtPincode.Text = ds.Tables[0].Rows[0][7].ToString();
            txtPassword.Text = ds.Tables[0].Rows[0][9].ToString();

            if (ds.Tables[0].Rows[0][8].ToString() != "")
            {

                // Get the image data from the result set
                byte[] imageData = (byte[])ds.Tables[0].Rows[0][8];

                // Convert the image data to an Image object
                Image image = ViewMember.ByteArrayToImage(imageData);
                if (image != null)
                {
                    userImage.Image = image;
                }
            }



        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                this.Close();
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            //before it show the confirmation message if yess then delete the user account
            if (MessageBox.Show("Do you want to delete Account?", "confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryManagement;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "Delete from NewMember where EnrollID = '" + userId + "'";

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Account Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the updated values from the textboxes
            string newName = txtName.Text;
            string newEmail = txtEmail.Text;
            string newContact=txtContact.Text;
            string newState = txtState.Text;
            string newCity = txtCity.Text;
            Int64 newPincode = Int64.Parse(txtPincode.Text);
            string newPassword = txtPassword.Text;

            // Open a connection to the database
            SqlConnection con=new SqlConnection();
            con.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryManagement;Integrated Security=True;Pooling=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd.CommandText = "Update NewMember set mName='" + newName + "' , mEmail='" + newEmail + "', mContact='" + newContact + "' , mState='" + newState + "' , mCity='" + newCity + "',mPincode=" + newPincode + ", mPassword='" + newPassword + "' WHERE EnrollID= '"+ userId + "'" ;

            int affectrow=cmd.ExecuteNonQuery();
            if(affectrow > 0)
            {
                MessageBox.Show("data Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
            con.Close();
      
        }


        private string imagePath = "";
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                userImage.Image = new Bitmap(openFileDialog.FileName);
                imagePath = openFileDialog.FileName;
            }
        }
    }
}
