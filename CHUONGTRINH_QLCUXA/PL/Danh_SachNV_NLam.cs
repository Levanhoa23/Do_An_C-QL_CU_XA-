using CHUONGTRINH_QLCUXA.DAL;
using System;
using System.Collections;
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
    public partial class Danh_SachNV_NLam : Form
    {
        function fn = new function();
        String query;
        public Danh_SachNV_NLam()
        {
            InitializeComponent();
        }

        private void Danh_SachNV_NLam_Load(object sender, EventArgs e)
        {
            this.Location = new Point(550, 123);
            query = "Select  * From Them_NhanVien Where dang_lam='No'";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
