using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


//נוכחות-דוח ניתוח שעות והכנה לשכר לאקסל

namespace GavHourReport.ExcelFlow
{
    class RPTImportType2
    {
        public static T val<T>(Excel.Range cell, T emptyResult = default(T))
        {
            if (cell != null && cell.Value2 != null)
                return (T)cell.Value2;
            return emptyResult;
        }

        public enum RPTColv2
        {
            DATE = 18,
            TIMESTART = 17,
            ROWTIME = 13
        }

        public class ImportResult
        {
            public Dictionary<string, DayInfo> days;
            public double reportedHours;
        }

        public static ImportResult import(string fileName)
        {
            Dictionary<string, DayInfo> resultDic = new Dictionary<string, DayInfo>();

            Excel.Application app = new Excel.Application();
            app.Visible = true; // DEBUG

            Excel.Workbook workbook = app.Workbooks.Open(fileName);
            Excel.Worksheet wsheet = (Excel.Worksheet)workbook.ActiveSheet;

            int row = 3; 
            string dateKey = val((Excel.Range)wsheet.Cells[row, RPTColv2.DATE], "");

            TimeSpan allTimeCounter = TimeSpan.FromSeconds(0);
            while (dateKey != "") // Day description should always exist.
            {
                // `*` if changed manually??
                double totalTime = val((Excel.Range)wsheet.Cells[row, RPTColv2.ROWTIME],0.0);
                totalTime = Math.Round(totalTime, 2);

                if (totalTime  >  1.0/60.0) // one minute
                {
                    string startTime = val((Excel.Range)wsheet.Cells[row, RPTColv2.TIMESTART], "")
                        .Replace(" ","").Replace("*","");

                    if (!resultDic.ContainsKey(dateKey))
                        resultDic.Add(dateKey, new DayInfo());

                    if (resultDic[dateKey].dayStart == TimeSpan.Zero)
                    {
                        resultDic[dateKey].dayStart = TimeSpan.Parse(startTime);
                    }

                    resultDic[dateKey].dayLength = TimeSpan.FromMinutes(Math.Floor(totalTime * 60));
                    allTimeCounter += resultDic[dateKey].dayLength;
                }

                row++;
                dateKey = val((Excel.Range)wsheet.Cells[row, RPTColv2.DATE], "");
            }

            // Read total:
            double allTimeExcel = Math.Round(val((Excel.Range)wsheet.Cells[row, RPTColv2.ROWTIME], 0.0),2);

            app.Quit();
           

            return new ImportResult() { days=  resultDic, reportedHours = allTimeExcel };
        }
    }
}
