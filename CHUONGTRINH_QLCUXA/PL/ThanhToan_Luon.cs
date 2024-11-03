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
    public partial class ThanhToan_Luon : Form
    {
        function fn = new function();
        String query;
        public ThanhToan_Luon()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThanhToan_Luon_Load(object sender, EventArgs e)
        {
            this.Location = new Point(550, 123);
            monthDateTimePicker.Format = DateTimePickerFormat.Custom;
            monthDateTimePicker.CustomFormat = "MMMM yyyy";


        }
        public void setDataGrid(Int64 sdt)

        {
            query = "Select * from Luong Where so_dien_thoai =" + sdt + "";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text != "")
            {
                query = "Select ho_ten, chuc_danh from Them_nhanvien Where so_dien_thoai=" + txtSDT.Text + "";
                DataSet ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txttennhanvien.Text = ds.Tables[0].Rows[0][0].ToString();
                    cbochucvu.Text = ds.Tables[0].Rows[0][1].ToString();

                    setDataGrid(Int64.Parse(txtSDT.Text));


                }
                else
                {
                    MessageBox.Show("Nhân viên này không tồn tại!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }

            }
            else
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void clearAll()
        {
            txtSDT.Clear();
            txttennhanvien.Clear();
            txtThanhTien.Clear();
            monthDateTimePicker.ResetText();
            guna2DataGridView1.DataSource = -1;
            cbochucvu.SelectedIndex = -1;
        }

       
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {
            if (txtSDT.Text != "" && txtThanhTien.Text != "")
            {
                query = "Select  * from Luong Where so_dien_thoai=" + txtSDT.Text + "And thang ='" + monthDateTimePicker.Text + "'";
                DataSet ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    Int64 sdt = Int64.Parse(txtSDT.Text);
                    String thang = monthDateTimePicker.Text;
                    String thanhtien = txtThanhTien.Text;

                    query = "Insert into Luong values(" + sdt + ",'" + thang + "'," + thanhtien + ")";
                    fn.setData(query, "Lương tháng " + monthDateTimePicker.Text + " Phải trả " + thanhtien);
                    setDataGrid(sdt);
                }
                else
                {
                    MessageBox.Show("Đã thanh toán lương!", "Thong tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
