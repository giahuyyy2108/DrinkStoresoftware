using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe_Nhom4.DAO;
using QuanLyQuanCafe_Nhom4.DTO;

namespace QuanLyQuanCafe_Nhom4
{
    public partial class FormTK : Form
    {
        private Account loginAccount;
        public Account LoginAccount
        {
            get => loginAccount;
            set
            {
                loginAccount = value;
                changeAccount(LoginAccount);
            }
        }
            void changeAccount(Account acc)
        {
            txtUserName.Text = loginAccount.UserName;
            txtDisplayName.Text = loginAccount.DisplayName;
        }
        public FormTK(Account acc)
        {
            InitializeComponent();
            loginAccount = acc;
            changeAccount(loginAccount);
        }
        private string haspass(string pass)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string haspass = "";
            foreach (byte item in hasData)
            {
                haspass += item;
            }
            return haspass;
        }
        void UpdateAccountInfo()
        {
            string displayName = txtDisplayName.Text;
            string password = txtPassword.Text;
            string newpass = txtNewPass.Text;
            string reenterPass = txtRetype.Text;
            string userName = txtUserName.Text;

            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, haspass(password), haspass(newpass)))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khấu");
                }
            }
        }
      
        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
    }
    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get { return acc; }
            set { acc = value; }
        }

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
