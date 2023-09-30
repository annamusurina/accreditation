using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Аккредитационные_показатели
{
    public partial class TabLoadRate : Form
    {
        private DataTable table = new DataTable();
        public TabLoadRate()
        {
            InitializeComponent();
            Fill();
        }
        private void Fill()
        {
            Table();
            dgvLoadRate.DataSource = table;
            dgvLoadRate.Columns["id"].Visible = false;
            dgvLoadRate.AllowUserToAddRows = false; //убрать отображение пустой последней строки
        }
        private void Table()
        {
            DataTable data = new DataTable();
            DataColumn dataColumn1 = new DataColumn("id", Type.GetType("System.Int32"));
            DataColumn dataColumn2 = new DataColumn("Должность", Type.GetType("System.String"));
            DataColumn dataColumn3 = new DataColumn("Число часов", Type.GetType("System.String"));
            DataColumn dataColumn4 = new DataColumn("Учебный год", Type.GetType("System.String"));
            data.Columns.Add(dataColumn1);
            data.Columns.Add(dataColumn2);
            data.Columns.Add(dataColumn3);
            data.Columns.Add(dataColumn4);

            foreach (LoadRate l in DBObjects.Entities.LoadRate.ToList())
            {
                data.Rows.Add(l.Code_lr,l.Position.Title,l.Number_hours,l.AcademicYear_load);
            }
            table = data;
        }
        private void вернутьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPosition position = new TabPosition();
            position.ShowDialog();
            Fill();
        }
        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Url = new Uri(String.Format("file:///{0}/Руководство_пользователя.docx", curDir));
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                for (int i = 0; i < dgvLoadRate.RowCount; i++)
                {
                    dgvLoadRate.Rows[i].Selected = false;
                    for (int j = 0; j < dgvLoadRate.ColumnCount; j++)
                        if (dgvLoadRate.Rows[i].Cells[j].Value != null)
                            if (dgvLoadRate.Rows[i].Cells[j].Value.ToString().Contains(txtSearch.Text))
                            {
                                dgvLoadRate.Rows[i].Selected = true;
                                break;
                            }
                }
            else
                for (int i = 0; i < dgvLoadRate.RowCount; i++)
                    dgvLoadRate.Rows[i].Selected = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            LoadRate load = new LoadRate();
            AddLoadRate add = new AddLoadRate(load);
            add.ShowDialog();
            Fill();
        }
        private void dgvLoadRate_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvLoadRate[0, dgvLoadRate.CurrentRow.Index].Value.ToString());
            foreach (LoadRate i in DBObjects.Entities.LoadRate.ToList())
                if (i.Code_lr == id)
                {
                    LoadRate load = i;
                    AddLoadRate add = new AddLoadRate(load);
                    add.ShowDialog();
                    Fill();
                }
        }
    }
}
