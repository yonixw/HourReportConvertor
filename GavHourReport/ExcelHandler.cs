using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace GavHourReport
{

    class ExcelHandler
    {
        Excel.Application app;

        public ExcelHandler()
        {
            app = new Excel.Application();
            app.Visible = true;
        }

        public void CloseExcel()
        {
            app.Quit();
        }

        string[] engMonths = new string[] {"January" ,"February","March","April","May","June","July"
            ,"August","September","October","November","December" };

        public void openTemplate()
        {
            Excel.Workbook workbook = app.Workbooks.Open(Environment.CurrentDirectory +  "\\TEMPLATE.xls");
        }
    }
}
