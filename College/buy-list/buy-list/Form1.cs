using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

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

            clbFilterCategory.SetItemChecked(0, true);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undo.Count > 0)
            {
                redo.Push(DeepCopy(mainBuyList));
                mainBuyList = undo.Pop();
                UpdateDgv(mainBuyList);
            }
            else
            {
                MessageBox.Show("Немає дій для скасування.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (redo.Count > 0)
            {
                undo.Push(DeepCopy(mainBuyList));
                mainBuyList = redo.Pop();
                UpdateDgv(mainBuyList);
            }
            else
            {
                MessageBox.Show("Немає дій для повторення.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            SaveStateForUndo();
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
            SaveStateForUndo();
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
            SaveStateForUndo();

            mainBuyList.RemoveAt(Index);
            dtBuyList.Rows.RemoveAt(Index);

        }

            //╔╦╦═══════╦╦══════╗
            //║║╚╦═╦═╦═╗║╚╦╗╔╦═╗║
            //║║║║╩╣╠╣╩╣║║║╚╝║║║║
            //║╚╩╩═╩╝╚═╝╚═╩══╬═║║
            //╚══════════════╩═╩╝
        private void btnSearchName_Click(object sender, EventArgs e)
        {
            if (tbSearchName.Text.Length == 0)
            {
                MessageBox.Show("Пошукова строка не може бути пустою!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            List<Dictionary<string, string>> searchResult = mainBuyList.Where(product => product["Name"].Contains(tbSearchName.Text)).ToList();

            UpdateDgv(searchResult);

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (clbFilterCategory.CheckedItems.Count == 0)
            {
                MessageBox.Show("Категорія не може бути не обрана!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Dictionary<string, string>> filterResult = new List<Dictionary<string, string>>();

            // Category filter
            if (!(clbFilterCategory.CheckedItems.Count == 1 && clbFilterCategory.CheckedItems.Contains("-Всі")))
            {
                
                foreach (var checkedItem in clbFilterCategory.CheckedItems)
                {
                    filterResult.AddRange(mainBuyList.Where(product => product["Category"] == checkedItem.ToString()).ToList());
                }
            }

            // Bought filter            
            if (cbFilterBought.Checked)
            {
                filterResult = filterResult.Where(product => product["Bought"] == "True").ToList();
            }

            DateTime start = dtpFilterDate1.Value.Date;
            DateTime end = dtpFilterDate2.Value.Date;

            filterResult = filterResult.Where(product => (DateTime.Parse(product["Date"]).Date >= start && DateTime.Parse(product["Date"]).Date <= end)).ToList();

            var startPrice = decimal.Parse(tbFilterPrice1.Text);
            var endPrice = decimal.Parse(tbFilterPrice2.Text);

            filterResult = filterResult.Where(product => (decimal.Parse(product["Price"]) >= startPrice && decimal.Parse(product["Price"]) <= endPrice)).ToList();

            UpdateDgv(filterResult);

        }

        private void btnOpenStatistic_Click(object sender, EventArgs e)
        {
            StatisticForm f = new StatisticForm();
            f.Show();
        }

        private void exportJSON_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "JSON files (*.json)|*.json";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfd.FileName;
                    string jsonString = JsonSerializer.Serialize(mainBuyList);
                    File.WriteAllText(filePath, jsonString);
                }
            }
        }

        private void saveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog()) {
                sfd.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfd.FileName;
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        if (sfd.FilterIndex == 2) {
                            sw.WriteLine("Name;Category;Price;Date;Bought");
                        }
                        foreach (Dictionary<string, string> product in mainBuyList)
                        {
                            sw.WriteLine(string.Join(";", product.Values));
                        }
                    }
                }
            }
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
            dict["Date"] = dtpProductDate.Value.ToShortDateString();
            dict["Bought"] = cbProductBought.Checked.ToString();

        }

        private void importJSON_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                
                ofd.Filter = "JSON files (*.json)|*.json";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    string jsonString = File.ReadAllText(filePath);
                    mainBuyList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(jsonString);
                    UpdateDgv(mainBuyList);
                }
            }
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
                    product["Date"],
                    product["Bought"]
                );
            }
        }

        List<Dictionary<string, string>> DeepCopy(List<Dictionary<string, string>> list) {

            List<Dictionary<string, string>> newList = new List<Dictionary<string, string>>();
            foreach (Dictionary<string, string> dict in list)
            {
                var newDict = new Dictionary<string, string>(dict);
                newList.Add(newDict);
            }
            return newList;

        }

        void SaveStateForUndo()
        {
            undo.Push(DeepCopy(mainBuyList));
            redo.Clear(); // history changed
        }

    }
}