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
    public partial class UpdateDeleteEmployee : Form
    {
        Dashboard dashboardForm = new Dashboard();
        function fn = new function();
        String query;
        public UpdateDeleteEmployee()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            fn.close();
        }

        private void UpdateDeleteEmployee_Load(object sender, EventArgs e)
        {
            this.Location = new Point(450, 131);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM newEmployee WHERE emobile = " + txtMobile.Text + "";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtFather.Text = ds.Tables[0].Rows[0][3].ToString();
                txtMother.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmailID.Text = ds.Tables[0].Rows[0][5].ToString();
                txtPermanent.Text = ds.Tables[0].Rows[0][6].ToString();
                txtUniqueID.Text = ds.Tables[0].Rows[0][7].ToString();
                txtDesignation.Text = ds.Tables[0].Rows[0][8].ToString();
                txtWorking.Text = ds.Tables[0].Rows[0][9].ToString();
            } else
            {
                MessageBox.Show("Hồ sơ này không tồn tại", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearAll();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String name = txtName.Text;
            String fname = txtFather.Text;
            String mname = txtMother.Text;
            String email = txtEmailID.Text;
            String paddress = txtPermanent.Text;
            String id = txtUniqueID.Text;
            String designation = txtDesignation.Text;
            String working = txtWorking.Text;

            query = "Update newEmployee set ename = '" + name + "', efname = '" + fname + "', emname = '" + mname + "', eemail = '" + email + "', epaddress = '" + paddress + "', eidproof = '" + id + "', edesignation = '" + designation + "', working='" + working + "' where emobile = " + mobile + "";
            fn.setData(query, "Cập nhật dữ liệu thành công.");
        }


        private void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmailID.Clear();
            txtPermanent.Clear();
            txtUniqueID.Clear();
            txtDesignation.SelectedIndex = -1;
            txtWorking.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                query = "DELETE FROM newEmployee WHERE emobile = " + txtMobile.Text + "";
                fn.setData(query, "Đã xóa hồ sơ nhân viên");
                clearAll();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fn.back(this, dashboardForm);
        }
    }
}
