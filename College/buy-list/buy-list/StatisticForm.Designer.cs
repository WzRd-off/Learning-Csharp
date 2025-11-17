namespace buy_list
{
    partial class StatisticForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lTotalSum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbCatSum = new System.Windows.Forms.ListBox();
            this.lbTop = new System.Windows.Forms.ListBox();
            this.dgvCatStat = new System.Windows.Forms.DataGridView();
            this.lbMonthSum = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatStat)).BeginInit();
            this.SuspendLayout();
            // 
            // lTotalSum
            // 
            this.lTotalSum.AutoSize = true;
            this.lTotalSum.Location = new System.Drawing.Point(10, 9);
            this.lTotalSum.Name = "lTotalSum";
            this.lTotalSum.Size = new System.Drawing.Size(146, 13);
            this.lTotalSum.TabIndex = 0;
            this.lTotalSum.Text = "Загальна сума цін товарів -";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Сума куплених товарів -";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Сума покупок по категоріям:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Топ-3 найдорожчих товари:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Зведення по місяцях (сума витрат):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Кількість покупок по категоріях і статусу:";
            // 
            // lbCatSum
            // 
            this.lbCatSum.FormattingEnabled = true;
            this.lbCatSum.Location = new System.Drawing.Point(13, 47);
            this.lbCatSum.Name = "lbCatSum";
            this.lbCatSum.Size = new System.Drawing.Size(261, 134);
            this.lbCatSum.TabIndex = 8;
            // 
            // lbTop
            // 
            this.lbTop.FormattingEnabled = true;
            this.lbTop.Location = new System.Drawing.Point(13, 210);
            this.lbTop.Name = "lbTop";
            this.lbTop.Size = new System.Drawing.Size(261, 134);
            this.lbTop.TabIndex = 9;
            // 
            // dgvCatStat
            // 
            this.dgvCatStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCatStat.Location = new System.Drawing.Point(311, 47);
            this.dgvCatStat.Name = "dgvCatStat";
            this.dgvCatStat.Size = new System.Drawing.Size(261, 134);
            this.dgvCatStat.TabIndex = 10;
            // 
            // lbMonthSum
            // 
            this.lbMonthSum.FormattingEnabled = true;
            this.lbMonthSum.Location = new System.Drawing.Point(311, 210);
            this.lbMonthSum.Name = "lbMonthSum";
            this.lbMonthSum.Size = new System.Drawing.Size(261, 134);
            this.lbMonthSum.TabIndex = 11;
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 353);
            this.Controls.Add(this.lbMonthSum);
            this.Controls.Add(this.dgvCatStat);
            this.Controls.Add(this.lbTop);
            this.Controls.Add(this.lbCatSum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lTotalSum);
            this.Name = "StatisticForm";
            this.Text = "StatisticForm";
            this.Load += new System.EventHandler(this.StatisticForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatStat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTotalSum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbCatSum;
        private System.Windows.Forms.ListBox lbTop;
        private System.Windows.Forms.DataGridView dgvCatStat;
        private System.Windows.Forms.ListBox lbMonthSum;
    }
}