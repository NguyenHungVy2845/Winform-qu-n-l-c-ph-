using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.Reporting.WinForms;

namespace QuanLyCafe
{
    public partial class TableManager : Form
    {
        private int _currentTableId = -1;

        public TableManager()
        {
            InitializeComponent();
        }

        private void TableManager_Load(object sender, EventArgs e)
        {
            LoadTable();
            LoadCategory();
            LoadListCombo(); // Tải danh sách Combo

            lsvBill.View = View.Details;
            lsvBill.GridLines = true;
            lsvBill.FullRowSelect = true;
        }

        #region Method (Các hàm xử lý logic)

        void LoadTable()
        {
            flpTable.Controls.Clear();
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                List<Ban> tableList = db.Bans.ToList();
                foreach (Ban item in tableList)
                {
                    Button btn = new Button() { Width = 90, Height = 90 };
                    btn.Text = item.TenBan + Environment.NewLine + (item.TrangThai == 0 ? "Trống" : "Có người");
                    btn.Click += btn_Click;
                    btn.Tag = item;

                    switch (item.TrangThai)
                    {
                        case 0: btn.BackColor = Color.Aqua; break;
                        default: btn.BackColor = Color.LightPink; break;
                    }
                    flpTable.Controls.Add(btn);
                }
            }
            LoadComboBoxTable();
        }

