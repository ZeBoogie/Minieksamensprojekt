using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PP_AddIn___minieks
{
    public partial class Nyt_spaargsmaal_frm : Form
    {
        int antalSpoergsmaal = 2;
        List<string> svarMuligheder = new List<string>();
        List<bool> korrektSvar = new List<bool>();
        List<string> billede = new List<string>();

        public Nyt_spaargsmaal_frm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Spoergsmaalsdata data = new Spoergsmaalsdata(titel_txt.Text,spoergsmaal_txt.Text, svarMuligheder, korrektSvar, billede);
            string fileName = "C:\\ProgramData\\PowerPointQuiz\\" + titel_txt.Text+".json";
            FileStream createStream = File.Create(fileName);
            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, jsonString);
            this.Close();
        }

        string tidligerespoergsmaalstype = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Svartype_comboB.SelectedItem != null)
            {
                string spoergsmaalstype = Svartype_comboB.SelectedItem.ToString();
                if (spoergsmaalstype == "Multiple choice" && tidligerespoergsmaalstype != spoergsmaalstype)
                {
                    tidligerespoergsmaalstype = spoergsmaalstype;
                    mulitpleChoice();
                }
            }
        }
        public void mulitpleChoice()
        {
            spoergsmaal_txt.Visible = true;
            titel_lbl.Visible = true;
            titel_txt.Visible = true;
            svar1_txt.Visible = true;
            svar1_chk.Visible = true;
            svar2_txt.Visible = true;
            svar2_chk.Visible = true;
            insertBillede1_btn.Visible = true;
            insertBillede2_btn.Visible = true;
            tilfoejSvar_btn.Visible = true;
            tilfoejSvar_btn.Location = new Point(40, svar3_txt.Location.Y);
            svarMuligheder.Add("banan");
            svarMuligheder.Add("gullerrod");
            korrektSvar.Add(false);
            korrektSvar.Add(false);
            label1.Text = string.Join(",", svarMuligheder);
            label2.Text = string.Join(",", korrektSvar);
        }

        private void Annuller_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            svarMuligheder[1] = svar2_txt.Text;
            label1.Text = string.Join(",", svarMuligheder);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            korrektSvar[1] = svar2_chk.Checked;
            label2.Text = string.Join(", ", korrektSvar);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            svarMuligheder[0] = svar1_txt.Text;
            label1.Text = string.Join(",", svarMuligheder);
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
            } else if (antalSpoergsmaal == 3)
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

        private void svar3_txt_TextChanged(object sender, EventArgs e)
        {
            svarMuligheder[2] = svar3_txt.Text;
            label1.Text = string.Join(",", svarMuligheder);
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
                svarMuligheder.RemoveAt(3);
                korrektSvar.RemoveAt(3);
                billede.RemoveAt(3);
            }
        }

        private void svar4_txt_TextChanged(object sender, EventArgs e)
        {
            svarMuligheder[3] = svar4_txt.Text;
            label1.Text = string.Join(",", svarMuligheder);
        }

        private void titel_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void svar1_chk_CheckedChanged(object sender, EventArgs e)
        {
            korrektSvar[0] = svar1_chk.Checked;
            label2.Text = string.Join(", ", korrektSvar);
        }

        private void svar3_chk_CheckedChanged(object sender, EventArgs e)
        {
            korrektSvar[2] = svar3_chk.Checked;
            label2.Text = string.Join(", ", korrektSvar);
        }

        private void svar4_chk_CheckedChanged(object sender, EventArgs e)
        {
            korrektSvar[3] = svar4_chk.Checked;
            label2.Text = string.Join(", ", korrektSvar);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void InsertBillede1_btn_Click(object sender, EventArgs e)
        {
            billedeHentning(0);
        }

        private void billedeHentning (int n)
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
    }
}
