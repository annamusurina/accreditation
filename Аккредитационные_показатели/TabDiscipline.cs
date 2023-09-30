using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Аккредитационные_показатели
{
    public partial class TabDiscipline : Form
    {
        private Disciplines disciplines { get; set; } //объект для работы 
        public TabDiscipline()
        {
            InitializeComponent();
            Fill();
        }
        private void Fill()
        {
            disciplines = new Disciplines();
            DataTable data = new DataTable();
            DataColumn dataColumn1 = new DataColumn("id", Type.GetType("System.Int32"));
            DataColumn dataColumn2 = new DataColumn("Наименование дисциплины", Type.GetType("System.String"));
            data.Columns.Add(dataColumn1);
            data.Columns.Add(dataColumn2);

            foreach (Disciplines d in DBObjects.Entities.Disciplines.ToList())
                data.Rows.Add(d.Code_discipline, d.Title_discipline);
            dgvDisc.DataSource = data;
            dgvDisc.Columns["id"].Visible = false;
            dgvDisc.AllowUserToAddRows = false; //убрать отображение пустой последней строки
            txtTitle.Text = "";
        }
        private void вернутьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Url = new Uri(String.Format("file:///{0}/Руководство_пользователя.docx", curDir));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                for (int i = 0; i < dgvDisc.RowCount; i++)
                {
                    dgvDisc.Rows[i].Selected = false;
                    for (int j = 0; j < dgvDisc.ColumnCount; j++)
                        if (dgvDisc.Rows[i].Cells[j].Value != null)
                            if (dgvDisc.Rows[i].Cells[j].Value.ToString().Contains(txtSearch.Text))
                            {
                                dgvDisc.Rows[i].Selected = true;
                                break;
                            }
                }
            else
                for (int i = 0; i < dgvDisc.RowCount; i++)
                    dgvDisc.Rows[i].Selected = false;
        }
        private void Delete()
        {
            foreach (AcademicLoad academic in DBObjects.Entities.AcademicLoad.ToList())
                foreach (DisciplinesSemester disciplinesS in DBObjects.Entities.DisciplinesSemester.ToList())
                    if (disciplinesS.Code_semester == academic.Code_semester && disciplines.Code_discipline == disciplinesS.Code_discipline)
                        DBObjects.Entities.AcademicLoad.Remove(academic);
            foreach (DisciplinesSemester disciplinesS in DBObjects.Entities.DisciplinesSemester.ToList())
                if (disciplinesS.Code_discipline == disciplines.Code_discipline)
                    DBObjects.Entities.DisciplinesSemester.Remove(disciplinesS);
            DBObjects.Entities.SaveChanges();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "")
            {
                if (DBObjects.Entities.Disciplines.Where(p => p.Code_discipline == disciplines.Code_discipline).Count() == 0)
                {
                    DBObjects.Entities.Disciplines.Add(disciplines);
                }
                DBObjects.Entities.SaveChanges();
                Fill();
            }
            else
                MessageBox.Show("Заполните пустые поля.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DBObjects.Entities.Disciplines.Where(p => p.Code_discipline == disciplines.Code_discipline).Count() > 0)
            {
                Delete();
                DBObjects.Entities.Disciplines.Remove(disciplines);
                DBObjects.Entities.SaveChanges();
            }
            Fill();
        }
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            disciplines.Title_discipline = txtTitle.Text;
        }
        private void dgvDisc_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvDisc[0, dgvDisc.CurrentRow.Index].Value.ToString());
            foreach (Disciplines i in DBObjects.Entities.Disciplines.ToList())
                if (i.Code_discipline == id)
                {
                    disciplines = i;
                    txtTitle.Text = i.Title_discipline;
                }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Fill();
        }
    }
}
