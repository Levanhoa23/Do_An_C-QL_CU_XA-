using CHUONGTRINH_QLCUXA.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHUONGTRINH_QLCUXA
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 fn = new Form1();
            fn.Show();
            this.Close();
        }

        private void btnQLP_Click(object sender, EventArgs e)
        {
            ThemPhong arr = new ThemPhong();
            arr.Show();


        }

        private void btnNguoiThue_Click(object sender, EventArgs e)
        {
            ThemNguoi tn = new ThemNguoi();
            tn.Show();  

        }

        private void btnCapNhat_XoaNT_Click(object sender, EventArgs e)
        {
            CapNhat_Xoa_Nguoi_Thue udnt = new CapNhat_Xoa_Nguoi_Thue();
            udnt.Show();
        }

        private void btnThanhToanPhong_Click(object sender, EventArgs e)
        {
            Thanh_Toan_Phong ttp = new Thanh_Toan_Phong();
            ttp.Show();
        }

        private void btnTrangThaiPhong_Click(object sender, EventArgs e)
        {
            Trang_Thai_Phong ttp = new Trang_Thai_Phong();
            ttp.Show();
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            Tra_Phong tp = new Tra_Phong();
            tp.Show();
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            Them_Nhan_Vien tn = new Them_Nhan_Vien();
            tn.Show();
        }

        private void btnCapNhat_XoaNV_Click(object sender, EventArgs e)
        {
            CapNhat_Xoa_NV cnx = new CapNhat_Xoa_NV();
            cnx.Show();
        }

        private void btnTTLuongNV_Click(object sender, EventArgs e)
        {
            ThanhToan_Luon luong = new ThanhToan_Luon();
            luong.Show();
        }

        private void btnDanhSachNhanVien_Click(object sender, EventArgs e)
        {
            Danh_SachNV danh_SachNV = new Danh_SachNV();
            danh_SachNV.Show();
        }

        private void btnNVNghiLam_Click(object sender, EventArgs e)
        {
            Danh_SachNV_NLam danh_SachNV_NLam = new Danh_SachNV_NLam();
            danh_SachNV_NLam.Show();
        }
    }
}
