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
    

    public partial class Thanh_Toan_Phong : Form
    {
        function fn = new function();
        String query;
        public Thanh_Toan_Phong()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Thanh_Toan_Phong_Load(object sender, EventArgs e)
        {
            this.Location = new Point(550, 123);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "MMMM-yyyy";


        }
        public void setDataGrid(Int64 so_dien_thoai)
        {
            query = "Select * From Nguoi_Thue Where so_dien_thoai =" + txtSDT.Text + "";
            DataSet ds = fn.getData(query);
            dataGridView.DataSource = ds.Tables[0];
        }
        private void clearAll()
        {
            txtSDT.Clear();
            txtSoPhong.Clear();
            txtthanhtoan.Clear();
            txtNguoi_Thue.Clear();
            dataGridView.DataSource = 0;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSDT.Text != "")
            {
                query = "Select * From NGUOI_THUE Where so_dien_thoai = " + txtSDT.Text + "";
                DataSet ds = fn.getData(query);

                if(ds.Tables[0].Rows.Count != 0)
                {
                    txtNguoi_Thue.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtSoPhong.Text = ds.Tables[0].Rows[0][1].ToString();
                    setDataGrid(Int64.Parse(txtSDT.Text));  

                }
                else
                {
                    MessageBox.Show("Người thuê này không tồn tại!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text != "" && txtthanhtoan.Text != "")
            {
                query = "Select * From Thanh_Toan Where so_dien_thoai = " + Int64.Parse(txtSDT.Text) + " and thang = '" + dateTimePicker.Text + "'";
                DataSet ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    Int64 sodienthoai = Int64.Parse(txtSDT.Text);
                    String thang = dateTimePicker.Text;
                    Int64 sotien = Int64.Parse(txtthanhtoan.Text);

                    query = "Insert into Thanh_Toan(so_dien_thoai, thang, so_tien) values(" + sodienthoai + ", '" + thang + "', " + sotien + ")";
                    fn.setData(query, "Phí đã trả!");
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Không có lệ phí của"+ dateTimePicker.Text+" còn lại!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

}
}
