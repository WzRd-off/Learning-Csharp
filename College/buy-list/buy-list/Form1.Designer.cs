namespace buy_list
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnProductAdd = new System.Windows.Forms.Button();
            this.btnProductChange = new System.Windows.Forms.Button();
            this.btnProductRemove = new System.Windows.Forms.Button();
            this.btnSearchName = new System.Windows.Forms.Button();
            this.dgvBuyList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbProductPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbProductCategory = new System.Windows.Forms.ComboBox();
            this.cbProductBought = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpProductDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDropFilter = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.tbSearchName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpFilterDate2 = new System.Windows.Forms.DateTimePicker();
            this.dtpFilterDate1 = new System.Windows.Forms.DateTimePicker();
            this.cbFilterBought = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbFilterPrice2 = new System.Windows.Forms.TextBox();
            this.tbFilterPrice1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clbFilterCategory = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.import = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.export = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsUndo = new System.Windows.Forms.ToolStripButton();
            this.tsRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProductAdd
            // 
            this.btnProductAdd.Location = new System.Drawing.Point(93, 98);
            this.btnProductAdd.Name = "btnProductAdd";
            this.btnProductAdd.Size = new System.Drawing.Size(75, 23);
            this.btnProductAdd.TabIndex = 3;
            this.btnProductAdd.Text = "Додати";
            this.btnProductAdd.UseVisualStyleBackColor = true;
            this.btnProductAdd.Click += new System.EventHandler(this.btnProductAdd_Click);
            // 
            // btnProductChange
            // 
            this.btnProductChange.Location = new System.Drawing.Point(174, 99);
            this.btnProductChange.Name = "btnProductChange";
            this.btnProductChange.Size = new System.Drawing.Size(75, 23);
            this.btnProductChange.TabIndex = 4;
            this.btnProductChange.Text = "Редагувати";
            this.btnProductChange.UseVisualStyleBackColor = true;
            this.btnProductChange.Click += new System.EventHandler(this.btnProductChange_Click);
            // 
            // btnProductRemove
            // 
            this.btnProductRemove.Location = new System.Drawing.Point(255, 98);
            this.btnProductRemove.Name = "btnProductRemove";
            this.btnProductRemove.Size = new System.Drawing.Size(75, 23);
            this.btnProductRemove.TabIndex = 5;
            this.btnProductRemove.Text = "Видалити";
            this.btnProductRemove.UseVisualStyleBackColor = true;
            this.btnProductRemove.Click += new System.EventHandler(this.btnProductRemove_Click);
            // 
            // btnSearchName
            // 
            this.btnSearchName.Location = new System.Drawing.Point(175, 360);
            this.btnSearchName.Name = "btnSearchName";
            this.btnSearchName.Size = new System.Drawing.Size(85, 23);
            this.btnSearchName.TabIndex = 6;
            this.btnSearchName.Text = "Шукати";
            this.btnSearchName.UseVisualStyleBackColor = true;
            this.btnSearchName.Click += new System.EventHandler(this.btnSearchName_Click);
            // 
            // dgvBuyList
            // 
            this.dgvBuyList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBuyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuyList.Location = new System.Drawing.Point(287, 193);
            this.dgvBuyList.Name = "dgvBuyList";
            this.dgvBuyList.Size = new System.Drawing.Size(517, 292);
            this.dgvBuyList.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.tbProductPrice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbProductCategory);
            this.groupBox1.Controls.Add(this.cbProductBought);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpProductDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbProductName);
            this.groupBox1.Controls.Add(this.btnProductAdd);
            this.groupBox1.Controls.Add(this.btnProductChange);
            this.groupBox1.Controls.Add(this.btnProductRemove);
            this.groupBox1.Location = new System.Drawing.Point(287, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 134);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Товар";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(51, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Ціна:";
            // 
            // tbProductPrice
            // 
            this.tbProductPrice.Location = new System.Drawing.Point(93, 74);
            this.tbProductPrice.Name = "tbProductPrice";
            this.tbProductPrice.Size = new System.Drawing.Size(237, 20);
            this.tbProductPrice.TabIndex = 20;
            this.tbProductPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbProductPrice_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Категорія:";
            // 
            // cbProductCategory
            // 
            this.cbProductCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbProductCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProductCategory.FormattingEnabled = true;
            this.cbProductCategory.Items.AddRange(new object[] {
            "-Їжа",
            "-Напої",
            "-Побутове",
            "-Електроніка",
            "-Одяг"});
            this.cbProductCategory.Location = new System.Drawing.Point(336, 50);
            this.cbProductCategory.Name = "cbProductCategory";
            this.cbProductCategory.Size = new System.Drawing.Size(135, 21);
            this.cbProductCategory.TabIndex = 17;
            // 
            // cbProductBought
            // 
            this.cbProductBought.AutoSize = true;
            this.cbProductBought.Location = new System.Drawing.Point(336, 77);
            this.cbProductBought.Name = "cbProductBought";
            this.cbProductBought.Size = new System.Drawing.Size(107, 17);
            this.cbProductBought.TabIndex = 16;
            this.cbProductBought.Text = "Товар куплено?";
            this.cbProductBought.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Дата:";
            // 
            // dtpProductDate
            // 
            this.dtpProductDate.Location = new System.Drawing.Point(93, 50);
            this.dtpProductDate.Name = "dtpProductDate";
            this.dtpProductDate.Size = new System.Drawing.Size(237, 20);
            this.dtpProductDate.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Назва товару:";
            // 
            // tbProductName
            // 
            this.tbProductName.Location = new System.Drawing.Point(93, 24);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(237, 20);
            this.tbProductName.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox2.Controls.Add(this.btnDropFilter);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnFilter);
            this.groupBox2.Controls.Add(this.tbSearchName);
            this.groupBox2.Controls.Add(this.btnSearchName);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.dtpFilterDate2);
            this.groupBox2.Controls.Add(this.dtpFilterDate1);
            this.groupBox2.Controls.Add(this.cbFilterBought);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbFilterPrice2);
            this.groupBox2.Controls.Add(this.tbFilterPrice1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.clbFilterCategory);
            this.groupBox2.Location = new System.Drawing.Point(12, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 432);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Фільтр";
            // 
            // btnDropFilter
            // 
            this.btnDropFilter.Location = new System.Drawing.Point(55, 403);
            this.btnDropFilter.Name = "btnDropFilter";
            this.btnDropFilter.Size = new System.Drawing.Size(205, 23);
            this.btnDropFilter.TabIndex = 26;
            this.btnDropFilter.Text = "Скинути фільтр";
            this.btnDropFilter.UseVisualStyleBackColor = true;
            this.btnDropFilter.Click += new System.EventHandler(this.btnDropFilter_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Пошук:";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(175, 312);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(85, 23);
            this.btnFilter.TabIndex = 25;
            this.btnFilter.Text = "Фільтрувати";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // tbSearchName
            // 
            this.tbSearchName.Location = new System.Drawing.Point(55, 362);
            this.tbSearchName.Name = "tbSearchName";
            this.tbSearchName.Size = new System.Drawing.Size(114, 20);
            this.tbSearchName.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 195);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Друга дата:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Перша дата:";
            // 
            // dtpFilterDate2
            // 
            this.dtpFilterDate2.Location = new System.Drawing.Point(6, 211);
            this.dtpFilterDate2.Name = "dtpFilterDate2";
            this.dtpFilterDate2.Size = new System.Drawing.Size(186, 20);
            this.dtpFilterDate2.TabIndex = 22;
            // 
            // dtpFilterDate1
            // 
            this.dtpFilterDate1.Location = new System.Drawing.Point(6, 172);
            this.dtpFilterDate1.Name = "dtpFilterDate1";
            this.dtpFilterDate1.Size = new System.Drawing.Size(186, 20);
            this.dtpFilterDate1.TabIndex = 20;
            // 
            // cbFilterBought
            // 
            this.cbFilterBought.AutoSize = true;
            this.cbFilterBought.Location = new System.Drawing.Point(9, 267);
            this.cbFilterBought.Name = "cbFilterBought";
            this.cbFilterBought.Size = new System.Drawing.Size(107, 17);
            this.cbFilterBought.TabIndex = 20;
            this.cbFilterBought.Text = "Товар куплено?";
            this.cbFilterBought.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(74, 317);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "-";
            // 
            // tbFilterPrice2
            // 
            this.tbFilterPrice2.Location = new System.Drawing.Point(89, 314);
            this.tbFilterPrice2.Name = "tbFilterPrice2";
            this.tbFilterPrice2.Size = new System.Drawing.Size(62, 20);
            this.tbFilterPrice2.TabIndex = 20;
            this.tbFilterPrice2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbProductPrice_KeyPress);
            // 
            // tbFilterPrice1
            // 
            this.tbFilterPrice1.Location = new System.Drawing.Point(6, 314);
            this.tbFilterPrice1.Name = "tbFilterPrice1";
            this.tbFilterPrice1.Size = new System.Drawing.Size(62, 20);
            this.tbFilterPrice1.TabIndex = 19;
            this.tbFilterPrice1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbProductPrice_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Ціна:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Статус:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Дата:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Категорії:";
            // 
            // clbFilterCategory
            // 
            this.clbFilterCategory.FormattingEnabled = true;
            this.clbFilterCategory.Items.AddRange(new object[] {
            "-Всі",
            "-Їжа",
            "-Напої",
            "-Побутове",
            "-Електроніка",
            "-Одяг"});
            this.clbFilterCategory.Location = new System.Drawing.Point(6, 40);
            this.clbFilterCategory.Name = "clbFilterCategory";
            this.clbFilterCategory.Size = new System.Drawing.Size(189, 94);
            this.clbFilterCategory.TabIndex = 14;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(816, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.import,
            this.toolStripSeparator1,
            this.export});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // import
            // 
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(197, 22);
            this.import.Text = "Імпорт JSON|TXT|CSV";
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(194, 6);
            // 
            // export
            // 
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(197, 22);
            this.export.Text = "Експорт JSON|TXT|CSV";
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsUndo,
            this.tsRedo,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(816, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsUndo
            // 
            this.tsUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsUndo.Image = ((System.Drawing.Image)(resources.GetObject("tsUndo.Image")));
            this.tsUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUndo.Name = "tsUndo";
            this.tsUndo.Size = new System.Drawing.Size(40, 22);
            this.tsUndo.Text = "Undo";
            this.tsUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // tsRedo
            // 
            this.tsRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsRedo.Image = ((System.Drawing.Image)(resources.GetObject("tsRedo.Image")));
            this.tsRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRedo.Name = "tsRedo";
            this.tsRedo.Size = new System.Drawing.Size(38, 22);
            this.tsRedo.Text = "Redo";
            this.tsRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton3.Text = "Statistic";
            this.toolStripButton3.Click += new System.EventHandler(this.btnOpenStatistic_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 492);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvBuyList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Buy list";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnProductAdd;
        private System.Windows.Forms.Button btnProductChange;
        private System.Windows.Forms.Button btnProductRemove;
        private System.Windows.Forms.Button btnSearchName;
        private System.Windows.Forms.DataGridView dgvBuyList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpProductDate;
        private System.Windows.Forms.CheckBox cbProductBought;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox clbFilterCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbProductCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSearchName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbFilterPrice2;
        private System.Windows.Forms.TextBox tbFilterPrice1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpFilterDate2;
        private System.Windows.Forms.DateTimePicker dtpFilterDate1;
        private System.Windows.Forms.CheckBox cbFilterBought;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem import;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem export;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbProductPrice;
        private System.Windows.Forms.Button btnDropFilter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsUndo;
        private System.Windows.Forms.ToolStripButton tsRedo;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}

