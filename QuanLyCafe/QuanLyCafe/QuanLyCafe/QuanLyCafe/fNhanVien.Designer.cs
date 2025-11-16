namespace QuanLyCafe
{
    partial class fNhanVien
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
            this.lbXinChao = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLuong = new System.Windows.Forms.Label();
            this.lbNgayNghi = new System.Windows.Forms.Label();
            this.lbNgayLam = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgvLichSu = new System.Windows.Forms.DataGridView();
            this.btnXinNghi = new System.Windows.Forms.Button();
            this.tbLyDo = new System.Windows.Forms.TextBox();
            this.dtpNgayNghi = new System.Windows.Forms.DateTimePicker();
            this.btnInLuong = new System.Windows.Forms.Button();
            this.dtpThang = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // lbXinChao
            // 
            this.lbXinChao.AutoSize = true;
            this.lbXinChao.Location = new System.Drawing.Point(22, 24);
            this.lbXinChao.Name = "lbXinChao";
            this.lbXinChao.Size = new System.Drawing.Size(108, 20);
            this.lbXinChao.TabIndex = 0;
            this.lbXinChao.Text = "Tên nhân viên";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpThang);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbLuong);
            this.groupBox1.Controls.Add(this.lbNgayNghi);
            this.groupBox1.Controls.Add(this.lbNgayLam);
            this.groupBox1.Location = new System.Drawing.Point(12, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 223);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin lương";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lương dự tính";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số ngày nghỉ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số ngày đi làm";
            // 
            // lbLuong
            // 
            this.lbLuong.AutoSize = true;
            this.lbLuong.Location = new System.Drawing.Point(231, 69);
            this.lbLuong.Name = "lbLuong";
            this.lbLuong.Size = new System.Drawing.Size(106, 20);
            this.lbLuong.TabIndex = 2;
            this.lbLuong.Text = "Lương dự tính";
            // 
            // lbNgayNghi
            // 
            this.lbNgayNghi.AutoSize = true;
            this.lbNgayNghi.Location = new System.Drawing.Point(124, 69);
            this.lbNgayNghi.Name = "lbNgayNghi";
            this.lbNgayNghi.Size = new System.Drawing.Size(101, 20);
            this.lbNgayNghi.TabIndex = 1;
            this.lbNgayNghi.Text = "Số ngày nghỉ";
            // 
            // lbNgayLam
            // 
            this.lbNgayLam.AutoSize = true;
            this.lbNgayLam.Location = new System.Drawing.Point(6, 69);
            this.lbNgayLam.Name = "lbNgayLam";
            this.lbNgayLam.Size = new System.Drawing.Size(112, 20);
            this.lbNgayLam.TabIndex = 0;
            this.lbNgayLam.Text = "Số ngày đi làm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnInLuong);
            this.groupBox2.Controls.Add(this.dtgvLichSu);
            this.groupBox2.Controls.Add(this.btnXinNghi);
            this.groupBox2.Controls.Add(this.tbLyDo);
            this.groupBox2.Controls.Add(this.dtpNgayNghi);
            this.groupBox2.Location = new System.Drawing.Point(357, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 223);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Xin nghỉ";
            // 
            // dtgvLichSu
            // 
            this.dtgvLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvLichSu.Location = new System.Drawing.Point(6, 98);
            this.dtgvLichSu.Name = "dtgvLichSu";
            this.dtgvLichSu.RowHeadersWidth = 62;
            this.dtgvLichSu.RowTemplate.Height = 28;
            this.dtgvLichSu.Size = new System.Drawing.Size(240, 119);
            this.dtgvLichSu.TabIndex = 3;
            // 
            // btnXinNghi
            // 
            this.btnXinNghi.Location = new System.Drawing.Point(131, 66);
            this.btnXinNghi.Name = "btnXinNghi";
            this.btnXinNghi.Size = new System.Drawing.Size(75, 26);
            this.btnXinNghi.TabIndex = 2;
            this.btnXinNghi.Text = "Gửi đơn xin nghỉ";
            this.btnXinNghi.UseVisualStyleBackColor = true;
            this.btnXinNghi.Click += new System.EventHandler(this.btnXinNghi_Click);
            // 
            // tbLyDo
            // 
            this.tbLyDo.Location = new System.Drawing.Point(6, 66);
            this.tbLyDo.Name = "tbLyDo";
            this.tbLyDo.Size = new System.Drawing.Size(100, 26);
            this.tbLyDo.TabIndex = 1;
            // 
            // dtpNgayNghi
            // 
            this.dtpNgayNghi.Location = new System.Drawing.Point(6, 34);
            this.dtpNgayNghi.Name = "dtpNgayNghi";
            this.dtpNgayNghi.Size = new System.Drawing.Size(200, 26);
            this.dtpNgayNghi.TabIndex = 0;
            // 
            // btnInLuong
            // 
            this.btnInLuong.Location = new System.Drawing.Point(312, 13);
            this.btnInLuong.Name = "btnInLuong";
            this.btnInLuong.Size = new System.Drawing.Size(75, 23);
            this.btnInLuong.TabIndex = 4;
            this.btnInLuong.Text = "In Bảng Lương";
            this.btnInLuong.UseVisualStyleBackColor = true;
            this.btnInLuong.Click += new System.EventHandler(this.btnInLuong_Click);
            // 
            // dtpThang
            // 
            this.dtpThang.CustomFormat = "MM/yyyy";
            this.dtpThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThang.Location = new System.Drawing.Point(128, 0);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.Size = new System.Drawing.Size(200, 26);
            this.dtpThang.TabIndex = 3;
            // 
            // fNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbXinChao);
            this.Name = "fNhanVien";
            this.Text = "fNhanVien";
            this.Load += new System.EventHandler(this.fNhanVien_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichSu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbXinChao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbLuong;
        private System.Windows.Forms.Label lbNgayNghi;
        private System.Windows.Forms.Label lbNgayLam;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpNgayNghi;
        private System.Windows.Forms.Button btnXinNghi;
        private System.Windows.Forms.TextBox tbLyDo;
        private System.Windows.Forms.DataGridView dtgvLichSu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInLuong;
        private System.Windows.Forms.DateTimePicker dtpThang;
    }
}