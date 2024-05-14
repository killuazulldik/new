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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            documents official = new documents();
            official.TopLevel = false;
            panelmain.Controls.Add(official);
            official.BringToFront();
            official.Dock = DockStyle.Fill;
            official.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int y = Screen.PrimaryScreen.Bounds.Height;
            int x = Screen.PrimaryScreen.Bounds.Width;
            this.Height = y - 40;
            this.Width = x;
            this.Left = 0;
            this.Top = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bgryofficials off = new bgryofficials();
            off.TopLevel = false;
            panelmain.Controls.Add(off);
            off.BringToFront();
            off.Dock = DockStyle.Fill;
            off.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
