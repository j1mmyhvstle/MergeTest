using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class FeedBack : Form
    {
        Dashboard dashboardForm = new Dashboard();
        function fn = new function();
        String query;

        public FeedBack()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FeedBack_Load(object sender, EventArgs e)
        {
            query = "SELECT StudentID,Name,FeedbackText,FeedbackDate FROM Feedback";
            DataSet ds = fn.getData(query);

            // Kiểm tra nếu có ít nhất một bảng dữ liệu trong DataSet
            if (ds.Tables.Count > 0)
            {
                // Kiểm tra nếu bảng dữ liệu có ít nhất một hàng
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Gán DataSource của dataGridView1 là bảng dữ liệu từ DataSet
                    dataGridView1.DataSource = ds.Tables[0];
                  


                }
                else
                {
                    // Nếu không có hàng nào trong bảng dữ liệu, thông báo cho người dùng
                    MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Nếu không có bảng dữ liệu trong DataSet, thông báo cho người dùng
                MessageBox.Show("Không có dữ liệu từ cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            fn.close();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fn.back(this, dashboardForm);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo người dùng đã chọn một hàng hợp lệ
            {
                // Lấy giá trị của các cột của hàng được chọn
                int studentId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["StudentID"].Value);
                string name  = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                string feedbackText = dataGridView1.Rows[e.RowIndex].Cells["FeedbackText"].Value.ToString();
                DateTime feedbackDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["FeedbackDate"].Value);

                // Hiển thị thông tin trong các controls tương ứng
                tbid.Text = $"ID: {studentId}";
                tbname.Text =$"Name :{name}";
                tbfeedback.Text = $"{feedbackText}";
                tbdate.Text = $"Date: {feedbackDate}";
                tbid.ReadOnly = true;
                tbname.ReadOnly = true;
                tbfeedback.ReadOnly = true;
                tbdate.ReadOnly = true;
            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Xóa tất cả dữ liệu từ cơ sở dữ liệu
            string deleteAllQuery = "DELETE FROM student_feedback";
            fn.setData(deleteAllQuery, "Đã xóa hết thông tin.");

            // Sau khi xóa dữ liệu từ cơ sở dữ liệu, cập nhật lại DataGridView
            dataGridView1.Rows.Clear();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy studentId của hàng được chọn
                int studentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["student_id"].Value);

                // Xóa dữ liệu từ cơ sở dữ liệu
                string deleteQuery = $"DELETE FROM student_feedback WHERE student_id = {studentId}";
                fn.setData(deleteQuery, "Đã xóa hàng được chọn.");

                // Sau khi xóa dữ liệu từ cơ sở dữ liệu, cập nhật lại DataGridView
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }

        }

       

        private void btHotro_Click(object sender, EventArgs e)
        {
            this.Hide();
            Response rp = new Response();
            rp.Show();
        }
    }
}
