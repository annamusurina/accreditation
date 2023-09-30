
namespace Аккредитационные_показатели
{
    partial class TabDisciplineSemeater
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabDisciplineSemeater));
            this.btnAddDisc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDisc = new System.Windows.Forms.DataGridView();
            this.btnSearchDisc = new System.Windows.Forms.Button();
            this.txtSearchDisc = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.вернутьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.объемToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наборToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.gbDT = new System.Windows.Forms.GroupBox();
            this.btnDate = new System.Windows.Forms.Button();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLevels = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisc)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gbDT.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddDisc
            // 
            this.btnAddDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnAddDisc.Location = new System.Drawing.Point(452, 44);
            this.btnAddDisc.Name = "btnAddDisc";
            this.btnAddDisc.Size = new System.Drawing.Size(133, 102);
            this.btnAddDisc.TabIndex = 46;
            this.btnAddDisc.Text = "Добавить новую запись";
            this.btnAddDisc.UseVisualStyleBackColor = true;
            this.btnAddDisc.Click += new System.EventHandler(this.btnAddDisc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F);
            this.label3.Location = new System.Drawing.Point(30, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 114);
            this.label3.TabIndex = 45;
            this.label3.Text = "Количество часов \r\nпо каждой \r\nдисциплине";
            // 
            // dgvDisc
            // 
            this.dgvDisc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisc.Location = new System.Drawing.Point(22, 219);
            this.dgvDisc.Name = "dgvDisc";
            this.dgvDisc.RowHeadersWidth = 51;
            this.dgvDisc.RowTemplate.Height = 24;
            this.dgvDisc.Size = new System.Drawing.Size(1287, 508);
            this.dgvDisc.TabIndex = 44;
            this.dgvDisc.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDisc_CellMouseDoubleClick);
            // 
            // btnSearchDisc
            // 
            this.btnSearchDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnSearchDisc.Location = new System.Drawing.Point(495, 165);
            this.btnSearchDisc.Name = "btnSearchDisc";
            this.btnSearchDisc.Size = new System.Drawing.Size(90, 38);
            this.btnSearchDisc.TabIndex = 43;
            this.btnSearchDisc.Text = "Поиск";
            this.btnSearchDisc.UseVisualStyleBackColor = true;
            this.btnSearchDisc.Click += new System.EventHandler(this.btnSearchTeacher_Click);
            // 
            // txtSearchDisc
            // 
            this.txtSearchDisc.Location = new System.Drawing.Point(27, 174);
            this.txtSearchDisc.Name = "txtSearchDisc";
            this.txtSearchDisc.Size = new System.Drawing.Size(440, 22);
            this.txtSearchDisc.TabIndex = 42;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вернутьсяToolStripMenuItem,
            this.объемToolStripMenuItem,
            this.наборToolStripMenuItem,
            this.справкаToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1331, 28);
            this.menuStrip1.TabIndex = 41;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // вернутьсяToolStripMenuItem
            // 
            this.вернутьсяToolStripMenuItem.Name = "вернутьсяToolStripMenuItem";
            this.вернутьсяToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this.вернутьсяToolStripMenuItem.Text = "Вернуться в меню";
            this.вернутьсяToolStripMenuItem.Click += new System.EventHandler(this.вернутьсяToolStripMenuItem_Click);
            // 
            // объемToolStripMenuItem
            // 
            this.объемToolStripMenuItem.Name = "объемToolStripMenuItem";
            this.объемToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.объемToolStripMenuItem.Text = "Объем учебной нагрузки";
            this.объемToolStripMenuItem.Click += new System.EventHandler(this.объемToolStripMenuItem_Click);
            // 
            // наборToolStripMenuItem
            // 
            this.наборToolStripMenuItem.Name = "наборToolStripMenuItem";
            this.наборToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.наборToolStripMenuItem.Text = "Набор студентов";
            this.наборToolStripMenuItem.Click += new System.EventHandler(this.наборToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem1
            // 
            this.справкаToolStripMenuItem1.Name = "справкаToolStripMenuItem1";
            this.справкаToolStripMenuItem1.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem1.Text = "Справка";
            this.справкаToolStripMenuItem1.Click += new System.EventHandler(this.справкаToolStripMenuItem1_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(277, 233);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(142, 134);
            this.webBrowser1.TabIndex = 47;
            this.webBrowser1.Visible = false;
            // 
            // gbDT
            // 
            this.gbDT.Controls.Add(this.btnDate);
            this.gbDT.Controls.Add(this.cbDirection);
            this.gbDT.Controls.Add(this.label1);
            this.gbDT.Controls.Add(this.label4);
            this.gbDT.Controls.Add(this.cbLevels);
            this.gbDT.Location = new System.Drawing.Point(604, 36);
            this.gbDT.Name = "gbDT";
            this.gbDT.Size = new System.Drawing.Size(705, 167);
            this.gbDT.TabIndex = 48;
            this.gbDT.TabStop = false;
            this.gbDT.Text = "Выберите:";
            // 
            // btnDate
            // 
            this.btnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnDate.Location = new System.Drawing.Point(281, 94);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(412, 52);
            this.btnDate.TabIndex = 43;
            this.btnDate.Text = "Справочник направлений подготовки";
            this.btnDate.UseVisualStyleBackColor = true;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // cbDirection
            // 
            this.cbDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.Location = new System.Drawing.Point(370, 48);
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.Size = new System.Drawing.Size(323, 30);
            this.cbDirection.TabIndex = 46;
            this.cbDirection.SelectedIndexChanged += new System.EventHandler(this.cbDirection_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(63, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 24);
            this.label1.TabIndex = 43;
            this.label1.Text = "Уровень образования";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(420, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 24);
            this.label4.TabIndex = 44;
            this.label4.Text = "Направление подготовки";
            // 
            // cbLevels
            // 
            this.cbLevels.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cbLevels.FormattingEnabled = true;
            this.cbLevels.Location = new System.Drawing.Point(17, 48);
            this.cbLevels.Name = "cbLevels";
            this.cbLevels.Size = new System.Drawing.Size(323, 30);
            this.cbLevels.TabIndex = 45;
            this.cbLevels.SelectedIndexChanged += new System.EventHandler(this.cbLevels_SelectedIndexChanged);
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnImport.Location = new System.Drawing.Point(292, 44);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(154, 102);
            this.btnImport.TabIndex = 47;
            this.btnImport.Text = "Ввести данные из учебного плана";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // TabDisciplineSemeater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 739);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.gbDT);
            this.Controls.Add(this.btnAddDisc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDisc);
            this.Controls.Add(this.btnSearchDisc);
            this.Controls.Add(this.txtSearchDisc);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.webBrowser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TabDisciplineSemeater";
            this.Text = "Часы по дисциплинам";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisc)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbDT.ResumeLayout(false);
            this.gbDT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddDisc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDisc;
        private System.Windows.Forms.Button btnSearchDisc;
        private System.Windows.Forms.TextBox txtSearchDisc;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem вернутьсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem объемToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem наборToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.GroupBox gbDT;
        private System.Windows.Forms.Button btnDate;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLevels;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}