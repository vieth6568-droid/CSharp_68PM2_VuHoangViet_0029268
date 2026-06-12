using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlysinhvien
{
    public partial class UCL_QLSV : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        int trangHienTai = 1;
        int soDongTrenTrang = 5;
        public UCL_QLSV()
        {
            InitializeComponent();
        }

       

        private void UCL_QLSV_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDSLCMBX();
        }
        private void button4_Click(object sender, EventArgs e)
        {

            string mSSV = txtMSSV.Text;
            string hoTen = txtHoTen.Text;
            string gioiTinh = cboGioiTinh.Text;
            string ngaySinh = dtpNgaySinh.Text;
            tbl_sinhvien sinhvien = new tbl_sinhvien();
            sinhvien.id = mSSV;
            sinhvien.hoten = hoTen;
            sinhvien.gioitinh = gioiTinh;
            sinhvien.ngaysinh = DateTime.Parse(ngaySinh);
            sinhvien.malop = cmb_Lop.SelectedValue.ToString(); 
            try
            {
                db.tbl_sinhviens.InsertOnSubmit(sinhvien);
                db.SubmitChanges();
                MessageBox.Show("Thêm mới thành công");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadData()
        {
            List<tbl_sinhvien> dSSV = db.tbl_sinhviens.ToList();
            dgv_QLSV.DataSource = dSSV;
        }
        public void LoadDSLCMBX()
        {
            List<tbl_lophoc> dSLH = db.tbl_lophocs.ToList();
            cmb_Lop.DataSource = dSLH;
            cmb_Lop.DisplayMember = "tenlop";
            cmb_Lop.ValueMember = "malop";
        
        }
        private void dgv_QLSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Kiểm tra chỉ nhấp vào dòng dữ liệu (không nhấp vào tiêu đề)
            if (e.RowIndex >= 0 && e.RowIndex < dgv_QLSV.Rows.Count)
            {
                DataGridViewRow row = dgv_QLSV.Rows[e.RowIndex];

                // 2. Kiểm tra ô có null hay không trước khi gán
                if (row.Cells["id"].Value != null) txtMSSV.Text = row.Cells["id"].Value.ToString();
                txtMSSV.ReadOnly = true;

                if (row.Cells["hoten"].Value != null) txtHoTen.Text = row.Cells["hoten"].Value.ToString();
                if (row.Cells["gioitinh"].Value != null) cboGioiTinh.Text = row.Cells["gioitinh"].Value.ToString();

                if (row.Cells["ngaysinh"].Value != null)
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["ngaysinh"].Value);

                // 3. Xử lý an toàn cho ComboBox
                if (row.Cells["malop"].Value != null)
                {
                    cmb_Lop.SelectedValue = row.Cells["malop"].Value.ToString();
                }
                else
                {
                    cmb_Lop.SelectedIndex = -1; // Nếu không có mã lớp thì bỏ chọn
                }
            }
        }

        private void sửa_Click(object sender, EventArgs e)
        {
            tbl_sinhvien sinhvien = db.tbl_sinhviens.SingleOrDefault(x => x.id == txtMSSV.Text);
            if (sinhvien != null)
            {
                sinhvien.hoten = txtHoTen.Text;
                sinhvien.gioitinh = cboGioiTinh.Text;
                sinhvien.ngaysinh = dtpNgaySinh.Value;
                sinhvien.malop = cmb_Lop.SelectedValue.ToString();
                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("Sửa thành công");
                    LoadDataPhanTrang();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void xóa_Click(object sender, EventArgs e)
        {
            tbl_sinhvien sinhvien = db.tbl_sinhviens.SingleOrDefault(x => x.id == txtMSSV.Text);
            try
            {
                db.tbl_sinhviens.DeleteOnSubmit(sinhvien);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công");
                LoadDataPhanTrang();
                lammoi_Click(sender, e);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void lammoi_Click(object sender, EventArgs e)
        {
            txtMSSV.Clear();
            txtMSSV.ReadOnly = false;
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            LoadDataPhanTrang();
        }

        private void button5_Click(object sender, EventArgs e) // Nút Tìm kiếm
        {
            string tuKhoa = textBox3.Text;
            var ketQua = db.tbl_sinhviens.Where(x => x.hoten.Contains(tuKhoa) || x.id == tuKhoa || x.malop == tuKhoa).ToList();
            dgv_QLSV.DataSource = ketQua;
        }

        // Các nút phân trang
        private void button7_Click(object sender, EventArgs e) { trangHienTai = 1; LoadDataPhanTrang(); } // Nút <<
        private void button6_Click(object sender, EventArgs e) { if (trangHienTai > 1) trangHienTai--; LoadDataPhanTrang(); } // Nút <
        private void button8_Click(object sender, EventArgs e) { /* Nút > */ trangHienTai++; LoadDataPhanTrang(); }
        private void button9_Click(object sender, EventArgs e) { /* Nút >> */ int tongSoBanGhi = db.tbl_sinhviens.Count(); trangHienTai = (int)Math.Ceiling((double)tongSoBanGhi / soDongTrenTrang); LoadDataPhanTrang(); }

        public void LoadDataPhanTrang()
        {
            int tongSoBanGhi = db.tbl_sinhviens.Count();
            int tongSoTrang = (int)Math.Ceiling((double)tongSoBanGhi / soDongTrenTrang);
            if (tongSoTrang == 0) tongSoTrang = 1;

            var dSSV = db.tbl_sinhviens.Skip((trangHienTai - 1) * soDongTrenTrang).Take(soDongTrenTrang).ToList();
            dgv_QLSV.DataSource = dSSV;
            label7.Text = $"Trang {trangHienTai}/{tongSoTrang} | {tongSoBanGhi} bản ghi";
        }
    }
}


   
