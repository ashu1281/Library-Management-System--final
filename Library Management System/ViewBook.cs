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
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

        
        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible= false; 

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select * from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);

           DataSet ds = new DataSet();

            da.Fill(ds);

            if(ds.Tables[0].Rows.Count != 0)
            {
                
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Width = 60;
            }

        }

        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 1 && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null && dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()!="")
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                
                panel2.Visible = true;

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select * from NewBook where bId = "+bid+"";
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);


                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());


                txtbName.Text = ds.Tables[0].Rows[0][1].ToString();
                txtAuthor.Text = ds.Tables[0].Rows[0][2].ToString();
                txtPublication.Text = ds.Tables[0].Rows[0][3].ToString();
                txtPDate.Text = ds.Tables[0].Rows[0][4].ToString();
                txtPrice.Text = ds.Tables[0].Rows[0][5].ToString();
                txtQuantity.Text = ds.Tables[0].Rows[0][6].ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if(txtBookName.Text != "")
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select * from NewBook where bName LIKE '"+txtBookName.Text+"%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select * from NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBookName.Clear(); 

            panel2.Visible = false;

            ViewBook_Load(sender, e);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Data Will be Updated. Confirm?","Confirmation Dialog",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {

                String bname = txtbName.Text;
                String bauthor = txtAuthor.Text;
                String bpublication = txtPublication.Text;
                String bpurDate = txtPDate.Text;
                Int64 bprice = Int64.Parse(txtPrice.Text);
                Int64 bquantity = Int64.Parse(txtQuantity.Text);

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "update NewBook set bName = '" + bname + "' ,bAuthor = '" + bauthor + "' ,bPubl = '" + bpublication + "' ,bPurDate = '" + bpurDate + "', bPrice=" + bprice + ", bQuan = " + bquantity + " where bId = " + rowid + "";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Data Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewBook_Load(sender, e);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will be Deleted. Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                String bname = txtbName.Text;
                String bauthor = txtAuthor.Text;
                String bpublication = txtPublication.Text;
                String bpurDate = txtPDate.Text;
                Int64 bprice = Int64.Parse(txtPrice.Text);
                Int64 bquantity = Int64.Parse(txtQuantity.Text);

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "delete from NewBook where bId = "+rowid+" ";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Data Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewBook_Load(sender, e);
            }
        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
