namespace PP_AddIn___minieks
{
    partial class Nyt_spaargsmaal_frm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Annuller_btn = new System.Windows.Forms.Button();
            this.OK_btn = new System.Windows.Forms.Button();
            this.Svartype_comboB = new System.Windows.Forms.ComboBox();
            this.spoergsmaal_txt = new System.Windows.Forms.TextBox();
            this.svar1_chk = new System.Windows.Forms.CheckBox();
            this.svar2_txt = new System.Windows.Forms.TextBox();
            this.svar1_txt = new System.Windows.Forms.TextBox();
            this.svar2_chk = new System.Windows.Forms.CheckBox();
            this.svar3_txt = new System.Windows.Forms.TextBox();
            this.svar3_chk = new System.Windows.Forms.CheckBox();
            this.svar4_txt = new System.Windows.Forms.TextBox();
            this.svar4_chk = new System.Windows.Forms.CheckBox();
            this.tilfoejSvar_btn = new System.Windows.Forms.Button();
            this.fjernSvar_btn = new System.Windows.Forms.Button();
            this.titel_txt = new System.Windows.Forms.TextBox();
            this.titel_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.InsertBillede1_btn = new System.Windows.Forms.Button();
            this.InsertBillede2_btn = new System.Windows.Forms.Button();
            this.InsertBillede3_btn = new System.Windows.Forms.Button();
            this.InsertBillede4_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Annuller_btn
            // 
            this.Annuller_btn.Location = new System.Drawing.Point(676, 401);
            this.Annuller_btn.Name = "Annuller_btn";
            this.Annuller_btn.Size = new System.Drawing.Size(112, 37);
            this.Annuller_btn.TabIndex = 0;
            this.Annuller_btn.Text = "Annuller";
            this.Annuller_btn.UseVisualStyleBackColor = true;
            this.Annuller_btn.Click += new System.EventHandler(this.Annuller_btn_Click);
            // 
            // OK_btn
            // 
            this.OK_btn.Location = new System.Drawing.Point(575, 401);
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.Size = new System.Drawing.Size(95, 37);
            this.OK_btn.TabIndex = 1;
            this.OK_btn.Text = "OK";
            this.OK_btn.UseVisualStyleBackColor = true;
            this.OK_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // Svartype_comboB
            // 
            this.Svartype_comboB.AccessibleDescription = "";
            this.Svartype_comboB.AccessibleName = "";
            this.Svartype_comboB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Svartype_comboB.Items.AddRange(new object[] {
            "Multiple choice",
            "Facit",
            "Prioritering",
            "Begrebsgymnastik"});
            this.Svartype_comboB.Location = new System.Drawing.Point(233, 12);
            this.Svartype_comboB.Name = "Svartype_comboB";
            this.Svartype_comboB.Size = new System.Drawing.Size(356, 28);
            this.Svartype_comboB.TabIndex = 2;
            this.Svartype_comboB.Tag = "";
            this.Svartype_comboB.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // spoergsmaal_txt
            // 
            this.spoergsmaal_txt.Location = new System.Drawing.Point(12, 78);
            this.spoergsmaal_txt.Multiline = true;
            this.spoergsmaal_txt.Name = "spoergsmaal_txt";
            this.spoergsmaal_txt.Size = new System.Drawing.Size(776, 72);
            this.spoergsmaal_txt.TabIndex = 3;
            this.spoergsmaal_txt.Text = "Skriv spørgsmål her";
            this.spoergsmaal_txt.Visible = false;
            this.spoergsmaal_txt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // svar1_chk
            // 
            this.svar1_chk.AutoSize = true;
            this.svar1_chk.Location = new System.Drawing.Point(12, 156);
            this.svar1_chk.Name = "svar1_chk";
            this.svar1_chk.Size = new System.Drawing.Size(22, 21);
            this.svar1_chk.TabIndex = 5;
            this.svar1_chk.UseVisualStyleBackColor = true;
            this.svar1_chk.Visible = false;
            this.svar1_chk.CheckedChanged += new System.EventHandler(this.svar1_chk_CheckedChanged);
            // 
            // svar2_txt
            // 
            this.svar2_txt.Location = new System.Drawing.Point(40, 188);
            this.svar2_txt.Multiline = true;
            this.svar2_txt.Name = "svar2_txt";
            this.svar2_txt.Size = new System.Drawing.Size(714, 26);
            this.svar2_txt.TabIndex = 8;
            this.svar2_txt.Text = "Skriv anden svarmulighed her";
            this.svar2_txt.Visible = false;
            this.svar2_txt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // svar1_txt
            // 
            this.svar1_txt.Location = new System.Drawing.Point(40, 156);
            this.svar1_txt.Name = "svar1_txt";
            this.svar1_txt.Size = new System.Drawing.Size(714, 26);
            this.svar1_txt.TabIndex = 9;
            this.svar1_txt.Text = "Skriv første svarmulighed her";
            this.svar1_txt.Visible = false;
            this.svar1_txt.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // svar2_chk
            // 
            this.svar2_chk.AutoSize = true;
            this.svar2_chk.Location = new System.Drawing.Point(12, 188);
            this.svar2_chk.Name = "svar2_chk";
            this.svar2_chk.Size = new System.Drawing.Size(22, 21);
            this.svar2_chk.TabIndex = 10;
            this.svar2_chk.UseVisualStyleBackColor = true;
            this.svar2_chk.Visible = false;
            this.svar2_chk.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // svar3_txt
            // 
            this.svar3_txt.Location = new System.Drawing.Point(40, 220);
            this.svar3_txt.Name = "svar3_txt";
            this.svar3_txt.Size = new System.Drawing.Size(714, 26);
            this.svar3_txt.TabIndex = 12;
            this.svar3_txt.Text = "Skriv tredje svarmulighed her";
            this.svar3_txt.Visible = false;
            this.svar3_txt.TextChanged += new System.EventHandler(this.svar3_txt_TextChanged);
            // 
            // svar3_chk
            // 
            this.svar3_chk.AutoSize = true;
            this.svar3_chk.Location = new System.Drawing.Point(12, 220);
            this.svar3_chk.Name = "svar3_chk";
            this.svar3_chk.Size = new System.Drawing.Size(22, 21);
            this.svar3_chk.TabIndex = 13;
            this.svar3_chk.UseVisualStyleBackColor = true;
            this.svar3_chk.Visible = false;
            this.svar3_chk.CheckedChanged += new System.EventHandler(this.svar3_chk_CheckedChanged);
            // 
            // svar4_txt
            // 
            this.svar4_txt.Location = new System.Drawing.Point(40, 252);
            this.svar4_txt.Name = "svar4_txt";
            this.svar4_txt.Size = new System.Drawing.Size(714, 26);
            this.svar4_txt.TabIndex = 14;
            this.svar4_txt.Text = "Skriv fjerde svarmulighed her";
            this.svar4_txt.Visible = false;
            this.svar4_txt.TextChanged += new System.EventHandler(this.svar4_txt_TextChanged);
            // 
            // svar4_chk
            // 
            this.svar4_chk.AutoSize = true;
            this.svar4_chk.Location = new System.Drawing.Point(12, 252);
            this.svar4_chk.Name = "svar4_chk";
            this.svar4_chk.Size = new System.Drawing.Size(22, 21);
            this.svar4_chk.TabIndex = 15;
            this.svar4_chk.UseVisualStyleBackColor = true;
            this.svar4_chk.Visible = false;
            this.svar4_chk.CheckedChanged += new System.EventHandler(this.svar4_chk_CheckedChanged);
            // 
            // tilfoejSvar_btn
            // 
            this.tilfoejSvar_btn.Location = new System.Drawing.Point(40, 284);
            this.tilfoejSvar_btn.Name = "tilfoejSvar_btn";
            this.tilfoejSvar_btn.Size = new System.Drawing.Size(161, 33);
            this.tilfoejSvar_btn.TabIndex = 16;
            this.tilfoejSvar_btn.Text = "Tilføj svarmulighed";
            this.tilfoejSvar_btn.UseVisualStyleBackColor = true;
            this.tilfoejSvar_btn.Visible = false;
            this.tilfoejSvar_btn.Click += new System.EventHandler(this.tilfoejSvar_btn_Click);
            // 
            // fjernSvar_btn
            // 
            this.fjernSvar_btn.Location = new System.Drawing.Point(207, 284);
            this.fjernSvar_btn.Name = "fjernSvar_btn";
            this.fjernSvar_btn.Size = new System.Drawing.Size(176, 33);
            this.fjernSvar_btn.TabIndex = 17;
            this.fjernSvar_btn.Text = "Fjern svarmulighed";
            this.fjernSvar_btn.UseVisualStyleBackColor = true;
            this.fjernSvar_btn.Visible = false;
            this.fjernSvar_btn.Click += new System.EventHandler(this.fjernSvar_btn_Click);
            // 
            // titel_txt
            // 
            this.titel_txt.Location = new System.Drawing.Point(60, 46);
            this.titel_txt.Name = "titel_txt";
            this.titel_txt.Size = new System.Drawing.Size(323, 26);
            this.titel_txt.TabIndex = 18;
            this.titel_txt.Visible = false;
            this.titel_txt.TextChanged += new System.EventHandler(this.titel_txt_TextChanged);
            // 
            // titel_lbl
            // 
            this.titel_lbl.AutoSize = true;
            this.titel_lbl.Location = new System.Drawing.Point(12, 46);
            this.titel_lbl.Name = "titel_lbl";
            this.titel_lbl.Size = new System.Drawing.Size(42, 20);
            this.titel_lbl.TabIndex = 19;
            this.titel_lbl.Text = "Titel:";
            this.titel_lbl.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(464, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(464, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(468, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "label4";
            // 
            // InsertBillede1_btn
            // 
            this.InsertBillede1_btn.Location = new System.Drawing.Point(760, 156);
            this.InsertBillede1_btn.Name = "InsertBillede1_btn";
            this.InsertBillede1_btn.Size = new System.Drawing.Size(26, 26);
            this.InsertBillede1_btn.TabIndex = 24;
            this.InsertBillede1_btn.UseVisualStyleBackColor = true;
            // 
            // InsertBillede2_btn
            // 
            this.InsertBillede2_btn.Location = new System.Drawing.Point(760, 188);
            this.InsertBillede2_btn.Name = "InsertBillede2_btn";
            this.InsertBillede2_btn.Size = new System.Drawing.Size(26, 26);
            this.InsertBillede2_btn.TabIndex = 25;
            this.InsertBillede2_btn.UseVisualStyleBackColor = true;
            // 
            // InsertBillede3_btn
            // 
            this.InsertBillede3_btn.Location = new System.Drawing.Point(760, 220);
            this.InsertBillede3_btn.Name = "InsertBillede3_btn";
            this.InsertBillede3_btn.Size = new System.Drawing.Size(26, 26);
            this.InsertBillede3_btn.TabIndex = 26;
            this.InsertBillede3_btn.UseVisualStyleBackColor = true;
            // 
            // InsertBillede4_btn
            // 
            this.InsertBillede4_btn.Location = new System.Drawing.Point(760, 252);
            this.InsertBillede4_btn.Name = "InsertBillede4_btn";
            this.InsertBillede4_btn.Size = new System.Drawing.Size(26, 26);
            this.InsertBillede4_btn.TabIndex = 27;
            this.InsertBillede4_btn.UseVisualStyleBackColor = true;
            // 
            // Nyt_spaargsmaal_frm
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InsertBillede4_btn);
            this.Controls.Add(this.InsertBillede3_btn);
            this.Controls.Add(this.InsertBillede2_btn);
            this.Controls.Add(this.InsertBillede1_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titel_lbl);
            this.Controls.Add(this.titel_txt);
            this.Controls.Add(this.fjernSvar_btn);
            this.Controls.Add(this.tilfoejSvar_btn);
            this.Controls.Add(this.svar4_chk);
            this.Controls.Add(this.svar4_txt);
            this.Controls.Add(this.svar3_chk);
            this.Controls.Add(this.svar3_txt);
            this.Controls.Add(this.svar2_chk);
            this.Controls.Add(this.svar1_txt);
            this.Controls.Add(this.svar2_txt);
            this.Controls.Add(this.svar1_chk);
            this.Controls.Add(this.spoergsmaal_txt);
            this.Controls.Add(this.Svartype_comboB);
            this.Controls.Add(this.OK_btn);
            this.Controls.Add(this.Annuller_btn);
            this.Name = "Nyt_spaargsmaal_frm";
            this.ShowIcon = false;
            this.Text = "Nyt spørgsmål";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Annuller_btn;
        private System.Windows.Forms.Button OK_btn;
        private System.Windows.Forms.ComboBox Svartype_comboB;
        private System.Windows.Forms.TextBox spoergsmaal_txt;
        private System.Windows.Forms.CheckBox svar1_chk;
        private System.Windows.Forms.TextBox svar2_txt;
        private System.Windows.Forms.TextBox svar1_txt;
        private System.Windows.Forms.CheckBox svar2_chk;
        private System.Windows.Forms.TextBox svar3_txt;
        private System.Windows.Forms.CheckBox svar3_chk;
        private System.Windows.Forms.TextBox svar4_txt;
        private System.Windows.Forms.CheckBox svar4_chk;
        private System.Windows.Forms.Button tilfoejSvar_btn;
        private System.Windows.Forms.Button fjernSvar_btn;
        private System.Windows.Forms.TextBox titel_txt;
        private System.Windows.Forms.Label titel_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button InsertBillede1_btn;
        private System.Windows.Forms.Button InsertBillede2_btn;
        private System.Windows.Forms.Button InsertBillede3_btn;
        private System.Windows.Forms.Button InsertBillede4_btn;
    }
}