namespace BTH12
{
    partial class frmDauSach
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
            this.txtNamXB = new System.Windows.Forms.TextBox();
            this.txtTenDS = new System.Windows.Forms.TextBox();
            this.txtMaDS = new System.Windows.Forms.TextBox();
            this.dgvDS = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.txtSolg = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnCNTG = new System.Windows.Forms.Button();
            this.btnCNNXB = new System.Windows.Forms.Button();
            this.btnCNTL = new System.Windows.Forms.Button();
            this.cbTheLoai = new System.Windows.Forms.ComboBox();
            this.cbNXB = new System.Windows.Forms.ComboBox();
            this.cbTacGia = new System.Windows.Forms.ComboBox();
            this.btnCN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNamXB
            // 
            this.txtNamXB.Location = new System.Drawing.Point(90, 121);
            this.txtNamXB.Name = "txtNamXB";
            this.txtNamXB.Size = new System.Drawing.Size(200, 20);
            this.txtNamXB.TabIndex = 30;
            // 
            // txtTenDS
            // 
            this.txtTenDS.Location = new System.Drawing.Point(90, 95);
            this.txtTenDS.Name = "txtTenDS";
            this.txtTenDS.Size = new System.Drawing.Size(200, 20);
            this.txtTenDS.TabIndex = 31;
            // 
            // txtMaDS
            // 
            this.txtMaDS.Location = new System.Drawing.Point(90, 69);
            this.txtMaDS.Name = "txtMaDS";
            this.txtMaDS.Size = new System.Drawing.Size(200, 20);
            this.txtMaDS.TabIndex = 32;
            // 
            // dgvDS
            // 
            this.dgvDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDS.Location = new System.Drawing.Point(90, 240);
            this.dgvDS.Name = "dgvDS";
            this.dgvDS.Size = new System.Drawing.Size(643, 164);
            this.dgvDS.TabIndex = 28;
            this.dgvDS.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDS_CellContentClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(248, 183);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(73, 28);
            this.btnXoa.TabIndex = 25;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(169, 183);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(73, 28);
            this.btnLuu.TabIndex = 26;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(90, 183);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(73, 28);
            this.btnThem.TabIndex = 27;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(12, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Ngày Nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(13, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Năm XB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Tên Đầu sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Mã Đầu sách";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(257, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 24);
            this.label1.TabIndex = 23;
            this.label1.Text = "FORM ĐẦU SÁCH";
            // 
            // txtNgayNhap
            // 
            this.txtNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtNgayNhap.Location = new System.Drawing.Point(90, 147);
            this.txtNgayNhap.Name = "txtNgayNhap";
            this.txtNgayNhap.Size = new System.Drawing.Size(200, 20);
            this.txtNgayNhap.TabIndex = 33;
            // 
            // txtSolg
            // 
            this.txtSolg.Location = new System.Drawing.Point(397, 69);
            this.txtSolg.Name = "txtSolg";
            this.txtSolg.Size = new System.Drawing.Size(200, 20);
            this.txtSolg.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(319, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Tác giả";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(320, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Nhà Xuất bản";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(319, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Thể loại";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(319, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Số lượng";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(406, 183);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(73, 28);
            this.btnThoat.TabIndex = 24;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnCNTG
            // 
            this.btnCNTG.Location = new System.Drawing.Point(612, 147);
            this.btnCNTG.Name = "btnCNTG";
            this.btnCNTG.Size = new System.Drawing.Size(121, 21);
            this.btnCNTG.TabIndex = 42;
            this.btnCNTG.Text = "Cập nhật Tác giả";
            this.btnCNTG.UseVisualStyleBackColor = true;
            this.btnCNTG.Click += new System.EventHandler(this.btnCNTG_Click);
            // 
            // btnCNNXB
            // 
            this.btnCNNXB.Location = new System.Drawing.Point(612, 118);
            this.btnCNNXB.Name = "btnCNNXB";
            this.btnCNNXB.Size = new System.Drawing.Size(121, 21);
            this.btnCNNXB.TabIndex = 43;
            this.btnCNNXB.Text = "Cập nhật NXB";
            this.btnCNNXB.UseVisualStyleBackColor = true;
            this.btnCNNXB.Click += new System.EventHandler(this.btnCNNXB_Click);
            // 
            // btnCNTL
            // 
            this.btnCNTL.Location = new System.Drawing.Point(612, 92);
            this.btnCNTL.Name = "btnCNTL";
            this.btnCNTL.Size = new System.Drawing.Size(121, 21);
            this.btnCNTL.TabIndex = 44;
            this.btnCNTL.Text = "Cập nhật Thể loại";
            this.btnCNTL.UseVisualStyleBackColor = true;
            this.btnCNTL.Click += new System.EventHandler(this.btnCNTL_Click);
            // 
            // cbTheLoai
            // 
            this.cbTheLoai.FormattingEnabled = true;
            this.cbTheLoai.Location = new System.Drawing.Point(397, 95);
            this.cbTheLoai.Name = "cbTheLoai";
            this.cbTheLoai.Size = new System.Drawing.Size(200, 21);
            this.cbTheLoai.TabIndex = 45;
            // 
            // cbNXB
            // 
            this.cbNXB.FormattingEnabled = true;
            this.cbNXB.Location = new System.Drawing.Point(397, 119);
            this.cbNXB.Name = "cbNXB";
            this.cbNXB.Size = new System.Drawing.Size(200, 21);
            this.cbNXB.TabIndex = 45;
            // 
            // cbTacGia
            // 
            this.cbTacGia.FormattingEnabled = true;
            this.cbTacGia.Location = new System.Drawing.Point(397, 143);
            this.cbTacGia.Name = "cbTacGia";
            this.cbTacGia.Size = new System.Drawing.Size(200, 21);
            this.cbTacGia.TabIndex = 45;
            // 
            // btnCN
            // 
            this.btnCN.Location = new System.Drawing.Point(327, 183);
            this.btnCN.Name = "btnCN";
            this.btnCN.Size = new System.Drawing.Size(73, 28);
            this.btnCN.TabIndex = 24;
            this.btnCN.Text = "Sửa";
            this.btnCN.UseVisualStyleBackColor = true;
            this.btnCN.Click += new System.EventHandler(this.btnCN_Click);
            // 
            // frmDauSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 430);
            this.Controls.Add(this.cbTacGia);
            this.Controls.Add(this.cbNXB);
            this.Controls.Add(this.cbTheLoai);
            this.Controls.Add(this.btnCNTG);
            this.Controls.Add(this.btnCNNXB);
            this.Controls.Add(this.btnCNTL);
            this.Controls.Add(this.txtSolg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNgayNhap);
            this.Controls.Add(this.txtNamXB);
            this.Controls.Add(this.txtTenDS);
            this.Controls.Add(this.txtMaDS);
            this.Controls.Add(this.dgvDS);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnCN);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDauSach";
            this.Text = "frmDauSach";
            this.Load += new System.EventHandler(this.frmDauSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNamXB;
        private System.Windows.Forms.TextBox txtTenDS;
        private System.Windows.Forms.TextBox txtMaDS;
        private System.Windows.Forms.DataGridView dgvDS;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtNgayNhap;
        private System.Windows.Forms.TextBox txtSolg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnCNTG;
        private System.Windows.Forms.Button btnCNNXB;
        private System.Windows.Forms.Button btnCNTL;
        private System.Windows.Forms.ComboBox cbTheLoai;
        private System.Windows.Forms.ComboBox cbNXB;
        private System.Windows.Forms.ComboBox cbTacGia;
        private System.Windows.Forms.Button btnCN;
    }
}