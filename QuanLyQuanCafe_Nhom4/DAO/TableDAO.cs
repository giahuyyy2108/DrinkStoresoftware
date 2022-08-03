using QuanLyQuanCafe_Nhom4.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe_Nhom4.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 125;
        public static int TableHeight = 125;

        private TableDAO() { }
        public void SwitchTable(int id1 , int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwtichTable @idTable1 , @idTable2",new object[] { id1, id2 });

        }
        public List<Table> GetListTable()
        {
            List<Table> list = new List<Table>();

            string query = "select * from dbo.TableFood ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }

            return list;
        }
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }

        public bool InsertTable(string name)
        {
            string query = string.Format("INSERT dbo.TableFood ( name )VALUES  ( N'{0}')", name);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateTable(int id, string name)
        {
            string query = string.Format("UPDATE dbo.TableFood SET name = N'{0}' WHERE id = {1}", name, id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

       
    }
}
