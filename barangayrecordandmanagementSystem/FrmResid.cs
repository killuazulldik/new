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
    public partial class FrmResid : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        resident f;
        public string _id;
        public FrmResid(resident f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconnection.connection);
            this.f = f;
            LoadPurok();
        }
        public void LoadPurok()
        {
            try
            {
                cboPurok.Items.Clear();
                cn.Open();
                cmd = new SqlCommand("select * from  Table_purok", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cboPurok.Items.Add(dr["p_purok"].ToString());
                }
                dr.Close();
                cn.Close();

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

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to save this record?", var.title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MemoryStream ms = new MemoryStream();
                    picImage.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arrImage = ms.GetBuffer();
                    cn.Open();
                    cmd = new SqlCommand("insert into Table_Resident (nid, lname, fname, mname, alias, bday, bplace, age, civilstatus, gender, religion, email, contact, voters, precint, purok, education, occupation, address, category, house, head, disability, status, pic)values(@nid, @lname, @fname, @mname, @alias, @bday, @bplace, @age, @civilstatus, @gender, @religion, @email, @contact, @voters, @precint, @purok, @education, @occupation, @address, @category, @house, @head, @disability, @status, @pic) ", cn);
                    cmd.Parameters.AddWithValue("@nid", txtID.Text);
                    cmd.Parameters.AddWithValue("@lname", txtLname.Text);
                    cmd.Parameters.AddWithValue("@fname", txtFname.Text);
                    cmd.Parameters.AddWithValue("@mname", txtMname.Text);
                    cmd.Parameters.AddWithValue("@alias", txtAlias.Text);
                    cmd.Parameters.AddWithValue("@bday", dtBday.Value);
                    cmd.Parameters.AddWithValue("@bplace", txtBplace.Text);
                    cmd.Parameters.AddWithValue("@age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@civilstatus", cboCivil.Text);
                    cmd.Parameters.AddWithValue("@gender", cboGender.Text);
                    cmd.Parameters.AddWithValue("@religion", txtReligion.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@voters", cboVoter.Text);
                    cmd.Parameters.AddWithValue("@precint", txtPrecint.Text);
                    cmd.Parameters.AddWithValue("@purok", cboPurok.Text);
                    cmd.Parameters.AddWithValue("@education", txtEduc.Text);
                    cmd.Parameters.AddWithValue("@occupation", txtOccup.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@category", cboCatergory.Text);
                    cmd.Parameters.AddWithValue("@house", txtHouse.Text);
                    cmd.Parameters.AddWithValue("@head", txtHead.Text);
                    cmd.Parameters.AddWithValue("@disability", cboDisability.Text);
                    cmd.Parameters.AddWithValue("@status", cboStatus.Text);
                    cmd.Parameters.AddWithValue("@pic", arrImage);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record have been successfully saved!", var.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

        }

        private void FrmResid_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        
        }

        private void txtLname_TextChanged(object sender, EventArgs e)
        {
            lblName.Text = txtFname.Text + " " + txtMname.Text + " " + txtLname.Text;
        }
    }
}
