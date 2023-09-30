using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Аккредитационные_показатели
{
    public partial class AddDirectTrain : Form
    {
        private DirectionTraining direction { get; } //объект для работы с направлением подготовки
        public AddDirectTrain(DirectionTraining direction)
        {
            InitializeComponent();
            this.direction = direction;
            Fill();
        }
        private void Fill() //заполнение формы данными        
        {
            string levels = "";
            cbLevels.DataSource = DBObjects.Entities.EducationLevels.ToList();//заполнение combobox данными об уровнях образования
            foreach (EducationLevels lev in DBObjects.Entities.EducationLevels.ToList())//нахождение наименования уровня записанного в строку с выбранными элементом
            {
                if (lev.Code_levels == direction.Code_levels)
                {
                    levels = lev.ToString();
                    break;
                }
            }
            for (int i = 0; i < cbLevels.Items.Count; i++) //нахождение нужного уровня в combobox и выделение его как первого
                if (cbLevels.Items[i].ToString() == levels)
                {
                    cbLevels.SelectedIndex = i;
                    break;
                }

            txtNumber.Text = direction.Code; 
            txtTitle.Text = direction.Title_dt;
        }
        private void вернутьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SaveLevels()
        {
            foreach (EducationLevels lev in DBObjects.Entities.EducationLevels.ToList())
                if (cbLevels.SelectedItem.ToString() == lev.ToString())
                    direction.Code_levels = lev.Code_levels;
        }
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            direction.Code = txtNumber.Text;
        }
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            direction.Title_dt = txtTitle.Text;
        }
        private void Delete()
        {
            foreach (AcademicLoad academic in DBObjects.Entities.AcademicLoad.ToList())
                foreach (DisciplinesSemester disciplines in DBObjects.Entities.DisciplinesSemester.ToList())
                    foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())
                        if (direction.Code_dt == student.Code_dt && student.Code_adst == disciplines.Code_adst && disciplines.Code_semester == academic.Code_semester)
                                DBObjects.Entities.AcademicLoad.Remove(academic);
            foreach (DisciplinesSemester disciplines in DBObjects.Entities.DisciplinesSemester.ToList())
                foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())
                    if (direction.Code_dt == student.Code_dt && student.Code_adst == disciplines.Code_adst)
                        DBObjects.Entities.DisciplinesSemester.Remove(disciplines);
            foreach (Admission_student student in DBObjects.Entities.Admission_student.ToList())
                if (direction.Code_dt == student.Code_dt)
                    DBObjects.Entities.Admission_student.Remove(student);
            DBObjects.Entities.SaveChanges();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text != "" || txtTitle.Text != "")
            {
                SaveLevels();
                if (DBObjects.Entities.DirectionTraining.Where(p => p.Code_dt == direction.Code_dt).Count() == 0)
                {
                    DBObjects.Entities.DirectionTraining.Add(direction);
                }
                DBObjects.Entities.SaveChanges();
                Close();
            }
            else
                MessageBox.Show("Заполните пустые поля.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DBObjects.Entities.DirectionTraining.Where(p => p.Code_dt == direction.Code_dt).Count() > 0)
            {
                Delete();
                DBObjects.Entities.DirectionTraining.Remove(direction);
                DBObjects.Entities.SaveChanges();
            }
            Close();
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Url = new Uri(String.Format("file:///{0}/Руководство_пользователя.docx", curDir));
        }
        private void btnEnterData_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                FileStream f;
                try
                {
                    f = new FileStream(file, FileMode.Open);
                    f.Close();
                    DirectionTraining directionTraining = new DirectionTraining();
                    AddDT change = new AddDT(directionTraining, file);
                    change.ShowDialog();
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Закройте файл.", "Ошибка открытия файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
