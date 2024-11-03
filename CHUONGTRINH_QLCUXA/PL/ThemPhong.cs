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
    public partial class ThemPhong : Form
    {
        function fn = new function();
        String query;   
        public ThemPhong()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemPhong_Load(object sender, EventArgs e)
        {
            this.Location = new Point(550, 123);
            labelRoomExit.Visible = false;
            labelRoom.Visible = false;
            query = "Select  * From PHONG";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {   
            query = "Select * From PHONG Where so_phong = " + txtPhong_1.Text + "";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                String status;
                if (checkBox1.Checked)
                {
                    status = "Yes";
                }
                else
                {
                    status = "No";
                }
                labelRoomExit.Visible = false;
                query = "Insert into PHONG (so_phong, trang_thai  ) values(" + txtPhong_1.Text + ",'" + status + "')";
                fn.setData(query, "Đã thêm phòng!");
                ThemPhong_Load(this, null);

            }
            else
            {
                labelRoomExit.Text = "Phòng đã có ";
                labelRoomExit.Visible = true;
            }
            
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "Select * From PHONG Where so_phong ="+ txtPhong_2.Text+"";
            DataSet ds = fn.getData(query);

            if(ds.Tables[0].Rows.Count == 0)
            {
                labelRoom.Text = "Phòng này không tồn tại!";
                labelRoom.Visible = true;
                checkBox2.Visible = false;


            }
            else
            {
                labelRoom.Text = "Phòng này tồn tại!";
                labelRoom.Visible = true;

                if (ds.Tables[0].Rows[0][1].ToString() == "Yes")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Visible= false;
                    checkBox2.Checked= true;   
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String status;
            if(checkBox2.Checked)
            {
                status = "Yes";
            }
            else{
                status = "No";
            }
            query = "Update PHONG Set trang_thai='"+status+"' Where so_phong = " + txtPhong_2.Text +"";
            fn.setData(query,"Đã cập nhật!");
            ThemPhong_Load(this, null);


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhong_2.Text))
            {
                MessageBox.Show("Vui lòng nhập số phòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //kiem tra truc tiep tai csdl xem co ton tai khong

            query = "Select * From PHONG Where so_phong = " + txtPhong_2.Text + "";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                // Hiển thị hộp thoại xác nhận trước khi xóa
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                { 
                query = "DELETE FROM PHONG WHERE so_phong = " + txtPhong_2.Text + "";
                fn.setData(query, "Xóa phòng thành công!");
                ThemPhong_Load(this,null);
                }
            }
            else
            {
                MessageBox.Show("Xóa phòng không thành công, thử lại!   ","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
