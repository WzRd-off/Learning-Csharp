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
using System.Windows.Forms;

namespace buy_list
{
    public partial class Form1 : Form
    {
        // VARIABLES

        DataTable dtBuyList = new DataTable();
        private string dataFilePath = "";
        private List<Dictionary<string, string>> mainBuyList = new List<Dictionary<string, string>>();
        private Dictionary<string, decimal> statistic = new Dictionary<string, decimal>();
        private Stack<List<Dictionary<string, string>>> 
            undo = new Stack<List<Dictionary<string, string>>>(), 
            redo = new Stack<List<Dictionary<string, string>>>();

        public List<Dictionary<string, string>> MainBuyList { get { return mainBuyList; } }

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

            Timer autoSaveTimer = new Timer();
            autoSaveTimer.Interval = 60_000;
            autoSaveTimer.Tick += autoSave_Tick;
            autoSaveTimer.Start();
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
            List<Dictionary<string, string>> searchResult = new List<Dictionary<string, string>>();
            if (string.IsNullOrWhiteSpace(tbSearchName.Text))
            {
                searchResult = mainBuyList;
            }
            searchResult = mainBuyList.Where(product => product["Name"].Contains(tbSearchName.Text)).ToList();

            UpdateDgv(searchResult);

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

            List<Dictionary<string, string>> filterResult = new List<Dictionary<string, string>>();

            // Category filter
            if (!(clbFilterCategory.CheckedItems.Count == 1 && clbFilterCategory.CheckedItems.Contains("-Всі")))
            {
                foreach (var checkedItem in clbFilterCategory.CheckedItems)
                {
                    filterResult.AddRange(mainBuyList.Where(product => product["Category"] == checkedItem.ToString()).ToList());
                }
            }
            else
            {
                filterResult.AddRange(mainBuyList);
            }
            // Bought filter            
            if (cbFilterBought.Checked)
            {
                filterResult = filterResult.Where(product => product["Bought"] == "True").ToList();
            }

            // Date filter
            DateTime start = dtpFilterDate1.Value.Date;
            DateTime end = dtpFilterDate2.Value.Date;

            filterResult = filterResult.Where(product => (DateTime.Parse(product["Date"]).Date >= start && DateTime.Parse(product["Date"]).Date <= end)).ToList();

            // Price filter
            if (!(tbFilterPrice1.Text.Length == 0 || tbFilterPrice2.Text.Length == 0))
            {

                var startPrice = decimal.Parse(tbFilterPrice1.Text);
                var endPrice = decimal.Parse(tbFilterPrice2.Text);

                filterResult = filterResult.Where(product => (decimal.Parse(product["Price"]) >= startPrice && decimal.Parse(product["Price"]) <= endPrice)).ToList();
            }
            UpdateDgv(filterResult);

        }

        private void btnOpenStatistic_Click(object sender, EventArgs e)
        {
            StatisticForm f = new StatisticForm(this);
            f.Show();
        }

        private void import_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON files (*.json)|*.json|Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    dataFilePath = filePath;
                    try
                    {
                        List<Dictionary<string, string>> tempList = new List<Dictionary<string, string>>();
                        if (ofd.FilterIndex == 1)
                        {
                            string jsonString = File.ReadAllText(filePath);
                            tempList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(jsonString);
                        }
                        else if (ofd.FilterIndex == 2)
                        {
                            string[] lines = File.ReadAllLines(filePath);
                            foreach (string line in lines)
                            {
                                if (!string.IsNullOrWhiteSpace(line))
                                {
                                    tempList.Add(ParseLineToProduct(line));
                                }
                            }
                        }
                        else if (ofd.FilterIndex == 3)
                        {
                            string[] lines = File.ReadAllLines(filePath);
                            for (int i = 1; i < lines.Length; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(lines[i]))
                                {
                                    tempList.Add(ParseLineToProduct(lines[i]));
                                }
                            }
                        }
                        mainBuyList = tempList;
                    }
                    catch (Exception ex) {
                        MessageBox.Show($"Помилка при читанні файлу:\n{ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    UpdateDgv(mainBuyList);
                }
            }
        }
        private void export_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "JSON files (*.json)|*.json|Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfd.FileName;

                    if (sfd.FilterIndex == 1)
                    {
                        string jsonString = JsonSerializer.Serialize(mainBuyList);
                        File.WriteAllText(filePath, jsonString);
                    }
                    else if (sfd.FilterIndex == 2)
                    {
                        exportToFile(filePath);

                    }
                    else if (sfd.FilterIndex == 3)
                    {
                        exportToFile(filePath, true);
    
                    }
                    
                }
            }
        }

        void exportToFile(string filePath, bool isCSV=false)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                if (isCSV) {
                    sw.WriteLine("Name,Category,Price,Date,Bought");
                }
                foreach (Dictionary<string, string> product in mainBuyList)
                {
                    sw.WriteLine(string.Join(",", product.Values));
                }
            }
        }
        private void tbProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) { 
                e.Handled = true;
            }
        }

        private void clearProductInputFields() {
            tbProductName.Clear();
            tbProductPrice.Clear();
            cbProductCategory.SelectedItem = null;
            cbProductBought.Checked = false;
        }

        private void addToDictData(Dictionary<string, string> dict) { 
        
            dict["Name"] = tbProductName.Text;
            dict["Category"] = cbProductCategory.SelectedItem.ToString();
            dict["Price"] = tbProductPrice.Text;
            dict["Date"] = dtpProductDate.Value.ToShortDateString();
            dict["Bought"] = cbProductBought.Checked.ToString();

        }

        private void UpdateDgv(List<Dictionary<string, string>> listToShow)
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

        private List<Dictionary<string, string>> DeepCopy(List<Dictionary<string, string>> list) {

            List<Dictionary<string, string>> newList = new List<Dictionary<string, string>>();
            foreach (Dictionary<string, string> dict in list)
            {
                var newDict = new Dictionary<string, string>(dict);
                newList.Add(newDict);
            }
            return newList;

        }

        private void autoSave_Tick(object sender, EventArgs e)
        {
            if (dataFilePath.Contains(".json"))
            {
                File.WriteAllText(dataFilePath, JsonSerializer.Serialize(mainBuyList));
            }
            else if (dataFilePath.Contains(".txt"))
            {
                exportToFile(dataFilePath);
            }
            else if (dataFilePath.Contains(".csv"))
            {
                exportToFile(dataFilePath, true);
            }
        }

        private void SaveStateForUndo()
        {
            undo.Push(DeepCopy(mainBuyList));
            redo.Clear(); // history changed
        }

        private void btnDropFilter_Click(object sender, EventArgs e)
        {
            cbFilterBought.Checked = false;
            dtpFilterDate1.Value = DateTime.Now;
            dtpFilterDate2.Value = DateTime.Now;
            tbFilterPrice1.Clear();
            tbFilterPrice2.Clear();
            clbFilterCategory.SetItemChecked(0, true);
            for (int i = 1; i < clbFilterCategory.Items.Count; i++)
            {
                clbFilterCategory.SetItemChecked(i, false);
            }

            UpdateDgv(mainBuyList);
        }

        private Dictionary<string, string> ParseLineToProduct(string line)
        {
            string[] parts = line.Split(',');

            Dictionary<string, string> product = new Dictionary<string, string>();

            if (parts.Length >= 5)
            {
                product["Name"] = parts[0].Trim();
                product["Category"] = parts[1].Trim();
                product["Price"] = parts[2].Trim();
                product["Date"] = parts[3].Trim(); 
                product["Bought"] = parts[4].Trim();
            }

            return product;
        }

    }
}