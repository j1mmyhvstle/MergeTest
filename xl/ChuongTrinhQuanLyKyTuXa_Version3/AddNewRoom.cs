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
    public partial class AddNewRoom : Form
    {
        Dashboard dashboardForm = new Dashboard();
        function fn = new function();
        String query;
        public AddNewRoom()
        {
            InitializeComponent();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            fn.close();
        }

        private void AddNewRoom_Load(object sender, EventArgs e)
        {
            this.Location = new Point(450, 131);
            labelRoom.Visible = false;
            labelRoomExist.Visible = false;

            query = "SELECT * FROM rooms";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM rooms  WHERE roomNo=" + txtRoomNo1.Text + "";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                String status;
                if (checkBox1.Checked)
                {
                    status = "Yes";
                } else
                {
                    status = "No";
                }
                labelRoomExist.Visible = false;
                query = "insert into rooms (roomNo, roomStatus) values (" + txtRoomNo1.Text + ",'" + status + "')";
                fn.setData(query, "Đã thêm phòng.");
                AddNewRoom_Load(this, null);
            } else
            {
                labelRoomExist.Text = "Phòng đã có";
                labelRoomExist.Visible = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM rooms WHERE roomNo=" + txtRoomNo2.Text + "";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                labelRoom.Text = "Phòng này không tôn tại";
                labelRoom.Visible = true;
                checkBox2.Checked = false;
            } else
            {
                labelRoom.Text = "Phòng này đã tìm thấy";
                labelRoom.Visible = true;
               
                if (ds.Tables[0].Rows[0][1].ToString() == "Yes")
                {
                    checkBox2.Checked = true;
                } else
                {
                    checkBox2.Visible = false;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String status;
            if (checkBox2.Checked)
            {
                status = "Yes";
            } else
            {
                status = "No";
            }
            query = "update rooms set roomStatus='" + status + "' where roomNo =" + txtRoomNo2.Text + "";
            fn.setData(query, "Cập nhật chi tiết thành công!");
            AddNewRoom_Load(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (labelRoom.Text == "Phòng này đã tìm thấy")
            {
                query = "delete from rooms where roomNo =" + txtRoomNo2.Text + "";
                fn.setData(query, "Đã xóa chi tiết phòng!");
                AddNewRoom_Load(this, null);
            } else
            {
                MessageBox.Show("Thử xóa lại không thấy phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelRoomExist_Click(object sender, EventArgs e)
        {

        }

        private void labelRoom_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fn.back(this, dashboardForm);
        }
    }
}
