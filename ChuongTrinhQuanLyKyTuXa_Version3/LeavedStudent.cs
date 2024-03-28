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
    public partial class LeavedStudent : Form
    {
        Dashboard dashboardForm = new Dashboard();
        function fn = new function();
        String query;
        public LeavedStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            fn.close();
        }

        private void LeavedStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(450, 131);
            query = "SELECT * FROM newStudent WHERE living='No'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            fn.back(this, dashboardForm);
        }
    }
}
