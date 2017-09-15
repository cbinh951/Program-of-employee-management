using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Version1
{
    public partial class FormChinh : Form
    {
        public FormChinh()
        {
            InitializeComponent();
        }

        public static CongTy congty = new CongTy();
        NhanVien nv;

        public static string static_MaSo, static_HoTen, static_DiaChi, static_ThongTinRieng, static_ChucVu, static_TimKiem;
        public static double static_HeSoLuong, static_LuongCanBan;
        public static DateTime static_NgaySinh;
        public static int static_SapXep; //1: Tăng dần, 2: Giảm dần

        private void FormChinh_Load(object sender, EventArgs e)
        {
            //Làm ẩn đi
            grbThongTinRieng.Visible = false;

            //Tạo các cột trong listView
            lsvDanhSach.Columns.Add("STT", 50);
            lsvDanhSach.Columns.Add("Mã Số", 50);
            lsvDanhSach.Columns.Add("Họ Tên", 140);
            lsvDanhSach.Columns.Add("Địa chỉ", 140);
            lsvDanhSach.Columns.Add("Ngày Sinh", 100);
            lsvDanhSach.Columns.Add("Hệ Số Lương", 100);
            lsvDanhSach.Columns.Add("Lương Căn Bản", 100);
            lsvDanhSach.Columns.Add("Chức Vụ", 100);
            lsvDanhSach.Columns.Add("Thông Tin Riêng", 100);
            lsvDanhSach.Columns.Add("Tiền Lương", 100);
        }

        private void rdbProgrammer_CheckedChanged(object sender, EventArgs e)
        {
            grbThongTinRieng.Visible = true;
            lblThongTinRieng.Text = "Tiền Ngoài Giờ";
        }

        private void rdbDesigner_CheckedChanged(object sender, EventArgs e)
        {
            grbThongTinRieng.Visible = true;
            lblThongTinRieng.Text = "Tiền Thưởng";
        }

        private void rdbTester_CheckedChanged(object sender, EventArgs e)
        {
            grbThongTinRieng.Visible = true;
            lblThongTinRieng.Text = "Số Lỗi";
        }

        private void rdbManager_CheckedChanged(object sender, EventArgs e)
        {
            grbThongTinRieng.Visible = false;
        }

        int dem = 1;
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSo.Text == "")
            {
                MessageBox.Show("Chưa nhập mã sổ");
            }
            else if (txtHoTen.Text == "")
            {
                MessageBox.Show("Chưa nhập họ tên");
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Chưa nhập địa chỉ");
            }
            else if (txtHeSoLuong.Text == "")
            {
                MessageBox.Show("Chưa nhập hệ số lương");
            }
            else if (txtLuongCanBan.Text == "")
            {
                MessageBox.Show("Chưa nhập lương căn bản");
            }
            else if (rdbProgrammer.Checked == false && rdbDesigner.Checked == false && rdbTester.Checked == false && rdbManager.Checked == false)
            {
                MessageBox.Show("Chưa lựa chọn loại nhân viên");
            }
            else if ((rdbProgrammer.Checked == true || rdbDesigner.Checked == true && rdbDesigner.Checked == true) && txtThongTinRieng.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin riêng");
            }
            else
            {
                if (congty.KiemTraMaSoBiTrung(txtMaSo.Text) == true)
                {
                    if (rdbProgrammer.Checked == true)
                    {
                        nv = new Programmer(txtMaSo.Text, txtHoTen.Text, txtDiaChi.Text, dtpNgaySinh.Value, double.Parse(txtHeSoLuong.Text),
                            double.Parse(txtLuongCanBan.Text), double.Parse(txtThongTinRieng.Text));
                    }
                    else if (rdbDesigner.Checked == true)
                    {
                        nv = new Designer(txtMaSo.Text, txtHoTen.Text, txtDiaChi.Text, dtpNgaySinh.Value, double.Parse(txtHeSoLuong.Text),
                            double.Parse(txtLuongCanBan.Text), double.Parse(txtThongTinRieng.Text));
                    }
                    else if (rdbTester.Checked == true)
                    {
                        nv = new Tester(txtMaSo.Text, txtHoTen.Text, txtDiaChi.Text, dtpNgaySinh.Value, double.Parse(txtHeSoLuong.Text),
                            double.Parse(txtLuongCanBan.Text), int.Parse(txtThongTinRieng.Text));
                    }
                    else if (rdbManager.Checked == true)
                    {
                        nv = new Manager(txtMaSo.Text, txtHoTen.Text, txtDiaChi.Text, dtpNgaySinh.Value, double.Parse(txtHeSoLuong.Text),
                            double.Parse(txtLuongCanBan.Text));
                    }

                    //Thêm vào trong mảng
                    congty.DANHSACH.Add(nv);

                    //Thêm vào trong ListView
                    string[] arr = new string[10];
                    arr[0] = (dem++).ToString();
                    arr[1] = nv.MASO;
                    arr[2] = nv.HOTEN;
                    arr[3] = nv.DIACHI;
                    arr[4] = (nv.NGAYSINH).ToString("dd/MM/yyyy");
                    arr[5] = nv.HESOLUONG.ToString("0.00");
                    arr[6] = nv.LUONGCANBAN.ToString();

                    if (nv is Programmer)
                    {
                        arr[7] = "Programmer";
                        arr[8] = ((Programmer)nv).TIENNGOAIGIO.ToString();
                    }
                    else if (nv is Designer)
                    {
                        arr[7] = "Designer";
                        arr[8] = ((Designer)nv).TIENTHUONG.ToString();
                    }
                    else if (nv is Tester)
                    {
                        arr[7] = "Tester";
                        arr[8] = ((Tester)nv).SOLOI.ToString();
                    }
                    else if (nv is Manager)
                    {
                        arr[7] = "Manager";
                        arr[8] = "NULL";
                    }
                    arr[9] = nv.TinhLuong().ToString();

                    ListViewItem item = new ListViewItem(arr);
                    lsvDanhSach.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("Mã sổ bị trùng");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count > 0)
            {
                int idx = lsvDanhSach.Items.IndexOf(lsvDanhSach.SelectedItems[0]);
                //Xoá trong congty
                congty.DANHSACH.RemoveAt(idx);

                //Xóa trên listview
                lsvDanhSach.Items.RemoveAt(idx);

                dem--;
                //Cập nhật lại cột STT
                for (int i = idx; i < lsvDanhSach.Items.Count; i++)
                {
                    lsvDanhSach.Items[i].SubItems[0].Text = (i + 1).ToString();
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dòng cần xóa");
            }
        }

        
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count > 0)
            {
                int idx = lsvDanhSach.Items.IndexOf(lsvDanhSach.SelectedItems[0]);

                FormSua frm_sua = new FormSua();
                //Truyền dữ liệu sang Form Sua
                frm_sua.MaSo = lsvDanhSach.Items[idx].SubItems[1].Text;
                frm_sua.HoTen = lsvDanhSach.Items[idx].SubItems[2].Text;
                frm_sua.DiaChi = lsvDanhSach.Items[idx].SubItems[3].Text;
                frm_sua.NgaySinh = DateTime.ParseExact(lsvDanhSach.Items[idx].SubItems[4].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                frm_sua.HeSoLuong = double.Parse(lsvDanhSach.Items[idx].SubItems[5].Text);
                frm_sua.LuongCanBan = double.Parse(lsvDanhSach.Items[idx].SubItems[6].Text);
                frm_sua.ChucVu = lsvDanhSach.Items[idx].SubItems[7].Text;
                frm_sua.ThongTinRieng = lsvDanhSach.Items[idx].SubItems[8].Text;

                frm_sua.idx = idx;
                frm_sua.ShowDialog();

                //Nhận dữ liệu ở form Sua và cập nhật lại ListView
                lsvDanhSach.Items[idx].SubItems[1].Text = static_MaSo;
                lsvDanhSach.Items[idx].SubItems[2].Text = static_HoTen;
                lsvDanhSach.Items[idx].SubItems[3].Text = static_DiaChi;
                lsvDanhSach.Items[idx].SubItems[4].Text = static_NgaySinh.ToString("dd/MM/yyyy");
                lsvDanhSach.Items[idx].SubItems[5].Text = static_HeSoLuong.ToString();
                lsvDanhSach.Items[idx].SubItems[6].Text = static_LuongCanBan.ToString();
                lsvDanhSach.Items[idx].SubItems[7].Text = static_ChucVu;
                lsvDanhSach.Items[idx].SubItems[8].Text = static_ThongTinRieng;

                //Cập nhật lại Luong
                double Luong = static_HeSoLuong * static_LuongCanBan;
                if (static_ChucVu == "Programmer")
                {
                    Luong += double.Parse(static_ThongTinRieng);
                    lsvDanhSach.Items[idx].SubItems[9].Text = Luong.ToString();
                }
                else if (static_ChucVu == "Designer")
                {
                    Luong += double.Parse(static_ThongTinRieng);
                    lsvDanhSach.Items[idx].SubItems[9].Text = Luong.ToString();
                }
                else if (static_ChucVu == "Tester")
                {
                    Luong += double.Parse(static_ThongTinRieng) * 100000;
                    lsvDanhSach.Items[idx].SubItems[9].Text = Luong.ToString();
                }
                else if (static_ChucVu == "Manager")
                {
                    lsvDanhSach.Items[idx].SubItems[9].Text = Luong.ToString();
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dòng cần sửa");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            bool Check = false;

            int soluong = lsvDanhSach.Items.Count;
            for (int i = 0; i < soluong; i++)
            {
                lsvDanhSach.Items[i].BackColor = Color.White;
            }

            FormTimKiem frm_TimKiem = new FormTimKiem();
            frm_TimKiem.ShowDialog();
           
            
            for (int i = 0; i < soluong; i++)
            {
                if (lsvDanhSach.Items[i].SubItems[1].Text == static_TimKiem)
                {
                    lsvDanhSach.Items[i].BackColor = Color.Red;
                    Check = true;
                    break;
                }
            }

            if (Check == false)
            {
                MessageBox.Show("Không tìm thấy");
            }
        }

        string str;
       
        private void txtTen_KeyUp(object sender, KeyEventArgs e)
        {
            int Dem = 1;
            str = txtTen.Text;
            //Xóa các dòng trên ListView
            lsvDanhSach.Items.Clear();

            int soluong = congty.DANHSACH.Count;
            for (int i = 0; i < soluong; i++)
            {
                //Chuẩn hóa thành chuỗi thường
                str = str.ToLower();
                string TenTrongCongTy = congty.DANHSACH[i].HOTEN;
                TenTrongCongTy = TenTrongCongTy.ToLower();

                if (TenTrongCongTy.Contains(str) == true)
                {
                    //Thêm vào trong ListView
                    string[] arr = new string[10];
                    arr[0] = (Dem++).ToString();
                    arr[1] = congty.DANHSACH[i].MASO;
                    arr[2] = congty.DANHSACH[i].HOTEN;
                    arr[3] = congty.DANHSACH[i].DIACHI;
                    arr[4] = (congty.DANHSACH[i].NGAYSINH).ToString("dd/MM/yyyy");
                    arr[5] = congty.DANHSACH[i].HESOLUONG.ToString("0.00");
                    arr[6] = congty.DANHSACH[i].LUONGCANBAN.ToString();

                    if (nv is Programmer)
                    {
                        arr[7] = "Programmer";
                        arr[8] = ((Programmer)congty.DANHSACH[i]).TIENNGOAIGIO.ToString();
                    }
                    else if (congty.DANHSACH[i] is Designer)
                    {
                        arr[7] = "Designer";
                        arr[8] = ((Designer)congty.DANHSACH[i]).TIENTHUONG.ToString();
                    }
                    else if (congty.DANHSACH[i] is Tester)
                    {
                        arr[7] = "Tester";
                        arr[8] = ((Tester)congty.DANHSACH[i]).SOLOI.ToString();
                    }
                    else if (congty.DANHSACH[i] is Manager)
                    {
                        arr[7] = "Manager";
                        arr[8] = "NULL";
                    }
                    arr[9] = congty.DANHSACH[i].TinhLuong().ToString();

                    ListViewItem item = new ListViewItem(arr);
                    lsvDanhSach.Items.Add(item);
                }
            }
        }

       
        private void btnSapXep_Click(object sender, EventArgs e)
        {
            int stt = 1;
            FormSapXep frm_sapxep = new FormSapXep();
            frm_sapxep.ShowDialog();

            if (static_SapXep == 0) // Sắp tăng dần
            {
                lsvDanhSach.Items.Clear();
                congty.SapXepTheoLuong('t');              
            }
            else
            {
                lsvDanhSach.Items.Clear();
                congty.SapXepTheoLuong('g');
            }

            int soluong = congty.DANHSACH.Count;
            for (int i = 0; i < soluong; i++)
            {
                string[] arr = new string[10];
                arr[0] = (stt++).ToString();
                arr[1] = congty.DANHSACH[i].MASO;
                arr[2] = congty.DANHSACH[i].HOTEN;
                arr[3] = congty.DANHSACH[i].DIACHI;
                arr[4] = (congty.DANHSACH[i].NGAYSINH).ToString("dd/MM/yyyy");
                arr[5] = congty.DANHSACH[i].HESOLUONG.ToString("0.00");
                arr[6] = congty.DANHSACH[i].LUONGCANBAN.ToString();

                if (nv is Programmer)
                {
                    arr[7] = "Programmer";
                    arr[8] = ((Programmer)congty.DANHSACH[i]).TIENNGOAIGIO.ToString();
                }
                else if (congty.DANHSACH[i] is Designer)
                {
                    arr[7] = "Designer";
                    arr[8] = ((Designer)congty.DANHSACH[i]).TIENTHUONG.ToString();
                }
                else if (congty.DANHSACH[i] is Tester)
                {
                    arr[7] = "Tester";
                    arr[8] = ((Tester)congty.DANHSACH[i]).SOLOI.ToString();
                }
                else if (congty.DANHSACH[i] is Manager)
                {
                    arr[7] = "Manager";
                    arr[8] = "NULL";
                }
                arr[9] = congty.DANHSACH[i].TinhLuong().ToString();

                ListViewItem item = new ListViewItem(arr);
                lsvDanhSach.Items.Add(item);
            }
        }

        private void btnGhiFile_Click(object sender, EventArgs e)
        {
            FileInfo myfile = new FileInfo("DanhSach.txt");
            StreamWriter ghi = myfile.CreateText(); //Tạo file mới

            int soluong = congty.DANHSACH.Count;
            for (int i = 0; i < soluong; i++)
            {
                ghi.Write(lsvDanhSach.Items[i].SubItems[0].Text);
                ghi.Write("-");
                ghi.Write(lsvDanhSach.Items[i].SubItems[1].Text);
                ghi.Write("-");
                ghi.Write(lsvDanhSach.Items[i].SubItems[2].Text);
                ghi.Write("-");
                ghi.Write(lsvDanhSach.Items[i].SubItems[3].Text);
                ghi.Write("-");
                ghi.Write(lsvDanhSach.Items[i].SubItems[4].Text);
                ghi.Write("-");
                ghi.Write(lsvDanhSach.Items[i].SubItems[5].Text);
                ghi.Write("-");
                ghi.Write(lsvDanhSach.Items[i].SubItems[6].Text);
                ghi.Write("-");
                ghi.Write(lsvDanhSach.Items[i].SubItems[7].Text);
                ghi.Write("-");
                ghi.Write(lsvDanhSach.Items[i].SubItems[8].Text);
                ghi.Write("-");
                ghi.Write(lsvDanhSach.Items[i].SubItems[9].Text);

                ghi.Write(ghi.NewLine); //Ghi dòng mới
            }
            ghi.Close();
            MessageBox.Show("Ghi Thành công");
        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Chọn File";
            opf.Filter = "select file |*.txt";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                StreamReader read = File.OpenText(opf.FileName);
                while (!read.EndOfStream)
                {
                    string doctungdong = read.ReadLine();
                    string[] mang = doctungdong.Split('-');
                    //Thêm vào trong ListView
                    string[] arr = new string[10];
                    arr[0] = mang[0];
                    arr[1] = mang[1];
                    arr[2] = mang[2];
                    arr[3] = mang[3];
                    arr[4] = mang[4];
                    arr[5] = mang[5];
                    arr[6] = mang[6];
                    arr[7] = mang[7];
                    arr[8] = mang[8];
                    arr[9] = mang[9];

                    ListViewItem item = new ListViewItem(arr);
                    lsvDanhSach.Items.Add(item);

                    //Thêm vào trong congty
                    if (arr[7] == "Programmer")
                    {
                        nv = new Programmer(arr[1], arr[2], arr[3], DateTime.ParseExact(arr[4], "dd/MM/yyyy", CultureInfo.InvariantCulture), double.Parse(arr[5]),
                            double.Parse(arr[6]), double.Parse(arr[8]));
                    }
                    else if (arr[7] == "Designer")
                    {
                        nv = new Designer(arr[1], arr[2], arr[3], DateTime.ParseExact(arr[4], "dd/MM/yyyy", CultureInfo.InvariantCulture), double.Parse(arr[5]),
                            double.Parse(arr[6]), double.Parse(arr[8]));
                    }
                    else if (arr[7] == "Tester")
                    {
                        nv = new Tester(arr[1], arr[2], arr[3], DateTime.ParseExact(arr[4], "dd/MM/yyyy", CultureInfo.InvariantCulture), double.Parse(arr[5]),
                            double.Parse(arr[6]), int.Parse(arr[8]));
                    }
                    else if (arr[7] == "Manager")
                    {
                        nv = new Manager(arr[1], arr[2], arr[3], DateTime.ParseExact(arr[4], "dd/MM/yyyy", CultureInfo.InvariantCulture), double.Parse(arr[5]),
                            double.Parse(arr[6]));
                    }

                    //Thêm vào trong mảng
                    congty.DANHSACH.Add(nv);
                }
            }
        }
       
    }
}
