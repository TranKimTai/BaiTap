namespace BTH10
{
    partial class frmDSSinhvien
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
            this.lb_dssv = new System.Windows.Forms.ListBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Capnhat = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(209, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "DANH SÁCH SINH VIÊN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lb_dssv
            // 
            this.lb_dssv.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lb_dssv.FormattingEnabled = true;
            this.lb_dssv.Location = new System.Drawing.Point(37, 46);
            this.lb_dssv.Name = "lb_dssv";
            this.lb_dssv.Size = new System.Drawing.Size(590, 147);
            this.lb_dssv.TabIndex = 20;
            // 
            // btn_them
            // 
            this.btn_them.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btn_them.Location = new System.Drawing.Point(53, 218);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(118, 32);
            this.btn_them.TabIndex = 19;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Xoa.Location = new System.Drawing.Point(192, 218);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(135, 32);
            this.btn_Xoa.TabIndex = 21;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Capnhat
            // 
            this.btn_Capnhat.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Capnhat.Location = new System.Drawing.Point(356, 218);
            this.btn_Capnhat.Name = "btn_Capnhat";
            this.btn_Capnhat.Size = new System.Drawing.Size(125, 32);
            this.btn_Capnhat.TabIndex = 22;
            this.btn_Capnhat.Text = "Cập nhật";
            this.btn_Capnhat.UseVisualStyleBackColor = true;
            this.btn_Capnhat.Click += new System.EventHandler(this.btn_Capnhat_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Thoat.Location = new System.Drawing.Point(489, 219);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(120, 30);
            this.btn_Thoat.TabIndex = 23;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click_1);
            // 
            // frmDSSinhvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 261);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Capnhat);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.lb_dssv);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.label1);
            this.Name = "frmDSSinhvien";
            this.Text = "frmSinhvien";
            this.Load += new System.EventHandler(this.frmDSSinhvien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_them;
        public System.Windows.Forms.Button btn_Xoa;
        public System.Windows.Forms.Button btn_Capnhat;
        public System.Windows.Forms.Button btn_Thoat;
        public System.Windows.Forms.ListBox lb_dssv;
    }
}