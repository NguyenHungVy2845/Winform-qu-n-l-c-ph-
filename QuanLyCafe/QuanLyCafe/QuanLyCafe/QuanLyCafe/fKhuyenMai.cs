using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fKhuyenMai : Form
    {
        public fKhuyenMai()
        {
            InitializeComponent();
        }

        private void fKhuyenMai_Load(object sender, EventArgs e)
        {
            LoadMonAn();
        }

        // 1. Load danh sách món (trừ Combo) để chọn
        void LoadMonAn()
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                var list = from m in db.Mons
                           join cat in db.LoaiMons on m.IdLoaiMon equals cat.Id
                           // Chỉ lấy món không phải là Combo và đang được bán
                           where cat.TenLoai != "Combo" && m.DangSuDung == true
                           select m;

                ((ListBox)clbMonAn).DataSource = list.ToList();
                ((ListBox)clbMonAn).DisplayMember = "TenMon";
                ((ListBox)clbMonAn).ValueMember = "Id";
            }
        }

        // 2. Hàm Tính tiền (Gốc & Sau giảm)
        void TinhTien()
        {
            decimal tongTienGoc = 0;

            // Cộng dồn giá các món được chọn
            foreach (Mon item in clbMonAn.CheckedItems)
            {
                tongTienGoc += item.GiaTien;
            }

            // Tính giảm giá
            int phanTramGiam = (int)nmGiamGia.Value;
            decimal tienSauGiam = tongTienGoc * (100 - phanTramGiam) / 100;

            // Hiển thị ra Label
            lbTongTien.Text = $"Tổng gốc: {tongTienGoc:N0} VNĐ\nGiảm {phanTramGiam}% -> Còn: {tienSauGiam:N0} VNĐ";
        }

        // Sự kiện khi tích/bỏ tích món ăn
        private void clbMonAn_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Dùng BeginInvoke để chạy hàm tính tiền SAU KHI trạng thái check đã cập nhật xong
            this.BeginInvoke(new Action(TinhTien));
        }

        // Sự kiện khi thay đổi số % giảm giá
        private void nmGiamGia_ValueChanged(object sender, EventArgs e)
        {
            TinhTien();
        }

        // 3. Nút Tạo Combo
        private void btnTaoCombo_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(tbTenCombo.Text))
            {
                MessageBox.Show("Vui lòng nhập tên Combo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clbMonAn.CheckedItems.Count < 2)
            {
                MessageBox.Show("Combo phải có ít nhất 2 món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                // Tính toán lại tiền lần cuối để lưu
                decimal tongTien = 0;
                string chiTietCombo = "";

                foreach (Mon item in clbMonAn.CheckedItems)
                {
                    tongTien += item.GiaTien;
                    chiTietCombo += $"- {item.TenMon}\n";
                }

                int phanTramGiam = (int)nmGiamGia.Value;
                decimal tienSauGiam = tongTien * (100 - phanTramGiam) / 100;

                // Tìm ID của danh mục "Combo" trong CSDL
                var catCombo = db.LoaiMons.FirstOrDefault(x => x.TenLoai == "Combo");
                if (catCombo == null)
                {
                    MessageBox.Show("Lỗi: Chưa có danh mục 'Combo' trong Database!\nHãy chạy lại script SQL cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo món mới (Loại là Combo)
                Mon newCombo = new Mon()
                {
                    TenMon = tbTenCombo.Text,
                    IdLoaiMon = catCombo.Id,
                    GiaTien = tienSauGiam,
                    DangSuDung = true
                    // Gợi ý mở rộng: Có thể lưu chiTietCombo vào cột GhiChu nếu muốn
                };

                db.Mons.InsertOnSubmit(newCombo);
                db.SubmitChanges();

                MessageBox.Show($"Đã tạo Combo thành công!\n\nChi tiết:\n{chiTietCombo}\nGiá gốc: {tongTien:N0}\nGiảm: {phanTramGiam}%\nGiá bán: {tienSauGiam:N0}", "Thành công");

                this.DialogResult = DialogResult.OK; // Báo về form cha (nếu cần)
                this.Close();
            }
        }
    }
}