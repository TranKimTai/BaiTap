namespace BTH5
{
    partial class Form1
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
            this.btn_cong = new System.Windows.Forms.Button();
            this.btn_tru = new System.Windows.Forms.Button();
            this.btn_nhan = new System.Windows.Forms.Button();
            this.btn_chia = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.vbtn_thoat = new System.Windows.Forms.Button();
            this.lbl_tieude = new System.Windows.Forms.Label();
            this.lbl_son = new System.Windows.Forms.Label();
            this.lbl_som = new System.Windows.Forms.Label();
            this.lbl_ketqua = new System.Windows.Forms.Label();
            this.txt_son = new System.Windows.Forms.TextBox();
            this.txt_som = new System.Windows.Forms.TextBox();
            this.txt_ketqua = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_cong
            // 
            this.btn_cong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cong.Location = new System.Drawing.Point(112, 191);
            this.btn_cong.Name = "btn_cong";
            this.btn_cong.Size = new System.Drawing.Size(75, 36);
            this.btn_cong.TabIndex = 0;
            this.btn_cong.Text = "+";
            this.btn_cong.UseVisualStyleBackColor = true;
            this.btn_cong.Click += new System.EventHandler(this.btn_cong_Click);
            // 
            // btn_tru
            // 
            this.btn_tru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tru.Location = new System.Drawing.Point(193, 191);
            this.btn_tru.Name = "btn_tru";
            this.btn_tru.Size = new System.Drawing.Size(75, 36);
            this.btn_tru.TabIndex = 0;
            this.btn_tru.Text = "-";
            this.btn_tru.UseVisualStyleBackColor = true;
            this.btn_tru.Click += new System.EventHandler(this.btn_tru_Click);
            // 
            // btn_nhan
            // 
            this.btn_nhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nhan.Location = new System.Drawing.Point(274, 191);
            this.btn_nhan.Name = "btn_nhan";
            this.btn_nhan.Size = new System.Drawing.Size(75, 36);
            this.btn_nhan.TabIndex = 0;
            this.btn_nhan.Text = "*";
            this.btn_nhan.UseVisualStyleBackColor = true;
            this.btn_nhan.Click += new System.EventHandler(this.btn_nhan_Click);
            // 
            // btn_chia
            // 
            this.btn_chia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chia.Location = new System.Drawing.Point(355, 191);
            this.btn_chia.Name = "btn_chia";
            this.btn_chia.Size = new System.Drawing.Size(75, 36);
            this.btn_chia.TabIndex = 0;
            this.btn_chia.Text = "/";
            this.btn_chia.UseVisualStyleBackColor = true;
            this.btn_chia.Click += new System.EventHandler(this.btn_chia_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.Location = new System.Drawing.Point(436, 191);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(75, 36);
            this.btn_xoa.TabIndex = 0;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // vbtn_thoat
            // 
            this.vbtn_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vbtn_thoat.Location = new System.Drawing.Point(517, 191);
            this.vbtn_thoat.Name = "vbtn_thoat";
            this.vbtn_thoat.Size = new System.Drawing.Size(75, 36);
            this.vbtn_thoat.TabIndex = 0;
            this.vbtn_thoat.Text = "Thoát";
            this.vbtn_thoat.UseVisualStyleBackColor = true;
            this.vbtn_thoat.Click += new System.EventHandler(this.vbtn_thoat_Click);
            // 
            // lbl_tieude
            // 
            this.lbl_tieude.AutoSize = true;
            this.lbl_tieude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tieude.Location = new System.Drawing.Point(287, 9);
            this.lbl_tieude.Name = "lbl_tieude";
            this.lbl_tieude.Size = new System.Drawing.Size(221, 20);
            this.lbl_tieude.TabIndex = 1;
            this.lbl_tieude.Text = "THỰC HIỆN CÁC PHÉP TÍNH";
            // 
            // lbl_son
            // 
            this.lbl_son.AutoSize = true;
            this.lbl_son.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_son.Location = new System.Drawing.Point(190, 53);
            this.lbl_son.Name = "lbl_son";
            this.lbl_son.Size = new System.Drawing.Size(81, 20);
            this.lbl_son.TabIndex = 1;
            this.lbl_son.Text = "Nhập số n";
            // 
            // lbl_som
            // 
            this.lbl_som.AutoSize = true;
            this.lbl_som.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_som.Location = new System.Drawing.Point(189, 94);
            this.lbl_som.Name = "lbl_som";
            this.lbl_som.Size = new System.Drawing.Size(85, 20);
            this.lbl_som.TabIndex = 1;
            this.lbl_som.Text = "Nhập số m";
            // 
            // lbl_ketqua
            // 
            this.lbl_ketqua.AutoSize = true;
            this.lbl_ketqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ketqua.Location = new System.Drawing.Point(189, 135);
            this.lbl_ketqua.Name = "lbl_ketqua";
            this.lbl_ketqua.Size = new System.Drawing.Size(64, 20);
            this.lbl_ketqua.TabIndex = 1;
            this.lbl_ketqua.Text = "Kết quả";
            // 
            // txt_son
            // 
            this.txt_son.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_son.Location = new System.Drawing.Point(291, 53);
            this.txt_son.Name = "txt_son";
            this.txt_son.Size = new System.Drawing.Size(238, 26);
            this.txt_son.TabIndex = 2;
            this.txt_son.TextChanged += new System.EventHandler(this.txt_son_TextChanged);
            // 
            // txt_som
            // 
            this.txt_som.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_som.Location = new System.Drawing.Point(291, 94);
            this.txt_som.Name = "txt_som";
            this.txt_som.Size = new System.Drawing.Size(238, 26);
            this.txt_som.TabIndex = 3;
            this.txt_som.TextChanged += new System.EventHandler(this.txt_som_TextChanged);
            // 
            // txt_ketqua
            // 
            this.txt_ketqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ketqua.Location = new System.Drawing.Point(291, 135);
            this.txt_ketqua.Name = "txt_ketqua";
            this.txt_ketqua.Size = new System.Drawing.Size(238, 26);
            this.txt_ketqua.TabIndex = 4;
            this.txt_ketqua.Text = " ";
            this.txt_ketqua.TextChanged += new System.EventHandler(this.txt_ketqua_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 261);
            this.Controls.Add(this.txt_ketqua);
            this.Controls.Add(this.txt_som);
            this.Controls.Add(this.txt_son);
            this.Controls.Add(this.lbl_ketqua);
            this.Controls.Add(this.lbl_som);
            this.Controls.Add(this.lbl_son);
            this.Controls.Add(this.lbl_tieude);
            this.Controls.Add(this.vbtn_thoat);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_chia);
            this.Controls.Add(this.btn_nhan);
            this.Controls.Add(this.btn_tru);
            this.Controls.Add(this.btn_cong);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cong;
        private System.Windows.Forms.Button btn_tru;
        private System.Windows.Forms.Button btn_nhan;
        private System.Windows.Forms.Button btn_chia;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button vbtn_thoat;
        private System.Windows.Forms.Label lbl_tieude;
        private System.Windows.Forms.Label lbl_son;
        private System.Windows.Forms.Label lbl_som;
        private System.Windows.Forms.Label lbl_ketqua;
        private System.Windows.Forms.TextBox txt_son;
        private System.Windows.Forms.TextBox txt_som;
        private System.Windows.Forms.TextBox txt_ketqua;
    }
}

