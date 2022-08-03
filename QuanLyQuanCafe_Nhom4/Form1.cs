using QuanLyQuanCafe_Nhom4.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe_Nhom4
{
    public partial class Form1 : Form
    {
        private Form activeForm;
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(LoginAccount.Type); }
        }
        public Form1(Account acc )
        {
            
            InitializeComponent();
            this.loginAccount = acc;
            ChangeAccount(loginAccount.Type);
        }
        void ChangeAccount(int type)
        {
            btnAdmin.Visible = type == 1;
            lblDisplayname.Text =  LoginAccount.DisplayName ;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SidePanel.Height = btnOrder.Height;
            SidePanel.Top = btnOrder.Top;
            orderControl1.BringToFront();


        }
 
        #region Events

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnOrder.Height;
            SidePanel.Top = btnOrder.Top;
            this.panel5.Controls.Clear();

            // Gắn vào panel
            this.panel5.Controls.Add(orderControl1);
            orderControl1.BringToFront();
            orderControl1.f_DeleteFood();
            orderControl1.f_InsertFood();
            orderControl1.f_UpdateFood();
           
           
        }

        private void btnMonAn_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnMonAn.Height;
            SidePanel.Top = btnMonAn.Top;
            this.panel5.Controls.Clear();

            // Gắn vào panel
            this.panel5.Controls.Add(monAnControl1);
            monAnControl1.BringToFront();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnTaiKhoan.Height;
            SidePanel.Top = btnTaiKhoan.Top;
            FormTK f = new FormTK(loginAccount);
            f.UpdateAccount += F_UpdateAccount;
            this.panel5.Controls.Clear();

            
            f.TopLevel = false;

            // Gắn vào panel
            this.panel5.Controls.Add(f);

            // Hiển thị form
            f.Show();

        }

        private void F_UpdateAccount(object sender, AccountEvent e)
        {
            
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            
            this.Close();

            
        }

        private void orderControl1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnAdmin.Height;
            SidePanel.Top = btnAdmin.Top;
            this.panel5.Controls.Clear();

            // Gắn vào panel
            this.panel5.Controls.Add(adminControl1);
            adminControl1.BringToFront();
        }
        #endregion

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
            this.Hide();
        }
    }
}
