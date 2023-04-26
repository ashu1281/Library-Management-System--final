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
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

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
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select * from NewMember where mID= '" + userId + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            txtName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtContact.Text = ds.Tables[0].Rows[0][2].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0][3].ToString();
            txtState.Text = ds.Tables[0].Rows[0][4].ToString();
            txtCity.Text = ds.Tables[0].Rows[0][5].ToString();
            txtPincode.Text = ds.Tables[0].Rows[0][6].ToString();
            txtPassword.Text = ds.Tables[0].Rows[0][8].ToString();
            txtPetName.Text = ds.Tables[0].Rows[0][9].ToString();

            if (ds.Tables[0].Rows[0][7].ToString() != "")
            {

                // Get the image data from the result set
                byte[] imageData = (byte[])ds.Tables[0].Rows[0][7];

                // Convert the image data to an Image object
                Image image = ViewMember.ByteArrayToImage(imageData);
                if (image != null)
                {
                    userImage.Image = image;
                }
            }
            else
            {
                Image image2 = Image.FromFile("D:\\pratiti training\\Project\\Library Management System\\Library Management System\\icon and imgs\\users phots's\\user_demo.jpg");
                userImage.Image = image2;

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
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "Delete from NewMember where mID= '" + userId + "'";

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
            int affectrow;
            if (!string.IsNullOrEmpty(imagePath))
            {
                byte[] imageData = AddMember.ImageToByteArray(imagePath);
                string newName = txtName.Text;
                string newEmail = txtEmail.Text;
                string newContact = txtContact.Text;
                string newState = txtState.Text;
                string newCity = txtCity.Text;
                Int64 newPincode = Int64.Parse(txtPincode.Text);
                string newPassword = txtPassword.Text;



                // Open a connection to the database
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                SqlParameter imageDataParameter = new SqlParameter("@imageDataParameter", SqlDbType.VarBinary);
                imageDataParameter.Value = imageData;

                con.Open();
                cmd.CommandText = "UPDATE NewMember SET mName = @newName, mEmail = @newEmail, mContact = @newContact, mState = @newState, mCity = @newCity, mPincode = @newPincode, mPassword = @newPassword, mPhoto = @imageDataParameter WHERE mID= '" + userId + "'";



                // Add the parameters to the command object's Parameters collection
                cmd.Parameters.Add("@newName", SqlDbType.VarChar).Value = newName;
                cmd.Parameters.Add("@newEmail", SqlDbType.VarChar).Value = newEmail;
                cmd.Parameters.Add("@newContact", SqlDbType.VarChar).Value = newContact;
                cmd.Parameters.Add("@newState", SqlDbType.VarChar).Value = newState;
                cmd.Parameters.Add("@newCity", SqlDbType.VarChar).Value = newCity;
                cmd.Parameters.Add("@newPincode", SqlDbType.Int).Value = newPincode;
                cmd.Parameters.Add("@newPassword", SqlDbType.VarChar).Value = newPassword;
                cmd.Parameters.Add(imageDataParameter);

                //// Execute the SQL command


                affectrow = cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {

                string newName = txtName.Text;
                string newEmail = txtEmail.Text;
                string newContact=txtContact.Text;
                string newState = txtState.Text;
                string newCity = txtCity.Text;
                Int64 newPincode = Int64.Parse(txtPincode.Text);
                string newPassword = txtPassword.Text;



                // Open a connection to the database
                SqlConnection con=new SqlConnection();
                con.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

               

                con.Open();
                cmd.CommandText = "UPDATE NewMember SET mName = @newName, mEmail = @newEmail, mContact = @newContact, mState = @newState, mCity = @newCity, mPincode = @newPincode, mPassword = @newPassword WHERE mID= '"+ userId + "'";



                // Add the parameters to the command object's Parameters collection
                cmd.Parameters.Add("@newName", SqlDbType.VarChar).Value = newName;
                cmd.Parameters.Add("@newEmail", SqlDbType.VarChar).Value = newEmail;
                cmd.Parameters.Add("@newContact", SqlDbType.VarChar).Value = newContact;
                cmd.Parameters.Add("@newState", SqlDbType.VarChar).Value = newState;
                cmd.Parameters.Add("@newCity", SqlDbType.VarChar).Value = newCity;
                cmd.Parameters.Add("@newPincode", SqlDbType.Int).Value = newPincode;
                cmd.Parameters.Add("@newPassword", SqlDbType.VarChar).Value = newPassword;

                //// Execute the SQL command


                 affectrow =cmd.ExecuteNonQuery();
                con.Close();
            }

            // Get the updated values from the textboxes
            if (affectrow > 0)
            {
                MessageBox.Show("data Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
            
      
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserManageProfile_Load(sender, e);
        }
    }
}
