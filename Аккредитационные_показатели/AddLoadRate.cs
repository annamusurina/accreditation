using System;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
namespace Аккредитационные_показатели
{
    public partial class AddLoadRate : Form
    {
        private LoadRate load { get; }
        public AddLoadRate(LoadRate load)
        {
            InitializeComponent();
            this.load = load;
            Fill();
        }
        private void Fill() //заполнение формы данными        
        {
            string position = "";
            cbTitle.DataSource = DBObjects.Entities.Position.ToList();
            foreach (Position pos in DBObjects.Entities.Position.ToList())
                if (pos.Code_position == load.Code_position)
                {
                    position = pos.ToString();
                    break;
                }
            for (int i = 0; i < cbTitle.Items.Count; i++) 
                if (cbTitle.Items[i].ToString() == position)
                {
                    cbTitle.SelectedIndex = i;
                    break;
                }
                        
            txtNumberHour.Text = Convert.ToString(load.Number_hours);
            txtYear.Text = load.AcademicYear_load;
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
        private void SavePos()
        {
            foreach(Position pos in DBObjects.Entities.Position.ToList())
                if(pos.Title == cbTitle.SelectedItem.ToString())
                    load.Code_position = pos.Code_position;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNumberHour.Text != "" && cbTitle.SelectedIndex.ToString() != "" && txtYear.Text != "")
            {
                SavePos();
                if (DBObjects.Entities.LoadRate.Where(p => p.Code_lr == load.Code_lr).Count() == 0)
                {
                    DBObjects.Entities.LoadRate.Add(load);
                }
                DBObjects.Entities.SaveChanges();
                Close();
            }
            else
                MessageBox.Show("Заполните пустые поля.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DBObjects.Entities.LoadRate.Where(p => p.Code_lr == load.Code_lr).Count() > 0)
            {
                DBObjects.Entities.LoadRate.Remove(load);
                DBObjects.Entities.SaveChanges();
            }
            Close();
        }
        private void txtNumberHour_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberHour.Text != "")
                load.Number_hours = Convert.ToInt32(txtNumberHour.Text);
            else
                load.Number_hours = 0;
        }
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            load.AcademicYear_load = txtYear.Text;
        }
        private void txtNumberHour_KeyPress(object sender, KeyPressEventArgs e)
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
