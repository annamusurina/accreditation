using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Аккредитационные_показатели
{
    public partial class Change_Data : Form
    {
        public Change_Data()
        {
            InitializeComponent();
            Fill();
        }
        private void Fill()
        {
            DataTable data = new DataTable();
            DataColumn dataColumn1 = new DataColumn("Code_dt", Type.GetType("System.Int32"));
            DataColumn dataColumn2 = new DataColumn("Code_levels", Type.GetType("System.Int32"));
            DataColumn dataColumn3 = new DataColumn("Код", Type.GetType("System.String"));
            DataColumn dataColumn4 = new DataColumn("Наименование", Type.GetType("System.String"));
            DataColumn dataColumn5 = new DataColumn("Уровень образования", Type.GetType("System.String"));
            data.Columns.Add(dataColumn1);
            data.Columns.Add(dataColumn2);
            data.Columns.Add(dataColumn3);
            data.Columns.Add(dataColumn4);
            data.Columns.Add(dataColumn5);

            int n = 0;          
            foreach (DirectionTraining d in DBObjects.Entities.DirectionTraining.ToList())
            {
                n++;
            }
            int[,] word = new int[n,5];
            int k = 0;
            foreach (DirectionTraining d in DBObjects.Entities.DirectionTraining.ToList())
            {
                if (d.Code != "")
                {
                    string[] arr = d.Code.Split(new Char[] { '.' });
                    for (int j = 2; j < 5; j++)
                    {
                        word[k, j] = Convert.ToInt32(arr[j - 2]);
                    }
                    word[k, 0] = d.Code_dt;
                    word[k, 1] = d.Code_levels;
                    k++;
                }
                else
                {
                    for (int j = 2; j < 5; j++)
                    {
                        word[k, j] = 0;
                    }
                    word[k, 0] = d.Code_dt;
                    word[k, 1] = d.Code_levels;
                    k++;
                }
            }
            for (int i = 0; i < n-1; i++)
            {
                for (int j = i+1; j < n ; j++)
                {
                    if (word[i, 1] > word[j, 1])
                    {
                        for (int col = 0; col < 5; col++)
                        {
                            int tmp = word[i, col];
                            word[i, col] = word[j, col];
                            word[j, col] = tmp;
                        }
                    }
                    else
                    if (word[i, 1] == word[j, 1])
                    {
                        if (word[i, 3] > word[j, 3])
                        {
                            for (int col = 0; col < 5; col++)
                            {
                                int tmp = word[i, col];
                                word[i, col] = word[j, col];
                                word[j, col] = tmp;
                            }
                        }
                        else
                        {
                            if (word[i, 3] == word[j, 3])
                            {
                                if (word[i, 2] > word[j, 2])
                                {
                                    for (int col = 0; col < 5; col++)
                                    {
                                        int tmp = word[i, col];
                                        word[i, col] = word[j, col];
                                        word[j, col] = tmp;
                                    }
                                }
                                else
                                if (word[i, 2] == word[j, 2])
                                {
                                    if (word[i, 4] > word[j, 4])
                                    {
                                        for (int col = 0; col < 5; col++)
                                        {
                                            int tmp = word[i, col];
                                            word[i, col] = word[j, col];
                                            word[j, col] = tmp;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < n; i++)
                foreach (DirectionTraining d in DBObjects.Entities.DirectionTraining.ToList())
                    if (word[i, 0] == d.Code_dt)
                    {
                        data.Rows.Add(d.Code_dt, d.Code_levels, d.Code, d.Title_dt, d.EducationLevels.Title_levels);
                        break;
                    }                

            dgvDT.DataSource = data;
            dgvDT.Columns["Code_dt"].Visible = false;
            dgvDT.Columns["Code_levels"].Visible = false;
            dgvDT.AllowUserToAddRows = false; //убрать отображение пустой последней строки

            DataTable dataLevel = new DataTable();
            DataColumn Column1 = new DataColumn("Code_levels", Type.GetType("System.Int32"));
            DataColumn Column2 = new DataColumn("Наименование", Type.GetType("System.String"));
            dataLevel.Columns.Add(Column1);
            dataLevel.Columns.Add(Column2);

            foreach (EducationLevels lev in DBObjects.Entities.EducationLevels.ToList())
            {
                dataLevel.Rows.Add(lev.Code_levels,lev.Title_levels);
            }
            dgvLavel.DataSource = dataLevel;
            dgvLavel.Columns["Code_levels"].Visible = false;
            dgvLavel.AllowUserToAddRows = false; //убрать отображение пустой последней строки
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Url = new Uri(String.Format("file:///{0}/Руководство_пользователя.docx", curDir));
        }
        private void btnSearchLevel_Click(object sender, EventArgs e)
        {
            if (txtSearchLevel.Text != "")
                for (int i = 0; i < dgvLavel.RowCount; i++)
                {
                    dgvLavel.Rows[i].Selected = false;
                    for (int j = 0; j < dgvLavel.ColumnCount; j++)
                        if (dgvLavel.Rows[i].Cells[j].Value != null)
                            if (dgvLavel.Rows[i].Cells[j].Value.ToString().Contains(txtSearchLevel.Text))
                            {
                                dgvLavel.Rows[i].Selected = true;
                                break;
                            }
                }
            else
                for (int i = 0; i < dgvLavel.RowCount; i++)
                    dgvLavel.Rows[i].Selected = false;
        }
        private void btnSearchDT_Click(object sender, EventArgs e)
        {
            if (txtSearchDT.Text != "")
                for (int i = 0; i < dgvDT.RowCount; i++)
                {
                    dgvDT.Rows[i].Selected = false;
                    for (int j = 0; j < dgvDT.ColumnCount; j++)
                        if (dgvDT.Rows[i].Cells[j].Value != null)
                            if (dgvDT.Rows[i].Cells[j].Value.ToString().Contains(txtSearchDT.Text))
                            {
                                dgvDT.Rows[i].Selected = true;
                                break;
                            }
                }
            else
                for (int i = 0; i < dgvDT.RowCount; i++)
                    dgvDT.Rows[i].Selected = false;
        }
        private void btnAddDT_Click(object sender, EventArgs e)
        {
            DirectionTraining dt = new DirectionTraining();
            AddDirectTrain add = new AddDirectTrain(dt);
            add.ShowDialog();
            Fill();
        }
        private void dgvDT_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvDT[0, dgvDT.CurrentRow.Index].Value.ToString());
            foreach (DirectionTraining i in DBObjects.Entities.DirectionTraining.ToList())
                if (i.Code_dt == id)
                {
                    DirectionTraining dt = i;
                    AddDirectTrain add = new AddDirectTrain(dt);
                    add.ShowDialog();
                    Fill();
                }
        }
        private void btnAddLevel_Click(object sender, EventArgs e)
        {
            EducationLevels el = new EducationLevels();
            AddLevels add = new AddLevels(el);
            add.ShowDialog();
            Fill();
        }
        private void dgvLavel_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvLavel[0, dgvLavel.CurrentRow.Index].Value.ToString());
            foreach (EducationLevels i in DBObjects.Entities.EducationLevels.ToList())
                if (i.Code_levels == id)
                {
                    EducationLevels el = i;
                    AddLevels add = new AddLevels(el);
                    add.ShowDialog();
                    Fill();
                }
        }
        private void вернутьсяНазадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
