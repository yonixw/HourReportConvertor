using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GavHourReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CultureInfo culture = new System.Globalization.CultureInfo("he-IL");
        public static string dateFormat = "dd/MM/yyyy";

        private void loadTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string inputDate = Microsoft.VisualBasic.Interaction.InputBox("Put Date: <MM>/<YY>");
            if (inputDate != "")
            {
                DateTime day;
                int currentMonth = -1;
                if ( DateTime.TryParse("01/" + inputDate, out day)  ){
                    dgvData.Rows.Clear();

                    currentMonth = day.Month;

                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = Color.Salmon;
                    while (day.Month == currentMonth)
                    {
                            dgvData.Rows.Add(new object[] {
                                day.ToString(dateFormat),
                                culture.DateTimeFormat.GetDayName(day.DayOfWeek),
                                "00:00", false, false, false });

                        if (day.DayOfWeek == DayOfWeek.Friday || day.DayOfWeek == DayOfWeek.Saturday)
                        {
                            dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle = style;
                            dgvData.Rows[dgvData.Rows.Count - 1].Cells["cIgnore"].Value = true;
                        }

                        day = day.AddDays(1);
                    }
                }
                else
                {
                    MessageBox.Show("Cant understand \"" + inputDate + "\". please use MM/YY");
                }
            }
        }

        private void loadEXELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Choose RPT excel to import";
            dlg.Filter = "Excel|*.xls;*.xlsx";
            dlg.CheckFileExists = true;
            dlg.Multiselect = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, TimeSpan> importData = ExcelFlow.RPTImport.import(dlg.FileName);

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    string dateKey = row.Cells[0].Value.ToString();
                    if (importData.ContainsKey(dateKey))
                    {
                        TimeSpan totalTime = importData[dateKey];
                        row.Cells["cTIME"].Value = string.Format("{0:00}:{1:00}",
                           (int)totalTime.TotalHours,
                                totalTime.Minutes); 
                    }
                }
            }
        }

        private void eXPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
