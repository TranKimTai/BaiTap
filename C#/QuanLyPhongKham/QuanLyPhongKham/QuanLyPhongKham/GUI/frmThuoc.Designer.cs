namespace QuanLyPhongKham.GUI
{
    partial class frmThuoc
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
            this.txtTenThuoc = new System.Windows.Forms.TextBox();
            this.txtHoatChat = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.cboDonViTinh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.tlpInput = new System.Windows.Forms.TableLayoutPanel();
            this.dgvThuoc = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tlpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTenThuoc
            // 
            this.txtTenThuoc.Location = new System.Drawing.Point(151, 3);
            this.txtTenThuoc.Name = "txtTenThuoc";
            this.txtTenThuoc.Size = new System.Drawing.Size(244, 30);
            this.txtTenThuoc.TabIndex = 1;
            // 
            // txtHoatChat
            // 
            this.txtHoatChat.Location = new System.Drawing.Point(551, 3);
            this.txtHoatChat.Name = "txtHoatChat";
            this.txtHoatChat.Size = new System.Drawing.Size(282, 30);
            this.txtHoatChat.TabIndex = 2;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(551, 43);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(282, 30);
            this.txtDonGia.TabIndex = 3;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(151, 83);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(244, 30);
            this.txtSoLuong.TabIndex = 4;
            // 
            // cboDonViTinh
            // 
            this.cboDonViTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonViTinh.FormattingEnabled = true;
            this.cboDonViTinh.Items.AddRange(new object[] {
            "Bộ",
            "Cái",
            "Cặp",
            "Chai",
            "Cuộn",
            "Gói",
            "Hộp",
            "Liều",
            "Lọ",
            "Miếng",
            "Ống",
            "Túi",
            "Tuýp",
            "Viên",
            "Vỉ"});
            this.cboDonViTinh.Location = new System.Drawing.Point(151, 43);
            this.cboDonViTinh.Name = "cboDonViTinh";
            this.cboDonViTinh.Size = new System.Drawing.Size(244, 31);
            this.cboDonViTinh.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tên thuốc:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(451, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Hoạt chất: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "Đơn giá:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "Số lượng: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 23);
            this.label5.TabIndex = 17;
            this.label5.Text = "Chọn đơn vị tính:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(8, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(282, 27);
            this.txtTimKiem.TabIndex = 18;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged_1);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(306, 3);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(114, 28);
            this.btnTimKiem.TabIndex = 19;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlTop.Controls.Add(this.panel1);
            this.pnlTop.Controls.Add(this.label6);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 69);
            this.pnlTop.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(508, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 37);
            this.panel1.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 31);
            this.label6.TabIndex = 18;
            this.label6.Text = "QUẢN LÝ THUỐC";
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.Controls.Add(this.flowLayoutPanel1);
            this.pnlInput.Controls.Add(this.tlpInput);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 69);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(1100, 300);
            this.pnlInput.TabIndex = 21;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btnThem);
            this.flowLayoutPanel1.Controls.Add(this.btnSua);
            this.flowLayoutPanel1.Controls.Add(this.btnXoa);
            this.flowLayoutPanel1.Controls.Add(this.btnLuu);
            this.flowLayoutPanel1.Controls.Add(this.btnBoQua);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(533, 210);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(539, 48);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // btnThem
            // 
            this.btnThem.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(3, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 40);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(109, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 40);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(215, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 40);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Enabled = false;
            this.btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(321, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 40);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Enabled = false;
            this.btnBoQua.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnBoQua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoQua.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoQua.Location = new System.Drawing.Point(427, 3);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(100, 40);
            this.btnBoQua.TabIndex = 14;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // tlpInput
            // 
            this.tlpInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlpInput.ColumnCount = 5;
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 292F));
            this.tlpInput.Controls.Add(this.txtDonGia, 4, 1);
            this.tlpInput.Controls.Add(this.label3, 3, 1);
            this.tlpInput.Controls.Add(this.label2, 0, 0);
            this.tlpInput.Controls.Add(this.txtTenThuoc, 1, 0);
            this.tlpInput.Controls.Add(this.label4, 0, 2);
            this.tlpInput.Controls.Add(this.txtSoLuong, 1, 2);
            this.tlpInput.Controls.Add(this.txtHoatChat, 4, 0);
            this.tlpInput.Controls.Add(this.label1, 3, 0);
            this.tlpInput.Controls.Add(this.label5, 0, 1);
            this.tlpInput.Controls.Add(this.cboDonViTinh, 1, 1);
            this.tlpInput.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpInput.Location = new System.Drawing.Point(112, 61);
            this.tlpInput.Name = "tlpInput";
            this.tlpInput.RowCount = 3;
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpInput.Size = new System.Drawing.Size(840, 128);
            this.tlpInput.TabIndex = 19;
            // 
            // dgvThuoc
            // 
            this.dgvThuoc.AllowUserToAddRows = false;
            this.dgvThuoc.AllowUserToDeleteRows = false;
            this.dgvThuoc.AllowUserToResizeColumns = false;
            this.dgvThuoc.AllowUserToResizeRows = false;
            this.dgvThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThuoc.Location = new System.Drawing.Point(0, 369);
            this.dgvThuoc.Name = "dgvThuoc";
            this.dgvThuoc.ReadOnly = true;
            this.dgvThuoc.RowHeadersVisible = false;
            this.dgvThuoc.RowHeadersWidth = 51;
            this.dgvThuoc.RowTemplate.Height = 24;
            this.dgvThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThuoc.Size = new System.Drawing.Size(1100, 317);
            this.dgvThuoc.TabIndex = 24;
            this.dgvThuoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThuoc_CellContentClick);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(426, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(114, 28);
            this.btnLoad.TabIndex = 20;
            this.btnLoad.Text = "Tải dữ liệu";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // frmThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 686);
            this.Controls.Add(this.dgvThuoc);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThuoc";
            this.Text = "frmThuoc";
            this.Load += new System.EventHandler(this.frmThuoc_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tlpInput.ResumeLayout(false);
            this.tlpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtTenThuoc;
        private System.Windows.Forms.TextBox txtHoatChat;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.ComboBox cboDonViTinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.TableLayoutPanel tlpInput;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.DataGridView dgvThuoc;
        private System.Windows.Forms.Button btnLoad;
    }
}