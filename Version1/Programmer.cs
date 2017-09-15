using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    class Programmer : NhanVien
    {
        private double TienNgoaiGio;

        public double TIENNGOAIGIO
        {
            get { return TienNgoaiGio; }
            set { TienNgoaiGio = value; }
        }

        public Programmer() : base()
        {
            TienNgoaiGio = 0;
        }

        public Programmer(string maso, string hoten, string diachi, DateTime ngaysinh, double hesoluong, double luongcanban, double tienngoaigio)
            : base(maso, hoten, diachi, ngaysinh, hesoluong, luongcanban)
        {
            this.TienNgoaiGio = tienngoaigio;
        }

        public Programmer(Programmer laptrinh)
            : base(laptrinh)
        {
            TienNgoaiGio = laptrinh.TienNgoaiGio;
        }

        public override double TinhLuong()
        {
            return LuongCanBan * HeSoLuong + TienNgoaiGio;
        }
    }
}
