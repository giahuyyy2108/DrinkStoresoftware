using QuanLyQuanCafe_Nhom4.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe_Nhom4.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string haspass = "";
            foreach (byte item in hasData)
            {
                haspass += item;
            }
 
            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, haspass});

            return result.Rows.Count > 0;
        }
        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName , DisplayName, Type FROM dbo.Account");
        }
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        public int Check(string userName)
        {
            string check = string.Format("SELECT * FROM dbo.Account WHERE UserName = N'{0}'", userName);
            var test = DataProvider.Instance.ExecuteScalar(check);
            if (test == null)
                return 1;
            else
                return 0;
        }
        public bool InsertAccount(string name, string displayName, int type)
        {
            if (Check(name) == 1)
            {
                string query = string.Format("INSERT dbo.Account ( UserName, DisplayName, Type, PassWord )VALUES  ( N'{0}', N'{1}', {2} , N'{3}')", name, displayName, type, "1962026656160185351301320480154111117132155");
                int result = DataProvider.Instance.ExcuteNonQuery(query);

                return result > 0;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAccount(string name, string displayName, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}', Type = {2} WHERE UserName = N'{0}'", name, displayName, type);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Account where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
        public bool ResetPassword(string name)
        {
            string query = string.Format("update account set password = N'1962026656160185351301320480154111117132155' where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }
    }
}
