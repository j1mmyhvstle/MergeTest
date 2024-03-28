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
    public partial class UpdateDeleteStudent : Form
    {
        Dashboard dashboardForm = new Dashboard();

        function fn = new function();
        String query;

        public UpdateDeleteStudent()
        {
            InitializeComponent();
        }

        private void txtExist_Click(object sender, EventArgs e)
        {
            fn.close();
        }

        private void UpdateDeleteStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(450, 131);
        }

        public void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmail.Clear();
            txtPermanent.Clear();
            txtCollege.Clear();
            txtIdproof.Clear();
            txtRoomNo.Clear();
            comboxLiving.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM newStudent WHERE mobile =" + txtMobile.Text + "";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtFather.Text = ds.Tables[0].Rows[0][3].ToString();
                txtMother.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                txtPermanent.Text = ds.Tables[0].Rows[0][6].ToString();
                txtCollege.Text = ds.Tables[0].Rows[0][7].ToString();
                txtIdproof.Text = ds.Tables[0].Rows[0][8].ToString();
                txtRoomNo.Text = ds.Tables[0].Rows[0][9].ToString();
                comboxLiving.Text = ds.Tables[0].Rows[0][10].ToString();
            } else
            {
                clearAll();
                MessageBox.Show("Số điện thoài này không tồn tại!", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String name = txtName.Text;
            String fname = txtFather.Text;
            String mname = txtMother.Text;
            String email = txtEmail.Text;
            String paddress = txtPermanent.Text;
            String college = txtCollege.Text;
            String idproof = txtIdproof.Text;
            Int64 roomNo = Int64.Parse(txtRoomNo.Text);
            String livingStatus = comboxLiving.Text;


            query = "update newStudent set name= '" + name + "', fname= '" + fname + "', mname= '" + mname + "', email= '" + email + "', paddress= '" + paddress + "', college= '" + college + "', idproof='" + idproof + "', roomNo= " + roomNo + ",living = '" + livingStatus + "' where mobile = " + mobile + " update rooms set Booked  = '" + livingStatus + "' where roomNo = " + roomNo + "";
            fn.setData(query, "Cập nhật dữ liệu thành công!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                query = "DELETE FROM newStudent WHERE mobile = " + txtMobile.Text + "";
                fn.setData(query, "Đã xóa hồ sơ sinh viên");
                clearAll();
            }
    
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMother_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fn.back(this, dashboardForm);
        }
    }
}
