using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace GavHourReport.ExcelFlow
{
    public class DayInfo
    {
        public TimeSpan dayStart = TimeSpan.Zero;
        public TimeSpan dayLength = TimeSpan.Zero;
    }

    class RPTImport
    {
        // תוכנה בשם TIMELINE
        // נוכחות - דוח שעות מפורט לפי עובד

        public static string valSTR(Excel.Range cell)
        {
            if (cell != null && cell.Value2 != null)
                return (string)cell.Value2;
            return "";
        }

        public static TimeSpan valTimeDot(Excel.Range cell)
        {
            if (cell != null && cell.Value2 != null)
            {
                double value = (double)cell.Value2;
                int HH = (int)Math.Floor(value);
                int MM = (int)Math.Floor(((value - HH) * 100.0));
                return new TimeSpan(HH, MM, 0);
            }
            return TimeSpan.Zero;
        }

        public enum RPTCol
        {
            DATE = 8,
            DAYTEXT = 7,
            TIMESTART = 6,
            ROWTIME = 4
        }

        public static Dictionary<string, DayInfo> import(string fileName)
        {
            Dictionary<string, DayInfo> resultDic = new Dictionary<string, DayInfo>();

            Excel.Application app = new Excel.Application();
            app.Visible = true; // DEBUG

            Excel.Workbook workbook = app.Workbooks.Open(fileName);
            Excel.Worksheet wsheet = (Excel.Worksheet)workbook.ActiveSheet;

            int row = 2; // start count from 1, and skip headers.
            string descData = valSTR((Excel.Range)wsheet.Cells[row, RPTCol.DAYTEXT]);
            string lastDateKey = "error???";

            while (descData != "") // Day description should always exist.
            {
                // `*` if changed manually??
                string totalTime = valSTR((Excel.Range)wsheet.Cells[row, RPTCol.ROWTIME]).Replace(" ", "").Replace("*", "");

                if (totalTime != "")
                {
                    string dateKey = valSTR((Excel.Range)wsheet.Cells[row, RPTCol.DATE]);
                    TimeSpan startTime = valTimeDot((Excel.Range)wsheet.Cells[row, RPTCol.TIMESTART]);

                    if (dateKey == "") // When a day has multiple enteries.
                        dateKey = lastDateKey;
                    else
                        lastDateKey = dateKey;

                    if (!resultDic.ContainsKey(dateKey))
                        resultDic.Add(dateKey, new DayInfo());

                    if (resultDic[dateKey].dayStart == TimeSpan.Zero)
                    {
                        resultDic[dateKey].dayStart = startTime;
                    }

                    resultDic[dateKey].dayLength += TimeSpan.Parse(totalTime); 
                }

                row++;
                descData = valSTR((Excel.Range)wsheet.Cells[row, RPTCol.DAYTEXT]);
            }

            app.Quit();

            return resultDic;
        }

    }
}
