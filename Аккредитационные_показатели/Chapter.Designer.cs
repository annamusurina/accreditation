
namespace Аккредитационные_показатели
{
    partial class Chapter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chapter));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPoint3 = new System.Windows.Forms.Button();
            this.btnPoint2 = new System.Windows.Forms.Button();
            this.btnPoint1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(522, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnBack.Location = new System.Drawing.Point(26, 382);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(149, 51);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Выход";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPoint3
            // 
            this.btnPoint3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPoint3.Location = new System.Drawing.Point(124, 299);
            this.btnPoint3.Name = "btnPoint3";
            this.btnPoint3.Size = new System.Drawing.Size(285, 68);
            this.btnPoint3.TabIndex = 11;
            this.btnPoint3.Text = "Специалисты-практики \r\n(пункт 2.3)";
            this.btnPoint3.UseVisualStyleBackColor = true;
            this.btnPoint3.Click += new System.EventHandler(this.btnPoint3_Click);
            // 
            // btnPoint2
            // 
            this.btnPoint2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPoint2.Location = new System.Drawing.Point(124, 217);
            this.btnPoint2.Name = "btnPoint2";
            this.btnPoint2.Size = new System.Drawing.Size(285, 76);
            this.btnPoint2.TabIndex = 10;
            this.btnPoint2.Text = "Руководство программы магистратуры (пункт 2.2)";
            this.btnPoint2.UseVisualStyleBackColor = true;
            this.btnPoint2.Click += new System.EventHandler(this.btnPoint2_Click);
            // 
            // btnPoint1
            // 
            this.btnPoint1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPoint1.Location = new System.Drawing.Point(124, 140);
            this.btnPoint1.Name = "btnPoint1";
            this.btnPoint1.Size = new System.Drawing.Size(285, 71);
            this.btnPoint1.TabIndex = 9;
            this.btnPoint1.Text = "Объем учебной нагрузки (пункт 2.1)";
            this.btnPoint1.UseVisualStyleBackColor = true;
            this.btnPoint1.Click += new System.EventHandler(this.btnPoint1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(21, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(489, 87);
            this.label1.TabIndex = 8;
            this.label1.Text = "Кадровые условия реализации\r\n основной образовательной программы \r\n(Раздел 2)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(173, 152);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(59, 114);
            this.webBrowser1.TabIndex = 13;
            this.webBrowser1.Visible = false;
            // 
            // Chapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 449);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPoint3);
            this.Controls.Add(this.btnPoint2);
            this.Controls.Add(this.btnPoint1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBrowser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chapter";
            this.Text = "Раздел 2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnPoint3;
        private System.Windows.Forms.Button btnPoint2;
        private System.Windows.Forms.Button btnPoint1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}