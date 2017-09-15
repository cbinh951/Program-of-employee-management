using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    public class CongTy
    {
        private List<NhanVien> DanhSach = new List<NhanVien>();

        internal List<NhanVien> DANHSACH
        {
            get { return DanhSach; }
            set { DanhSach = value; }
        }

        public bool KiemTraMaSoBiTrung(string maso)
        {
            foreach (NhanVien item in DanhSach)
            {
                if (item.MASO == maso)
                {
                    return false;
                }
            }
            
            return true;
        }

        //public void Swap(NhanVien a, NhanVien b)
        //{
        //    NhanVien temp = a;
        //    a = b;
        //    b = temp;
        //}

        public void SapXepTheoLuong(char c)
        {
            int soluong = DanhSach.Count;
            //Sắp tăng dần
            if(c == 't')
            {
                for (int i = 0; i < soluong - 1; i++)
                {
                    for (int j = i + 1; j < soluong; j++)
                    {
                        if (DanhSach[i].TinhLuong() > DanhSach[j].TinhLuong())
                        {
                           // Swap(DanhSach[i], DanhSach[j]);
                            NhanVien Temp = DanhSach[i];
                            DanhSach[i] = DanhSach[j];
                            DanhSach[j] = Temp;
                        }
                    }
                }
            }
            else if (c == 'g') // Sap giam dan
            {
                for (int i = 0; i < soluong - 1; i++)
                {
                    for (int j = i + 1; j < soluong; j++)
                    {
                        if (DanhSach[i].TinhLuong() < DanhSach[j].TinhLuong())
                        {
                            //Swap(DanhSach[i], DanhSach[j]);
                            NhanVien Temp = DanhSach[i];
                            DanhSach[i] = DanhSach[j];
                            DanhSach[j] = Temp;
                        }
                    }
                }
            }
        }

    }
}
