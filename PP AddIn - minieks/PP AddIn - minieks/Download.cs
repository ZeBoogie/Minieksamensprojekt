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

        private void LavExcel_btn_Click(object sender, EventArgs e)
        {
            if (Sessions_lb.SelectedIndex != -1)
            {
                string valgt = Sessions_lb.SelectedItem.ToString();
                Svardata data = new Svardata();
                string mellemmand = File.ReadAllText("C:\\ProgramData\\PowerPointQuiz\\Svar\\" + valgt + ".json");
                data = JsonConvert.DeserializeObject<Svardata>(mellemmand);
                Excel excel = new Excel();
                excel.nyFil();
                excel.saveAs(@"" + valgt + ".xlsx");
                excel.CelleInsert(0, 0, "Session start:");
                excel.CelleInsert(1, 0, "Session slut:");
                excel.CelleInsert(0, 1, data.sessionStart.ToString());
                excel.CelleInsert(1, 1, data.sessionEnd.ToString());
                int i = 0;
                int j = 0;
                int k;
                foreach (string s in data.questions)
                {
                    excel.CelleInsert(3 + i, 0, s);
                    k = i;
                    foreach (string q in data.answerOptions[j])
                    {
                        excel.CelleInsert(3 + i, 1, q);
                        i++;
                    }
                    i = k;
                    foreach (bool q in data.correctAnswers[j])
                    {
                        excel.CelleInsert(3 + i, 2, q.ToString());
                        i++;
                    }
                    j++;
                    i++;
                }

                excel.nytSheet();
                excel.ChooseSheet(2);
                i = 0;
                foreach (string s in data.titlesOfQuestions)
                {
                    excel.CelleInsert(0, 1 + i, s);
                    i++;
                }

                i = 0;
                j = 0;
                foreach (string b in data.playersAndAnswers.Keys)
                {
                    excel.CelleInsert(1 + i, 0, b);
                    foreach (string c in data.playersAndAnswers[b])
                    {
                        excel.CelleInsert(1 + j, 1 + i, c);
                        j++;
                    }
                    j = 0;
                    i++;
                }

                excel.save();
                excel.close();
            }
            else
            {
                MessageBox.Show("Du skal lige vælge hvilken fil du ville konverete.", "Fil ikke valgt");
            }
        }
    }
}
