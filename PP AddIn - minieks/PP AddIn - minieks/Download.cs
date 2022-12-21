using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;

namespace PP_AddIn___minieks
{
    public partial class Download_frm : Form
    {
        public Download_frm()
        {
            InitializeComponent();
        }

        private void Download_Load(object sender, EventArgs e)
        {
            string[] titles = loadFiles();
            foreach (string title in titles)
            {
                Sessions_lb.Items.Add(title);
            }
        }
        public static string[] loadFiles()
        {
            string path = "C:\\ProgramData\\PowerPointQuiz\\Svar";
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles();
            string[] titleNames = new string[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                titleNames[i] = files[i].Name.Remove((int)(files[i].Name.Length) - 5, 5);
            }
            return titleNames;
        }

        void Excelmaking()
        {
            Workbook workbook;
            Worksheet worksheet;
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            string path = "C:\\Users\\Documents\\test.xlsx";
            workbook = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            workbook.SaveAs(path);
            excel.Workbooks.Open(path);

        }


        private void LavExcel_btn_Click(object sender, EventArgs e)
        {
            Svardata data = new Svardata();
            string mellemmand = File.ReadAllText("C:\\ProgramData\\PowerPointQuiz\\Svar\\" + "21-12-202217-47-26" + ".json");
            data = JsonConvert.DeserializeObject<Svardata>(mellemmand);
            Excel excel = new Excel(@"Test.xlsx", 1);
            excel.CelleInsert(0, 0, "Session start:");
            excel.CelleInsert(1, 0, "Session slut:");
            excel.CelleInsert(0,1,data.sessionStart.ToString());
            excel.CelleInsert(1, 1, data.sessionEnd.ToString());
            int i = 0;
            int j = 0;
            foreach (string s in data.questions)
            {
                excel.CelleInsert(3 + i, 0, s);
                foreach (string q in data.answerOptions[j])
                {
                    excel.CelleInsert(3 + i, 1, q);
                    i++;
                }
                j++;
                i++;
            }

            excel.save();
            excel.close();
        }
    }
}
