namespace pr8
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Поля ввода для Команды
        private System.Windows.Forms.GroupBox grpTeam;
        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.Label lblTeamID;
        private System.Windows.Forms.NumericUpDown numTeamID;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdateTeam; // Новая кнопка для редактирования

        // Поля ввода для Участника
        private System.Windows.Forms.GroupBox grpMember;
        private System.Windows.Forms.Label lblMemName;
        private System.Windows.Forms.TextBox txtMemFirstName;
        private System.Windows.Forms.Label lblMemLast;
        private System.Windows.Forms.TextBox txtMemLastName;
        private System.Windows.Forms.Label lblMemDob;
        private System.Windows.Forms.DateTimePicker dtpMemDob;
        private System.Windows.Forms.Button btnAddMember;

        // Поля ввода для Статьи
        private System.Windows.Forms.GroupBox grpPaper;
        private System.Windows.Forms.Label lblPaperTitle;
        private System.Windows.Forms.TextBox txtPaperTitle;
        private System.Windows.Forms.Label lblPaperDate;
        private System.Windows.Forms.DateTimePicker dtpPaperDate;
        private System.Windows.Forms.Button btnAddPaper;

        // Группа тестирования и файлов
        private System.Windows.Forms.GroupBox grpTests;
        private System.Windows.Forms.Button btnTestException;
        private System.Windows.Forms.Button btnDeepCopy;
        private System.Windows.Forms.Button btnIterNoPapers;
        private System.Windows.Forms.Button btnIterRecent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;

        // Вывод
        private System.Windows.Forms.TextBox txtOutput;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpTeam = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTeamList = new System.Windows.Forms.ComboBox();
            this.lblTeamName = new System.Windows.Forms.Label();
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.lblTeamID = new System.Windows.Forms.Label();
            this.numTeamID = new System.Windows.Forms.NumericUpDown();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdateTeam = new System.Windows.Forms.Button();
            this.grpMember = new System.Windows.Forms.GroupBox();
            this.btnUpdateMember = new System.Windows.Forms.Button();
            this.numStudentGroup = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEduForm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMemberList = new System.Windows.Forms.ComboBox();
            this.lblMemName = new System.Windows.Forms.Label();
            this.txtMemFirstName = new System.Windows.Forms.TextBox();
            this.lblMemLast = new System.Windows.Forms.Label();
            this.txtMemLastName = new System.Windows.Forms.TextBox();
            this.lblMemDob = new System.Windows.Forms.Label();
            this.dtpMemDob = new System.Windows.Forms.DateTimePicker();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.grpPaper = new System.Windows.Forms.GroupBox();
            this.lblPaperTitle = new System.Windows.Forms.Label();
            this.txtPaperTitle = new System.Windows.Forms.TextBox();
            this.lblPaperDate = new System.Windows.Forms.Label();
            this.dtpPaperDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddPaper = new System.Windows.Forms.Button();
            this.grpTests = new System.Windows.Forms.GroupBox();
            this.btnDeepCopy = new System.Windows.Forms.Button();
            this.btnTestException = new System.Windows.Forms.Button();
            this.btnIterNoPapers = new System.Windows.Forms.Button();
            this.btnIterRecent = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpTeam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTeamID)).BeginInit();
            this.grpMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStudentGroup)).BeginInit();
            this.grpPaper.SuspendLayout();
            this.grpTests.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTeam
            // 
            this.grpTeam.Controls.Add(this.label1);
            this.grpTeam.Controls.Add(this.cbTeamList);
            this.grpTeam.Controls.Add(this.lblTeamName);
            this.grpTeam.Controls.Add(this.txtTeamName);
            this.grpTeam.Controls.Add(this.lblTeamID);
            this.grpTeam.Controls.Add(this.numTeamID);
            this.grpTeam.Controls.Add(this.btnCreate);
            this.grpTeam.Controls.Add(this.btnUpdateTeam);
            this.grpTeam.Location = new System.Drawing.Point(12, 12);
            this.grpTeam.Name = "grpTeam";
            this.grpTeam.Size = new System.Drawing.Size(220, 245);
            this.grpTeam.TabIndex = 0;
            this.grpTeam.TabStop = false;
            this.grpTeam.Text = "Дані Команди";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Поточна команда: ";
            // 
            // cbTeamList
            // 
            this.cbTeamList.FormattingEnabled = true;
            this.cbTeamList.Location = new System.Drawing.Point(6, 157);
            this.cbTeamList.Name = "cbTeamList";
            this.cbTeamList.Size = new System.Drawing.Size(200, 24);
            this.cbTeamList.TabIndex = 7;
            // 
            // lblTeamName
            // 
            this.lblTeamName.AutoSize = true;
            this.lblTeamName.Location = new System.Drawing.Point(10, 25);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(52, 16);
            this.lblTeamName.TabIndex = 0;
            this.lblTeamName.Text = "Назва:";
            // 
            // txtTeamName
            // 
            this.txtTeamName.Location = new System.Drawing.Point(10, 45);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(200, 22);
            this.txtTeamName.TabIndex = 1;
            this.txtTeamName.Text = "Research Lab";
            // 
            // lblTeamID
            // 
            this.lblTeamID.AutoSize = true;
            this.lblTeamID.Location = new System.Drawing.Point(10, 75);
            this.lblTeamID.Name = "lblTeamID";
            this.lblTeamID.Size = new System.Drawing.Size(104, 16);
            this.lblTeamID.TabIndex = 2;
            this.lblTeamID.Text = "Реєстр. номер:";
            // 
            // numTeamID
            // 
            this.numTeamID.Location = new System.Drawing.Point(10, 95);
            this.numTeamID.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTeamID.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numTeamID.Name = "numTeamID";
            this.numTeamID.Size = new System.Drawing.Size(200, 22);
            this.numTeamID.TabIndex = 3;
            this.numTeamID.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(10, 199);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(95, 40);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Створити нову";
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // btnUpdateTeam
            // 
            this.btnUpdateTeam.Location = new System.Drawing.Point(111, 199);
            this.btnUpdateTeam.Name = "btnUpdateTeam";
            this.btnUpdateTeam.Size = new System.Drawing.Size(95, 40);
            this.btnUpdateTeam.TabIndex = 5;
            this.btnUpdateTeam.Text = "Оновити дані";
            this.btnUpdateTeam.Click += new System.EventHandler(this.BtnUpdateTeam_Click);
            // 
            // grpMember
            // 
            this.grpMember.Controls.Add(this.label4);
            this.grpMember.Controls.Add(this.btnUpdateMember);
            this.grpMember.Controls.Add(this.numStudentGroup);
            this.grpMember.Controls.Add(this.label3);
            this.grpMember.Controls.Add(this.txtEduForm);
            this.grpMember.Controls.Add(this.label2);
            this.grpMember.Controls.Add(this.cbMemberList);
            this.grpMember.Controls.Add(this.lblMemName);
            this.grpMember.Controls.Add(this.txtMemFirstName);
            this.grpMember.Controls.Add(this.lblMemLast);
            this.grpMember.Controls.Add(this.txtMemLastName);
            this.grpMember.Controls.Add(this.lblMemDob);
            this.grpMember.Controls.Add(this.dtpMemDob);
            this.grpMember.Controls.Add(this.btnAddMember);
            this.grpMember.Location = new System.Drawing.Point(240, 12);
            this.grpMember.Name = "grpMember";
            this.grpMember.Size = new System.Drawing.Size(565, 198);
            this.grpMember.TabIndex = 1;
            this.grpMember.TabStop = false;
            this.grpMember.Text = "Додати Учасника";
            // 
            // btnUpdateMember
            // 
            this.btnUpdateMember.Location = new System.Drawing.Point(270, 148);
            this.btnUpdateMember.Name = "btnUpdateMember";
            this.btnUpdateMember.Size = new System.Drawing.Size(95, 42);
            this.btnUpdateMember.TabIndex = 12;
            this.btnUpdateMember.Text = "Оновити учасника";
            this.btnUpdateMember.UseVisualStyleBackColor = true;
            // 
            // numStudentGroup
            // 
            this.numStudentGroup.Location = new System.Drawing.Point(269, 109);
            this.numStudentGroup.Maximum = new decimal(new int[] {
            599,
            0,
            0,
            0});
            this.numStudentGroup.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numStudentGroup.Name = "numStudentGroup";
            this.numStudentGroup.Size = new System.Drawing.Size(197, 22);
            this.numStudentGroup.TabIndex = 11;
            this.numStudentGroup.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Група №:";
            // 
            // txtEduForm
            // 
            this.txtEduForm.Location = new System.Drawing.Point(266, 52);
            this.txtEduForm.Name = "txtEduForm";
            this.txtEduForm.Size = new System.Drawing.Size(200, 22);
            this.txtEduForm.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Форма навчання:";
            // 
            // cbMemberList
            // 
            this.cbMemberList.FormattingEnabled = true;
            this.cbMemberList.Location = new System.Drawing.Point(10, 157);
            this.cbMemberList.Name = "cbMemberList";
            this.cbMemberList.Size = new System.Drawing.Size(200, 24);
            this.cbMemberList.TabIndex = 8;
            // 
            // lblMemName
            // 
            this.lblMemName.AutoSize = true;
            this.lblMemName.Location = new System.Drawing.Point(10, 25);
            this.lblMemName.Name = "lblMemName";
            this.lblMemName.Size = new System.Drawing.Size(32, 16);
            this.lblMemName.TabIndex = 0;
            this.lblMemName.Text = "Ім\'я:";
            // 
            // txtMemFirstName
            // 
            this.txtMemFirstName.Location = new System.Drawing.Point(63, 22);
            this.txtMemFirstName.Name = "txtMemFirstName";
            this.txtMemFirstName.Size = new System.Drawing.Size(147, 22);
            this.txtMemFirstName.TabIndex = 1;
            this.txtMemFirstName.Text = "Ivan";
            // 
            // lblMemLast
            // 
            this.lblMemLast.AutoSize = true;
            this.lblMemLast.Location = new System.Drawing.Point(10, 55);
            this.lblMemLast.Name = "lblMemLast";
            this.lblMemLast.Size = new System.Drawing.Size(47, 16);
            this.lblMemLast.TabIndex = 2;
            this.lblMemLast.Text = "Прізв:";
            // 
            // txtMemLastName
            // 
            this.txtMemLastName.Location = new System.Drawing.Point(63, 52);
            this.txtMemLastName.Name = "txtMemLastName";
            this.txtMemLastName.Size = new System.Drawing.Size(147, 22);
            this.txtMemLastName.TabIndex = 3;
            this.txtMemLastName.Text = "Ivanov";
            // 
            // lblMemDob
            // 
            this.lblMemDob.AutoSize = true;
            this.lblMemDob.Location = new System.Drawing.Point(10, 85);
            this.lblMemDob.Name = "lblMemDob";
            this.lblMemDob.Size = new System.Drawing.Size(72, 16);
            this.lblMemDob.TabIndex = 4;
            this.lblMemDob.Text = "Дата нар.:";
            // 
            // dtpMemDob
            // 
            this.dtpMemDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMemDob.Location = new System.Drawing.Point(10, 105);
            this.dtpMemDob.Name = "dtpMemDob";
            this.dtpMemDob.Size = new System.Drawing.Size(200, 22);
            this.dtpMemDob.TabIndex = 5;
            // 
            // btnAddMember
            // 
            this.btnAddMember.Location = new System.Drawing.Point(371, 148);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(95, 44);
            this.btnAddMember.TabIndex = 6;
            this.btnAddMember.Text = "Додати учасника";
            this.btnAddMember.Click += new System.EventHandler(this.BtnAddMember_Click);
            // 
            // grpPaper
            // 
            this.grpPaper.Controls.Add(this.lblPaperTitle);
            this.grpPaper.Controls.Add(this.txtPaperTitle);
            this.grpPaper.Controls.Add(this.lblPaperDate);
            this.grpPaper.Controls.Add(this.dtpPaperDate);
            this.grpPaper.Controls.Add(this.btnAddPaper);
            this.grpPaper.Location = new System.Drawing.Point(12, 257);
            this.grpPaper.Name = "grpPaper";
            this.grpPaper.Size = new System.Drawing.Size(220, 197);
            this.grpPaper.TabIndex = 2;
            this.grpPaper.TabStop = false;
            this.grpPaper.Text = "Додати Публікацію";
            // 
            // lblPaperTitle
            // 
            this.lblPaperTitle.AutoSize = true;
            this.lblPaperTitle.Location = new System.Drawing.Point(10, 25);
            this.lblPaperTitle.Name = "lblPaperTitle";
            this.lblPaperTitle.Size = new System.Drawing.Size(94, 16);
            this.lblPaperTitle.TabIndex = 0;
            this.lblPaperTitle.Text = "Назва статті:";
            // 
            // txtPaperTitle
            // 
            this.txtPaperTitle.Location = new System.Drawing.Point(10, 45);
            this.txtPaperTitle.Name = "txtPaperTitle";
            this.txtPaperTitle.Size = new System.Drawing.Size(200, 22);
            this.txtPaperTitle.TabIndex = 1;
            this.txtPaperTitle.Text = "AI Research";
            // 
            // lblPaperDate
            // 
            this.lblPaperDate.AutoSize = true;
            this.lblPaperDate.Location = new System.Drawing.Point(10, 75);
            this.lblPaperDate.Name = "lblPaperDate";
            this.lblPaperDate.Size = new System.Drawing.Size(109, 16);
            this.lblPaperDate.TabIndex = 2;
            this.lblPaperDate.Text = "Дата публікації:";
            // 
            // dtpPaperDate
            // 
            this.dtpPaperDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaperDate.Location = new System.Drawing.Point(10, 95);
            this.dtpPaperDate.Name = "dtpPaperDate";
            this.dtpPaperDate.Size = new System.Drawing.Size(200, 22);
            this.dtpPaperDate.TabIndex = 3;
            // 
            // btnAddPaper
            // 
            this.btnAddPaper.Location = new System.Drawing.Point(6, 146);
            this.btnAddPaper.Name = "btnAddPaper";
            this.btnAddPaper.Size = new System.Drawing.Size(200, 35);
            this.btnAddPaper.TabIndex = 4;
            this.btnAddPaper.Text = "Додати публікацію";
            this.btnAddPaper.Click += new System.EventHandler(this.BtnAddPaper_Click);
            // 
            // grpTests
            // 
            this.grpTests.Controls.Add(this.btnDeepCopy);
            this.grpTests.Controls.Add(this.btnTestException);
            this.grpTests.Controls.Add(this.btnIterNoPapers);
            this.grpTests.Controls.Add(this.btnIterRecent);
            this.grpTests.Controls.Add(this.btnSave);
            this.grpTests.Controls.Add(this.btnLoad);
            this.grpTests.Location = new System.Drawing.Point(12, 460);
            this.grpTests.Name = "grpTests";
            this.grpTests.Size = new System.Drawing.Size(220, 138);
            this.grpTests.TabIndex = 3;
            this.grpTests.TabStop = false;
            this.grpTests.Text = "Тестування та Файли";
            // 
            // btnDeepCopy
            // 
            this.btnDeepCopy.Location = new System.Drawing.Point(10, 20);
            this.btnDeepCopy.Name = "btnDeepCopy";
            this.btnDeepCopy.Size = new System.Drawing.Size(100, 30);
            this.btnDeepCopy.TabIndex = 0;
            this.btnDeepCopy.Text = "DeepCopy Test";
            this.btnDeepCopy.Click += new System.EventHandler(this.BtnDeepCopy_Click);
            // 
            // btnTestException
            // 
            this.btnTestException.Location = new System.Drawing.Point(115, 20);
            this.btnTestException.Name = "btnTestException";
            this.btnTestException.Size = new System.Drawing.Size(100, 30);
            this.btnTestException.TabIndex = 1;
            this.btnTestException.Text = "Exception Test";
            this.btnTestException.Click += new System.EventHandler(this.BtnTestException_Click);
            // 
            // btnIterNoPapers
            // 
            this.btnIterNoPapers.Location = new System.Drawing.Point(10, 60);
            this.btnIterNoPapers.Name = "btnIterNoPapers";
            this.btnIterNoPapers.Size = new System.Drawing.Size(100, 30);
            this.btnIterNoPapers.TabIndex = 2;
            this.btnIterNoPapers.Text = "Iter: No Papers";
            this.btnIterNoPapers.Click += new System.EventHandler(this.BtnIterNoPapers_Click);
            // 
            // btnIterRecent
            // 
            this.btnIterRecent.Location = new System.Drawing.Point(115, 60);
            this.btnIterRecent.Name = "btnIterRecent";
            this.btnIterRecent.Size = new System.Drawing.Size(100, 30);
            this.btnIterRecent.TabIndex = 3;
            this.btnIterRecent.Text = "Iter: Recent";
            this.btnIterRecent.Click += new System.EventHandler(this.BtnIterRecent_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 100);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save JSON";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(115, 100);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 30);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load JSON";
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtOutput.Location = new System.Drawing.Point(238, 216);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(567, 382);
            this.txtOutput.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Поточний студент:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 607);
            this.Controls.Add(this.grpTeam);
            this.Controls.Add(this.grpMember);
            this.Controls.Add(this.grpPaper);
            this.Controls.Add(this.grpTests);
            this.Controls.Add(this.txtOutput);
            this.Name = "Form1";
            this.Text = "Практична робота №8";
            this.grpTeam.ResumeLayout(false);
            this.grpTeam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTeamID)).EndInit();
            this.grpMember.ResumeLayout(false);
            this.grpMember.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStudentGroup)).EndInit();
            this.grpPaper.ResumeLayout(false);
            this.grpPaper.PerformLayout();
            this.grpTests.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox cbTeamList;
        private System.Windows.Forms.ComboBox cbMemberList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdateMember;
        private System.Windows.Forms.NumericUpDown numStudentGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEduForm;
        private System.Windows.Forms.Label label4;
    }
}