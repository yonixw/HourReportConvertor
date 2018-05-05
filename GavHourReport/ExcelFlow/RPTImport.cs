using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace GavHourReport.ExcelFlow
{
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

        public enum RPTCol
        {
            DATE = 8,
            DAYTEXT = 7,
            ROWTIME = 4
        }

        public static Dictionary<string, TimeSpan> import(string fileName)
        {
            Dictionary<string, TimeSpan> resultDic = new Dictionary<string, TimeSpan>();

            Excel.Application app = new Excel.Application();
            app.Visible = true; // DEBUG

            Excel.Workbook workbook = app.Workbooks.Open(fileName);
            Excel.Worksheet wsheet = (Excel.Worksheet)workbook.ActiveSheet;

            int row = 2; // start count from 1, and skip headers.
            string descData = valSTR((Excel.Range)wsheet.Cells[row, RPTCol.DAYTEXT]);
            string lastDateKey = "error???";

            while (descData != "") // Day description should always exist.
            {
                string totalTime = valSTR((Excel.Range)wsheet.Cells[row, RPTCol.ROWTIME]);
                if (totalTime != "")
                {
                    string dateKey = valSTR((Excel.Range)wsheet.Cells[row, RPTCol.DATE]);
                    if (dateKey == "") // When a day has multiple enteries.
                        dateKey = lastDateKey;
                    else
                        lastDateKey = dateKey;

                    if (!resultDic.ContainsKey(dateKey))
                        resultDic.Add(dateKey, TimeSpan.Zero);

                    resultDic[dateKey] += TimeSpan.Parse(totalTime.Replace(" ", "").Replace("*", "")); // * if changed manually??
                }

                row++;
                descData = valSTR((Excel.Range)wsheet.Cells[row, RPTCol.DAYTEXT]);
            }

            app.Quit();

            return resultDic;
        }

    }
}
