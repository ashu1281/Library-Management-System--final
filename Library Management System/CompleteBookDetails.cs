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
    public partial class CompleteBookDetails : Form
    {
        public CompleteBookDetails()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int enroll=int.Parse(txtSearchEnroll.Text);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            //cmd.CommandText = "select EnrollID,Member_Name,Book_Name,Book_Issue_Date from IssueReturnBook where EnrollID='"+enroll+ "' and Book_Return_Date is NULL";
         
            cmd.CommandText = @"SELECT t2.mName, t3.bName, t1.Book_Issue_Date
                                FROM IssueReturnBook t1
                                INNER JOIN NewMember t2 ON t1.MemberID = t2.mID
                                INNER JOIN NewBook t3 ON t1.BookID = t3.bId
                                WHERE t1.MemberID = " + enroll + " and t1.Book_Return_Date is Null";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0 )
            {
                txtMemberName.Text = ds.Tables[0].Rows[0][0].ToString();

                issuedBooksdataGridView1.DataSource = ds.Tables[0];
                issuedBooksdataGridView1.Columns.Clear();
                issuedBooksdataGridView1.Columns.Add("serialNumber", "Sr.No.");
                issuedBooksdataGridView1.Columns.Add("bName", "Book Name");
                issuedBooksdataGridView1.Columns.Add("Book_Issue_Date", "Book Issue Date");
                issuedBooksdataGridView1.Columns[1].DataPropertyName = "bName";
                issuedBooksdataGridView1.Columns[2].DataPropertyName = "Book_Issue_Date";

                issuedBooksdataGridView1.Columns[0].Width = 70;

                // Add the new column for Due Amount
                issuedBooksdataGridView1.Columns.Add("dueAmount", "Due Amount");

                // Calculate and populate the Due Amount values
                foreach (DataGridViewRow row in issuedBooksdataGridView1.Rows)
                {
                    DateTime issueDate = DateTime.Parse(row.Cells["Book_Issue_Date"].Value.ToString());
                    DateTime currentDate = DateTime.Now;
                    TimeSpan difference = currentDate - issueDate;
                    int daysDifference = (int)difference.TotalDays;

                    if (daysDifference > 10)
                    {
                        // Overdue per day is rs. 5 
                        int dueAmount = (daysDifference - 10) * 5;
                        row.Cells["dueAmount"].Value = dueAmount;

                        // Set the cell's style to red if due amount is greater than 0
                        if (row.Cells["dueAmount"].Style != null)
                        {
                            row.Cells["dueAmount"].Style.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        row.Cells["dueAmount"].Value = 0;
                    }
                }


            }


            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = conn;

            //cmd1.CommandText = "select EnrollID,Member_Name,Book_Name,Book_Issue_Date,Book_Return_Date from IssueReturnBook where EnrollID='" + enroll + "' and Book_Return_Date is NOT NULL";

            cmd1.CommandText = @"SELECT t3.bName, t1.Book_Issue_Date, t1.Book_Return_Date
                                FROM IssueReturnBook t1
                                INNER JOIN NewMember t2 ON t1.MemberID = t2.mID
                                INNER JOIN NewBook t3 ON t1.BookID = t3.bId
                                WHERE t1.MemberID = " + enroll + " and t1.Book_Return_Date is NOT NULL";

            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            if (ds1.Tables[0].Rows.Count != 0)
            {

                returnedBooksdataGridView2.DataSource = ds1.Tables[0];
                returnedBooksdataGridView2.Columns.Clear();
                returnedBooksdataGridView2.Columns.Add("serialNumber", "Sr.No.");
                returnedBooksdataGridView2.Columns.Add("bName", "Book Name");
                returnedBooksdataGridView2.Columns.Add("Book_Issue_Date", "Book Issue Date");
                returnedBooksdataGridView2.Columns.Add("Book_Return_Date", "Book Return Date");

                returnedBooksdataGridView2.Columns[1].DataPropertyName = "bName";
                returnedBooksdataGridView2.Columns[2].DataPropertyName = "Book_Issue_Date";
                returnedBooksdataGridView2.Columns[3].DataPropertyName = "Book_Return_Date";

                returnedBooksdataGridView2.Columns[0].Width = 70;
            }
        }

        private void txtSearchEnroll_TextChanged(object sender, EventArgs e)
        {
            
            issuedBooksdataGridView1.Columns.Clear();
            returnedBooksdataGridView2.Columns.Clear();
            txtMemberName.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchEnroll.Clear();
        }

        private void CompleteBookDetails_Load(object sender, EventArgs e)
        {


        }

        private void issuedBooksdataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = issuedBooksdataGridView1.Rows[e.RowIndex];
            row.Cells["serialNumber"].Value = (e.RowIndex + 1).ToString();
        }

        private void returnedBooksdataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = returnedBooksdataGridView2.Rows[e.RowIndex];
            row.Cells["serialNumber"].Value = (e.RowIndex+1).ToString();
        }

        private void issuedBooksdataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
