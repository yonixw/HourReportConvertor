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

        public static Dictionary<string, TimeSpan> import(string fileName)
        {
            Dictionary<string, TimeSpan> data = new Dictionary<string, TimeSpan>();

            Excel.Application app = new Excel.Application();
            app.Visible = true; // DEBUG

            return data;
        }

    }
}
