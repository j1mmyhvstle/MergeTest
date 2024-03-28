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
    public partial class Dashboard : Form
    { 
        function fn = new function() { };
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            fn.close();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login fn = new Login();
            fn.Show();
            this.Close();
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            AddNewRoom anr = new AddNewRoom();
            this.Hide();
            anr.Show();
        }

        private void btnNewStudent_Click(object sender, EventArgs e)
        {
            this.Hide();

            NewStudent nst = new NewStudent();
            nst.Show();
        }

        private void btnUpdateDeleteStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateDeleteStudent uds = new UpdateDeleteStudent();
            uds.Show();
        }

        private void btnStudentFees_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentFees snf = new StudentFees();
            snf.Show();
        }

        private void btnAllStudentLiving_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllStudentLiving asl = new AllStudentLiving();
            asl.Show();
        }

        private void btnLeavedStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            LeavedStudent lsn = new LeavedStudent();
            lsn.Show();
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewEmployee ne = new NewEmployee();
            ne.Show();
        }

        private void btnUpdateDeletedEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateDeleteEmployee ude = new UpdateDeleteEmployee();
            ude.Show();
        }

        private void btnEmployeePayment_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeePayment eep = new EmployeePayment();
            eep.Show();
        }

        private void btnAllEmployeeWorking_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllEmployeeWorking aew = new AllEmployeeWorking();
            aew.Show();
        }

        private void btnLeavedEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            LeavedEmployee lde = new LeavedEmployee();
            lde.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FeedBack fb = new FeedBack();
            fb.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Noti  tb = new Noti();
            tb.Show();
        }
    }
}
