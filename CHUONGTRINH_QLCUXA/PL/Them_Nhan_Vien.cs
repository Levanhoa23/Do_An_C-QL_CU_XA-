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
    public partial class Them_Nhan_Vien : Form
    {
        function fn = new function();
        String query;
        public Them_Nhan_Vien()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Them_Nhan_Vien_Load(object sender, EventArgs e)
        {
            this.Location = new Point(550, 123);

        }
        public void clearAll()
        {
            txtSDT.Clear();
            txtNhan_Vien.Clear();
            txtDiaChiO.Clear();
            txtCCCD.Clear();
            cboVai_Tro.SelectedIndex = -1;


        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text != "" && txtNhan_Vien.Text != "" && txtDiaChiO.Text != "" && txtCCCD.Text != ""&& cboVai_Tro.SelectedIndex != -1 )
            {
                Int64 sdt = Int64.Parse(txtSDT.Text);
                String cccd = txtCCCD.Text;
                String tennhanvien = txtNhan_Vien.Text;
                String diachi = txtDiaChiO.Text;
                String chucdanh = cboVai_Tro.Text;

                query = "insert into Them_NhanVien (so_dien_thoai, cccd, ho_ten, dia_chi, chuc_danh) values ("+ sdt+ ",'"+ cccd + "','"+ tennhanvien + "','"+ diachi + "','"+ chucdanh +"')";
                fn.setData(query, "Đã thêm nhân viên!");



            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!","Thông tin",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
