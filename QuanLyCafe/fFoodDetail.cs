using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fFoodDetail : Form
    {
        private int? _foodID = null; // Biến lưu ID món (Nếu null = Thêm mới, Có giá trị = Sửa)

        // Constructor nhận tham số ID (Mặc định là null nếu thêm mới)
        public fFoodDetail(int? foodId = null)
        {
            InitializeComponent();
            _foodID = foodId;
        }

        private void fFoodDetail_Load(object sender, EventArgs e)
        {
            LoadCategory(); // Load danh mục trước

            // Nếu đang ở chế độ Sửa (_foodID có giá trị) -> Đổ dữ liệu cũ lên
            if (_foodID != null)
            {
                this.Text = "Cập nhật món ăn"; // Đổi tên form
                using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
                {
                    var food = db.Mons.SingleOrDefault(x => x.Id == _foodID);
                    if (food != null)
                    {
                        tbName.Text = food.TenMon;
                        nmPrice.Value = food.GiaTien;
                        cbCategory.SelectedValue = food.IdLoaiMon; // Tự chọn đúng danh mục
                    }
                }
            }
            else
            {
                this.Text = "Thêm món mới";
            }
        }

        void LoadCategory()
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                // Chỉ lấy 2 loại: Thức ăn và Đồ uống (Bỏ qua Combo)
                var list = db.LoaiMons.Where(x => x.TenLoai == "Thức ăn" || x.TenLoai == "Đồ uống").ToList();

                cbCategory.DataSource = list;
                cbCategory.DisplayMember = "TenLoai";
                cbCategory.ValueMember = "Id";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                string name = tbName.Text;
                int idCategory = (int)cbCategory.SelectedValue;
                decimal price = nmPrice.Value;

                if (_foodID == null) // --- TRƯỜNG HỢP THÊM MỚI ---
                {
                    if (db.Mons.Any(x => x.TenMon == name))
                    {
                        MessageBox.Show("Tên món đã tồn tại!");
                        return;
                    }

                    Mon newFood = new Mon()
                    {
                        TenMon = name,
                        IdLoaiMon = idCategory,
                        GiaTien = price,
                        DangSuDung = true
                    };
                    db.Mons.InsertOnSubmit(newFood);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm mới thành công!");
                }
                else // --- TRƯỜNG HỢP SỬA ---
                {
                    var food = db.Mons.SingleOrDefault(x => x.Id == _foodID);
                    if (food != null)
                    {
                        food.TenMon = name;
                        food.IdLoaiMon = idCategory;
                        food.GiaTien = price;
                        db.SubmitChanges();
                        MessageBox.Show("Cập nhật thành công!");
                    }
                }

                // Đóng form và báo về form cha là đã OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}