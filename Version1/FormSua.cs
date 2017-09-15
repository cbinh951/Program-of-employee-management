using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Version1
{
    public partial class FormSua : Form
    {
        public FormSua()
        {
            InitializeComponent();
        }

        public string MaSo, HoTen, DiaChi, ThongTinRieng, ChucVu;
        public double HeSoLuong, LuongCanBan;
        public DateTime NgaySinh;

        public int idx;//Vị trí dòng vừa chọn để sửa

        private void FormSua_Load(object sender, EventArgs e)
        {
            txtMaSo.Text = MaSo;
            txtHoTen.Text = HoTen;
            txtDiaChi.Text = DiaChi;
            txtHeSoLuong.Text = HeSoLuong.ToString();
            txtLuongCanBan.Text = LuongCanBan.ToString();
            dtpNgaySinh.Value = NgaySinh;

            if (ChucVu == "Programmer")
            {
                rdbProgrammer.Checked = true;
            }
            else if (ChucVu == "Designer")
            {
                rdbDesigner.Checked = true;
            }
            else if (ChucVu == "Tester")
            {
                rdbTester.Checked = true;
            }
            else if (ChucVu == "Manager")
            {
                rdbManager.Checked = true;
            }
            txtThongTinRieng.Text = ThongTinRieng;

            txtMaSo.Enabled = false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            FormChinh.static_MaSo = txtMaSo.Text;
            FormChinh.static_HoTen = txtHoTen.Text;
            FormChinh.static_DiaChi = txtDiaChi.Text;
            FormChinh.static_HeSoLuong = double.Parse(txtHeSoLuong.Text);
            FormChinh.static_LuongCanBan = double.Parse(txtLuongCanBan.Text);
            FormChinh.static_NgaySinh = dtpNgaySinh.Value;

            if (rdbProgrammer.Checked == true)
            {
                FormChinh.static_ChucVu = "Programmer";
            }
            else if (rdbDesigner.Checked == true)
            {
                FormChinh.static_ChucVu = "Designer";
            }
            else if (rdbTester.Checked == true)
            {
                FormChinh.static_ChucVu = "Tester";
            }
            else if (rdbManager.Checked == true)
            {
                FormChinh.static_ChucVu = "Manager";
                txtThongTinRieng.Text = "NULL";
            }
            FormChinh.static_ThongTinRieng = txtThongTinRieng.Text;

            //Cập nhật lại trong congty
            if (rdbProgrammer.Checked == true)
            {
                FormChinh.congty.DANHSACH[idx] = new Programmer(txtMaSo.Text, txtHoTen.Text, txtDiaChi.Text, dtpNgaySinh.Value, 
                    double.Parse(txtHeSoLuong.Text), double.Parse(txtLuongCanBan.Text), double.Parse(txtThongTinRieng.Text));
            }
            else if (rdbDesigner.Checked == true)
            {
                FormChinh.congty.DANHSACH[idx] = new Designer(txtMaSo.Text, txtHoTen.Text, txtDiaChi.Text, dtpNgaySinh.Value,
                    double.Parse(txtHeSoLuong.Text), double.Parse(txtLuongCanBan.Text), double.Parse(txtThongTinRieng.Text));
            }
            else if (rdbTester.Checked == true)
            {
                FormChinh.congty.DANHSACH[idx] = new Tester(txtMaSo.Text, txtHoTen.Text, txtDiaChi.Text, dtpNgaySinh.Value,
                    double.Parse(txtHeSoLuong.Text), double.Parse(txtLuongCanBan.Text), int.Parse(txtThongTinRieng.Text));
            }
            else if (rdbManager.Checked == true)
            {
                FormChinh.congty.DANHSACH[idx] = new Manager(txtMaSo.Text, txtHoTen.Text, txtDiaChi.Text, dtpNgaySinh.Value,
                    double.Parse(txtHeSoLuong.Text), double.Parse(txtLuongCanBan.Text));
            }
            this.Close();
        }

        
    }
}
