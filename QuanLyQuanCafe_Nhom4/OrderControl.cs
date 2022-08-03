using QuanLyQuanCafe_Nhom4.DAO;
using QuanLyQuanCafe_Nhom4.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyQuanCafe_Nhom4
{
    public partial class OrderControl : UserControl
    {
        public OrderControl()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
            LoadCbbTable(cbbTable);



        }
        #region Method
       void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbbCategory.DataSource = listCategory;
            cbbCategory.DisplayMember = "Name";
        }
        void LoadCbbTable(ComboBox cbb)
        {
            cbb.DataSource = TableDAO.Instance.LoadTableList();
            cbb.DisplayMember = "name";
            
        }
        void LoadListFoodByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbbFood.DataSource = listFood;
            cbbFood.DisplayMember = "name";
        }
        public void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {


                    Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                    btn.Text = item.Name + Environment.NewLine + item.Status;
                    btn.Click += btn_Click;
                    btn.Tag = item;
                    switch (item.Status)
                    {
                        case "Trống":
                            btn.BackColor = Color.Brown;
                            btn.ForeColor = Color.White;
                            btn.Font = new Font("Arial", 16);
                            btn.FlatStyle = FlatStyle.Flat;
                            break;
                        default:
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.BackColor = Color.White;
                            btn.Font = new Font("Arial", 16);
                            break;
                    }

                    flpTable.Controls.Add(btn);
                

            }
        }
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<QuanLyQuanCafe_Nhom4.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (QuanLyQuanCafe_Nhom4.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txtTotalPrice.Text = totalPrice.ToString("c", culture);
        }

        #endregion
        public void f_UpdateFood()
        {
            LoadCategory();
            LoadListFoodByCategoryID((cbbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        public void f_DeleteFood()
        {
            LoadCategory();
            LoadListFoodByCategoryID((cbbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }

        public void f_InsertFood()
        {
            LoadCategory();
            LoadListFoodByCategoryID((cbbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        #region Events
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag as Table;
            ShowBill(tableID);
        }
       
      
        private void OrderControl_Load(object sender, EventArgs e)
        {
            this.Width = this.Parent.Width;
            this.Height = this.Parent.Height;
            f_InsertFood();
            f_UpdateFood();
            f_DeleteFood();
            
         
        }
        private void cbbCategory_TextChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadListFoodByCategoryID(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cbbFood.SelectedItem as Food).ID;
            int count = (int)nmFoodCount.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }

            ShowBill(table.ID);
            LoadTable();


            }

          private void btnPay_Click(object sender, EventArgs e)
            {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = (int)mnDiscout.Value;
            double total = Convert.ToDouble(txtTotalPrice.Text.Split(',')[0]);
            double finalprice = (total - (total/100)*discount)*1000 ;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\n Tổng: {1}đ ", table.Name,finalprice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill,discount,(float)finalprice);
                    ShowBill(table.ID);
                    LoadTable();


                }
            }
        }

        private void bntSwtichTable_Click(object sender, EventArgs e)
        {
            int id1 = (lsvBill.Tag as Table).ID;
            int id2 = (cbbTable.SelectedItem as Table).ID;
            if(MessageBox.Show(string.Format("Bạn có muốn chuyển bàn {0} sang bàn {1} ", (lsvBill.Tag as Table).Name, (cbbTable.SelectedItem as Table).Name),"Thông Báo",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);
                LoadTable();
            }    
            
        }


        #endregion

        private void cbbTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }



}

