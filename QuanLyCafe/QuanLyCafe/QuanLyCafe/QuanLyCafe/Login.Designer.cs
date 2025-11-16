namespace QuanLyCafe
{
    partial class Login
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
            this.OpenLogin = new System.Windows.Forms.Panel();
            this.btnThongTinQuan = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbPassWord = new System.Windows.Forms.TextBox();
            this.MatKhau = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.TenDangNhap = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.OpenLogin.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenLogin
            // 
            this.OpenLogin.Controls.Add(this.textBox1);
            this.OpenLogin.Controls.Add(this.btnThongTinQuan);
            this.OpenLogin.Controls.Add(this.btnExit);
            this.OpenLogin.Controls.Add(this.btnLogin);
            this.OpenLogin.Controls.Add(this.panel3);
            this.OpenLogin.Controls.Add(this.panel2);
            this.OpenLogin.Font = new System.Drawing.Font("Times New Roman", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenLogin.Location = new System.Drawing.Point(12, 12);
            this.OpenLogin.Name = "OpenLogin";
            this.OpenLogin.Size = new System.Drawing.Size(1423, 815);
            this.OpenLogin.TabIndex = 0;
            // 
            // btnThongTinQuan
            // 
            this.btnThongTinQuan.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongTinQuan.Location = new System.Drawing.Point(1030, 23);
            this.btnThongTinQuan.Name = "btnThongTinQuan";
            this.btnThongTinQuan.Size = new System.Drawing.Size(316, 50);
            this.btnThongTinQuan.TabIndex = 5;
            this.btnThongTinQuan.Text = "Thông Tin Quán";
            this.btnThongTinQuan.UseVisualStyleBackColor = true;
            this.btnThongTinQuan.Click += new System.EventHandler(this.btnThongTinQuan_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(710, 660);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(181, 50);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(501, 660);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(181, 50);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbPassWord);
            this.panel3.Controls.Add(this.MatKhau);
            this.panel3.Location = new System.Drawing.Point(418, 529);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(629, 74);
            this.panel3.TabIndex = 1;
            // 
            // txbPassWord
            // 
            this.txbPassWord.Location = new System.Drawing.Point(248, 22);
            this.txbPassWord.Name = "txbPassWord";
            this.txbPassWord.Size = new System.Drawing.Size(324, 32);
            this.txbPassWord.TabIndex = 2;
            this.txbPassWord.UseSystemPasswordChar = true;
            // 
            // MatKhau
            // 
            this.MatKhau.AutoSize = true;
            this.MatKhau.Font = new System.Drawing.Font("Times New Roman", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MatKhau.Location = new System.Drawing.Point(13, 18);
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.Size = new System.Drawing.Size(136, 33);
            this.MatKhau.TabIndex = 0;
            this.MatKhau.Text = "Mật Khẩu:";
            this.MatKhau.Click += new System.EventHandler(this.MatKhau_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbUserName);
            this.panel2.Controls.Add(this.TenDangNhap);
            this.panel2.Location = new System.Drawing.Point(418, 451);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 72);
            this.panel2.TabIndex = 0;
            // 
            // txbUserName
            // 
            this.txbUserName.Location = new System.Drawing.Point(248, 22);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(324, 32);
            this.txbUserName.TabIndex = 1;
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.AutoSize = true;
            this.TenDangNhap.Font = new System.Drawing.Font("Times New Roman", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenDangNhap.Location = new System.Drawing.Point(13, 18);
            this.TenDangNhap.Name = "TenDangNhap";
            this.TenDangNhap.Size = new System.Drawing.Size(203, 33);
            this.TenDangNhap.TabIndex = 0;
            this.TenDangNhap.Text = "Tên Đăng Nhập:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 28.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(418, 295);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(629, 94);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Quán Cafe Anh 7";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 839);
            this.Controls.Add(this.OpenLogin);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.OpenLogin.ResumeLayout(false);
            this.OpenLogin.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel OpenLogin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txbPassWord;
        private System.Windows.Forms.Label MatKhau;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.Label TenDangNhap;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnThongTinQuan;
        private System.Windows.Forms.TextBox textBox1;
    }
}

