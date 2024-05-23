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
    public partial class resident : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public resident()
        {
            

            InitializeComponent();
            cn = new SqlConnection(dbconnection.connection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmResident f = new FrmResident(this);
            f.btnupdate.Enabled = false;
            f.ShowDialog();
        }
        public void Loadrecord() {

            try {
                dataGridView1.Rows.Clear();
                cn.Open();
                cmd = new SqlCommand("select * from Table_Resident",cn);
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["nid"].ToString(), dr["lname"].ToString(), dr["fname"].ToString(), dr["mname"].ToString(), dr["alias"].ToString(), dr["address"].ToString(), dr["house"].ToString(), dr["category"].ToString(), DateTime.Parse(dr["bday"].ToString()).ToShortDateString(), dr["civilstatus"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView1.ClearSelection();
            }
            
            catch (Exception ex) {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                string colname = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colname == "btnedite")

                {
                    FrmResident f = new FrmResident(this);
                    cn.Open();
                    cmd = new SqlCommand("select * from Table_Resident where id like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'",cn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        f._id = dr["id"].ToString();
                        f.txtID.Text = dr["nid"].ToString();
                        f.txtLname.Text = dr["lname"].ToString();
                        f.txtFname.Text = dr["fname"].ToString();
                        f.txtMname.Text = dr["mname"].ToString();


                    }
                    else {

                        MessageBox.Show("error");
                        
                    }
                    f.ShowDialog();
                    dr.Close();
                    cn.Close();
                    

                }
            }
            catch (Exception ex) {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
