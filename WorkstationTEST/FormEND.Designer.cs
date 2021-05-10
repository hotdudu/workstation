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
            this.EMPSave1 = new System.Windows.Forms.TextBox();
            this.frmEmpRecordT = new System.Windows.Forms.Label();
            this.empname = new System.Windows.Forms.TextBox();
            this.frmEmpRecordnow = new System.Windows.Forms.Label();
            this.EMPPanel = new System.Windows.Forms.Panel();
            this.frmEmpshowno = new System.Windows.Forms.TextBox();
            this.frmEmpPageU = new WorkstationTEST.XButton();
            this.frmEmpPageD = new WorkstationTEST.XButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RECsearch = new System.Windows.Forms.TextBox();
            this.focust = new System.Windows.Forms.TextBox();
            this.emptydata = new System.Windows.Forms.Label();
            this.frmRecTotal = new System.Windows.Forms.Label();
            this.frmREno = new System.Windows.Forms.TextBox();
            this.frmPTRecordnow = new System.Windows.Forms.Label();
            this.NumPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RPanel = new System.Windows.Forms.TableLayoutPanel();
            this.next = new WorkstationTEST.XButton();
            this.save = new WorkstationTEST.XButton();
            this.frmPTbtnD = new WorkstationTEST.XButton();
            this.frmPTbtnU = new WorkstationTEST.XButton();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.ermsg = new System.Windows.Forms.TextBox();
            this.button3 = new WorkstationTEST.XButton();
            this.button2 = new WorkstationTEST.XButton();
            this.button1 = new WorkstationTEST.XButton();
            this.nowrecord2 = new System.Windows.Forms.Label();
            this.cqty = new System.Windows.Forms.Label();
            this.totalcount2 = new System.Windows.Forms.Label();
            this.tqty = new System.Windows.Forms.Label();
            this.totalcount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.EMPPanel.AutoScroll = true;
            this.EMPPanel.AutoScrollMinSize = new System.Drawing.Size(900, 218);
            this.EMPPanel.Location = new System.Drawing.Point(3, 38);
            this.EMPPanel.Name = "EMPPanel";
            this.EMPPanel.Size = new System.Drawing.Size(1027, 350);
            this.EMPPanel.TabIndex = 19;
            // 
            // frmEmpshowno
            // 
            this.frmEmpshowno.AcceptsReturn = true;
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
            this.frmEmpPageU.Click += new System.EventHandler(this.frmEmpPageU_Click);
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
            this.frmEmpPageD.Click += new System.EventHandler(this.frmEmpPageD_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.nowrecord2);
            this.tabPage2.Controls.Add(this.cqty);
            this.tabPage2.Controls.Add(this.totalcount2);
            this.tabPage2.Controls.Add(this.tqty);
            this.tabPage2.Controls.Add(this.totalcount);
            this.tabPage2.Controls.Add(this.RECsearch);
            this.tabPage2.Controls.Add(this.focust);
            this.tabPage2.Controls.Add(this.emptydata);
            this.tabPage2.Controls.Add(this.frmRecTotal);
            this.tabPage2.Controls.Add(this.frmREno);
            this.tabPage2.Controls.Add(this.frmPTRecordnow);
            this.tabPage2.Controls.Add(this.NumPanel);
            this.tabPage2.Controls.Add(this.RPanel);
            this.tabPage2.Controls.Add(this.next);
            this.tabPage2.Controls.Add(this.save);
            this.tabPage2.Controls.Add(this.frmPTbtnD);
            this.tabPage2.Controls.Add(this.frmPTbtnU);
            this.tabPage2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage2.Location = new System.Drawing.Point(4, 42);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1179, 580);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "未結束工作";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // RECsearch
            // 
            this.RECsearch.Location = new System.Drawing.Point(732, 4);
            this.RECsearch.Name = "RECsearch";
            this.RECsearch.Size = new System.Drawing.Size(100, 22);
            this.RECsearch.TabIndex = 37;
            // 
            // focust
            // 
            this.focust.Location = new System.Drawing.Point(951, 527);
            this.focust.Name = "focust";
            this.focust.Size = new System.Drawing.Size(100, 22);
            this.focust.TabIndex = 36;
            this.focust.Visible = false;
            // 
            // emptydata
            // 
            this.emptydata.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.emptydata.Location = new System.Drawing.Point(377, 34);
            this.emptydata.Name = "emptydata";
            this.emptydata.Size = new System.Drawing.Size(174, 34);
            this.emptydata.TabIndex = 35;
            this.emptydata.Text = "目前無資料";
            this.emptydata.Visible = false;
            // 
            // frmRecTotal
            // 
            this.frmRecTotal.AutoSize = true;
            this.frmRecTotal.Location = new System.Drawing.Point(949, 252);
            this.frmRecTotal.Name = "frmRecTotal";
            this.frmRecTotal.Size = new System.Drawing.Size(33, 12);
            this.frmRecTotal.TabIndex = 33;
            this.frmRecTotal.Text = "label8";
            this.frmRecTotal.Visible = false;
            // 
            // frmREno
            // 
            this.frmREno.Location = new System.Drawing.Point(510, 4);
            this.frmREno.Name = "frmREno";
            this.frmREno.ReadOnly = true;
            this.frmREno.Size = new System.Drawing.Size(100, 22);
            this.frmREno.TabIndex = 31;
            // 
            // frmPTRecordnow
            // 
            this.frmPTRecordnow.AutoSize = true;
            this.frmPTRecordnow.Location = new System.Drawing.Point(893, 273);
            this.frmPTRecordnow.Name = "frmPTRecordnow";
            this.frmPTRecordnow.Size = new System.Drawing.Size(89, 12);
            this.frmPTRecordnow.TabIndex = 30;
            this.frmPTRecordnow.Text = "frmPTRecordnow";
            this.frmPTRecordnow.Visible = false;
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
            this.NumPanel.Location = new System.Drawing.Point(7, 200);
            this.NumPanel.Name = "NumPanel";
            this.NumPanel.RowCount = 3;
            this.NumPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.NumPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.NumPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.NumPanel.Size = new System.Drawing.Size(0, 0);
            this.NumPanel.TabIndex = 21;
            // 
            // RPanel
            // 
            this.RPanel.AutoSize = true;
            this.RPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RPanel.ColumnCount = 13;
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.RPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.RPanel.Location = new System.Drawing.Point(7, 50);
            this.RPanel.Name = "RPanel";
            this.RPanel.RowCount = 2;
            this.RPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RPanel.Size = new System.Drawing.Size(1300, 0);
            this.RPanel.TabIndex = 4;
            // 
            // next
            // 
            this.next.LeftText = null;
            this.next.Location = new System.Drawing.Point(869, 418);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(75, 23);
            this.next.TabIndex = 34;
            this.next.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.next.TopText = null;
            this.next.UseVisualStyleBackColor = false;
            // 
            // save
            // 
            this.save.LeftText = null;
            this.save.Location = new System.Drawing.Point(869, 200);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 32;
            this.save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.save.TopText = null;
            this.save.UseVisualStyleBackColor = false;
            // 
            // frmPTbtnD
            // 
            this.frmPTbtnD.LeftText = null;
            this.frmPTbtnD.Location = new System.Drawing.Point(1074, 418);
            this.frmPTbtnD.Name = "frmPTbtnD";
            this.frmPTbtnD.Size = new System.Drawing.Size(75, 23);
            this.frmPTbtnD.TabIndex = 29;
            this.frmPTbtnD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmPTbtnD.TopText = null;
            this.frmPTbtnD.UseVisualStyleBackColor = true;
            this.frmPTbtnD.Click += new System.EventHandler(this.frmPTbtnD_Click);
            // 
            // frmPTbtnU
            // 
            this.frmPTbtnU.LeftText = null;
            this.frmPTbtnU.Location = new System.Drawing.Point(1074, 200);
            this.frmPTbtnU.Name = "frmPTbtnU";
            this.frmPTbtnU.Size = new System.Drawing.Size(75, 23);
            this.frmPTbtnU.TabIndex = 28;
            this.frmPTbtnU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmPTbtnU.TopText = null;
            this.frmPTbtnU.UseVisualStyleBackColor = true;
            this.frmPTbtnU.Click += new System.EventHandler(this.frmPTbtnU_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
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
            // nowrecord2
            // 
            this.nowrecord2.AutoSize = true;
            this.nowrecord2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.nowrecord2.ForeColor = System.Drawing.Color.ForestGreen;
            this.nowrecord2.Location = new System.Drawing.Point(1173, 14);
            this.nowrecord2.Name = "nowrecord2";
            this.nowrecord2.Size = new System.Drawing.Size(0, 19);
            this.nowrecord2.TabIndex = 42;
            // 
            // cqty
            // 
            this.cqty.AutoSize = true;
            this.cqty.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cqty.ForeColor = System.Drawing.Color.ForestGreen;
            this.cqty.Location = new System.Drawing.Point(1158, 11);
            this.cqty.Name = "cqty";
            this.cqty.Size = new System.Drawing.Size(0, 19);
            this.cqty.TabIndex = 41;
            // 
            // totalcount2
            // 
            this.totalcount2.AutoSize = true;
            this.totalcount2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.totalcount2.ForeColor = System.Drawing.Color.ForestGreen;
            this.totalcount2.Location = new System.Drawing.Point(974, 15);
            this.totalcount2.Name = "totalcount2";
            this.totalcount2.Size = new System.Drawing.Size(0, 19);
            this.totalcount2.TabIndex = 40;
            // 
            // tqty
            // 
            this.tqty.AutoSize = true;
            this.tqty.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tqty.ForeColor = System.Drawing.Color.ForestGreen;
            this.tqty.Location = new System.Drawing.Point(925, 15);
            this.tqty.Name = "tqty";
            this.tqty.Size = new System.Drawing.Size(0, 19);
            this.tqty.TabIndex = 39;
            // 
            // totalcount
            // 
            this.totalcount.AutoSize = true;
            this.totalcount.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.totalcount.ForeColor = System.Drawing.Color.ForestGreen;
            this.totalcount.Location = new System.Drawing.Point(868, 14);
            this.totalcount.Name = "totalcount";
            this.totalcount.Size = new System.Drawing.Size(0, 19);
            this.totalcount.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(626, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 43;
            this.label8.Text = "搜尋:";
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel RPanel;
        private System.Windows.Forms.TableLayoutPanel NumPanel;
        private System.Windows.Forms.TextBox RECsearch;
        private System.Windows.Forms.TextBox focust;
        private System.Windows.Forms.Label emptydata;
        private XButton next;
        private System.Windows.Forms.Label frmRecTotal;
        private XButton save;
        private System.Windows.Forms.TextBox frmREno;
        private System.Windows.Forms.Label frmPTRecordnow;
        private XButton frmPTbtnD;
        private XButton frmPTbtnU;
        private System.Windows.Forms.Label nowrecord2;
        private System.Windows.Forms.Label cqty;
        private System.Windows.Forms.Label totalcount2;
        private System.Windows.Forms.Label tqty;
        private System.Windows.Forms.Label totalcount;
        private System.Windows.Forms.Label label8;
    }
}