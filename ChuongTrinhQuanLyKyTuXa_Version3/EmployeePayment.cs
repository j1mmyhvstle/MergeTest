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
    public partial class EmployeePayment : Form
    {
        Dashboard dashboardForm = new Dashboard();
        function fn = new function();
        String query;
        public EmployeePayment()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            fn.close();
        }

        private void EmployeePayment_Load(object sender, EventArgs e)
        {
            this.Location = new Point(450, 131);
            monthDateTime.Format = DateTimePickerFormat.Custom;
            monthDateTime.CustomFormat = "MMMM yyyy";
        }

        public void setDataGrid(Int64 mobile)
        {
            query = "SELECT * FROM employeeSalary WHERE mobileNo = " + mobile + "";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "")
            {
                query = "select ename, eemail, edesignation from newEmployee where emobile = " + txtMobile.Text + "";
                DataSet ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtEmailId.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDesignation.Text = ds.Tables[0].Rows[0][2].ToString();

                    setDataGrid(Int64.Parse(txtMobile.Text));
                } else
                {
                    MessageBox.Show("Hồ sơ này không tồn tại", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearAll();
                }
            } else
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtPayAmount.Text != "")
            {
                query = "SELECT * FROM employeeSalary WHERE mobileNo = " + txtMobile.Text + " AND fmonth = '" + monthDateTime.Text + "'";
                DataSet ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count == 0)
                {

                    Int64 mobile = Int64.Parse(txtMobile.Text);
                    String month = monthDateTime.Text;
                    Int64 amount = Int64.Parse(txtPayAmount.Text);

                    query = "insert into employeeSalary values(" + mobile + ", '" + month + "', " + amount + ")";
                    fn.setData(query, "Lương tháng " + monthDateTime.Text + " Đã trã là " + amount);
                    setDataGrid(mobile);
                } else
                {
                    MessageBox.Show("Khoản thanh toán của " + monthDateTime.Text + " Đã thanh toán.", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        public void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtPayAmount.Clear();
            txtDesignation.Clear();
            guna2DataGridView1.DataSource = 0;
            monthDateTime.ResetText();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fn.back(this, dashboardForm);
        }
    }
}
