﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PP_AddIn___minieks
{
    public partial class Spoergsmaalsstyring_frm : Form
    {
        public Spoergsmaalsstyring_frm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myForm = new Nyt_spaargsmaal_frm();
            myForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = "C:\\ProgramData\\PowerPointQuiz";
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles();
            foreach (FileInfo file in Files)
            {
                string  navn = file.Name;
                navn = navn.Remove(navn.Length - 5, 5);
                Spoergsmaalsliste_lb.Items.Add(navn);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
