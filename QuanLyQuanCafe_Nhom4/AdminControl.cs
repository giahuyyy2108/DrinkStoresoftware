using QuanLyQuanCafe_Nhom4.DAO;
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

    public partial class AdminControl : UserControl
    {
        BindingSource accountlist = new BindingSource();
        public Account loginAccount2;

     
        public AdminControl()
        {
            InitializeComponent();
             dgvAccount.DataSource = accountlist;
            LoadAccount();
            AddAccountBinding();
            LoadListBillByDate(dtpFrom.Value, dtpTo.Value);
            LoadDateTimePickerBill();
        }
        #region Method
        void LoadAccount()
        {
            accountlist.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void AddAccountBinding()
        {
            txtUserName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtDisplayName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmType.DataBindings.Add(new Binding("Value", dgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        void AddAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadAccount();
        }
        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
           
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadAccount();
        }
        void ResetPass(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtpTo.Value = dtpFrom.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }
        void LoadListBillByMonth(DateTime checkOut)
        {
            dgvBill.DataSource = BillDAO.Instance.GetBillListByMonth(checkOut);
        }
        #endregion

        #region Events
        private void button2_Click(object sender, EventArgs e)
        {
            if (optDate.Checked == true)
            {
                dtpMonth.Enabled = false;
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
                LoadListBillByDate(dtpFrom.Value, dtpTo.Value);
            }
            else if(optMonth.Checked == true)
            {
                dtpMonth.Enabled = true;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                LoadListBillByMonth(dtpMonth.Value);
            }
         
              
        }
        private void optDate_CheckedChanged(object sender, EventArgs e)
        {
            if (optDate.Checked == true)
            {
                dtpMonth.Enabled = false;
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;            
            }
            else
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
             
        }
        private void optMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (optMonth.Checked == true)
            {
                dtpMonth.Enabled = true;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
            else
            {
                dtpMonth.Enabled = false;
            }
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string displayName = txtDisplayName.Text;
            int type = (int)nmType.Value;

            AddAccount(userName, displayName, type);
        }
        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string displayName = txtDisplayName.Text;
            int type = (int)nmType.Value;

            EditAccount(userName, displayName, type);

        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;

            DeleteAccount(userName);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;

            ResetPass(userName);
        }
        #endregion

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

       
    }
}
