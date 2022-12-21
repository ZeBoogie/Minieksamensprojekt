namespace PP_AddIn___minieks
{
    partial class Download_frm
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
            this.Sessions_lb = new System.Windows.Forms.ListBox();
            this.LavExcel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Sessions_lb
            // 
            this.Sessions_lb.FormattingEnabled = true;
            this.Sessions_lb.ItemHeight = 20;
            this.Sessions_lb.Location = new System.Drawing.Point(12, 12);
            this.Sessions_lb.Name = "Sessions_lb";
            this.Sessions_lb.Size = new System.Drawing.Size(212, 424);
            this.Sessions_lb.TabIndex = 0;
            // 
            // LavExcel_btn
            // 
            this.LavExcel_btn.Location = new System.Drawing.Point(454, 194);
            this.LavExcel_btn.Name = "LavExcel_btn";
            this.LavExcel_btn.Size = new System.Drawing.Size(128, 71);
            this.LavExcel_btn.TabIndex = 1;
            this.LavExcel_btn.Text = "Lav Excel";
            this.LavExcel_btn.UseVisualStyleBackColor = true;
            this.LavExcel_btn.Click += new System.EventHandler(this.LavExcel_btn_Click);
            // 
            // Download_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LavExcel_btn);
            this.Controls.Add(this.Sessions_lb);
            this.Name = "Download_frm";
            this.ShowIcon = false;
            this.Text = "Download sessions";
            this.Load += new System.EventHandler(this.Download_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Sessions_lb;
        private System.Windows.Forms.Button LavExcel_btn;
    }
}