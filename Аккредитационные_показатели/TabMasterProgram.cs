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
    public partial class TabMasterProgram : Form
    {
        private DataTable table = new DataTable();
        private DataTable tableDoc = new DataTable();
        public TabMasterProgram()
        {
            InitializeComponent();
            Fill();
        }
        private void Fill()
        {
            Table();
            dgvMaster.DataSource = table;
            dgvMaster.Columns["id"].Visible = false;
            for (int i = 1; i < dgvMaster.ColumnCount; i++)
                dgvMaster.Columns[i].ReadOnly = true;
            dgvMaster.AllowUserToAddRows = false; //убрать отображение пустой последней строки
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
        private void btnSearchMaster_Click(object sender, EventArgs e)
        {
            if (txtSearchMaster.Text != "")
                for (int i = 0; i < dgvMaster.RowCount; i++)
                {
                    dgvMaster.Rows[i].Selected = false;
                    for (int j = 0; j < dgvMaster.ColumnCount; j++)
                        if (dgvMaster.Rows[i].Cells[j].Value != null)
                            if (dgvMaster.Rows[i].Cells[j].Value.ToString().Contains(txtSearchMaster.Text))
                            {
                                dgvMaster.Rows[i].Selected = true;
                                break;
                            }
                }
            else
                for (int i = 0; i < dgvMaster.RowCount; i++)
                    dgvMaster.Rows[i].Selected = false;
        }
        private void btnAddMaster_Click(object sender, EventArgs e)
        {
            Management_Master_degree_program management = new Management_Master_degree_program();
            AddMasterProgram add = new AddMasterProgram(management);
            add.ShowDialog();
            Fill();
        }
        private void dgvMaster_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvMaster[0, dgvMaster.CurrentRow.Index].Value.ToString());
            foreach (Management_Master_degree_program i in DBObjects.Entities.Management_Master_degree_program.ToList())
                if (i.Code_management == id)
                {
                    Management_Master_degree_program management = i;
                    AddMasterProgram add = new AddMasterProgram(management);
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
            DataColumn dataColumn3 = new DataColumn("Фамилия, имя, отчество (при наличии) педагогического (научно-педагогического) работника", Type.GetType("System.String"));
            DataColumn dataColumn4 = new DataColumn("Условия привлечения (по основному месту работы, на условиях внутреннего/ внешнего совместительства; на условиях гражданско-правового договора)", Type.GetType("System.String"));
            DataColumn dataColumn5 = new DataColumn("Ученая степень, (в том числе ученая степень, присвоенная за рубежом и признаваемая в Российской Федерации)", Type.GetType("System.String"));
            DataColumn dataColumn6 = new DataColumn("Тематика самостоятельного научно-исследовательского (творческого) проекта (участие в осуществлении таких проектов) по направлению подготовки, а также наименование и реквизиты документа, подтверждающие его закрепление", Type.GetType("System.String"));
            DataColumn dataColumn7 = new DataColumn("Публикации (название статьи, монографии и другое; наименование журнала/издания, год публикации) в: ведущих отечественных рецензируемых научных журналах и изданиях", Type.GetType("System.String"));
            DataColumn dataColumn8 = new DataColumn("Публикации (название статьи, монографии и другое; наименование журнала/издания, год публикации) в: зарубежных рецензируемых научных журналах и изданиях", Type.GetType("System.String"));
            DataColumn dataColumn9 = new DataColumn("Апробация результатов научно-исследовательской (творческой) деятельности на национальных и международных конференциях (название, статус конференций, материалы конференций, год выпуска)", Type.GetType("System.String"));
            dataTable.Columns.Add(dataColumn1);
            dataTable.Columns.Add(dataColumn2);
            dataTable.Columns.Add(dataColumn3);
            dataTable.Columns.Add(dataColumn4);
            dataTable.Columns.Add(dataColumn5);
            dataTable.Columns.Add(dataColumn6);
            dataTable.Columns.Add(dataColumn7);
            dataTable.Columns.Add(dataColumn8);
            dataTable.Columns.Add(dataColumn9);

            //заполнение строк
            int id = 1;
            foreach (Management_Master_degree_program m in DBObjects.Entities.Management_Master_degree_program.ToList())
            {
                dataTable.Rows.Add(m.Code_management,id, m.Teacher.FIO_teacher, m.Teacher.TitleSpecialty_teacher, m.Teacher.AcademicDegree_teacher, m.ResearchProject_management, m.DomesticPublications_management, m.ForeignPublications_management,m.Approbation_management);
                id++;
            }
            
            table = dataTable;
        }
        private void TableDoc()
        {
            DataTable dataDoc = new DataTable(); //создание таблицы
            DataColumn dataColumn2 = new DataColumn("№п/п", Type.GetType("System.Int32"));
            DataColumn dataColumn3 = new DataColumn("Фамилия, имя, отчество (при наличии) педагогического (научно-педагогического) работника", Type.GetType("System.String"));
            DataColumn dataColumn4 = new DataColumn("Условия привлечения (по основному месту работы, на условиях внутреннего/ внешнего совместительства; на условиях гражданско-правового договора)", Type.GetType("System.String"));
            DataColumn dataColumn5 = new DataColumn("Ученая степень, (в том числе ученая степень, присвоенная за рубежом и признаваемая в Российской Федерации)", Type.GetType("System.String"));
            DataColumn dataColumn6 = new DataColumn("Тематика самостоятельного научно-исследовательского (творческого) проекта (участие в осуществлении таких проектов) по направлению подготовки, а также наименование и реквизиты документа, подтверждающие его закрепление", Type.GetType("System.String"));
            DataColumn dataColumn7 = new DataColumn("Публикации (название статьи, монографии и другое; наименование журнала/издания, год публикации) в: ведущих отечественных рецензируемых научных журналах и изданиях", Type.GetType("System.String"));
            DataColumn dataColumn8 = new DataColumn("Публикации (название статьи, монографии и другое; наименование журнала/издания, год публикации) в: зарубежных рецензируемых научных журналах и изданиях", Type.GetType("System.String"));
            DataColumn dataColumn9 = new DataColumn("Апробация результатов научно-исследовательской (творческой) деятельности на национальных и международных конференциях (название, статус конференций, материалы конференций, год выпуска)", Type.GetType("System.String"));

            dataDoc.Columns.Add(dataColumn2);
            dataDoc.Columns.Add(dataColumn3);
            dataDoc.Columns.Add(dataColumn4);
            dataDoc.Columns.Add(dataColumn5);
            dataDoc.Columns.Add(dataColumn6);
            dataDoc.Columns.Add(dataColumn7);
            dataDoc.Columns.Add(dataColumn8);
            dataDoc.Columns.Add(dataColumn9);
            int id = 1;
            foreach (Management_Master_degree_program m in DBObjects.Entities.Management_Master_degree_program.ToList())
            {
                dataDoc.Rows.Add(id, m.Teacher.FIO_teacher, m.Teacher.TitleSpecialty_teacher, m.Teacher.AcademicDegree_teacher, m.ResearchProject_management, m.DomesticPublications_management, m.ForeignPublications_management, m.Approbation_management);
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
                    wb.Worksheets.Add(tableDoc, "Руководство магистратуры");
                    wb.SaveAs(folderPath + "\\Руководство магистратуры.xlsx");
                    MessageBox.Show("Сохранение прошло успешно.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
