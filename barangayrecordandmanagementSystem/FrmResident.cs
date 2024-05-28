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
    public partial class FrmResident : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        resident f;
        public string _id;
       //    private resident resident;

        //private resident resident;

        public FrmResident(resident f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbconnection.connection);
            this.f = f;
            LoadPurok();
        }

        //public FrmResident(resident resident)
        //{
        //    this.resident = resident;
        //}

        //public FrmResident(resident resident)
        //{
        //    this.resident = resident;
        //}

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
            lblName.Text = txtFname.Text + " " + txtMname.Text + " " + txtLname.Text;
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

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try {
                if (MessageBox.Show("Do you want to save this record?", var.title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MemoryStream ms = new MemoryStream();
                    picImage.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arrImage = ms.GetBuffer();
                    cn.Open();
                    cmd = new SqlCommand("insert into Table_Resident (nid, lname, fname, mname, alias, bday, bplace, age, civilstatus, gender, religion, email, contact, voters, precint, purok, education, occupation, address, category, house, head, disability, status, pic)values(@nid, @lname, @fname, @mname, @alias, @bday, @bplace, @age, @civilstatus, @gender, @religion, @email, @contact, @voters, @precint, @purok, @education, @occupation, @address, @category, @house, @head, @disability, @status, @pic) ",cn);
                    cmd.Parameters.AddWithValue("@nid",txtID.Text);
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
                    MessageBox.Show("Record have been successfully saved!", var.title,MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.Loadrecord();
                }
            }
            catch (Exception ex) {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void picImage_Click(object sender, EventArgs e)
        {

        }

        private void cboCatergory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCatergory.Text == "HOUSEHOLD HEAD")
            {
                txtHouse.Enabled = true;
                btnBrows.Visible = false;
            }
            else {
                
                txtHouse.Enabled = false;
                btnBrows.Visible = true;
            }
        }

        private void cboVoter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVoter.Text == "YES")
            {
                txtPrecint.Enabled = true;
              
            }
            else
            {
                txtPrecint.Enabled = false;
                txtPrecint.Clear();
            }
        }

        private void FrmResident_Load(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to update this record?", var.title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MemoryStream ms = new MemoryStream();
                    picImage.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arrImage = ms.GetBuffer();
                    cn.Open();
                    cmd = new SqlCommand("update Table_Resident set nid=@nid, lname=@lname, fname=@fname, mname=@mname, alias=@alias, bday=@bday, bplace=@bplace, age=@age, civilstatus=@civilstatus, gender=@gender, religion=@religion, email=@email, contact=@contact, voters=@voters, precint=@precint, purok=@purok, education=@education, occupation=@occupation, address=@address, category=@category, house=@house, head=@head, disability=@disability, status=@status, pic=@pic where id=@id", cn);
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
                    cmd.Parameters.AddWithValue("@id", _id);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record have been successfully updated!", var.title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    f.Loadrecord();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, var.title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Clear() {

            picImage.BackgroundImage = Image.FromFile(Application.StartupPath + @"\profile.png");
            txtAddress.Clear();
            txtAge.Clear();
            txtAlias.Clear();
            txtContact.Clear();
            txtEduc.Clear();
            txtEmail.Clear(); 
            txtFname.Clear();
            txtHead.Clear();
            txtHouse.Clear();
            txtID.Clear();
            txtLname.Clear();
            txtMname.Clear();
            txtOccup.Clear();
            txtBplace.Clear();
            txtPrecint.Clear();
            txtReligion.Clear();
            cboCatergory.Text = "";
            cboCivil.Text = "";
            cboDisability.Text = "";
            cboGender.Text = "";
            cboPurok.Text = "";
            cboStatus.Text = "";
            cboVoter.Text = "";
            dtBday.Value = DateTime.Now;
            btnsave.Enabled = true;
            btnupdate.Enabled = false;
            txtID.Focus();

        }

        private void dtBday_ValueChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dtBday.Value.Year;
            txtAge.Text = age.ToString();

        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            FrmHousehold f = new FrmHousehold(this);
            f.Loadrecord();
            f.ShowDialog();
        }
    }
    }

