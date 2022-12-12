namespace PP_AddIn___minieks
{
    partial class Spoergsmaalsstyring_frm
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
            System.Windows.Forms.Button OK_btn;
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Ny_btn = new System.Windows.Forms.Button();
            this.Redigering_btn = new System.Windows.Forms.Button();
            this.Slet_btn = new System.Windows.Forms.Button();
            this.Annuller_btn = new System.Windows.Forms.Button();
            OK_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(138, 50);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(339, 244);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Ny_btn
            // 
            this.Ny_btn.Location = new System.Drawing.Point(138, 300);
            this.Ny_btn.Name = "Ny_btn";
            this.Ny_btn.Size = new System.Drawing.Size(70, 41);
            this.Ny_btn.TabIndex = 1;
            this.Ny_btn.Text = "Ny";
            this.Ny_btn.UseVisualStyleBackColor = true;
            this.Ny_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Redigering_btn
            // 
            this.Redigering_btn.Location = new System.Drawing.Point(214, 300);
            this.Redigering_btn.Name = "Redigering_btn";
            this.Redigering_btn.Size = new System.Drawing.Size(91, 41);
            this.Redigering_btn.TabIndex = 2;
            this.Redigering_btn.Text = "Rediger";
            this.Redigering_btn.UseVisualStyleBackColor = true;
            // 
            // Slet_btn
            // 
            this.Slet_btn.Location = new System.Drawing.Point(311, 300);
            this.Slet_btn.Name = "Slet_btn";
            this.Slet_btn.Size = new System.Drawing.Size(79, 41);
            this.Slet_btn.TabIndex = 3;
            this.Slet_btn.Text = "Slet";
            this.Slet_btn.UseVisualStyleBackColor = true;
            this.Slet_btn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Annuller_btn
            // 
            this.Annuller_btn.Location = new System.Drawing.Point(483, 397);
            this.Annuller_btn.Name = "Annuller_btn";
            this.Annuller_btn.Size = new System.Drawing.Size(117, 41);
            this.Annuller_btn.TabIndex = 4;
            this.Annuller_btn.Text = "Annuller";
            this.Annuller_btn.UseVisualStyleBackColor = true;
            this.Annuller_btn.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // OK_btn
            // 
            OK_btn.Location = new System.Drawing.Point(385, 397);
            OK_btn.Name = "OK_btn";
            OK_btn.Size = new System.Drawing.Size(92, 41);
            OK_btn.TabIndex = 5;
            OK_btn.Text = "OK";
            OK_btn.UseVisualStyleBackColor = true;
            OK_btn.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // Spoergsmaalsstyring_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 450);
            this.Controls.Add(OK_btn);
            this.Controls.Add(this.Annuller_btn);
            this.Controls.Add(this.Slet_btn);
            this.Controls.Add(this.Redigering_btn);
            this.Controls.Add(this.Ny_btn);
            this.Controls.Add(this.listBox1);
            this.Name = "Spoergsmaalsstyring_frm";
            this.ShowIcon = false;
            this.Text = "Spørgsmålsstyring";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Ny_btn;
        private System.Windows.Forms.Button Redigering_btn;
        private System.Windows.Forms.Button Slet_btn;
        private System.Windows.Forms.Button Annuller_btn;
    }
}