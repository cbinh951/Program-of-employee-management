using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    class Manager : NhanVien
    {
        public Manager()
            : base()
        {
        }

        public Manager(string maso, string hoten, string diachi, DateTime ngaysinh, double hesoluong, double luongcanban)
            : base(maso, hoten, diachi, ngaysinh, hesoluong, luongcanban)
        {
        }

        public Manager(Manager quanly)
            : base(quanly)
        {
        }

        public override double TinhLuong()
        {
            return LuongCanBan * HeSoLuong;
        }
    }
}
