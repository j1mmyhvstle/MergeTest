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
    public partial class NewEmployee : Form
    {
        Dashboard dashboardForm = new Dashboard();
        function fn = new function();
        String query;
        public NewEmployee()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewEmployee_Load(object sender, EventArgs e)
        {
            this.Location = new Point(450, 131);
        }

        public void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmaild.Clear();
            txtPernament.Clear();
            txtDesignation.SelectedIndex = -1;
            txtUniqueId.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtName.Text != "" && txtFather.Text != "" && txtMother.Text != "" && txtEmaild.Text != "" && txtPernament.Text != "" && txtUniqueId.Text != "" && txtDesignation.SelectedIndex != -1)
            {
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String name = txtName.Text;
                String fname = txtFather.Text;
                String mname = txtMother.Text;
                String email = txtEmaild.Text;
                String address = txtPernament.Text;
                String designation = txtDesignation.Text;
                String id = txtUniqueId.Text;

                query = "insert into newEmployee(emobile, ename, efname, emname, eemail, epaddress, eidproof, edesignation) values (" + mobile + ", '" + name + "', '" + fname + "', '" + mname + "', '" + email + "', '" + address + "', '" + id + "', '" + designation + "')";
                fn.setData(query, "Đã thêm nhân viên mới thành công");
                clearAll();
            } else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fn.back(this, dashboardForm);
        }
    }
}
