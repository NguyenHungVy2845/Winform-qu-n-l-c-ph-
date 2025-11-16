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
    public partial class QuanLy : Form
    {
        // Chỉ còn 1 BindingSource cho Món
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();

        public QuanLy()
        {
            InitializeComponent();
            LoadState();
        }

        void LoadState()
        {
            // 1. Cấu hình Tab Quản lý Món (Đổi tên dtgvFood nếu cần)
            dtgvFood.DataSource = foodList;
            LoadListFood();

            // 2. Cấu hình Tab Bàn Ăn
            LoadListTable();

            // 3. Cấu hình Tab Tài Khoản
            dtgvAccount.DataSource = accountList;
            LoadListAccount();
        }

        public void SelectTabByTitle(string tabTitle)
        {
            foreach (TabPage tab in tbThongTinBanHang.TabPages)
            {
                if (tab.Text == tabTitle)
                {
                    tbThongTinBanHang.SelectedTab = tab;
                    return;
                }
            }
        }

        #region 1. QUẢN LÝ MÓN (Gộp chung)

        void LoadListFood()
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                var list = from m in db.Mons
                           join cat in db.LoaiMons on m.IdLoaiMon equals cat.Id
                           // Chỉ hiển thị 2 loại này, Combo sẽ quản lý ở form riêng
                           where cat.TenLoai == "Thức ăn" || cat.TenLoai == "Đồ uống"
                           select new
                           {
                               ID = m.Id,
                               TenMon = m.TenMon,
                               Gia = m.GiaTien,
                               Loại = cat.TenLoai,
                               TrangThai = m.DangSuDung == true ? "Đang bán" : "Ngừng bán"
                           };
                foodList.DataSource = list.ToList();
            }
        }

        private void btnShowFood_Click(object sender, EventArgs e) { LoadListFood(); }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            fFoodDetail f = new fFoodDetail(null);
            if (f.ShowDialog() == DialogResult.OK) LoadListFood();
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            if (dtgvFood.SelectedCells.Count > 0)
            {
                int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["ID"].Value;
                fFoodDetail f = new fFoodDetail(id);
                if (f.ShowDialog() == DialogResult.OK) LoadListFood();
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (dtgvFood.SelectedCells.Count > 0)
            {
                int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["ID"].Value;
                if (MessageBox.Show("Xóa món này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
                    {
                        try
                        {
                            var mon = db.Mons.SingleOrDefault(x => x.Id == id);
                            db.Mons.DeleteOnSubmit(mon);
                            db.SubmitChanges();
                            LoadListFood();
                        }
                        catch { MessageBox.Show("Không thể xóa món đang kinh doanh!"); }
                    }
                }
            }
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            string key = tbSearchFoodName.Text.Trim();
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                var list = from m in db.Mons
                           join cat in db.LoaiMons on m.IdLoaiMon equals cat.Id
                           where m.TenMon.Contains(key) && (cat.TenLoai == "Thức ăn" || cat.TenLoai == "Đồ uống")
                           select new { ID = m.Id, TenMon = m.TenMon, Gia = m.GiaTien, Loại = cat.TenLoai, TrangThai = m.DangSuDung == true ? "Đang bán" : "Ngừng bán" };
                foodList.DataSource = list.ToList();
            }
        }

        // MỚI: Nút mở form tạo Combo
        private void btnTaoCombo_Click(object sender, EventArgs e)
        {
            fKhuyenMai f = new fKhuyenMai();
            f.ShowDialog();
            // Không cần load lại list này vì Combo không hiển thị ở đây
        }

        #endregion

        #region 2. QUẢN LÝ BÀN ĂN
        // (Giữ nguyên toàn bộ code Quản lý Bàn ăn của bạn)
        void LoadListTable()
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                var list = from t in db.Bans select new { ID = t.Id, Tên_Bàn = t.TenBan, Trạng_Thái = t.TrangThai == 0 ? "Trống" : "Có người" };
                dtgvTable.DataSource = list.ToList();
            }
        }
        private void dtgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvTable.SelectedCells.Count > 0)
            {
                int rowIndex = dtgvTable.SelectedCells[0].OwningRow.Index;
                tbTableName.Text = dtgvTable.Rows[rowIndex].Cells["Tên_Bàn"].Value.ToString();
                string statusVal = dtgvTable.Rows[rowIndex].Cells["Trạng_Thái"].Value.ToString();
                if (cbTableStatus.Items.Contains(statusVal))
                    cbTableStatus.SelectedItem = statusVal;
            }
        }
        private void btnShowTable_Click(object sender, EventArgs e) { LoadListTable(); }
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                string name = tbTableName.Text;
                string statusStr = cbTableStatus.SelectedItem != null ? cbTableStatus.SelectedItem.ToString() : "Trống";
                int status = (statusStr == "Trống") ? 0 : 1;
                if (db.Bans.Any(x => x.TenBan == name)) { MessageBox.Show("Tên bàn đã tồn tại!"); return; }
                db.Bans.InsertOnSubmit(new Ban() { TenBan = name, TrangThai = (byte)status });
                db.SubmitChanges(); LoadListTable();
                MessageBox.Show("Thêm bàn thành công!");
            }
        }
        private void btnEditTable_Click(object sender, EventArgs e)
        {
            if (dtgvTable.SelectedCells.Count > 0)
            {
                int id = (int)dtgvTable.SelectedCells[0].OwningRow.Cells["ID"].Value;
                string name = tbTableName.Text;
                string statusStr = cbTableStatus.SelectedItem != null ? cbTableStatus.SelectedItem.ToString() : "Trống";
                int status = (statusStr == "Trống") ? 0 : 1;
                using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
                {
                    Ban t = db.Bans.SingleOrDefault(x => x.Id == id);
                    if (t != null)
                    {
                        t.TenBan = name;
                        t.TrangThai = (byte)status;
                        db.SubmitChanges(); LoadListTable(); MessageBox.Show("Cập nhật thành công!");
                    }
                }
            }
            else MessageBox.Show("Vui lòng chọn bàn cần sửa!");
        }
        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (dtgvTable.SelectedCells.Count > 0)
            {
                int id = (int)dtgvTable.SelectedCells[0].OwningRow.Cells["ID"].Value;
                if (MessageBox.Show("Xóa bàn này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
                    {
                        try { Ban t = db.Bans.SingleOrDefault(x => x.Id == id); if (t != null) { db.Bans.DeleteOnSubmit(t); db.SubmitChanges(); LoadListTable(); } }
                        catch { MessageBox.Show("Không thể xóa bàn này."); }
                    }
                }
            }
        }
        #endregion

        #region 3. QUẢN LÝ TÀI KHOẢN

        // SỬA: Đổi từ MD5 sang SHA256 để khớp với Database Data1.sql
        public string Encrytion(string password)
        {
            // Tạo đối tượng SHA256
            using (System.Security.Cryptography.SHA256Managed sha256 = new System.Security.Cryptography.SHA256Managed())
            {
                // Chuyển chuỗi thành byte
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(password);

                // Băm
                byte[] hash = sha256.ComputeHash(textData);

                // Chuyển kết quả về chuỗi Hex thường (lowercase)
                return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
            }
        }

        void LoadListAccount()
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                var list = from tk in db.TaiKhoans
                           select new
                           {
                               Tên_Đăng_Nhập = tk.TenDangNhap,
                               Tên_Hiển_Thị = tk.TenHienThi,
                               Vai_Trò = tk.LoaiTaiKhoan == 1 ? "Quản lý" : "Nhân viên",
                               Trạng_Thái = tk.DangHoatDong == true ? "Hoạt động" : "Đã khóa"
                           };
                accountList.DataSource = list.ToList();
            }
        }

        private void dtgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvAccount.SelectedCells.Count > 0)
            {
                int rowIndex = dtgvAccount.SelectedCells[0].OwningRow.Index;
                tbUserName.Text = dtgvAccount.Rows[rowIndex].Cells["Tên_Đăng_Nhập"].Value.ToString();
                tbDisplayName.Text = dtgvAccount.Rows[rowIndex].Cells["Tên_Hiển_Thị"].Value.ToString();
                string roleStr = dtgvAccount.Rows[rowIndex].Cells["Vai_Trò"].Value.ToString();

                // Chọn lại ComboBox Vai trò
                foreach (var item in cbRole.Items)
                {
                    if (item.ToString() == roleStr) { cbRole.SelectedItem = item; break; }
                }

                tbPassword.Text = ""; // Xóa trắng ô pass
            }
        }

        private void btnShowAccount_Click(object sender, EventArgs e) { LoadListAccount(); }

        // --- NÚT THÊM ---
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;
            string displayName = tbDisplayName.Text;
            string password = tbPassword.Text;
            string roleStr = cbRole.SelectedItem != null ? cbRole.SelectedItem.ToString() : "Nhân viên";
            int type = (roleStr == "Quản lý") ? 1 : 0;

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(displayName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!"); return;
            }

            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                if (db.TaiKhoans.Any(x => x.TenDangNhap == userName))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!"); return;
                }

                TaiKhoan tk = new TaiKhoan()
                {
                    TenDangNhap = userName,
                    TenHienThi = displayName,
                    LoaiTaiKhoan = (byte)type,
                    MatKhauMaHoa = Encrytion(password), // Dùng hàm SHA256 mới
                    DangHoatDong = true,
                    NgayTao = DateTime.Now
                };
                db.TaiKhoans.InsertOnSubmit(tk);
                db.SubmitChanges();

                MessageBox.Show("Thêm tài khoản thành công!");
                LoadListAccount();
            }
        }

        // --- NÚT SỬA ---
        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;
            string displayName = tbDisplayName.Text;
            string password = tbPassword.Text;
            string roleStr = cbRole.SelectedItem != null ? cbRole.SelectedItem.ToString() : "Nhân viên";
            int type = (roleStr == "Quản lý") ? 1 : 0;

            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                TaiKhoan tk = db.TaiKhoans.SingleOrDefault(x => x.TenDangNhap == userName);
                if (tk != null)
                {
                    tk.TenHienThi = displayName;
                    tk.LoaiTaiKhoan = (byte)type;

                    // Chỉ đổi mật khẩu nếu người dùng có nhập vào ô textbox
                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        tk.MatKhauMaHoa = Encrytion(password); // Dùng hàm SHA256 mới
                    }

                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadListAccount();
                    tbPassword.Text = "";
                }
                else MessageBox.Show("Không tìm thấy tài khoản!");
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;
            if (Session.CurrentUser != null && Session.CurrentUser.TenDangNhap == userName)
            {
                MessageBox.Show("Bạn không thể tự xóa chính mình!"); return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản [" + userName + "]?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
                {
                    try
                    {
                        TaiKhoan tk = db.TaiKhoans.SingleOrDefault(x => x.TenDangNhap == userName);
                        if (tk != null) { db.TaiKhoans.DeleteOnSubmit(tk); db.SubmitChanges(); MessageBox.Show("Xóa thành công!"); LoadListAccount(); }
                    }
                    catch { MessageBox.Show("Không thể xóa tài khoản này (đang có dữ liệu liên quan)."); }
                }
            }
        }

        #endregion

    }
}