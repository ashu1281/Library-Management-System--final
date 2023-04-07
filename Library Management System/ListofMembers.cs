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
    public partial class ListofMembers : Form
    {
        public ListofMembers()
        {
            InitializeComponent();
        }

        private void ListofMembers_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryManagement;Integrated Security=True;Pooling=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            //cmd.CommandText = "SELECT Member_Name, COUNT(Book_Name) AS count FROM IssueReturnBook GROUP BY Member_Name ORDER BY count DESC";
            cmd.CommandText = "SELECT t1.mName, t1.mContact,t1.mCity, COUNT(t2.Book_Name) AS count FROM NewMember t1 JOIN IssueReturnBook t2 ON t1.EnrollID = t2.EnrollID GROUP BY t1.mName, t1.mContact, t1.mCity ORDER BY count DESC";



            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                MemberListdataGridView.DataSource = ds.Tables[0];
                MemberListdataGridView.Columns.Clear();
                MemberListdataGridView.Columns.Add("serialNumber", "Sr.No.");
                MemberListdataGridView.Columns.Add("mName", "Member Name");
                MemberListdataGridView.Columns.Add("mContact", "Member Contact");
                MemberListdataGridView.Columns.Add("mCity", "Member City");
           
                MemberListdataGridView.Columns.Add("count", "No. of Books borrowed");
                MemberListdataGridView.Columns[0].Width = 60;
                MemberListdataGridView.Columns[1].DataPropertyName = "mName";
                MemberListdataGridView.Columns[2].DataPropertyName = "mContact";
                MemberListdataGridView.Columns[3].DataPropertyName = "mCity";                             
                MemberListdataGridView.Columns[4].DataPropertyName = "count";

            }
        }

        

        private void MemberListdataGridView_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = MemberListdataGridView.Rows[e.RowIndex];
            row.Cells["serialNumber"].Value = (e.RowIndex + 1).ToString();
        }
    }
}
