using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace PP_AddIn___minieks
{
    internal class Excel
    {
        string Path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public Excel(string path, int sheet) 
        {
            this.Path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }

        public Excel() 
        {
            
        }

        public void CelleInsert(int i, int j, string s)
        {
            i++;
            j++;
            ws.Cells[i, j].Value2 = s;
        }

        public void save()
        {
            wb.Save();
        }

        public void saveAs(string titel)
        {
            wb.SaveAs(titel);
        }

        public void close()
        {
            wb.Close();
        }
        public void nyFil()
        {
            this.wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            this.ws = wb.Worksheets[1];
        }

        public void nytSheet()
        {
            Worksheet temptsheet = wb.Worksheets.Add(After: ws);
        }

        public void ChooseSheet(int i)
        {
            this.ws = wb.Worksheets[i];
        }

    }
}
