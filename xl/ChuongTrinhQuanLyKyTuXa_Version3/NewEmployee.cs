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
            try
            {
                string  mobile = txtMobile.Text;
                String name = txtName.Text;
                String fname = txtFather.Text;
                String mname = txtMother.Text;
                String email = txtEmaild.Text;
                String address = txtPernament.Text;
                String designation = txtDesignation.Text;
                String id = txtUniqueId.Text;

                // Using parameterized query to prevent SQL injection
                string query = "INSERT INTO newEmployee(emobile, ename, efname, emname, eemail, epaddress, eidproof, edesignation) VALUES (@mobile, @name, @fname, @mname, @email, @address, @id, @designation)";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@mobile", SqlDbType.NVarChar,250) { Value = mobile, Direction = ParameterDirection.Input },
            new SqlParameter("@name", SqlDbType.NVarChar, 250) { Value = name , Direction = ParameterDirection.Input},
            new SqlParameter("@fname", SqlDbType.NVarChar, 250) { Value = fname , Direction = ParameterDirection.Input},
            new SqlParameter("@mname", SqlDbType.NVarChar, 250) { Value = mname, Direction = ParameterDirection.Input },
            new SqlParameter("@email", SqlDbType.NVarChar, 250) { Value = email, Direction = ParameterDirection.Input },
            new SqlParameter("@address", SqlDbType.NVarChar, 250) { Value = address , Direction = ParameterDirection.Input},
            new SqlParameter("@designation", SqlDbType.NVarChar, 250) { Value = designation, Direction = ParameterDirection.Input },
            new SqlParameter("@id", SqlDbType.NVarChar, 250) { Value = id , Direction = ParameterDirection.Input}
                };

                // Assuming fn.setData is a method to execute the query
                fn.setData(query, "Thêm dữ liệu thành công!", parameters);
                clearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
