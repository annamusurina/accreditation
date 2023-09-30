using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Аккредитационные_показатели
{
    public partial class AddDiscipline : Form
    {
        private int code_dt = 0;
        DisciplinesSemester disciplinesS { get; } //объект для работы с дисциплинами
        public AddDiscipline(DisciplinesSemester disciplinesS, int code_dt)
        {
            InitializeComponent();
            this.disciplinesS = disciplinesS;
            this.code_dt = code_dt;
            Fill();
        }
        private void Fill() //заполнение формы данными        
        {  
            foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())
                if (student.Code_dt == code_dt)
                    cbYear.Items.Add(student.AcademicYear_adst);
            if(cbYear.Items.Count != 0)
                cbYear.SelectedIndex = 0;
            string year = "";
            foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())//нахождение учебного года записанного в строку с выбранными элементом
                if (student.Code_adst == disciplinesS.Code_adst)
                {
                    year = student.ToString();
                    break;
                }
            for (int i = 0; i < cbYear.Items.Count; i++) //нахождение нужного наименования в combobox и выделение его как первого
                if (cbYear.Items[i].ToString() == year)
                {
                    cbYear.SelectedIndex = i;
                    break;
                }

            foreach (Disciplines disciplines in DBObjects.Entities.Disciplines.ToList())
                cbTitle.Items.Add(disciplines.Title_discipline);
            if (cbTitle.Items.Count != 0)
                cbTitle.SelectedIndex = 0;
            string title = "";
            foreach (Disciplines disciplines in DBObjects.Entities.Disciplines.ToList())
                if (disciplines.Code_discipline == disciplinesS.Code_discipline)
                {
                    title = disciplines.ToString();
                    break;
                }
            for (int i = 0; i < cbTitle.Items.Count; i++) 
                if (cbTitle.Items[i].ToString() == title)
                {
                    cbTitle.SelectedIndex = i;
                    break;
                }

            txtSemester.Text = disciplinesS.Semester;
            txtLecture.Text = disciplinesS.HoursLectures_discipline;
            txtPractice.Text = disciplinesS.HoursPractice_discipline;
            txtLab.Text = disciplinesS.HoursLaboratory_discipline;
            txtCredits.Text = disciplinesS.HoursCredits_discipline;
            txtConsultation.Text = disciplinesS.HoursConsultation_discipline;
            txtExam.Text = disciplinesS.HoursExam_discipline;
            txtCoursework.Text = disciplinesS.HoursCoursework_discipline;
        }
        private void SaveYearDis()
        {
            foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())
                if (cbYear.SelectedItem.ToString() == student.AcademicYear_adst && student.Code_dt == code_dt)
                    disciplinesS.Code_adst = student.Code_adst;
            foreach (Disciplines disciplines in DBObjects.Entities.Disciplines.ToList())
                if (cbTitle.SelectedItem.ToString() == disciplines.Title_discipline)
                    disciplinesS.Code_discipline = disciplines.Code_discipline;
        }
        private void txtSemester_TextChanged(object sender, EventArgs e)
        {
            disciplinesS.Semester = txtSemester.Text;
        }
        private void txtLecture_TextChanged(object sender, EventArgs e)
        {
            disciplinesS.HoursLectures_discipline = txtLecture.Text;
        }
        private void txtPractice_TextChanged(object sender, EventArgs e)
        {
            disciplinesS.HoursPractice_discipline = txtPractice.Text;
        }
        private void txtLab_TextChanged(object sender, EventArgs e)
        {
            disciplinesS.HoursLaboratory_discipline = txtLab.Text;
        }
        private void txtCredits_TextChanged(object sender, EventArgs e)
        {
            disciplinesS.HoursCredits_discipline = txtCredits.Text;            
        }
        private void txtConsultation_TextChanged(object sender, EventArgs e)
        {
            disciplinesS.HoursConsultation_discipline = txtConsultation.Text;           
        }
        private void txtExam_TextChanged(object sender, EventArgs e)
        {
            disciplinesS.HoursExam_discipline = txtExam.Text;            
        }
        private void txtCoursework_TextChanged(object sender, EventArgs e)
        {
            disciplinesS.HoursCoursework_discipline = txtCoursework.Text;
        }
        private void Delete()
        {
            foreach (AcademicLoad academic in DBObjects.Entities.AcademicLoad.ToList())
                if (disciplinesS.Code_semester == academic.Code_semester)
                    DBObjects.Entities.AcademicLoad.Remove(academic);
            DBObjects.Entities.SaveChanges();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSemester.Text != "" && cbYear.SelectedIndex.ToString() != "" && cbTitle.SelectedIndex.ToString() != "")
            {
                SaveYearDis();
                if (DBObjects.Entities.DisciplinesSemester.Where(p => p.Code_semester == disciplinesS.Code_semester).Count() == 0)
                {
                    DBObjects.Entities.DisciplinesSemester.Add(disciplinesS);
                }
                DBObjects.Entities.SaveChanges();
                Close();
            }
            else
                MessageBox.Show("Заполните поля с наименованием, семестром и/или учебным годом.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DBObjects.Entities.DisciplinesSemester.Where(p => p.Code_semester == disciplinesS.Code_semester).Count() > 0)
            {
                Delete();
                DBObjects.Entities.DisciplinesSemester.Remove(disciplinesS);
                DBObjects.Entities.SaveChanges();
            }
            Close();
        }
        private void вернутьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Url = new Uri(String.Format("file:///{0}/Руководство_пользователя.docx", curDir));
        }
        private void btnEnterData_Click(object sender, EventArgs e)
        {
            if (cbYear.Items != null && cbTitle.SelectedIndex.ToString() != "")
            {
                string Semestr1 = null;
                string Discipline1 = cbTitle.SelectedItem.ToString();
                string Year = "";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fn = openFileDialog.FileName;
                    XDocument xdoc = XDocument.Load(fn);
                    foreach (XElement myConfig in xdoc.Element("Документ").Element("{urn:schemas-microsoft-com:xml-diffgram-v1}diffgram").Element(@"{http://tempuri.org/dsMMISDB.xsd}dsMMISDB").Elements())
                    {
                        if (myConfig.Name.ToString() == @"{http://tempuri.org/dsMMISDB.xsd}ПланыСтроки")
                        {
                            string PracticaHours = null, Lectures = null, LaboratoryWorks = null;
                            XAttribute Discipline = myConfig.Attribute("Дисциплина");
                            XAttribute Code = null;
                            if (Discipline.Value == Discipline1)
                            {
                                Code = myConfig.Attribute("Код");
                                foreach (XElement myConfig4 in xdoc.Element("Документ").Element("{urn:schemas-microsoft-com:xml-diffgram-v1}diffgram").Element(@"{http://tempuri.org/dsMMISDB.xsd}dsMMISDB").Element(@"{http://tempuri.org/dsMMISDB.xsd}ООП").Elements())
                                {
                                    foreach (XElement myConfig2 in xdoc.Element("Документ").Element("{urn:schemas-microsoft-com:xml-diffgram-v1}diffgram").Element(@"{http://tempuri.org/dsMMISDB.xsd}dsMMISDB").Elements())
                                    {
                                        if (myConfig2.Name.ToString() == @"{http://tempuri.org/dsMMISDB.xsd}Планы")
                                        {
                                            Year = myConfig2.Attribute("ГодНачалаПодготовки").Value;
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
                                                foreach (XElement myConfig3 in xdoc.Element("Документ").Element("{urn:schemas-microsoft-com:xml-diffgram-v1}diffgram").Element(@"{http://tempuri.org/dsMMISDB.xsd}dsMMISDB").Elements())
                                                {
                                                    if (myConfig3.Name.ToString() == @"{http://tempuri.org/dsMMISDB.xsd}СправочникВидыРабот")
                                                    {
                                                        XAttribute nameAttribute9 = myConfig3.Attribute("Код");
                                                        if (nameAttribute9.Value.ToString() == CodeViewJob.Value)
                                                        {
                                                            XAttribute ViewJob = myConfig3.Attribute("Название");
                                                            if (Semester.Value == "1")
                                                            {
                                                                if(Course.Value == "1")
                                                                    Semestr1 = "1 семестр";
                                                                if (Course.Value == "2")
                                                                    Semestr1 = "3 семестр";
                                                                if (Course.Value == "3")
                                                                    Semestr1 = "5 семестр";
                                                                if (Course.Value == "4")
                                                                    Semestr1 = "7 семестр";
                                                                if (Course.Value == "5")
                                                                    Semestr1 = "9 семестр";
                                                            }
                                                            if (Semester.Value == "2")
                                                            {
                                                                if (Course.Value == "1")
                                                                    Semestr1 = "2 семестр";
                                                                if (Course.Value == "2")
                                                                    Semestr1 = "4 семестр";
                                                                if (Course.Value == "3")
                                                                    Semestr1 = "6 семестр";
                                                                if (Course.Value == "4")
                                                                    Semestr1 = "8 семестр";
                                                                if (Course.Value == "5")
                                                                    Semestr1 = "10 семестр";
                                                            }
                                                            if (ViewJob.Value == "Практические занятия")
                                                            {
                                                                PracticaHours = Count.Value;
                                                            }
                                                            else
                                                            if (ViewJob.Value == "Лекционные занятия")
                                                            {
                                                                Lectures = Count.Value;
                                                            }
                                                            else
                                                            if (ViewJob.Value == "Лабораторные занятия")
                                                            {
                                                                LaboratoryWorks = Count.Value;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        txtSemester.Text = Semestr1;
                                        txtLecture.Text = Lectures;
                                        txtPractice.Text = PracticaHours;
                                        txtLab.Text = LaboratoryWorks;
                                        

                                    }
                                }
                            }                          
                        }
                    }
                    for (int i = 0; i < cbYear.Items.Count; i++)
                        if (cbYear.Items[i].ToString() == Year)
                        {
                            cbYear.SelectedIndex = i;
                            break;
                        }
                        else
                        {
                            cbYear.SelectedIndex = -1;
                        }
                    if (cbYear.SelectedIndex == -1)
                    {
                        MessageBox.Show("Набор студентов " + Year + " не был найден", "Импорт данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Заполните поля с наименованием и набором студентов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void btnDis_Click(object sender, EventArgs e)
        {
            TabDiscipline discipline = new TabDiscipline();
            discipline.ShowDialog();
            cbTitle.Items.Clear();
            cbTitle.ResetText();
            foreach (Disciplines disciplines in DBObjects.Entities.Disciplines.ToList())
                cbTitle.Items.Add(disciplines.Title_discipline);
            if (cbTitle.Items.Count != 0)
                cbTitle.SelectedIndex = 0;
            string title = "";
            foreach (Disciplines disciplines in DBObjects.Entities.Disciplines.ToList())
                if (disciplines.Code_discipline == disciplinesS.Code_discipline)
                {
                    title = disciplines.ToString();
                    break;
                }
            for (int i = 0; i < cbTitle.Items.Count; i++)
                if (cbTitle.Items[i].ToString() == title)
                {
                    cbTitle.SelectedIndex = i;
                    break;
                }
        }
    }
}
