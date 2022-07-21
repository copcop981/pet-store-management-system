
namespace PetStoreManagement
{
    partial class UserModule
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserModule));
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.txbAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUid = new System.Windows.Forms.Label();
            this.cbbRole = new System.Windows.Forms.ComboBox();
            this.dtpkBirth = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pnTxbName = new System.Windows.Forms.Panel();
            this.pnTxbAddress = new System.Windows.Forms.Panel();
            this.pnTxbPhone = new System.Windows.Forms.Panel();
            this.pnTxbPassword = new System.Windows.Forms.Panel();
            this.pnCbbRole = new System.Windows.Forms.Panel();
            this.pnDtpkBirth = new System.Windows.Forms.Panel();
            this.pbName = new System.Windows.Forms.PictureBox();
            this.pbAddress = new System.Windows.Forms.PictureBox();
            this.pbPhone = new System.Windows.Forms.PictureBox();
            this.pbRole = new System.Windows.Forms.PictureBox();
            this.pbDateOfBirth = new System.Windows.Forms.PictureBox();
            this.pbPassword = new System.Windows.Forms.PictureBox();
            this.chkbShowHide = new Guna.UI2.WinForms.Guna2CheckBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDateOfBirth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(172)))), ((int)(((byte)(220)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 10);
            this.panel1.TabIndex = 1;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(172)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Registration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            // 
            // txbName
            // 
            this.txbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbName.Location = new System.Drawing.Point(224, 82);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(444, 19);
            this.txbName.TabIndex = 4;
            this.txbName.TextChanged += new System.EventHandler(this.txbName_TextChanged);
            // 
            // txbAddress
            // 
            this.txbAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbAddress.Location = new System.Drawing.Point(224, 126);
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(444, 19);
            this.txbAddress.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Address:";
            // 
            // txbPhone
            // 
            this.txbPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbPhone.Location = new System.Drawing.Point(224, 173);
            this.txbPhone.Name = "txbPhone";
            this.txbPhone.Size = new System.Drawing.Size(444, 19);
            this.txbPhone.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Phone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Role:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Date of Birth:";
            // 
            // txbPassword
            // 
            this.txbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbPassword.Location = new System.Drawing.Point(224, 314);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '♦';
            this.txbPassword.Size = new System.Drawing.Size(444, 19);
            this.txbPassword.TabIndex = 14;
            this.txbPassword.TextChanged += new System.EventHandler(this.txbPassword_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(44, 317);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(83, 20);
            this.lblPassword.TabIndex = 13;
            this.lblPassword.Text = "Password:";
            // 
            // lblUid
            // 
            this.lblUid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUid.AutoSize = true;
            this.lblUid.Location = new System.Drawing.Point(12, 400);
            this.lblUid.Name = "lblUid";
            this.lblUid.Size = new System.Drawing.Size(33, 20);
            this.lblUid.TabIndex = 15;
            this.lblUid.Text = "Uid";
            this.lblUid.Visible = false;
            // 
            // cbbRole
            // 
            this.cbbRole.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbRole.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbRole.FormattingEnabled = true;
            this.cbbRole.Items.AddRange(new object[] {
            "Administrator",
            "Cashier",
            "Employee"});
            this.cbbRole.Location = new System.Drawing.Point(224, 215);
            this.cbbRole.Name = "cbbRole";
            this.cbbRole.Size = new System.Drawing.Size(444, 28);
            this.cbbRole.TabIndex = 16;
            this.cbbRole.SelectedIndexChanged += new System.EventHandler(this.cbbRole_SelectedIndexChanged);
            // 
            // dtpkBirth
            // 
            this.dtpkBirth.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpkBirth.Location = new System.Drawing.Point(224, 268);
            this.dtpkBirth.Name = "dtpkBirth";
            this.dtpkBirth.Size = new System.Drawing.Size(444, 26);
            this.dtpkBirth.TabIndex = 17;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(172)))), ((int)(((byte)(220)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(224, 391);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 38);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(44)))));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(380, 391);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(133, 38);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(535, 391);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 38);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(687, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(28, 30);
            this.panel2.TabIndex = 21;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Empty;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedColor = System.Drawing.Color.Transparent;
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.TabIndex = 16;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnTxbName
            // 
            this.pnTxbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnTxbName.Location = new System.Drawing.Point(196, 103);
            this.pnTxbName.Name = "pnTxbName";
            this.pnTxbName.Size = new System.Drawing.Size(472, 2);
            this.pnTxbName.TabIndex = 22;
            // 
            // pnTxbAddress
            // 
            this.pnTxbAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnTxbAddress.Location = new System.Drawing.Point(196, 147);
            this.pnTxbAddress.Name = "pnTxbAddress";
            this.pnTxbAddress.Size = new System.Drawing.Size(472, 2);
            this.pnTxbAddress.TabIndex = 23;
            // 
            // pnTxbPhone
            // 
            this.pnTxbPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnTxbPhone.Location = new System.Drawing.Point(196, 194);
            this.pnTxbPhone.Name = "pnTxbPhone";
            this.pnTxbPhone.Size = new System.Drawing.Size(472, 2);
            this.pnTxbPhone.TabIndex = 24;
            // 
            // pnTxbPassword
            // 
            this.pnTxbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnTxbPassword.Location = new System.Drawing.Point(196, 335);
            this.pnTxbPassword.Name = "pnTxbPassword";
            this.pnTxbPassword.Size = new System.Drawing.Size(472, 2);
            this.pnTxbPassword.TabIndex = 25;
            // 
            // pnCbbRole
            // 
            this.pnCbbRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnCbbRole.Location = new System.Drawing.Point(196, 245);
            this.pnCbbRole.Name = "pnCbbRole";
            this.pnCbbRole.Size = new System.Drawing.Size(472, 2);
            this.pnCbbRole.TabIndex = 25;
            // 
            // pnDtpkBirth
            // 
            this.pnDtpkBirth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnDtpkBirth.Location = new System.Drawing.Point(196, 294);
            this.pnDtpkBirth.Name = "pnDtpkBirth";
            this.pnDtpkBirth.Size = new System.Drawing.Size(472, 2);
            this.pnDtpkBirth.TabIndex = 26;
            // 
            // pbName
            // 
            this.pbName.Image = ((System.Drawing.Image)(resources.GetObject("pbName.Image")));
            this.pbName.Location = new System.Drawing.Point(196, 79);
            this.pbName.Name = "pbName";
            this.pbName.Size = new System.Drawing.Size(22, 22);
            this.pbName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbName.TabIndex = 27;
            this.pbName.TabStop = false;
            // 
            // pbAddress
            // 
            this.pbAddress.Image = ((System.Drawing.Image)(resources.GetObject("pbAddress.Image")));
            this.pbAddress.Location = new System.Drawing.Point(196, 123);
            this.pbAddress.Name = "pbAddress";
            this.pbAddress.Size = new System.Drawing.Size(22, 22);
            this.pbAddress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAddress.TabIndex = 28;
            this.pbAddress.TabStop = false;
            // 
            // pbPhone
            // 
            this.pbPhone.Image = ((System.Drawing.Image)(resources.GetObject("pbPhone.Image")));
            this.pbPhone.Location = new System.Drawing.Point(196, 170);
            this.pbPhone.Name = "pbPhone";
            this.pbPhone.Size = new System.Drawing.Size(22, 22);
            this.pbPhone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhone.TabIndex = 29;
            this.pbPhone.TabStop = false;
            // 
            // pbRole
            // 
            this.pbRole.Image = ((System.Drawing.Image)(resources.GetObject("pbRole.Image")));
            this.pbRole.Location = new System.Drawing.Point(196, 221);
            this.pbRole.Name = "pbRole";
            this.pbRole.Size = new System.Drawing.Size(22, 22);
            this.pbRole.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRole.TabIndex = 30;
            this.pbRole.TabStop = false;
            // 
            // pbDateOfBirth
            // 
            this.pbDateOfBirth.Image = ((System.Drawing.Image)(resources.GetObject("pbDateOfBirth.Image")));
            this.pbDateOfBirth.Location = new System.Drawing.Point(196, 270);
            this.pbDateOfBirth.Name = "pbDateOfBirth";
            this.pbDateOfBirth.Size = new System.Drawing.Size(22, 22);
            this.pbDateOfBirth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDateOfBirth.TabIndex = 31;
            this.pbDateOfBirth.TabStop = false;
            // 
            // pbPassword
            // 
            this.pbPassword.Image = ((System.Drawing.Image)(resources.GetObject("pbPassword.Image")));
            this.pbPassword.Location = new System.Drawing.Point(196, 311);
            this.pbPassword.Name = "pbPassword";
            this.pbPassword.Size = new System.Drawing.Size(22, 22);
            this.pbPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPassword.TabIndex = 32;
            this.pbPassword.TabStop = false;
            // 
            // chkbShowHide
            // 
            this.chkbShowHide.AutoSize = true;
            this.chkbShowHide.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkbShowHide.CheckedState.BorderRadius = 0;
            this.chkbShowHide.CheckedState.BorderThickness = 0;
            this.chkbShowHide.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkbShowHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkbShowHide.Location = new System.Drawing.Point(196, 348);
            this.chkbShowHide.Name = "chkbShowHide";
            this.chkbShowHide.Size = new System.Drawing.Size(142, 24);
            this.chkbShowHide.TabIndex = 33;
            this.chkbShowHide.Text = "Show Password";
            this.chkbShowHide.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkbShowHide.UncheckedState.BorderRadius = 0;
            this.chkbShowHide.UncheckedState.BorderThickness = 0;
            this.chkbShowHide.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkbShowHide.CheckedChanged += new System.EventHandler(this.chkbShowHide_CheckedChanged);
            // 
            // UserModule
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(727, 455);
            this.Controls.Add(this.chkbShowHide);
            this.Controls.Add(this.pbPassword);
            this.Controls.Add(this.pbDateOfBirth);
            this.Controls.Add(this.pbRole);
            this.Controls.Add(this.pbPhone);
            this.Controls.Add(this.pbAddress);
            this.Controls.Add(this.pbName);
            this.Controls.Add(this.pnDtpkBirth);
            this.Controls.Add(this.pnCbbRole);
            this.Controls.Add(this.pnTxbPassword);
            this.Controls.Add(this.pnTxbPhone);
            this.Controls.Add(this.pnTxbAddress);
            this.Controls.Add(this.pnTxbName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpkBirth);
            this.Controls.Add(this.cbbRole);
            this.Controls.Add(this.lblUid);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbPhone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserModule";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDateOfBirth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cbbRole;
        public System.Windows.Forms.Label lblUid;
        public System.Windows.Forms.TextBox txbPassword;
        public System.Windows.Forms.TextBox txbPhone;
        public System.Windows.Forms.TextBox txbAddress;
        public System.Windows.Forms.TextBox txbName;
        public System.Windows.Forms.DateTimePicker dtpkBirth;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Panel pnTxbName;
        private System.Windows.Forms.Panel pnTxbPhone;
        private System.Windows.Forms.Panel pnTxbAddress;
        private System.Windows.Forms.Panel pnTxbPassword;
        private System.Windows.Forms.Panel pnCbbRole;
        private System.Windows.Forms.Panel pnDtpkBirth;
        private System.Windows.Forms.PictureBox pbPassword;
        private System.Windows.Forms.PictureBox pbDateOfBirth;
        private System.Windows.Forms.PictureBox pbRole;
        private System.Windows.Forms.PictureBox pbPhone;
        private System.Windows.Forms.PictureBox pbAddress;
        private System.Windows.Forms.PictureBox pbName;
        private Guna.UI2.WinForms.Guna2CheckBox chkbShowHide;
    }
}