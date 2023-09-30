using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Аккредитационные_показатели
{
    public partial class TabDisciplineSemeater : Form
    {
        private int code_dt = 0;
        private DataTable table = new DataTable();
        public TabDisciplineSemeater()
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
            DataColumn dataColumn1 = new DataColumn("id", Type.GetType("System.Int32"));
            DataColumn dataColumn2 = new DataColumn("Набор студентов", Type.GetType("System.String"));
            DataColumn dataColumn3 = new DataColumn("Наименование дисциплины", Type.GetType("System.String"));
            DataColumn dataColumn4 = new DataColumn("Семестр", Type.GetType("System.String"));
            DataColumn dataColumn5 = new DataColumn("Количество часов лекций", Type.GetType("System.String"));
            DataColumn dataColumn6 = new DataColumn("Количество часов практик", Type.GetType("System.String"));
            DataColumn dataColumn7 = new DataColumn("Количество часов лабораторных работ", Type.GetType("System.String"));
            DataColumn dataColumn8 = new DataColumn("Количество часов зачетов", Type.GetType("System.String"));
            DataColumn dataColumn9 = new DataColumn("Количество часов экзаменов", Type.GetType("System.String"));
            DataColumn dataColumn10 = new DataColumn("Количество часов консультаций", Type.GetType("System.String"));
            DataColumn dataColumn11 = new DataColumn("Количество часов руководства КР/ВКР/КП", Type.GetType("System.String"));
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

            foreach (DisciplinesSemester d in DBObjects.Entities.DisciplinesSemester.ToList())
                foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())
                {
                    if (student.Code_dt == code_dt && d.Code_adst == student.Code_adst)
                        data.Rows.Add(d.Code_semester, student.AcademicYear_adst, d.Disciplines.Title_discipline, d.Semester, d.HoursLectures_discipline, d.HoursPractice_discipline, d.HoursLaboratory_discipline,d.HoursCredits_discipline,
                        d.HoursExam_discipline, d.HoursConsultation_discipline, d.HoursCoursework_discipline);
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
        private void наборToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            TabAdmission_student student = new TabAdmission_student();
            student.ShowDialog();
            Close();
        }
        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Url = new Uri(String.Format("file:///{0}/Руководство_пользователя.docx", curDir));
        }
        private void btnSearchTeacher_Click(object sender, EventArgs e)
        {
            if (txtSearchDisc.Text != "")
                for (int i = 0; i < dgvDisc.RowCount; i++)
                {
                    dgvDisc.Rows[i].Selected = false;
                    for (int j = 0; j < dgvDisc.ColumnCount; j++)
                        if (dgvDisc.Rows[i].Cells[j].Value != null)
                            if (dgvDisc.Rows[i].Cells[j].Value.ToString().Contains(txtSearchDisc.Text))
                            {
                                dgvDisc.Rows[i].Selected = true;
                                break;
                            }
                }
            else
                for (int i = 0; i < dgvDisc.RowCount; i++)
                    dgvDisc.Rows[i].Selected = false;
        }
        private void btnAddDisc_Click(object sender, EventArgs e)
        {
            DisciplinesSemester disc = new DisciplinesSemester();
            AddDiscipline add = new AddDiscipline(disc, code_dt);
            add.ShowDialog();
            Table(code_dt);

            dgvDisc.DataSource = table;
            dgvDisc.Columns["id"].Visible = false;
            for (int j = 1; j < dgvDisc.ColumnCount; j++)
                dgvDisc.Columns[j].ReadOnly = true;
            dgvDisc.AllowUserToAddRows = false; //убрать отображение пустой последней строки
        }
        private void dgvDisc_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvDisc[0, dgvDisc.CurrentRow.Index].Value.ToString());
            foreach (DisciplinesSemester i in DBObjects.Entities.DisciplinesSemester.ToList())
                if (i.Code_semester == id)
                {
                    DisciplinesSemester disc = i;
                    AddDiscipline add = new AddDiscipline(disc, code_dt);
                    add.ShowDialog();
                    Table(code_dt);

                    dgvDisc.DataSource = table;
                    dgvDisc.Columns["id"].Visible = false;
                    for (int j = 1; j < dgvDisc.ColumnCount; j++)
                        dgvDisc.Columns[j].ReadOnly = true;
                    dgvDisc.AllowUserToAddRows = false; //убрать отображение пустой последней строки
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

                        dgvDisc.DataSource = table;
                        dgvDisc.Columns["id"].Visible = false;
                        for (int i = 1; i < dgvDisc.ColumnCount; i++)
                            dgvDisc.Columns[i].ReadOnly = true;
                        dgvDisc.AllowUserToAddRows = false; //убрать отображение пустой последней строки
                    }
            }
        }
        private void btnDate_Click(object sender, EventArgs e)
        {
            Change_Data change = new Change_Data();
            change.ShowDialog();
            Fill();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string name = "";
            int nomer = 0;
            if (cbLevels.SelectedIndex.ToString() != "")
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fn = openFileDialog.FileName;
                    XDocument xdoc = XDocument.Load(fn);
                    foreach (XElement myConfig in xdoc.Element("Документ").Element("{urn:schemas-microsoft-com:xml-diffgram-v1}diffgram").Element(@"{http://tempuri.org/dsMMISDB.xsd}dsMMISDB").Elements())
                    {
                        if (myConfig.Name.ToString() == @"{http://tempuri.org/dsMMISDB.xsd}ПланыСтроки")
                        {
                            string practicaHours = null, Lectures = null, LaboratoryWorks = null, Semestr = null;
                            XAttribute Discipline = myConfig.Attribute("Дисциплина");
                            XAttribute Code = myConfig.Attribute("Код");
                            XAttribute RecruitmentYear = null, Profile = null, Shifre = null;
                            foreach (XElement myConfig4 in xdoc.Element("Документ").Element("{urn:schemas-microsoft-com:xml-diffgram-v1}diffgram").Element(@"{http://tempuri.org/dsMMISDB.xsd}dsMMISDB").Element(@"{http://tempuri.org/dsMMISDB.xsd}ООП").Elements())
                            {
                                Shifre = myConfig4.Attribute("Шифр"); //код направления подготовки
                                Profile = myConfig4.Attribute("Название");//название направления подготовки
                                foreach (XElement myConfig2 in xdoc.Element("Документ")
                                    .Element("{urn:schemas-microsoft-com:xml-diffgram-v1}diffgram")
                                    .Element(@"{http://tempuri.org/dsMMISDB.xsd}dsMMISDB").Elements())
                                {
                                    if (myConfig2.Name.ToString() == @"{http://tempuri.org/dsMMISDB.xsd}Планы")
                                    {
                                        RecruitmentYear = myConfig2.Attribute("ГодНачалаПодготовки");
                                    }
                                    if (myConfig2.Name.ToString() == @"{http://tempuri.org/dsMMISDB.xsd}ПланыНовыеЧасы")
                                    {
                                        XAttribute CodeObject = myConfig2.Attribute("КодОбъекта");
                                        XAttribute Course = myConfig2.Attribute("Курс");
                                        XAttribute Semester = myConfig2.Attribute("Семестр");
                                        if (CodeObject.Value.ToString() == Code.Value)
                                        {
                                            XAttribute CodeViewJob = myConfig2.Attribute("КодВидаРаботы");
                                            XAttribute Count = myConfig2.Attribute("Количество");
                                            foreach (XElement myConfig3 in xdoc.Element("Документ")
                                                .Element("{urn:schemas-microsoft-com:xml-diffgram-v1}diffgram")
                                                .Element(@"{http://tempuri.org/dsMMISDB.xsd}dsMMISDB").Elements())
                                            {
                                                if (myConfig3.Name.ToString() == @"{http://tempuri.org/dsMMISDB.xsd}СправочникВидыРабот")
                                                {
                                                    XAttribute nameAttribute9 = myConfig3.Attribute("Код");

                                                    if (nameAttribute9.Value.ToString() == CodeViewJob.Value)
                                                    {
                                                        XAttribute ViewJob = myConfig3.Attribute("Название");
                                                        if (Semester.Value == "1")
                                                        {
                                                            if (Course.Value == "1") Semestr = "1 семестр";
                                                            if (Course.Value == "2") Semestr = "3 семестр";
                                                            if (Course.Value == "3") Semestr = "5 семестр";
                                                            if (Course.Value == "4") Semestr = "7 семестр";
                                                            if (Course.Value == "5") Semestr = "9 семестр";
                                                        }
                                                        if (Semester.Value == "2")
                                                        {
                                                            if (Course.Value == "1") Semestr = "2 семестр";
                                                            if (Course.Value == "2") Semestr = "4 семестр";
                                                            if (Course.Value == "3") Semestr = "6 семестр";
                                                            if (Course.Value == "4") Semestr = "8 семестр";
                                                            if (Course.Value == "5") Semestr = "10 семестр";
                                                        }
                                                        if (ViewJob.Value == "Практические занятия")
                                                            practicaHours = Count.Value;
                                                        else
                                                        if (ViewJob.Value == "Лекционные занятия")
                                                            Lectures = Count.Value;
                                                        else
                                                        if (ViewJob.Value == "Лабораторные занятия")
                                                            LaboratoryWorks = Count.Value;
                                                    }

                                                }

                                            }
                                        }
                                    }

                                }
                            }

                            DisciplinesSemester disciplinesS = new DisciplinesSemester();
                            int count = 0;
                            foreach (Disciplines disciplines in DBObjects.Entities.Disciplines.ToList())
                                if (disciplines.Title_discipline == Discipline.Value)
                                {
                                    disciplinesS.Code_discipline = disciplines.Code_discipline;
                                    count++;
                                }
                            if (count == 0)
                            {
                                Disciplines disciplines = new Disciplines();
                                disciplines.Title_discipline = Discipline.Value;
                                DBObjects.Entities.Disciplines.Add(disciplines);
                                DBObjects.Entities.SaveChanges();
                                disciplinesS.Code_discipline = disciplines.Code_discipline;
                            }
                            count = 0;
                            int numberLev = 0;
                            foreach (EducationLevels lev in DBObjects.Entities.EducationLevels.ToList())
                                if (cbLevels.SelectedItem.ToString() == lev.Title_levels)
                                    numberLev = lev.Code_levels;
                            int numberDt = 0;
                            foreach (DirectionTraining direction in DBObjects.Entities.DirectionTraining.ToList())
                                if (direction.Code == Shifre.Value && direction.Title_dt == Profile.Value && direction.Code_levels == numberLev)
                                {
                                    numberDt = direction.Code_dt;
                                    name = direction.Title_dt;
                                }

                            if (numberDt == 0)
                            {
                                DirectionTraining direction = new DirectionTraining();
                                direction.Code_levels = numberLev;
                                direction.Code = Shifre.Value;
                                direction.Title_dt = Profile.Value;
                                DBObjects.Entities.DirectionTraining.Add(direction);
                                DBObjects.Entities.SaveChanges();
                                numberDt = direction.Code_dt;
                                name = direction.Title_dt;
                            }
                            nomer = numberDt;
                            foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())
                                if (student.AcademicYear_adst == RecruitmentYear.Value && student.Code_dt == numberDt)
                                {
                                    disciplinesS.Code_adst = student.Code_adst;
                                    count++;
                                }                            
                            if (count == 0)
                            {
                                Admission_student student = new Admission_student();
                                student.Code_dt = numberDt;
                                student.AcademicYear_adst = RecruitmentYear.Value;
                                DBObjects.Entities.Admission_student.Add(student);
                                DBObjects.Entities.SaveChanges();
                                disciplinesS.Code_adst = student.Code_adst;
                            }
                            disciplinesS.Semester = Semestr;
                            disciplinesS.HoursLectures_discipline = Lectures;
                            disciplinesS.HoursPractice_discipline = practicaHours;
                            disciplinesS.HoursLaboratory_discipline = LaboratoryWorks;
                            if (Lectures != null || practicaHours != null || LaboratoryWorks != null)
                            {
                                int counter = 0;
                                foreach (DisciplinesSemester disciplinesSemester in DBObjects.Entities.DisciplinesSemester.ToList())
                                    if (disciplinesSemester.Code_discipline == disciplinesS.Code_discipline && disciplinesSemester.Code_adst == disciplinesS.Code_adst && disciplinesSemester.HoursLaboratory_discipline == disciplinesS.HoursLaboratory_discipline
                                        && disciplinesSemester.HoursLectures_discipline == disciplinesS.HoursLectures_discipline && disciplinesSemester.HoursPractice_discipline == disciplinesS.HoursPractice_discipline && disciplinesSemester.HoursExam_discipline == null
                                        && disciplinesSemester.HoursCredits_discipline == null && disciplinesSemester.HoursCoursework_discipline == null && disciplinesSemester.HoursConsultation_discipline == null && disciplinesSemester.Semester == disciplinesS.Semester)
                                        counter++;
                                if (counter == 0)
                                {
                                    DBObjects.Entities.DisciplinesSemester.Add(disciplinesS);
                                    DBObjects.Entities.SaveChanges();
                                }
                            }
                        }

                    }
                }
            int number = 0;
            foreach (EducationLevels lev in DBObjects.Entities.EducationLevels.ToList())
                if (cbLevels.SelectedItem.ToString() == lev.Title_levels)
                    number = lev.Code_levels;
            cbDirection.Items.Clear();
            cbDirection.ResetText();
            foreach (DirectionTraining direction in DBObjects.Entities.DirectionTraining.ToList())
                if (direction.Code_levels == number)
                    cbDirection.Items.Add(direction.Title_dt);
            for (int i = 0; i < cbDirection.Items.Count; i++)
                if (cbDirection.Items[i].ToString() == name)
                {
                    cbDirection.SelectedIndex = i;
                    break;
                }
            Table(nomer);
            dgvDisc.DataSource = table;
            dgvDisc.Columns["id"].Visible = false;
            for (int i = 1; i < dgvDisc.ColumnCount; i++)
                dgvDisc.Columns[i].ReadOnly = true;
            dgvDisc.AllowUserToAddRows = false; //убрать отображение пустой последней строки
        }
    }
}
