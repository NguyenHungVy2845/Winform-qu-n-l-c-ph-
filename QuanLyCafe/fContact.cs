using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fContact : Form
    {
        public fContact()
        {
            InitializeComponent();
            // Tự động tạo giao diện khi khởi chạy
            InitializeCustomDesign();
        }

        // Hàm này vẽ giao diện (Thay vì bạn phải kéo thả thủ công)
        private void InitializeCustomDesign()
        {
            this.Text = "Thông tin liên hệ";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            // 1. Tiêu đề
            Label lblTitle = new Label();
            lblTitle.Text = "PHẦN MỀM QUẢN LÝ QUÁN CAFE";
            lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(60, 30);
            this.Controls.Add(lblTitle);

            // 2. GroupBox thông tin quán
            GroupBox gbQuan = new GroupBox();
            gbQuan.Text = "Thông tin quán";
            gbQuan.Font = new Font("Arial", 10, FontStyle.Bold);
            gbQuan.Size = new Size(440, 120);
            gbQuan.Location = new Point(20, 80);

            Label lblInfoQuan = new Label();
            lblInfoQuan.Text = "☕ Tên quán: Cafe Sinh Viên IT\n" +
                               "🏠 Địa chỉ: 123 Đường Lập Trình, Quận Code, TP. WinForm\n" +
                               "☎ Hotline: 0909 123 456\n" +
                               "📧 Email: lienhe@quanlycafe.com";
            lblInfoQuan.Font = new Font("Arial", 10, FontStyle.Regular);
            lblInfoQuan.AutoSize = true;
            lblInfoQuan.Location = new Point(20, 30);
            gbQuan.Controls.Add(lblInfoQuan);
            this.Controls.Add(gbQuan);

            // 3. GroupBox thông tin tác giả
            GroupBox gbTacGia = new GroupBox();
            gbTacGia.Text = "Đội ngũ phát triển";
            gbTacGia.Font = new Font("Arial", 10, FontStyle.Bold);
            gbTacGia.Size = new Size(440, 90);
            gbTacGia.Location = new Point(20, 210);

            Label lblInfoTacGia = new Label();
            lblInfoTacGia.Text = "👨‍💻 Nhóm thực hiện: Nhóm Anh 7\n" +
                                 "🏫 Trường: Đại học Sư Phạm TP.HCM\n" +
                                 "📆 Phiên bản: 1.0.0 (Release 2025)";
            lblInfoTacGia.Font = new Font("Arial", 10, FontStyle.Regular);
            lblInfoTacGia.AutoSize = true;
            lblInfoTacGia.Location = new Point(20, 25);
            gbTacGia.Controls.Add(lblInfoTacGia);
            this.Controls.Add(gbTacGia);

            // 4. Nút Đóng
            Button btnClose = new Button();
            btnClose.Text = "Đóng";
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(190, 315);
            btnClose.BackColor = Color.LightGray;
            btnClose.Click += (s, e) => { this.Close(); }; // Sự kiện đóng form
            this.Controls.Add(btnClose);
        }
    }
}