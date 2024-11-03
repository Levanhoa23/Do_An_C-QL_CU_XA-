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
    public partial class ThemNguoi : Form
    {
        function fn = new function();
        String query;
        public ThemNguoi()
        {
            InitializeComponent();
        }

        private void ThemNguoi_Load(object sender, EventArgs e)
        {
            this.Location = new Point(550, 123);
            query = "SELECT so_phong from PHONG Where trang_thai = 'Yes' AND da_dat = 'No'";

            DataSet ds = fn.getData(query);
            for(int i = 0; i < ds.Tables.Count; i++)
            {
                Int64 phong = Int64.Parse(ds.Tables[0].Rows[i][0].ToString());
                cboSo_Phong.Items.Add(phong);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void clearAll()
        {
            txtSDT.Clear();
            txtNguoi_Thue.Clear();
            txtCCCD.Clear();
            txtDiaChiO.Clear();
            cboSo_Phong.SelectedIndex = -1;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text != "" && txtNguoi_Thue.Text != "" && txtDiaChiO.Text != "" && txtCCCD.Text!= "" && cboSo_Phong.Text !="" )
            {
                Int64 sdt = Int64.Parse(txtSDT.Text);
                String ten = txtNguoi_Thue.Text;
                String diach = txtDiaChiO.Text;
                String cccd = txtCCCD.Text;
               Int64 so_phong = Int64.Parse(cboSo_Phong.Text);

                query = "Insert into NGUOI_THUE(so_dien_thoai, ho_ten, dia_chi, cccd,so_phong) values("+ sdt + ",'"+ ten+"','" + diach + "','"+cccd+"','"+so_phong+"') update PHONG set da_dat = 'Yes' Where so_phong = "+so_phong+"";
                fn.setData(query, "Thêm người thành công!");

                clearAll();



            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ!","Thông tin",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNguoi_Thue_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
