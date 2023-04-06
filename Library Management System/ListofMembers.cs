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

            cmd.CommandText = "SELECT Member_Name,Member_Contact,Member_Email, COUNT(Book_Name) AS count FROM IssueReturnBook GROUP BY Member_Name,Member_Contact,Member_Email ORDER BY count DESC";



            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                MemberListdataGridView.DataSource = ds.Tables[0];
                MemberListdataGridView.Columns.Clear();
                MemberListdataGridView.Columns.Add("serialNumber", "Sr.No.");
                MemberListdataGridView.Columns.Add("Member_Name", "Member Name");
                MemberListdataGridView.Columns.Add("Member_Contact", "Member Contact");
                MemberListdataGridView.Columns.Add("Member_Email", "Member Email");
                MemberListdataGridView.Columns.Add("count", "No. of Books borrowed");
                MemberListdataGridView.Columns[0].Width = 60;
                MemberListdataGridView.Columns[1].DataPropertyName = "Member_Name";
                // MemberListdataGridView.Columns[1].Width = 200;
                MemberListdataGridView.Columns[2].DataPropertyName = "Member_Contact";
                //MemberListdataGridView.Columns[2].Width = 200;
                MemberListdataGridView.Columns[3].DataPropertyName = "Member_Email";
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
