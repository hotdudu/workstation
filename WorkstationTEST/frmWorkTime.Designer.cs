namespace WorkstationTEST
{
    partial class frmWorkTime
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
            System.Windows.Forms.Button frmNumbtnD;
            this.SaveStat = new System.Windows.Forms.Label();
            this.frmNumshowno = new System.Windows.Forms.TextBox();
            this.frmNumRecordnow = new System.Windows.Forms.Label();
            this.frmNumbtnU = new System.Windows.Forms.Button();
            this.NumPanel = new System.Windows.Forms.TableLayoutPanel();
            frmNumbtnD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // frmNumbtnD
            // 
            frmNumbtnD.Location = new System.Drawing.Point(548, 458);
            frmNumbtnD.Name = "frmNumbtnD";
            frmNumbtnD.Size = new System.Drawing.Size(75, 23);
            frmNumbtnD.TabIndex = 24;
            frmNumbtnD.TabStop = false;
            frmNumbtnD.Text = "frmNumbtnD";
            frmNumbtnD.UseVisualStyleBackColor = true;
            frmNumbtnD.Visible = false;
            // 
            // SaveStat
            // 
            this.SaveStat.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveStat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SaveStat.Location = new System.Drawing.Point(711, 83);
            this.SaveStat.Name = "SaveStat";
            this.SaveStat.Size = new System.Drawing.Size(164, 33);
            this.SaveStat.TabIndex = 27;
            this.SaveStat.Text = "label1";
            this.SaveStat.Visible = false;
            // 
            // frmNumshowno
            // 
            this.frmNumshowno.Location = new System.Drawing.Point(28, 47);
            this.frmNumshowno.Name = "frmNumshowno";
            this.frmNumshowno.Size = new System.Drawing.Size(174, 22);
            this.frmNumshowno.TabIndex = 26;
            this.frmNumshowno.TabStop = false;
            // 
            // frmNumRecordnow
            // 
            this.frmNumRecordnow.AutoSize = true;
            this.frmNumRecordnow.Location = new System.Drawing.Point(361, 556);
            this.frmNumRecordnow.Name = "frmNumRecordnow";
            this.frmNumRecordnow.Size = new System.Drawing.Size(99, 12);
            this.frmNumRecordnow.TabIndex = 25;
            this.frmNumRecordnow.Text = "frmNumRecordnow";
            this.frmNumRecordnow.Visible = false;
            // 
            // frmNumbtnU
            // 
            this.frmNumbtnU.Location = new System.Drawing.Point(548, 188);
            this.frmNumbtnU.Name = "frmNumbtnU";
            this.frmNumbtnU.Size = new System.Drawing.Size(75, 23);
            this.frmNumbtnU.TabIndex = 23;
            this.frmNumbtnU.TabStop = false;
            this.frmNumbtnU.Text = "frmNumbtnU";
            this.frmNumbtnU.UseVisualStyleBackColor = true;
            this.frmNumbtnU.Visible = false;
            // 
            // NumPanel
            // 
            this.NumPanel.AutoSize = true;
            this.NumPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NumPanel.ColumnCount = 4;
            this.NumPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.NumPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.NumPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.NumPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.NumPanel.Location = new System.Drawing.Point(12, 69);
            this.NumPanel.Margin = new System.Windows.Forms.Padding(1);
            this.NumPanel.Name = "NumPanel";
            this.NumPanel.RowCount = 3;
            this.NumPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.NumPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.NumPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.NumPanel.Size = new System.Drawing.Size(0, 0);
            this.NumPanel.TabIndex = 28;
            // 
            // frmWorkTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 605);
            this.Controls.Add(this.NumPanel);
            this.Controls.Add(this.SaveStat);
            this.Controls.Add(this.frmNumshowno);
            this.Controls.Add(this.frmNumRecordnow);
            this.Controls.Add(frmNumbtnD);
            this.Controls.Add(this.frmNumbtnU);
            this.Name = "frmWorkTime";
            this.Text = "frmWorkTime";
            this.Load += new System.EventHandler(this.frmWorkTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SaveStat;
        private System.Windows.Forms.TextBox frmNumshowno;
        private System.Windows.Forms.Label frmNumRecordnow;
        private System.Windows.Forms.Button frmNumbtnU;
        private System.Windows.Forms.TableLayoutPanel NumPanel;
    }
}