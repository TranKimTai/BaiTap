namespace QuanLyPhongKham.GUI
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBenhNhan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThuoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDichVu = new System.Windows.Forms.ToolStripMenuItem();
            this.nghiệpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhamBenh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThanhToan = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLichSu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbBenhNhan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbKhamBenh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbThuoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbThanhToan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbThoat = new System.Windows.Forms.ToolStripButton();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.nghiệpToolStripMenuItem,
            this.báoCáoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1382, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDoiMatKhau,
            this.mnuDangXuat,
            this.mnuThoat});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.hệThốngToolStripMenuItem.Text = "&Hệ thống";
            // 
            // mnuDoiMatKhau
            // 
            this.mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            this.mnuDoiMatKhau.Size = new System.Drawing.Size(181, 26);
            this.mnuDoiMatKhau.Text = "&Đổi mật khẩu";
            this.mnuDoiMatKhau.Click += new System.EventHandler(this.mnuDoiMatKhau_Click);
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(181, 26);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(181, 26);
            this.mnuThoat.Text = "&Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNhanVien,
            this.mnuBenhNhan,
            this.mnuThuoc,
            this.mnuDichVu});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.danhMụcToolStripMenuItem.Text = "&Danh mục";
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new System.Drawing.Size(215, 26);
            this.mnuNhanVien.Text = "&Quản lý nhân viên";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            // 
            // mnuBenhNhan
            // 
            this.mnuBenhNhan.Name = "mnuBenhNhan";
            this.mnuBenhNhan.Size = new System.Drawing.Size(215, 26);
            this.mnuBenhNhan.Text = "&Quản lý bệnh nhân";
            this.mnuBenhNhan.Click += new System.EventHandler(this.mnuBenhNhan_Click);
            // 
            // mnuThuoc
            // 
            this.mnuThuoc.Name = "mnuThuoc";
            this.mnuThuoc.Size = new System.Drawing.Size(215, 26);
            this.mnuThuoc.Text = "&Kho thuốc";
            this.mnuThuoc.Click += new System.EventHandler(this.mnuThuoc_Click);
            // 
            // mnuDichVu
            // 
            this.mnuDichVu.Name = "mnuDichVu";
            this.mnuDichVu.Size = new System.Drawing.Size(215, 26);
            this.mnuDichVu.Text = "&Dịch vụ khám";
            this.mnuDichVu.Click += new System.EventHandler(this.mnuDichVu_Click);
            // 
            // nghiệpToolStripMenuItem
            // 
            this.nghiệpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKhamBenh,
            this.mnuThanhToan});
            this.nghiệpToolStripMenuItem.Name = "nghiệpToolStripMenuItem";
            this.nghiệpToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.nghiệpToolStripMenuItem.Text = "&Nghiệp vụ";
            // 
            // mnuKhamBenh
            // 
            this.mnuKhamBenh.Name = "mnuKhamBenh";
            this.mnuKhamBenh.Size = new System.Drawing.Size(253, 26);
            this.mnuKhamBenh.Text = "&Tiếp nhận và khám bệnh";
            this.mnuKhamBenh.Click += new System.EventHandler(this.mnuKhamBenh_Click);
            // 
            // mnuThanhToan
            // 
            this.mnuThanhToan.Name = "mnuThanhToan";
            this.mnuThanhToan.Size = new System.Drawing.Size(253, 26);
            this.mnuThanhToan.Text = "&Thanh thoán và hóa đơn";
            this.mnuThanhToan.Click += new System.EventHandler(this.mnuThanhToan_Click);
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDoanhThu,
            this.mnuLichSu});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.báoCáoToolStripMenuItem.Text = "&Báo cáo";
            // 
            // mnuDoanhThu
            // 
            this.mnuDoanhThu.Name = "mnuDoanhThu";
            this.mnuDoanhThu.Size = new System.Drawing.Size(177, 26);
            this.mnuDoanhThu.Text = "&Doanh thu";
            this.mnuDoanhThu.Click += new System.EventHandler(this.mnuDoanhThu_Click);
            // 
            // mnuLichSu
            // 
            this.mnuLichSu.Name = "mnuLichSu";
            this.mnuLichSu.Size = new System.Drawing.Size(177, 26);
            this.mnuLichSu.Text = "&Lịch sử khám";
            this.mnuLichSu.Click += new System.EventHandler(this.mnuLichSu_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBenhNhan,
            this.toolStripSeparator1,
            this.tsbKhamBenh,
            this.toolStripSeparator2,
            this.tsbThuoc,
            this.toolStripSeparator3,
            this.tsbThanhToan,
            this.toolStripSeparator4,
            this.tsbThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1382, 77);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbBenhNhan
            // 
            this.tsbBenhNhan.Image = ((System.Drawing.Image)(resources.GetObject("tsbBenhNhan.Image")));
            this.tsbBenhNhan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBenhNhan.Margin = new System.Windows.Forms.Padding(5);
            this.tsbBenhNhan.Name = "tsbBenhNhan";
            this.tsbBenhNhan.Size = new System.Drawing.Size(97, 67);
            this.tsbBenhNhan.Text = "Bệnh nhân";
            this.tsbBenhNhan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbBenhNhan.Click += new System.EventHandler(this.tsbBenhNhan_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 77);
            // 
            // tsbKhamBenh
            // 
            this.tsbKhamBenh.Image = ((System.Drawing.Image)(resources.GetObject("tsbKhamBenh.Image")));
            this.tsbKhamBenh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbKhamBenh.Margin = new System.Windows.Forms.Padding(5);
            this.tsbKhamBenh.Name = "tsbKhamBenh";
            this.tsbKhamBenh.Size = new System.Drawing.Size(102, 67);
            this.tsbKhamBenh.Text = "Khám bệnh";
            this.tsbKhamBenh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbKhamBenh.Click += new System.EventHandler(this.tsbKhamBenh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 77);
            // 
            // tsbThuoc
            // 
            this.tsbThuoc.Image = ((System.Drawing.Image)(resources.GetObject("tsbThuoc.Image")));
            this.tsbThuoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbThuoc.Margin = new System.Windows.Forms.Padding(5);
            this.tsbThuoc.Name = "tsbThuoc";
            this.tsbThuoc.Size = new System.Drawing.Size(93, 67);
            this.tsbThuoc.Text = "Kho thuốc";
            this.tsbThuoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbThuoc.Click += new System.EventHandler(this.tsbThuoc_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 77);
            // 
            // tsbThanhToan
            // 
            this.tsbThanhToan.Image = ((System.Drawing.Image)(resources.GetObject("tsbThanhToan.Image")));
            this.tsbThanhToan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbThanhToan.Margin = new System.Windows.Forms.Padding(5);
            this.tsbThanhToan.Name = "tsbThanhToan";
            this.tsbThanhToan.Size = new System.Drawing.Size(102, 67);
            this.tsbThanhToan.Text = "Thanh toán";
            this.tsbThanhToan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbThanhToan.Click += new System.EventHandler(this.tsbThanhToan_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 77);
            // 
            // tsbThoat
            // 
            this.tsbThoat.Image = ((System.Drawing.Image)(resources.GetObject("tsbThoat.Image")));
            this.tsbThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbThoat.Margin = new System.Windows.Forms.Padding(5);
            this.tsbThoat.Name = "tsbThoat";
            this.tsbThoat.Size = new System.Drawing.Size(58, 67);
            this.tsbThoat.Text = "Thoát";
            this.tsbThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbThoat.Click += new System.EventHandler(this.tsbThoat_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.BackgroundImage = global::QuanLyPhongKham.Properties.Resources.health;
            this.pnlBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlBody.Controls.Add(this.panel3);
            this.pnlBody.Controls.Add(this.panel1);
            this.pnlBody.Controls.Add(this.pnlFooter);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 105);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1382, 950);
            this.pnlBody.TabIndex = 11;
            this.pnlBody.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBody_Paint);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlFooter.Controls.Add(this.lblStatus);
            this.pnlFooter.Controls.Add(this.lblUser);
            this.pnlFooter.Controls.Add(this.lblClock);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 920);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1382, 30);
            this.pnlFooter.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblStatus.Size = new System.Drawing.Size(116, 30);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Sẵn sàng";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUser.Location = new System.Drawing.Point(767, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblUser.Size = new System.Drawing.Size(376, 30);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Người dùng: ...";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClock
            // 
            this.lblClock.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClock.Location = new System.Drawing.Point(1143, 0);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(239, 30);
            this.lblClock.TabIndex = 0;
            this.lblClock.Text = "00:00:00";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 918);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1382, 2);
            this.panel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1382, 2);
            this.panel1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 1055);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Trang chủ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuBenhNhan;
        private System.Windows.Forms.ToolStripMenuItem mnuThuoc;
        private System.Windows.Forms.ToolStripMenuItem mnuDichVu;
        private System.Windows.Forms.ToolStripMenuItem nghiệpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuKhamBenh;
        private System.Windows.Forms.ToolStripMenuItem mnuThanhToan;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDoanhThu;
        private System.Windows.Forms.ToolStripMenuItem mnuLichSu;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbKhamBenh;
        private System.Windows.Forms.ToolStripButton tsbThanhToan;
        private System.Windows.Forms.ToolStripButton tsbThuoc;
        private System.Windows.Forms.ToolStripButton tsbBenhNhan;
        private System.Windows.Forms.ToolStripButton tsbThoat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblStatus;
    }
}