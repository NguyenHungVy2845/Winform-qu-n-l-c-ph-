namespace QuanLyCafe
{
    partial class QuanLy
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
            this.d = new System.Windows.Forms.DataGridView();
            this.dtpkfromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpktoDate = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnEditTable = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.btnShowTable = new System.Windows.Forms.Button();
            this.cbTableStatus = new System.Windows.Forms.ComboBox();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.dtgvTable = new System.Windows.Forms.DataGridView();
            this.tabKtNhanVien = new System.Windows.Forms.TabPage();
            this.panelAccount = new System.Windows.Forms.Panel();
            this.dtgvAccount = new System.Windows.Forms.DataGridView();
            this.grpAccountDetails = new System.Windows.Forms.GroupBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.tbDisplayName = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbSearchFoodName = new System.Windows.Forms.TextBox();
            this.btnFindFood = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnShowFood = new System.Windows.Forms.Button();
            this.btnEditFood = new System.Windows.Forms.Button();
            this.btnDeleteFood = new System.Windows.Forms.Button();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgvFood = new System.Windows.Forms.DataGridView();
            this.tbThongTinBanHang = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.d)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTable)).BeginInit();
            this.tabKtNhanVien.SuspendLayout();
            this.panelAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).BeginInit();
            this.grpAccountDetails.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFood)).BeginInit();
            this.tbThongTinBanHang.SuspendLayout();
            this.SuspendLayout();
            // 
            // d
            // 
            this.d.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.d.Location = new System.Drawing.Point(15, 19);
            this.d.Margin = new System.Windows.Forms.Padding(2);
            this.d.Name = "d";
            this.d.RowHeadersWidth = 82;
            this.d.RowTemplate.Height = 33;
            this.d.Size = new System.Drawing.Size(744, 358);
            this.d.TabIndex = 0;
            // 
            // dtpkfromDate
            // 
            this.dtpkfromDate.Location = new System.Drawing.Point(15, 15);
            this.dtpkfromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpkfromDate.Name = "dtpkfromDate";
            this.dtpkfromDate.Size = new System.Drawing.Size(311, 26);
            this.dtpkfromDate.TabIndex = 0;
            // 
            // dtpktoDate
            // 
            this.dtpktoDate.Location = new System.Drawing.Point(339, 15);
            this.dtpktoDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpktoDate.Name = "dtpktoDate";
            this.dtpktoDate.Size = new System.Drawing.Size(311, 26);
            this.dtpktoDate.TabIndex = 1;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(669, 14);
            this.btnView.Margin = new System.Windows.Forms.Padding(2);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(90, 31);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "Thống Kê";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnEditTable);
            this.tabPage1.Controls.Add(this.btnDeleteTable);
            this.tabPage1.Controls.Add(this.btnAddTable);
            this.tabPage1.Controls.Add(this.btnShowTable);
            this.tabPage1.Controls.Add(this.cbTableStatus);
            this.tabPage1.Controls.Add(this.tbTableName);
            this.tabPage1.Controls.Add(this.dtgvTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1283, 517);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Bàn Ăn";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnEditTable
            // 
            this.btnEditTable.Location = new System.Drawing.Point(607, 75);
            this.btnEditTable.Name = "btnEditTable";
            this.btnEditTable.Size = new System.Drawing.Size(75, 39);
            this.btnEditTable.TabIndex = 6;
            this.btnEditTable.Text = "Sửa";
            this.btnEditTable.UseVisualStyleBackColor = true;
            this.btnEditTable.Click += new System.EventHandler(this.btnEditTable_Click);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Location = new System.Drawing.Point(688, 75);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(75, 39);
            this.btnDeleteTable.TabIndex = 5;
            this.btnDeleteTable.Text = "Xóa";
            this.btnDeleteTable.UseVisualStyleBackColor = true;
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);
            // 
            // btnAddTable
            // 
            this.btnAddTable.Location = new System.Drawing.Point(298, 75);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(75, 39);
            this.btnAddTable.TabIndex = 4;
            this.btnAddTable.Text = "Thêm";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // btnShowTable
            // 
            this.btnShowTable.Location = new System.Drawing.Point(217, 75);
            this.btnShowTable.Name = "btnShowTable";
            this.btnShowTable.Size = new System.Drawing.Size(75, 39);
            this.btnShowTable.TabIndex = 3;
            this.btnShowTable.Text = "Xem";
            this.btnShowTable.UseVisualStyleBackColor = true;
            this.btnShowTable.Click += new System.EventHandler(this.btnShowTable_Click);
            // 
            // cbTableStatus
            // 
            this.cbTableStatus.FormattingEnabled = true;
            this.cbTableStatus.Items.AddRange(new object[] {
            "Trống",
            "Có người"});
            this.cbTableStatus.Location = new System.Drawing.Point(769, 75);
            this.cbTableStatus.Name = "cbTableStatus";
            this.cbTableStatus.Size = new System.Drawing.Size(121, 28);
            this.cbTableStatus.TabIndex = 2;
            // 
            // tbTableName
            // 
            this.tbTableName.Location = new System.Drawing.Point(111, 75);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(100, 26);
            this.tbTableName.TabIndex = 1;
            // 
            // dtgvTable
            // 
            this.dtgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTable.Location = new System.Drawing.Point(111, 120);
            this.dtgvTable.Name = "dtgvTable";
            this.dtgvTable.RowHeadersWidth = 62;
            this.dtgvTable.RowTemplate.Height = 28;
            this.dtgvTable.Size = new System.Drawing.Size(779, 377);
            this.dtgvTable.TabIndex = 0;
            this.dtgvTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTable_CellClick);
            // 
            // tabKtNhanVien
            // 
            this.tabKtNhanVien.Controls.Add(this.panelAccount);
            this.tabKtNhanVien.Location = new System.Drawing.Point(4, 29);
            this.tabKtNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.tabKtNhanVien.Name = "tabKtNhanVien";
            this.tabKtNhanVien.Padding = new System.Windows.Forms.Padding(2);
            this.tabKtNhanVien.Size = new System.Drawing.Size(1283, 517);
            this.tabKtNhanVien.TabIndex = 3;
            this.tabKtNhanVien.Tag = "";
            this.tabKtNhanVien.Text = "Tài Khoản";
            this.tabKtNhanVien.UseVisualStyleBackColor = true;
            // 
            // panelAccount
            // 
            this.panelAccount.Controls.Add(this.dtgvAccount);
            this.panelAccount.Controls.Add(this.grpAccountDetails);
            this.panelAccount.Location = new System.Drawing.Point(10, 10);
            this.panelAccount.Name = "panelAccount";
            this.panelAccount.Size = new System.Drawing.Size(1260, 495);
            this.panelAccount.TabIndex = 0;
            // 
            // dtgvAccount
            // 
            this.dtgvAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvAccount.ColumnHeadersHeight = 34;
            this.dtgvAccount.Location = new System.Drawing.Point(10, 10);
            this.dtgvAccount.MultiSelect = false;
            this.dtgvAccount.Name = "dtgvAccount";
            this.dtgvAccount.RowHeadersWidth = 62;
            this.dtgvAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvAccount.Size = new System.Drawing.Size(800, 450);
            this.dtgvAccount.TabIndex = 0;
            this.dtgvAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvAccount_CellClick);
            // 
            // grpAccountDetails
            // 
            this.grpAccountDetails.Controls.Add(this.tbPassword);
            this.grpAccountDetails.Controls.Add(this.label1);
            this.grpAccountDetails.Controls.Add(this.lblUserName);
            this.grpAccountDetails.Controls.Add(this.tbUserName);
            this.grpAccountDetails.Controls.Add(this.lblDisplayName);
            this.grpAccountDetails.Controls.Add(this.tbDisplayName);
            this.grpAccountDetails.Controls.Add(this.lblRole);
            this.grpAccountDetails.Controls.Add(this.cbRole);
            this.grpAccountDetails.Controls.Add(this.btnAddAccount);
            this.grpAccountDetails.Controls.Add(this.btnEditAccount);
            this.grpAccountDetails.Controls.Add(this.btnDeleteAccount);
            this.grpAccountDetails.Location = new System.Drawing.Point(820, 10);
            this.grpAccountDetails.Name = "grpAccountDetails";
            this.grpAccountDetails.Size = new System.Drawing.Size(420, 260);
            this.grpAccountDetails.TabIndex = 1;
            this.grpAccountDetails.TabStop = false;
            this.grpAccountDetails.Text = "Chi tiết tài khoản";
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(10, 30);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(120, 23);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Tên đăng nhập:";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(140, 27);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(260, 26);
            this.tbUserName.TabIndex = 1;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.Location = new System.Drawing.Point(10, 70);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(120, 23);
            this.lblDisplayName.TabIndex = 2;
            this.lblDisplayName.Text = "Tên hiển thị:";
            // 
            // tbDisplayName
            // 
            this.tbDisplayName.Location = new System.Drawing.Point(140, 67);
            this.tbDisplayName.Name = "tbDisplayName";
            this.tbDisplayName.Size = new System.Drawing.Size(260, 26);
            this.tbDisplayName.TabIndex = 3;
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(10, 152);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(120, 23);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "Vai trò:";
            // 
            // cbRole
            // 
            this.cbRole.Items.AddRange(new object[] {
            "Nhân viên",
            "Quản lý"});
            this.cbRole.Location = new System.Drawing.Point(140, 147);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(150, 28);
            this.cbRole.TabIndex = 5;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(20, 198);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(90, 42);
            this.btnAddAccount.TabIndex = 6;
            this.btnAddAccount.Text = "Thêm";
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Location = new System.Drawing.Point(116, 198);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(90, 42);
            this.btnEditAccount.TabIndex = 7;
            this.btnEditAccount.Text = "Sửa";
            this.btnEditAccount.Click += new System.EventHandler(this.btnEditAccount_Click);
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(212, 198);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(90, 42);
            this.btnDeleteAccount.TabIndex = 8;
            this.btnDeleteAccount.Text = "Xóa";
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(1283, 517);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quản lý Món";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tbSearchFoodName);
            this.panel6.Controls.Add(this.btnFindFood);
            this.panel6.Location = new System.Drawing.Point(590, 25);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(302, 68);
            this.panel6.TabIndex = 3;
            // 
            // tbSearchFoodName
            // 
            this.tbSearchFoodName.Location = new System.Drawing.Point(13, 20);
            this.tbSearchFoodName.Name = "tbSearchFoodName";
            this.tbSearchFoodName.Size = new System.Drawing.Size(170, 26);
            this.tbSearchFoodName.TabIndex = 4;
            // 
            // btnFindFood
            // 
            this.btnFindFood.Location = new System.Drawing.Point(188, 9);
            this.btnFindFood.Margin = new System.Windows.Forms.Padding(2);
            this.btnFindFood.Name = "btnFindFood";
            this.btnFindFood.Size = new System.Drawing.Size(88, 48);
            this.btnFindFood.TabIndex = 3;
            this.btnFindFood.Text = "Tìm";
            this.btnFindFood.UseVisualStyleBackColor = true;
            this.btnFindFood.Click += new System.EventHandler(this.btnSearchFood_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnShowFood);
            this.panel5.Controls.Add(this.btnEditFood);
            this.panel5.Controls.Add(this.btnDeleteFood);
            this.panel5.Controls.Add(this.btnAddFood);
            this.panel5.Location = new System.Drawing.Point(16, 25);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(539, 68);
            this.panel5.TabIndex = 2;
            // 
            // btnShowFood
            // 
            this.btnShowFood.Location = new System.Drawing.Point(420, 9);
            this.btnShowFood.Name = "btnShowFood";
            this.btnShowFood.Size = new System.Drawing.Size(102, 45);
            this.btnShowFood.TabIndex = 2;
            this.btnShowFood.Text = "Làm mới";
            this.btnShowFood.UseVisualStyleBackColor = true;
            this.btnShowFood.Click += new System.EventHandler(this.btnShowFood_Click);
            // 
            // btnEditFood
            // 
            this.btnEditFood.Location = new System.Drawing.Point(291, 9);
            this.btnEditFood.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditFood.Name = "btnEditFood";
            this.btnEditFood.Size = new System.Drawing.Size(124, 45);
            this.btnEditFood.TabIndex = 2;
            this.btnEditFood.Text = "Sửa";
            this.btnEditFood.UseVisualStyleBackColor = true;
            this.btnEditFood.Click += new System.EventHandler(this.btnEditFood_Click);
            // 
            // btnDeleteFood
            // 
            this.btnDeleteFood.Location = new System.Drawing.Point(152, 9);
            this.btnDeleteFood.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteFood.Name = "btnDeleteFood";
            this.btnDeleteFood.Size = new System.Drawing.Size(124, 45);
            this.btnDeleteFood.TabIndex = 1;
            this.btnDeleteFood.Text = "Xóa";
            this.btnDeleteFood.UseVisualStyleBackColor = true;
            this.btnDeleteFood.Click += new System.EventHandler(this.btnDeleteFood_Click);
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(10, 9);
            this.btnAddFood.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(124, 45);
            this.btnAddFood.TabIndex = 0;
            this.btnAddFood.Text = "Thêm";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(590, 98);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(302, 401);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgvFood);
            this.panel3.Location = new System.Drawing.Point(16, 98);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(522, 401);
            this.panel3.TabIndex = 0;
            // 
            // dtgvFood
            // 
            this.dtgvFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvFood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvFood.Location = new System.Drawing.Point(0, 0);
            this.dtgvFood.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvFood.Name = "dtgvFood";
            this.dtgvFood.RowHeadersWidth = 82;
            this.dtgvFood.RowTemplate.Height = 33;
            this.dtgvFood.Size = new System.Drawing.Size(522, 401);
            this.dtgvFood.TabIndex = 0;
            // 
            // tbThongTinBanHang
            // 
            this.tbThongTinBanHang.Controls.Add(this.tabPage2);
            this.tbThongTinBanHang.Controls.Add(this.tabKtNhanVien);
            this.tbThongTinBanHang.Controls.Add(this.tabPage1);
            this.tbThongTinBanHang.Location = new System.Drawing.Point(9, 21);
            this.tbThongTinBanHang.Margin = new System.Windows.Forms.Padding(2);
            this.tbThongTinBanHang.Name = "tbThongTinBanHang";
            this.tbThongTinBanHang.SelectedIndex = 0;
            this.tbThongTinBanHang.Size = new System.Drawing.Size(1291, 550);
            this.tbThongTinBanHang.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mật khẩu:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(140, 105);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(260, 26);
            this.tbPassword.TabIndex = 10;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // QuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 581);
            this.Controls.Add(this.tbThongTinBanHang);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QuanLy";
            this.Text = "Quyền Quản Lý";
            ((System.ComponentModel.ISupportInitialize)(this.d)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTable)).EndInit();
            this.tabKtNhanVien.ResumeLayout(false);
            this.panelAccount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).EndInit();
            this.grpAccountDetails.ResumeLayout(false);
            this.grpAccountDetails.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFood)).EndInit();
            this.tbThongTinBanHang.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView d;
        private System.Windows.Forms.DateTimePicker dtpkfromDate;
        private System.Windows.Forms.DateTimePicker dtpktoDate;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnEditTable;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.Button btnShowTable;
        private System.Windows.Forms.ComboBox cbTableStatus;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.DataGridView dtgvTable;
        private System.Windows.Forms.TabPage tabKtNhanVien;
        private System.Windows.Forms.Panel panelAccount;
        private System.Windows.Forms.DataGridView dtgvAccount;
        private System.Windows.Forms.GroupBox grpAccountDetails;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.TextBox tbDisplayName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox tbSearchFoodName;
        private System.Windows.Forms.Button btnFindFood;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnShowFood;
        private System.Windows.Forms.Button btnEditFood;
        private System.Windows.Forms.Button btnDeleteFood;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgvFood;
        private System.Windows.Forms.TabControl tbThongTinBanHang;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label1;
    }
}