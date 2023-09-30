
namespace Аккредитационные_показатели
{
    partial class TabAcademicLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabAcademicLoad));
            this.btnAddLoad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvLoad = new System.Windows.Forms.DataGridView();
            this.btnSearchLoad = new System.Windows.Forms.Button();
            this.txtSearchLoad = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.вернутьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.преподавателиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дисциплиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.gbDT = new System.Windows.Forms.GroupBox();
            this.btnDate = new System.Windows.Forms.Button();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLevels = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoad)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gbDT.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddLoad
            // 
            this.btnAddLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnAddLoad.Location = new System.Drawing.Point(501, 51);
            this.btnAddLoad.Name = "btnAddLoad";
            this.btnAddLoad.Size = new System.Drawing.Size(152, 60);
            this.btnAddLoad.TabIndex = 40;
            this.btnAddLoad.Text = "Добавить новую запись";
            this.btnAddLoad.UseVisualStyleBackColor = true;
            this.btnAddLoad.Click += new System.EventHandler(this.btnAddLoad_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(26, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(344, 38);
            this.label3.TabIndex = 39;
            this.label3.Text = "Объем учебной нагрузки";
            // 
            // dgvLoad
            // 
            this.dgvLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoad.Location = new System.Drawing.Point(12, 183);
            this.dgvLoad.Name = "dgvLoad";
            this.dgvLoad.RowHeadersWidth = 51;
            this.dgvLoad.RowTemplate.Height = 24;
            this.dgvLoad.Size = new System.Drawing.Size(1385, 504);
            this.dgvLoad.TabIndex = 38;
            this.dgvLoad.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLoad_CellMouseDoubleClick);
            // 
            // btnSearchLoad
            // 
            this.btnSearchLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnSearchLoad.Location = new System.Drawing.Point(488, 129);
            this.btnSearchLoad.Name = "btnSearchLoad";
            this.btnSearchLoad.Size = new System.Drawing.Size(90, 38);
            this.btnSearchLoad.TabIndex = 37;
            this.btnSearchLoad.Text = "Поиск";
            this.btnSearchLoad.UseVisualStyleBackColor = true;
            this.btnSearchLoad.Click += new System.EventHandler(this.btnSearchLoad_Click);
            // 
            // txtSearchLoad
            // 
            this.txtSearchLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearchLoad.Location = new System.Drawing.Point(24, 138);
            this.txtSearchLoad.Name = "txtSearchLoad";
            this.txtSearchLoad.Size = new System.Drawing.Size(440, 24);
            this.txtSearchLoad.TabIndex = 36;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вернутьсяToolStripMenuItem,
            this.преподавателиToolStripMenuItem,
            this.дисциплиныToolStripMenuItem,
            this.сохранениеToolStripMenuItem,
            this.справкаToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1409, 30);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // вернутьсяToolStripMenuItem
            // 
            this.вернутьсяToolStripMenuItem.Name = "вернутьсяToolStripMenuItem";
            this.вернутьсяToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.вернутьсяToolStripMenuItem.Text = "Вернуться назад";
            this.вернутьсяToolStripMenuItem.Click += new System.EventHandler(this.вернутьсяToolStripMenuItem_Click);
            // 
            // преподавателиToolStripMenuItem
            // 
            this.преподавателиToolStripMenuItem.Name = "преподавателиToolStripMenuItem";
            this.преподавателиToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.преподавателиToolStripMenuItem.Text = "Преподаватели";
            this.преподавателиToolStripMenuItem.Click += new System.EventHandler(this.преподавателиToolStripMenuItem_Click);
            // 
            // дисциплиныToolStripMenuItem
            // 
            this.дисциплиныToolStripMenuItem.Name = "дисциплиныToolStripMenuItem";
            this.дисциплиныToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.дисциплиныToolStripMenuItem.Text = "Дисциплины семестр";
            this.дисциплиныToolStripMenuItem.Click += new System.EventHandler(this.дисциплиныToolStripMenuItem_Click);
            // 
            // сохранениеToolStripMenuItem
            // 
            this.сохранениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.документомToolStripMenuItem,
            this.таблицейToolStripMenuItem});
            this.сохранениеToolStripMenuItem.Name = "сохранениеToolStripMenuItem";
            this.сохранениеToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.сохранениеToolStripMenuItem.Text = "Сохранение";
            // 
            // документомToolStripMenuItem
            // 
            this.документомToolStripMenuItem.Name = "документомToolStripMenuItem";
            this.документомToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.документомToolStripMenuItem.Text = "Документом";
            this.документомToolStripMenuItem.Click += new System.EventHandler(this.документомToolStripMenuItem_Click);
            // 
            // таблицейToolStripMenuItem
            // 
            this.таблицейToolStripMenuItem.Name = "таблицейToolStripMenuItem";
            this.таблицейToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.таблицейToolStripMenuItem.Text = "Таблицей";
            this.таблицейToolStripMenuItem.Click += new System.EventHandler(this.таблицейToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem1
            // 
            this.справкаToolStripMenuItem1.Name = "справкаToolStripMenuItem1";
            this.справкаToolStripMenuItem1.Size = new System.Drawing.Size(81, 26);
            this.справкаToolStripMenuItem1.Text = "Справка";
            this.справкаToolStripMenuItem1.Click += new System.EventHandler(this.справкаToolStripMenuItem1_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(209, 221);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(161, 125);
            this.webBrowser1.TabIndex = 41;
            this.webBrowser1.Visible = false;
            // 
            // gbDT
            // 
            this.gbDT.Controls.Add(this.btnDate);
            this.gbDT.Controls.Add(this.cbDirection);
            this.gbDT.Controls.Add(this.label1);
            this.gbDT.Controls.Add(this.label4);
            this.gbDT.Controls.Add(this.cbLevels);
            this.gbDT.Location = new System.Drawing.Point(692, 31);
            this.gbDT.Name = "gbDT";
            this.gbDT.Size = new System.Drawing.Size(705, 146);
            this.gbDT.TabIndex = 42;
            this.gbDT.TabStop = false;
            this.gbDT.Text = "Выберите:";
            // 
            // btnDate
            // 
            this.btnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnDate.Location = new System.Drawing.Point(281, 84);
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
            this.cbDirection.Location = new System.Drawing.Point(370, 44);
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
            this.cbLevels.Location = new System.Drawing.Point(17, 44);
            this.cbLevels.Name = "cbLevels";
            this.cbLevels.Size = new System.Drawing.Size(323, 30);
            this.cbLevels.TabIndex = 45;
            this.cbLevels.SelectedIndexChanged += new System.EventHandler(this.cbLevels_SelectedIndexChanged);
            // 
            // TabAcademicLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 699);
            this.Controls.Add(this.gbDT);
            this.Controls.Add(this.btnAddLoad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvLoad);
            this.Controls.Add(this.btnSearchLoad);
            this.Controls.Add(this.txtSearchLoad);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.webBrowser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TabAcademicLoad";
            this.Text = "Объем учебной нагрузки";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoad)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbDT.ResumeLayout(false);
            this.gbDT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddLoad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvLoad;
        private System.Windows.Forms.Button btnSearchLoad;
        private System.Windows.Forms.TextBox txtSearchLoad;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem вернутьсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem преподавателиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem дисциплиныToolStripMenuItem;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox gbDT;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.ComboBox cbLevels;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDate;
    }
}