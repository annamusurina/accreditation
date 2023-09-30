using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Аккредитационные_показатели
{
    public partial class TabPosition : Form
    {
        private Position position { get; set; } //объект для работы 
        public TabPosition()
        {
            InitializeComponent();
            Fill();
        }
        private void Fill()
        {
            position = new Position();
            DataTable data = new DataTable();
            DataColumn dataColumn1 = new DataColumn("id", Type.GetType("System.Int32"));
            DataColumn dataColumn2 = new DataColumn("Наименование должности", Type.GetType("System.String"));
            data.Columns.Add(dataColumn1);
            data.Columns.Add(dataColumn2);

            foreach (Position p in DBObjects.Entities.Position.ToList())
                data.Rows.Add(p.Code_position, p.Title);
            dgvPosition.DataSource = data;
            dgvPosition.Columns["id"].Visible = false;
            dgvPosition.AllowUserToAddRows = false; //убрать отображение пустой последней строки
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
                for (int i = 0; i < dgvPosition.RowCount; i++)
                {
                    dgvPosition.Rows[i].Selected = false;
                    for (int j = 0; j < dgvPosition.ColumnCount; j++)
                        if (dgvPosition.Rows[i].Cells[j].Value != null)
                            if (dgvPosition.Rows[i].Cells[j].Value.ToString().Contains(txtSearch.Text))
                            {
                                dgvPosition.Rows[i].Selected = true;
                                break;
                            }
                }
            else
                for (int i = 0; i < dgvPosition.RowCount; i++)
                    dgvPosition.Rows[i].Selected = false;
        }        
        private void Delete()
        {
            foreach (AcademicLoad academic in DBObjects.Entities.AcademicLoad.ToList())
                foreach (Teacher teacher in DBObjects.Entities.Teacher.ToList())
                    if (teacher.Code_teacher == academic.Code_teacher && position.Code_position == teacher.Code_position)
                        DBObjects.Entities.AcademicLoad.Remove(academic);
            foreach (Teacher teacher in DBObjects.Entities.Teacher.ToList())
                if (teacher.Code_position == position.Code_position)
                    DBObjects.Entities.Teacher.Remove(teacher);
            DBObjects.Entities.SaveChanges();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "")
            {
                if (DBObjects.Entities.Position.Where(p => p.Code_position == position.Code_position).Count() == 0)
                {
                    DBObjects.Entities.Position.Add(position);
                }
                DBObjects.Entities.SaveChanges();
                Fill();
            }
            else
                MessageBox.Show("Заполните пустые поля.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DBObjects.Entities.Position.Where(p => p.Code_position == position.Code_position).Count() > 0)
            {
                Delete();
                DBObjects.Entities.Position.Remove(position);
                DBObjects.Entities.SaveChanges();
            }
            Fill();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Fill();
        }
        private void dgvPosition_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvPosition[0, dgvPosition.CurrentRow.Index].Value.ToString());
            foreach (Position i in DBObjects.Entities.Position.ToList())
                if (i.Code_position == id)
                {
                    position = i;
                    txtTitle.Text = i.Title;
                }
        }
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            position.Title = txtTitle.Text;
        }
    }
}
