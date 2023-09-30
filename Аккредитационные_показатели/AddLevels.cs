using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Аккредитационные_показатели
{
    public partial class AddLevels : Form
    {
        private EducationLevels levels { get; } //объект для работы с уровнем образования
        public AddLevels(EducationLevels levels)
        {
            InitializeComponent();
            this.levels = levels;
            Fill();
        }
        private void Fill() //заполнение формы данными        
        {
            txtTitle.Text = levels.Title_levels;
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
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            levels.Title_levels = txtTitle.Text;
        }
        private void Delete()
        {
            foreach (AcademicLoad academic in DBObjects.Entities.AcademicLoad.ToList())
                foreach (DisciplinesSemester disciplines in DBObjects.Entities.DisciplinesSemester.ToList())
                    foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())
                        foreach (DirectionTraining direction in DBObjects.Entities.DirectionTraining.ToList())
                            if (levels.Code_levels == direction.Code_levels && direction.Code_dt == student.Code_dt && student.Code_adst == disciplines.Code_adst && disciplines.Code_semester == academic.Code_semester)
                                DBObjects.Entities.AcademicLoad.Remove(academic);
            foreach (DisciplinesSemester disciplines in DBObjects.Entities.DisciplinesSemester.ToList())
                foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())
                    foreach (DirectionTraining direction in DBObjects.Entities.DirectionTraining.ToList())
                        if (levels.Code_levels == direction.Code_levels && direction.Code_dt == student.Code_dt && student.Code_adst == disciplines.Code_adst)
                            DBObjects.Entities.DisciplinesSemester.Remove(disciplines);
            foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())
                    foreach (DirectionTraining direction in DBObjects.Entities.DirectionTraining.ToList())
                        if (levels.Code_levels == direction.Code_levels && direction.Code_dt == student.Code_dt)
                            DBObjects.Entities.Admission_student.Remove(student);
            foreach (DirectionTraining direction in DBObjects.Entities.DirectionTraining.ToList())
                if (levels.Code_levels == direction.Code_levels)
                    DBObjects.Entities.DirectionTraining.Remove(direction);
            DBObjects.Entities.SaveChanges();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "")
            {
                if ((DBObjects.Entities.EducationLevels.Where(p => p.Code_levels == levels.Code_levels).Count() == 0) && (DBObjects.Entities.EducationLevels.Where(p => p.Title_levels == levels.Title_levels).Count() == 0))
                    DBObjects.Entities.EducationLevels.Add(levels);
                DBObjects.Entities.SaveChanges();
                Close();
            }
            else
                MessageBox.Show("Заполните пустые поля.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DBObjects.Entities.EducationLevels.Where(p => p.Code_levels == levels.Code_levels).Count() > 0)
            {
                Delete();
                DBObjects.Entities.EducationLevels.Remove(levels);
                DBObjects.Entities.SaveChanges();
            }
            Close();
        }
    }
}
