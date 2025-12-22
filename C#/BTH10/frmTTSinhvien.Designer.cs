namespace BTH10
{
    partial class frmTTSinhvien
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
            this.label1 = new System.Windows.Forms.Label();
            this.lb_hoten = new System.Windows.Forms.Label();
            this.lb_gioitinh = new System.Windows.Forms.Label();
            this.lb_Namsinh = new System.Windows.Forms.Label();
            this.lb_dienthoai = new System.Windows.Forms.Label();
            this.lb_Diachi = new System.Windows.Forms.Label();
            this.lb_Khoahoc = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtNamSinh = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.cb_KhoaHoc = new System.Windows.Forms.ComboBox();
            this.rbtn_nam = new System.Windows.Forms.RadioButton();
            this.rbtn_nu = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(190, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN SINH VIÊN";
            // 
            // lb_hoten
            // 
            this.lb_hoten.AutoSize = true;
            this.lb_hoten.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_hoten.Location = new System.Drawing.Point(89, 41);
            this.lb_hoten.Name = "lb_hoten";
            this.lb_hoten.Size = new System.Drawing.Size(54, 13);
            this.lb_hoten.TabIndex = 1;
            this.lb_hoten.Text = "Họ và tên";
            // 
            // lb_gioitinh
            // 
            this.lb_gioitinh.AutoSize = true;
            this.lb_gioitinh.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_gioitinh.Location = new System.Drawing.Point(89, 69);
            this.lb_gioitinh.Name = "lb_gioitinh";
            this.lb_gioitinh.Size = new System.Drawing.Size(47, 13);
            this.lb_gioitinh.TabIndex = 2;
            this.lb_gioitinh.Text = "Giới tính";
            // 
            // lb_Namsinh
            // 
            this.lb_Namsinh.AutoSize = true;
            this.lb_Namsinh.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_Namsinh.Location = new System.Drawing.Point(91, 93);
            this.lb_Namsinh.Name = "lb_Namsinh";
            this.lb_Namsinh.Size = new System.Drawing.Size(51, 13);
            this.lb_Namsinh.TabIndex = 3;
            this.lb_Namsinh.Text = "Năm sinh";
            // 
            // lb_dienthoai
            // 
            this.lb_dienthoai.AutoSize = true;
            this.lb_dienthoai.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_dienthoai.Location = new System.Drawing.Point(91, 119);
            this.lb_dienthoai.Name = "lb_dienthoai";
            this.lb_dienthoai.Size = new System.Drawing.Size(55, 13);
            this.lb_dienthoai.TabIndex = 4;
            this.lb_dienthoai.Text = "Điện thoại";
            this.lb_dienthoai.Click += new System.EventHandler(this.label5_Click);
            // 
            // lb_Diachi
            // 
            this.lb_Diachi.AutoSize = true;
            this.lb_Diachi.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_Diachi.Location = new System.Drawing.Point(89, 149);
            this.lb_Diachi.Name = "lb_Diachi";
            this.lb_Diachi.Size = new System.Drawing.Size(40, 13);
            this.lb_Diachi.TabIndex = 5;
            this.lb_Diachi.Text = "Địa chỉ";
            // 
            // lb_Khoahoc
            // 
            this.lb_Khoahoc.AutoSize = true;
            this.lb_Khoahoc.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_Khoahoc.Location = new System.Drawing.Point(89, 179);
            this.lb_Khoahoc.Name = "lb_Khoahoc";
            this.lb_Khoahoc.Size = new System.Drawing.Size(53, 13);
            this.lb_Khoahoc.TabIndex = 6;
            this.lb_Khoahoc.Text = "Khóa học";
            this.lb_Khoahoc.Click += new System.EventHandler(this.label2_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_OK.Location = new System.Drawing.Point(166, 217);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(118, 32);
            this.btn_OK.TabIndex = 7;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_Thoat.Location = new System.Drawing.Point(315, 217);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(118, 32);
            this.btn_Thoat.TabIndex = 7;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(153, 41);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(307, 20);
            this.txtHoTen.TabIndex = 8;
            // 
            // txtNamSinh
            // 
            this.txtNamSinh.Location = new System.Drawing.Point(155, 90);
            this.txtNamSinh.Name = "txtNamSinh";
            this.txtNamSinh.Size = new System.Drawing.Size(307, 20);
            this.txtNamSinh.TabIndex = 8;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(155, 116);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(307, 20);
            this.txtDienThoai.TabIndex = 8;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(153, 146);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(307, 20);
            this.txtDiaChi.TabIndex = 8;
            // 
            // cb_KhoaHoc
            // 
            this.cb_KhoaHoc.FormattingEnabled = true;
            this.cb_KhoaHoc.Items.AddRange(new object[] {
            "Đại học CNTT - DA19TTA",
            "Đại học CNTT - DA19TTB",
            "Đại học CNTT - DA20TTA",
            "Đại học CNTT - DA20TTB"});
            this.cb_KhoaHoc.Location = new System.Drawing.Point(155, 181);
            this.cb_KhoaHoc.Name = "cb_KhoaHoc";
            this.cb_KhoaHoc.Size = new System.Drawing.Size(304, 21);
            this.cb_KhoaHoc.TabIndex = 9;
            this.cb_KhoaHoc.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // rbtn_nam
            // 
            this.rbtn_nam.AutoSize = true;
            this.rbtn_nam.Location = new System.Drawing.Point(155, 67);
            this.rbtn_nam.Name = "rbtn_nam";
            this.rbtn_nam.Size = new System.Drawing.Size(47, 17);
            this.rbtn_nam.TabIndex = 10;
            this.rbtn_nam.TabStop = true;
            this.rbtn_nam.Text = "Nam";
            this.rbtn_nam.UseVisualStyleBackColor = true;
            // 
            // rbtn_nu
            // 
            this.rbtn_nu.AutoSize = true;
            this.rbtn_nu.Location = new System.Drawing.Point(271, 67);
            this.rbtn_nu.Name = "rbtn_nu";
            this.rbtn_nu.Size = new System.Drawing.Size(39, 17);
            this.rbtn_nu.TabIndex = 10;
            this.rbtn_nu.TabStop = true;
            this.rbtn_nu.Text = "Nữ";
            this.rbtn_nu.UseVisualStyleBackColor = true;
            this.rbtn_nu.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // frmTTSinhvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 261);
            this.Controls.Add(this.rbtn_nu);
            this.Controls.Add(this.rbtn_nam);
            this.Controls.Add(this.cb_KhoaHoc);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.txtNamSinh);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lb_Khoahoc);
            this.Controls.Add(this.lb_Diachi);
            this.Controls.Add(this.lb_dienthoai);
            this.Controls.Add(this.lb_Namsinh);
            this.Controls.Add(this.lb_gioitinh);
            this.Controls.Add(this.lb_hoten);
            this.Controls.Add(this.label1);
            this.Name = "frmTTSinhvien";
            this.Text = "frmDSSinhvien";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lb_hoten;
        public System.Windows.Forms.Label lb_gioitinh;
        public System.Windows.Forms.Label lb_Namsinh;
        public System.Windows.Forms.Label lb_dienthoai;
        public System.Windows.Forms.Label lb_Diachi;
        public System.Windows.Forms.Label lb_Khoahoc;
        public System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Thoat;
        public System.Windows.Forms.TextBox txtHoTen;
        public System.Windows.Forms.TextBox txtNamSinh;
        public System.Windows.Forms.TextBox txtDienThoai;
        public System.Windows.Forms.TextBox txtDiaChi;
        public System.Windows.Forms.ComboBox cb_KhoaHoc;
        public System.Windows.Forms.RadioButton rbtn_nu;
        public System.Windows.Forms.RadioButton rbtn_nam;
    }
}