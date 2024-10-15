using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_ĐTĐM_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            loadDgvSinhVien();
        }
        private void loadDgvSinhVien()
        {
            dgvSinhVien.DataSource = database.Query("SELECT * FROM SinhVien");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            database.Execute("INSERT SinhVien VALUES('" + txtMaSV.Text + "',N'" + txtTenSV.Text + "')");
            loadDgvSinhVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            database.Execute("DELETE SinhVien WHERE MaSinhVien='" + dgvSinhVien.CurrentRow.Cells[0].Value.ToString() + "'");
            loadDgvSinhVien();
        }
    }
}
