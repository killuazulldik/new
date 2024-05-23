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
    public partial class Frmpurok : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        bgryofficials b;
        public string _purok;
        public Frmpurok(bgryofficials b)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconnection.connection);
            this.b = b; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        public void Clear()
        {
            txtPurok.Clear();
            txtChairman.Clear();
            btnsave.Enabled = true;
            btnupdate.Enabled = false;
            txtPurok.Focus();
        
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to save this record?", var.title,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("insert  into Table_purok (p_purok, p_chairman)values(@p_purok, @p_chairman)", cn);
                    cmd.Parameters.AddWithValue("@p_purok", txtPurok.Text);
                    cmd.Parameters.AddWithValue("@p_chairman", txtChairman.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Recond has been successfully saved!", var.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    b.LoaderPurok();
                    Clear();
                }

            }
            catch (Exception ex) 
            {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to update this record?", var.title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("update Table_purok set p_purok=@p_purok, p_chairman=@p_chairman where p_purok = @purok1", cn);
                    cmd.Parameters.AddWithValue("@p_purok", txtPurok.Text);
                    cmd.Parameters.AddWithValue("@p_chairman", txtChairman.Text);
                    cmd.Parameters.AddWithValue("@purok1", _purok);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Recond has been successfully updated!", var.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    b.LoaderPurok();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Frmpurok_Load(object sender, EventArgs e)
        {

        }
    }
}
