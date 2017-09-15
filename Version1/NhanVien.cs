using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    class NhanVien
    {
        protected string MaSo, HoTen, DiaChi;

        public string DIACHI
        {
            get { return DiaChi; }
            set { DiaChi = value; }
        }

        public string HOTEN
        {
            get { return HoTen; }
            set { HoTen = value; }
        }

        public string MASO
        {
            get { return MaSo; }
            set { MaSo = value; }
        }
        protected DateTime NgaySinh;

        public DateTime NGAYSINH
        {
            get { return NgaySinh; }
            set { NgaySinh = value; }
        }
        protected double HeSoLuong, LuongCanBan;

        public double LUONGCANBAN
        {
            get { return LuongCanBan; }
            set { LuongCanBan = value; }
        }

        public double HESOLUONG
        {
            get { return HeSoLuong; }
            set { HeSoLuong = value; }
        }

        public NhanVien()
        {
            MaSo = HoTen = DiaChi = null;
            HeSoLuong = LuongCanBan = 0;
        }

        public NhanVien(string maso, string hoten, string diachi, DateTime ngaysinh, double hesoluong, double luongcanban)
        {
            MaSo = maso;
            this.HoTen = hoten;
            this.DiaChi = diachi;
            this.NgaySinh = ngaysinh;
            this.HeSoLuong = hesoluong;
            this.LuongCanBan = luongcanban;
        }

        public NhanVien(NhanVien nv)
        {
            MaSo = nv.MaSo;
            this.HoTen = nv.HoTen;
            this.DiaChi = nv.DiaChi;
            this.NgaySinh = nv.NgaySinh;
            this.HeSoLuong = nv.HeSoLuong;
            this.LuongCanBan = nv.LuongCanBan;
        }

        public virtual double TinhLuong()
        {
            return 0;
        }
    }
}
