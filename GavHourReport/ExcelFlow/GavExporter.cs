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
        public static TimeSpan fulldayLength = new TimeSpan(9, 06, 0);
        public static TimeSpan minWorkdayLength = new TimeSpan(5, 0, 0);
        public static TimeSpan minWorkForBreak = new TimeSpan(6, 0, 0);
        public static TimeSpan breakLength = new TimeSpan(0, 30, 0);
        public static TimeSpan defaultDayStart = new TimeSpan(8, 0, 0);

        static string[] engMonths = new string[] {"January" ,"February","March","April","May","June","July"
            ,"August","September","October","November","December" };

        enum HourTypeRow
        {
            WORK = 7,
            BREAK = 8,
            OTHER_START = 9
        }

        static string timeStr(TimeSpan time)
        {
            return
                string.Format("{0:00}:{1:00}",
                               (int)time.TotalHours,
                                    time.Minutes);
        }

        public static void export(DateTime currMonth, DataGridViewRowCollection rows,
            string templatePath, string exportPath)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true; // DEBUG

            Excel.Workbook workbook = app.Workbooks.Open(templatePath);
            Excel.Worksheet wsheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Set Month
            ((Excel.Range)wsheet.Cells[2, 2]).Value2 = engMonths[currMonth.Month -1];
            // Set year:
            ((Excel.Range)wsheet.Cells[3,2]).Value2 = currMonth.Year;

            int currentCol = 5;
            foreach(DataGridViewRow row in rows)
            {
                try
                { 

                    TimeSpan rowWorkLength = TimeSpan.Parse((string)row.Cells["cTIME"].Value);
                    TimeSpan rowStartTime = TimeSpan.Parse((string)row.Cells["cStart"].Value);

                    if (rowWorkLength.TotalMinutes > 0)
                    {
                        if (rowWorkLength < minWorkdayLength)
                            throw new Exception("Not enough hours for this day!");

                        TimeSpan rowBreakLength = TimeSpan.Zero;
                        if (rowWorkLength > minWorkForBreak)
                            rowBreakLength = breakLength;

                        ((Excel.Range)wsheet.Cells[HourTypeRow.WORK, currentCol]).Value 
                            = timeStr(rowStartTime);
                        ((Excel.Range)wsheet.Cells[HourTypeRow.WORK, currentCol + 1]).Value 
                            = timeStr(rowStartTime + rowWorkLength - rowBreakLength);

                        if (rowBreakLength.TotalMinutes > 0)
                        {
                            ((Excel.Range)wsheet.Cells[HourTypeRow.BREAK, currentCol]).Value
                                = timeStr(rowStartTime + rowWorkLength - rowBreakLength);
                            ((Excel.Range)wsheet.Cells[HourTypeRow.BREAK, currentCol + 1]).Value
                                = timeStr(rowStartTime + rowWorkLength);
                        }
                    }
                    else
                    {
                        // No work hours ! Find reason:
                        DataGridViewComboBoxCell cell =
                                ((DataGridViewComboBoxCell)row.Cells["cOther"]);
                        rowWorkLength = fulldayLength;
                        rowStartTime = defaultDayStart;

                        if (cell.Value == null)
                            throw new Exception("No time and no reason!");
                        else
                        {
                            int reasonIndex = cell.Items.IndexOf(cell.Value);

                            if (reasonIndex == 0)
                            {
                                // Ignore
                            }
                            else
                            {
                                int rowIndex = (int)HourTypeRow.OTHER_START - 1 + reasonIndex;
                                ((Excel.Range)wsheet.Cells[rowIndex, currentCol]).Value = timeStr(rowStartTime);
                                ((Excel.Range)wsheet.Cells[rowIndex, currentCol + 1]).Value = timeStr(rowStartTime + rowWorkLength);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error on date:" + row.Cells[0].Value.ToString() + Environment.NewLine +
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
