namespace QuanLyCafe
{
    partial class fBaoCao
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
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.lbDoanhThu = new System.Windows.Forms.Label();
            this.lbTienLuong = new System.Windows.Forms.Label();
            this.lbTienNhap = new System.Windows.Forms.Label();
            this.lbLoiNhuan = new System.Windows.Forms.Label();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(48, 55);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 26);
            this.dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(254, 55);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 26);
            this.dtpTo.TabIndex = 1;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.Location = new System.Drawing.Point(460, 55);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(75, 48);
            this.btnXemBaoCao.TabIndex = 2;
            this.btnXemBaoCao.Text = "Xem";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // lbDoanhThu
            // 
            this.lbDoanhThu.AutoSize = true;
            this.lbDoanhThu.Location = new System.Drawing.Point(44, 96);
            this.lbDoanhThu.Name = "lbDoanhThu";
            this.lbDoanhThu.Size = new System.Drawing.Size(84, 20);
            this.lbDoanhThu.TabIndex = 3;
            this.lbDoanhThu.Text = "DoanhThu";
            // 
            // lbTienLuong
            // 
            this.lbTienLuong.AutoSize = true;
            this.lbTienLuong.Location = new System.Drawing.Point(44, 125);
            this.lbTienLuong.Name = "lbTienLuong";
            this.lbTienLuong.Size = new System.Drawing.Size(84, 20);
            this.lbTienLuong.TabIndex = 4;
            this.lbTienLuong.Text = "TienLuong";
            // 
            // lbTienNhap
            // 
            this.lbTienNhap.AutoSize = true;
            this.lbTienNhap.Location = new System.Drawing.Point(44, 160);
            this.lbTienNhap.Name = "lbTienNhap";
            this.lbTienNhap.Size = new System.Drawing.Size(77, 20);
            this.lbTienNhap.TabIndex = 5;
            this.lbTienNhap.Text = "TienNhap";
            // 
            // lbLoiNhuan
            // 
            this.lbLoiNhuan.AutoSize = true;
            this.lbLoiNhuan.Location = new System.Drawing.Point(44, 195);
            this.lbLoiNhuan.Name = "lbLoiNhuan";
            this.lbLoiNhuan.Size = new System.Drawing.Size(77, 20);
            this.lbLoiNhuan.TabIndex = 6;
            this.lbLoiNhuan.Text = "LoiNhuan";
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.Location = new System.Drawing.Point(541, 55);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(117, 48);
            this.btnInBaoCao.TabIndex = 7;
            this.btnInBaoCao.Text = "In Báo Cáo";
            this.btnInBaoCao.UseVisualStyleBackColor = true;
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);
            // 
            // fBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnInBaoCao);
            this.Controls.Add(this.lbLoiNhuan);
            this.Controls.Add(this.lbTienNhap);
            this.Controls.Add(this.lbTienLuong);
            this.Controls.Add(this.lbDoanhThu);
            this.Controls.Add(this.btnXemBaoCao);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Name = "fBaoCao";
            this.Text = "fBaoCao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Label lbDoanhThu;
        private System.Windows.Forms.Label lbTienLuong;
        private System.Windows.Forms.Label lbTienNhap;
        private System.Windows.Forms.Label lbLoiNhuan;
        private System.Windows.Forms.Button btnInBaoCao;
    }
}