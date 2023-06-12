using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Library_Management_System
{
    
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        

      


        private void Dashboard_Load(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Transparent;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=LibraryDB;Integrated Security=True;Pooling=False";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT TOP 3 t1.bName, COUNT(t2.BookID) AS count FROM NewBook t1 JOIN IssueReturnBook t2 ON t1.bId = t2.BookID  GROUP BY t1.bName ORDER BY count DESC ";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                BooksdataGridView.DataSource = ds.Tables[0];
                BooksdataGridView.Columns.Clear();
                BooksdataGridView.Columns.Add("serialNumber", "Rank");
                BooksdataGridView.Columns.Add("bName", "Book Name");
                BooksdataGridView.Columns.Add("count", "Books Read Count");
                BooksdataGridView.Columns[0].Width = 60;
                BooksdataGridView.Columns[1].DataPropertyName = "bName";
                BooksdataGridView.Columns[1].Width = 200;
                BooksdataGridView.Columns[2].DataPropertyName = "count";

            }

            cmd.CommandText = "SELECT TOP 3 t1.mName, COUNT(MemberID) AS count FROM NewMember t1 JOIN IssueReturnBook t2 ON t1.mID = t2.MemberID where t2.Book_Return_Date is not null GROUP BY t1.mName ORDER BY count DESC ";

            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            if (ds1.Tables[0].Rows.Count != 0)
            {
                MemberdataGridView.DataSource = ds1.Tables[0];
                MemberdataGridView.Columns.Clear();
                MemberdataGridView.Columns.Add("serialNumber", "Rank");
                MemberdataGridView.Columns.Add("mName", "Member Name");
                MemberdataGridView.Columns.Add("count", "No. of Books Read");
                MemberdataGridView.Columns[1].DataPropertyName = "mName";
                MemberdataGridView.Columns[2].DataPropertyName = "count";
                MemberdataGridView.Columns[0].Width = 60;
                MemberdataGridView.Columns[1].Width = 200;

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to Exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Close all open forms except for the dashboard form
                for (int i = Application.OpenForms.Count - 1; i > 0; i--)
                {
                    if (Application.OpenForms[i] != this) // "this" refers to the dashboard form
                    {
                        Application.OpenForms[i].Close();
                    }
                }

                // Close the dashboard form
                this.Close();
            }
        }

       
        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "AddBooks")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                AddBooks abs = new AddBooks();
                abs.Show();
            }
        }


        private void viewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if(f.Text == "ViewBook")
                {
                    Isopen= true; 
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                ViewBook vb = new ViewBook();
                vb.Show();
            }
        }


        private void addMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "AddMember")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                AddMember addMember = new AddMember();
                addMember.Show();
            }
        }

        private void viewMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "ViewMember")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                ViewMember vm = new ViewMember();
                vm.Show();
              
            }
        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "IssueBook")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                IssueBook ib = new IssueBook();
                ib.Show();

            }

        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Return_Book")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                Return_Book rb = new Return_Book();
                rb.Show();

            }
            
        }

        private void completeBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "CompleteBookDetails")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                CompleteBookDetails cbd = new CompleteBookDetails();
                cbd.Show();
            }
            
        }


        private void BooksdataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if(e.RowIndex < 3)
            {
                DataGridViewRow row = BooksdataGridView.Rows[e.RowIndex];
                row.Cells["serialNumber"].Value = (e.RowIndex + 1).ToString();
            }
              
        }

        private void MemberdataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if(e.RowIndex < 3)
            {
                DataGridViewRow row = MemberdataGridView.Rows[e.RowIndex];
                row.Cells["serialNumber"].Value = (e.RowIndex + 1).ToString();
            }
        }

        private void BooksdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

       
        private void listOfReadedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "listofReadedBooks")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                listofReadedBooks lrb = new listofReadedBooks();
                lrb.Show();
            }
            
        }

        private void listOfMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "ListofMembers")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (Isopen == false)
            {
                ListofMembers lm = new ListofMembers();
                lm.Show();
            }
            
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Dashboard_Load(sender, e);
        }

        private void MemberdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