        void LoadComboBoxTable()
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                cbSwitchTable.DataSource = db.Bans.ToList();
                cbSwitchTable.DisplayMember = "TenBan";
            }
        }

        void LoadCategory()
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                // Lấy danh mục Thức ăn và Đồ uống
                var listCategory = db.LoaiMons.Where(x => x.TenLoai == "Thức ăn" || x.TenLoai == "Đồ uống").ToList();
                cbLoaiMon.DataSource = listCategory;
                cbLoaiMon.DisplayMember = "TenLoai";

                cbLoaiMon.SelectedIndexChanged -= cbCategory_SelectedIndexChanged;
                cbLoaiMon.SelectedIndexChanged += cbCategory_SelectedIndexChanged;

                if (listCategory.Count > 0)
                    LoadFoodListByCategoryID(listCategory[0].Id);
            }
        }

        void LoadFoodListByCategoryID(int id)
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                List<Mon> listFood = db.Mons.Where(x => x.IdLoaiMon == id).ToList();

                // SỬA: Gán thuộc tính hiển thị TRƯỚC, gán dữ liệu SAU
                cbMon.DisplayMember = "TenMon"; // Hiển thị tên món
                cbMon.ValueMember = "Id";       // Giá trị ngầm là Id món
                cbMon.DataSource = listFood;    // Gán nguồn dữ liệu cuối cùng
            }
        }

        // Hàm mới: Load danh sách Combo
        void LoadListCombo()
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                var list = from m in db.Mons
                           join cat in db.LoaiMons on m.IdLoaiMon equals cat.Id
                           where cat.TenLoai == "Combo" && m.DangSuDung == true
                           select m;

                cbCombo.DataSource = list.ToList();
                cbCombo.DisplayMember = "TenMon";
            }
        }

        void ShowBill(int idBan)
        {
            lsvBill.Items.Clear();
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                var bill = db.HoaDons.FirstOrDefault(x => x.IdBan == idBan && x.TrangThai == 0);
                if (bill != null)
                {
                    var listMenu = from ct in db.ChiTietHoaDons
                                   join m in db.Mons on ct.IdMon equals m.Id
                                   where ct.IdHoaDon == bill.Id
                                   select new
                                   {
                                       m.TenMon,
                                       ct.SoLuong,
                                       m.GiaTien,
                                       ThanhTien = ct.SoLuong * m.GiaTien
                                   };

                    foreach (var item in listMenu)
                    {
                        ListViewItem lsvItem = new ListViewItem(item.TenMon);
                        lsvItem.SubItems.Add(item.SoLuong.ToString());
                        lsvItem.SubItems.Add(((double)item.GiaTien).ToString("N0"));
                        lsvItem.SubItems.Add(((double)item.ThanhTien).ToString("N0"));
                        lsvBill.Items.Add(lsvItem);
                    }
                }
            }
        }

        // Hàm dùng chung để thêm món (hoặc combo) vào bill
        void AddItemToBill(int idMon, int soLuong)
        {
            if (_currentTableId == -1) { MessageBox.Show("Vui lòng chọn bàn!", "Thông báo"); return; }
            int idBan = _currentTableId;

            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                var mon = db.Mons.SingleOrDefault(m => m.Id == idMon);
                var bill = db.HoaDons.FirstOrDefault(x => x.IdBan == idBan && x.TrangThai == 0);

                if (bill == null) // Tạo Bill mới
                {
                    HoaDon newBill = new HoaDon() { IdBan = idBan, TrangThai = 0, ThoiGianVao = DateTime.Now, TienGiamGia = 0 };
                    db.HoaDons.InsertOnSubmit(newBill);
                    db.SubmitChanges();

                    var ban = db.Bans.SingleOrDefault(b => b.Id == idBan);
                    if (ban != null) { ban.TrangThai = 1; db.SubmitChanges(); } // Đổi màu bàn

                    ChiTietHoaDon ct = new ChiTietHoaDon() { IdHoaDon = newBill.Id, IdMon = idMon, SoLuong = soLuong, DonGiaTaiThoiDiem = mon.GiaTien };
                    db.ChiTietHoaDons.InsertOnSubmit(ct);
                    db.SubmitChanges();
                }
                else // Cập nhật Bill cũ
                {
                    var ct = db.ChiTietHoaDons.FirstOrDefault(x => x.IdHoaDon == bill.Id && x.IdMon == idMon);
                    if (ct == null)
                    {
                        db.ChiTietHoaDons.InsertOnSubmit(new ChiTietHoaDon() { IdHoaDon = bill.Id, IdMon = idMon, SoLuong = soLuong, DonGiaTaiThoiDiem = mon.GiaTien });
                    }
                    else
                    {
                        ct.SoLuong += soLuong;
                        if (ct.SoLuong <= 0) db.ChiTietHoaDons.DeleteOnSubmit(ct);
                    }
                    db.SubmitChanges();
                }
                ShowBill(idBan);
                LoadTable();
            }
        }

        #endregion

        #region Events

        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Ban).Id;
            _currentTableId = tableID;
            this.Text = "Đang chọn: " + ((sender as Button).Tag as Ban).TenBan;
            ShowBill(tableID);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;
            LoaiMon selected = cb.SelectedItem as LoaiMon;
            LoadFoodListByCategoryID(selected.Id);
        }

        // --- CÁC MENU ---
        private void HệthốngbànMenu_Click(object sender, EventArgs e)
        {
            QuanLy f = new QuanLy();
            f.SelectTabByTitle("Bàn ăn");
            this.Hide(); f.ShowDialog(); this.Show();
            LoadTable(); LoadCategory();
        }
        private void QuyềnquảnlýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLy f = new QuanLy();
            this.Hide(); f.ShowDialog(); this.Show();
            LoadTable(); LoadCategory();
        }
        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser == null) { MessageBox.Show("Vui lòng đăng nhập!"); return; }
            fNhanVien f = new fNhanVien(); f.ShowDialog();
        }
        private void ThốngkêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongKe f = new fThongKe(); this.Hide(); f.ShowDialog(); this.Show();
        }
        private void ĐăngxuấtToolStripMenuItem_Click(object sender, EventArgs e) { this.Close(); }

        // --- NÚT THANH TOÁN (Đã xóa Giảm giá) ---
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (_currentTableId == -1) { MessageBox.Show("Vui lòng chọn bàn!"); return; }
            int idBan = _currentTableId;

            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                var bill = db.HoaDons.FirstOrDefault(x => x.IdBan == idBan && x.TrangThai == 0);
                if (bill != null)
                {
                    double tongTienHang = 0;
                    var listChiTiet = db.ChiTietHoaDons.Where(x => x.IdHoaDon == bill.Id);

                    // Tính tổng tiền (lưu ý: nếu listChiTiet là IQueryable, lệnh này sẽ gọi xuống DB)
                    if (listChiTiet.Any()) tongTienHang = (double)listChiTiet.Sum(x => x.SoLuong * x.DonGiaTaiThoiDiem);

                    string msg = string.Format("Thanh toán bàn {0}?\n\nTổng tiền: {1:N0} VNĐ", idBan, tongTienHang);

                    if (MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        // 1. Cập nhật thông tin hóa đơn
                        bill.ThoiGianRa = DateTime.Now;
                        bill.TrangThai = 1;
                        bill.TienGiamGia = 0;

                        // 2. Cập nhật trạng thái bàn
                        var ban = db.Bans.SingleOrDefault(b => b.Id == idBan);
                        if (ban != null) ban.TrangThai = 0; // Trả bàn về Trống

                        // ======================================================
                        // 3. LOGIC MỚI: TRỪ TỒN KHO (Thêm vào đây)
                        // ======================================================
                        foreach (var chitiet in listChiTiet)
                        {
                            var mon = db.Mons.SingleOrDefault(m => m.Id == chitiet.IdMon);
                            if (mon != null)
                            {
                                // Trừ số lượng tồn
                                mon.SoLuongTon -= chitiet.SoLuong;

                                // (Tùy chọn) Nếu muốn chặn âm kho thì mở comment này ra:
                                /*
                                if (mon.SoLuongTon < 0) 
                                { 
                                    MessageBox.Show("Lỗi: Món " + mon.TenMon + " đã hết hàng trong kho (bị âm)!"); 
                                    return; // Dừng việc thanh toán lại
                                }
                                */
                            }
                        }
                        // ======================================================

                        // 4. Lưu tất cả thay đổi xuống Database (Hóa đơn, Bàn, Kho)
                        db.SubmitChanges();

                        // 5. In hóa đơn & Cập nhật giao diện
                        fReport f = new fReport(bill.Id);
                        f.ShowDialog();

                        ShowBill(idBan);
                        LoadTable();
                        _currentTableId = -1;
                    }
                }
            }
        }

        // --- NÚT THÊM MÓN ---
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đầu vào cơ bản
            if (cbMon.SelectedItem == null) return;
            if (_currentTableId == -1) { MessageBox.Show("Vui lòng chọn bàn!", "Thông báo"); return; }

            // Lấy ID món và Số lượng muốn thêm từ giao diện
            // Lưu ý: Cần ép kiểu về Mon để lấy Id chính xác
            int idMon = (cbMon.SelectedItem as Mon).Id;
            int soLuongMuonThem = (int)nmFoodCount.Value;

            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                var mon = db.Mons.SingleOrDefault(m => m.Id == idMon);
                if (mon == null) return;

                // --- LOGIC MỚI: TÍNH TOÁN TỔNG SỐ LƯỢNG ---

                // B1: Lấy số lượng món này ĐÃ CÓ trong hóa đơn của bàn hiện tại (nếu có)
                int soLuongDaCoTrongBill = 0;
                var bill = db.HoaDons.FirstOrDefault(x => x.IdBan == _currentTableId && x.TrangThai == 0);

                if (bill != null)
                {
                    var chiTiet = db.ChiTietHoaDons.FirstOrDefault(ct => ct.IdHoaDon == bill.Id && ct.IdMon == idMon);
                    if (chiTiet != null)
                    {
                        soLuongDaCoTrongBill = chiTiet.SoLuong;
                    }
                }

                // B2: Tính tổng: Đã gọi + Muốn gọi thêm
                int tongSoLuongSauKhiThem = soLuongDaCoTrongBill + soLuongMuonThem;

                // B3: So sánh với Tồn Kho
                // Nếu tổng cầu > cung -> Chặn lại
                if (tongSoLuongSauKhiThem > mon.SoLuongTon)
                {
                    MessageBox.Show(
                        string.Format("Không đủ hàng!\nKho còn: {0}\nĐã gọi: {1}\nMuốn thêm: {2}",
                        mon.SoLuongTon, soLuongDaCoTrongBill, soLuongMuonThem),
                        "Cảnh báo hết hàng",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return; // Dừng lại, không chạy hàm thêm món bên dưới
                }
            }

            // 2. Nếu đủ hàng thì mới thực hiện thêm vào Bill
            AddItemToBill(idMon, soLuongMuonThem);
        }

        // --- NÚT THÊM COMBO (Mới) ---
        private void btnAddCombo_Click(object sender, EventArgs e)
        {
            if (cbCombo.SelectedItem == null) return;
            int idMon = (cbCombo.SelectedItem as Mon).Id;
            int soLuong = 1; // Combo thường thêm từng cái

            AddItemToBill(idMon, soLuong);
        }

        // --- NÚT CHUYỂN BÀN ---
        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            // (Giữ nguyên logic chuyển bàn như cũ)
            int idOld = _currentTableId;
            if (idOld == -1) { MessageBox.Show("Chọn bàn cần chuyển!"); return; }
            if (cbSwitchTable.SelectedItem == null) return;
            int idNew = (cbSwitchTable.SelectedItem as Ban).Id;
            if (idOld == idNew) return;

            if (MessageBox.Show($"Chuyển bàn {idOld} sang {idNew}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
                {
                    var bOld = db.HoaDons.FirstOrDefault(x => x.IdBan == idOld && x.TrangThai == 0);
                    var bNew = db.HoaDons.FirstOrDefault(x => x.IdBan == idNew && x.TrangThai == 0);

                    if (bOld == null) { MessageBox.Show("Bàn này trống!"); return; }

                    if (bNew == null)
                    {
                        bOld.IdBan = idNew;
                        db.Bans.Single(x => x.Id == idOld).TrangThai = 0;
                        db.Bans.Single(x => x.Id == idNew).TrangThai = 1;
                        db.SubmitChanges();
                    }
                    else
                    {
                        foreach (var ctOld in db.ChiTietHoaDons.Where(x => x.IdHoaDon == bOld.Id).ToList())
                        {
                            var ctNew = db.ChiTietHoaDons.FirstOrDefault(x => x.IdHoaDon == bNew.Id && x.IdMon == ctOld.IdMon);
                            if (ctNew == null) { ctOld.IdHoaDon = bNew.Id; }
                            else { ctNew.SoLuong += ctOld.SoLuong; db.ChiTietHoaDons.DeleteOnSubmit(ctOld); }
                        }
                        db.HoaDons.DeleteOnSubmit(bOld);
                        db.Bans.Single(x => x.Id == idOld).TrangThai = 0;
                        db.SubmitChanges();
                    }
                    LoadTable(); ShowBill(idOld); _currentTableId = -1;
                }
            }
        }

        #endregion
    }
}