using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         txtSo1.Text = txtSo2.Text = "0";
         radCong.Checked = true;             //đầu tiên chọn phép cộng
      }

      private void btnThoat_Click(object sender, EventArgs e)
      {
         DialogResult dr;
         dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                              "Thông báo", MessageBoxButtons.YesNo);
         if (dr == DialogResult.Yes)
            this.Close();
      }

      private void btnTinh_Click(object sender, EventArgs e)
      {
         //lấy giá trị của 2 ô số
         double so1, so2, kq = 0;
         so1 = double.Parse(txtSo1.Text);
         so2 = double.Parse(txtSo2.Text);
         int iso2 = int.Parse(txtSo2.Text);


         //Thực hiện phép tính dựa vào phép toán được chọn
         if (radCong.Checked) kq = so1 + so2;
         else if (radTru.Checked) kq = so1 - so2;
         else if (radNhan.Checked) kq = so1 * so2;
         else if (radChia.Checked)
         {
            if (iso2 == 0)
            {
               DialogResult dr;
               dr = MessageBox.Show("Phep tinh khong hop le! ");
               if (dr == DialogResult.Yes)
               {
                  this.Close();
               }

               txtSo2.Select();
            }
            else
            {
               kq = so1 / so2;
            }

         }
         //Hiển thị kết quả lên trên ô kết quả
         txtKq.Text = kq.ToString();
      }


      
      private bool checkValidinput(TextBox textBox)
      {
         try
         {
            double a = double.Parse(textBox.Text);
            return true;
         }
         catch (Exception ex)
         {
            return false;
         }
      }

      private void txtSo2_Click_1(object sender, EventArgs e)
      {
         txtSo2.SelectionStart = 0;
         txtSo2.SelectionLength = txtSo2.Text.Length;
      }

      private void txtSo1_Click_1(object sender, EventArgs e)
      {
         txtSo1.SelectionStart = 0;
         txtSo1.SelectionLength = txtSo1.Text.Length;
      }

      private void txtSo2_Leave_1(object sender, EventArgs e)
      {
         DialogResult dr;
         if (!checkValidinput(txtSo2))
         {
            dr = MessageBox.Show("So khong hop le! ");
            if (dr == DialogResult.Yes)
            {
               this.Close();
            }

            txtSo2.Select();
         }
      }

      private void txtSo1_Leave(object sender, EventArgs e)
      {
         DialogResult dr;
         if (!checkValidinput(txtSo1))
         {
            dr = MessageBox.Show("So khong hop le! ");
            if (dr == DialogResult.Yes)
            {
               this.Close();
            }

            txtSo1.Select();
         }
      }
   }
}
