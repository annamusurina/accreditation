using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Аккредитационные_показатели
{
    public partial class AddAcademicLoad : Form
    {
        private AcademicLoad academic { get; } //объект для работы с объемом учебной нагрузки
        private int code_dt = 0;
        public AddAcademicLoad(AcademicLoad academic, int code_dt)
        {
            InitializeComponent();
            this.academic = academic;
            this.code_dt = code_dt;
            Fill();
        }
        private void Fill() //заполнение формы данными        
        {
            string FIO = "";
            cbFIO.DataSource = DBObjects.Entities.Teacher.ToList();//заполнение combobox данными о преподавателях
            foreach (Teacher teacher in DBObjects.Entities.Teacher.ToList())//нахождение ФИО записанного в строку с выбранными элементом
                if (teacher.Code_teacher == academic.Code_teacher)
                {
                    FIO = teacher.ToString();
                    break;
                }
            for (int i = 0; i < cbFIO.Items.Count; i++) //нахождение нужного ФИО в combobox и выделение его как первого
                if (cbFIO.Items[i].ToString() == FIO)
                {
                    cbFIO.SelectedIndex = i;
                    break;
                }

            foreach (DisciplinesSemester ds in DBObjects.Entities.DisciplinesSemester.ToList()) //заполнение combobox данными о дисциплинах
                foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())
                    if (student.Code_dt == code_dt && ds.Code_adst == student.Code_adst)
                        cbTitleDisc.Items.Add(ds.ToString());
            if(cbTitleDisc.Items.Count != 0)
                cbTitleDisc.SelectedIndex = 0;
            string Disc = "";
            foreach (DisciplinesSemester disciplines in DBObjects.Entities.DisciplinesSemester.ToList())//нахождение наименования записанного в строку с выбранными элементом
                if (disciplines.Code_semester == academic.Code_semester)
                {
                    Disc = disciplines.ToString();
                    break;
                }
            for (int i = 0; i < cbTitleDisc.Items.Count; i++) //нахождение нужного наименования в combobox и выделение его как первого
                if (cbTitleDisc.Items[i].ToString() == Disc)
                {
                    cbTitleDisc.SelectedIndex = i;
                    break;
                }

            txtHour.Text = academic.NumberHours_academic;
            if(academic.BidShare_academic != null)
                txtDola.Text = academic.BidShare_academic;
        }
        private void вернутьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SaveDiscFIO()
        {
            foreach (Teacher teacher in DBObjects.Entities.Teacher.ToList())
                if (cbFIO.SelectedItem.ToString() == teacher.ToString())
                    academic.Code_teacher = teacher.Code_teacher;
            foreach (DisciplinesSemester disciplines in DBObjects.Entities.DisciplinesSemester.ToList())
                if (cbTitleDisc.SelectedItem.ToString() == disciplines.ToString())
                    academic.Code_semester = disciplines.Code_semester;
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Url = new Uri(String.Format("file:///{0}/Руководство_пользователя.docx", curDir));
        }
        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            academic.NumberHours_academic = txtHour.Text;
            //рассчет доли
            int hour = 0;
            if (txtHour.Text != "")
                hour = Convert.ToInt32(txtHour.Text);
            Teacher teacher1 = new Teacher();
            DisciplinesSemester discipline = new DisciplinesSemester();
            foreach (Teacher teacher in DBObjects.Entities.Teacher.ToList())
                if (cbFIO.SelectedItem.ToString() == teacher.ToString())
                    teacher1 = teacher;
            foreach (DisciplinesSemester disciplines in DBObjects.Entities.DisciplinesSemester.ToList())
                if (cbTitleDisc.SelectedItem.ToString() == disciplines.ToString())
                    discipline = disciplines;
            if(discipline.Semester == "1 семестр" || discipline.Semester == "2 семестр")
            {
                string str = discipline.Admission_student.AcademicYear_adst + "-" + (Convert.ToInt32(discipline.Admission_student.AcademicYear_adst)+1);
                foreach(LoadRate load in DBObjects.Entities.LoadRate.ToList())
                {
                    if (load.Code_position == teacher1.Code_position && str == load.AcademicYear_load)
                    {
                        double dola = (double)hour / (double)load.Number_hours;
                        txtDola.Text = Convert.ToString(Math.Round(dola,2));
                    }
                }
            }
            if (discipline.Semester == "3 семестр" || discipline.Semester == "4 семестр")
            {
                string str = (Convert.ToInt32(discipline.Admission_student.AcademicYear_adst)+1) + "-" + (Convert.ToInt32(discipline.Admission_student.AcademicYear_adst) + 2);
                foreach (LoadRate load in DBObjects.Entities.LoadRate.ToList())
                {
                    if (load.Code_position == teacher1.Code_position && str == load.AcademicYear_load)
                    {
                        double dola = (double)hour / (double)load.Number_hours;
                        txtDola.Text = Convert.ToString(Math.Round(dola, 2));
                    }
                }
            }
            if (discipline.Semester == "5 семестр" || discipline.Semester == "6 семестр")
            {
                string str = (Convert.ToInt32(discipline.Admission_student.AcademicYear_adst) + 2) + "-" + (Convert.ToInt32(discipline.Admission_student.AcademicYear_adst) + 3);
                foreach (LoadRate load in DBObjects.Entities.LoadRate.ToList())
                {
                    if (load.Code_position == teacher1.Code_position && str == load.AcademicYear_load)
                    {
                        double dola = (double)hour / (double)load.Number_hours;
                        txtDola.Text = Convert.ToString(Math.Round(dola, 2));
                    }
                }
            }
            if (discipline.Semester == "7 семестр" || discipline.Semester == "8 семестр")
            {
                string str = (Convert.ToInt32(discipline.Admission_student.AcademicYear_adst) + 3) + "-" + (Convert.ToInt32(discipline.Admission_student.AcademicYear_adst) + 4);
                foreach (LoadRate load in DBObjects.Entities.LoadRate.ToList())
                {
                    if (load.Code_position == teacher1.Code_position && str == load.AcademicYear_load)
                    {
                        double dola = (double)hour / (double)load.Number_hours;
                        txtDola.Text = Convert.ToString(Math.Round(dola, 2));
                    }
                }
            }
            if (discipline.Semester == "9 семестр" || discipline.Semester == "10 семестр")
            {
                string str = (Convert.ToInt32(discipline.Admission_student.AcademicYear_adst) + 4) + "-" + (Convert.ToInt32(discipline.Admission_student.AcademicYear_adst) + 5);
                foreach (LoadRate load in DBObjects.Entities.LoadRate.ToList())
                {
                    if (load.Code_position == teacher1.Code_position && str == load.AcademicYear_load)
                    {
                        double dola = (double)hour / (double)load.Number_hours;
                        txtDola.Text = Convert.ToString(Math.Round(dola, 2));
                    }
                }
            }
        }
        private void AddDola()
        {
            academic.BidShare_academic = txtDola.Text;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtHour.Text != "" && cbTitleDisc.SelectedIndex.ToString() != "" && cbFIO.SelectedIndex.ToString() != "")
            {
                SaveDiscFIO();
                AddDola();
                if (DBObjects.Entities.AcademicLoad.Where(p => p.Code_academic == academic.Code_academic).Count() == 0)
                    DBObjects.Entities.AcademicLoad.Add(academic);
                DBObjects.Entities.SaveChanges();
                Close();
            }
            else
                MessageBox.Show("Заполните пустые поля.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DBObjects.Entities.AcademicLoad.Where(p => p.Code_academic == academic.Code_academic).Count() > 0)
            {
                DBObjects.Entities.AcademicLoad.Remove(academic);
                DBObjects.Entities.SaveChanges();
            }
            Close();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            TabLoadRate loadrate = new TabLoadRate();
            loadrate.ShowDialog();
        }
        private void txtHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
                if (e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
        }
    }
}
