namespace QuanLyCafe
{
    partial class fShowLuong
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
            this.rpvLuong = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvLuong
            // 
            this.rpvLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvLuong.Location = new System.Drawing.Point(0, 0);
            this.rpvLuong.Name = "rpvLuong";
            this.rpvLuong.ServerReport.BearerToken = null;
            this.rpvLuong.Size = new System.Drawing.Size(800, 450);
            this.rpvLuong.TabIndex = 0;
            this.rpvLuong.Load += new System.EventHandler(this.fShowLuong_Load);
            // 
            // fShowLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpvLuong);
            this.Name = "fShowLuong";
            this.Text = "fShowLuong";
            this.Load += new System.EventHandler(this.fShowLuong_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvLuong;
    }
}