namespace WorkstationTEST
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.labSQLstatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labScannerStatus = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.laberror = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.txtinfo = new System.Windows.Forms.Label();
            this.empnolist = new System.Windows.Forms.ComboBox();
            this.CHT = new System.Windows.Forms.Button();
            this.EN = new System.Windows.Forms.Button();
            this.VN = new System.Windows.Forms.Button();
            this.start2 = new WorkstationTEST.XButton();
            this.ousidework = new WorkstationTEST.XButton();
            this.endwork = new WorkstationTEST.XButton();
            this.startwork = new WorkstationTEST.XButton();
            this.button2 = new System.Windows.Forms.Button();
            this.IN = new System.Windows.Forms.Button();
            this.ousideworkR = new WorkstationTEST.XButton();
            this.FItem = new WorkstationTEST.XButton();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labSQLstatus
            // 
            this.labSQLstatus.AutoSize = true;
            this.labSQLstatus.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labSQLstatus.ForeColor = System.Drawing.Color.Blue;
            this.labSQLstatus.Location = new System.Drawing.Point(624, 549);
            this.labSQLstatus.Name = "labSQLstatus";
            this.labSQLstatus.Size = new System.Drawing.Size(68, 27);
            this.labSQLstatus.TabIndex = 13;
            this.labSQLstatus.Text = "斷線";
            this.labSQLstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 25F);
            this.label2.Location = new System.Drawing.Point(501, 545);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 34);
            this.label2.TabIndex = 12;
            this.label2.Text = "資料庫:";
            // 
            // labScannerStatus
            // 
            this.labScannerStatus.AutoSize = true;
            this.labScannerStatus.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labScannerStatus.ForeColor = System.Drawing.Color.Blue;
            this.labScannerStatus.Location = new System.Drawing.Point(161, 549);
            this.labScannerStatus.Name = "labScannerStatus";
            this.labScannerStatus.Size = new System.Drawing.Size(68, 27);
            this.labScannerStatus.TabIndex = 11;
            this.labScannerStatus.Text = "斷開";
            this.labScannerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("新細明體", 25F);
            this.label23.Location = new System.Drawing.Point(38, 548);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(126, 34);
            this.label23.TabIndex = 10;
            this.label23.Text = "掃描器:";
            // 
            // laberror
            // 
            this.laberror.Location = new System.Drawing.Point(779, 548);
            this.laberror.Name = "laberror";
            this.laberror.Size = new System.Drawing.Size(353, 30);
            this.laberror.TabIndex = 14;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-2, 208);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1131, 314);
            this.dataGridView1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PaleGreen;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(-2, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 37);
            this.label1.TabIndex = 16;
            this.label1.Text = "最近100筆資料";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(194, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 34);
            this.button1.TabIndex = 17;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // txtinfo
            // 
            this.txtinfo.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtinfo.Location = new System.Drawing.Point(283, 168);
            this.txtinfo.Name = "txtinfo";
            this.txtinfo.Size = new System.Drawing.Size(195, 34);
            this.txtinfo.TabIndex = 18;
            this.txtinfo.Text = "選擇員工代號過濾";
            this.txtinfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // empnolist
            // 
            this.empnolist.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.empnolist.FormattingEnabled = true;
            this.empnolist.Location = new System.Drawing.Point(484, 168);
            this.empnolist.Name = "empnolist";
            this.empnolist.Size = new System.Drawing.Size(121, 29);
            this.empnolist.TabIndex = 19;
            this.empnolist.SelectedIndexChanged += new System.EventHandler(this.empnolist_SelectedIndexChanged);
            // 
            // CHT
            // 
            this.CHT.Location = new System.Drawing.Point(1102, 26);
            this.CHT.Name = "CHT";
            this.CHT.Size = new System.Drawing.Size(75, 23);
            this.CHT.TabIndex = 20;
            this.CHT.Text = "中文";
            this.CHT.UseVisualStyleBackColor = true;
            this.CHT.Click += new System.EventHandler(this.CHT_Click);
            // 
            // EN
            // 
            this.EN.Location = new System.Drawing.Point(1102, 63);
            this.EN.Name = "EN";
            this.EN.Size = new System.Drawing.Size(75, 23);
            this.EN.TabIndex = 21;
            this.EN.Text = "English";
            this.EN.UseVisualStyleBackColor = true;
            this.EN.Click += new System.EventHandler(this.EN_Click);
            // 
            // VN
            // 
            this.VN.Location = new System.Drawing.Point(1102, 100);
            this.VN.Name = "VN";
            this.VN.Size = new System.Drawing.Size(75, 23);
            this.VN.TabIndex = 22;
            this.VN.Text = "Tiếng Việt";
            this.VN.UseVisualStyleBackColor = true;
            this.VN.Click += new System.EventHandler(this.VN_Click);
            // 
            // start2
            // 
            this.start2.LeftText = null;
            this.start2.Location = new System.Drawing.Point(226, 12);
            this.start2.Name = "start2";
            this.start2.Size = new System.Drawing.Size(134, 113);
            this.start2.TabIndex = 23;
            this.start2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.start2.TopText = null;
            this.start2.UseVisualStyleBackColor = true;
            this.start2.Click += new System.EventHandler(this.start2_Click);
            // 
            // ousidework
            // 
            this.ousidework.LeftText = null;
            this.ousidework.Location = new System.Drawing.Point(664, 10);
            this.ousidework.Name = "ousidework";
            this.ousidework.Size = new System.Drawing.Size(132, 113);
            this.ousidework.TabIndex = 2;
            this.ousidework.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ousidework.TopText = null;
            this.ousidework.UseVisualStyleBackColor = true;
            this.ousidework.Click += new System.EventHandler(this.ousidework_Click);
            // 
            // endwork
            // 
            this.endwork.LeftText = null;
            this.endwork.Location = new System.Drawing.Point(426, 12);
            this.endwork.Name = "endwork";
            this.endwork.Size = new System.Drawing.Size(126, 113);
            this.endwork.TabIndex = 1;
            this.endwork.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.endwork.TopText = null;
            this.endwork.UseVisualStyleBackColor = true;
            this.endwork.Click += new System.EventHandler(this.endwork_Click);
            // 
            // startwork
            // 
            this.startwork.LeftText = null;
            this.startwork.Location = new System.Drawing.Point(30, 12);
            this.startwork.Name = "startwork";
            this.startwork.Size = new System.Drawing.Size(134, 113);
            this.startwork.TabIndex = 0;
            this.startwork.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.startwork.TopText = null;
            this.startwork.UseVisualStyleBackColor = true;
            this.startwork.Click += new System.EventHandler(this.startwork_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1089, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // IN
            // 
            this.IN.Location = new System.Drawing.Point(1102, 138);
            this.IN.Name = "IN";
            this.IN.Size = new System.Drawing.Size(75, 23);
            this.IN.TabIndex = 25;
            this.IN.Text = "Bahasa";
            this.IN.UseVisualStyleBackColor = true;
            this.IN.Click += new System.EventHandler(this.IN_Click);
            // 
            // ousideworkR
            // 
            this.ousideworkR.LeftText = null;
            this.ousideworkR.Location = new System.Drawing.Point(816, 10);
            this.ousideworkR.Name = "ousideworkR";
            this.ousideworkR.Size = new System.Drawing.Size(110, 113);
            this.ousideworkR.TabIndex = 26;
            this.ousideworkR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ousideworkR.TopText = null;
            this.ousideworkR.UseVisualStyleBackColor = true;
            this.ousideworkR.Click += new System.EventHandler(this.ousideworkR_Click);
            // 
            // FItem
            // 
            this.FItem.LeftText = null;
            this.FItem.Location = new System.Drawing.Point(955, 10);
            this.FItem.Name = "FItem";
            this.FItem.Size = new System.Drawing.Size(126, 113);
            this.FItem.TabIndex = 27;
            this.FItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.FItem.TopText = null;
            this.FItem.UseVisualStyleBackColor = true;
            this.FItem.Click += new System.EventHandler(this.FItem_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(629, 168);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 31);
            this.button3.TabIndex = 28;
            this.button3.Text = "顯示成品區資料";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 647);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.FItem);
            this.Controls.Add(this.ousideworkR);
            this.Controls.Add(this.IN);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.start2);
            this.Controls.Add(this.VN);
            this.Controls.Add(this.EN);
            this.Controls.Add(this.CHT);
            this.Controls.Add(this.empnolist);
            this.Controls.Add(this.txtinfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.laberror);
            this.Controls.Add(this.labSQLstatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labScannerStatus);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.ousidework);
            this.Controls.Add(this.endwork);
            this.Controls.Add(this.startwork);
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XButton startwork;
        private XButton endwork;
        private XButton ousidework;
        private System.Windows.Forms.Label labSQLstatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labScannerStatus;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label laberror;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label txtinfo;
        private System.Windows.Forms.ComboBox empnolist;
        private System.Windows.Forms.Button CHT;
        private System.Windows.Forms.Button EN;
        private System.Windows.Forms.Button VN;
        private XButton start2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button IN;
        private XButton ousideworkR;
        private XButton FItem;
        private System.Windows.Forms.Button button3;
    }
}