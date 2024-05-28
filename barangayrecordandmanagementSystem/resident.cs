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
using System.IO;
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
            f.Clear();
            f.ShowDialog();
        }
        public void Loadrecord() {

            try {
                dataGridView1.Rows.Clear();
                cn.Open();
                cmd = new SqlCommand("select * from Table_Resident where lname like '%" +txtsearch1.Text +"%' or fname like '%"+txtsearch1.Text+"%'",cn);
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["nid"].ToString(), dr["lname"].ToString(), dr["fname"].ToString(), dr["mname"].ToString(), dr["alias"].ToString(), dr["address"].ToString(), dr["house"].ToString(), dr["category"].ToString(), DateTime.Parse(dr["bday"].ToString()).ToShortDateString(), dr["gender"].ToString(), dr["age"].ToString(), dr["civilstatus"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView1.ClearSelection();
                lblVoters.Text = CountRecords("select count (*) from Table_Resident where voters like 'YES'");
                lblCount.Text = CountRecords("select count (*) from Table_Resident");
                lblHousehold.Text = CountRecords("select count (*) from Table_Resident where category like 'HOUSEHOLD HEAD'");
                lblMember.Text = CountRecords("select count (*) from Table_Resident where category like 'MEMBER'");
                lblFemale.Text = CountRecords("select count (*) from Table_Resident where gender like 'FEMALE'");
                lblMale.Text = CountRecords("select count (*) from Table_Resident where gender like 'MALE'");
                lblVaccine.Text = CountRecords("select count (*) from Table_Vaccine where status like 'FULLY VACCINATED'");
            }
            
            catch (Exception ex) {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void LoadHead()
        {

            try
            {
                dataGridView2.Rows.Clear();
                cn.Open();
                cmd = new SqlCommand("select * from Table_Resident where (lname like '%" + txtsearch2.Text + "%' or fname like '%" + txtsearch2.Text + "%') and category like 'HOUSEHOLD HEAD'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView2.Rows.Add(dr["id"].ToString(), dr["nid"].ToString(), dr["lname"].ToString(), dr["fname"].ToString(), dr["mname"].ToString(), dr["alias"].ToString(), dr["address"].ToString(), dr["house"].ToString(), dr["category"].ToString(), DateTime.Parse(dr["bday"].ToString()).ToShortDateString(), dr["gender"].ToString(), dr["age"].ToString(), dr["civilstatus"].ToString());
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
        public void LoadVaccine()
        {

            try
            {
                dataGridView3.Rows.Clear();
                cn.Open();
                cmd = new SqlCommand("select * from vwvaccination where (lname like '%" + txtsearch3.Text + "%' or fname like '%" + txtsearch3.Text + "%') and status like '" + cboFilter.Text + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView3.Rows.Add(dr["id"].ToString(), dr["lname"].ToString(), dr["fname"].ToString(), dr["mname"].ToString(), dr["vaccine"].ToString(), dr["status"].ToString());
                }
                dr.Close();
                cn.Close();
                dataGridView3.ClearSelection();

            }

            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public string CountRecords(string sql) {
            cn.Open();
            cmd = new SqlCommand(sql,cn);
            string _count = cmd.ExecuteScalar().ToString();
            cn.Close();
            return _count;
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                string colname = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colname == "btnedite")

                {
                    FrmResident f = new FrmResident(this);
                    f.LoadPurok();
                    cn.Open();
                    cmd = new SqlCommand("select pic as picture,* from Table_Resident where id like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'",cn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        long len = dr.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                        dr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));

                        f._id = dr["id"].ToString();
                        f.txtID.Text = dr["nid"].ToString();
                        f.txtLname.Text = dr["lname"].ToString();
                        f.txtFname.Text = dr["fname"].ToString();
                        f.txtMname.Text = dr["mname"].ToString();
                        f.txtAddress.Text = dr["address"].ToString();
                        f.txtAge.Text = dr["age"].ToString();
                        f.txtAlias.Text = dr["alias"].ToString();
                        f.txtContact.Text = dr["contact"].ToString();
                        f.txtEduc.Text = dr["education"].ToString();
                        f.txtEmail.Text = dr["email"].ToString();
                        f.txtHead.Text = dr["head"].ToString();
                        f.txtHouse.Text = dr["house"].ToString();
                        f.txtOccup.Text = dr["occupation"].ToString();
                        f.txtBplace.Text = dr["bplace"].ToString();
                        f.txtPrecint.Text = dr["precint"].ToString();
                        f.txtReligion.Text = dr["religion"].ToString();
                        f.cboCatergory.Text = dr["category"].ToString();
                        f.cboCivil.Text = dr["civilstatus"].ToString();
                        f.cboDisability.Text = dr["disability"].ToString();
                        f.cboGender.Text = dr["gender"].ToString();
                        f.cboPurok.Text = dr["purok"].ToString();
                        f.cboStatus.Text = dr["status"].ToString();
                        f.cboVoter.Text = dr["voters"].ToString();
                        f.dtBday.Value = DateTime.Parse(dr["bday"].ToString());

                        MemoryStream ms = new MemoryStream(array);
                        Bitmap bitmap = new Bitmap(ms);
                        f.picImage.BackgroundImage = bitmap;
                        f.btnsave.Enabled = false;
                    } 
                 
                    f.ShowDialog();
                    dr.Close();
                    cn.Close();
                    

                }
                else if (colname == "btndelete")
                {
                    if (MessageBox.Show("Do want to deleted this record?", var.title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cmd = new SqlCommand("delete from Table_Resident where id like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been seccussfully deleted!", var.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Loadrecord();
                    }
                }
            }
            catch (Exception ex) {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblCount_Click(object sender, EventArgs e)
        {

        }

        private void lbHousehold_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void s_TextChanged(object sender, EventArgs e)
        {
            Loadrecord();
        }

        private void txtsearch1_TextChanged(object sender, EventArgs e)
        {
            Loadrecord();
        }

        private void txtsearch2_TextChanged(object sender, EventArgs e)
        {
            LoadHead();
        }

        private void txtsearch2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {

                string colname = dataGridView2.Columns[e.ColumnIndex].Name;
                if (colname == "btnView")
                {
                    string _id = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    FrmViewHousehold f = new FrmViewHousehold(this);
                    cn.Open();
                    cmd = new SqlCommand("select (lname + ', '+fname+' '+mname) as fullname, house from Table_Resident where id =@id",cn);
                    cmd.Parameters.AddWithValue("@id",_id);
                    dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        f.lblHouseNo.Text = dr["house"].ToString();
                        f.lblName.Text = dr["fullname"].ToString();

                    }
                    dr.Close();
                    cn.Close();
                    f.Loadrecord();
                    f.ShowDialog();
            

                }
            }
            catch (Exception ex) {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView3.Columns[e.ColumnIndex].Name;
           
                if (colname == "btneditVaccine") {

                FrmVaccine f = new FrmVaccine(this);
                f._id = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                f.lblName.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString() +", "+ dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString()+" "+ dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                   f.txtVaccine.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
                f.cboStatus.Text = dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
                f.ShowDialog();
            }
        }

        private void txtsearch3_TextChanged(object sender, EventArgs e)
        {
            LoadVaccine();
        }

        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVaccine();
        }
    }
}
