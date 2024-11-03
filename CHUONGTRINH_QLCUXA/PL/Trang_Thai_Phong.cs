using CHUONGTRINH_QLCUXA.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHUONGTRINH_QLCUXA.PL
{
    public partial class Trang_Thai_Phong : Form
    {
        function fn = new function();
        String query;
        public Trang_Thai_Phong()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Trang_Thai_Phong_Load(object sender, EventArgs e)
        {
            this.Location = new Point(550, 123);
            query = "Select * from NGUOI_THUE Where dang_sinh='Yes'";
            DataSet ds = fn.getData(query);
            dataGridView.DataSource = ds.Tables[0];
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
