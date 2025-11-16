namespace QuanLyCafe
{
    partial class fKhuyenMai
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
            this.clbMonAn = new System.Windows.Forms.CheckedListBox();
            this.tbTenCombo = new System.Windows.Forms.TextBox();
            this.nmGiamGia = new System.Windows.Forms.NumericUpDown();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.btnTaoCombo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiamGia)).BeginInit();
            this.SuspendLayout();
            // 
            // clbMonAn
            // 
            this.clbMonAn.FormattingEnabled = true;
            this.clbMonAn.Location = new System.Drawing.Point(141, 112);
            this.clbMonAn.Name = "clbMonAn";
            this.clbMonAn.Size = new System.Drawing.Size(470, 234);
            this.clbMonAn.TabIndex = 0;
            this.clbMonAn.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbMonAn_ItemCheck);
            // 
            // tbTenCombo
            // 
            this.tbTenCombo.Location = new System.Drawing.Point(141, 80);
            this.tbTenCombo.Name = "tbTenCombo";
            this.tbTenCombo.Size = new System.Drawing.Size(138, 26);
            this.tbTenCombo.TabIndex = 1;
            // 
            // nmGiamGia
            // 
            this.nmGiamGia.Location = new System.Drawing.Point(285, 80);
            this.nmGiamGia.Name = "nmGiamGia";
            this.nmGiamGia.Size = new System.Drawing.Size(120, 26);
            this.nmGiamGia.TabIndex = 2;
            this.nmGiamGia.ValueChanged += new System.EventHandler(this.nmGiamGia_ValueChanged);
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Location = new System.Drawing.Point(503, 82);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(108, 20);
            this.lbTongTien.TabIndex = 3;
            this.lbTongTien.Text = "Hiện tổng tiền";
            // 
            // btnTaoCombo
            // 
            this.btnTaoCombo.Location = new System.Drawing.Point(411, 80);
            this.btnTaoCombo.Name = "btnTaoCombo";
            this.btnTaoCombo.Size = new System.Drawing.Size(75, 26);
            this.btnTaoCombo.TabIndex = 4;
            this.btnTaoCombo.Text = "Lưu";
            this.btnTaoCombo.UseVisualStyleBackColor = true;
            this.btnTaoCombo.Click += new System.EventHandler(this.btnTaoCombo_Click);
            // 
            // fKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTaoCombo);
            this.Controls.Add(this.lbTongTien);
            this.Controls.Add(this.nmGiamGia);
            this.Controls.Add(this.tbTenCombo);
            this.Controls.Add(this.clbMonAn);
            this.Name = "fKhuyenMai";
            this.Text = "fKhuyenMai";
            this.Load += new System.EventHandler(this.fKhuyenMai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmGiamGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbMonAn;
        private System.Windows.Forms.TextBox tbTenCombo;
        private System.Windows.Forms.NumericUpDown nmGiamGia;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Button btnTaoCombo;
    }
}