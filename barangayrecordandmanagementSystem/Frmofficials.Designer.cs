
namespace barangayrecordandmanagementSystem
{
    partial class Frmofficials
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmofficials));
            this.txtName = new MetroFramework.Controls.MetroTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.htmlLabel2 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.cboCommittee = new MetroFramework.Controls.MetroComboBox();
            this.cboPosition = new MetroFramework.Controls.MetroComboBox();
            this.htmlLabel3 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.htmlLabel4 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.dtStart = new MetroFramework.Controls.MetroDateTime();
            this.dtEnd = new MetroFramework.Controls.MetroDateTime();
            this.htmlLabel5 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.cboStatus = new MetroFramework.Controls.MetroComboBox();
            this.htmlLabel6 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.htmlLabel1 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.CustomButton.Image = null;
            this.txtName.CustomButton.Location = new System.Drawing.Point(308, 2);
            this.txtName.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.CustomButton.Name = "";
            this.txtName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtName.CustomButton.TabIndex = 1;
            this.txtName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtName.CustomButton.UseSelectable = true;
            this.txtName.CustomButton.Visible = false;
            this.txtName.Lines = new string[0];
            this.txtName.Location = new System.Drawing.Point(35, 90);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.MaxLength = 32767;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtName.SelectedText = "";
            this.txtName.SelectionLength = 0;
            this.txtName.SelectionStart = 0;
            this.txtName.ShortcutsEnabled = true;
            this.txtName.Size = new System.Drawing.Size(332, 26);
            this.txtName.TabIndex = 1;
            this.txtName.UseSelectable = true;
            this.txtName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(55)))), ((int)(((byte)(42)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 35);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(307, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "  CLOSE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "BRGY. OFFICAILS";
            // 
            // htmlLabel2
            // 
            this.htmlLabel2.AutoScroll = true;
            this.htmlLabel2.AutoScrollMinSize = new System.Drawing.Size(82, 23);
            this.htmlLabel2.AutoSize = false;
            this.htmlLabel2.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel2.Location = new System.Drawing.Point(35, 136);
            this.htmlLabel2.Name = "htmlLabel2";
            this.htmlLabel2.Size = new System.Drawing.Size(94, 27);
            this.htmlLabel2.TabIndex = 3;
            this.htmlLabel2.Text = "COMMITTEE :";
            // 
            // cboCommittee
            // 
            this.cboCommittee.FormattingEnabled = true;
            this.cboCommittee.ItemHeight = 23;
            this.cboCommittee.Items.AddRange(new object[] {
            "COMMITTEE OF AGRI",
            "COMMITTEE OF FINANCE",
            "COMMITTEE OF HEALTH",
            "COMMITTEE OF SAMPLE"});
            this.cboCommittee.Location = new System.Drawing.Point(35, 165);
            this.cboCommittee.Name = "cboCommittee";
            this.cboCommittee.Size = new System.Drawing.Size(332, 29);
            this.cboCommittee.TabIndex = 4;
            this.cboCommittee.UseSelectable = true;
            this.cboCommittee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCommittee_KeyPress);
            // 
            // cboPosition
            // 
            this.cboPosition.FormattingEnabled = true;
            this.cboPosition.ItemHeight = 23;
            this.cboPosition.Items.AddRange(new object[] {
            "CAPTIAN",
            " 1ST COUNCILOR ",
            " 2ND COUNCILOR ",
            " 3RD COUNCILOR ",
            " 4TH COUNCILOR ",
            " 5TH COUNCILOR ",
            " 6TH COUNCILOR ",
            " 7TH COUNCILOR ",
            " 8TH COUNCILOR ",
            "SECRETARY",
            "TRESUARER"});
            this.cboPosition.Location = new System.Drawing.Point(35, 245);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(332, 29);
            this.cboPosition.TabIndex = 6;
            this.cboPosition.UseSelectable = true;
            this.cboPosition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboPosition_KeyPress);
            // 
            // htmlLabel3
            // 
            this.htmlLabel3.AutoScroll = true;
            this.htmlLabel3.AutoScrollMinSize = new System.Drawing.Size(66, 23);
            this.htmlLabel3.AutoSize = false;
            this.htmlLabel3.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel3.Location = new System.Drawing.Point(35, 217);
            this.htmlLabel3.Name = "htmlLabel3";
            this.htmlLabel3.Size = new System.Drawing.Size(94, 27);
            this.htmlLabel3.TabIndex = 5;
            this.htmlLabel3.Text = "POSITION:";
            // 
            // htmlLabel4
            // 
            this.htmlLabel4.AutoScroll = true;
            this.htmlLabel4.AutoScrollMinSize = new System.Drawing.Size(83, 23);
            this.htmlLabel4.AutoSize = false;
            this.htmlLabel4.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel4.Location = new System.Drawing.Point(35, 293);
            this.htmlLabel4.Name = "htmlLabel4";
            this.htmlLabel4.Size = new System.Drawing.Size(94, 27);
            this.htmlLabel4.TabIndex = 7;
            this.htmlLabel4.Text = "TERM START:";
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(35, 317);
            this.dtStart.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(332, 29);
            this.dtStart.TabIndex = 8;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(35, 396);
            this.dtEnd.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(332, 29);
            this.dtEnd.TabIndex = 10;
            // 
            // htmlLabel5
            // 
            this.htmlLabel5.AutoScroll = true;
            this.htmlLabel5.AutoScrollMinSize = new System.Drawing.Size(70, 23);
            this.htmlLabel5.AutoSize = false;
            this.htmlLabel5.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel5.Location = new System.Drawing.Point(35, 372);
            this.htmlLabel5.Name = "htmlLabel5";
            this.htmlLabel5.Size = new System.Drawing.Size(94, 27);
            this.htmlLabel5.TabIndex = 9;
            this.htmlLabel5.Text = "TERM END:";
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.ItemHeight = 23;
            this.cboStatus.Items.AddRange(new object[] {
            "ACTIVE",
            "INACTIVE"});
            this.cboStatus.Location = new System.Drawing.Point(35, 470);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(332, 29);
            this.cboStatus.TabIndex = 12;
            this.cboStatus.UseSelectable = true;
            this.cboStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboStatus_KeyPress);
            // 
            // htmlLabel6
            // 
            this.htmlLabel6.AutoScroll = true;
            this.htmlLabel6.AutoScrollMinSize = new System.Drawing.Size(56, 23);
            this.htmlLabel6.AutoSize = false;
            this.htmlLabel6.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel6.Location = new System.Drawing.Point(35, 442);
            this.htmlLabel6.Name = "htmlLabel6";
            this.htmlLabel6.Size = new System.Drawing.Size(94, 27);
            this.htmlLabel6.TabIndex = 11;
            this.htmlLabel6.Text = "STATUS:";
            // 
            // htmlLabel1
            // 
            this.htmlLabel1.AutoScroll = true;
            this.htmlLabel1.AutoScrollMinSize = new System.Drawing.Size(47, 23);
            this.htmlLabel1.AutoSize = false;
            this.htmlLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel1.Location = new System.Drawing.Point(35, 61);
            this.htmlLabel1.Name = "htmlLabel1";
            this.htmlLabel1.Size = new System.Drawing.Size(54, 27);
            this.htmlLabel1.TabIndex = 4;
            this.htmlLabel1.Text = "NAME :";
            // 
            // btnsave
            // 
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.Image")));
            this.btnsave.Location = new System.Drawing.Point(104, 529);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 33);
            this.btnsave.TabIndex = 13;
            this.btnsave.Text = "SAVE";
            this.btnsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.FlatAppearance.BorderSize = 0;
            this.btnupdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.Image = ((System.Drawing.Image)(resources.GetObject("btnupdate.Image")));
            this.btnupdate.Location = new System.Drawing.Point(185, 530);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(89, 33);
            this.btnupdate.TabIndex = 14;
            this.btnupdate.Text = "UPDATE";
            this.btnupdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(278, 530);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 33);
            this.button4.TabIndex = 15;
            this.button4.Text = "CANCEL";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Frmofficials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 607);
            this.ControlBox = false;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.htmlLabel1);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.htmlLabel6);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.htmlLabel5);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.htmlLabel4);
            this.Controls.Add(this.cboPosition);
            this.Controls.Add(this.htmlLabel3);
            this.Controls.Add(this.cboCommittee);
            this.Controls.Add(this.htmlLabel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frmofficials";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frmofficials_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        public MetroFramework.Controls.MetroTextBox txtName;
        public MetroFramework.Drawing.Html.HtmlLabel htmlLabel2;
        public MetroFramework.Controls.MetroComboBox cboPosition;
        public MetroFramework.Drawing.Html.HtmlLabel htmlLabel3;
        public MetroFramework.Drawing.Html.HtmlLabel htmlLabel4;
        public MetroFramework.Controls.MetroDateTime dtStart;
        public MetroFramework.Controls.MetroDateTime dtEnd;
        public MetroFramework.Drawing.Html.HtmlLabel htmlLabel5;
        public MetroFramework.Controls.MetroComboBox cboCommittee;
        public MetroFramework.Controls.MetroComboBox cboStatus;
        public MetroFramework.Drawing.Html.HtmlLabel htmlLabel6;
        public MetroFramework.Drawing.Html.HtmlLabel htmlLabel1;
        public System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.Button btnupdate;
    }
}