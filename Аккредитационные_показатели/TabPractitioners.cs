using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Аккредитационные_показатели
{
    public partial class TabPractitioners : Form
    {
        private DataTable table = new DataTable();
        private DataTable tableDoc = new DataTable();
        public TabPractitioners()
        {
            InitializeComponent();
            Fill();
        }
        private void Fill()
        {
            Table();
            dgvPract.DataSource = table;
            dgvPract.Columns["id"].Visible = false;
            for (int i = 1; i < dgvPract.ColumnCount; i++)
                dgvPract.Columns[i].ReadOnly = true;
            dgvPract.AllowUserToAddRows = false; //убрать отображение пустой последней строки
        }
        private void вернутьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Chapter chapter = new Chapter();
            chapter.ShowDialog();
            Close();
        }
        private void преподавателиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            TabTeacher teacher = new TabTeacher();
            teacher.ShowDialog();
            Close();
        }
        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Url = new Uri(String.Format("file:///{0}/Руководство_пользователя.docx", curDir));
        }
        private void btnSearchPract_Click(object sender, EventArgs e)
        {
            if (txtSearchPract.Text != "")
                for (int i = 0; i < dgvPract.RowCount; i++)
                {
                    dgvPract.Rows[i].Selected = false;
                    for (int j = 0; j < dgvPract.ColumnCount; j++)
                        if (dgvPract.Rows[i].Cells[j].Value != null)
                            if (dgvPract.Rows[i].Cells[j].Value.ToString().Contains(txtSearchPract.Text))
                            {
                                dgvPract.Rows[i].Selected = true;
                                break;
                            }
                }
            else
                for (int i = 0; i < dgvPract.RowCount; i++)
                    dgvPract.Rows[i].Selected = false;
        }
        private void btnAddPract_Click(object sender, EventArgs e)
        {
            Practitioners practitioners = new Practitioners();
            AddPractitioners add = new AddPractitioners(practitioners);
            add.ShowDialog();
            Fill();
        }
        private void dgvPract_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvPract[0, dgvPract.CurrentRow.Index].Value.ToString());
            foreach (Practitioners i in DBObjects.Entities.Practitioners.ToList())
                if (i.Code_practitioner == id)
                {
                    Practitioners practitioners = i;
                    AddPractitioners add = new AddPractitioners(practitioners);
                    add.ShowDialog();
                    Fill();
                }
        }
        private void Table()
        {
            DataTable dataTable = new DataTable(); //создание таблицы
           
            //добавление колонок
            DataColumn dataColumn1 = new DataColumn("id", Type.GetType("System.Int32"));
            DataColumn dataColumn2 = new DataColumn("№п/п", Type.GetType("System.Int32"));
            DataColumn dataColumn3 = new DataColumn("Фамилия, имя, отчество (при наличии) специалиста-практика", Type.GetType("System.String"));
            DataColumn dataColumn4 = new DataColumn("Наименование организации, осуществляющей деятельность в профессиональной сфере, в которой работает специалист-практик по основному месту работы или на условиях внешнего штатного совместительства", Type.GetType("System.String"));
            DataColumn dataColumn5 = new DataColumn("Занимаемая специалистом-практиком должность", Type.GetType("System.String"));
            DataColumn dataColumn6 = new DataColumn("Период работы в организации, осуществляющей деятельность в профессиональной сфере, соответствующей профессиональной деятельности, к которой готовится выпускник", Type.GetType("System.String"));
            DataColumn dataColumn7 = new DataColumn("Общий трудовой стаж работы в организациях, осуществляющих деятельность в профессиональной сфере, соответствующей профессиональной деятельности, к которой готовится выпускник", Type.GetType("System.String"));
            dataTable.Columns.Add(dataColumn1);
            dataTable.Columns.Add(dataColumn2);
            dataTable.Columns.Add(dataColumn3);
            dataTable.Columns.Add(dataColumn4);
            dataTable.Columns.Add(dataColumn5);
            dataTable.Columns.Add(dataColumn6);
            dataTable.Columns.Add(dataColumn7);

            //заполнение строк
            int id = 1;
            foreach (Practitioners p in DBObjects.Entities.Practitioners.ToList())
            {
                dataTable.Rows.Add(p.Code_practitioner,id, p.FIO_practitioner,p.TitleOrg_practitioner,p.Position_practitioner,p.PeriodOperation_practitioner,p.WorkExperience_practitioner);
                id++;
            }
            table = dataTable;
        }
        private void TableDoc()
        {
            DataTable dataDoc = new DataTable(); //создание таблицы
            DataColumn dataColumn2 = new DataColumn("№п/п", Type.GetType("System.Int32"));
            DataColumn dataColumn3 = new DataColumn("Фамилия, имя, отчество (при наличии) специалиста-практика", Type.GetType("System.String"));
            DataColumn dataColumn4 = new DataColumn("Наименование организации, осуществляющей деятельность в профессиональной сфере, в которой работает специалист-практик по основному месту работы или на условиях внешнего штатного совместительства", Type.GetType("System.String"));
            DataColumn dataColumn5 = new DataColumn("Занимаемая специалистом-практиком должность", Type.GetType("System.String"));
            DataColumn dataColumn6 = new DataColumn("Период работы в организации, осуществляющей деятельность в профессиональной сфере, соответствующей профессиональной деятельности, к которой готовится выпускник", Type.GetType("System.String"));
            DataColumn dataColumn7 = new DataColumn("Общий трудовой стаж работы в организациях, осуществляющих деятельность в профессиональной сфере, соответствующей профессиональной деятельности, к которой готовится выпускник", Type.GetType("System.String"));
            dataDoc.Columns.Add(dataColumn2);
            dataDoc.Columns.Add(dataColumn3);
            dataDoc.Columns.Add(dataColumn4);
            dataDoc.Columns.Add(dataColumn5);
            dataDoc.Columns.Add(dataColumn6);
            dataDoc.Columns.Add(dataColumn7);
            int id = 1;
            foreach (Practitioners p in DBObjects.Entities.Practitioners.ToList())
            {
                dataDoc.Rows.Add(id, p.FIO_practitioner, p.TitleOrg_practitioner, p.Position_practitioner, p.PeriodOperation_practitioner, p.WorkExperience_practitioner);
                id++;
            }
            tableDoc = dataDoc;
        }
        public static void AddTable(string fileName, string[,] data)
        {
            using (WordprocessingDocument document = WordprocessingDocument.Open(fileName, true))
            {

                var doc = document.MainDocumentPart.Document;

                Table table = new Table();

                TableProperties props = new TableProperties(
                    new TableBorders(
                    new TopBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new BottomBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new LeftBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new RightBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new InsideHorizontalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    },
                    new InsideVerticalBorder
                    {
                        Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12
                    }));

                table.AppendChild<TableProperties>(props);

                for (var i = 0; i <= data.GetUpperBound(0); i++)
                {
                    var tr = new TableRow();
                    for (var j = 0; j <= data.GetUpperBound(1); j++)
                    {
                        var tc = new TableCell();
                        tc.Append(new Paragraph(new Run(new Text(data[i, j]))));
                        tc.Append(new TableCellProperties(
                            new TableCellWidth { Type = TableWidthUnitValues.Auto }));

                        tr.Append(tc);
                    }
                    table.Append(tr);
                }
                doc.Body.Append(table);
                doc.Save();
                MessageBox.Show("Сохранение прошло успешно.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void документомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableDoc();
            OpenFileDialog ofd = new OpenFileDialog();

            int RowCount = tableDoc.Rows.Count;
            int ColumnCount = tableDoc.Columns.Count;
            string[,] d = new string[RowCount + 1, ColumnCount];
            int m = 0;
            foreach (DataColumn column in tableDoc.Columns)
            {
                d[0, m] = column.ColumnName;
                m++;
            }

            for (int c = 0; c <= ColumnCount - 1; c++)
            {
                for (int r = 0; r <= RowCount - 1; r++)
                {
                    d[r + 1, c] = tableDoc.Rows[r][c].ToString();
                }
            }
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string name = ofd.FileName;
                AddTable(name, d);
            }
        }
        private void таблицейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableDoc();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog1.SelectedPath;
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(tableDoc, "Сотрудники-практики");
                    wb.SaveAs(folderPath + "\\Сотрудники-практики.xlsx");
                    MessageBox.Show("Сохранение прошло успешно.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
