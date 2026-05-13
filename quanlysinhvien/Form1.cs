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
            
            if (txtEmail.Text == "vietvh0029268@huce.edu.vn" && txtPassword.Text == "0029268")
            {
                MessageBox.Show("đăng nhập thành công");
            }
            else
            {
                MessageBox.Show("đăng nhập thất bại");
            }
        }
    }
}
