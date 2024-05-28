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
    public partial class FrmVaccine : Form
    {
        SqlConnection cn;   
        SqlCommand cmd;
        resident f;

        public string _id;
        public FrmVaccine(resident f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconnection.connection);
            this.f = f;
        }

        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try {
                if (MessageBox.Show("Do you want to save changes?", var.title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (checkDulicate("select count(*) from Table_Vaccine where rid like '"+ _id+"'") == true)
                    {
                        cn.Open();
                        cmd = new SqlCommand("update Table_Vaccine set vaccine =@vaccine, status =@status where rid =@rid ", cn);
                        cmd.Parameters.AddWithValue("@vaccine", txtVaccine.Text);
                        cmd.Parameters.AddWithValue("@status", cboStatus.Text);
                        cmd.Parameters.AddWithValue("@rid", _id);
                        cmd.ExecuteNonQuery();
                        cn.Close();

                    }
                    else {  

                        cn.Open();
                        cmd = new SqlCommand("insert into Table_Vaccine (rid,vaccine,status)Values (@rid, @vaccine, @status)", cn);
                        cmd.Parameters.AddWithValue("@rid", _id);
                        cmd.Parameters.AddWithValue("@vaccine", txtVaccine.Text);
                        cmd.Parameters.AddWithValue("@status", cboStatus.Text);   
                        cmd.ExecuteNonQuery();
                        cn.Close();

                    }
                    MessageBox.Show("Record had been successfully saved!", var.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadVaccine();
                    f.Loadrecord();
                    this.Dispose();
                    
                }

            }
            catch (Exception ex) {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool checkDulicate(string sql) {
            bool duplicate = false;

            try
            {
                cn.Open();
                cmd = new SqlCommand(sql,cn);
                int count = int.Parse(cmd.ExecuteScalar().ToString());
                cn.Close();
                if (count == 0) duplicate = false;  else  duplicate = true; 
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return duplicate;
        }
    }
}
