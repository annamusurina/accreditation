
namespace Аккредитационные_показатели
{
    partial class TabMasterProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabMasterProgram));
            this.btnAddMaster = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvMaster = new System.Windows.Forms.DataGridView();
            this.btnSearchMaster = new System.Windows.Forms.Button();
            this.txtSearchMaster = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.вернутьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.преподавателиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddMaster
            // 
            this.btnAddMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnAddMaster.Location = new System.Drawing.Point(655, 61);
            this.btnAddMaster.Name = "btnAddMaster";
            this.btnAddMaster.Size = new System.Drawing.Size(133, 60);
            this.btnAddMaster.TabIndex = 28;
            this.btnAddMaster.Text = "Добавить";
            this.btnAddMaster.UseVisualStyleBackColor = true;
            this.btnAddMaster.Click += new System.EventHandler(this.btnAddMaster_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(43, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(374, 28);
            this.label3.TabIndex = 27;
            this.label3.Text = "Руководство программы магистратуры";
            // 
            // dgvMaster
            // 
            this.dgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaster.Location = new System.Drawing.Point(12, 127);
            this.dgvMaster.Name = "dgvMaster";
            this.dgvMaster.RowHeadersWidth = 51;
            this.dgvMaster.RowTemplate.Height = 24;
            this.dgvMaster.Size = new System.Drawing.Size(1106, 515);
            this.dgvMaster.TabIndex = 26;
            this.dgvMaster.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMaster_CellMouseDoubleClick);
            // 
            // btnSearchMaster
            // 
            this.btnSearchMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnSearchMaster.Location = new System.Drawing.Point(527, 83);
            this.btnSearchMaster.Name = "btnSearchMaster";
            this.btnSearchMaster.Size = new System.Drawing.Size(90, 38);
            this.btnSearchMaster.TabIndex = 25;
            this.btnSearchMaster.Text = "Поиск";
            this.btnSearchMaster.UseVisualStyleBackColor = true;
            this.btnSearchMaster.Click += new System.EventHandler(this.btnSearchMaster_Click);
            // 
            // txtSearchMaster
            // 
            this.txtSearchMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearchMaster.Location = new System.Drawing.Point(59, 92);
            this.txtSearchMaster.Name = "txtSearchMaster";
            this.txtSearchMaster.Size = new System.Drawing.Size(440, 24);
            this.txtSearchMaster.TabIndex = 24;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вернутьсяToolStripMenuItem,
            this.преподавателиToolStripMenuItem,
            this.сохранениеToolStripMenuItem,
            this.справкаToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1128, 30);
            this.menuStrip1.TabIndex = 23;
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
            this.webBrowser1.Location = new System.Drawing.Point(283, 145);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(250, 250);
            this.webBrowser1.TabIndex = 29;
            this.webBrowser1.Visible = false;
            // 
            // TabMasterProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 654);
            this.Controls.Add(this.btnAddMaster);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvMaster);
            this.Controls.Add(this.btnSearchMaster);
            this.Controls.Add(this.txtSearchMaster);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.webBrowser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TabMasterProgram";
            this.Text = "Руководство программы магистратуры";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddMaster;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvMaster;
        private System.Windows.Forms.Button btnSearchMaster;
        private System.Windows.Forms.TextBox txtSearchMaster;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem вернутьсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem преподавателиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}