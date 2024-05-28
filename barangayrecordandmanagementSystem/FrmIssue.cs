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
    public partial class FrmIssue : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public FrmIssue()
        {
            InitializeComponent();
            cn = new SqlConnection(dbconnection.connection);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBlotter f = new FrmBlotter(this);
            f.lblFile.Text = f.GetFileNO();
            f.btnupdate.Enabled = false;
            f.ShowDialog();
        }
        public void LoadRecords() {

            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();
                cmd = new SqlCommand("select * from Table_Blotters ",cn);
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["fileno"].ToString(), dr["barangay"].ToString(), dr["purok"].ToString(), dr["incident"].ToString(), dr["place"].ToString(), DateTime.Parse(dr["idate"].ToString()).ToShortDateString(), dr["itime"].ToString(), dr["complainant"].ToString(), dr["witness1"].ToString(), dr["witness2"].ToString(), dr["narrative"].ToString(), dr["status"].ToString());
                }
                cn.Close();
                dataGridView1.ClearSelection();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                string colname = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colname == "btnedite") {
                    FrmBlotter f = new FrmBlotter(this);
                    f._id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    f.lblFile.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    f.txtBarangay.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    f.txtPurok.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    f.txtIncident.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    f.txtPlace.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    f.dtDate.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                    f.txtTime.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    f.txtComplainant.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                    f.txtWitness1.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                    f.txtWitness2.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                    f.txtNarrative.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                    f.btnsave.Enabled = false;
                    f.ShowDialog();
                } else if (colname == "btndelete") {
                    if (MessageBox.Show("Do you want to delete this record?", var.title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes) {

                        cn.Open();
                        cmd = new SqlCommand("delete from Table_Blotters where id like '"+dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()+ "'",cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();

                        MessageBox.Show("Record has been successfully deleted!", var.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRecords();
                    }
                
                }
             
            }
            catch (Exception ex) {
                cn.Close();
                MessageBox.Show(ex.Message,var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
