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
    public partial class TabAcademicLoad : Form
    {
        private int code_dt = 0;
        private DataTable table = new DataTable();
        private DataTable tableDoc = new DataTable();
        public TabAcademicLoad()
        {
            InitializeComponent();
            Fill();
        }
        private void Fill()
        {
            cbLevels.DataSource = DBObjects.Entities.EducationLevels.ToList();
        }
        private void Table() 
        { 
            DataTable data = new DataTable();
            DataColumn dataColumn1 = new DataColumn("id", Type.GetType("System.Int32"));
            DataColumn dataColumn2 = new DataColumn("№п/п", Type.GetType("System.Int32"));
            DataColumn dataColumn3 = new DataColumn("Наименование учебных предметов, курсов, дисциплин (модулей), практики, иных видов учебной деятельности, предусмотренных учебным планом образовательной программы", Type.GetType("System.String"));
            DataColumn dataColumn4 = new DataColumn("Фамилия, имя, отчество (при наличии) педагогического (научно-педагогического) работника, учавствующего в реализации образовательной программы", Type.GetType("System.String"));
            DataColumn dataColumn5 = new DataColumn("Условия привлечения (по основному месту работы, на условиях внутреннего/ внешнего совместительства; на условиях гражданско-правового договора)", Type.GetType("System.String"));
            DataColumn dataColumn6 = new DataColumn("Должность, ученая степень, ученое звание", Type.GetType("System.String"));
            DataColumn dataColumn7 = new DataColumn("Уровень образования, наименование специальности, направления подготовки, наименование присвоенной квалификации", Type.GetType("System.String"));
            DataColumn dataColumn8 = new DataColumn("Cведения о дополнительном профессиональном образовании", Type.GetType("System.String"));
            DataColumn dataColumn9 = new DataColumn("Объем учебной нагрузки: количество часов", Type.GetType("System.String"));
            DataColumn dataColumn10 = new DataColumn("Объем учебной нагрузки: доля ставки", Type.GetType("System.String"));
            DataColumn dataColumn11 = new DataColumn("Трудовой стаж работы: стаж работы в организациях, осуществляющих образовательную деятельность, на должностях педагогических (научно-педагогических) работников", Type.GetType("System.String"));
            DataColumn dataColumn12 = new DataColumn("Трудовой стаж работы: стаж работы в иных организациях, осуществляющих деятельность в профессиональной сфере, соответствующей профессиональной деятельности, к которой готовится выпускник", Type.GetType("System.String"));
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

            int nomer = 1;
            foreach (AcademicLoad a in DBObjects.Entities.AcademicLoad.ToList())
            {
                foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())
                {
                    if (student.Code_dt == code_dt && a.DisciplinesSemester.Code_adst == student.Code_adst)
                    {
                        data.Rows.Add(a.Code_academic, nomer, a.DisciplinesSemester.Disciplines.Title_discipline, a.Teacher.FIO_teacher, a.Teacher.TitleSpecialty_teacher, a.Teacher.Position.Title + ", " + a.Teacher.AcademicDegree_teacher + ", " + a.Teacher.AcademicTitle_teacher,
                        a.Teacher.EducationLevel_teacher + ", " + a.Teacher.TitleSpecialty_teacher + ", " + a.Teacher.AssignedQualification_teacher, a.Teacher.AdditionalProfEducation_teacher, a.NumberHours_academic, a.BidShare_academic, a.Teacher.WorkEducationalActivities_teacher, a.Teacher.WorkOtherOrg_teacher);
                        nomer++;
                    }
                }
            }
            table = data;
        }
        private void TableDoc()
        {
            DataTable dataDoc = new DataTable();
            DataColumn dataColumn2 = new DataColumn("№п/п", Type.GetType("System.Int32"));
            DataColumn dataColumn3 = new DataColumn("Наименование учебных предметов, курсов, дисциплин (модулей), практики, иных видов учебной деятельности, предусмотренных учебным планом образовательной программы", Type.GetType("System.String"));
            DataColumn dataColumn4 = new DataColumn("Фамилия, имя, отчество (при наличии) педагогического (научно-педагогического) работника, учавствующего в реализации образовательной программы", Type.GetType("System.String"));
            DataColumn dataColumn5 = new DataColumn("Условия привлечения (по основному месту работы, на условиях внутреннего/ внешнего совместительства; на условиях гражданско-правового договора)", Type.GetType("System.String"));
            DataColumn dataColumn6 = new DataColumn("Должность, ученая степень, ученое звание", Type.GetType("System.String"));
            DataColumn dataColumn7 = new DataColumn("Уровень образования, наименование специальности, направления подготовки, наименование присвоенной квалификации", Type.GetType("System.String"));
            DataColumn dataColumn8 = new DataColumn("Cведения о дополнительном профессиональном образовании", Type.GetType("System.String"));
            DataColumn dataColumn9 = new DataColumn("Объем учебной нагрузки: количество часов", Type.GetType("System.String"));
            DataColumn dataColumn10 = new DataColumn("Объем учебной нагрузки: доля ставки", Type.GetType("System.String"));
            DataColumn dataColumn11 = new DataColumn("Трудовой стаж работы: стаж работы в организациях, осуществляющих образовательную деятельность, на должностях педагогических (научно-педагогических) работников", Type.GetType("System.String"));
            DataColumn dataColumn12 = new DataColumn("Трудовой стаж работы: стаж работы в иных организациях, осуществляющих деятельность в профессиональной сфере, соответствующей профессиональной деятельности, к которой готовится выпускник", Type.GetType("System.String"));

            dataDoc.Columns.Add(dataColumn2);
            dataDoc.Columns.Add(dataColumn3);
            dataDoc.Columns.Add(dataColumn4);
            dataDoc.Columns.Add(dataColumn5);
            dataDoc.Columns.Add(dataColumn6);
            dataDoc.Columns.Add(dataColumn7);
            dataDoc.Columns.Add(dataColumn8);
            dataDoc.Columns.Add(dataColumn9);
            dataDoc.Columns.Add(dataColumn10);
            dataDoc.Columns.Add(dataColumn11);
            dataDoc.Columns.Add(dataColumn12);
            int nomer = 1;
            foreach (AcademicLoad a in DBObjects.Entities.AcademicLoad.ToList())
            {
                foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())
                {
                    if (student.Code_dt == code_dt && a.DisciplinesSemester.Code_adst == student.Code_adst)
                    {
                        dataDoc.Rows.Add(nomer, a.DisciplinesSemester.Disciplines.Title_discipline, a.Teacher.FIO_teacher, a.Teacher.TitleSpecialty_teacher, a.Teacher.Position.Title + ", " + a.Teacher.AcademicDegree_teacher + ", " + a.Teacher.AcademicTitle_teacher,
                        a.Teacher.EducationLevel_teacher + ", " + a.Teacher.TitleSpecialty_teacher + ", " + a.Teacher.AssignedQualification_teacher, a.Teacher.AdditionalProfEducation_teacher, a.NumberHours_academic, a.BidShare_academic, a.Teacher.WorkEducationalActivities_teacher, a.Teacher.WorkOtherOrg_teacher);
                        nomer++;
                    }
                }
            }
            tableDoc = dataDoc;
        }
        private void cbLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLevels.SelectedItem.ToString() != "")
            {
                int number = 0;
                foreach (EducationLevels lev in DBObjects.Entities.EducationLevels.ToList())
                    if (cbLevels.SelectedItem.ToString() == lev.Title_levels) //поиск уровня образования в выбранного в списке
                        number = lev.Code_levels; 
                cbDirection.Items.Clear();
                cbDirection.ResetText();
                foreach (DirectionTraining direction in DBObjects.Entities.DirectionTraining.ToList())
                    if (direction.Code_levels == number)
                        cbDirection.Items.Add(direction.Title_dt);//добавление направлений подготовки в список
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
                        Table(); //создание таблицы
                        dgvLoad.DataSource = table;
                        dgvLoad.Columns["id"].Visible = false;
                        for (int i = 1; i < dgvLoad.ColumnCount; i++)
                            dgvLoad.Columns[i].ReadOnly = true; 
                        dgvLoad.AllowUserToAddRows = false; //убрать отображение пустой последней строки
                    }
            }
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
        private void дисциплиныToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void btnSearchLoad_Click(object sender, EventArgs e)
        {
            if (txtSearchLoad.Text != "")
                for (int i = 0; i < dgvLoad.RowCount; i++)
                {
                    dgvLoad.Rows[i].Selected = false;
                    for (int j = 0; j < dgvLoad.ColumnCount; j++)
                        if (dgvLoad.Rows[i].Cells[j].Value != null)
                            if (dgvLoad.Rows[i].Cells[j].Value.ToString().Contains(txtSearchLoad.Text))
                            {
                                dgvLoad.Rows[i].Selected = true;
                                break;
                            }
                }
            else
                for (int i = 0; i < dgvLoad.RowCount; i++)
                    dgvLoad.Rows[i].Selected = false;
        }
        private void btnAddLoad_Click(object sender, EventArgs e)
        {
            AcademicLoad academic = new AcademicLoad();
            AddAcademicLoad add = new AddAcademicLoad(academic,code_dt);
            add.ShowDialog();
            Table();

            dgvLoad.DataSource = table;
            dgvLoad.Columns["id"].Visible = false;
            for (int i = 1; i < dgvLoad.ColumnCount; i++)
                dgvLoad.Columns[i].ReadOnly = true;
            dgvLoad.AllowUserToAddRows = false; //убрать отображение пустой последней строки
        }
        private void dgvLoad_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvLoad[0, dgvLoad.CurrentRow.Index].Value.ToString());
            foreach (AcademicLoad i in DBObjects.Entities.AcademicLoad.ToList())
                if (i.Code_academic == id)
                {
                    AcademicLoad academic = i;
                    AddAcademicLoad add = new AddAcademicLoad(academic, code_dt);
                    add.ShowDialog();
                    Table();

                    dgvLoad.DataSource = table;
                    dgvLoad.Columns["id"].Visible = false;
                    for (int j = 1; j < dgvLoad.ColumnCount; j++)
                        dgvLoad.Columns[j].ReadOnly = true;
                    dgvLoad.AllowUserToAddRows = false; //убрать отображение пустой последней строки
                } 
        }
        private void таблицейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableDoc();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) //выбор папки для сохранения таблицы Excel
            {
                string folderPath = folderBrowserDialog1.SelectedPath;
                if (!Directory.Exists(folderPath)) //проверка существует ли файл
                {
                    Directory.CreateDirectory(folderPath); //создается новый
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(tableDoc, "AcademicLoad"); //добавление таблицы
                    wb.SaveAs(folderPath + "\\AcademicLoad.xlsx"); //сохранение документа
                    MessageBox.Show("Сохранение прошло успешно.", "Сохранение", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }        
        public static void AddTable(string fileName, string[,] data)
        {   //открытие документа
            using (WordprocessingDocument document = WordprocessingDocument.Open(fileName, true))
            {
                var doc = document.MainDocumentPart.Document;
                Table table = new Table();
                //создание таблицы и указания сведений о ее границах
                TableProperties props = new TableProperties( 
                    new TableBorders(  
                    new TopBorder
                    {   Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12 },
                    new BottomBorder
                    {   Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12 },
                    new LeftBorder
                    {   Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12 },
                    new RightBorder
                    {   Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12 },
                    new InsideHorizontalBorder
                    {   Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12 },
                    new InsideVerticalBorder
                    {   Val = new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 12 }));
                //добавление таблицы в конец документа
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
                MessageBox.Show("Сохранение прошло успешно.", "Сохранение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void документомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableDoc(); //создание таблицы 
            OpenFileDialog ofd = new OpenFileDialog();
            
            int RowCount = tableDoc.Rows.Count;
            int ColumnCount = tableDoc.Columns.Count;
            string[,] d = new string[RowCount+1, ColumnCount];
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
                    d[r+1, c] = tableDoc.Rows[r][c].ToString();
                }
            }
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string name = ofd.FileName;                
                AddTable(name, d);
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
