using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_ĐTĐM_
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        public Form1()
        {
            InitializeComponent();

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (KiemTraDangNhap(taiKhoan, matKhau))
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide(); 
            }
            else
            {
                MessageBox.Show("Bạn đã nhập sai tài khoản hoặc mật khẩu. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            string query = $"SELECT COUNT(*) FROM Users WHERE TaiKhoan = '{taiKhoan}' AND MatKhau = '{matKhau}'";
            DataTable result = database.Query(query);

            if (result.Rows.Count > 0 && (int)result.Rows[0][0] > 0)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
    }
}
