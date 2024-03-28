using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class StudentFees : Form
    {
        Dashboard dashboardForm = new Dashboard();
        function fn = new function();
        String query;
        public StudentFees()
        {
            InitializeComponent();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            fn.close();
        }

        private void StudentFees_Load(object sender, EventArgs e)
        {
            this.Location = new Point(450, 131);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "MMMM yyyy";
        }

        public void setDataGrid(Int64 mobile)
        {
            query = "SELECT * FROM fees WHERE mobileNo =" + mobile + "";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

       private void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtAmount.Clear();
            txtRoomNo.Clear();
            txtEmailId.Clear();
            guna2DataGridView1.DataSource = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "")
            {
                query = "SELECT name, email, roomNo from newStudent WHERE mobile =" + txtMobile.Text + "";
                DataSet ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtEmailId.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtRoomNo.Text = ds.Tables[0].Rows[0][2].ToString();
                    setDataGrid(Int64.Parse(txtMobile.Text));   
                } else
                {
                    MessageBox.Show("Hồ sơ này không tồn tại.", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtAmount.Text != "")
            {
                query = "SELECT * FROM fees WHERE mobileNo = " + Int64.Parse(txtMobile.Text) + " and fmonth='" + dateTimePicker.Text + "'";
                DataSet ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    Int64 mobile = Int64.Parse(txtMobile.Text);
                    String month = dateTimePicker.Text;
                    Int64 amount = Int64.Parse(txtAmount.Text);

                    query = "insert into fees values (" + mobile + ", '" + month + "', " + amount + ")";
                    fn.setData(query, "Phí đã trả");
                    clearAll();
                } else
                {
                    MessageBox.Show("Không có lệ phí của " + dateTimePicker.Text + " Còn lại.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fn.back(this, dashboardForm);
        }
    }
}
