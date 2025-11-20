namespace QuanLyCafe
{
    partial class fNhapHang
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
            this.dtgvKho = new System.Windows.Forms.DataGridView();
            this.nmSoLuong = new System.Windows.Forms.NumericUpDown();
            this.nmGiaNhap = new System.Windows.Forms.NumericUpDown();
            this.btnNhapHang = new System.Windows.Forms.Button();
            this.lbTenMon = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgvLichSu = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiaNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvKho
            // 
            this.dtgvKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvKho.Location = new System.Drawing.Point(32, 157);
            this.dtgvKho.Name = "dtgvKho";
            this.dtgvKho.RowHeadersWidth = 62;
            this.dtgvKho.RowTemplate.Height = 28;
            this.dtgvKho.Size = new System.Drawing.Size(397, 232);
            this.dtgvKho.TabIndex = 0;
            this.dtgvKho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvKho_CellClick);
            // 
            // nmSoLuong
            // 
            this.nmSoLuong.Location = new System.Drawing.Point(32, 116);
            this.nmSoLuong.Name = "nmSoLuong";
            this.nmSoLuong.Size = new System.Drawing.Size(120, 26);
            this.nmSoLuong.TabIndex = 1;
            // 
            // nmGiaNhap
            // 
            this.nmGiaNhap.Location = new System.Drawing.Point(204, 115);
            this.nmGiaNhap.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmGiaNhap.Name = "nmGiaNhap";
            this.nmGiaNhap.Size = new System.Drawing.Size(120, 26);
            this.nmGiaNhap.TabIndex = 2;
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.Location = new System.Drawing.Point(354, 110);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(75, 41);
            this.btnNhapHang.TabIndex = 3;
            this.btnNhapHang.Text = "Nhập";
            this.btnNhapHang.UseVisualStyleBackColor = true;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // lbTenMon
            // 
            this.lbTenMon.AutoSize = true;
            this.lbTenMon.Location = new System.Drawing.Point(40, 45);
            this.lbTenMon.Name = "lbTenMon";
            this.lbTenMon.Size = new System.Drawing.Size(183, 20);
            this.lbTenMon.TabIndex = 4;
            this.lbTenMon.Text = "Hiện tên món đang chọn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Số lượng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Giá nhập";
            // 
            // dtgvLichSu
            // 
            this.dtgvLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvLichSu.Location = new System.Drawing.Point(450, 157);
            this.dtgvLichSu.Name = "dtgvLichSu";
            this.dtgvLichSu.RowHeadersWidth = 62;
            this.dtgvLichSu.RowTemplate.Height = 28;
            this.dtgvLichSu.Size = new System.Drawing.Size(338, 232);
            this.dtgvLichSu.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Lịch sử nhập hàng";
            // 
            // fNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtgvLichSu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTenMon);
            this.Controls.Add(this.btnNhapHang);
            this.Controls.Add(this.nmGiaNhap);
            this.Controls.Add(this.nmSoLuong);
            this.Controls.Add(this.dtgvKho);
            this.Name = "fNhapHang";
            this.Text = "fNhapHang";
            this.Load += new System.EventHandler(this.fNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiaNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichSu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvKho;
        private System.Windows.Forms.NumericUpDown nmSoLuong;
        private System.Windows.Forms.NumericUpDown nmGiaNhap;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Label lbTenMon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgvLichSu;
        private System.Windows.Forms.Label label3;
    }
}