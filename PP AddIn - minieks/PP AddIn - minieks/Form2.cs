using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PP_AddIn___minieks
{
    public partial class Nyt_spaargsmaal_frm : Form
    {
        int antalSpoergsmaal = 2;
        string titel;
        string spoergsmaal;
        ArrayList svarMuligheder;
        ArrayList korrektSvar;

        public Nyt_spaargsmaal_frm()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Svartype_comboB.SelectedItem != null)
            {
                string spoergsmaalstype = Svartype_comboB.SelectedItem.ToString();
                 if (spoergsmaalstype == "Multiple choice")
                {
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
            tilfoejSvar_btn.Visible = true;
            tilfoejSvar_btn.Location = new Point(40, svar3_txt.Location.Y);
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

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tilfoejSvar_btn_Click(object sender, EventArgs e)
        {
            if (antalSpoergsmaal == 2)
            {
                antalSpoergsmaal = 3;
                svar3_chk.Visible = true;
                svar3_txt.Visible = true;
                fjernSvar_btn.Visible = true;
                tilfoejSvar_btn.Location = new Point(40, svar4_txt.Location.Y);
                fjernSvar_btn.Location = new Point(207, svar4_txt.Location.Y);
            } else if (antalSpoergsmaal == 3)
            {
                antalSpoergsmaal = 4;
                svar4_chk.Visible = true;
                svar4_txt.Visible = true;
                tilfoejSvar_btn.Visible = false;
                fjernSvar_btn.Location = new Point(207, 284);
            }
        }

        private void svar3_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void fjernSvar_btn_Click(object sender, EventArgs e)
        {
            if (antalSpoergsmaal == 3)
            {
                antalSpoergsmaal = 2;
                svar3_chk.Visible = false;
                svar3_txt.Visible = false;
                fjernSvar_btn.Visible = false;
                tilfoejSvar_btn.Location = new Point(40, svar3_txt.Location.Y);
            }
            else if (antalSpoergsmaal == 4)
            {
                antalSpoergsmaal = 3;
                svar4_chk.Visible = false;
                svar4_txt.Visible = false;
                tilfoejSvar_btn.Visible = true;
                fjernSvar_btn.Location = new Point(207, svar4_txt.Location.Y);
            }
        }
    }
}
