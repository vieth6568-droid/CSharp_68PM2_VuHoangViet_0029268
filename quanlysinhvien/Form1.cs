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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            // Giả sử bạn kiểm tra tài khoản, mật khẩu ở đây
            if (txtEmail.Text == "admin" && txtPassword.Text == "123") // Thay điều kiện đăng nhập của bạn vào đây
            {
                MessageBox.Show("Đăng nhập thành công");

                // SỬA CHÍNH XÁC DÒNG NÀY: Khởi tạo Form chính bằng từ khóa new
                Form_maincs f = new Form_maincs();

                this.Hide(); // Ẩn form đăng nhập đi
                f.ShowDialog(); // Hiển thị form chính lên
                this.Show(); // Khi form chính đóng, hiện lại form đăng nhập (hoặc dùng this.Close() nếu muốn tắt hẳn)
            }
            else
            {
                MessageBox.Show("đăng nhập thất bại");
            }
        }
    }
}
