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
        public redigerSpoergsmaal_frm()
        {
            InitializeComponent();
        }

        private void Svartype_comboB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void redigerSpoergsmaal_frm_Load(object sender, EventArgs e)
        {
            Spoergsmaalsdata data = new Spoergsmaalsdata();
            string mellemmand = File.ReadAllText("C:\\ProgramData\\PowerPointQuiz\\" + valgt + ".json");
            data = JsonConvert.DeserializeObject<Spoergsmaalsdata>(mellemmand);
            Svartype_comboB.SelectedItem = data.type;
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Annuller_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void tilRedigering(string overf)
        {
            valgt = overf;
        }
    }
}
