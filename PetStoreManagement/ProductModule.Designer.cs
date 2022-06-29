
namespace PetStoreManagement
{
    partial class ProductModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductModule));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbbCategory = new System.Windows.Forms.ComboBox();
            this.lblPid = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbQuantity = new System.Windows.Forms.TextBox();
            this.txbType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbPrice = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pnTxbName = new System.Windows.Forms.Panel();
            this.pnTxbType = new System.Windows.Forms.Panel();
            this.pnTxbQuantity = new System.Windows.Forms.Panel();
            this.pnTxbPrice = new System.Windows.Forms.Panel();
            this.pnCbbCategory = new System.Windows.Forms.Panel();
            this.pbName = new System.Windows.Forms.PictureBox();
            this.pbType = new System.Windows.Forms.PictureBox();
            this.pbCategory = new System.Windows.Forms.PictureBox();
            this.pbQuantity = new System.Windows.Forms.PictureBox();
            this.pbPrice = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(525, 317);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 38);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(132)))), ((int)(((byte)(44)))));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(370, 317);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(133, 38);
            this.btnUpdate.TabIndex = 38;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(172)))), ((int)(((byte)(220)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(214, 317);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 38);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbbCategory
            // 
            this.cbbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbCategory.FormattingEnabled = true;
            this.cbbCategory.Items.AddRange(new object[] {
            "Dog",
            "Cat",
            "Bird",
            "Fish",
            "Food"});
            this.cbbCategory.Location = new System.Drawing.Point(214, 168);
            this.cbbCategory.Name = "cbbCategory";
            this.cbbCategory.Size = new System.Drawing.Size(444, 28);
            this.cbbCategory.TabIndex = 35;
            this.cbbCategory.SelectedIndexChanged += new System.EventHandler(this.cbbCategory_SelectedIndexChanged);
            // 
            // lblPid
            // 
            this.lblPid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPid.AutoSize = true;
            this.lblPid.Location = new System.Drawing.Point(12, 326);
            this.lblPid.Name = "lblPid";
            this.lblPid.Size = new System.Drawing.Size(31, 20);
            this.lblPid.TabIndex = 34;
            this.lblPid.Text = "Pid";
            this.lblPid.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Quantity:";
            // 
            // txbQuantity
            // 
            this.txbQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbQuantity.Location = new System.Drawing.Point(214, 220);
            this.txbQuantity.Name = "txbQuantity";
            this.txbQuantity.Size = new System.Drawing.Size(444, 19);
            this.txbQuantity.TabIndex = 29;
            this.txbQuantity.TextChanged += new System.EventHandler(this.txbQuantity_TextChanged);
            // 
            // txbType
            // 
            this.txbType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbType.Location = new System.Drawing.Point(214, 126);
            this.txbType.Name = "txbType";
            this.txbType.Size = new System.Drawing.Size(444, 19);
            this.txbType.TabIndex = 27;
            this.txbType.TextChanged += new System.EventHandler(this.txbType_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(172)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 24);
            this.label1.TabIndex = 23;
            this.label1.Text = "Product Registration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Category:";
            // 
            // txbName
            // 
            this.txbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbName.Location = new System.Drawing.Point(214, 79);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(444, 19);
            this.txbName.TabIndex = 25;
            this.txbName.TextChanged += new System.EventHandler(this.txbName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(172)))), ((int)(((byte)(220)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 10);
            this.panel1.TabIndex = 22;
            // 
            // txbPrice
            // 
            this.txbPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbPrice.Location = new System.Drawing.Point(214, 267);
            this.txbPrice.Name = "txbPrice";
            this.txbPrice.Size = new System.Drawing.Size(444, 19);
            this.txbPrice.TabIndex = 41;
            this.txbPrice.TextChanged += new System.EventHandler(this.txbPrice_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(687, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(28, 30);
            this.panel2.TabIndex = 42;
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
            this.pnTxbName.Location = new System.Drawing.Point(186, 100);
            this.pnTxbName.Name = "pnTxbName";
            this.pnTxbName.Size = new System.Drawing.Size(472, 2);
            this.pnTxbName.TabIndex = 43;
            // 
            // pnTxbType
            // 
            this.pnTxbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnTxbType.Location = new System.Drawing.Point(186, 147);
            this.pnTxbType.Name = "pnTxbType";
            this.pnTxbType.Size = new System.Drawing.Size(472, 2);
            this.pnTxbType.TabIndex = 44;
            // 
            // pnTxbQuantity
            // 
            this.pnTxbQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnTxbQuantity.Location = new System.Drawing.Point(186, 241);
            this.pnTxbQuantity.Name = "pnTxbQuantity";
            this.pnTxbQuantity.Size = new System.Drawing.Size(472, 2);
            this.pnTxbQuantity.TabIndex = 45;
            // 
            // pnTxbPrice
            // 
            this.pnTxbPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnTxbPrice.Location = new System.Drawing.Point(186, 288);
            this.pnTxbPrice.Name = "pnTxbPrice";
            this.pnTxbPrice.Size = new System.Drawing.Size(472, 2);
            this.pnTxbPrice.TabIndex = 45;
            // 
            // pnCbbCategory
            // 
            this.pnCbbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnCbbCategory.Location = new System.Drawing.Point(186, 198);
            this.pnCbbCategory.Name = "pnCbbCategory";
            this.pnCbbCategory.Size = new System.Drawing.Size(472, 2);
            this.pnCbbCategory.TabIndex = 45;
            // 
            // pbName
            // 
            this.pbName.Image = ((System.Drawing.Image)(resources.GetObject("pbName.Image")));
            this.pbName.Location = new System.Drawing.Point(186, 76);
            this.pbName.Name = "pbName";
            this.pbName.Size = new System.Drawing.Size(22, 22);
            this.pbName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbName.TabIndex = 46;
            this.pbName.TabStop = false;
            // 
            // pbType
            // 
            this.pbType.Image = ((System.Drawing.Image)(resources.GetObject("pbType.Image")));
            this.pbType.Location = new System.Drawing.Point(186, 123);
            this.pbType.Name = "pbType";
            this.pbType.Size = new System.Drawing.Size(22, 22);
            this.pbType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbType.TabIndex = 47;
            this.pbType.TabStop = false;
            // 
            // pbCategory
            // 
            this.pbCategory.Image = ((System.Drawing.Image)(resources.GetObject("pbCategory.Image")));
            this.pbCategory.Location = new System.Drawing.Point(186, 174);
            this.pbCategory.Name = "pbCategory";
            this.pbCategory.Size = new System.Drawing.Size(22, 22);
            this.pbCategory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCategory.TabIndex = 48;
            this.pbCategory.TabStop = false;
            // 
            // pbQuantity
            // 
            this.pbQuantity.Image = ((System.Drawing.Image)(resources.GetObject("pbQuantity.Image")));
            this.pbQuantity.Location = new System.Drawing.Point(186, 217);
            this.pbQuantity.Name = "pbQuantity";
            this.pbQuantity.Size = new System.Drawing.Size(22, 22);
            this.pbQuantity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQuantity.TabIndex = 49;
            this.pbQuantity.TabStop = false;
            // 
            // pbPrice
            // 
            this.pbPrice.Image = ((System.Drawing.Image)(resources.GetObject("pbPrice.Image")));
            this.pbPrice.Location = new System.Drawing.Point(186, 264);
            this.pbPrice.Name = "pbPrice";
            this.pbPrice.Size = new System.Drawing.Size(22, 22);
            this.pbPrice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPrice.TabIndex = 50;
            this.pbPrice.TabStop = false;
            // 
            // ProductModule
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(727, 381);
            this.Controls.Add(this.pbPrice);
            this.Controls.Add(this.pbQuantity);
            this.Controls.Add(this.pbCategory);
            this.Controls.Add(this.pbType);
            this.Controls.Add(this.pbName);
            this.Controls.Add(this.pnCbbCategory);
            this.Controls.Add(this.pnTxbPrice);
            this.Controls.Add(this.pnTxbQuantity);
            this.Controls.Add(this.pnTxbType);
            this.Controls.Add(this.pnTxbName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txbPrice);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbbCategory);
            this.Controls.Add(this.lblPid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbQuantity);
            this.Controls.Add(this.txbType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductModule";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.ComboBox cbbCategory;
        public System.Windows.Forms.Label lblPid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txbQuantity;
        public System.Windows.Forms.TextBox txbType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txbPrice;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Panel pnTxbType;
        private System.Windows.Forms.Panel pnTxbName;
        private System.Windows.Forms.Panel pnTxbPrice;
        private System.Windows.Forms.Panel pnTxbQuantity;
        private System.Windows.Forms.Panel pnCbbCategory;
        private System.Windows.Forms.PictureBox pbName;
        private System.Windows.Forms.PictureBox pbPrice;
        private System.Windows.Forms.PictureBox pbQuantity;
        private System.Windows.Forms.PictureBox pbCategory;
        private System.Windows.Forms.PictureBox pbType;
    }
}