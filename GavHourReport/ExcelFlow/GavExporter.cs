using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace GavHourReport.ExcelFlow
{

    class GavExporter
    {
        public static TimeSpan fullday = new TimeSpan(9, 10, 0);
        public static TimeSpan minHour = new TimeSpan(5, 10, 0);
        public static TimeSpan minBreak = new TimeSpan(6, 0, 0);
        public static TimeSpan breakLength = new TimeSpan(0, 30, 0);

        static string[] engMonths = new string[] {"January" ,"February","March","April","May","June","July"
            ,"August","September","October","November","December" };

        public static void export(DateTime currMonth, DataGridViewRowCollection rows,
            string templatePath, string exportPath)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true; // DEBUG

            Excel.Workbook workbook = app.Workbooks.Open(templatePath);
            Excel.Worksheet wsheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Set Month
            ((Excel.Range)wsheet.Cells[2, 2]).Value2 = engMonths[currMonth.Month];
            // Set year:
            ((Excel.Range)wsheet.Cells[3,2]).Value2 = currMonth.Year;

            int currentCol = 5;
            foreach(DataGridViewRow row in rows)
            {
                try
                {

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error on date:" + row.Cells[0].Value.ToString() + Environment.NewLine
                        ex.Message + Environment.NewLine + ex.StackTrace
                        );
                }

                currentCol += 3;
            }

            workbook.SaveAs(exportPath);
            workbook.Close(SaveChanges: false);

            app.Quit();
      
        }
    }
}
