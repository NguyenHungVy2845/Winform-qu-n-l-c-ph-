namespace QuanLyCafe
{
    partial class ChucNang
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
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnBanHang = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnKhuyenMai = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnNhapHang = new System.Windows.Forms.Button();
            this.btnTopMon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(43, 39);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(211, 105);
            this.btnAdmin.TabIndex = 0;
            this.btnAdmin.Text = "Quản Lý";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnBanHang
            // 
            this.btnBanHang.Location = new System.Drawing.Point(258, 39);
            this.btnBanHang.Margin = new System.Windows.Forms.Padding(2);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(211, 105);
            this.btnBanHang.TabIndex = 1;
            this.btnBanHang.Text = "Bán Hàng";
            this.btnBanHang.UseVisualStyleBackColor = true;
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(43, 10);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(125, 25);
            this.lblWelcome.TabIndex = 6;
            this.lblWelcome.Text = "Chào mừng: ";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(780, 12);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 25);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(473, 39);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(211, 105);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Location = new System.Drawing.Point(43, 148);
            this.btnNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(211, 105);
            this.btnNhanVien.TabIndex = 3;
            this.btnNhanVien.Text = "Nhân Viên";
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnKhuyenMai
            // 
            this.btnKhuyenMai.Location = new System.Drawing.Point(258, 148);
            this.btnKhuyenMai.Margin = new System.Windows.Forms.Padding(2);
            this.btnKhuyenMai.Name = "btnKhuyenMai";
            this.btnKhuyenMai.Size = new System.Drawing.Size(211, 105);
            this.btnKhuyenMai.TabIndex = 4;
            this.btnKhuyenMai.Text = "Khuyến Mãi";
            this.btnKhuyenMai.UseVisualStyleBackColor = true;
            this.btnKhuyenMai.Click += new System.EventHandler(this.btnKhuyenMai_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(473, 148);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(211, 105);
            this.btnBaoCao.TabIndex = 5;
            this.btnBaoCao.Text = "Báo Cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.Location = new System.Drawing.Point(689, 40);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(211, 105);
            this.btnNhapHang.TabIndex = 8;
            this.btnNhapHang.Text = "Nhập Hàng";
            this.btnNhapHang.UseVisualStyleBackColor = true;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnTopMon
            // 
            this.btnTopMon.Location = new System.Drawing.Point(689, 148);
            this.btnTopMon.Name = "btnTopMon";
            this.btnTopMon.Size = new System.Drawing.Size(211, 105);
            this.btnTopMon.TabIndex = 9;
            this.btnTopMon.Text = "Món bán chạy";
            this.btnTopMon.UseVisualStyleBackColor = true;
            this.btnTopMon.Click += new System.EventHandler(this.btnTopMon_Click);
            // 
            // ChucNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 717);
            this.Controls.Add(this.btnTopMon);
            this.Controls.Add(this.btnNhapHang);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.btnKhuyenMai);
            this.Controls.Add(this.btnNhanVien);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnBanHang);
            this.Controls.Add(this.btnAdmin);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChucNang";
            this.Text = "Chức Năng";
            this.Load += new System.EventHandler(this.ChucNang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnBanHang;
    private System.Windows.Forms.Button btnThongKe;
    private System.Windows.Forms.Button btnNhanVien;
    private System.Windows.Forms.Button btnKhuyenMai;
    private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Button btnTopMon;
    }
}