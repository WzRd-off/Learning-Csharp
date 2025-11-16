using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buy_list
{
    public partial class Form1 : Form
    {
        // VARIABLES
        DataTable dtBuyList = new DataTable();
        private List<Dictionary<string, string>> mainBuyList = new List<Dictionary<string, string>>();
        private Dictionary<string, decimal> statistic = new Dictionary<string, decimal>();
        private Stack<List<Dictionary<string, string>>> 
            undo = new Stack<List<Dictionary<string, string>>>(), 
            redo = new Stack<List<Dictionary<string, string>>>();

        public Form1()
        {
            InitializeComponent();
            
            dtBuyList.Columns.Add("Ім'я");
            dtBuyList.Columns.Add("Категорія");
            dtBuyList.Columns.Add("Ціна");
            dtBuyList.Columns.Add("Дата");
            dtBuyList.Columns.Add("Куплено");
            dgvBuyList.AllowUserToAddRows = false;
            dgvBuyList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBuyList.ReadOnly = true;
            

            dgvBuyList.DataSource = dtBuyList;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {

        }

        private void btnRedo_Click(object sender, EventArgs e)
        {

        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            if (tbProductName.Text.Length == 0) { 
                MessageBox.Show("Ім'я продукту не може бути пустим!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbProductCategory.SelectedItem == null) {
                MessageBox.Show("Категорія не може бути не вибрана!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbProductPrice.Text.Length == 0) {
                MessageBox.Show("Ціна продукту не може бути пустою!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Dictionary<string, string> newProduct = new Dictionary<string, string>();
            addToDictData(newProduct);

            dtBuyList.Rows.Add(newProduct.Values.ToArray());

            mainBuyList.Add(newProduct);

            clearProductInputFields();
        }

        private void btnProductChange_Click(object sender, EventArgs e)
        {
            if (mainBuyList == null) {
                MessageBox.Show("Список покупок пустий!\n Немає що редагувати", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var Index = dgvBuyList.CurrentRow.Index;
            Dictionary<string, string> changedProduct = new Dictionary<string, string>();
            addToDictData(changedProduct);

            mainBuyList[Index] = changedProduct;

            UpdateDgv(mainBuyList);
            clearProductInputFields();
        }

        private void btnProductRemove_Click(object sender, EventArgs e)
        {
            if (mainBuyList == null)
            {
                MessageBox.Show("Список покупок пустий!\n Немає що видаляти", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            var Index = dgvBuyList.CurrentRow.Index;

            mainBuyList.RemoveAt(Index);
            dtBuyList.Rows.RemoveAt(Index);
            
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            if (tbSearchName.Text.Length == 0)
            {
                MessageBox.Show("Пошукова строка не може бути пустою!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (clbFilterCategory.CheckedItems.Count == 0)
            {
                MessageBox.Show("Категорія не може бути не обрана!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenStatistic_Click(object sender, EventArgs e)
        {
            StatisticForm f = new StatisticForm();
            f.Show();
        }

        private void tbProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { 
            e.Handled = true;
            }
        }

        void clearProductInputFields() {
            tbProductName.Clear();
            tbProductPrice.Clear();
            cbProductCategory.SelectedItem = null;
            cbProductBought.Checked = false;
        }

        void addToDictData(Dictionary<string, string> dict) { 
        
            dict["Name"] = tbProductName.Text;
            dict["Category"] = cbProductCategory.SelectedItem.ToString();
            dict["Price"] = tbProductPrice.Text;
            dict["Data"] = dtpProductDate.Value.ToShortDateString();
            dict["Bought"] = cbProductBought.Checked.ToString();

        }

        void UpdateDgv(List<Dictionary<string, string>> listToShow)
        {
            dtBuyList.Rows.Clear();

            foreach (Dictionary<string, string> product in listToShow)
            {
                dtBuyList.Rows.Add(
                    product["Name"],
                    product["Category"],
                    product["Price"],
                    product["Data"],
                    product["Bought"]
                );
            }
        }
    }
}