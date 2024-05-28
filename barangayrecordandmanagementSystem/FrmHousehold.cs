using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace barangayrecordandmanagementSystem
{
    public partial class FrmHousehold : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        FrmResident f;
        public FrmHousehold(FrmResident f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconnection.connection);
            this.f = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void Loadrecord()
        {

            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();
                cmd = new SqlCommand("select * from Table_Resident where (lname +', '+ fname +' '+ mname)  like '%" + txtSearch.Text + "%'and category like 'HOUSEHOLD HEAD'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["house"].ToString(), dr["lname"].ToString() + ", " + dr["fname"].ToString() + " " + dr["mname"].ToString(), dr["address"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView1.ClearSelection();
                lblCount.Text = "Record count(" + dataGridView1.RowCount + ")";
            }

            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Loadrecord();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colname == "btnSelect") {

                f.txtHouse.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                f.txtHead.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.Dispose();
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
