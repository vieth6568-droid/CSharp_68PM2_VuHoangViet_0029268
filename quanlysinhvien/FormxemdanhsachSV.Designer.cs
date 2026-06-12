namespace quanlysinhvien
{
    partial class FormxemdanhsachSV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_DSSV = new System.Windows.Forms.DataGridView();
            this.label_TenLop = new System.Windows.Forms.Label();
            this.label_TongSinhVien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSSV)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_DSSV
            // 
            this.dgv_DSSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DSSV.Location = new System.Drawing.Point(37, 82);
            this.dgv_DSSV.Name = "dgv_DSSV";
            this.dgv_DSSV.RowHeadersWidth = 51;
            this.dgv_DSSV.RowTemplate.Height = 24;
            this.dgv_DSSV.Size = new System.Drawing.Size(872, 441);
            this.dgv_DSSV.TabIndex = 0;
            this.dgv_DSSV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label_TenLop
            // 
            this.label_TenLop.AutoSize = true;
            this.label_TenLop.Location = new System.Drawing.Point(34, 17);
            this.label_TenLop.Name = "label_TenLop";
            this.label_TenLop.Size = new System.Drawing.Size(44, 16);
            this.label_TenLop.TabIndex = 1;
            this.label_TenLop.Text = "label1";
            // 
            // label_TongSinhVien
            // 
            this.label_TongSinhVien.AutoSize = true;
            this.label_TongSinhVien.Location = new System.Drawing.Point(34, 45);
            this.label_TongSinhVien.Name = "label_TongSinhVien";
            this.label_TongSinhVien.Size = new System.Drawing.Size(44, 16);
            this.label_TongSinhVien.TabIndex = 2;
            this.label_TongSinhVien.Text = "label2";
            // 
            // FormxemdanhsachSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 551);
            this.Controls.Add(this.label_TongSinhVien);
            this.Controls.Add(this.label_TenLop);
            this.Controls.Add(this.dgv_DSSV);
            this.Name = "FormxemdanhsachSV";
            this.Text = "FormxemdanhsachSV";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSSV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DSSV;
        private System.Windows.Forms.Label label_TenLop;
        private System.Windows.Forms.Label label_TongSinhVien;
    }
}