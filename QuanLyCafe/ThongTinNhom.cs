using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class ThongTinNhom : Form
    {
        public ThongTinNhom()
        {
            InitializeComponent();
        }

        private void ThongTinNhom_Load(object sender, EventArgs e)
        {
            // Danh sách thành viên
            string[] members = new string[]
            {
                "THÔNG TIN QUÁN",
                "Quán được thành lập bởi",
                "1. Nguyễn Đức Trọng",
                "2. Đặng Yên Chí Tài",
                "3. Nguyễn Hùng Vỹ",
                "4. Phạm Gia Khiêm",
                "5. Phạm Văn Hợp"
            };

            // Tự động tạo Label cho từng người
            int y = 20; // Vị trí bắt đầu chiều dọc
            foreach (string member in members)
            {
                Label lb = new Label();
                lb.Text = member;
                lb.Font = new Font("Arial", 12, FontStyle.Regular); // Cỡ chữ 12
                lb.AutoSize = true;
                lb.Location = new Point(50, y); // Cách lề trái 50px

                // Thêm vào Panel (nếu bạn đã tạo Panel tên pnDanhSach)
                // Nếu chưa tạo Panel, đổi 'pnDanhSach' thành 'this' để thêm thẳng vào Form
                if (this.Controls.ContainsKey("pnDanhSach"))
                {
                    this.Controls["pnDanhSach"].Controls.Add(lb);
                }
                else
                {
                    this.Controls.Add(lb);
                }

                y += 40; // Dòng tiếp theo cách 40px
            }

            // Cấu hình nút thoát (nếu chưa có sự kiện)
            if (this.Controls.ContainsKey("btnThoat"))
            {
                this.Controls["btnThoat"].Click += (s, ev) => { this.Close(); };
            }
        }
    }
}