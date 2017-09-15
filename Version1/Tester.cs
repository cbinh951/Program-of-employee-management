using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    class Tester : NhanVien
    {
        private int SoLoi;

        public int SOLOI
        {
            get { return SoLoi; }
            set { SoLoi = value; }
        }

        public Tester()
            : base()
        {
            SoLoi = 0;
        }

        public Tester(string maso, string hoten, string diachi, DateTime ngaysinh, double hesoluong, double luongcanban, int soloi)
            : base(maso, hoten, diachi, ngaysinh, hesoluong, luongcanban)
        {
            SoLoi = soloi;
        }

        public Tester(Tester kiemloi)
            : base(kiemloi)
        {
            SoLoi = kiemloi.SoLoi;
        }

        public override double TinhLuong()
        {
            return LuongCanBan * HeSoLuong + SoLoi * 100000;
        }
    }
}
