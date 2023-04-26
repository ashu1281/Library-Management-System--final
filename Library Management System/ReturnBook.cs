using Library_Management_System.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Library_Management_System
{
    public partial class Return_Book : Form
    {
        public Return_Book()
        {
            InitializeComponent();
        }


        private void Return_Book_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            int enroll = int.Parse(txtsearchEnroll.Text);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            //cmd.CommandText = "select ID,EnrollID,Member_Name,bName,Book_Issue_Date,Book_Return_Date from IssueReturnBook where EnrollID= '" + enroll + "' and Book_Return_Date is Null";

            //cmd.CommandText = "SELECT t1.irID, t1.MemberID, t1.BookID, t1.Book_Issue_Date,t1.Book_Return_Date,t2.mPhoto,t2.mName FROM IssueReturnBook t1 JOIN NewMember t2 ON t1.MemberID = t2.mID where t1.MemberID= " + enroll + " and Book_Return_Date is Null";
            
            
            cmd.CommandText = @"SELECT t1.irID, t2.mName, t2.mContact, t2.mEmail, t2.mPhoto, t3.bName, t1.Book_Issue_Date
                                FROM IssueReturnBook t1
                                INNER JOIN NewMember t2 ON t1.MemberID = t2.mID
                                INNER JOIN NewBook t3 ON t1.BookID = t3.bId
                                WHERE t1.MemberID = " + enroll+" and t1.Book_Return_Date is Null";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {

                if (ds.Tables[0].Rows[0][4].ToString() != "")
                {

                    // Get the image data from the result set
                    byte[] imageData = (byte[])ds.Tables[0].Rows[0][4];

                    // Convert the image data to an Image object
                    Image image = ViewMember.ByteArrayToImage(imageData);
                    if (image != null)
                    {
                        pictureBoxMemberImg.Image = image;
                    }
                }
                else
                {
                    Image image2 = Image.FromFile("D:\\pratiti training\\Project\\Library Management System\\Library Management System\\icon and imgs\\icons8-student-male-100.png");
                    pictureBoxMemberImg.Image = image2;
                }

                textBoxMemberName.Text = ds.Tables[0].Rows[0][1].ToString();

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("irID", "ID");
                dataGridView1.Columns.Add("bName", "Book Name");
                dataGridView1.Columns.Add("Book_Issue_Date", "Book Issue Date");
                dataGridView1.Columns[0].DataPropertyName = "irID";
                dataGridView1.Columns[0].Width = 50;

                dataGridView1.Columns[1].DataPropertyName = "bName";
                dataGridView1.Columns[2].DataPropertyName = "Book_Issue_Date";

            }
            else
            {
                MessageBox.Show("This Enrollment Number does not issued book yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        int id;
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {


                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());


                panel3.Visible = true;

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = @"SELECT t1.MemberID,t2.mName, t2.mContact, t2.mEmail, t3.bName, t1.Book_Issue_Date
                                FROM IssueReturnBook t1
                                INNER JOIN NewMember t2 ON t1.MemberID = t2.mID
                                INNER JOIN NewBook t3 ON t1.BookID = t3.bId
                                WHERE t1.irID = " + id +"";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);



               

                txtEnrollID.Text = ds.Tables[0].Rows[0][0].ToString();
                txtMemberName.Text = ds.Tables[0].Rows[0][1].ToString();
                txtContact.Text = ds.Tables[0].Rows[0][2].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][3].ToString();
                txtBookName.Text = ds.Tables[0].Rows[0][4].ToString();
                txtIssueDate.Text = ds.Tables[0].Rows[0][5].ToString();

            }
        }

        private void txtsearchEnroll_TextChanged(object sender, EventArgs e)
        {
            if (txtsearchEnroll.Text == "")
            {
                dataGridView1.DataSource = null;
                Image image2 = Image.FromFile("D:\\pratiti training\\Project\\Library Management System\\Library Management System\\icon and imgs\\icons8-student-male-100.png");
                pictureBoxMemberImg.Image = image2;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtsearchEnroll.Clear();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }



        private void btnReturnBook_Click(object sender, EventArgs e)
        {

            int enroll = int.Parse(txtsearchEnroll.Text);

            String rtdate = ReturnDateTimePicker1.Text;
            String bookName = txtBookName.Text;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select bQuan from NewBook where bName = '" + bookName + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            object quan = ds.Tables[0].Rows[0][0];
            Int64 quantity = Convert.ToInt64(quan);


            //update book return date 
            conn.Open();

            cmd.CommandText = "update IssueReturnBook SET Book_Return_Date = '" + rtdate + "' WHERE irID=" + id + "";
            cmd.ExecuteNonQuery();

            quantity++;
            cmd.CommandText = "update NewBook SET bQuan = " + quantity + " WHERE bName='" + bookName + "'";
            cmd.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("Book Return Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



            //refresh datagridview1

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = @"SELECT t1.irID, t2.mName, t2.mContact, t2.mEmail, t2.mPhoto, t3.bName, t1.Book_Issue_Date 
                                FROM IssueReturnBook t1
                                INNER JOIN NewMember t2 ON t1.MemberID = t2.mID
                                INNER JOIN NewBook t3 ON t1.BookID = t3.bId
                                WHERE t1.MemberID = " + enroll + " and t1.Book_Return_Date is Null";

            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            if (ds1.Tables[0].Rows.Count != 0)
            {

                dataGridView1.DataSource = ds1.Tables[0];
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("irID", "ID");
                dataGridView1.Columns.Add("bName", "Book Name");
                dataGridView1.Columns.Add("Book_Issue_Date", "Book Issue Date");
                dataGridView1.Columns[0].Width = 50;

                dataGridView1.Columns[0].DataPropertyName = "irID";
                dataGridView1.Columns[1].DataPropertyName = "bName";
                dataGridView1.Columns[2].DataPropertyName = "Book_Issue_Date";
            }
            else
            {
                dataGridView1.DataSource= null;
                dataGridView1.Columns.Add("irID", "ID");
                dataGridView1.Columns.Add("bName", "Book Name");
                dataGridView1.Columns.Add("Book_Issue_Date", "Book Issue Date");
                dataGridView1.Columns[0].Width = 50;


            }

            panel3.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
