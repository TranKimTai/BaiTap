using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH10
{
    class Sinhvien
    {
        public string hoten;
        public string dienthoai;
        public string diachi;
        public int namsinh;
        public bool gioitinh;
        public string khoahoc;
        public Sinhvien()
        {
            this.hoten = "";
            this.dienthoai = "";
            this.diachi = "";
            this.namsinh = 0;
            this.gioitinh = true;
            this.khoahoc = "";
        }

        public Sinhvien(string hoten, string dienthoai, string diachi, int namsinh, bool gioitinh, string khoahoc)
        {
            this.hoten = hoten;
            this.dienthoai =dienthoai;
            this.diachi =diachi;
            this.namsinh = namsinh;
            this.gioitinh = gioitinh;
            this.khoahoc =khoahoc;
        }

        public int TinhTuoi()
        {
            int tuoi = DateTime.Now.Year - namsinh;
            return tuoi;
        }


    }
}
