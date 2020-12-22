namespace WorkstationTEST
{
    partial class frmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtUnfinishQty = new System.Windows.Forms.TextBox();
            this.txtBadQty = new System.Windows.Forms.TextBox();
            this.labUnfinishQty = new System.Windows.Forms.Label();
            this.labBadQty = new System.Windows.Forms.Label();
            this.txtWorkName = new System.Windows.Forms.TextBox();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.labTotalQty = new System.Windows.Forms.Label();
            this.labDeviceNO = new System.Windows.Forms.Label();
            this.labEmpNO = new System.Windows.Forms.Label();
            this.labWorkNO = new System.Windows.Forms.Label();
            this.labWorkOrderNO = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.txtDeviceNo = new System.Windows.Forms.TextBox();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.txtWorkNo = new System.Windows.Forms.TextBox();
            this.txtWorkOrder = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.labSQLstatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.labScannerStatus = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labRemark = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.labAccuracy = new System.Windows.Forms.Label();
            this.labLR = new System.Windows.Forms.Label();
            this.labSpec = new System.Windows.Forms.Label();
            this.labPName = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labQty = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labWorkOrder = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnWorkNoDown = new System.Windows.Forms.Button();
            this.btnWorkNoUp = new System.Windows.Forms.Button();
            this.panelWorkNO = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnEmpDown = new System.Windows.Forms.Button();
            this.btnEmpUp = new System.Windows.Forms.Button();
            this.panelEmp = new System.Windows.Forms.Panel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnDeviceDown = new System.Windows.Forms.Button();
            this.btnDeviceUp = new System.Windows.Forms.Button();
            this.panelDevice = new System.Windows.Forms.Panel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnNumber0 = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnNumberClear = new System.Windows.Forms.Button();
            this.btnNumber3 = new System.Windows.Forms.Button();
            this.btnNumber2 = new System.Windows.Forms.Button();
            this.btnNumber1 = new System.Windows.Forms.Button();
            this.btnNumber6 = new System.Windows.Forms.Button();
            this.btnNumber5 = new System.Windows.Forms.Button();
            this.btnNumber4 = new System.Windows.Forms.Button();
            this.btnNumber9 = new System.Windows.Forms.Button();
            this.btnNumber8 = new System.Windows.Forms.Button();
            this.btnNumber7 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnT007 = new System.Windows.Forms.Button();
            this.btnT006 = new System.Windows.Forms.Button();
            this.btnT005 = new System.Windows.Forms.Button();
            this.btnT004 = new System.Windows.Forms.Button();
            this.btnT003 = new System.Windows.Forms.Button();
            this.btnT002 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSart = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtUnfinishQty);
            this.panel1.Controls.Add(this.txtBadQty);
            this.panel1.Controls.Add(this.labUnfinishQty);
            this.panel1.Controls.Add(this.labBadQty);
            this.panel1.Controls.Add(this.txtWorkName);
            this.panel1.Controls.Add(this.txtEmpName);
            this.panel1.Controls.Add(this.labTotalQty);
            this.panel1.Controls.Add(this.labDeviceNO);
            this.panel1.Controls.Add(this.labEmpNO);
            this.panel1.Controls.Add(this.labWorkNO);
            this.panel1.Controls.Add(this.labWorkOrderNO);
            this.panel1.Controls.Add(this.txtTotalQty);
            this.panel1.Controls.Add(this.txtDeviceNo);
            this.panel1.Controls.Add(this.txtEmpNo);
            this.panel1.Controls.Add(this.txtWorkNo);
            this.panel1.Controls.Add(this.txtWorkOrder);
            this.panel1.Location = new System.Drawing.Point(3, 123);
            this.panel1.Margin = new System.Windows.Forms.Padding(7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 485);
            this.panel1.TabIndex = 5;
            // 
            // txtUnfinishQty
            // 
            this.txtUnfinishQty.Location = new System.Drawing.Point(141, 436);
            this.txtUnfinishQty.Margin = new System.Windows.Forms.Padding(7);
            this.txtUnfinishQty.MaxLength = 6;
            this.txtUnfinishQty.Name = "txtUnfinishQty";
            this.txtUnfinishQty.Size = new System.Drawing.Size(228, 40);
            this.txtUnfinishQty.TabIndex = 2;
            this.txtUnfinishQty.Tag = "number";
            this.txtUnfinishQty.Enter += new System.EventHandler(this.Textbox_Enter);
            this.txtUnfinishQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalQty_KeyPress);
            this.txtUnfinishQty.Leave += new System.EventHandler(this.Textbox_Leave);
            this.txtUnfinishQty.Validating += new System.ComponentModel.CancelEventHandler(this.txtQty_Validating);
            // 
            // txtBadQty
            // 
            this.txtBadQty.Location = new System.Drawing.Point(141, 382);
            this.txtBadQty.Margin = new System.Windows.Forms.Padding(7);
            this.txtBadQty.MaxLength = 6;
            this.txtBadQty.Name = "txtBadQty";
            this.txtBadQty.Size = new System.Drawing.Size(228, 40);
            this.txtBadQty.TabIndex = 1;
            this.txtBadQty.Tag = "number";
            this.txtBadQty.Enter += new System.EventHandler(this.Textbox_Enter);
            this.txtBadQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalQty_KeyPress);
            this.txtBadQty.Leave += new System.EventHandler(this.Textbox_Leave);
            this.txtBadQty.Validating += new System.ComponentModel.CancelEventHandler(this.txtQty_Validating);
            // 
            // labUnfinishQty
            // 
            this.labUnfinishQty.AutoSize = true;
            this.labUnfinishQty.Location = new System.Drawing.Point(7, 439);
            this.labUnfinishQty.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labUnfinishQty.Name = "labUnfinishQty";
            this.labUnfinishQty.Size = new System.Drawing.Size(117, 27);
            this.labUnfinishQty.TabIndex = 12;
            this.labUnfinishQty.Text = "U.未完成";
            // 
            // labBadQty
            // 
            this.labBadQty.AutoSize = true;
            this.labBadQty.Location = new System.Drawing.Point(7, 385);
            this.labBadQty.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labBadQty.Name = "labBadQty";
            this.labBadQty.Size = new System.Drawing.Size(117, 27);
            this.labBadQty.TabIndex = 11;
            this.labBadQty.Text = "X.不良數";
            // 
            // txtWorkName
            // 
            this.txtWorkName.Location = new System.Drawing.Point(141, 112);
            this.txtWorkName.Margin = new System.Windows.Forms.Padding(7);
            this.txtWorkName.Name = "txtWorkName";
            this.txtWorkName.ReadOnly = true;
            this.txtWorkName.Size = new System.Drawing.Size(228, 40);
            this.txtWorkName.TabIndex = 10;
            this.txtWorkName.TabStop = false;
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(141, 220);
            this.txtEmpName.Margin = new System.Windows.Forms.Padding(7);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.ReadOnly = true;
            this.txtEmpName.Size = new System.Drawing.Size(228, 40);
            this.txtEmpName.TabIndex = 9;
            this.txtEmpName.TabStop = false;
            // 
            // labTotalQty
            // 
            this.labTotalQty.AutoSize = true;
            this.labTotalQty.Location = new System.Drawing.Point(7, 331);
            this.labTotalQty.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labTotalQty.Name = "labTotalQty";
            this.labTotalQty.Size = new System.Drawing.Size(90, 27);
            this.labTotalQty.TabIndex = 8;
            this.labTotalQty.Text = "Q.總數";
            // 
            // labDeviceNO
            // 
            this.labDeviceNO.AutoSize = true;
            this.labDeviceNO.Location = new System.Drawing.Point(7, 277);
            this.labDeviceNO.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labDeviceNO.Name = "labDeviceNO";
            this.labDeviceNO.Size = new System.Drawing.Size(95, 27);
            this.labDeviceNO.TabIndex = 7;
            this.labDeviceNO.Text = "M.機台";
            // 
            // labEmpNO
            // 
            this.labEmpNO.AutoSize = true;
            this.labEmpNO.Location = new System.Drawing.Point(7, 169);
            this.labEmpNO.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labEmpNO.Name = "labEmpNO";
            this.labEmpNO.Size = new System.Drawing.Size(86, 27);
            this.labEmpNO.TabIndex = 6;
            this.labEmpNO.Text = "P.員工";
            // 
            // labWorkNO
            // 
            this.labWorkNO.AutoSize = true;
            this.labWorkNO.Location = new System.Drawing.Point(7, 61);
            this.labWorkNO.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labWorkNO.Name = "labWorkNO";
            this.labWorkNO.Size = new System.Drawing.Size(96, 27);
            this.labWorkNO.TabIndex = 6;
            this.labWorkNO.Text = "W.工序";
            // 
            // labWorkOrderNO
            // 
            this.labWorkOrderNO.AutoSize = true;
            this.labWorkOrderNO.Location = new System.Drawing.Point(7, 7);
            this.labWorkOrderNO.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labWorkOrderNO.Name = "labWorkOrderNO";
            this.labWorkOrderNO.Size = new System.Drawing.Size(120, 27);
            this.labWorkOrderNO.TabIndex = 5;
            this.labWorkOrderNO.Text = "製造命令";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(141, 328);
            this.txtTotalQty.Margin = new System.Windows.Forms.Padding(7);
            this.txtTotalQty.MaxLength = 6;
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(228, 40);
            this.txtTotalQty.TabIndex = 0;
            this.txtTotalQty.Tag = "number";
            this.txtTotalQty.Enter += new System.EventHandler(this.Textbox_Enter);
            this.txtTotalQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalQty_KeyPress);
            this.txtTotalQty.Leave += new System.EventHandler(this.Textbox_Leave);
            this.txtTotalQty.Validating += new System.ComponentModel.CancelEventHandler(this.txtQty_Validating);
            // 
            // txtDeviceNo
            // 
            this.txtDeviceNo.Location = new System.Drawing.Point(141, 274);
            this.txtDeviceNo.Margin = new System.Windows.Forms.Padding(7);
            this.txtDeviceNo.Name = "txtDeviceNo";
            this.txtDeviceNo.Size = new System.Drawing.Size(228, 40);
            this.txtDeviceNo.TabIndex = 0;
            this.txtDeviceNo.TabStop = false;
            this.txtDeviceNo.Enter += new System.EventHandler(this.Textbox_Enter);
            this.txtDeviceNo.Leave += new System.EventHandler(this.Textbox_Leave);
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(141, 166);
            this.txtEmpNo.Margin = new System.Windows.Forms.Padding(7);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.ReadOnly = true;
            this.txtEmpNo.Size = new System.Drawing.Size(228, 40);
            this.txtEmpNo.TabIndex = 2;
            this.txtEmpNo.TabStop = false;
            this.txtEmpNo.TextChanged += new System.EventHandler(this.txtEmpNo_TextChanged);
            this.txtEmpNo.Enter += new System.EventHandler(this.Textbox_Enter);
            this.txtEmpNo.Leave += new System.EventHandler(this.Textbox_Leave);
            // 
            // txtWorkNo
            // 
            this.txtWorkNo.Location = new System.Drawing.Point(141, 58);
            this.txtWorkNo.Margin = new System.Windows.Forms.Padding(7);
            this.txtWorkNo.Name = "txtWorkNo";
            this.txtWorkNo.ReadOnly = true;
            this.txtWorkNo.Size = new System.Drawing.Size(228, 40);
            this.txtWorkNo.TabIndex = 1;
            this.txtWorkNo.TabStop = false;
            this.txtWorkNo.TextChanged += new System.EventHandler(this.txtWorkNo_TextChanged);
            this.txtWorkNo.Enter += new System.EventHandler(this.Textbox_Enter);
            this.txtWorkNo.Leave += new System.EventHandler(this.Textbox_Leave);
            // 
            // txtWorkOrder
            // 
            this.txtWorkOrder.Location = new System.Drawing.Point(141, 4);
            this.txtWorkOrder.Margin = new System.Windows.Forms.Padding(7);
            this.txtWorkOrder.Name = "txtWorkOrder";
            this.txtWorkOrder.ReadOnly = true;
            this.txtWorkOrder.Size = new System.Drawing.Size(228, 40);
            this.txtWorkOrder.TabIndex = 0;
            this.txtWorkOrder.TabStop = false;
            this.txtWorkOrder.TextChanged += new System.EventHandler(this.txtWorkOrder_TextChanged);
            this.txtWorkOrder.Enter += new System.EventHandler(this.Textbox_Enter);
            this.txtWorkOrder.Leave += new System.EventHandler(this.Textbox_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1257, 225);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(79, 67);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox8);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(1346, 244);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 377);
            this.panel2.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(258, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 43);
            this.button2.TabIndex = 15;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 27);
            this.label1.TabIndex = 14;
            this.label1.Text = "label1";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(15, 96);
            this.textBox8.Margin = new System.Windows.Forms.Padding(7);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(336, 70);
            this.textBox8.TabIndex = 13;
            this.textBox8.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 246);
            this.button3.Margin = new System.Windows.Forms.Padding(7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(252, 52);
            this.button3.TabIndex = 12;
            this.button3.TabStop = false;
            this.button3.Text = "SQLCONNECT";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(15, 5);
            this.textBox2.Margin = new System.Windows.Forms.Padding(7);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(336, 83);
            this.textBox2.TabIndex = 11;
            this.textBox2.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 312);
            this.textBox1.Margin = new System.Windows.Forms.Padding(7);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 69);
            this.textBox1.TabIndex = 10;
            this.textBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 180);
            this.button1.Margin = new System.Windows.Forms.Padding(7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(313, 52);
            this.button1.TabIndex = 9;
            this.button1.TabStop = false;
            this.button1.Text = "OPEN COMPORT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView2);
            this.panel4.Location = new System.Drawing.Point(1115, 215);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(63, 104);
            this.panel4.TabIndex = 11;
            this.panel4.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(7, 13);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(7);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(40, 81);
            this.dataGridView2.TabIndex = 8;
            // 
            // tmrMain
            // 
            this.tmrMain.Enabled = true;
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labSQLstatus);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.dtpTime);
            this.panel5.Controls.Add(this.button7);
            this.panel5.Controls.Add(this.button6);
            this.panel5.Controls.Add(this.labScannerStatus);
            this.panel5.Controls.Add(this.label23);
            this.panel5.Location = new System.Drawing.Point(3, 609);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(412, 89);
            this.panel5.TabIndex = 12;
            // 
            // labSQLstatus
            // 
            this.labSQLstatus.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labSQLstatus.ForeColor = System.Drawing.Color.Blue;
            this.labSQLstatus.Location = new System.Drawing.Point(308, 6);
            this.labSQLstatus.Name = "labSQLstatus";
            this.labSQLstatus.Size = new System.Drawing.Size(76, 27);
            this.labSQLstatus.TabIndex = 9;
            this.labSQLstatus.Text = "斷線";
            this.labSQLstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 27);
            this.label2.TabIndex = 8;
            this.label2.Text = "資料庫";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.DoubleClick += new System.EventHandler(this.label2_DoubleClick);
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtpTime.Enabled = false;
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(18, 45);
            this.dtpTime.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(374, 40);
            this.dtpTime.TabIndex = 7;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(343, 48);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(66, 42);
            this.button7.TabIndex = 6;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(-3, 66);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // labScannerStatus
            // 
            this.labScannerStatus.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labScannerStatus.ForeColor = System.Drawing.Color.Blue;
            this.labScannerStatus.Location = new System.Drawing.Point(106, 6);
            this.labScannerStatus.Name = "labScannerStatus";
            this.labScannerStatus.Size = new System.Drawing.Size(76, 27);
            this.labScannerStatus.TabIndex = 4;
            this.labScannerStatus.Text = "斷開";
            this.labScannerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 6);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(93, 27);
            this.label23.TabIndex = 1;
            this.label23.Text = "掃描器";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabControl1.Location = new System.Drawing.Point(421, 123);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(923, 575);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(915, 534);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "製造命令";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(325, 248);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(90, 68);
            this.button8.TabIndex = 13;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(68, 248);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 133);
            this.button4.TabIndex = 12;
            this.button4.Text = "button4";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labRemark);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.labAccuracy);
            this.panel3.Controls.Add(this.labLR);
            this.panel3.Controls.Add(this.labSpec);
            this.panel3.Controls.Add(this.labPName);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.labQty);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.labWorkOrder);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(907, 176);
            this.panel3.TabIndex = 11;
            // 
            // labRemark
            // 
            this.labRemark.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labRemark.ForeColor = System.Drawing.Color.Blue;
            this.labRemark.Location = new System.Drawing.Point(159, 141);
            this.labRemark.Name = "labRemark";
            this.labRemark.Size = new System.Drawing.Size(741, 27);
            this.labRemark.TabIndex = 15;
            this.labRemark.Text = "label22";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(24, 141);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 27);
            this.label21.TabIndex = 14;
            this.label21.Text = "備註";
            // 
            // labAccuracy
            // 
            this.labAccuracy.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labAccuracy.ForeColor = System.Drawing.Color.Blue;
            this.labAccuracy.Location = new System.Drawing.Point(703, 102);
            this.labAccuracy.Name = "labAccuracy";
            this.labAccuracy.Size = new System.Drawing.Size(97, 27);
            this.labAccuracy.TabIndex = 12;
            this.labAccuracy.Text = "label19";
            // 
            // labLR
            // 
            this.labLR.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labLR.ForeColor = System.Drawing.Color.Blue;
            this.labLR.Location = new System.Drawing.Point(703, 60);
            this.labLR.Name = "labLR";
            this.labLR.Size = new System.Drawing.Size(97, 27);
            this.labLR.TabIndex = 11;
            this.labLR.Text = "label18";
            // 
            // labSpec
            // 
            this.labSpec.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labSpec.ForeColor = System.Drawing.Color.Blue;
            this.labSpec.Location = new System.Drawing.Point(159, 102);
            this.labSpec.Name = "labSpec";
            this.labSpec.Size = new System.Drawing.Size(412, 27);
            this.labSpec.TabIndex = 10;
            this.labSpec.Text = "label17";
            // 
            // labPName
            // 
            this.labPName.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labPName.ForeColor = System.Drawing.Color.Blue;
            this.labPName.Location = new System.Drawing.Point(159, 63);
            this.labPName.Name = "labPName";
            this.labPName.Size = new System.Drawing.Size(412, 27);
            this.labPName.TabIndex = 9;
            this.labPName.Text = "label16";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(577, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(122, 27);
            this.label15.TabIndex = 8;
            this.label15.Text = "精        度";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(577, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 27);
            this.label14.TabIndex = 7;
            this.label14.Text = "左  / 右牙";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 27);
            this.label13.TabIndex = 6;
            this.label13.Text = "規        格";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 27);
            this.label12.TabIndex = 5;
            this.label12.Text = "品        名";
            // 
            // labQty
            // 
            this.labQty.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labQty.ForeColor = System.Drawing.Color.Blue;
            this.labQty.Location = new System.Drawing.Point(703, 19);
            this.labQty.Name = "labQty";
            this.labQty.Size = new System.Drawing.Size(97, 27);
            this.labQty.TabIndex = 3;
            this.labQty.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(577, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 27);
            this.label9.TabIndex = 2;
            this.label9.Text = "製造數量";
            // 
            // labWorkOrder
            // 
            this.labWorkOrder.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labWorkOrder.ForeColor = System.Drawing.Color.Blue;
            this.labWorkOrder.Location = new System.Drawing.Point(159, 19);
            this.labWorkOrder.Name = "labWorkOrder";
            this.labWorkOrder.Size = new System.Drawing.Size(412, 27);
            this.labWorkOrder.TabIndex = 1;
            this.labWorkOrder.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 27);
            this.label7.TabIndex = 0;
            this.label7.Text = "製造番號";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnWorkNoDown);
            this.tabPage2.Controls.Add(this.btnWorkNoUp);
            this.tabPage2.Controls.Add(this.panelWorkNO);
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(915, 534);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "工序";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnWorkNoDown
            // 
            this.btnWorkNoDown.BackColor = System.Drawing.SystemColors.Control;
            this.btnWorkNoDown.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnWorkNoDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnWorkNoDown.Location = new System.Drawing.Point(785, 424);
            this.btnWorkNoDown.Name = "btnWorkNoDown";
            this.btnWorkNoDown.Size = new System.Drawing.Size(130, 110);
            this.btnWorkNoDown.TabIndex = 41;
            this.btnWorkNoDown.TabStop = false;
            this.btnWorkNoDown.Text = "Down▼";
            this.btnWorkNoDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnWorkNoDown.UseVisualStyleBackColor = false;
            this.btnWorkNoDown.Click += new System.EventHandler(this.btnWorkNoDown_Click);
            // 
            // btnWorkNoUp
            // 
            this.btnWorkNoUp.BackColor = System.Drawing.SystemColors.Control;
            this.btnWorkNoUp.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnWorkNoUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnWorkNoUp.Location = new System.Drawing.Point(785, 0);
            this.btnWorkNoUp.Name = "btnWorkNoUp";
            this.btnWorkNoUp.Size = new System.Drawing.Size(130, 110);
            this.btnWorkNoUp.TabIndex = 40;
            this.btnWorkNoUp.TabStop = false;
            this.btnWorkNoUp.Text = "Up▲";
            this.btnWorkNoUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnWorkNoUp.UseVisualStyleBackColor = false;
            this.btnWorkNoUp.Click += new System.EventHandler(this.button6_Click);
            // 
            // panelWorkNO
            // 
            this.panelWorkNO.AutoScroll = true;
            this.panelWorkNO.Location = new System.Drawing.Point(6, 6);
            this.panelWorkNO.Name = "panelWorkNO";
            this.panelWorkNO.Size = new System.Drawing.Size(766, 525);
            this.panelWorkNO.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnEmpDown);
            this.tabPage3.Controls.Add(this.btnEmpUp);
            this.tabPage3.Controls.Add(this.panelEmp);
            this.tabPage3.Location = new System.Drawing.Point(4, 37);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(915, 534);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "員工";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnEmpDown
            // 
            this.btnEmpDown.BackColor = System.Drawing.SystemColors.Control;
            this.btnEmpDown.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnEmpDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmpDown.Location = new System.Drawing.Point(785, 424);
            this.btnEmpDown.Name = "btnEmpDown";
            this.btnEmpDown.Size = new System.Drawing.Size(130, 110);
            this.btnEmpDown.TabIndex = 47;
            this.btnEmpDown.TabStop = false;
            this.btnEmpDown.Text = "Down▼";
            this.btnEmpDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmpDown.UseVisualStyleBackColor = false;
            this.btnEmpDown.Click += new System.EventHandler(this.btnEmpDown_Click);
            // 
            // btnEmpUp
            // 
            this.btnEmpUp.BackColor = System.Drawing.SystemColors.Control;
            this.btnEmpUp.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnEmpUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmpUp.Location = new System.Drawing.Point(785, 0);
            this.btnEmpUp.Name = "btnEmpUp";
            this.btnEmpUp.Size = new System.Drawing.Size(130, 110);
            this.btnEmpUp.TabIndex = 46;
            this.btnEmpUp.TabStop = false;
            this.btnEmpUp.Text = "Up▲";
            this.btnEmpUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmpUp.UseVisualStyleBackColor = false;
            this.btnEmpUp.Click += new System.EventHandler(this.btnEmpUp_Click);
            // 
            // panelEmp
            // 
            this.panelEmp.AutoScroll = true;
            this.panelEmp.Location = new System.Drawing.Point(3, 8);
            this.panelEmp.Name = "panelEmp";
            this.panelEmp.Size = new System.Drawing.Size(766, 525);
            this.panelEmp.TabIndex = 45;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnDeviceDown);
            this.tabPage4.Controls.Add(this.btnDeviceUp);
            this.tabPage4.Controls.Add(this.panelDevice);
            this.tabPage4.Location = new System.Drawing.Point(4, 37);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(915, 534);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "機台";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnDeviceDown
            // 
            this.btnDeviceDown.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeviceDown.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDeviceDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeviceDown.Location = new System.Drawing.Point(785, 424);
            this.btnDeviceDown.Name = "btnDeviceDown";
            this.btnDeviceDown.Size = new System.Drawing.Size(130, 110);
            this.btnDeviceDown.TabIndex = 44;
            this.btnDeviceDown.TabStop = false;
            this.btnDeviceDown.Text = "Down▼";
            this.btnDeviceDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeviceDown.UseVisualStyleBackColor = false;
            this.btnDeviceDown.Click += new System.EventHandler(this.btnDeviceDown_Click);
            // 
            // btnDeviceUp
            // 
            this.btnDeviceUp.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeviceUp.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDeviceUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeviceUp.Location = new System.Drawing.Point(785, 0);
            this.btnDeviceUp.Name = "btnDeviceUp";
            this.btnDeviceUp.Size = new System.Drawing.Size(130, 110);
            this.btnDeviceUp.TabIndex = 43;
            this.btnDeviceUp.TabStop = false;
            this.btnDeviceUp.Text = "Up▲";
            this.btnDeviceUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeviceUp.UseVisualStyleBackColor = false;
            this.btnDeviceUp.Click += new System.EventHandler(this.btnDeviceUp_Click);
            // 
            // panelDevice
            // 
            this.panelDevice.AutoScroll = true;
            this.panelDevice.Location = new System.Drawing.Point(3, 8);
            this.panelDevice.Name = "panelDevice";
            this.panelDevice.Size = new System.Drawing.Size(766, 525);
            this.panelDevice.TabIndex = 42;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnSend);
            this.tabPage5.Controls.Add(this.btnNumber0);
            this.tabPage5.Controls.Add(this.btnUp);
            this.tabPage5.Controls.Add(this.btnDown);
            this.tabPage5.Controls.Add(this.btnNumberClear);
            this.tabPage5.Controls.Add(this.btnNumber3);
            this.tabPage5.Controls.Add(this.btnNumber2);
            this.tabPage5.Controls.Add(this.btnNumber1);
            this.tabPage5.Controls.Add(this.btnNumber6);
            this.tabPage5.Controls.Add(this.btnNumber5);
            this.tabPage5.Controls.Add(this.btnNumber4);
            this.tabPage5.Controls.Add(this.btnNumber9);
            this.tabPage5.Controls.Add(this.btnNumber8);
            this.tabPage5.Controls.Add(this.btnNumber7);
            this.tabPage5.Location = new System.Drawing.Point(4, 37);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(915, 534);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "輸入數量";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.SystemColors.Control;
            this.btnSend.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSend.Location = new System.Drawing.Point(511, 418);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(130, 110);
            this.btnSend.TabIndex = 41;
            this.btnSend.TabStop = false;
            this.btnSend.Text = "送出";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Visible = false;
            // 
            // btnNumber0
            // 
            this.btnNumber0.AccessibleDescription = "";
            this.btnNumber0.BackColor = System.Drawing.SystemColors.Control;
            this.btnNumber0.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber0.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNumber0.Location = new System.Drawing.Point(188, 418);
            this.btnNumber0.Name = "btnNumber0";
            this.btnNumber0.Size = new System.Drawing.Size(130, 110);
            this.btnNumber0.TabIndex = 40;
            this.btnNumber0.TabStop = false;
            this.btnNumber0.Text = "0";
            this.btnNumber0.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNumber0.UseVisualStyleBackColor = false;
            this.btnNumber0.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.Control;
            this.btnUp.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUp.Location = new System.Drawing.Point(785, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(130, 110);
            this.btnUp.TabIndex = 39;
            this.btnUp.TabStop = false;
            this.btnUp.Text = "Up▲";
            this.btnUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.SystemColors.Control;
            this.btnDown.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDown.Location = new System.Drawing.Point(785, 424);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(130, 110);
            this.btnDown.TabIndex = 38;
            this.btnDown.TabStop = false;
            this.btnDown.Text = "Down▼";
            this.btnDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnNumberClear
            // 
            this.btnNumberClear.AccessibleDescription = "";
            this.btnNumberClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnNumberClear.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumberClear.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNumberClear.Location = new System.Drawing.Point(511, 10);
            this.btnNumberClear.Name = "btnNumberClear";
            this.btnNumberClear.Size = new System.Drawing.Size(130, 110);
            this.btnNumberClear.TabIndex = 37;
            this.btnNumberClear.TabStop = false;
            this.btnNumberClear.Text = "Clear";
            this.btnNumberClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNumberClear.UseVisualStyleBackColor = false;
            this.btnNumberClear.Click += new System.EventHandler(this.btnNumberClear_Click);
            // 
            // btnNumber3
            // 
            this.btnNumber3.BackColor = System.Drawing.SystemColors.Control;
            this.btnNumber3.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNumber3.Location = new System.Drawing.Point(360, 275);
            this.btnNumber3.Name = "btnNumber3";
            this.btnNumber3.Size = new System.Drawing.Size(130, 110);
            this.btnNumber3.TabIndex = 36;
            this.btnNumber3.TabStop = false;
            this.btnNumber3.Text = "3";
            this.btnNumber3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNumber3.UseVisualStyleBackColor = false;
            this.btnNumber3.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btnNumber2
            // 
            this.btnNumber2.BackColor = System.Drawing.SystemColors.Control;
            this.btnNumber2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNumber2.Location = new System.Drawing.Point(188, 275);
            this.btnNumber2.Name = "btnNumber2";
            this.btnNumber2.Size = new System.Drawing.Size(130, 110);
            this.btnNumber2.TabIndex = 35;
            this.btnNumber2.TabStop = false;
            this.btnNumber2.Text = "2";
            this.btnNumber2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNumber2.UseVisualStyleBackColor = false;
            this.btnNumber2.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btnNumber1
            // 
            this.btnNumber1.BackColor = System.Drawing.SystemColors.Control;
            this.btnNumber1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNumber1.Location = new System.Drawing.Point(15, 275);
            this.btnNumber1.Name = "btnNumber1";
            this.btnNumber1.Size = new System.Drawing.Size(130, 110);
            this.btnNumber1.TabIndex = 34;
            this.btnNumber1.TabStop = false;
            this.btnNumber1.Text = "1";
            this.btnNumber1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNumber1.UseVisualStyleBackColor = false;
            this.btnNumber1.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btnNumber6
            // 
            this.btnNumber6.BackColor = System.Drawing.SystemColors.Control;
            this.btnNumber6.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNumber6.Location = new System.Drawing.Point(360, 140);
            this.btnNumber6.Name = "btnNumber6";
            this.btnNumber6.Size = new System.Drawing.Size(130, 110);
            this.btnNumber6.TabIndex = 33;
            this.btnNumber6.TabStop = false;
            this.btnNumber6.Text = "6";
            this.btnNumber6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNumber6.UseVisualStyleBackColor = false;
            this.btnNumber6.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btnNumber5
            // 
            this.btnNumber5.BackColor = System.Drawing.SystemColors.Control;
            this.btnNumber5.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNumber5.Location = new System.Drawing.Point(188, 140);
            this.btnNumber5.Name = "btnNumber5";
            this.btnNumber5.Size = new System.Drawing.Size(130, 110);
            this.btnNumber5.TabIndex = 32;
            this.btnNumber5.TabStop = false;
            this.btnNumber5.Text = "5";
            this.btnNumber5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNumber5.UseVisualStyleBackColor = false;
            this.btnNumber5.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btnNumber4
            // 
            this.btnNumber4.BackColor = System.Drawing.SystemColors.Control;
            this.btnNumber4.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNumber4.Location = new System.Drawing.Point(15, 140);
            this.btnNumber4.Name = "btnNumber4";
            this.btnNumber4.Size = new System.Drawing.Size(130, 110);
            this.btnNumber4.TabIndex = 31;
            this.btnNumber4.TabStop = false;
            this.btnNumber4.Text = "4";
            this.btnNumber4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNumber4.UseVisualStyleBackColor = false;
            this.btnNumber4.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btnNumber9
            // 
            this.btnNumber9.BackColor = System.Drawing.SystemColors.Control;
            this.btnNumber9.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber9.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNumber9.Location = new System.Drawing.Point(360, 10);
            this.btnNumber9.Name = "btnNumber9";
            this.btnNumber9.Size = new System.Drawing.Size(130, 110);
            this.btnNumber9.TabIndex = 30;
            this.btnNumber9.TabStop = false;
            this.btnNumber9.Text = "9";
            this.btnNumber9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNumber9.UseVisualStyleBackColor = false;
            this.btnNumber9.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btnNumber8
            // 
            this.btnNumber8.BackColor = System.Drawing.SystemColors.Control;
            this.btnNumber8.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber8.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNumber8.Location = new System.Drawing.Point(188, 10);
            this.btnNumber8.Name = "btnNumber8";
            this.btnNumber8.Size = new System.Drawing.Size(130, 110);
            this.btnNumber8.TabIndex = 29;
            this.btnNumber8.TabStop = false;
            this.btnNumber8.Text = "8";
            this.btnNumber8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNumber8.UseVisualStyleBackColor = false;
            this.btnNumber8.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btnNumber7
            // 
            this.btnNumber7.BackColor = System.Drawing.SystemColors.Control;
            this.btnNumber7.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNumber7.Location = new System.Drawing.Point(15, 10);
            this.btnNumber7.Name = "btnNumber7";
            this.btnNumber7.Size = new System.Drawing.Size(130, 110);
            this.btnNumber7.TabIndex = 28;
            this.btnNumber7.TabStop = false;
            this.btnNumber7.Text = "7";
            this.btnNumber7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNumber7.UseVisualStyleBackColor = false;
            this.btnNumber7.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button5);
            this.panel6.Controls.Add(this.textBox4);
            this.panel6.Controls.Add(this.textBox3);
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Location = new System.Drawing.Point(1386, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(332, 219);
            this.panel6.TabIndex = 14;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(218, 152);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(101, 55);
            this.button5.TabIndex = 3;
            this.button5.TabStop = false;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(19, 163);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(179, 40);
            this.textBox4.TabIndex = 2;
            this.textBox4.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(107, 42);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(145, 40);
            this.textBox3.TabIndex = 1;
            this.textBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(14, 21);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Aqua;
            this.panel7.Controls.Add(this.btnT007);
            this.panel7.Controls.Add(this.btnT006);
            this.panel7.Controls.Add(this.btnT005);
            this.panel7.Controls.Add(this.btnT004);
            this.panel7.Controls.Add(this.btnT003);
            this.panel7.Controls.Add(this.btnT002);
            this.panel7.Controls.Add(this.btnStop);
            this.panel7.Controls.Add(this.btnSart);
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1351, 118);
            this.panel7.TabIndex = 22;
            // 
            // btnT007
            // 
            this.btnT007.BackColor = System.Drawing.SystemColors.Control;
            this.btnT007.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnT007.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnT007.Location = new System.Drawing.Point(1214, 3);
            this.btnT007.Name = "btnT007";
            this.btnT007.Size = new System.Drawing.Size(130, 110);
            this.btnT007.TabIndex = 27;
            this.btnT007.TabStop = false;
            this.btnT007.Text = "U.未完成";
            this.btnT007.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnT007.UseVisualStyleBackColor = false;
            this.btnT007.Click += new System.EventHandler(this.btnT007_Click);
            // 
            // btnT006
            // 
            this.btnT006.BackColor = System.Drawing.SystemColors.Control;
            this.btnT006.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnT006.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnT006.Location = new System.Drawing.Point(1041, 3);
            this.btnT006.Name = "btnT006";
            this.btnT006.Size = new System.Drawing.Size(130, 110);
            this.btnT006.TabIndex = 26;
            this.btnT006.TabStop = false;
            this.btnT006.Text = "X.不良數";
            this.btnT006.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnT006.UseVisualStyleBackColor = false;
            this.btnT006.Click += new System.EventHandler(this.btnT006_Click);
            // 
            // btnT005
            // 
            this.btnT005.BackColor = System.Drawing.SystemColors.Control;
            this.btnT005.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnT005.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnT005.Location = new System.Drawing.Point(868, 3);
            this.btnT005.Name = "btnT005";
            this.btnT005.Size = new System.Drawing.Size(130, 110);
            this.btnT005.TabIndex = 25;
            this.btnT005.TabStop = false;
            this.btnT005.Text = "Q.總數";
            this.btnT005.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnT005.UseVisualStyleBackColor = false;
            this.btnT005.Click += new System.EventHandler(this.btnT005_Click);
            // 
            // btnT004
            // 
            this.btnT004.BackColor = System.Drawing.SystemColors.Control;
            this.btnT004.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnT004.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnT004.Location = new System.Drawing.Point(695, 3);
            this.btnT004.Name = "btnT004";
            this.btnT004.Size = new System.Drawing.Size(130, 110);
            this.btnT004.TabIndex = 24;
            this.btnT004.TabStop = false;
            this.btnT004.Text = "M.機台";
            this.btnT004.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnT004.UseVisualStyleBackColor = false;
            this.btnT004.Click += new System.EventHandler(this.btnT004_Click);
            // 
            // btnT003
            // 
            this.btnT003.BackColor = System.Drawing.SystemColors.Control;
            this.btnT003.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnT003.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnT003.Location = new System.Drawing.Point(522, 3);
            this.btnT003.Name = "btnT003";
            this.btnT003.Size = new System.Drawing.Size(130, 110);
            this.btnT003.TabIndex = 23;
            this.btnT003.TabStop = false;
            this.btnT003.Text = "P.員工";
            this.btnT003.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnT003.UseVisualStyleBackColor = false;
            this.btnT003.Click += new System.EventHandler(this.btnT003_Click);
            // 
            // btnT002
            // 
            this.btnT002.BackColor = System.Drawing.SystemColors.Control;
            this.btnT002.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnT002.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnT002.Location = new System.Drawing.Point(349, 3);
            this.btnT002.Name = "btnT002";
            this.btnT002.Size = new System.Drawing.Size(130, 110);
            this.btnT002.TabIndex = 22;
            this.btnT002.TabStop = false;
            this.btnT002.Text = "W.工序";
            this.btnT002.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnT002.UseVisualStyleBackColor = false;
            this.btnT002.Click += new System.EventHandler(this.btnT002_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.Control;
            this.btnStop.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStop.Location = new System.Drawing.Point(176, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(130, 110);
            this.btnStop.TabIndex = 18;
            this.btnStop.TabStop = false;
            this.btnStop.Text = "Stop";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSart
            // 
            this.btnSart.BackColor = System.Drawing.Color.Lime;
            this.btnSart.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSart.Location = new System.Drawing.Point(3, 3);
            this.btnSart.Name = "btnSart";
            this.btnSart.Size = new System.Drawing.Size(130, 110);
            this.btnSart.TabIndex = 17;
            this.btnSart.TabStop = false;
            this.btnSart.Text = "Start";
            this.btnSart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSart.UseVisualStyleBackColor = false;
            this.btnSart.Click += new System.EventHandler(this.btnSart_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 701);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("PMingLiU", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1362, 740);
            this.MinimumSize = new System.Drawing.Size(1362, 740);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "工作站";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMain_KeyPress);
            this.Leave += new System.EventHandler(this.frmMain_Leave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labTotalQty;
        private System.Windows.Forms.Label labDeviceNO;
        private System.Windows.Forms.Label labEmpNO;
        private System.Windows.Forms.Label labWorkNO;
        private System.Windows.Forms.Label labWorkOrderNO;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.TextBox txtDeviceNo;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.TextBox txtWorkNo;
        private System.Windows.Forms.TextBox txtWorkOrder;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.TextBox txtWorkName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labScannerStatus;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox txtUnfinishQty;
        private System.Windows.Forms.TextBox txtBadQty;
        private System.Windows.Forms.Label labUnfinishQty;
        private System.Windows.Forms.Label labBadQty;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labRemark;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label labAccuracy;
        private System.Windows.Forms.Label labLR;
        private System.Windows.Forms.Label labSpec;
        private System.Windows.Forms.Label labPName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labWorkOrder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnT007;
        private System.Windows.Forms.Button btnT006;
        private System.Windows.Forms.Button btnT005;
        private System.Windows.Forms.Button btnT004;
        private System.Windows.Forms.Button btnT003;
        private System.Windows.Forms.Button btnT002;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSart;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnNumber0;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnNumberClear;
        private System.Windows.Forms.Button btnNumber3;
        private System.Windows.Forms.Button btnNumber2;
        private System.Windows.Forms.Button btnNumber1;
        private System.Windows.Forms.Button btnNumber6;
        private System.Windows.Forms.Button btnNumber5;
        private System.Windows.Forms.Button btnNumber4;
        private System.Windows.Forms.Button btnNumber9;
        private System.Windows.Forms.Button btnNumber8;
        private System.Windows.Forms.Button btnNumber7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnWorkNoDown;
        private System.Windows.Forms.Button btnWorkNoUp;
        private System.Windows.Forms.Panel panelWorkNO;
        private System.Windows.Forms.Button btnDeviceDown;
        private System.Windows.Forms.Button btnDeviceUp;
        private System.Windows.Forms.Panel panelDevice;
        private System.Windows.Forms.Button btnEmpDown;
        private System.Windows.Forms.Button btnEmpUp;
        private System.Windows.Forms.Panel panelEmp;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label labSQLstatus;
        private System.Windows.Forms.Label label2;
    }
}

