using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace Аккредитационные_показатели
{
    public partial class AddTeacher : Form
    {
        private Teacher teacher { get; } //объект для работы с преподавателем
        public AddTeacher(Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
            Fill();
        }
        private void Fill() //заполнение формы данными        
        {
            cbTermsAttraction.SelectedIndex = 0;
            for (int i = 0; i < cbTermsAttraction.Items.Count; i++) 
                //нахождение нужного условия в combobox и выделение его как первого
                if (cbTermsAttraction.Items[i].ToString() == teacher.TermsAttraction_teacher)
                {
                    cbTermsAttraction.SelectedIndex = i;
                    break;
                }
            txtFIO.Text = teacher.FIO_teacher;

            string pos = "";
            cbPosition.DataSource = DBObjects.Entities.Position.ToList();
            //заполнение combobox данными
            foreach (Position position in DBObjects.Entities.Position.ToList())
                //нахождение записанного в строку с выбранными элементом
                if (teacher.Code_position == position.Code_position)
                {
                    pos = position.Title;
                    break;
                }
            for (int i = 0; i < cbPosition.Items.Count; i++) 
                //нахождение нужного в combobox и выделение его как первого
                if (cbPosition.Items[i].ToString() == pos)
                {
                    cbPosition.SelectedIndex = i;
                    break;
                }
            txtAcademicDegree.Text = teacher.AcademicDegree_teacher;
            txtAcademicTitle.Text = teacher.AcademicTitle_teacher;
            txtEducationLevel.Text = teacher.EducationLevel_teacher;
            txtTitleSpecialty.Text = teacher.TitleSpecialty_teacher;
            txtAssignedQualification.Text = teacher.AssignedQualification_teacher;
            txtAdditionalProfEducation.Text = teacher.AdditionalProfEducation_teacher;
            txtWorkEducationalActivities.Text = teacher.WorkEducationalActivities_teacher;
            txtWorkOtherOrg.Text = teacher.WorkOtherOrg_teacher;
        }
        private void вернутьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }        
        private void txtFIO_TextChanged(object sender, EventArgs e)
        {
           teacher.FIO_teacher = txtFIO.Text;
        }
        private void txtAcademicDegree_TextChanged(object sender, EventArgs e)
        {
            teacher.AcademicDegree_teacher = txtAcademicDegree.Text;
        }
        private void txtAcademicTitle_TextChanged(object sender, EventArgs e)
        {
            teacher.AcademicTitle_teacher = txtAcademicTitle.Text;
        }
        private void txtEducationLevel_TextChanged(object sender, EventArgs e)
        {
            teacher.EducationLevel_teacher = txtEducationLevel.Text;
        }
        private void txtTitleSpecialty_TextChanged(object sender, EventArgs e)
        {
            teacher.TitleSpecialty_teacher = txtTitleSpecialty.Text;
        }
        private void txtAssignedQualification_TextChanged(object sender, EventArgs e)
        {
            teacher.AssignedQualification_teacher = txtAssignedQualification.Text;
        }
        private void txtAdditionalProfEducation_TextChanged(object sender, EventArgs e)
        {
            teacher.AdditionalProfEducation_teacher = txtAdditionalProfEducation.Text;
        }
        private void txtWorkEducationalActivities_TextChanged(object sender, EventArgs e)
        {
            teacher.WorkEducationalActivities_teacher = txtWorkEducationalActivities.Text;
        }
        private void txtWorkOtherOrg_TextChanged(object sender, EventArgs e)
        {   //заполнение при изменении поля
            teacher.WorkOtherOrg_teacher = txtWorkOtherOrg.Text;
        }
        private void Save()
        {
            teacher.TermsAttraction_teacher = cbTermsAttraction.SelectedItem.ToString();
            foreach (Position position in DBObjects.Entities.Position.ToList())
                if (cbPosition.SelectedItem.ToString() == position.Title)
                    teacher.Code_position = position.Code_position;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFIO.Text != "" && cbPosition.SelectedIndex.ToString() != "" 
                && txtEducationLevel.Text != "" && txtTitleSpecialty.Text != "")
            {
                Save();
                if (DBObjects.Entities.Teacher.Where(p => p.Code_teacher == teacher.Code_teacher).Count() == 0)
                    DBObjects.Entities.Teacher.Add(teacher);
                DBObjects.Entities.SaveChanges();
                Close();
            }
            else
                MessageBox.Show("Заполните обязательные поля.", "Ошибка сохранения",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Delete()
        {
            foreach (AcademicLoad academic in DBObjects.Entities.AcademicLoad.ToList())
                if (teacher.Code_teacher == academic.Code_teacher)
                    DBObjects.Entities.AcademicLoad.Remove(academic);
            foreach (Management_Master_degree_program management in DBObjects.Entities.Management_Master_degree_program.ToList())
                if (teacher.Code_teacher == management.Code_teacher)
                    DBObjects.Entities.Management_Master_degree_program.Remove(management);
            DBObjects.Entities.SaveChanges();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DBObjects.Entities.Teacher.Where(p => p.Code_teacher == teacher.Code_teacher).Count() > 0)
            {
                Delete();
                DBObjects.Entities.Teacher.Remove(teacher);
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
                try
                {
                    DocX doc = DocX.Load(file);

                string text = doc.Text;
                string[] arr = text.Split(new Char[] { ' ', '.', ',', ':', '_', '\t', '\n' });
                arr = arr.Where(val => val != "").ToArray();
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        if (arr[i] == "Фамилия")
                            txtFIO.Text = arr[i + 1] + " ";
                        if (arr[i] == "Имя")
                            txtFIO.Text += arr[i + 1] + " ";
                        if (arr[i] == "Отчество")
                            txtFIO.Text += arr[i + 1];
                        if (arr[i] == "Условия" && arr[i + 1] == "привлечения")
                        {
                            string str = "";
                            i += 2;
                            do
                            {
                                str += arr[i] + " ";
                                i++;
                            } while (arr[i] != "Должность");
                            for (int j = 0; j < cbTermsAttraction.Items.Count; j++) //нахождение нужного условия в combobox и выделение его как первого
                                if (cbTermsAttraction.Items[j].ToString() == str)
                                {
                                    cbTermsAttraction.SelectedIndex = j;
                                    break;
                                }
                        }
                        if (arr[i] == "Должность")
                        {
                            string str = "";
                            i++;
                            do
                            {
                                str += arr[i] + " ";
                                i++;
                            } while (arr[i] != "Ученая");
                            for (int j = 0; j < cbPosition.Items.Count; j++) //нахождение нужной должности в combobox и выделение его как первого
                                if (cbPosition.Items[j].ToString() == str)
                                {
                                    cbPosition.SelectedIndex = j;
                                    break;
                                }
                        }
                        if (arr[i] == "Ученая" && arr[i + 1] == "степень")
                        {
                            string str = "";
                            i += 2;
                            do
                            {
                                str += arr[i] + " ";
                                i++;
                            } while (arr[i] != "Ученое");
                            txtAcademicDegree.Text = str;
                        }
                        if (arr[i] == "Ученое" && arr[i + 1] == "звание")
                        {
                            string str = "";
                            i += 2;
                            do
                            {
                                str += arr[i] + " ";
                                i++;
                            } while (arr[i] != "Уровень");
                            txtAcademicTitle.Text = str;
                        }
                        if (arr[i] == "Уровень" && arr[i + 1] == "образования")
                        {
                            string str = "";
                            i += 2;
                            do
                            {
                                str += arr[i] + " ";
                                i++;
                            } while (arr[i] != "Наименование" && arr[i] != "Направление");
                            txtEducationLevel.Text = str;
                        }
                        if (arr[i] == "Наименование" && arr[i + 1] == "специальности")
                        {
                            string str = "";
                            i += 2;
                            do
                            {
                                str += arr[i] + " ";
                                i++;
                            } while (arr[i] != "Присвоенная");
                            txtTitleSpecialty.Text = str;
                        }
                        else
                        {
                            if (arr[i] == "Направление" && arr[i + 1] == "подготовки")
                            {
                                string str = "";
                                i += 2;
                                do
                                {
                                    str += arr[i] + " ";
                                    i++;
                                } while (arr[i] != "Присвоенная");
                                txtTitleSpecialty.Text = str;
                            }
                        }
                        if (arr[i] == "Присвоенная" && arr[i + 1] == "квалификация")
                        {
                            string str = "";
                            i += 2;
                            do
                            {
                                str += arr[i] + " ";
                                i++;
                            } while (arr[i] != "Сведения");
                            txtAssignedQualification.Text = str;
                        }
                        if (arr[i] == "Сведения" && arr[i + 1] == "о" && arr[i + 2] == "дополнительном")
                        {
                            string str = "";
                            i += 5;
                            while (arr[i] != "Стаж")
                            {
                                str += arr[i] + " ";
                                i++;
                            }
                            txtAdditionalProfEducation.Text = str;
                        }
                        if (arr[i] == "Стаж" && arr[i + 1] == "работы" && arr[i + 2] == "в" && arr[i + 3] == "организациях" && arr[i + 4] == "с" && arr[i + 5] == "образовательной")
                        {
                            string str = "";
                            i += 7;
                            do
                            {
                                str += arr[i] + " ";
                                i++;
                            } while (arr[i] != "Стаж");
                            txtWorkEducationalActivities.Text = str;
                        }
                        if (arr[i] == "Стаж" && arr[i + 1] == "работы" && arr[i + 2] == "в" && arr[i + 3] == "иных" && arr[i + 4] == "организациях")
                        {
                            string str = "";
                            i += 5;
                            do
                            {
                                str += arr[i] + " ";
                                i++;
                            } while (i != arr.Length);
                            txtWorkOtherOrg.Text = str;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Закройте файл.", "Ошибка открытия файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            TabPosition position = new TabPosition();
            position.ShowDialog();
            Fill();
        }
    }
}
