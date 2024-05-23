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
    public partial class FrmResident : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public FrmResident()
        {
            InitializeComponent();
            cn = new SqlConnection(dbconnection.connection);
            LoadPurok();
        }
        public void LoadPurok()
        {
            try {
                cboPurok.Items.Clear();
                cn.Open();
                cmd = new SqlCommand("select * from  Table_purok",cn);
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    cboPurok.Items.Add(dr["p_purok"].ToString());
                }
                dr.Close();
                cn.Close();

            }
            catch (Exception ex) {

                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
        
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }   

        private void txtLname_TextChanged(object sender, EventArgs e)
        {
            lblName.Text = txtFname.Text + "" + txtMname.Text + "" + txtLname.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                openFileDialog1.Filter = "Image Files(*.png)|*.png|(*.jpg)|*.jpg|(*.gif)|*.gif";
                openFileDialog1.ShowDialog();
                picImage.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
