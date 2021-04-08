namespace WorkstationTEST
{
    partial class FormReturn
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
            this.EMPPanel = new System.Windows.Forms.Panel();
            this.frmEmpRecordnow = new System.Windows.Forms.Label();
            this.frmEmpshowno = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.frmPTname = new System.Windows.Forms.TextBox();
            this.frmPTRecordT = new System.Windows.Forms.Label();
            this.PTPanel = new System.Windows.Forms.Panel();
            this.PTSavePartnerId = new System.Windows.Forms.TextBox();
            this.frmPTshowno = new System.Windows.Forms.TextBox();
            this.frmPTRecordnow = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.frmRecordnow = new System.Windows.Forms.Label();
            this.focust = new System.Windows.Forms.TextBox();
            this.RPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.frmEmpRecordT = new System.Windows.Forms.Label();
            this.EMPSave1 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtsearchbyO = new System.Windows.Forms.TextBox();
            this.labsearchbyO = new System.Windows.Forms.Label();
            this.txtsearchbyW = new System.Windows.Forms.TextBox();
            this.labsearchbyW = new System.Windows.Forms.Label();
            this.button4 = new WorkstationTEST.XButton();
            this.button3 = new WorkstationTEST.XButton();
            this.button2 = new WorkstationTEST.XButton();
            this.button1 = new WorkstationTEST.XButton();
            this.frmEmpPageU = new WorkstationTEST.XButton();
            this.frmEmpPageD = new WorkstationTEST.XButton();
            this.frmPTbtnU = new WorkstationTEST.XButton();
            this.frmPTbtnD = new WorkstationTEST.XButton();
            this.save = new WorkstationTEST.XButton();
            this.numstat = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(12, 140);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1225, 626);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.EMPPanel);
            this.tabPage1.Controls.Add(this.frmEmpPageU);
            this.tabPage1.Controls.Add(this.frmEmpPageD);
            this.tabPage1.Controls.Add(this.frmEmpRecordnow);
            this.tabPage1.Controls.Add(this.frmEmpshowno);
            this.tabPage1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage1.Location = new System.Drawing.Point(4, 42);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1217, 580);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "人員";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // EMPPanel
            // 
            this.EMPPanel.AutoScroll = true;
            this.EMPPanel.AutoScrollMinSize = new System.Drawing.Size(900, 218);
            this.EMPPanel.Location = new System.Drawing.Point(5, 55);
            this.EMPPanel.Name = "EMPPanel";
            this.EMPPanel.Size = new System.Drawing.Size(1027, 350);
            this.EMPPanel.TabIndex = 14;
            // 
            // frmEmpRecordnow
            // 
            this.frmEmpRecordnow.AutoSize = true;
            this.frmEmpRecordnow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.frmEmpRecordnow.Location = new System.Drawing.Point(1045, 335);
            this.frmEmpRecordnow.Name = "frmEmpRecordnow";
            this.frmEmpRecordnow.Size = new System.Drawing.Size(98, 12);
            this.frmEmpRecordnow.TabIndex = 15;
            this.frmEmpRecordnow.Text = "frmEmpRecordnow";
            // 
            // frmEmpshowno
            // 
            this.frmEmpshowno.Location = new System.Drawing.Point(80, 18);
            this.frmEmpshowno.Name = "frmEmpshowno";
            this.frmEmpshowno.Size = new System.Drawing.Size(100, 22);
            this.frmEmpshowno.TabIndex = 14;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.frmPTbtnU);
            this.tabPage2.Controls.Add(this.frmPTname);
            this.tabPage2.Controls.Add(this.frmPTRecordT);
            this.tabPage2.Controls.Add(this.PTPanel);
            this.tabPage2.Controls.Add(this.PTSavePartnerId);
            this.tabPage2.Controls.Add(this.frmPTshowno);
            this.tabPage2.Controls.Add(this.frmPTRecordnow);
            this.tabPage2.Controls.Add(this.frmPTbtnD);
            this.tabPage2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage2.Location = new System.Drawing.Point(4, 42);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1217, 580);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "廠商";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmPTname
            // 
            this.frmPTname.Location = new System.Drawing.Point(863, 423);
            this.frmPTname.Name = "frmPTname";
            this.frmPTname.Size = new System.Drawing.Size(100, 22);
            this.frmPTname.TabIndex = 113;
            this.frmPTname.Visible = false;
            // 
            // frmPTRecordT
            // 
            this.frmPTRecordT.AutoSize = true;
            this.frmPTRecordT.Location = new System.Drawing.Point(571, 416);
            this.frmPTRecordT.Name = "frmPTRecordT";
            this.frmPTRecordT.Size = new System.Drawing.Size(76, 12);
            this.frmPTRecordT.TabIndex = 111;
            this.frmPTRecordT.Text = "frmPTRecordT";
            this.frmPTRecordT.Visible = false;
            // 
            // PTPanel
            // 
            this.PTPanel.AutoScroll = true;
            this.PTPanel.AutoScrollMinSize = new System.Drawing.Size(900, 218);
            this.PTPanel.Location = new System.Drawing.Point(2, 53);
            this.PTPanel.Name = "PTPanel";
            this.PTPanel.Size = new System.Drawing.Size(1021, 355);
            this.PTPanel.TabIndex = 112;
            // 
            // PTSavePartnerId
            // 
            this.PTSavePartnerId.Location = new System.Drawing.Point(969, 423);
            this.PTSavePartnerId.Name = "PTSavePartnerId";
            this.PTSavePartnerId.Size = new System.Drawing.Size(100, 22);
            this.PTSavePartnerId.TabIndex = 110;
            this.PTSavePartnerId.Visible = false;
            // 
            // frmPTshowno
            // 
            this.frmPTshowno.Location = new System.Drawing.Point(6, 25);
            this.frmPTshowno.Name = "frmPTshowno";
            this.frmPTshowno.Size = new System.Drawing.Size(174, 22);
            this.frmPTshowno.TabIndex = 109;
            // 
            // frmPTRecordnow
            // 
            this.frmPTRecordnow.AutoSize = true;
            this.frmPTRecordnow.Location = new System.Drawing.Point(689, 416);
            this.frmPTRecordnow.Name = "frmPTRecordnow";
            this.frmPTRecordnow.Size = new System.Drawing.Size(89, 12);
            this.frmPTRecordnow.TabIndex = 108;
            this.frmPTRecordnow.Text = "frmPTRecordnow";
            this.frmPTRecordnow.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.numstat);
            this.tabPage3.Controls.Add(this.save);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.frmRecordnow);
            this.tabPage3.Controls.Add(this.focust);
            this.tabPage3.Controls.Add(this.RPanel);
            this.tabPage3.Location = new System.Drawing.Point(4, 42);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1217, 580);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "外包單";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("新細明體", 15F);
            this.label10.Location = new System.Drawing.Point(1003, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 999;
            this.label10.Text = "不良數";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("新細明體", 15F);
            this.label9.Location = new System.Drawing.Point(903, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 999;
            this.label9.Text = "完成數";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("新細明體", 15F);
            this.label8.Location = new System.Drawing.Point(803, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 999;
            this.label8.Text = "外包單號";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label8.Visible = false;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("新細明體", 15F);
            this.label3.Location = new System.Drawing.Point(102, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 999;
            this.label3.Text = "產品編號";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Visible = false;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("新細明體", 15F);
            this.label7.Location = new System.Drawing.Point(603, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 999;
            this.label7.Text = "外包數";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label7.Visible = false;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("新細明體", 15F);
            this.label6.Location = new System.Drawing.Point(502, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 23);
            this.label6.TabIndex = 34;
            this.label6.Text = "加工日期";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("新細明體", 15F);
            this.label5.Location = new System.Drawing.Point(202, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 999;
            this.label5.Text = "規格";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("新細明體", 15F);
            this.label4.Location = new System.Drawing.Point(301, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 23);
            this.label4.TabIndex = 999;
            this.label4.Text = "製程";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.Visible = false;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("新細明體", 15F);
            this.label2.Location = new System.Drawing.Point(703, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 999;
            this.label2.Text = "單位";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("新細明體", 15F);
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 999;
            this.label1.Text = "工令";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Visible = false;
            // 
            // frmRecordnow
            // 
            this.frmRecordnow.Location = new System.Drawing.Point(963, 313);
            this.frmRecordnow.Name = "frmRecordnow";
            this.frmRecordnow.Size = new System.Drawing.Size(89, 12);
            this.frmRecordnow.TabIndex = 28;
            this.frmRecordnow.Visible = false;
            // 
            // focust
            // 
            this.focust.Location = new System.Drawing.Point(952, 354);
            this.focust.Name = "focust";
            this.focust.Size = new System.Drawing.Size(100, 46);
            this.focust.TabIndex = 999;
            this.focust.TabStop = false;
            this.focust.Visible = false;
            // 
            // RPanel
            // 
            this.RPanel.AutoScroll = true;
            this.RPanel.AutoScrollMinSize = new System.Drawing.Size(800, 80);
            this.RPanel.ColumnCount = 13;
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RPanel.Location = new System.Drawing.Point(3, 47);
            this.RPanel.Name = "RPanel";
            this.RPanel.RowCount = 2;
            this.RPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RPanel.Size = new System.Drawing.Size(1211, 290);
            this.RPanel.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 42);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1217, 580);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "數量";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // frmEmpRecordT
            // 
            this.frmEmpRecordT.AutoSize = true;
            this.frmEmpRecordT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.frmEmpRecordT.Location = new System.Drawing.Point(327, 748);
            this.frmEmpRecordT.Name = "frmEmpRecordT";
            this.frmEmpRecordT.Size = new System.Drawing.Size(85, 12);
            this.frmEmpRecordT.TabIndex = 17;
            this.frmEmpRecordT.Text = "frmEmpRecordT";
            this.frmEmpRecordT.Visible = false;
            // 
            // EMPSave1
            // 
            this.EMPSave1.CausesValidation = false;
            this.EMPSave1.Location = new System.Drawing.Point(574, 745);
            this.EMPSave1.Name = "EMPSave1";
            this.EMPSave1.Size = new System.Drawing.Size(100, 22);
            this.EMPSave1.TabIndex = 16;
            this.EMPSave1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtsearchbyO);
            this.panel1.Controls.Add(this.labsearchbyO);
            this.panel1.Controls.Add(this.txtsearchbyW);
            this.panel1.Controls.Add(this.labsearchbyW);
            this.panel1.Location = new System.Drawing.Point(465, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 48);
            this.panel1.TabIndex = 18;
            // 
            // txtsearchbyO
            // 
            this.txtsearchbyO.Location = new System.Drawing.Point(416, 24);
            this.txtsearchbyO.Name = "txtsearchbyO";
            this.txtsearchbyO.Size = new System.Drawing.Size(100, 22);
            this.txtsearchbyO.TabIndex = 101;
            this.txtsearchbyO.TextChanged += new System.EventHandler(this.txtsearchbyO_TextChanged);
            // 
            // labsearchbyO
            // 
            this.labsearchbyO.AutoSize = true;
            this.labsearchbyO.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labsearchbyO.Location = new System.Drawing.Point(268, 25);
            this.labsearchbyO.Name = "labsearchbyO";
            this.labsearchbyO.Size = new System.Drawing.Size(142, 21);
            this.labsearchbyO.TabIndex = 999;
            this.labsearchbyO.Text = "依外包單搜尋";
            // 
            // txtsearchbyW
            // 
            this.txtsearchbyW.Location = new System.Drawing.Point(141, 25);
            this.txtsearchbyW.Name = "txtsearchbyW";
            this.txtsearchbyW.Size = new System.Drawing.Size(100, 22);
            this.txtsearchbyW.TabIndex = 100;
            this.txtsearchbyW.TextChanged += new System.EventHandler(this.txtsearchbyW_TextChanged);
            // 
            // labsearchbyW
            // 
            this.labsearchbyW.AutoSize = true;
            this.labsearchbyW.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labsearchbyW.Location = new System.Drawing.Point(14, 27);
            this.labsearchbyW.Name = "labsearchbyW";
            this.labsearchbyW.Size = new System.Drawing.Size(120, 21);
            this.labsearchbyW.TabIndex = 999;
            this.labsearchbyW.Text = "依工令搜尋";
            // 
            // button4
            // 
            this.button4.LeftText = null;
            this.button4.Location = new System.Drawing.Point(698, 9);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 19;
            this.button4.TabStop = false;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.TopText = null;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.LeftText = null;
            this.button3.Location = new System.Drawing.Point(1036, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.TabStop = false;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.TopText = null;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.LeftText = null;
            this.button2.Location = new System.Drawing.Point(341, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.TabStop = false;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.TopText = null;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.LeftText = null;
            this.button1.Location = new System.Drawing.Point(42, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.TabStop = false;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.TopText = null;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmEmpPageU
            // 
            this.frmEmpPageU.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.frmEmpPageU.LeftText = null;
            this.frmEmpPageU.Location = new System.Drawing.Point(1020, 58);
            this.frmEmpPageU.Name = "frmEmpPageU";
            this.frmEmpPageU.Size = new System.Drawing.Size(75, 23);
            this.frmEmpPageU.TabIndex = 12;
            this.frmEmpPageU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmEmpPageU.TopText = null;
            this.frmEmpPageU.UseVisualStyleBackColor = true;
            this.frmEmpPageU.Click += new System.EventHandler(this.frmEmpPageU_Click);
            // 
            // frmEmpPageD
            // 
            this.frmEmpPageD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.frmEmpPageD.LeftText = null;
            this.frmEmpPageD.Location = new System.Drawing.Point(1020, 254);
            this.frmEmpPageD.Name = "frmEmpPageD";
            this.frmEmpPageD.Size = new System.Drawing.Size(75, 23);
            this.frmEmpPageD.TabIndex = 13;
            this.frmEmpPageD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmEmpPageD.TopText = null;
            this.frmEmpPageD.UseVisualStyleBackColor = true;
            this.frmEmpPageD.Click += new System.EventHandler(this.frmEmpPageD_Click);
            // 
            // frmPTbtnU
            // 
            this.frmPTbtnU.LeftText = null;
            this.frmPTbtnU.Location = new System.Drawing.Point(1020, 62);
            this.frmPTbtnU.Name = "frmPTbtnU";
            this.frmPTbtnU.Size = new System.Drawing.Size(75, 23);
            this.frmPTbtnU.TabIndex = 114;
            this.frmPTbtnU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmPTbtnU.TopText = null;
            this.frmPTbtnU.UseVisualStyleBackColor = true;
            this.frmPTbtnU.Click += new System.EventHandler(this.frmPTbtnU_Click);
            // 
            // frmPTbtnD
            // 
            this.frmPTbtnD.LeftText = null;
            this.frmPTbtnD.Location = new System.Drawing.Point(1020, 226);
            this.frmPTbtnD.Name = "frmPTbtnD";
            this.frmPTbtnD.Size = new System.Drawing.Size(75, 23);
            this.frmPTbtnD.TabIndex = 107;
            this.frmPTbtnD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmPTbtnD.TopText = null;
            this.frmPTbtnD.UseVisualStyleBackColor = true;
            this.frmPTbtnD.Click += new System.EventHandler(this.frmPTbtnD_Click);
            // 
            // save
            // 
            this.save.LeftText = null;
            this.save.Location = new System.Drawing.Point(969, 343);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 1000;
            this.save.TabStop = false;
            this.save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.save.TopText = null;
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // numstat
            // 
            this.numstat.AutoSize = true;
            this.numstat.Location = new System.Drawing.Point(1105, 12);
            this.numstat.Name = "numstat";
            this.numstat.Size = new System.Drawing.Size(0, 32);
            this.numstat.TabIndex = 20;
            // 
            // FormReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 650);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.frmEmpRecordT);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.EMPSave1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormReturn";
            this.Text = "FormReturn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormReturn_FormClosed);
            this.Load += new System.EventHandler(this.FormReturn_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XButton button3;
        private XButton button2;
        private XButton button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private XButton frmEmpPageU;
        private XButton frmEmpPageD;
        private System.Windows.Forms.Label frmEmpRecordT;
        private System.Windows.Forms.TextBox EMPSave1;
        private System.Windows.Forms.Label frmEmpRecordnow;
        private System.Windows.Forms.Panel EMPPanel;
        private System.Windows.Forms.TextBox frmEmpshowno;
        private System.Windows.Forms.TextBox frmPTname;
        private System.Windows.Forms.Panel PTPanel;
        private System.Windows.Forms.Label frmPTRecordT;
        private System.Windows.Forms.TextBox PTSavePartnerId;
        private System.Windows.Forms.TextBox frmPTshowno;
        private System.Windows.Forms.Label frmPTRecordnow;
        private XButton frmPTbtnD;
        private XButton frmPTbtnU;
        private System.Windows.Forms.TableLayoutPanel RPanel;
        private System.Windows.Forms.TextBox focust;
        private System.Windows.Forms.Label frmRecordnow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtsearchbyO;
        private System.Windows.Forms.Label labsearchbyO;
        private System.Windows.Forms.TextBox txtsearchbyW;
        private System.Windows.Forms.Label labsearchbyW;
        private XButton button4;
        private XButton save;
        private System.Windows.Forms.Label numstat;
    }
}