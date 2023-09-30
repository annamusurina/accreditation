using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Аккредитационные_показатели
{
    public partial class TabAdmission_student : Form
    {
        private int code_dt = 0;
        private DataTable table = new DataTable();
        public TabAdmission_student()
        {
            InitializeComponent();
            Fill();
        }
        private void Fill()
        {
            cbLevels.DataSource = DBObjects.Entities.EducationLevels.ToList();            
        }
        private void Table(int code_dt)
        {
            DataTable data = new DataTable();
            DataColumn dataColumn1 = new DataColumn("Code_adst", Type.GetType("System.Int32"));
            DataColumn dataColumn2 = new DataColumn("Code_dt", Type.GetType("System.Int32"));
            DataColumn dataColumn3 = new DataColumn("Код", Type.GetType("System.String"));
            DataColumn dataColumn4 = new DataColumn("Наименование направления", Type.GetType("System.String"));
            DataColumn dataColumn5 = new DataColumn("Набор студентов", Type.GetType("System.String"));
            data.Columns.Add(dataColumn1);
            data.Columns.Add(dataColumn2);
            data.Columns.Add(dataColumn3);
            data.Columns.Add(dataColumn4);
            data.Columns.Add(dataColumn5);

            foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())
                if (student.Code_dt == code_dt)
                    data.Rows.Add(student.Code_adst, student.Code_dt, student.DirectionTraining.Code, student.DirectionTraining.Title_dt, student.AcademicYear_adst);
            table = data;
        }
        private void вернутьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            TabDisciplineSemeater discipline = new TabDisciplineSemeater();
            discipline.ShowDialog();
            Close();
        }
        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Url = new Uri(String.Format("file:///{0}/Руководство_пользователя.docx", curDir));
        }
        private void btnSearchStud_Click(object sender, EventArgs e)
        {
            if (txtSearchStud.Text != "")
                for (int i = 0; i < dgvStud.RowCount; i++)
                {
                    dgvStud.Rows[i].Selected = false;
                    for (int j = 0; j < dgvStud.ColumnCount; j++)
                        if (dgvStud.Rows[i].Cells[j].Value != null)
                            if (dgvStud.Rows[i].Cells[j].Value.ToString().Contains(txtSearchStud.Text))
                            {
                                dgvStud.Rows[i].Selected = true;
                                break;
                            }
                }
            else
                for (int i = 0; i < dgvStud.RowCount; i++)
                    dgvStud.Rows[i].Selected = false;
        }
        private void btnAddStud_Click(object sender, EventArgs e)
        {
            Admission_student stu = new Admission_student();
            AddAdmission_student add = new AddAdmission_student(stu, code_dt);
            add.ShowDialog();
            Table(code_dt);

            dgvStud.DataSource = table;
            dgvStud.Columns["Code_adst"].Visible = false;
            dgvStud.Columns["Code_dt"].Visible = false;
            for (int j = 1; j < dgvStud.ColumnCount; j++)
                dgvStud.Columns[j].ReadOnly = true;
            dgvStud.AllowUserToAddRows = false; //убрать отображение пустой последней строки
        }
        private void dgvStud_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvStud[0, dgvStud.CurrentRow.Index].Value.ToString());
            foreach (Admission_student i in DBObjects.Entities.Admission_student.ToList())
                if (i.Code_adst == id)
                {
                    Admission_student stu = i;
                    AddAdmission_student add = new AddAdmission_student(stu, code_dt);
                    add.ShowDialog();
                    Table(code_dt);

                    dgvStud.DataSource = table;
                    dgvStud.Columns["Code_adst"].Visible = false;
                    dgvStud.Columns["Code_dt"].Visible = false;
                    for (int j = 1; j < dgvStud.ColumnCount; j++)
                        dgvStud.Columns[j].ReadOnly = true;
                    dgvStud.AllowUserToAddRows = false; //убрать отображение пустой последней строки
                }
        }
        private void cbLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLevels.SelectedItem.ToString() != "")
            {
                int number = 0;
                foreach (EducationLevels lev in DBObjects.Entities.EducationLevels.ToList())
                    if (cbLevels.SelectedItem.ToString() == lev.Title_levels)
                        number = lev.Code_levels;
                cbDirection.Items.Clear();
                cbDirection.ResetText();
                foreach (DirectionTraining direction in DBObjects.Entities.DirectionTraining.ToList())
                    if (direction.Code_levels == number)
                        cbDirection.Items.Add(direction.Title_dt);
            }
            else
                MessageBox.Show("Выберите или добавьте уровень образования.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDirection.SelectedItem.ToString() != "")
            {
                foreach (DirectionTraining direction in DBObjects.Entities.DirectionTraining.ToList())
                    if (direction.Title_dt == cbDirection.SelectedItem.ToString())
                    {
                        code_dt = direction.Code_dt;
                        Table(direction.Code_dt);

                        dgvStud.DataSource = table;
                        dgvStud.Columns["Code_adst"].Visible = false;
                        dgvStud.Columns["Code_dt"].Visible = false;
                        for (int i = 1; i < dgvStud.ColumnCount; i++)
                            dgvStud.Columns[i].ReadOnly = true;
                        dgvStud.AllowUserToAddRows = false; //убрать отображение пустой последней строки
                    }
            }
        }
        private void btnDate_Click(object sender, EventArgs e)
        {
            Change_Data change = new Change_Data();
            change.ShowDialog();
            Fill();
        }
    }
}
