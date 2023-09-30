using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
namespace Аккредитационные_показатели
{
    public partial class AddDT : Form
    {
        private string file = "";
        private DirectionTraining directionTraining { get; }
        public AddDT(DirectionTraining directionTraining, string file)
        {
            InitializeComponent();
            this.directionTraining = directionTraining;
            this.file = file;
            Fill();
        }
        private void Fill()
        {     
            DataTable dt = new DataTable();
            using (WordprocessingDocument doc = WordprocessingDocument.Open(file, true))
            {
                Table table = doc.MainDocumentPart.Document.Body.Elements<Table>().First();
                IEnumerable<TableRow> rows = table.Elements<TableRow>();
                int rowCount = 0;
                foreach (TableRow row in rows)
                {
                    if (rowCount == 0)
                    {
                        foreach (TableCell cell in row.Descendants<TableCell>())
                        {
                            dt.Columns.Add(cell.InnerText);
                        }
                        rowCount++;
                    }
                    else
                    {
                        string[] text = new string[4];
                        int i = 0;
                        foreach (TableCell cell in row.Descendants<TableCell>())
                        {
                            text[i] = cell.InnerText;
                            i++;
                        }
                        dt.Rows.Add(text[0], text[1], text[2], text[3]);
                    }
                }
                string[] colomn = new string[2];
                colomn[0] = "Код";
                colomn[1] = "Специальность";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() != "" && dt.Rows[i][1].ToString() != "")
                        clbDT.Items.Add(dt.Rows[i][0].ToString() + "_" + dt.Rows[i][1].ToString());
                }
            }
            cbLevels.DataSource = DBObjects.Entities.EducationLevels.ToList();//заполнение combobox данными об уровнях образования
            if(cbLevels.Items.Count != 0)
                cbLevels.SelectedIndex = 0;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbLevels.Items.Count != 0)
            {
                foreach (EducationLevels lev in DBObjects.Entities.EducationLevels.ToList())
                    if (cbLevels.SelectedItem.ToString() == lev.ToString())
                        directionTraining.Code_levels = lev.Code_levels;

                for (int i = 0; i < clbDT.Items.Count; i++)
                {
                    if (clbDT.GetItemChecked(i))
                    {
                        string text = clbDT.Items[i].ToString();

                        string[] words = text.Split('_');
                        directionTraining.Code = words[0];
                        directionTraining.Title_dt = words[1];
                        DBObjects.Entities.DirectionTraining.Add(directionTraining);
                        DBObjects.Entities.SaveChanges();
                    }
                }
                Close();
            }
            else
                MessageBox.Show("Не найден уровень образования. Пожалуйста, сначала добавьте запись в таблицу по уровню образования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
