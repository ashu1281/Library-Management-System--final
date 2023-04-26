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

namespace Library_Management_System
{
    public partial class UserDashboard : Form
    {
        private string username;
        public UserDashboard(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private void RoundPictureBox(PictureBox pictureBox)
        {
            Rectangle r = new Rectangle(0, 0, pictureBox.Width, pictureBox.Height);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            int d = Math.Min(pictureBox.Width, pictureBox.Height);
            gp.AddArc(r.X, r.Y, d, d, 180, 90);
            gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
            pictureBox.Region = new Region(gp);
        }


        private void UserDashboard_Load(object sender, EventArgs e)
        {
            //make a picturebox rounded

            RoundPictureBox(pictureBox1);

            SqlConnection conn3 = new SqlConnection();
            conn3.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = conn3;

            cmd3.CommandText = "select * from NewMember where mID = '" + username + "'";

            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);



            if (ds3.Tables[0].Rows.Count != 0)
            {
                usernm.Text = "@"+ds3.Tables[0].Rows[0][1].ToString();
                //txtContact.Text = ds.Tables[0].Rows[0][3].ToString();
                //txtEmail.Text = ds.Tables[0].Rows[0][4].ToString();

                if (ds3.Tables[0].Rows[0][7].ToString() != "")
                {

                    // Get the image data from the result set
                    byte[] imageData = (byte[])ds3.Tables[0].Rows[0][7];

                    // Convert the image data to an Image object
                    Image image = ViewMember.ByteArrayToImage(imageData);
                    if (image != null)
                    {
                        pictureBox1.Image = image;
                    }
                }
            }


            WelcomeLabel.Text = $"Welcome, {username}!";


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            //cmd.CommandText = "select mID,Member_Name,Book_Name,Book_Issue_Date from IssueReturnBook where mID='" + username + "' and Book_Return_Date is NULL";

            cmd.CommandText = "select t1.MemberID,t2.mName,t3.bName,t1.Book_Issue_Date FROM IssueReturnBook t1 INNER JOIN NewMember t2 ON t1.MemberID = t2.mID INNER JOIN NewBook t3 ON t1.BookID = t3.bId where t2.mID ='" + username + "' and t1.Book_Return_Date is NULL";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("serialNumber", "Sr.No.");
                dataGridView1.Columns.Add("bName", "Book Name");
                dataGridView1.Columns.Add("Book_Issue_Date", "Book Issue Date");
                
                dataGridView1.Columns[0].Width = 50;

                dataGridView1.Columns[1].DataPropertyName = "bName";
                dataGridView1.Columns[2].DataPropertyName = "Book_Issue_Date";


            }



            //returned books

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = conn;

            //cmd1.CommandText = "select mID,Member_Name,Book_Name,Book_Issue_Date,Book_Return_Date from IssueReturnBook where mID='" + username + "' and Book_Return_Date is NOT NULL";
            cmd1.CommandText = "select t1.MemberID,t2.mName,t3.bName,t1.Book_Issue_Date,t1.Book_Return_Date FROM IssueReturnBook t1 INNER JOIN NewMember t2 ON t1.MemberID = t2.mID INNER JOIN NewBook t3 ON t1.BookID = t3.bId where t2.mID ='" + username + "' and t1.Book_Return_Date is NOT NULL";

            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            lblBookRead.Text = ds1.Tables[0].Rows.Count.ToString();

            if (ds1.Tables[0].Rows.Count != 0)
            {
                dataGridView2.DataSource = ds1.Tables[0];
                dataGridView2.Columns.Clear();
                dataGridView2.Columns.Add("serialNumber", "Sr.No.");
                dataGridView2.Columns.Add("bName", "Book Name");
                dataGridView2.Columns.Add("Book_Issue_Date", "Book Issue Date");
                dataGridView2.Columns.Add("Book_Return_Date", "Book return Date");

                dataGridView2.Columns[0].Width = 50;

                dataGridView2.Columns[1].DataPropertyName = "bName";
                dataGridView2.Columns[2].DataPropertyName = "Book_Issue_Date";
                dataGridView2.Columns[3].DataPropertyName = "Book_Return_Date";
            }

            dataGridView3.Visible= false;
            avlBook.Visible= false;
            searchBook.Visible= false;
           

                    


        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to Sign out", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Close all open forms except for the dashboard form
                
                this.Close();
            }

        }
        

        

        private void manage_profile_Click(object sender, EventArgs e)
        {
            //new form should open with edit , delete and update action on user's data
            UserManageProfile usermanage = new UserManageProfile(username);
            usermanage.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //To make a picturebox to circular
            //// Set the smoothing mode to antialias
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //// Create a circular path that matches the size of the PictureBox
            //System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            //path.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height);

            //// Set the clip of the graphics object to the circular path
            //e.Graphics.SetClip(path);

            //// Draw the image onto the graphics object
            //e.Graphics.DrawImage(pictureBox1.Image, 0, 0);

            //// Reset the clip of the graphics object
            //e.Graphics.ResetClip();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Set the smoothing mode to antialias
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Create a rounded rectangle path that matches the size of the Panel
            int rounding = 200; // adjust the rounding size as needed
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, rounding, rounding, 180, 90);
            path.AddArc(panel1.Width - rounding, 0, rounding, rounding, 270, 90);
            path.AddArc(panel1.Width - rounding, panel1.Height - rounding, rounding, rounding, 0, 90);
            path.AddArc(0, panel1.Height - rounding, rounding, rounding, 90, 90);
            path.CloseFigure();

            // Set the clip of the graphics object to the rounded rectangle path
            e.Graphics.SetClip(path);

            // Fill the panel with the BackColor
            e.Graphics.FillRectangle(new SolidBrush(panel1.BackColor), 20, 20, panel1.Width, panel1.Height);

            // Reset the clip of the graphics object
            e.Graphics.ResetClip();
        }

        

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UserDashboard_Load(sender,e);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            row.Cells["serialNumber"].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
            row.Cells["serialNumber"].Value = (e.RowIndex + 1).ToString();
        }

        private void usernm_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnbookcheck_Click(object sender, EventArgs e)
        {
            //available books 
            dataGridView3.Visible = true;
            avlBook.Visible = true;
            searchBook.Visible = true;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";


            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = conn;

            cmd4.CommandText = "select bName , bAuthor, bPubl from NewBook WHERE bQuan > 0";
            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);

            if (ds4.Tables[0].Rows.Count > 0)
            {
                dataGridView3.DataSource = ds4.Tables[0];
            }
        }

        private void searchBook_TextChanged(object sender, EventArgs e)
        {
                
  
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select bName , bAuthor , bPubl , bQuan from NewBook where bName LIKE '" + searchBook.Text + "%' OR bAuthor LIKE '"+searchBook.Text+"%' AND bQuan > 0";
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);

                dataGridView3.DataSource = ds.Tables[0];

          

        }

        private void serachBook(object sender, EventArgs e)
        {
            searchBook.Clear();
        }
    }
}
