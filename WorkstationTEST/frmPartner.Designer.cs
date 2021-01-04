namespace WorkstationTEST
{
    partial class frmPartner
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
            this.frmPTRecordnow = new System.Windows.Forms.Label();
            this.frmPTshowno = new System.Windows.Forms.TextBox();
            this.PTSavePartnerId = new System.Windows.Forms.TextBox();
            this.frmPTRecordT = new System.Windows.Forms.Label();
            this.PTPanel = new System.Windows.Forms.Panel();
            this.save = new WorkstationTEST.XButton();
            this.frmPTbtnD = new WorkstationTEST.XButton();
            this.frmPTbtnU = new WorkstationTEST.XButton();
            this.SuspendLayout();
            // 
            // frmPTRecordnow
            // 
            this.frmPTRecordnow.AutoSize = true;
            this.frmPTRecordnow.Location = new System.Drawing.Point(630, 576);
            this.frmPTRecordnow.Name = "frmPTRecordnow";
            this.frmPTRecordnow.Size = new System.Drawing.Size(89, 12);
            this.frmPTRecordnow.TabIndex = 7;
            this.frmPTRecordnow.Text = "frmPTRecordnow";
            this.frmPTRecordnow.Visible = false;
            // 
            // frmPTshowno
            // 
            this.frmPTshowno.Location = new System.Drawing.Point(219, 34);
            this.frmPTshowno.Name = "frmPTshowno";
            this.frmPTshowno.Size = new System.Drawing.Size(174, 22);
            this.frmPTshowno.TabIndex = 8;
            // 
            // PTSavePartnerId
            // 
            this.PTSavePartnerId.Location = new System.Drawing.Point(958, 576);
            this.PTSavePartnerId.Name = "PTSavePartnerId";
            this.PTSavePartnerId.Size = new System.Drawing.Size(100, 22);
            this.PTSavePartnerId.TabIndex = 9;
            // 
            // frmPTRecordT
            // 
            this.frmPTRecordT.AutoSize = true;
            this.frmPTRecordT.Location = new System.Drawing.Point(512, 576);
            this.frmPTRecordT.Name = "frmPTRecordT";
            this.frmPTRecordT.Size = new System.Drawing.Size(76, 12);
            this.frmPTRecordT.TabIndex = 10;
            this.frmPTRecordT.Text = "frmPTRecordT";
            this.frmPTRecordT.Visible = false;
            // 
            // PTPanel
            // 
            this.PTPanel.AutoScroll = true;
            this.PTPanel.AutoScrollMinSize = new System.Drawing.Size(900, 218);
            this.PTPanel.Location = new System.Drawing.Point(3, 62);
            this.PTPanel.Name = "PTPanel";
            this.PTPanel.Size = new System.Drawing.Size(1021, 325);
            this.PTPanel.TabIndex = 105;
            // 
            // save
            // 
            this.save.LeftText = null;
            this.save.Location = new System.Drawing.Point(1030, 143);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(86, 73);
            this.save.TabIndex = 6;
            this.save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.save.TopText = null;
            this.save.UseVisualStyleBackColor = true;
            this.save.Visible = false;
            // 
            // frmPTbtnD
            // 
            this.frmPTbtnD.LeftText = null;
            this.frmPTbtnD.Location = new System.Drawing.Point(577, 500);
            this.frmPTbtnD.Name = "frmPTbtnD";
            this.frmPTbtnD.Size = new System.Drawing.Size(75, 23);
            this.frmPTbtnD.TabIndex = 5;
            this.frmPTbtnD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmPTbtnD.TopText = null;
            this.frmPTbtnD.UseVisualStyleBackColor = true;
            this.frmPTbtnD.Click += new System.EventHandler(this.frmPTbtnD_Click);
            // 
            // frmPTbtnU
            // 
            this.frmPTbtnU.LeftText = null;
            this.frmPTbtnU.Location = new System.Drawing.Point(593, 206);
            this.frmPTbtnU.Name = "frmPTbtnU";
            this.frmPTbtnU.Size = new System.Drawing.Size(75, 23);
            this.frmPTbtnU.TabIndex = 4;
            this.frmPTbtnU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmPTbtnU.TopText = null;
            this.frmPTbtnU.UseVisualStyleBackColor = true;
            this.frmPTbtnU.Click += new System.EventHandler(this.frmPTbtnU_Click);
            // 
            // frmPartner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 645);
            this.Controls.Add(this.PTPanel);
            this.Controls.Add(this.frmPTRecordT);
            this.Controls.Add(this.PTSavePartnerId);
            this.Controls.Add(this.frmPTshowno);
            this.Controls.Add(this.frmPTRecordnow);
            this.Controls.Add(this.save);
            this.Controls.Add(this.frmPTbtnD);
            this.Controls.Add(this.frmPTbtnU);
            this.Name = "frmPartner";
            this.Text = "frmPartner";
            this.Load += new System.EventHandler(this.frmPartner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private XButton frmPTbtnU;
        private XButton save;
        private System.Windows.Forms.Label frmPTRecordnow;
        private System.Windows.Forms.TextBox frmPTshowno;
        private System.Windows.Forms.TextBox PTSavePartnerId;
        private XButton frmPTbtnD;
        private System.Windows.Forms.Label frmPTRecordT;
        private System.Windows.Forms.Panel PTPanel;
    }
}