using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    class Designer : NhanVien
    {
        private double TienThuong;

        public double TIENTHUONG
        {
            get { return TienThuong; }
            set { TienThuong = value; }
        }

        public Designer()
            : base()
        {
            TienThuong = 0;
        }

        public Designer(string maso, string hoten, string diachi, DateTime ngaysinh, double hesoluong, double luongcanban, double tienthuong)
            : base(maso, hoten, diachi, ngaysinh, hesoluong, luongcanban)
        {
            TienThuong = tienthuong;
        }

        public Designer(Designer thietke)
            : base(thietke)
        {
            TienThuong = thietke.TienThuong;
        }

        public override double TinhLuong()
        {
            return LuongCanBan * HeSoLuong + TienThuong;
        }
    }
}
