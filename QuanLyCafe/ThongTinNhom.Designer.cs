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
            this.pnDanhSach = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pnDanhSach.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnDanhSach
            // 
            this.pnDanhSach.BackgroundImage = global::QuanLyCafe.Properties.Resources.Nen;
            this.pnDanhSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnDanhSach.Controls.Add(this.btnThoat);
            this.pnDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDanhSach.Location = new System.Drawing.Point(0, 0);
            this.pnDanhSach.Name = "pnDanhSach";
            this.pnDanhSach.Size = new System.Drawing.Size(746, 489);
            this.pnDanhSach.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(659, 434);
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
            this.ClientSize = new System.Drawing.Size(746, 489);
            this.Controls.Add(this.pnDanhSach);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ThongTinNhom";
            this.Text = "ThongTinNhom";
            this.Load += new System.EventHandler(this.ThongTinNhom_Load);
            this.pnDanhSach.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnDanhSach;
        private System.Windows.Forms.Button btnThoat;
    }
}