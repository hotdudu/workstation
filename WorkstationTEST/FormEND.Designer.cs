namespace WorkstationTEST
{
    partial class FormEND
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button3 = new WorkstationTEST.XButton();
            this.button2 = new WorkstationTEST.XButton();
            this.button1 = new WorkstationTEST.XButton();
            this.ermsg = new System.Windows.Forms.TextBox();
            this.EMPSave1 = new System.Windows.Forms.TextBox();
            this.frmEmpRecordT = new System.Windows.Forms.Label();
            this.empname = new System.Windows.Forms.TextBox();
            this.frmEmpRecordnow = new System.Windows.Forms.Label();
            this.EMPPanel = new System.Windows.Forms.Panel();
            this.frmEmpshowno = new System.Windows.Forms.TextBox();
            this.frmEmpPageU = new WorkstationTEST.XButton();
            this.frmEmpPageD = new WorkstationTEST.XButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(12, 133);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1187, 626);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.EMPSave1);
            this.tabPage1.Controls.Add(this.frmEmpRecordT);
            this.tabPage1.Controls.Add(this.empname);
            this.tabPage1.Controls.Add(this.frmEmpRecordnow);
            this.tabPage1.Controls.Add(this.EMPPanel);
            this.tabPage1.Controls.Add(this.frmEmpshowno);
            this.tabPage1.Controls.Add(this.frmEmpPageU);
            this.tabPage1.Controls.Add(this.frmEmpPageD);
            this.tabPage1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage1.Location = new System.Drawing.Point(4, 42);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1179, 580);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "人員";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage2.Location = new System.Drawing.Point(4, 42);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1179, 580);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "未結束工作";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button3
            // 
            this.button3.LeftText = null;
            this.button3.Location = new System.Drawing.Point(1043, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.TopText = null;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.LeftText = null;
            this.button2.Location = new System.Drawing.Point(548, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.TopText = null;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.LeftText = null;
            this.button1.Location = new System.Drawing.Point(49, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.TopText = null;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ermsg
            // 
            this.ermsg.BackColor = System.Drawing.SystemColors.Control;
            this.ermsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ermsg.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ermsg.ForeColor = System.Drawing.Color.Red;
            this.ermsg.Location = new System.Drawing.Point(479, 129);
            this.ermsg.Multiline = true;
            this.ermsg.Name = "ermsg";
            this.ermsg.ReadOnly = true;
            this.ermsg.Size = new System.Drawing.Size(627, 41);
            this.ermsg.TabIndex = 4;
            this.ermsg.TabStop = false;
            // 
            // EMPSave1
            // 
            this.EMPSave1.CausesValidation = false;
            this.EMPSave1.Location = new System.Drawing.Point(930, 437);
            this.EMPSave1.Name = "EMPSave1";
            this.EMPSave1.Size = new System.Drawing.Size(100, 22);
            this.EMPSave1.TabIndex = 23;
            this.EMPSave1.Visible = false;
            // 
            // frmEmpRecordT
            // 
            this.frmEmpRecordT.AutoSize = true;
            this.frmEmpRecordT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.frmEmpRecordT.Location = new System.Drawing.Point(654, 447);
            this.frmEmpRecordT.Name = "frmEmpRecordT";
            this.frmEmpRecordT.Size = new System.Drawing.Size(85, 12);
            this.frmEmpRecordT.TabIndex = 24;
            this.frmEmpRecordT.Text = "frmEmpRecordT";
            this.frmEmpRecordT.Visible = false;
            // 
            // empname
            // 
            this.empname.CausesValidation = false;
            this.empname.Location = new System.Drawing.Point(786, 444);
            this.empname.Name = "empname";
            this.empname.Size = new System.Drawing.Size(100, 22);
            this.empname.TabIndex = 25;
            this.empname.Visible = false;
            // 
            // frmEmpRecordnow
            // 
            this.frmEmpRecordnow.AutoSize = true;
            this.frmEmpRecordnow.Location = new System.Drawing.Point(24, 454);
            this.frmEmpRecordnow.Name = "frmEmpRecordnow";
            this.frmEmpRecordnow.Size = new System.Drawing.Size(98, 12);
            this.frmEmpRecordnow.TabIndex = 20;
            this.frmEmpRecordnow.Text = "frmEmpRecordnow";
            this.frmEmpRecordnow.Visible = false;
            // 
            // EMPPanel
            // 
            this.EMPPanel.AutoScrollMinSize = new System.Drawing.Size(900, 218);
            this.EMPPanel.Location = new System.Drawing.Point(3, 38);
            this.EMPPanel.Name = "EMPPanel";
            this.EMPPanel.Size = new System.Drawing.Size(1027, 350);
            this.EMPPanel.TabIndex = 19;
            // 
            // frmEmpshowno
            // 
            this.frmEmpshowno.Location = new System.Drawing.Point(196, 7);
            this.frmEmpshowno.Name = "frmEmpshowno";
            this.frmEmpshowno.Size = new System.Drawing.Size(100, 22);
            this.frmEmpshowno.TabIndex = 18;
            // 
            // frmEmpPageU
            // 
            this.frmEmpPageU.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.frmEmpPageU.LeftText = null;
            this.frmEmpPageU.Location = new System.Drawing.Point(1036, 94);
            this.frmEmpPageU.Name = "frmEmpPageU";
            this.frmEmpPageU.Size = new System.Drawing.Size(75, 23);
            this.frmEmpPageU.TabIndex = 21;
            this.frmEmpPageU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmEmpPageU.TopText = null;
            this.frmEmpPageU.UseVisualStyleBackColor = true;
            // 
            // frmEmpPageD
            // 
            this.frmEmpPageD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.frmEmpPageD.LeftText = null;
            this.frmEmpPageD.Location = new System.Drawing.Point(1036, 365);
            this.frmEmpPageD.Name = "frmEmpPageD";
            this.frmEmpPageD.Size = new System.Drawing.Size(75, 23);
            this.frmEmpPageD.TabIndex = 22;
            this.frmEmpPageD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmEmpPageD.TopText = null;
            this.frmEmpPageD.UseVisualStyleBackColor = true;
            // 
            // FormEND
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 650);
            this.Controls.Add(this.ermsg);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormEND";
            this.Text = "FormEND";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormEND_FormClosed);
            this.Load += new System.EventHandler(this.FormEND_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.IO.Ports.SerialPort serialPort1;
        private XButton button1;
        private XButton button2;
        private XButton button3;
        private System.Windows.Forms.TextBox ermsg;
        private System.Windows.Forms.TextBox EMPSave1;
        private System.Windows.Forms.Label frmEmpRecordT;
        private System.Windows.Forms.TextBox empname;
        private System.Windows.Forms.Label frmEmpRecordnow;
        private System.Windows.Forms.Panel EMPPanel;
        private System.Windows.Forms.TextBox frmEmpshowno;
        private XButton frmEmpPageU;
        private XButton frmEmpPageD;
    }
}