using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace buy_list
{
    public partial class StatisticForm : Form
    {
        private Form1 mainForm;

        public StatisticForm(Form1 f)
        {
            InitializeComponent();
            mainForm = f;
        }

        private void StatisticForm_Load(object sender, EventArgs e)
        {
            var list = mainForm.MainBuyList;

            if (list == null || list.Count == 0)
            {
                MessageBox.Show("Список пустий! Статистика недоступна.", "Увага");
                this.Close();
                return;
            }

            CalculateStatistics(list);
        }

        private void CalculateStatistics(List<Dictionary<string, string>> list)
        {
            //total sum
            decimal totalSum = list.Sum(x => GetPrice(x["Price"]));
            lTotalSum.Text = $"Загальна сума цін товарів: {totalSum} грн";

            //bought sum
            decimal boughtSum = list.Where(x => x["Bought"] == "True").Sum(x => GetPrice(x["Price"]));
            label2.Text = $"Сума куплених товарів: {boughtSum} грн";


            //category sum
            lbCatSum.Items.Clear();
            var categorySums = list.GroupBy(x => x["Category"])
                .Select(g => new { 
                    Category = g.Key,
                    Sum = g.Sum(item => GetPrice(item["Price"]))
                });

            foreach (var item in categorySums)
            {
                lbCatSum.Items.Add($"{item.Category}: {item.Sum} грн");
            }

            //top3
            lbTop.Items.Clear();
            var top3 = list.OrderByDescending(x => GetPrice(x["Price"])).Take(3);
            foreach (var item in top3)
            {
                lbTop.Items.Add($"{item["Name"]} - {item["Price"]} грн");
            }

            //month sum
            lbMonthSum.Items.Clear();
            var monthStats = list
                .GroupBy(x => GetDate(x["Date"]).ToString("MM.yyyy"))
                .Select(g => new {
                    Month = g.Key,
                    Sum = g.Sum(item => GetPrice(item["Price"]))
                })
                .OrderBy(x => x.Month);

            foreach (var item in monthStats)
            {
                lbMonthSum.Items.Add($"{item.Month}: {item.Sum} грн");
            }

            FillDataGridView(list);
        }

        private void FillDataGridView(List<Dictionary<string, string>> list)
        {
            dgvCatStat.Columns.Clear();
            dgvCatStat.Columns.Add("Category", "Категорія");
            dgvCatStat.Columns.Add("Total", "Всього шт.");
            dgvCatStat.Columns.Add("Bought", "Куплено");

            var catStats = list
                .GroupBy(x => x["Category"])
                .Select(g => new
                {
                    Category = g.Key,
                    Count = g.Count(),
                    BoughtCount = g.Count(item => item["Bought"] == "True")
                });

            foreach (var stat in catStats)
            {
                dgvCatStat.Rows.Add(stat.Category, stat.Count, stat.BoughtCount);
            }

            dgvCatStat.AllowUserToAddRows = false;
        }

        private decimal GetPrice(string priceStr)
        {
            if (decimal.TryParse(priceStr, out decimal result))
            {
                return result;
            }
            return 0;
        }

        private DateTime GetDate(string dateStr)
        {
            if (DateTime.TryParse(dateStr, out DateTime result))
            {
                return result;
            }
            return DateTime.MinValue;
        }
    }
}