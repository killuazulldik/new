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
    public partial class FrmBlotter : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        FrmIssue f;
        public string _id;
        public FrmBlotter(FrmIssue f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconnection.connection);
            this.f = f;
        }
        public string  GetFileNO() {

           
            string fileno = "CASE-";
            Random rnd = new Random();

            for (int x=0; x<6; x++) {
                fileno += rnd.Next(1,9).ToString();
            }
            try {
                cn.Open();
                cmd = new SqlCommand("select top 1 fileno from Table_Blotters where fileno like '" + fileno + "%' order by id desc",cn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    lblFile.Text = GetFileNO();
                    dr.Close();
                    cn.Close();

                }
                else {
                    dr.Close();
                    cn.Close();
                }
              

            }
            catch (Exception ex) {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            }
            return fileno;
        
        }
        private void label4_Click(object sender, EventArgs e)
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
                if (MessageBox.Show("Do you want to save this Blotter?", var.title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes) {
                    cn.Open();
                    cmd = new SqlCommand("insert into Table_Blotters (fileno, barangay, purok, incident, place, idate, itime, complainant, witness1, witness2, narrative )values (@fileno, @barangay, @purok, @incident, @place, @idate, @itime, @complainant, @witness1, @witness2, @narrative)", cn);
                    cmd.Parameters.AddWithValue("@fileno", lblFile.Text);
                    cmd.Parameters.AddWithValue("@barangay", txtBarangay.Text);
                    cmd.Parameters.AddWithValue("@purok", txtPurok.Text);
                    cmd.Parameters.AddWithValue("@incident", txtIncident.Text);
                    cmd.Parameters.AddWithValue("@place", txtPlace.Text);
                    cmd.Parameters.AddWithValue("@idate", DateTime.Parse(dtDate.Value.ToLongDateString()));
                    cmd.Parameters.AddWithValue("@itime", txtTime.Text);
                    cmd.Parameters.AddWithValue("@complainant", txtComplainant.Text);
                    cmd.Parameters.AddWithValue("@witness1", txtWitness1.Text);
                    cmd.Parameters.AddWithValue("@witness2", txtWitness2.Text);
                    cmd.Parameters.AddWithValue("@narrative", txtNarrative.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully saved!", var.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.LoadRecords();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Clear() {

            txtBarangay.Clear();
            txtComplainant.Clear();
            txtIncident.Clear();
            txtNarrative.Clear();
            txtPlace.Clear();
            txtPurok.Clear();
            txtTime.Clear();
            txtWitness1.Clear();
            txtWitness2.Clear();
            dtDate.Value = DateTime.Now;
            btnsave.Enabled = true;
            btnupdate.Enabled = false;
            txtBarangay.Focus();
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtIncident_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FrmBlotter_Load(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to update this Blotter?", var.title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("update Table_Blotters set barangay=@barangay, purok=@purok, incident=@incident, place=@place, idate=@idate, itime=@itime, complainant=@complainant, witness1=@witness1, witness2=@witness2, narrative=@narrative where id=@id ", cn);
                   
                    cmd.Parameters.AddWithValue("@barangay", txtBarangay.Text);
                    cmd.Parameters.AddWithValue("@purok", txtPurok.Text);
                    cmd.Parameters.AddWithValue("@incident", txtIncident.Text);
                    cmd.Parameters.AddWithValue("@place", txtPlace.Text);
                    cmd.Parameters.AddWithValue("@idate", DateTime.Parse(dtDate.Value.ToLongDateString()));
                    cmd.Parameters.AddWithValue("@itime", txtTime.Text);
                    cmd.Parameters.AddWithValue("@complainant", txtComplainant.Text);
                    cmd.Parameters.AddWithValue("@witness1", txtWitness1.Text);
                    cmd.Parameters.AddWithValue("@witness2", txtWitness2.Text);
                    cmd.Parameters.AddWithValue("@narrative", txtNarrative.Text);
                    cmd.Parameters.AddWithValue("@id", _id);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record has been successfully updated!", var.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.LoadRecords();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
