using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace Аккредитационные_показатели
{
    public partial class AddPractitioners : Form
    {
        private Practitioners practitioners { get; } //объект для работы с специалистом практиком
        public AddPractitioners(Practitioners practitioners)
        {
            InitializeComponent();
            this.practitioners = practitioners;
            Fill();
        }
        private void Fill() //заполнение формы данными        
        {
            txtFIO.Text = practitioners.FIO_practitioner;
            txtOrg.Text = practitioners.TitleOrg_practitioner;
            txtPosition.Text = practitioners.Position_practitioner;
            txtPeriod.Text = practitioners.PeriodOperation_practitioner;
            txtWork.Text = practitioners.WorkExperience_practitioner;
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
        private void txtFIO_TextChanged(object sender, EventArgs e)
        {
            practitioners.FIO_practitioner = txtFIO.Text;
        }
        private void txtOrg_TextChanged(object sender, EventArgs e)
        {
            practitioners.TitleOrg_practitioner = txtOrg.Text;
        }
        private void txtPosition_TextChanged(object sender, EventArgs e)
        {
            practitioners.Position_practitioner = txtPosition.Text;
        }
        private void txtPeriod_TextChanged(object sender, EventArgs e)
        {
            practitioners.PeriodOperation_practitioner = txtPeriod.Text;
        }
        private void txtWork_TextChanged(object sender, EventArgs e)
        {
            practitioners.WorkExperience_practitioner = txtWork.Text;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFIO.Text != "" && txtOrg.Text != "" && txtPosition.Text != "" && txtPeriod.Text != "")
            {
                if (DBObjects.Entities.Practitioners.Where(p => p.Code_practitioner == practitioners.Code_practitioner).Count() == 0)
                    DBObjects.Entities.Practitioners.Add(practitioners);
                DBObjects.Entities.SaveChanges();
                Close();
            }
            else
                MessageBox.Show("Заполните пустые поля.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DBObjects.Entities.Practitioners.Where(p => p.Code_practitioner == practitioners.Code_practitioner).Count() > 0)
            {
                DBObjects.Entities.Practitioners.Remove(practitioners);
                DBObjects.Entities.SaveChanges();
            }
            Close();
        }

        private void btnEnterData_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
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
                    if (arr[i] == "Организация")
                    {
                        string str = "";
                        i++;
                        do
                        {
                            str += arr[i] + " ";
                            i++;
                        } while (arr[i] != "Должность");
                        txtOrg.Text = str;
                    }
                    if (arr[i] == "Должность")
                    {
                        string str = "";
                        i++;
                        do
                        {
                            str += arr[i] + " ";
                            i++;
                        } while (arr[i] != "Период");
                        txtPosition.Text = str;
                    }
                    if (arr[i] == "Период" && arr[i+1] == "работы")
                    {
                        string str = "";
                        i+=2;
                        do
                        {
                            str += arr[i] + " ";
                            i++;
                        } while (arr[i] != "Трудовой");
                        txtPeriod.Text = str;
                    }
                    if (arr[i] == "Трудовой" && arr[i + 1] == "стаж")
                    {
                        string str = "";
                        i += 2;
                        do
                        {
                            str += arr[i] + " ";
                            i++;
                        } while (i != arr.Length);
                        txtWork.Text = str;
                    }                    
                }
            }
        }
    }
}
