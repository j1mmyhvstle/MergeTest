using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class Dashboard_SV : Form
    {
        function fn = new function();
        string username;
        public Dashboard_SV(string id)
        {
            InitializeComponent();
            this.username = id;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            fn.close();
        }
        private void bntPay_Click(object sender, EventArgs e)
        {
            // form thanh toan cho sinh vien
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            // form rp cho sinh vien
        }
        private void btnNoti_Check_Click(object sender, EventArgs e)
        {
            // form de xem nhung thong bao tu nha truong
        }
        private void btnRoommates_Click(object sender, EventArgs e)
        {
            try
            {
                // xem thu ban cung phong la ai ?
                string smallquery = $"select roomNo from Student where username = '{username}'";
                DataSet ds = fn.getData(smallquery);
                string roomNO = ds.Tables[0].Rows[0][0].ToString();
                string query = $"select CONCAT_WS(' ',fname,mname,lname) as 'Họ và tên'," +
                    $" email as 'Email'," +
                    $" mobile as 'SĐT'" +
                    $" from Student" +
                    $" where roomNo = '"+roomNO+"'";
                DataSet ds1 = fn.getData(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txbMSSV.Text = $"Danh sách thành viên phòng {roomNO}";
                    guna2DataGridView1.DataSource = ds1.Tables[0];
                }
                else
                {
                    MessageBox.Show("Không có bạn cùng phòng !");
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ ở đây
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }   
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(username);
        }
        private void Dashboard_SV_Load(object sender, EventArgs e)
        {
            txbMSSV.Text = "Mã số sinh viên: " + username;
            string query =
            $"select concat_ws(' ',fname,mname,lname) as 'Họ và tên', " +
            $"email as Email, mobile as SĐT, roomNo as 'Phòng' " +
            $"from Student " +
            $"where living = 'Yes' and username = '" + username + "'";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                guna2DataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}

/* CREATE TABLE Student (
	id INT IDENTITY(1, 1) PRIMARY KEY,
	mobile BIGINT NOT NULL,
	lname VARCHAR(250) NOT NULL,
	fname VARCHAR(250) NOT NULL,
	mname VARCHAR(250) NOT NULL,
	email VARCHAR(250) NOT NULL,
	paddress VARCHAR(250) NOT NULL,
	college VARCHAR(250) NOT NULL,
	idproof VARCHAR(250) NOT NULL,
	roomNo BIGINT NOT NULL,
	living VARCHAR(250) DEFAULT 'Yes',
	username VARCHAR(250) NOT NULL,
	password VARCHAR(250) NOT NULL,
	FOREIGN KEY (roomNo) REFERENCES rooms(roomNo)
)

select * from Student
INSERT INTO Student (mobile, lname, fname, mname, email, paddress, college, idproof, roomNo, living, username, password)
VALUES 
(1234567890, 'Nguyen', 'Anh', 'Tuan', 'anhtuan@gmail.com', '123 Le Loi, Q1, HCM', 'DHQG', '123456789', 101, 'Yes', 1001, 'password1'),
(2345678901, 'Tran', 'Bao', 'Ngoc', 'baongoc@gmail.com', '456 Tran Hung Dao, Q5, HCM', 'UIT', '234567890', 102, 'Yes', 1002, 'password2'),
(3456789012, 'Le', 'Thi', 'Mai', 'thimai@gmail.com', '789 Nguyen Trai, Q1, HCM', 'HUTECH', '345678901', 103, 'Yes', 1003, 'password3'),
(4567890123, 'Pham', 'Van', 'Minh', 'vanminh@gmail.com', '321 Le Lai, Q1, HCM', 'NEU', '456789012', 104, 'Yes', 1004, 'password4'),
(5678901234, 'Ho', 'Thi', 'Trang', 'thitrang@gmail.com', '654 Tran Phu, Q5, HCM', 'FTU', '567890123', 105, 'Yes', 1005, 'password5');
INSERT INTO rooms (roomNo, roomStatus, Booked)
VALUES 
(101, 'Available', 'No'),
(102, 'Available', 'No'),
(103, 'Available', 'No'),
(104, 'Available', 'No'),
(105, 'Available', 'No');

-- CREATE TABLE ROOMS
CREATE TABLE rooms (
	roomNo BIGINT not null PRIMARY KEY, 
	roomStatus VARCHAR(250) NOT NULL,
	Booked VARCHAR(150) DEFAULT 'No'
)*/
