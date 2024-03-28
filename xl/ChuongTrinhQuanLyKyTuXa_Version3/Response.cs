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
    public partial class Response : Form
    {
        Dashboard dashboardForm = new Dashboard();

        function fn = new function();
        String query;
        public Response()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fn.back(this, dashboardForm);
        }

        private void txtExist_Click(object sender, EventArgs e)
        {
            fn.close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTd.Clear();
            txtNd.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ID từ TextBox và chuyển đổi sang kiểu int
                int selectedID = int.Parse(txtID.Text);

                

                if (selectedID > 0) // Nếu ID đã tồn tại
                {
                    // Trích xuất tiêu đề và nội dung từ TextBox
                    string tieude = txtTd.Text;
                    string noidung = txtNd.Text;

                    // Tạo câu lệnh SQL UPDATE để cập nhật dữ liệu vào hàng có ID tương ứng
                    string queryUpdate = "UPDATE Feedback SET TieuDe = @tieude, NoiDungPhanHoi = @noidung WHERE StudentID = @selectedID";

                    // Khởi tạo mảng các tham số SqlParameter
                    SqlParameter[] parameters = new SqlParameter[]
                    {
            new SqlParameter("@selectedID", SqlDbType.Int) { Value = selectedID, Direction = ParameterDirection.Input },
            new SqlParameter("@tieude", SqlDbType.NVarChar, 100) { Value = tieude, Direction = ParameterDirection.Input },
            new SqlParameter("@noidung", SqlDbType.NVarChar, 500) { Value = noidung, Direction = ParameterDirection.Input }
                    };

                    // Gọi phương thức setData từ đối tượng fn để thực thi câu lệnh SQL UPDATE
                    fn.setData(queryUpdate, "Gửi thành công!", parameters);
                }
                else
                {
                    MessageBox.Show("ID không tồn tại trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Response_Load(object sender, EventArgs e)
        {

        }
    }
}
