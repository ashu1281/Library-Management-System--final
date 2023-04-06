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
            string enroll=txtSearchEnroll.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryManagement;Integrated Security=True;Pooling=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select EnrollID,Member_Name,Book_Name,Book_Issue_Date from IssueReturnBook where EnrollID='"+enroll+ "' and Book_Return_Date is NULL";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0 )
            {
                issuedBooksdataGridView1.Columns.Add("serialNumber", "Sr.No.");
                issuedBooksdataGridView1.DataSource = ds.Tables[0];
                issuedBooksdataGridView1.Columns[0].Width = 70;
            }
            

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = conn;

            cmd1.CommandText = "select EnrollID,Member_Name,Book_Name,Book_Issue_Date,Book_Return_Date from IssueReturnBook where EnrollID='" + enroll + "' and Book_Return_Date is NOT NULL";

            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            if (ds1.Tables[0].Rows.Count != 0)
            {
                returnedBooksdataGridView2.Columns.Add("serialNumber", "Sr.No.");
                returnedBooksdataGridView2.DataSource = ds1.Tables[0];
                returnedBooksdataGridView2.Columns[0].Width = 70;
            }
        }

        private void txtSearchEnroll_TextChanged(object sender, EventArgs e)
        {
            issuedBooksdataGridView1.DataSource = null;
            returnedBooksdataGridView2.DataSource = null;    
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
    }
}
