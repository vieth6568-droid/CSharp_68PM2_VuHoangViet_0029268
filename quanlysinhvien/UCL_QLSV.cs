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
    }
}

