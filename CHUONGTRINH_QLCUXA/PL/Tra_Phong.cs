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
    public partial class Tra_Phong : Form
    {
        function fn = new function();
        String query;
        public Tra_Phong()
        {
            InitializeComponent();
        }

        private void Tra_Phong_Load(object sender, EventArgs e)
        {
            this.Location = new Point(550, 123);
            query = "Select  * from Nguoi_thue where ding_sinh='No'";
            DataSet ds = fn.getData(query);
            dataGridView.DataSource = ds.Tables[0];

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
