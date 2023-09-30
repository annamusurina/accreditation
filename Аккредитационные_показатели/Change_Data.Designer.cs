
namespace Аккредитационные_показатели
{
    partial class Change_Data
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Change_Data));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.вернутьсяНазадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddDT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDT = new System.Windows.Forms.DataGridView();
            this.btnSearchDT = new System.Windows.Forms.Button();
            this.txtSearchDT = new System.Windows.Forms.TextBox();
            this.btnAddLevel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvLavel = new System.Windows.Forms.DataGridView();
            this.btnSearchLevel = new System.Windows.Forms.Button();
            this.txtSearchLevel = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLavel)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вернутьсяНазадToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1146, 28);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // вернутьсяНазадToolStripMenuItem
            // 
            this.вернутьсяНазадToolStripMenuItem.Name = "вернутьсяНазадToolStripMenuItem";
            this.вернутьсяНазадToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.вернутьсяНазадToolStripMenuItem.Text = "Вернуться назад";
            this.вернутьсяНазадToolStripMenuItem.Click += new System.EventHandler(this.вернутьсяНазадToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // btnAddDT
            // 
            this.btnAddDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnAddDT.Location = new System.Drawing.Point(602, 128);
            this.btnAddDT.Name = "btnAddDT";
            this.btnAddDT.Size = new System.Drawing.Size(122, 73);
            this.btnAddDT.TabIndex = 21;
            this.btnAddDT.Text = "Добавить";
            this.btnAddDT.UseVisualStyleBackColor = true;
            this.btnAddDT.Click += new System.EventHandler(this.btnAddDT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(45, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 28);
            this.label1.TabIndex = 19;
            this.label1.Text = "Направления подготовки";
            // 
            // dgvDT
            // 
            this.dgvDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDT.Location = new System.Drawing.Point(14, 128);
            this.dgvDT.Name = "dgvDT";
            this.dgvDT.RowHeadersWidth = 51;
            this.dgvDT.RowTemplate.Height = 24;
            this.dgvDT.Size = new System.Drawing.Size(582, 286);
            this.dgvDT.TabIndex = 17;
            this.dgvDT.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDT_CellMouseDoubleClick);
            // 
            // btnSearchDT
            // 
            this.btnSearchDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnSearchDT.Location = new System.Drawing.Point(496, 86);
            this.btnSearchDT.Name = "btnSearchDT";
            this.btnSearchDT.Size = new System.Drawing.Size(80, 35);
            this.btnSearchDT.TabIndex = 16;
            this.btnSearchDT.Text = "Поиск";
            this.btnSearchDT.UseVisualStyleBackColor = true;
            this.btnSearchDT.Click += new System.EventHandler(this.btnSearchDT_Click);
            // 
            // txtSearchDT
            // 
            this.txtSearchDT.Location = new System.Drawing.Point(50, 93);
            this.txtSearchDT.Name = "txtSearchDT";
            this.txtSearchDT.Size = new System.Drawing.Size(440, 22);
            this.txtSearchDT.TabIndex = 15;
            // 
            // btnAddLevel
            // 
            this.btnAddLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnAddLevel.Location = new System.Drawing.Point(1025, 126);
            this.btnAddLevel.Name = "btnAddLevel";
            this.btnAddLevel.Size = new System.Drawing.Size(114, 73);
            this.btnAddLevel.TabIndex = 26;
            this.btnAddLevel.Text = "Добавить";
            this.btnAddLevel.UseVisualStyleBackColor = true;
            this.btnAddLevel.Click += new System.EventHandler(this.btnAddLevel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(783, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 28);
            this.label3.TabIndex = 25;
            this.label3.Text = "Уровни образования";
            // 
            // dgvLavel
            // 
            this.dgvLavel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLavel.Location = new System.Drawing.Point(779, 128);
            this.dgvLavel.Name = "dgvLavel";
            this.dgvLavel.RowHeadersWidth = 51;
            this.dgvLavel.RowTemplate.Height = 24;
            this.dgvLavel.Size = new System.Drawing.Size(240, 286);
            this.dgvLavel.TabIndex = 24;
            this.dgvLavel.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLavel_CellMouseDoubleClick);
            // 
            // btnSearchLevel
            // 
            this.btnSearchLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnSearchLevel.Location = new System.Drawing.Point(1025, 86);
            this.btnSearchLevel.Name = "btnSearchLevel";
            this.btnSearchLevel.Size = new System.Drawing.Size(80, 35);
            this.btnSearchLevel.TabIndex = 23;
            this.btnSearchLevel.Text = "Поиск";
            this.btnSearchLevel.UseVisualStyleBackColor = true;
            this.btnSearchLevel.Click += new System.EventHandler(this.btnSearchLevel_Click);
            // 
            // txtSearchLevel
            // 
            this.txtSearchLevel.Location = new System.Drawing.Point(779, 94);
            this.txtSearchLevel.Name = "txtSearchLevel";
            this.txtSearchLevel.Size = new System.Drawing.Size(240, 22);
            this.txtSearchLevel.TabIndex = 22;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(187, 176);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(140, 158);
            this.webBrowser1.TabIndex = 27;
            this.webBrowser1.Visible = false;
            // 
            // Change_Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 426);
            this.Controls.Add(this.btnAddLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvLavel);
            this.Controls.Add(this.btnSearchLevel);
            this.Controls.Add(this.txtSearchLevel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnAddDT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDT);
            this.Controls.Add(this.btnSearchDT);
            this.Controls.Add(this.txtSearchDT);
            this.Controls.Add(this.webBrowser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Change_Data";
            this.Text = "Справочник направлений подготовки";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLavel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Button btnAddDT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDT;
        private System.Windows.Forms.Button btnSearchDT;
        private System.Windows.Forms.TextBox txtSearchDT;
        private System.Windows.Forms.Button btnAddLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvLavel;
        private System.Windows.Forms.Button btnSearchLevel;
        private System.Windows.Forms.TextBox txtSearchLevel;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripMenuItem вернутьсяНазадToolStripMenuItem;
    }
}