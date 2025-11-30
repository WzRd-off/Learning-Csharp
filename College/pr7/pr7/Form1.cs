using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace pr7
{
    public partial class fToolRental : Form
    {
        private RentalService service;

        public fToolRental()
        {
            InitializeComponent();

            service = new RentalService();
            SeedData();

            SetupGrids();
            RefreshGrids();
        }

        private void SeedData()
        {
            service.ToolCollection.AddTool(new Tool(101, "Перфоратор Bosch", "Електро", 150m, "новий"));
            service.ToolCollection.AddTool(new Tool(102, "Лазерний рівень", "Вимір", 100m, "вживаний"));
            service.ToolCollection.AddTool(new Tool(103, "Бетонозмішувач", "Важке", 300m, "пошкоджений"));
            service.ToolCollection.AddTool(new Tool(104, "Шліфувальна машина", "Електро", 120m, "новий"));

            service.AddClient(new Client(1, "Шевченко Тарас", "0501112233"));
            service.AddClient(new Client(2, "Франко Іван", "0679998877"));
            service.AddClient(new Client(3, "Леся Українка", "0935554433"));
        }

        private void SetupGrids()
        {
            // Налаштування таблиці інструментів
            dgvTools.Columns.Add("Series", "ID");
            dgvTools.Columns.Add("Name", "Назва");
            dgvTools.Columns.Add("Category", "Категорія");
            dgvTools.Columns.Add("Price", "Ціна");
            dgvTools.Columns.Add("State", "Стан");
            dgvTools.Columns.Add("Status", "Статус");

            // Налаштування таблиці клієнтів
            dgvClients.Columns.Add("Id", "ID");
            dgvClients.Columns.Add("Name", "ПІБ");
            dgvClients.Columns.Add("Phone", "Телефон");
        }

        private void RefreshGrids()
        {
            // Оновлення інструментів
            dgvTools.Rows.Clear();
            foreach (var tool in service.ToolCollection.Tools)
            {
                int idx = dgvTools.Rows.Add(
                    tool.Series, tool.Name, tool.Category,
                    tool.Price, tool.State,
                    tool.Status ? "Доступний" : "Зайнятий"
                );

                // Фарбуємо рядки для наочності (опціонально, але корисно)
                if (!tool.Status)
                    dgvTools.Rows[idx].DefaultCellStyle.BackColor = Color.LightGray;
            }

            // Оновлення клієнтів
            dgvClients.Rows.Clear();
            foreach (var client in service.Clients)
            {
                dgvClients.Rows.Add(client.ClientId, client.FullName, client.PhoneNumber);
            }
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if (dgvTools.SelectedRows.Count > 0 && dgvClients.SelectedRows.Count > 0)
            {
                try
                {
                    int toolId = Convert.ToInt32(dgvTools.SelectedRows[0].Cells[0].Value);
                    int clientId = Convert.ToInt32(dgvClients.SelectedRows[0].Cells[0].Value);
                    int days = (int)numDays.Value;

                    service.RentToolToClient(toolId, clientId, days);

                    // Повідомлення про успіх
                    var lastAgreement = service.Agreements.LastOrDefault();
                    string msg = "Оренда успішно оформлена!";
                    if (lastAgreement != null)
                    {
                        msg += $"\n\n{lastAgreement.GetAgreementInfo()}";
                    }

                    MessageBox.Show(msg, "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrids();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Виберіть рядок інструменту та рядок клієнта!", "Увага");
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvTools.SelectedRows.Count > 0)
            {
                int toolId = Convert.ToInt32(dgvTools.SelectedRows[0].Cells[0].Value);
                var tool = service.ToolCollection.FindTool(toolId);

                if (tool.Status)
                {
                    MessageBox.Show("Цей інструмент не перебуває в оренді.", "Інфо");
                    return;
                }

                service.ReturnTool(toolId);
                MessageBox.Show($"Інструмент '{tool.Name}' успішно повернуто!", "Повернення");
                RefreshGrids();
            }
            else
            {
                MessageBox.Show("Виберіть інструмент для повернення.", "Увага");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                service.SaveAllData();
                MessageBox.Show("Всі дані успішно збережено у JSON файли.", "Збереження");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка збереження: " + ex.Message, "Помилка");
            }
        }

        // Кнопка статистики
        private void btnStats_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== СТАТИСТИКА КЛІЄНТІВ ===");
            sb.AppendLine("");

            foreach (var client in service.Clients)
            {
                sb.AppendLine($"Клієнт: {client.FullName} (ID: {client.ClientId})");
                sb.AppendLine($"Телефон: {client.PhoneNumber}");

                // Отримуємо угоди для цього клієнта через індексатор сервісу
                var clientAgreements = service[client.ClientId];

                sb.AppendLine($"Активних/Минулих оренд: {clientAgreements.Count}");
                if (clientAgreements.Count > 0)
                {
                    foreach (var agr in clientAgreements)
                    {
                        sb.AppendLine($"   - {agr.RentedTool.Name} ({agr.Days} дн.) = {agr.CalculateTotalPrice()} грн");
                    }
                }
                else
                {
                    sb.AppendLine("   (Немає історії оренд)");
                }
                sb.AppendLine("--------------------------------");
            }

            MessageBox.Show(sb.ToString(), "Детальна статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}