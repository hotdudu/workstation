namespace WorkstationTEST
{
    partial class frmLog
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
            this.lstLOG = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstLOG
            // 
            this.lstLOG.BackColor = System.Drawing.Color.Cyan;
            this.lstLOG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLOG.FormattingEnabled = true;
            this.lstLOG.ItemHeight = 12;
            this.lstLOG.Location = new System.Drawing.Point(0, 0);
            this.lstLOG.Name = "lstLOG";
            this.lstLOG.ScrollAlwaysVisible = true;
            this.lstLOG.Size = new System.Drawing.Size(767, 493);
            this.lstLOG.TabIndex = 0;
            this.lstLOG.DoubleClick += new System.EventHandler(this.lstLOG_DoubleClick);
            // 
            // frmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 493);
            this.Controls.Add(this.lstLOG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Log";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstLOG;
    }
}