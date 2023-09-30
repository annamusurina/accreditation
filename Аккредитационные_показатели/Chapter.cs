using System;
using System.IO;
using System.Windows.Forms;

namespace Аккредитационные_показатели
{
    public partial class Chapter : Form
    {
        public Chapter()
        {
            InitializeComponent();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Url = new Uri(String.Format("file:///{0}/Руководство_пользователя.docx", curDir));
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnPoint1_Click(object sender, EventArgs e)//объем учебной нагрузки
        {
            Hide();
            TabAcademicLoad load = new TabAcademicLoad();
            load.ShowDialog();
            Close();
        }        
        private void btnPoint2_Click(object sender, EventArgs e) //руководтво программы магистратуры
        {
            Hide();
            TabMasterProgram program = new TabMasterProgram();
            program.ShowDialog();
            Close();
        }        
        private void btnPoint3_Click(object sender, EventArgs e)//специалисты-практики
        {
            Hide();
            TabPractitioners practitioners = new TabPractitioners();
            practitioners.ShowDialog();
            Close();
        }
    }
}
