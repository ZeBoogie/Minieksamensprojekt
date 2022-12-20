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
using Newtonsoft.Json;

namespace PP_AddIn___minieks
{
    public partial class redigerSpoergsmaal_frm : Form
    {
        string valgt = "";
        string tidligereTitel = "";
        int antalSpoergsmaal;
        List<string> svarMuligheder = new List<string>();
        List<bool> korrektSvar = new List<bool>();
        List<string> billede = new List<string>();
        public redigerSpoergsmaal_frm()
        {
            InitializeComponent();
        }

        string tidligerespoergsmaalstype = "";
        private void Svartype_comboB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Svartype_comboB.SelectedItem != null)
            {
                string spoergsmaalstype = Svartype_comboB.SelectedItem.ToString();
                if (spoergsmaalstype == "Multiple choice" && tidligerespoergsmaalstype != spoergsmaalstype)
                {
                    tidligerespoergsmaalstype = spoergsmaalstype;
                }
            }
        }

        private void redigerSpoergsmaal_frm_Load(object sender, EventArgs e)
        {
            Spoergsmaalsdata data = new Spoergsmaalsdata();
            string mellemmand = File.ReadAllText("C:\\ProgramData\\PowerPointQuiz\\" + valgt + ".json");
            data = JsonConvert.DeserializeObject<Spoergsmaalsdata>(mellemmand);
            Svartype_comboB.SelectedItem = data.type;
            antalSpoergsmaal = data.svarMuligheder.Count; 
            spoergsmaal_txt.Visible = true;
            spoergsmaal_txt.Text = data.spoergsmaal;
            titel_lbl.Visible = true;
            titel_txt.Visible = true;
            titel_txt.Text = data.titel;
            tidligereTitel = data.titel;
            
            svar1_txt.Visible = true;
            svarMuligheder.Add(data.svarMuligheder[0]);
            svar1_txt.Text = data.svarMuligheder[0];
            svar1_chk.Visible = true;
            korrektSvar.Add(data.korrektSvar[0]);
            svar1_chk.Checked = data.korrektSvar[0];

            svar2_txt.Visible = true;
            svarMuligheder.Add(data.svarMuligheder[1]);
            svar2_txt.Text = data.svarMuligheder[1];
            svar2_chk.Visible = true;
            korrektSvar.Add(data.korrektSvar[1]);
            svar2_chk.Checked = data.korrektSvar[1];

            insertBillede1_btn.Visible = true;
            insertBillede2_btn.Visible = true;
            billede.Add(data.billeder[0]);
            billede.Add(data.billeder[1]);
            tilfoejSvar_btn.Visible = true;
            tilfoejSvar_btn.Location = new Point(40, svar3_txt.Location.Y);
            
            if (antalSpoergsmaal == 3)
            {
                svar3_chk.Visible = true;
                korrektSvar.Add(data.korrektSvar[2]);
                svar3_chk.Checked = data.korrektSvar[2];
                svar3_txt.Visible = true;
                svarMuligheder.Add(data.svarMuligheder[2]);
                svar3_txt.Text = data.svarMuligheder[2];
                insertBillede3_btn.Visible = true;
                billede.Add(data.billeder[2]);
                fjernSvar_btn.Visible = true;
                tilfoejSvar_btn.Location = new Point(40, svar4_txt.Location.Y);
                fjernSvar_btn.Location = new Point(207, svar4_txt.Location.Y);
            } else if (antalSpoergsmaal == 4)
            {
				svar3_chk.Visible = true;
				korrektSvar.Add(data.korrektSvar[2]);
				svar3_chk.Checked = data.korrektSvar[2];
				svar3_txt.Visible = true;
				svarMuligheder.Add(data.svarMuligheder[2]);
				svar3_txt.Text = data.svarMuligheder[2];
				insertBillede3_btn.Visible = true;
				billede.Add(data.billeder[2]);
				fjernSvar_btn.Visible = true;
				svar4_chk.Visible = true;
                korrektSvar.Add(data.korrektSvar[3]);
                svar4_chk.Checked = data.korrektSvar[3];
                svar4_txt.Visible = true;
                svarMuligheder.Add(data.svarMuligheder[3]);
                svar4_txt.Text = data.svarMuligheder[3];
                insertBillede4_btn.Visible = true;
                billede.Add(data.billeder[3]);
                tilfoejSvar_btn.Visible = false;
                fjernSvar_btn.Location = new Point(207, 284);
            }
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            string fileName = "C:\\ProgramData\\PowerPointQuiz\\" + titel_txt.Text + ".json";
            bool preExist = false;
            if (titel_txt.Text != "")
            {
                string path = "C:\\ProgramData\\PowerPointQuiz";
                DirectoryInfo d = new DirectoryInfo(path);
                FileInfo[] Files = d.GetFiles();
                foreach (FileInfo file in Files)
                {
                    if (titel_txt.Text + ".json" == file.Name)
                    {
                        preExist = true;
                    }
                }

                if (titel_txt.Text == tidligereTitel)
                {
                    preExist = false;
                }

                if (preExist == false)
                {
                    File.Delete("C:\\ProgramData\\PowerPointQuiz\\" + tidligereTitel + ".json");
                    Spoergsmaalsdata data = new Spoergsmaalsdata(titel_txt.Text, spoergsmaal_txt.Text, svarMuligheder, korrektSvar, billede, Svartype_comboB.Text);
                    string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
                    File.WriteAllText(fileName, jsonString);
                    this.Close();
                } else
                {
                    MessageBox.Show("Spørgsmålets titel eksisterer allerede.", "Forkert titel");
                }
            } else
            {
                MessageBox.Show("Der skal være en titel.", "Manglende titel");
            }
        }

        private void Annuller_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void tilRedigering(string overf)
        {
            valgt = overf;
        }

        private void svar3_txt_TextChanged(object sender, EventArgs e)
        {
            svarMuligheder[2] = svar3_txt.Text;
        }

        private void svar1_txt_TextChanged(object sender, EventArgs e)
        {
            svarMuligheder[0] = svar1_txt.Text;
        }

        private void svar2_txt_TextChanged(object sender, EventArgs e)
        {
            svarMuligheder[1] = svar2_txt.Text;
        }

        private void svar4_txt_TextChanged(object sender, EventArgs e)
        {
            svarMuligheder[3] = svar4_txt.Text;
        }

        private void tilfoejSvar_btn_Click(object sender, EventArgs e)
        {
            if (antalSpoergsmaal == 2)
            {
                antalSpoergsmaal = 3;
                svar3_chk.Visible = true;
                svar3_txt.Visible = true;
                insertBillede3_btn.Visible = true;
                fjernSvar_btn.Visible = true;
                tilfoejSvar_btn.Location = new Point(40, svar4_txt.Location.Y);
                fjernSvar_btn.Location = new Point(207, svar4_txt.Location.Y);
                svarMuligheder.Add("");
                korrektSvar.Add(svar3_chk.Checked);
                billede.Add("");
            }
            else if (antalSpoergsmaal == 3)
            {
                antalSpoergsmaal = 4;
                svar4_chk.Visible = true;
                svar4_txt.Visible = true;
                insertBillede4_btn.Visible = true;
                tilfoejSvar_btn.Visible = false;
                fjernSvar_btn.Location = new Point(207, 284);
                svarMuligheder.Add("");
                billede.Add("");
                korrektSvar.Add(svar4_chk.Checked);
            }
        }

        private void svar1_chk_CheckedChanged(object sender, EventArgs e)
        {
            korrektSvar[0] = svar1_chk.Checked;
        }

        private void svar2_chk_CheckedChanged(object sender, EventArgs e)
        {
            korrektSvar[1] = svar2_chk.Checked;
        }

        private void svar3_chk_CheckedChanged(object sender, EventArgs e)
        {
            korrektSvar[2] = svar3_chk.Checked;
        }

        private void svar4_chk_CheckedChanged(object sender, EventArgs e)
        {
            korrektSvar[3] = svar4_chk.Checked;
        }

        private void billedeHentning(int n)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\Pictures";
                openFileDialog.Filter = "HTML files (*.webp)|*.webp|PNG files (*.png)|*.png||JPEG files(*.jpg)|*.jpg|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    billede[n] = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
        }

        private void insertBillede1_btn_Click(object sender, EventArgs e)
        {
            billedeHentning(0);
        }

        private void insertBillede2_btn_Click(object sender, EventArgs e)
        {
            billedeHentning(1);
        }

        private void insertBillede3_btn_Click(object sender, EventArgs e)
        {
            billedeHentning(2);
        }

        private void insertBillede4_btn_Click(object sender, EventArgs e)
        {
            billedeHentning(3);
        }

        private void fjernSvar_btn_Click(object sender, EventArgs e)
        {
            if (antalSpoergsmaal == 3)
            {
                antalSpoergsmaal = 2;
                svar3_chk.Visible = false;
                svar3_txt.Visible = false;
                insertBillede3_btn.Visible = false;
                fjernSvar_btn.Visible = false;
                tilfoejSvar_btn.Location = new Point(40, svar3_txt.Location.Y);
                svarMuligheder.RemoveAt(2);
                korrektSvar.RemoveAt(2);
                billede.RemoveAt(2);
            }
            else if (antalSpoergsmaal == 4)
            {
                antalSpoergsmaal = 3;
                svar4_chk.Visible = false;
                svar4_txt.Visible = false;
                insertBillede4_btn.Visible = false;
                tilfoejSvar_btn.Visible = true;
                fjernSvar_btn.Location = new Point(207, svar4_txt.Location.Y);
                tilfoejSvar_btn.Location = new Point(40, svar4_txt.Location.Y);

                svarMuligheder.RemoveAt(3);
                korrektSvar.RemoveAt(3);
                billede.RemoveAt(3);
            }
        }
    }
}
