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
    public partial class FormxemdanhsachSV : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public FormxemdanhsachSV()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // Trong Form_DanhSachSV.cs
        public void LoadDSSV(string maLop)
        { 
            var danhSachSV = db.tbl_sinhviens.Where(s => s.malop == maLop).ToList();
     
            // Giả sử db là DataContext của bạn
            dgv_DSSV.DataSource = db.tbl_sinhviens.ToList();
            label_TenLop.Text = $"Danh sách sinh viên lớp {maLop.Trim()}";
            var dSSVTheoLop = db.tbl_sinhviens.Where(x => x.malop.Trim() == maLop.Trim()).ToList();

            dgv_DSSV.DataSource = dSSVTheoLop;
            label_TongSinhVien.Text = $"Tổng số sinh viên: {dSSVTheoLop.Count}";
        }

    }
}
