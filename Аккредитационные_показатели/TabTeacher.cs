using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Аккредитационные_показатели
{
    public partial class TabTeacher : Form
    {
        private DataTable table = new DataTable();
        public TabTeacher()
        {
            InitializeComponent();
            Fill();
        }
        private void Fill()
        {
            Table();
            dgvTeacher.DataSource = table;
            dgvTeacher.Columns["id"].Visible = false;
            dgvTeacher.AllowUserToAddRows = false; //убрать отображение пустой последней строки
        }
        private void Table()
        {
            DataTable data = new DataTable();
            DataColumn dataColumn1 = new DataColumn("id", Type.GetType("System.Int32"));
            DataColumn dataColumn2 = new DataColumn("Фамилия, имя, отчество", Type.GetType("System.String"));
            DataColumn dataColumn3 = new DataColumn("Условия привлечения", Type.GetType("System.String"));
            DataColumn dataColumn4 = new DataColumn("Должность", Type.GetType("System.String"));
            DataColumn dataColumn5 = new DataColumn("Ученая степень", Type.GetType("System.String"));
            DataColumn dataColumn6 = new DataColumn("Ученое звание", Type.GetType("System.String"));
            DataColumn dataColumn7 = new DataColumn("Уровень образования", Type.GetType("System.String"));
            DataColumn dataColumn8 = new DataColumn("Наименование специальности", Type.GetType("System.String"));
            DataColumn dataColumn9 = new DataColumn("Присвоенная квалификация", Type.GetType("System.String"));
            DataColumn dataColumn10 = new DataColumn("Сведения о дополнительном профессиональным образовании", Type.GetType("System.String"));
            DataColumn dataColumn11 = new DataColumn("Стаж работы в организациях с образовательной деятельностью", Type.GetType("System.String"));
            DataColumn dataColumn12 = new DataColumn("Стаж работы в иных организациях", Type.GetType("System.String"));
            data.Columns.Add(dataColumn1);
            data.Columns.Add(dataColumn2);
            data.Columns.Add(dataColumn3);
            data.Columns.Add(dataColumn4);
            data.Columns.Add(dataColumn5);
            data.Columns.Add(dataColumn6);
            data.Columns.Add(dataColumn7);
            data.Columns.Add(dataColumn8);
            data.Columns.Add(dataColumn9);
            data.Columns.Add(dataColumn10);
            data.Columns.Add(dataColumn11);
            data.Columns.Add(dataColumn12);
            
            foreach (Teacher t in DBObjects.Entities.Teacher.ToList())
            {
                data.Rows.Add(t.Code_teacher, t.FIO_teacher, t.TermsAttraction_teacher, t.Position.Title, t.AcademicDegree_teacher, t.AcademicTitle_teacher, t.EducationLevel_teacher,
                    t.TitleSpecialty_teacher,t.AssignedQualification_teacher,t.AdditionalProfEducation_teacher,t.WorkEducationalActivities_teacher,t.WorkOtherOrg_teacher);
            }
            table = data;
        }
        private void вернутьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Chapter chapter = new Chapter();
            chapter.ShowDialog();
            Close();
        }
        private void объемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            TabAcademicLoad academic = new TabAcademicLoad();
            academic.ShowDialog();
            Close();
        }
        private void руководствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            TabMasterProgram master = new TabMasterProgram();
            master.ShowDialog();
            Close();
        }
        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Url = new Uri(String.Format("file:///{0}/Руководство_пользователя.docx", curDir));
        }
        private void btnSearchTeacher_Click(object sender, EventArgs e)
        {
            if (txtSearchTeacher.Text != "")
                for (int i = 0; i < dgvTeacher.RowCount; i++)
                {
                    dgvTeacher.Rows[i].Selected = false;
                    for (int j = 0; j < dgvTeacher.ColumnCount; j++)
                        if (dgvTeacher.Rows[i].Cells[j].Value != null)
                            if (dgvTeacher.Rows[i].Cells[j].Value.ToString().Contains(txtSearchTeacher.Text))
                            {
                                dgvTeacher.Rows[i].Selected = true;
                                break;
                            }
                }
            else
                for (int i = 0; i < dgvTeacher.RowCount; i++)
                    dgvTeacher.Rows[i].Selected = false;
        }
        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();
            AddTeacher add = new AddTeacher(teacher);
            add.ShowDialog();
            Fill();
        }
        private void dgvTeacher_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvTeacher[0, dgvTeacher.CurrentRow.Index].Value.ToString());
            foreach (Teacher i in DBObjects.Entities.Teacher.ToList())
                if (i.Code_teacher == id)
                {
                    Teacher teacher = i;
                    AddTeacher add = new AddTeacher(teacher);
                    add.ShowDialog();
                    Fill();
                }
        }
    }
}
