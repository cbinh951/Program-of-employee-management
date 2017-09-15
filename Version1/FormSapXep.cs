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
    public partial class FormSapXep : Form
    {
        public FormSapXep()
        {
            InitializeComponent();
        }

        private void FormSapXep_Load(object sender, EventArgs e)
        {
            cmbSapXep.Items.Add("Sắp xếp tăng dần");
            cmbSapXep.Items.Add("Sắp xếp giảm dần");

            cmbSapXep.SelectedIndex = 0;
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            FormChinh.static_SapXep = cmbSapXep.SelectedIndex;
            this.Close();
        }
    }
}
