using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barangayrecordandmanagementSystem
{
    public partial class resident : Form
    {
        public resident()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmResident f = new FrmResident();
            f.btnupdate.Enabled = false;
            f.ShowDialog();
        }
    }
}
