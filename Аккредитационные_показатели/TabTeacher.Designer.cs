
namespace Аккредитационные_показатели
{
    partial class TabTeacher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabTeacher));
            this.btnAddTeacher = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTeacher = new System.Windows.Forms.DataGridView();
            this.btnSearchTeacher = new System.Windows.Forms.Button();
            this.txtSearchTeacher = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.вернутьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.объемToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.руководствоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacher)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnAddTeacher.Location = new System.Drawing.Point(655, 62);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(133, 60);
            this.btnAddTeacher.TabIndex = 40;
            this.btnAddTeacher.Text = "Добавить";
            this.btnAddTeacher.UseVisualStyleBackColor = true;
            this.btnAddTeacher.Click += new System.EventHandler(this.btnAddTeacher_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(43, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 28);
            this.label3.TabIndex = 39;
            this.label3.Text = "Преподаватели";
            // 
            // dgvTeacher
            // 
            this.dgvTeacher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeacher.Location = new System.Drawing.Point(12, 128);
            this.dgvTeacher.Name = "dgvTeacher";
            this.dgvTeacher.RowHeadersWidth = 51;
            this.dgvTeacher.RowTemplate.Height = 24;
            this.dgvTeacher.Size = new System.Drawing.Size(1237, 286);
            this.dgvTeacher.TabIndex = 38;
            this.dgvTeacher.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTeacher_CellMouseDoubleClick);
            // 
            // btnSearchTeacher
            // 
            this.btnSearchTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnSearchTeacher.Location = new System.Drawing.Point(527, 84);
            this.btnSearchTeacher.Name = "btnSearchTeacher";
            this.btnSearchTeacher.Size = new System.Drawing.Size(90, 38);
            this.btnSearchTeacher.TabIndex = 37;
            this.btnSearchTeacher.Text = "Поиск";
            this.btnSearchTeacher.UseVisualStyleBackColor = true;
            this.btnSearchTeacher.Click += new System.EventHandler(this.btnSearchTeacher_Click);
            // 
            // txtSearchTeacher
            // 
            this.txtSearchTeacher.Location = new System.Drawing.Point(59, 93);
            this.txtSearchTeacher.Name = "txtSearchTeacher";
            this.txtSearchTeacher.Size = new System.Drawing.Size(440, 22);
            this.txtSearchTeacher.TabIndex = 36;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вернутьсяToolStripMenuItem,
            this.объемToolStripMenuItem,
            this.руководствоToolStripMenuItem,
            this.справкаToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1265, 28);
            this.menuStrip1.TabIndex = 35;
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
            // руководствоToolStripMenuItem
            // 
            this.руководствоToolStripMenuItem.Name = "руководствоToolStripMenuItem";
            this.руководствоToolStripMenuItem.Size = new System.Drawing.Size(297, 24);
            this.руководствоToolStripMenuItem.Text = "Руководство программы магистратуры";
            this.руководствоToolStripMenuItem.Click += new System.EventHandler(this.руководствоToolStripMenuItem_Click);
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
            this.webBrowser1.Location = new System.Drawing.Point(366, 218);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(108, 129);
            this.webBrowser1.TabIndex = 41;
            this.webBrowser1.Visible = false;
            // 
            // TabTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 430);
            this.Controls.Add(this.btnAddTeacher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvTeacher);
            this.Controls.Add(this.btnSearchTeacher);
            this.Controls.Add(this.txtSearchTeacher);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.webBrowser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TabTeacher";
            this.Text = "Преподаватели";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacher)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddTeacher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvTeacher;
        private System.Windows.Forms.Button btnSearchTeacher;
        private System.Windows.Forms.TextBox txtSearchTeacher;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem вернутьсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem объемToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem руководствоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem1;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}