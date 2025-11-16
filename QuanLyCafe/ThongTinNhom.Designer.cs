namespace QuanLyCafe
{
    partial class ThongTinNhom
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnDanhSach = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(314, 87);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(145, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÔNG TIN QUÁN";
            // 
            // pnDanhSach
            // 
            this.pnDanhSach.Location = new System.Drawing.Point(67, 120);
            this.pnDanhSach.Name = "pnDanhSach";
            this.pnDanhSach.Size = new System.Drawing.Size(685, 251);
            this.pnDanhSach.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(758, 120);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 43);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Đóng";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // ThongTinNhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 708);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.pnDanhSach);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ThongTinNhom";
            this.Text = "ThongTinNhom";
            this.Load += new System.EventHandler(this.ThongTinNhom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnDanhSach;
        private System.Windows.Forms.Button btnThoat;
    }
}