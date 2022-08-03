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
    public partial class MonAnControl : UserControl
    {
        BindingSource foodList = new BindingSource();
        BindingSource categorylist = new BindingSource();
        public MonAnControl()
        {
            InitializeComponent();
            dgvFood.DataSource = foodList;
            dgvCategory.DataSource = categorylist;
            LoadListFood();
            LoadCategory();
            AddFoodBinding();
            AddCategoryBinding();
            LoadCategoryIntoCombobox(cbbCategory);
        }
        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }
        void LoadCategory()
        {
            categorylist.DataSource = CategoryDAO.Instance.GetCategory();
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "name";
        }
        void AddFoodBinding()
        {
            txtName.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtID.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmPrice.DataBindings.Add(new Binding("Value", dgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void AddCategoryBinding()
        {
            txtName2.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtID2.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            
        }
        List<Food> seachbyname(string name)
        {
            List<Food> listfood = FoodDAO.Instance.SeachFoodByName(name);

            return listfood;
        }

        List<Category> seachCatebyname(string name)
        {
            List<Category> listcate = CategoryDAO.Instance.SeachCategoryByName(name);

            return listcate;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }

        private void MonAnControl_Load(object sender, EventArgs e)
        {

        }

        private void cbbCategory_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                    Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                    cbbCategory.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbbCategory.Items)
                    {
                        if (item.ID == cateogory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbbCategory.SelectedIndex = index;
                }

            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int categoryID = (cbbCategory.SelectedItem as Category).ID;
            float price = (float)nmPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int categoryID = (cbbCategory.SelectedItem as Category).ID;
            float price = (float)nmPrice.Value;
            int id = Convert.ToInt32(txtID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());

            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }
        private event EventHandler insertCate;
        public event EventHandler InsertCate
        {
            add { insertCate += value; }
            remove { insertCate -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }
        private event EventHandler deleteCate;
        public event EventHandler DeleteCate
        {
            add { deleteCate += value; }
            remove { deleteCate -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        private event EventHandler updateCate;
        public event EventHandler UpdateCate
        {
            add { updateCate += value; }
            remove { updateCate -= value; }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCate_Click(object sender, EventArgs e)
        {
            string name = txtName2.Text;
           
         

            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công");
                LoadCategory();
                if (insertCate != null)
                    insertCate(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục");
            }
        }

        private void btnEditCate_Click(object sender, EventArgs e)
        {
            string name = txtName2.Text;
           
            int id = Convert.ToInt32(txtID2.Text);

            if (CategoryDAO.Instance.UpdateCategory(id,name))
            {
                MessageBox.Show("Sửa danh mục thành công");
                LoadCategory();
                if (updateCate != null)
                    updateCate(this, new EventArgs());

            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID2.Text);

            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa danh mục thành công");
                LoadCategory();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa danh mục");
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            LoadListFood();
            LoadCategoryIntoCombobox(cbbCategory);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            foodList.DataSource= seachbyname(txtSeach.Text);
        }

        private void btnSearchCate_Click(object sender, EventArgs e)
        {
            categorylist.DataSource = seachCatebyname(txtSearchCate.Text);
        }
    }
}
