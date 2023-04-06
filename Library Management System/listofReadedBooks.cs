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
    public partial class listofReadedBooks : Form
    {
        public listofReadedBooks()
        {
            InitializeComponent();
        }

        private void listofReadedBooks_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryManagement;Integrated Security=True;Pooling=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT t1.bName, t1.bAuthor, t1.bPubl, COUNT(t2.Book_Name) AS count FROM NewBook t1 JOIN IssueReturnBook t2 ON t1.bName = t2.Book_Name GROUP BY t1.bName, t1.bAuthor, t1.bPubl ORDER BY count DESC";



            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                bookListdataGridView.DataSource = ds.Tables[0];
                bookListdataGridView.Columns.Clear();
                bookListdataGridView.Columns.Add("serialNumber", "Sr.No.");
                bookListdataGridView.Columns.Add("bName", "Book Name");
                bookListdataGridView.Columns.Add("bAuthor", "Author Name");
                bookListdataGridView.Columns.Add("bPubl", "Publication Name");
                bookListdataGridView.Columns.Add("count", "Read Count");
                bookListdataGridView.Columns[0].Width = 60;
                bookListdataGridView.Columns[1].DataPropertyName = "bName";
               // bookListdataGridView.Columns[1].Width = 200;
                bookListdataGridView.Columns[2].DataPropertyName = "bAuthor";
                //bookListdataGridView.Columns[2].Width = 200;
                bookListdataGridView.Columns[3].DataPropertyName = "bPubl";
                bookListdataGridView.Columns[4].DataPropertyName = "count";

            }
        }

        private void bookListdataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewRow row = bookListdataGridView.Rows[e.RowIndex];
            row.Cells["serialNumber"].Value = (e.RowIndex + 1).ToString();
        }
    }
}
