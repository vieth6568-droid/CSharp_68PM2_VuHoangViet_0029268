using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlysinhvien
{
    public partial class UCL_QLLH : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        int trangHienTai = 1;
        int soDongTrenTrang = 5;
        public UCL_QLLH()
        {
            InitializeComponent();
        }

        private void UCL_QLLH_Load(object sender, EventArgs e)
        {
            LoadDataPhanTrang();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            tbl_lophoc lophoc = new tbl_lophoc();
            lophoc.id = txtID.Text;
            lophoc.malop = txtMaLop.Text;
            lophoc.tenlop = txtTenLop.Text;
            lophoc.ghichu = txtGhiChu.Text;
            try
            {
                db.tbl_lophocs.InsertOnSubmit(lophoc);
                db.SubmitChanges();
                MessageBox.Show("Thêm mới thành công");
                LoadDataPhanTrang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_QLLH_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = dgv_QLLH.CurrentRow;

            txtID.Text = row.Cells["id"].Value.ToString();
            txtID.ReadOnly = true;
            txtMaLop.Text = row.Cells["malop"].Value.ToString();
            txtTenLop.Text = row.Cells["tenlop"].Value.ToString();
            txtGhiChu.Text = row.Cells["ghichu"].Value.ToString();
        }



        private void sửa_Click(object sender, EventArgs e)
        {
            tbl_lophoc lophoc = db.tbl_lophocs.SingleOrDefault(x => x.id == txtID.Text);

            if (lophoc != null)
                try
                {
                    lophoc.malop = txtMaLop.Text;
                    lophoc.tenlop = txtTenLop.Text;
                    lophoc.ghichu = txtGhiChu.Text;

                    db.SubmitChanges();

                    MessageBox.Show("Sửa thành công");
                    LoadDataPhanTrang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }


        private void xóa_Click(object sender, EventArgs e)
        {
            tbl_lophoc lophoc = db.tbl_lophocs.SingleOrDefault(x => x.id == txtID.Text);
            try
            {
                db.tbl_lophocs.DeleteOnSubmit(lophoc);

                db.SubmitChanges();
                MessageBox.Show("Xóa thành công");
                LoadDataPhanTrang();

                lammoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lammoi_Click(object sender, EventArgs e)
        {
            txtMaLop.Clear();
            txtID.Clear();
            txtID.ReadOnly = false;
            txtTenLop.Clear();
            txtGhiChu.Clear();
            trangHienTai = 1;
            LoadDataPhanTrang();
        }

        private void button5_Click(object sender, EventArgs e) // Nút Tìm kiếm
        {
            string tuKhoa = txttimkiem.Text;

            List<tbl_lophoc> ketQua = db.tbl_lophocs.Where(x => x.id.Contains(tuKhoa)
                                                                || x.malop == tuKhoa
                                                                || x.tenlop == tuKhoa).ToList();

            dgv_QLLH.DataSource = ketQua;
        }

        // Các nút phân trang
        private void button7_Click(object sender, EventArgs e) { trangHienTai = 1; LoadDataPhanTrang(); } // Nút <<
        private void button6_Click(object sender, EventArgs e) { if (trangHienTai > 1) trangHienTai--; LoadDataPhanTrang(); } // Nút <
        private void button8_Click(object sender, EventArgs e) { /* Nút > */ trangHienTai++; LoadDataPhanTrang(); }
        private void button9_Click(object sender, EventArgs e) { /* Nút >> */ int tongSoBanGhi = db.tbl_sinhviens.Count(); trangHienTai = (int)Math.Ceiling((double)tongSoBanGhi / soDongTrenTrang); LoadDataPhanTrang(); }

        public void LoadDataPhanTrang()
        {
            // 1. Luôn luôn đếm từ bảng gốc, không đếm từ kết quả lọc
            int tongSoBanGhi = db.tbl_lophocs.Count();
            int tongSoTrang = (int)Math.Ceiling((double)tongSoBanGhi / soDongTrenTrang);
            if (tongSoTrang == 0) tongSoTrang = 1;

            // 2. Lấy dữ liệu phân trang từ bảng gốc tbl_lophocs (bảng của lớp học)
            var dsLop = db.tbl_lophocs.Skip((trangHienTai - 1) * soDongTrenTrang)
                                     .Take(soDongTrenTrang).ToList();

            // 3. Gán lại nguồn dữ liệu gốc
            dgv_QLLH.DataSource = dsLop;

            dgv_QLLH.Text = $"Trang {trangHienTai}/{tongSoTrang} | {tongSoBanGhi} bản ghi";
        }
        private void btnXemDS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Chọn 1 lớp từ danh sách");
                return;
            }

            string maLopDuocChon = txtMaLop.Text;

            var dSSVTheoLop = db.tbl_sinhviens.Where(x => x.malop == maLopDuocChon).ToList();

            dgv_QLLH.DataSource = dSSVTheoLop;

            phantrang.Text = $"{maLopDuocChon} | {dSSVTheoLop.Count} sinh viên";
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
