using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace Аккредитационные_показатели
{
    public partial class AddMasterProgram : Form
    {
        private Management_Master_degree_program management { get; } //объект для работы с руководством программы магистратуры
        public AddMasterProgram(Management_Master_degree_program management)
        {
            InitializeComponent();
            this.management = management;
            Fill();
        }
        private void Fill() //заполнение формы данными        
        {
            string FIO = "";
            cbFIO.DataSource = DBObjects.Entities.Teacher.ToList();//заполнение combobox данными о преподавателях
            foreach (Teacher teacher in DBObjects.Entities.Teacher.ToList())//нахождение ФИО записанного в строку с выбранными элементом
            {
                if (teacher.Code_teacher == management.Code_teacher)
                {
                    FIO = teacher.ToString();
                    break;
                }
            }
            for (int i = 0; i < cbFIO.Items.Count; i++) //нахождение нужного ФИО в combobox и выделение его как первого
                if (cbFIO.Items[i].ToString() == FIO)
                {
                    cbFIO.SelectedIndex = i;
                    break;
                }

            txtResearchProject.Text = management.ResearchProject_management;
            txtDomestic.Text = management.DomesticPublications_management;
            txtForeign.Text = management.ForeignPublications_management;
            rtxtApprobation.Text = management.Approbation_management;
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
        private void txtResearchProject_TextChanged(object sender, EventArgs e)
        {
            management.ResearchProject_management = txtResearchProject.Text;
        }
        private void txtDomestic_TextChanged(object sender, EventArgs e)
        {
            management.DomesticPublications_management = txtDomestic.Text;
        }
        private void txtForeign_TextChanged(object sender, EventArgs e)
        {
            management.ForeignPublications_management = txtForeign.Text;
        }
        private void rtxtApprobation_TextChanged(object sender, EventArgs e)
        {
            management.Approbation_management = rtxtApprobation.Text;
        }
        private void SaveFIO()
        {
            foreach (Teacher teacher in DBObjects.Entities.Teacher.ToList())
                if (cbFIO.SelectedItem.ToString() == teacher.ToString())
                    management.Code_teacher = teacher.Code_teacher;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtResearchProject.Text != "" && cbFIO.SelectedIndex.ToString() != "")
            {
                SaveFIO();
                if (DBObjects.Entities.Management_Master_degree_program.Where(p => p.Code_management == management.Code_management).Count() == 0)
                {
                    DBObjects.Entities.Management_Master_degree_program.Add(management);
                }
                DBObjects.Entities.SaveChanges();
                Close();
            }
            else
                MessageBox.Show("Заполните поля тематики научно-исследотельского проекта и/или ФИО преподавателя.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DBObjects.Entities.Management_Master_degree_program.Where(p => p.Code_management == management.Code_management).Count() > 0)
            {
                DBObjects.Entities.Management_Master_degree_program.Remove(management);
                DBObjects.Entities.SaveChanges();
            }
            Close();
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
                    string[] arr = text.Split(new Char[] { ' ', ':', '\t', '\n' });
                    arr = arr.Where(val => val != "").ToArray();
                    string FIO = "";
                    for (int i = 0; i < arr.Length - 1; i++)
                    {                        
                        if (arr[i] == "Фамилия")
                            FIO += arr[i + 1] + " ";
                        if (arr[i] == "Имя")
                            FIO += arr[i + 1] + " ";
                        if (arr[i] == "Отчество")
                            FIO += arr[i + 1];
                        for (int j = 0; j < cbFIO.Items.Count; j++) //нахождение нужного ФИО в combobox и выделение его как первого
                            if (cbFIO.Items[j].ToString() == FIO)
                            {
                                cbFIO.SelectedIndex = j;
                                break;
                            }
                        if (arr[i] == "Тематика" && arr[i + 1] == "научно-исследовательского" && arr[i + 2] == "проекта")
                        {
                            string str = "";
                            i += 3;
                            do
                            {
                                str += arr[i] + " ";
                                i++;
                            } while (arr[i] != "Публикация");
                            txtResearchProject.Text = str;
                        }
                        if (arr[i] == "Публикация" && arr[i + 1] == "в" && arr[i + 2] == "отечественных")
                        {
                            string str = "";
                            i += 4;
                            do
                            {
                                str += arr[i] + " ";
                                i++;
                            } while (arr[i] != "Публикация");
                            txtDomestic.Text = str;
                        }
                        if (arr[i] == "Публикация" && arr[i + 1] == "в" && arr[i + 2] == "зарубежных")
                        {
                            string str = "";
                            i += 4;
                            do
                            {
                                str += arr[i] + " ";
                                i++;
                            } while (arr[i] != "Апробация");
                            txtForeign.Text = str;
                        }
                        if (arr[i] == "Апробация" && arr[i + 1] == "результатов")
                        {
                            string str = "";
                            i += 2;
                            do
                            {
                                str += arr[i] + " ";
                                i++;
                            } while (i != arr.Length);
                            rtxtApprobation.Text = str;
                        }                        
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Закройте файл.", "Ошибка открытия файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
