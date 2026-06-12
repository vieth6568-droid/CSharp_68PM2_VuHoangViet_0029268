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
        }
    }
}
