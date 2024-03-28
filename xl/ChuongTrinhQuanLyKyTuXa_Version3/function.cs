using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    class function
    {
        protected SqlConnection  getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-OHV1CLJ\MSSQLSERVER01;Initial Catalog=hostel;Integrated Security=True";
            return con;
        }
        
        public void back(Form currentForm, Form Dashboard)
        { // Hiển thị hộp thoại thông báo và lấy phản hồi từ người dùng
            DialogResult result = MessageBox.Show("Bạn có muốn quay lại màn hình chính không?", "Xác nhận quay lại màn hình chính", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Xử lý phản hồi từ người dùng
            if (result == DialogResult.Yes)
            {
                // Hiển thị màn hình chính và ẩn form hiện tại
                Dashboard.Show();
                currentForm.Hide();
            }
            else
            {
                // Không làm gì nếu người dùng chọn "No"
            }
        }
        public void close() 
        {
            // Hiển thị hộp thoại thông báo và lấy phản hồi từ người dùng
            DialogResult result = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Xác nhận đóng chương trình", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Xử lý phản hồi từ người dùng
            if (result == DialogResult.Yes)
            {
                // Thoát chương trình nếu người dùng chọn "Yes"
                Application.Exit();
            }
            else
            {
                // Không làm gì nếu người dùng chọn "No"
            }
        }
        public DataSet getData(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public void setData(String query, String msg, SqlParameter[] sqlParams = null)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            if (sqlParams != null) cmd.Parameters.AddRange(sqlParams);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(msg, "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
    