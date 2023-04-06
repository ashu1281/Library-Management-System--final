using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library_Management_System
{
    public partial class IssueBook : Form
    {

        public IssueBook()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(IssueBook_MouseDown);
            this.MouseMove += new MouseEventHandler(IssueBook_MouseMove);
            this.MouseUp += new MouseEventHandler(IssueBook_MouseUp);
        }







        Int64 count = 0;
        private void btnSearchEnrollNo_Click(object sender, EventArgs e)
        {
            if (txtEnroll.Text != null)
            {

                String eid = txtEnroll.Text;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryManagement;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select * from NewMember where EnrollID = '" + eid + "'";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);



                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][4].ToString();

                    if (ds.Tables[0].Rows[0][8].ToString() != "")
                    {

                        // Get the image data from the result set
                        byte[] imageData = (byte[])ds.Tables[0].Rows[0][8];

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
                }
                else
                {
                    MessageBox.Show("This Enrollment Number does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //for finding count             
                cmd.CommandText = "select * from IssueReturnBook where EnrollId='" + eid + "' and Book_Return_Date is NULL ";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                count = Int64.Parse(ds1.Tables[0].Rows.Count.ToString());



                //exclude already issued books from combobox
                comboBoxBooks.Items.Clear();
                conn.Open();
                string sqlCommandText = string.Empty;
                sqlCommandText = "SELECT bName FROM NewBook WHERE bName NOT IN (SELECT Book_Name FROM IssueReturnBook WHERE EnrollID = '" + eid + "' and Book_Return_Date is NULL) ORDER BY bName ASC";

                cmd = new SqlCommand(sqlCommandText, conn);
                SqlDataReader Sdr = cmd.ExecuteReader();

                while (Sdr.Read())
                {
                    for (int i = 0; i < Sdr.FieldCount; i++)
                    {
                        comboBoxBooks.Items.Add(Sdr.GetString(i));
                    }
                }

                Sdr.Close();
                conn.Close();
            }
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {

        }

        private void txtEnroll_TextChanged(object sender, EventArgs e)
        {
            if (txtEnroll.Text == "")
            {
                txtName.Clear();
                txtContact.Clear();
                txtEmail.Clear();
                comboBoxBooks.Items.Clear();

                Image image2 = Image.FromFile("D:\\pratiti training\\Project\\Library Management System\\Library Management System\\icon and imgs\\icons8-student-male-100.png");
                pictureBoxMemberImg.Image = image2;

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnroll.Clear();
        }


        private void btnIssueBook_Click(object sender, EventArgs e)
        {




            if (txtName.Text != "")
            {
                if (comboBoxBooks.SelectedItem != null)
                {
                    if (count < 4)
                    {

                        String enroll = txtEnroll.Text;
                        String name = txtName.Text;
                        String contact = txtContact.Text;
                        String email = txtEmail.Text;
                        String bookName = comboBoxBooks.Text;
                        String issueDate = dateTimePicker1.Text;


                        SqlConnection conn = new SqlConnection();
                        conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryManagement;Integrated Security=True;Pooling=False";
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;

                        cmd.CommandText = "select bQuan from NewBook where bName = '" + bookName + "'";
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        object quan = ds.Tables[0].Rows[0][0];
                        Int64 quantity = Convert.ToInt64(quan);

                        if (quantity > 0)
                        {
                            quantity--;
                            conn.Open();
                            cmd.CommandText = "insert into IssueReturnBook (EnrollID,Member_Name,Member_Contact,Member_Email,Book_Name,Book_Issue_Date) values ('" + enroll + "','" + name + "','" + contact + "','" + email + "','" + bookName + "','" + issueDate + "')";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "update NewBook SET bQuan = " + quantity + " WHERE bName='" + bookName + "'";
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Book Issued Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btnRefresh_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Selceted Book is NOT available", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Issue Book limit exceeded for this member", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("First serach Member", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure, You want to Exit", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }

        }

        private bool isDragging = false;
        private Point lastLocation;
        private void IssueBook_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastLocation = e.Location;
        }

        private void IssueBook_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void IssueBook_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}
