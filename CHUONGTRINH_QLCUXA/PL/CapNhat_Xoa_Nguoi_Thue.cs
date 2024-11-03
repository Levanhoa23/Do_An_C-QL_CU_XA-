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
    public partial class CapNhat_Xoa_Nguoi_Thue : Form
    {
        function fn = new function();
        String query;
        public CapNhat_Xoa_Nguoi_Thue()
        {
            InitializeComponent();
        }

        private void CapNhat_Xoa_Nguoi_Thue_Load(object sender, EventArgs e)
        {
            this.Location = new Point(550, 123);

        }
        public void clearAll()
        {
            txtCCCD.Clear();
            txtDiaChiO.Clear();
            txtNguoi_Thue.Clear();
            txtSDT.Clear();
            txtSoPhong.Clear();
            cboTinh_Trang.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query ="Select * From Nguoi_Thue Where so_dien_thoai =" +txtSDT.Text+"";
            DataSet ds = fn.getData(query);

            if(ds.Tables[0].Rows.Count != 0)
            {
                txtNguoi_Thue.Text = ds.Tables[0].Rows[0][2].ToString();
                txtCCCD.Text = ds.Tables[0].Rows [0][4].ToString();
                txtDiaChiO.Text = ds.Tables[0].Rows[0][3].ToString();
                txtSDT.Text = ds.Tables[0].Rows[0][1].ToString();
                txtSoPhong.Text = ds.Tables[0].Rows[0][5].ToString();
                cboTinh_Trang.Text = ds.Tables[0].Rows[0][6].ToString();

            }
            else
            {
                clearAll();
                MessageBox.Show("Số điện thoại này không tồn tại!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Int64 sdt = Int64.Parse(txtSDT.Text);   
            String ten_nguoi_thue = txtNguoi_Thue.Text;
            String cccd = txtCCCD.Text;
            String diachi = txtDiaChiO.Text;
            Int64 sophong = Int64.Parse(txtSoPhong.Text);
            String tinhtrang = cboTinh_Trang.Text;

            string query = "Update Nguoi_thue set ho_ten ='" + ten_nguoi_thue + "', CCCD = '"+ cccd + "', dia_chi = '"+ diachi + "',so_dien_thoai = '"+ sdt + "',so_phong = '"+ sophong + "'";
            fn.setData(query, "Cập nhật thành công!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) { 
                query ="Delete From Nguoi_thue Where so_dien_thoai ="+txtSDT.Text+"";
                fn.setData(query, "Xoá thành công!");
                clearAll();
            }
        }

        private void txtNguoi_Thue_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtSoPhong_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
