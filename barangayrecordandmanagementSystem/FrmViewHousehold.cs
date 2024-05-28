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

    public partial class FrmViewHousehold : Form
    {
        resident f;
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public FrmViewHousehold(resident f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconnection.connection);
            this.f = f;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Loadrecord()
        {
            try {
                dataGridView1.Rows.Clear();
                cn.Open();
                cmd = new SqlCommand("select id,address, (lname + ', '+fname+' '+mname) as fullname, bday from Table_Resident where house like '344' and category like 'MEMBER'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["fullname"].ToString(), DateTime.Parse(dr["bday"].ToString()).ToShortDateString(), dr["address"].ToString());
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

        }
    }
}
