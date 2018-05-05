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
                                day.ToString("dd/MM"),
                                culture.DateTimeFormat.GetDayName(day.DayOfWeek),
                                0, 0, false, false });

                        if (day.DayOfWeek == DayOfWeek.Friday || day.DayOfWeek == DayOfWeek.Saturday)
                        {
                            dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle = style;
                            dgvData.Rows[dgvData.Rows.Count - 1].ReadOnly = true;
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

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                ExcelFlow.RPTImport.import(dlg.FileName);
            }
        }
    }
}
