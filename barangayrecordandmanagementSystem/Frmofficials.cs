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
    public partial class Frmofficials : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        bgryofficials b;
        public string _id;
        public Frmofficials(bgryofficials b)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconnection.connection);
            this.b = b;
        }

        private void Frmofficials_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to save this record?", var.title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cn.Open();
                    cmd = new SqlCommand("insert into Table_officials (off_name, off_committe, off_position, off_termstart, off_end, off_status)values(@off_name, @off_committe, @off_position, @off_termstart, @off_end, @off_status)", cn);
                    cmd.Parameters.AddWithValue("@off_name", txtName.Text);
                    cmd.Parameters.AddWithValue("@off_committe", cboCommittee.Text);
                    cmd.Parameters.AddWithValue("@off_position", cboPosition.Text);
                    cmd.Parameters.AddWithValue("@off_termstart", dtStart.Value);
                    cmd.Parameters.AddWithValue("@off_end", dtEnd.Value);
                    cmd.Parameters.AddWithValue("@off_status", cboStatus.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record successfully saved!", var.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    b.LoaderRecord();
                }
            }
            catch (Exception ex) {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            }
        }
        public void Clear() {
            txtName.Clear();
            cboCommittee.Text = "";
            cboPosition.Text = "";
            cboStatus.Text = "";
            dtStart.Value = DateTime.Today;
            dtEnd.Value = DateTime.Today;
            btnsave.Enabled = true;
            btnupdate.Enabled = false;
            txtName.Focus();


        }

        private void cboCommittee_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to update this record?", var.title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cn.Open();
                    cmd = new SqlCommand("update Table_officials set  off_name=@off_name, off_committe=@off_committe, off_position=@off_position, off_termstart=@off_termstart, off_end=@off_end, off_status=@off_status where off_id = @off_id", cn);
                    cmd.Parameters.AddWithValue("@off_name", txtName.Text);
                    cmd.Parameters.AddWithValue("@off_committe", cboCommittee.Text);
                    cmd.Parameters.AddWithValue("@off_position", cboPosition.Text);
                    cmd.Parameters.AddWithValue("@off_termstart", dtStart.Value);
                    cmd.Parameters.AddWithValue("@off_end", dtEnd.Value);
                    cmd.Parameters.AddWithValue("@off_status", cboStatus.Text);
                    cmd.Parameters.AddWithValue("@off_id",_id);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record successfully updated!", var.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    b.LoaderRecord();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
