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
    public partial class Form_maincs : Form
    {
        public Form_maincs()
        {
            InitializeComponent();
        }

        private void Form_maincs_Load(object sender, EventArgs e)
        {

            UCL_QLSV uCL_QLSV = new UCL_QLSV();
            pnl_QLSV.Controls.Clear();
            pnl_QLSV.Controls.Add(uCL_QLSV);
        }

        private void quảnLýLớpHọcToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            UCL_QLLH uCL_QLLH = new UCL_QLLH();
            pnl_QLSV.Controls.Clear();
            pnl_QLSV.Controls.Add(uCL_QLLH);
        }

        private void quanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCL_QLSV uCL_QLSV = new UCL_QLSV();
            pnl_QLSV.Controls.Clear();
            pnl_QLSV.Controls.Add(uCL_QLSV);
        }
    }
}
