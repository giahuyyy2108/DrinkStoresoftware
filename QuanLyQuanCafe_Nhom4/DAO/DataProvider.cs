using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe_Nhom4.DAO
{
    public class DataProvider
    {
       
        private string connectionSTR = "Data Source=GIAHUY2108;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        DataTable tbldata; //= new DataTable();

        private static DataProvider instance; 

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            using(SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();
                SqlCommand comand = new SqlCommand(query, connection);
                
                if(parameter != null)
                {
                    int i = 0;
                    string[] listPara = query.Split(' ');
                    foreach (var item in listPara)
                    {
                        if(item.Contains('@'))
                        {
                            comand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }    
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(comand);
                tbldata = new DataTable();
                adapter.Fill(tbldata);
                connection.Close();
            }
                return tbldata;           
        }


        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();
                SqlCommand comand = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    int i = 0;
                    string[] listPara = query.Split(' ');
                    foreach (var item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            comand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = comand.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
            {
                object data = 0;
                using (SqlConnection connection = new SqlConnection(connectionSTR))
                {

                    connection.Open();
                    SqlCommand comand = new SqlCommand(query, connection);
                    if (parameter != null)
                    {
                        int i = 0;
                        string[] listPara = query.Split(' ');
                        foreach (var item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                comand.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    data = comand.ExecuteScalar();
                    connection.Close();
                }
                return data;
            }
    }
}
