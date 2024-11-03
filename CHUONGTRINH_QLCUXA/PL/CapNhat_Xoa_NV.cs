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
    public partial class CapNhat_Xoa_NV : Form
    {
        function fn = new function();
        String query;
        public CapNhat_Xoa_NV()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CapNhat_Xoa_NV_Load(object sender, EventArgs e)
        {
            this.Location = new Point(550, 123);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "Select * from Them_NhanVien Where so_dien_thoai=" + txtSDT.Text + "";
            DataSet ds = fn.getData(query);

            if(ds.Tables[0].Rows.Count !=0){
                txttennhanvien.Text = ds.Tables[0].Rows[0][2].ToString();
                txtcccd.Text = ds.Tables[0].Rows[0][3].ToString();  
                cbochucvu.Text = ds.Tables[0].Rows[0][4].ToString();
                txtdiachi.Text = ds.Tables[0].Rows[0][5].ToString();
                cbotinhtrang.Text = ds.Tables[0].Rows[0][6].ToString();

            }
            else
            {
                MessageBox.Show("Thông tin nhân viên này không tồn tại", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            txtcccd.Clear();
            txtdiachi.Clear();
            txtSDT.Clear();
            txttennhanvien.Clear();
            cbochucvu.SelectedIndex = -1;
            cbotinhtrang.SelectedIndex = -1;
        }

        private void btnUpdata_Click(object sender, EventArgs e)
        {
            Int64 sodienthoai = Int64.Parse(txtSDT.Text);
            String cccd = txtcccd.Text;
            String diachi = txtdiachi.Text;
            String tennv = txttennhanvien.Text;
            String chucvu = cbochucvu.Text;
            String tinhtrang = cbotinhtrang.Text;

            // Sửa cú pháp truy vấn UPDATE
            query = "UPDATE Them_Nhanvien SET ho_ten = '" + tennv + "', cccd = '" + cccd + "', dia_chi = '" + diachi + "', chuc_danh = '" + chucvu + "', dang_lam = '" + tinhtrang + "' WHERE so_dien_thoai = " + sodienthoai;

            // Thực thi truy vấn
            fn.setData(query, "Cập nhật dữ liệu thành công!");
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        

        private void btnXoa_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn chắc chắn muốn xóa không!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                query = "Delete from them_nhanvien where so_dien_thoai=" + txtSDT.Text + "";
                fn.setData(query, "Xóa thành công!");
                clearAll();
            }

        }
    }
}
