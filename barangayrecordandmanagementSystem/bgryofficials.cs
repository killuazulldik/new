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
    public partial class bgryofficials : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public bgryofficials()
        {
            InitializeComponent();
            cn = new SqlConnection(dbconnection.connection);

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }
        //method
        public void LoaderRecord()
        {
            try {
                dataGridView1.Rows.Clear();
                cn.Open();
                cmd = new SqlCommand("select * from Table_officials",cn);
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    dataGridView1.Rows.Add(dr["off_id"].ToString(), dr["off_name"].ToString(), dr["off_committe"].ToString(), dr["off_position"].ToString(), DateTime.Parse(dr["off_termstart"].ToString()).ToShortDateString(),DateTime.Parse(dr["off_end"].ToString()).ToShortDateString(), dr["off_status"].ToString());
                }
                
                dr.Close();
                cn.Close();
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void LoaderPurok()
        {
            try
            {
                dataGridView2.Rows.Clear();
                cn.Open();
                cmd = new SqlCommand("select * from Table_purok", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView2.Rows.Add( dr["p_purok"].ToString(), dr["p_chairman"].ToString());
                }

                dr.Close();
                cn.Close();
                dataGridView2.ClearSelection();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frmofficials frmoff = new Frmofficials(this);
            frmoff.btnupdate.Enabled = false;
            frmoff.ShowDialog();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colname = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colname == "btnedit")
                {
                    Frmofficials off = new Frmofficials(this);
                    off.btnsave.Enabled = false;
                    off._id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    off.txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    off.cboCommittee.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    off.cboPosition.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    off.dtStart.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    off.dtEnd.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    off.cboStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    off.ShowDialog();
                }
                else if (colname == "btndelete")
                {
                    if (MessageBox.Show("Do you want to delete?", var.title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cmd = new SqlCommand("delete from Table_officials where off_id like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Recond has been successfully deleted !", var.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoaderRecord();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colname = dataGridView2.Columns[e.ColumnIndex].Name;
                if (colname == "btnedit2")
                {
                    Frmpurok off = new Frmpurok(this);
                    off.btnsave.Enabled = false;
                    off._purok = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    off.txtPurok.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    off.txtChairman.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    off.ShowDialog();
                }
                else if (colname == "btndelete2")
                {
                    if (MessageBox.Show("Do you want to delete?", var.title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cmd = new SqlCommand("delete from Table_purok where p_purok like '" + dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Recond has been successfully deleted !", var.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoaderPurok();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frmpurok f = new Frmpurok(this);
            f.btnupdate.Enabled = false;
            f.ShowDialog();
        }
    }
}
