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

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class Noti : Form
    {
        Dashboard dashboardForm = new Dashboard();

        function fn = new function();
        String query;

        public Noti()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fn.back(this, dashboardForm);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            fn.close();


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txttieude.Clear();
            txtnoidung.Clear();
            txtghichu.Clear();
            txtlienlac.Clear();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                String tieude = txttieude.Text;
                String noidung = txtnoidung.Text;
                String ghichu = txtghichu.Text;
                String lienlac = txtlienlac.Text;

                // Tạo câu lệnh SQL INSERT INTO
                string query = "INSERT INTO ThongBao (Tieude, Noidung, Ghichu, LienLac) VALUES (@tieude, @noidung, @ghichu, @lienlac)";

                // Khởi tạo mảng các tham số SqlParameter
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@tieude", SqlDbType.NVarChar, 100) { Value = tieude, Direction = ParameterDirection.Input },
            new SqlParameter("@noidung", SqlDbType.NVarChar, 500) { Value = noidung, Direction = ParameterDirection.Input },
            new SqlParameter("@ghichu", SqlDbType.NVarChar, 200) { Value = ghichu, Direction = ParameterDirection.Input },
            new SqlParameter("@lienlac", SqlDbType.NVarChar, 50) { Value = lienlac, Direction = ParameterDirection.Input }
                };

                // Gọi phương thức setData từ đối tượng fn để thực thi câu lệnh SQL INSERT INTO
                fn.setData(query, "Đã gửi thành công!", parameters);

                // Xóa nội dung các TextBox sau khi thêm thành công
                txttieude.Clear();
                txtnoidung.Clear();
                txtghichu.Clear();
                txtlienlac.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
