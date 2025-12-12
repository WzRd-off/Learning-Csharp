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
        private Person currentMember;

        public Form1()
        {
            InitializeComponent();

            cbTeamList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMemberList.DropDownStyle = ComboBoxStyle.DropDownList;

            cbTeamList.SelectedIndexChanged += CbTeamList_SelectedIndexChanged;
            cbMemberList.SelectedIndexChanged += CbMemberList_SelectedIndexChanged;
        }

        private void CbTeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTeamList.SelectedIndex == -1) return;

            currentTeam = teams[cbTeamList.SelectedIndex];

            txtTeamName.Text = currentTeam.TeamName;
            numTeamID.Value = currentTeam.RegistrationNumber;

            Print($"[INFO] Вибрана команда: {currentTeam.TeamName}");

            RefreshMemberList();
        }

        private void CbMemberList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMemberList.SelectedIndex == -1 || currentTeam == null) return;

            currentMember = currentTeam.Members[cbMemberList.SelectedIndex];

            txtMemFirstName.Text = currentMember.FirstName;
            txtMemLastName.Text = currentMember.LastName;
            dtpMemDob.Value = currentMember.DateOfBirth;

            if (currentMember is Student student)
            {
                // Примечание: Убедитесь, что в классе Student есть свойство FormEducation, иначе эта строка вызовет ошибку
                // txtEduForm.Text = student.FormEducation; 
                try { numStudentGroup.Value = student.StudentGroup; } catch { }
            }
            else
            {
                txtEduForm.Text = "";
                numStudentGroup.Value = 0;
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtTeamName.Text;
                int id = (int)numTeamID.Value;

                ResearchTeam newTeam = new ResearchTeam(name, id, new List<Person>(), new List<Paper>());
                teams.Add(newTeam);

                currentTeam = newTeam;

                Print($"[OK] Створено нову команду: {newTeam.TeamName}");

                RefreshTeamList();
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
                Print("[!] Спочатку виберіть або створіть команду!");
                return;
            }

            try
            {
                currentTeam.TeamName = txtTeamName.Text;
                currentTeam.RegistrationNumber = (int)numTeamID.Value;

                Print($"[OK] Дані команди оновлено: {currentTeam}");
                RefreshTeamList();
            }
            catch (Exception ex)
            {
                Print($"[ПОМИЛКА] {ex.Message}");
            }
        }

        private void BtnAddMember_Click(object sender, EventArgs e)
        {
            if (currentTeam == null)
            {
                Print("[!] Оберіть команду!");
                return;
            }

            string first = txtMemFirstName.Text;
            string last = txtMemLastName.Text;
            DateTime dob = dtpMemDob.Value;
            string eduForm = txtEduForm.Text;
            int group = (int)numStudentGroup.Value;

            if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(last))
            {
                Print("[!] Введіть ім'я та прізвище!");
                return;
            }

            try
            {
                Student newStudent = new Student(first, last, dob, eduForm, group, new List<Test>(), new List<Exam>());

                currentTeam.AddMember(newStudent);
                Print($"[+] Додано студента: {newStudent.FirstName} {newStudent.LastName}, Група: {group}");

                RefreshMemberList();
            }
            catch (Exception ex)
            {
                Print($"[ПОМИЛКА створення студента]: {ex.Message}");

            }
        }

        private void BtnUpdateMember_Click(object sender, EventArgs e)
        {
            if (currentMember == null)
            {
                Print("[!] Оберіть учасника зі списку для редагування!");
                return;
            }

            try
            {
                currentMember.FirstName = txtMemFirstName.Text;
                currentMember.LastName = txtMemLastName.Text;
                currentMember.DateOfBirth = dtpMemDob.Value;

                if (currentMember is Student s)
                {
                    s.StudentGroup = (int)numStudentGroup.Value;
                    // Примечание: Убедитесь, что в классе Student есть свойство FormEducation, иначе эта строка вызовет ошибку
                    // s.FormEducation = txtEduForm.Text;
                }

                Print($"[OK] Дані учасника оновлено.");
                RefreshMemberList();
            }
            catch (Exception ex)
            {
                Print($"[ПОМИЛКА] {ex.Message}");
            }
        }

        private void RefreshTeamList()
        {
            int savedIndex = cbTeamList.SelectedIndex;

            cbTeamList.Items.Clear();
            foreach (var t in teams)
            {
                cbTeamList.Items.Add($"{t.TeamName} (ID: {t.RegistrationNumber})");
            }

            if (savedIndex >= 0 && savedIndex < cbTeamList.Items.Count)
                cbTeamList.SelectedIndex = savedIndex;
            else if (cbTeamList.Items.Count > 0)
                cbTeamList.SelectedIndex = cbTeamList.Items.Count - 1;
        }

        private void RefreshMemberList()
        {
            cbMemberList.Items.Clear();
            if (currentTeam == null) return;

            foreach (var m in currentTeam.Members)
            {
                string info = $"{m.FirstName} {m.LastName}";
                if (m is Student s) info += $" (Гр. {s.StudentGroup})";
                cbMemberList.Items.Add(info);
            }

            currentMember = null;
            txtMemFirstName.Clear();
            txtMemLastName.Clear();
        }

        private string GetStudentEducationForm(Student s)
        {
            return "";
        }

        private void BtnAddPaper_Click(object sender, EventArgs e)
        {
            if (currentTeam == null || currentTeam.Members.Count == 0)
            {
                Print("[!] Немає команди або учасників!");
                return;
            }

            Person author = currentMember ?? currentTeam.Members[currentTeam.Members.Count - 1];

            string title = txtPaperTitle.Text;
            DateTime pubDate = dtpPaperDate.Value;

            Paper newPaper = new Paper(title, author, pubDate);
            currentTeam.AddPaper(newPaper);
            Print($"[+] Додано статтю: \"{title}\" для {author.LastName}");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (currentTeam == null) return;
            if (currentTeam.Save("team_db.json")) Print("Збережено у team_db.json");
            else Print("Помилка збереження.");
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                ResearchTeam loadedTeam = ResearchTeam.Load("team_db.json");
                teams.Add(loadedTeam);
                Print("\nЗавантажено з JSON нову команду.");
                RefreshTeamList();
            }
            catch (Exception ex) { Print("Помилка: " + ex.Message); }
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
            teams.Add(copy);
            copy.TeamName = currentTeam.TeamName + "_COPY";

            Print($"Оригінал: {currentTeam.TeamName}");
            Print($"Копія:    {copy.TeamName}");
        }
        private void BtnIterNoPapers_Click(object sender, EventArgs e)
        {
            if (currentTeam == null) return;
            foreach (var p in currentTeam.GetMembersWithoutPublications()) Print(p.ToString());
        }
        private void BtnIterRecent_Click(object sender, EventArgs e)
        {
            if (currentTeam == null) return;
            foreach (var p in currentTeam.GetRecentPapers(2)) Print(p.ToString());
        }

        private void Print(string text)
        {
            txtOutput.AppendText(text + Environment.NewLine);
        }
    }
}