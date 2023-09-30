
namespace Аккредитационные_показатели
{
    partial class TabAdmission_student
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabAdmission_student));
            this.btnAddStud = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvStud = new System.Windows.Forms.DataGridView();
            this.btnSearchStud = new System.Windows.Forms.Button();
            this.txtSearchStud = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.вернутьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.gbDT = new System.Windows.Forms.GroupBox();
            this.btnDate = new System.Windows.Forms.Button();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLevels = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStud)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gbDT.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddStud
            // 
            this.btnAddStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnAddStud.Location = new System.Drawing.Point(513, 40);
            this.btnAddStud.Name = "btnAddStud";
            this.btnAddStud.Size = new System.Drawing.Size(133, 60);
            this.btnAddStud.TabIndex = 52;
            this.btnAddStud.Text = "Добавить";
            this.btnAddStud.UseVisualStyleBackColor = true;
            this.btnAddStud.Click += new System.EventHandler(this.btnAddStud_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(43, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 28);
            this.label3.TabIndex = 51;
            this.label3.Text = "Набор студентов";
            // 
            // dgvStud
            // 
            this.dgvStud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStud.Location = new System.Drawing.Point(12, 121);
            this.dgvStud.Name = "dgvStud";
            this.dgvStud.RowHeadersWidth = 51;
            this.dgvStud.RowTemplate.Height = 24;
            this.dgvStud.Size = new System.Drawing.Size(495, 286);
            this.dgvStud.TabIndex = 50;
            this.dgvStud.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStud_CellMouseDoubleClick);
            // 
            // btnSearchStud
            // 
            this.btnSearchStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnSearchStud.Location = new System.Drawing.Point(417, 77);
            this.btnSearchStud.Name = "btnSearchStud";
            this.btnSearchStud.Size = new System.Drawing.Size(90, 38);
            this.btnSearchStud.TabIndex = 49;
            this.btnSearchStud.Text = "Поиск";
            this.btnSearchStud.UseVisualStyleBackColor = true;
            this.btnSearchStud.Click += new System.EventHandler(this.btnSearchStud_Click);
            // 
            // txtSearchStud
            // 
            this.txtSearchStud.Location = new System.Drawing.Point(12, 86);
            this.txtSearchStud.Name = "txtSearchStud";
            this.txtSearchStud.Size = new System.Drawing.Size(390, 22);
            this.txtSearchStud.TabIndex = 48;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вернутьсяToolStripMenuItem,
            this.справкаToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(879, 30);
            this.menuStrip1.TabIndex = 47;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // вернутьсяToolStripMenuItem
            // 
            this.вернутьсяToolStripMenuItem.Name = "вернутьсяToolStripMenuItem";
            this.вернутьсяToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.вернутьсяToolStripMenuItem.Text = "Вернуться назад";
            this.вернутьсяToolStripMenuItem.Click += new System.EventHandler(this.вернутьсяToolStripMenuItem_Click);
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
            this.webBrowser1.Location = new System.Drawing.Point(232, 208);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(115, 124);
            this.webBrowser1.TabIndex = 53;
            this.webBrowser1.Visible = false;
            // 
            // gbDT
            // 
            this.gbDT.Controls.Add(this.btnDate);
            this.gbDT.Controls.Add(this.cbDirection);
            this.gbDT.Controls.Add(this.label1);
            this.gbDT.Controls.Add(this.label4);
            this.gbDT.Controls.Add(this.cbLevels);
            this.gbDT.Location = new System.Drawing.Point(513, 118);
            this.gbDT.Name = "gbDT";
            this.gbDT.Size = new System.Drawing.Size(353, 287);
            this.gbDT.TabIndex = 54;
            this.gbDT.TabStop = false;
            this.gbDT.Text = "Выберите:";
            // 
            // btnDate
            // 
            this.btnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnDate.Location = new System.Drawing.Point(13, 193);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(323, 65);
            this.btnDate.TabIndex = 43;
            this.btnDate.Text = "Справочник направлений подготовки";
            this.btnDate.UseVisualStyleBackColor = true;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // cbDirection
            // 
            this.cbDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.Location = new System.Drawing.Point(13, 125);
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
            this.label4.Location = new System.Drawing.Point(63, 98);
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
            // TabAdmission_student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 417);
            this.Controls.Add(this.gbDT);
            this.Controls.Add(this.btnAddStud);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvStud);
            this.Controls.Add(this.btnSearchStud);
            this.Controls.Add(this.txtSearchStud);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.webBrowser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TabAdmission_student";
            this.Text = "Набор студентов";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStud)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbDT.ResumeLayout(false);
            this.gbDT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddStud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvStud;
        private System.Windows.Forms.Button btnSearchStud;
        private System.Windows.Forms.TextBox txtSearchStud;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem вернутьсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.GroupBox gbDT;
        private System.Windows.Forms.Button btnDate;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLevels;
    }
}