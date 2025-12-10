using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace pr8
{
    public partial class Form1 : Form
    {
        private ResearchTeam currentTeam;
        private List<ResearchTeam> teams = new List<ResearchTeam>();
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtTeamName.Text;
                int id = (int)numTeamID.Value;

                currentTeam = new ResearchTeam(name, id, new List<Person>(), new List<Paper>());
                teams.Add(currentTeam);
                cbTeamList.Items.Add(currentTeam.RegistrationNumber.ToString());

                Print($"[OK] Створено нову команду: {currentTeam.TeamName} (ID: {currentTeam.RegistrationNumber})");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Print($"[ПОМИЛКА] Некоректний ID: {ex.Message}");
            }
            catch (Exception ex)
            {
                Print($"[ПОМИЛКА] {ex.Message}");
            }
        }

        private void BtnUpdateTeam_Click(object sender, EventArgs e)
        {
            if (currentTeam == null)
            {
                Print("[!] Спочатку створіть команду!");
                return;
            }

            try
            {

                foreach(var item in teams) {
                    if (cbTeamList.SelectedItem == item.RegistrationNumber.ToString())
                    {
                        item.TeamName = txtTeamName.Text;
                        item.RegistrationNumber = (int)numTeamID.Value;
                        cbTeamList.SelectedItem = item.RegistrationNumber.ToString();
                    }
                }

                Print($"[OK] Дані оновлено. Тепер: {currentTeam}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Print($"[ПОМИЛКА] Не вдалося оновити ID: {ex.Message}");
            }
        }

        private void BtnAddMember_Click(object sender, EventArgs e)
        {
            if (currentTeam == null)
            {
                Print("[!] Спочатку створіть команду!");
                return;
            }

            string first = txtMemFirstName.Text;
            string last = txtMemLastName.Text;
            DateTime dob = dtpMemDob.Value;

            if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(last))
            {
                Print("[!] Введіть ім'я та прізвище!");
                return;
            }

            Person newMember = new Person(first, last, dob);
            currentTeam.AddMember(newMember);
            Print($"[+] Додано учасника: {newMember}");
        }


        private void BtnAddPaper_Click(object sender, EventArgs e)
        {
            if (currentTeam == null)
            {
                Print("[!] Немає команди!");
                return;
            }
            if (currentTeam.Members.Count == 0)
            {
                Print("[!] У команді немає учасників! Спочатку додайте когось.");
                return;
            }

            string title = txtPaperTitle.Text;
            DateTime pubDate = dtpPaperDate.Value;

            Person author = currentTeam.Members[currentTeam.Members.Count - 1];

            Paper newPaper = new Paper(title, author, pubDate);
            currentTeam.AddPaper(newPaper);
            Print($"[+] Додано статтю: \"{title}\" (Автор: {author.LastName})");
        }


        private void BtnTestException_Click(object sender, EventArgs e)
        {
            Print("--- Тест винятку ---");
            try
            {
                int val = (int)numTeamID.Value;
                Print($"Спроба встановити ID = {val}...");

                if (currentTeam != null)
                {
                    currentTeam.RegistrationNumber = val;
                    Print("Успішно (значення коректне).");
                }
                else
                {
                    Team temp = new Team("Temp", 1);
                    temp.RegistrationNumber = val;
                    Print("Team created temp successfully.");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Print($"ПЕРЕХОПЛЕНО: {ex.Message}");
            }
        }

        private void BtnDeepCopy_Click(object sender, EventArgs e)
        {
            if (currentTeam == null) return;

            Print("\n--- Тест DeepCopy ---");
            ResearchTeam copy = (ResearchTeam)currentTeam.DeepCopy();

            // Меняем имя копии, чтобы убедиться, что оригинал не меняется
            copy.TeamName = currentTeam.TeamName + "_COPY";

            Print($"Оригінал: {currentTeam.TeamName}");
            Print($"Копія:    {copy.TeamName}");
        }

        private void BtnIterNoPapers_Click(object sender, EventArgs e)
        {
            if (currentTeam == null) return;
            Print("\n--- Учасники без публікацій ---");
            foreach (var p in currentTeam.GetMembersWithoutPublications())
            {
                Print(p.ToString());
            }
        }

        private void BtnIterRecent_Click(object sender, EventArgs e)
        {
            if (currentTeam == null) return;
            Print("\n--- Статті за останні 2 роки ---");
            foreach (var p in currentTeam.GetRecentPapers(2))
            {
                Print(p.ToString());
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (currentTeam == null) return;
            if (currentTeam.Save("team_db.json"))
                Print("Збережено у team_db.json");
            else
                Print("Помилка збереження.");
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                currentTeam = ResearchTeam.Load("team_db.json");
                Print("\nЗавантажено з JSON:");
                Print(currentTeam.ToString());

                txtTeamName.Text = currentTeam.TeamName;
                numTeamID.Value = currentTeam.RegistrationNumber > numTeamID.Minimum ? currentTeam.RegistrationNumber : numTeamID.Minimum;
            }
            catch (Exception ex)
            {
                Print("Помилка завантаження: " + ex.Message);
            }
        }

        private void Print(string text)
        {
            txtOutput.AppendText(text + Environment.NewLine);
        }

    }
}