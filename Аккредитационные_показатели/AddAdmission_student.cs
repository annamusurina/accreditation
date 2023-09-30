using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Аккредитационные_показатели
{
    public partial class AddAdmission_student : Form
    {
        private int code_dt = 0;
        private Admission_student student { get; } //объект для работы с набором студентов
        public AddAdmission_student(Admission_student student,int code_dt)
        {
            InitializeComponent();
            this.student = student;
            this.code_dt = code_dt;
            Fill();
        }
        private void Fill() //заполнение формы данными        
        {
            foreach (DirectionTraining dt in DBObjects.Entities.DirectionTraining.ToList())
                if (dt.Code_dt == code_dt)
                {
                    txtDT.Text = dt.Title_dt;
                    break;
                }
            txtYear.Text = student.AcademicYear_adst;
        }
        private void вернутьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            student.AcademicYear_adst = txtYear.Text;
        }
        private void Delete()
        {
            foreach (AcademicLoad academic in DBObjects.Entities.AcademicLoad.ToList())
                foreach (DisciplinesSemester disciplines in DBObjects.Entities.DisciplinesSemester.ToList())              
                        if (student.Code_adst == disciplines.Code_adst && disciplines.Code_discipline == academic.Code_semester)
                                DBObjects.Entities.AcademicLoad.Remove(academic);
            foreach (DisciplinesSemester disciplines in DBObjects.Entities.DisciplinesSemester.ToList())
                    if (student.Code_adst == disciplines.Code_adst)
                        DBObjects.Entities.DisciplinesSemester.Remove(disciplines);
            DBObjects.Entities.SaveChanges();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtYear.Text != "")
            {
                student.Code_dt = code_dt;
                if (DBObjects.Entities.Admission_student.Where(p => p.Code_adst == student.Code_adst).Count() == 0)
                {
                    DBObjects.Entities.Admission_student.Add(student);
                }
                DBObjects.Entities.SaveChanges();
                Close();
            }
            else
                MessageBox.Show("Заполните пустые поля.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DBObjects.Entities.Admission_student.Where(p => p.Code_adst == student.Code_adst).Count() > 0)
            {
                Delete();
                DBObjects.Entities.Admission_student.Remove(student);
                DBObjects.Entities.SaveChanges();
            }
            Close();
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Url = new Uri(String.Format("file:///{0}/Руководство_пользователя.docx", curDir));
        }
        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
