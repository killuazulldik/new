﻿using System;
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
    public partial class bgryofficials : Form
    {
        public bgryofficials()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frmofficials frmoff = new Frmofficials();
            frmoff.ShowDialog();
        }
    }
}
