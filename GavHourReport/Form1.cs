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
                    while (day.Month == currentMonth)
                    {
                        if (day.DayOfWeek != DayOfWeek.Friday && day.DayOfWeek != DayOfWeek.Saturday)
                            dgvData.Rows.Add(new object[] {
                                day.ToString("dd/MM"),
                                culture.DateTimeFormat.GetDayName(day.DayOfWeek),
                                0, 0, false, false });

                        day = day.AddDays(1);
                    }
                }
                else
                {
                    MessageBox.Show("Cant understand \"" + inputDate + "\". please use MM/YY");
                }
            }
        }
    }
}
