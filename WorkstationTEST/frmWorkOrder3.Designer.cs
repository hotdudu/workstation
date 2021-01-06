namespace WorkstationTEST
{
    partial class frmWorkOrder3
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
            this.frmWKMakeno = new System.Windows.Forms.TextBox();
            this.WKPanel = new System.Windows.Forms.TableLayoutPanel();
            this.frmWKWorkitem = new System.Windows.Forms.TextBox();
            this.frmWKRecordnow = new System.Windows.Forms.Label();
            this.WKSaveWitemId = new System.Windows.Forms.TextBox();
            this.WKSaveWorderId = new System.Windows.Forms.TextBox();
            this.WKSaveWorkId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.WKSaveMakeNo = new System.Windows.Forms.TextBox();
            this.WKSaveWorkNo = new System.Windows.Forms.TextBox();
            this.WKSaveWorkName = new System.Windows.Forms.TextBox();
            this.WKSaveMNo = new System.Windows.Forms.TextBox();
            this.WKSaveSpecification = new System.Windows.Forms.TextBox();
            this.WKSaveWorkqty = new System.Windows.Forms.TextBox();
            this.frmWKRecordT = new System.Windows.Forms.Label();
            this.frmWKbtnD = new WorkstationTEST.XButton();
            this.frmWKbtnU = new WorkstationTEST.XButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labUnit = new System.Windows.Forms.Label();
            this.labAssetsName = new System.Windows.Forms.Label();
            this.labelname = new System.Windows.Forms.Label();
            this.labRemark = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.labSpec = new System.Windows.Forms.Label();
            this.labPName = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labQty = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labWorkOrder = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.infowkname = new System.Windows.Forms.Label();
            this.infowkno = new System.Windows.Forms.Label();
            this.infoempname = new System.Windows.Forms.Label();
            this.infoempno = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.infotitle = new System.Windows.Forms.Label();
            this.WKAssetsId = new System.Windows.Forms.TextBox();
            this.WKtenantId = new System.Windows.Forms.TextBox();
            this.WKpno = new System.Windows.Forms.TextBox();
            this.WKPartnerId = new System.Windows.Forms.TextBox();
            this.WKprice = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmWKMakeno
            // 
            this.frmWKMakeno.HideSelection = false;
            this.frmWKMakeno.Location = new System.Drawing.Point(256, 12);
            this.frmWKMakeno.Name = "frmWKMakeno";
            this.frmWKMakeno.Size = new System.Drawing.Size(176, 22);
            this.frmWKMakeno.TabIndex = 0;
            this.frmWKMakeno.TabStop = false;
            this.frmWKMakeno.TextChanged += new System.EventHandler(this.frmWKMakeno_TextChanged);
            // 
            // WKPanel
            // 
            this.WKPanel.AutoSize = true;
            this.WKPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WKPanel.CausesValidation = false;
            this.WKPanel.ColumnCount = 5;
            this.WKPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.WKPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.WKPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.WKPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.WKPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.WKPanel.Location = new System.Drawing.Point(10, 160);
            this.WKPanel.Name = "WKPanel";
            this.WKPanel.RowCount = 2;
            this.WKPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.WKPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.WKPanel.Size = new System.Drawing.Size(0, 0);
            this.WKPanel.TabIndex = 99;
            // 
            // frmWKWorkitem
            // 
            this.frmWKWorkitem.CausesValidation = false;
            this.frmWKWorkitem.HideSelection = false;
            this.frmWKWorkitem.Location = new System.Drawing.Point(256, 64);
            this.frmWKWorkitem.Name = "frmWKWorkitem";
            this.frmWKWorkitem.ReadOnly = true;
            this.frmWKWorkitem.Size = new System.Drawing.Size(176, 22);
            this.frmWKWorkitem.TabIndex = 99;
            this.frmWKWorkitem.TabStop = false;
            // 
            // frmWKRecordnow
            // 
            this.frmWKRecordnow.AutoSize = true;
            this.frmWKRecordnow.CausesValidation = false;
            this.frmWKRecordnow.Location = new System.Drawing.Point(337, 548);
            this.frmWKRecordnow.Name = "frmWKRecordnow";
            this.frmWKRecordnow.Size = new System.Drawing.Size(95, 12);
            this.frmWKRecordnow.TabIndex = 99;
            this.frmWKRecordnow.Text = "frmWKRecordnow";
            this.frmWKRecordnow.Visible = false;
            // 
            // WKSaveWitemId
            // 
            this.WKSaveWitemId.CausesValidation = false;
            this.WKSaveWitemId.HideSelection = false;
            this.WKSaveWitemId.Location = new System.Drawing.Point(752, 538);
            this.WKSaveWitemId.Name = "WKSaveWitemId";
            this.WKSaveWitemId.Size = new System.Drawing.Size(100, 22);
            this.WKSaveWitemId.TabIndex = 6;
            this.WKSaveWitemId.TabStop = false;
            this.WKSaveWitemId.Visible = false;
            // 
            // WKSaveWorderId
            // 
            this.WKSaveWorderId.CausesValidation = false;
            this.WKSaveWorderId.HideSelection = false;
            this.WKSaveWorderId.Location = new System.Drawing.Point(913, 538);
            this.WKSaveWorderId.Name = "WKSaveWorderId";
            this.WKSaveWorderId.Size = new System.Drawing.Size(100, 22);
            this.WKSaveWorderId.TabIndex = 7;
            this.WKSaveWorderId.TabStop = false;
            this.WKSaveWorderId.Visible = false;
            // 
            // WKSaveWorkId
            // 
            this.WKSaveWorkId.CausesValidation = false;
            this.WKSaveWorkId.HideSelection = false;
            this.WKSaveWorkId.Location = new System.Drawing.Point(1087, 537);
            this.WKSaveWorkId.Name = "WKSaveWorkId";
            this.WKSaveWorkId.Size = new System.Drawing.Size(100, 22);
            this.WKSaveWorkId.TabIndex = 8;
            this.WKSaveWorkId.TabStop = false;
            this.WKSaveWorkId.Visible = false;
            // 
            // label1
            // 
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(79, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "請輸入工令";
            // 
            // label2
            // 
            this.label2.CausesValidation = false;
            this.label2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(79, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "請選擇工序";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // WKSaveMakeNo
            // 
            this.WKSaveMakeNo.CausesValidation = false;
            this.WKSaveMakeNo.HideSelection = false;
            this.WKSaveMakeNo.Location = new System.Drawing.Point(606, 538);
            this.WKSaveMakeNo.Name = "WKSaveMakeNo";
            this.WKSaveMakeNo.Size = new System.Drawing.Size(100, 22);
            this.WKSaveMakeNo.TabIndex = 14;
            this.WKSaveMakeNo.TabStop = false;
            this.WKSaveMakeNo.Visible = false;
            // 
            // WKSaveWorkNo
            // 
            this.WKSaveWorkNo.CausesValidation = false;
            this.WKSaveWorkNo.HideSelection = false;
            this.WKSaveWorkNo.Location = new System.Drawing.Point(1087, 592);
            this.WKSaveWorkNo.Name = "WKSaveWorkNo";
            this.WKSaveWorkNo.Size = new System.Drawing.Size(100, 22);
            this.WKSaveWorkNo.TabIndex = 15;
            this.WKSaveWorkNo.TabStop = false;
            this.WKSaveWorkNo.Visible = false;
            // 
            // WKSaveWorkName
            // 
            this.WKSaveWorkName.CausesValidation = false;
            this.WKSaveWorkName.HideSelection = false;
            this.WKSaveWorkName.Location = new System.Drawing.Point(914, 592);
            this.WKSaveWorkName.Name = "WKSaveWorkName";
            this.WKSaveWorkName.Size = new System.Drawing.Size(100, 22);
            this.WKSaveWorkName.TabIndex = 16;
            this.WKSaveWorkName.TabStop = false;
            this.WKSaveWorkName.Visible = false;
            // 
            // WKSaveMNo
            // 
            this.WKSaveMNo.CausesValidation = false;
            this.WKSaveMNo.HideSelection = false;
            this.WKSaveMNo.Location = new System.Drawing.Point(752, 592);
            this.WKSaveMNo.Name = "WKSaveMNo";
            this.WKSaveMNo.Size = new System.Drawing.Size(100, 22);
            this.WKSaveMNo.TabIndex = 17;
            this.WKSaveMNo.TabStop = false;
            this.WKSaveMNo.Visible = false;
            // 
            // WKSaveSpecification
            // 
            this.WKSaveSpecification.CausesValidation = false;
            this.WKSaveSpecification.HideSelection = false;
            this.WKSaveSpecification.Location = new System.Drawing.Point(606, 592);
            this.WKSaveSpecification.Name = "WKSaveSpecification";
            this.WKSaveSpecification.Size = new System.Drawing.Size(100, 22);
            this.WKSaveSpecification.TabIndex = 18;
            this.WKSaveSpecification.TabStop = false;
            this.WKSaveSpecification.Visible = false;
            // 
            // WKSaveWorkqty
            // 
            this.WKSaveWorkqty.CausesValidation = false;
            this.WKSaveWorkqty.HideSelection = false;
            this.WKSaveWorkqty.Location = new System.Drawing.Point(470, 592);
            this.WKSaveWorkqty.Name = "WKSaveWorkqty";
            this.WKSaveWorkqty.Size = new System.Drawing.Size(100, 22);
            this.WKSaveWorkqty.TabIndex = 19;
            this.WKSaveWorkqty.TabStop = false;
            this.WKSaveWorkqty.Visible = false;
            // 
            // frmWKRecordT
            // 
            this.frmWKRecordT.AutoSize = true;
            this.frmWKRecordT.CausesValidation = false;
            this.frmWKRecordT.Location = new System.Drawing.Point(210, 548);
            this.frmWKRecordT.Name = "frmWKRecordT";
            this.frmWKRecordT.Size = new System.Drawing.Size(82, 12);
            this.frmWKRecordT.TabIndex = 20;
            this.frmWKRecordT.Text = "frmWKRecordT";
            this.frmWKRecordT.Visible = false;
            // 
            // frmWKbtnD
            // 
            this.frmWKbtnD.CausesValidation = false;
            this.frmWKbtnD.LeftText = null;
            this.frmWKbtnD.Location = new System.Drawing.Point(787, 422);
            this.frmWKbtnD.Name = "frmWKbtnD";
            this.frmWKbtnD.Size = new System.Drawing.Size(75, 23);
            this.frmWKbtnD.TabIndex = 99;
            this.frmWKbtnD.TabStop = false;
            this.frmWKbtnD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmWKbtnD.TopText = null;
            this.frmWKbtnD.UseVisualStyleBackColor = true;
            this.frmWKbtnD.Click += new System.EventHandler(this.frmWKbtnD_Click);
            // 
            // frmWKbtnU
            // 
            this.frmWKbtnU.CausesValidation = false;
            this.frmWKbtnU.LeftText = null;
            this.frmWKbtnU.Location = new System.Drawing.Point(787, 259);
            this.frmWKbtnU.Name = "frmWKbtnU";
            this.frmWKbtnU.Size = new System.Drawing.Size(75, 23);
            this.frmWKbtnU.TabIndex = 99;
            this.frmWKbtnU.TabStop = false;
            this.frmWKbtnU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmWKbtnU.TopText = null;
            this.frmWKbtnU.UseVisualStyleBackColor = true;
            this.frmWKbtnU.Click += new System.EventHandler(this.frmWKbtnU_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(258, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 27);
            this.label3.TabIndex = 100;
            this.label3.Text = "loading";
            this.label3.UseMnemonic = false;
            this.label3.Visible = false;
            // 
            // panel3
            // 
            this.panel3.CausesValidation = false;
            this.panel3.Controls.Add(this.labUnit);
            this.panel3.Controls.Add(this.labAssetsName);
            this.panel3.Controls.Add(this.labelname);
            this.panel3.Controls.Add(this.labRemark);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.labSpec);
            this.panel3.Controls.Add(this.labPName);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.labQty);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.labWorkOrder);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(537, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(609, 154);
            this.panel3.TabIndex = 101;
            // 
            // labUnit
            // 
            this.labUnit.CausesValidation = false;
            this.labUnit.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labUnit.ForeColor = System.Drawing.Color.Blue;
            this.labUnit.Location = new System.Drawing.Point(506, -1);
            this.labUnit.Name = "labUnit";
            this.labUnit.Size = new System.Drawing.Size(80, 27);
            this.labUnit.TabIndex = 104;
            // 
            // labAssetsName
            // 
            this.labAssetsName.CausesValidation = false;
            this.labAssetsName.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labAssetsName.ForeColor = System.Drawing.Color.Blue;
            this.labAssetsName.Location = new System.Drawing.Point(414, 83);
            this.labAssetsName.Name = "labAssetsName";
            this.labAssetsName.Size = new System.Drawing.Size(174, 27);
            this.labAssetsName.TabIndex = 102;
            // 
            // labelname
            // 
            this.labelname.AutoSize = true;
            this.labelname.CausesValidation = false;
            this.labelname.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelname.Location = new System.Drawing.Point(321, 90);
            this.labelname.Name = "labelname";
            this.labelname.Size = new System.Drawing.Size(87, 19);
            this.labelname.TabIndex = 101;
            this.labelname.Text = "品        名";
            // 
            // labRemark
            // 
            this.labRemark.CausesValidation = false;
            this.labRemark.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labRemark.ForeColor = System.Drawing.Color.Blue;
            this.labRemark.Location = new System.Drawing.Point(137, 122);
            this.labRemark.Name = "labRemark";
            this.labRemark.Size = new System.Drawing.Size(451, 27);
            this.labRemark.TabIndex = 15;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.CausesValidation = false;
            this.label21.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(34, 130);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 19);
            this.label21.TabIndex = 14;
            this.label21.Text = "備        註";
            // 
            // labSpec
            // 
            this.labSpec.CausesValidation = false;
            this.labSpec.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labSpec.ForeColor = System.Drawing.Color.Blue;
            this.labSpec.Location = new System.Drawing.Point(137, 83);
            this.labSpec.Name = "labSpec";
            this.labSpec.Size = new System.Drawing.Size(178, 27);
            this.labSpec.TabIndex = 10;
            // 
            // labPName
            // 
            this.labPName.CausesValidation = false;
            this.labPName.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labPName.ForeColor = System.Drawing.Color.Blue;
            this.labPName.Location = new System.Drawing.Point(137, 44);
            this.labPName.Name = "labPName";
            this.labPName.Size = new System.Drawing.Size(241, 27);
            this.labPName.TabIndex = 99;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.CausesValidation = false;
            this.label13.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(34, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 19);
            this.label13.TabIndex = 6;
            this.label13.Text = "規        格";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.CausesValidation = false;
            this.label12.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(34, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 19);
            this.label12.TabIndex = 99;
            this.label12.Text = "產品編號";
            // 
            // labQty
            // 
            this.labQty.CausesValidation = false;
            this.labQty.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labQty.ForeColor = System.Drawing.Color.Blue;
            this.labQty.Location = new System.Drawing.Point(403, 3);
            this.labQty.Name = "labQty";
            this.labQty.Size = new System.Drawing.Size(97, 27);
            this.labQty.TabIndex = 99;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.CausesValidation = false;
            this.label9.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(321, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 19);
            this.label9.TabIndex = 99;
            this.label9.Text = "製造數量";
            // 
            // labWorkOrder
            // 
            this.labWorkOrder.CausesValidation = false;
            this.labWorkOrder.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labWorkOrder.ForeColor = System.Drawing.Color.Blue;
            this.labWorkOrder.Location = new System.Drawing.Point(137, 1);
            this.labWorkOrder.Name = "labWorkOrder";
            this.labWorkOrder.Size = new System.Drawing.Size(215, 27);
            this.labWorkOrder.TabIndex = 99;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.CausesValidation = false;
            this.label7.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(34, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 99;
            this.label7.Text = "製造番號";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.infowkname);
            this.panel1.Controls.Add(this.infowkno);
            this.panel1.Controls.Add(this.infoempname);
            this.panel1.Controls.Add(this.infoempno);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.infotitle);
            this.panel1.Location = new System.Drawing.Point(26, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 91);
            this.panel1.TabIndex = 104;
            // 
            // infowkname
            // 
            this.infowkname.CausesValidation = false;
            this.infowkname.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.infowkname.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.infowkname.Location = new System.Drawing.Point(412, 57);
            this.infowkname.Name = "infowkname";
            this.infowkname.Size = new System.Drawing.Size(82, 27);
            this.infowkname.TabIndex = 106;
            // 
            // infowkno
            // 
            this.infowkno.CausesValidation = false;
            this.infowkno.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.infowkno.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.infowkno.Location = new System.Drawing.Point(239, 57);
            this.infowkno.Name = "infowkno";
            this.infowkno.Size = new System.Drawing.Size(167, 27);
            this.infowkno.TabIndex = 105;
            // 
            // infoempname
            // 
            this.infoempname.CausesValidation = false;
            this.infoempname.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.infoempname.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.infoempname.Location = new System.Drawing.Point(344, 4);
            this.infoempname.Name = "infoempname";
            this.infoempname.Size = new System.Drawing.Size(147, 27);
            this.infoempname.TabIndex = 104;
            // 
            // infoempno
            // 
            this.infoempno.CausesValidation = false;
            this.infoempno.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.infoempno.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.infoempno.Location = new System.Drawing.Point(230, 4);
            this.infoempno.Name = "infoempno";
            this.infoempno.Size = new System.Drawing.Size(118, 27);
            this.infoempno.TabIndex = 103;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.CausesValidation = false;
            this.label5.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(154, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 19);
            this.label5.TabIndex = 102;
            this.label5.Text = "製程:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.CausesValidation = false;
            this.label4.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(154, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 19);
            this.label4.TabIndex = 101;
            this.label4.Text = "人員:";
            // 
            // infotitle
            // 
            this.infotitle.AutoSize = true;
            this.infotitle.CausesValidation = false;
            this.infotitle.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.infotitle.Location = new System.Drawing.Point(3, 32);
            this.infotitle.Name = "infotitle";
            this.infotitle.Size = new System.Drawing.Size(109, 19);
            this.infotitle.TabIndex = 100;
            this.infotitle.Text = "已新增資料:";
            this.infotitle.Click += new System.EventHandler(this.infotitle_Click);
            // 
            // WKAssetsId
            // 
            this.WKAssetsId.CausesValidation = false;
            this.WKAssetsId.HideSelection = false;
            this.WKAssetsId.Location = new System.Drawing.Point(470, 538);
            this.WKAssetsId.Name = "WKAssetsId";
            this.WKAssetsId.Size = new System.Drawing.Size(100, 22);
            this.WKAssetsId.TabIndex = 106;
            this.WKAssetsId.TabStop = false;
            this.WKAssetsId.Visible = false;
            // 
            // WKtenantId
            // 
            this.WKtenantId.CausesValidation = false;
            this.WKtenantId.HideSelection = false;
            this.WKtenantId.Location = new System.Drawing.Point(470, 490);
            this.WKtenantId.Name = "WKtenantId";
            this.WKtenantId.Size = new System.Drawing.Size(100, 22);
            this.WKtenantId.TabIndex = 107;
            this.WKtenantId.TabStop = false;
            this.WKtenantId.Visible = false;
            // 
            // WKpno
            // 
            this.WKpno.CausesValidation = false;
            this.WKpno.HideSelection = false;
            this.WKpno.Location = new System.Drawing.Point(606, 490);
            this.WKpno.Name = "WKpno";
            this.WKpno.Size = new System.Drawing.Size(100, 22);
            this.WKpno.TabIndex = 108;
            this.WKpno.TabStop = false;
            this.WKpno.Visible = false;
            // 
            // WKPartnerId
            // 
            this.WKPartnerId.CausesValidation = false;
            this.WKPartnerId.HideSelection = false;
            this.WKPartnerId.Location = new System.Drawing.Point(752, 490);
            this.WKPartnerId.Name = "WKPartnerId";
            this.WKPartnerId.Size = new System.Drawing.Size(100, 22);
            this.WKPartnerId.TabIndex = 109;
            this.WKPartnerId.TabStop = false;
            this.WKPartnerId.Visible = false;
            // 
            // WKprice
            // 
            this.WKprice.CausesValidation = false;
            this.WKprice.HideSelection = false;
            this.WKprice.Location = new System.Drawing.Point(913, 490);
            this.WKprice.Name = "WKprice";
            this.WKprice.Size = new System.Drawing.Size(100, 22);
            this.WKprice.TabIndex = 110;
            this.WKprice.TabStop = false;
            this.WKprice.Visible = false;
            // 
            // frmWorkOrder3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 687);
            this.Controls.Add(this.WKprice);
            this.Controls.Add(this.WKPartnerId);
            this.Controls.Add(this.WKpno);
            this.Controls.Add(this.WKtenantId);
            this.Controls.Add(this.WKAssetsId);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.frmWKMakeno);
            this.Controls.Add(this.frmWKRecordT);
            this.Controls.Add(this.WKSaveWorkqty);
            this.Controls.Add(this.WKSaveSpecification);
            this.Controls.Add(this.WKSaveMNo);
            this.Controls.Add(this.WKSaveWorkName);
            this.Controls.Add(this.WKSaveWorkNo);
            this.Controls.Add(this.WKSaveMakeNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WKSaveWorkId);
            this.Controls.Add(this.WKSaveWorderId);
            this.Controls.Add(this.WKSaveWitemId);
            this.Controls.Add(this.frmWKRecordnow);
            this.Controls.Add(this.frmWKWorkitem);
            this.Controls.Add(this.frmWKbtnD);
            this.Controls.Add(this.frmWKbtnU);
            this.Controls.Add(this.WKPanel);
            this.Name = "frmWorkOrder3";
            this.Text = "frmWorkOrder3";
            this.Load += new System.EventHandler(this.frmWorkOrder_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox frmWKMakeno;
        private System.Windows.Forms.TableLayoutPanel WKPanel;
        private XButton frmWKbtnU;
        private System.Windows.Forms.TextBox frmWKWorkitem;
        private System.Windows.Forms.Label frmWKRecordnow;
        private System.Windows.Forms.TextBox WKSaveWitemId;
        private System.Windows.Forms.TextBox WKSaveWorderId;
        private System.Windows.Forms.TextBox WKSaveWorkId;
        private XButton frmWKbtnD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WKSaveMakeNo;
        private System.Windows.Forms.TextBox WKSaveWorkNo;
        private System.Windows.Forms.TextBox WKSaveWorkName;
        private System.Windows.Forms.TextBox WKSaveMNo;
        private System.Windows.Forms.TextBox WKSaveSpecification;
        private System.Windows.Forms.TextBox WKSaveWorkqty;
        private System.Windows.Forms.Label frmWKRecordT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labUnit;
        private System.Windows.Forms.Label labAssetsName;
        private System.Windows.Forms.Label labelname;
        private System.Windows.Forms.Label labRemark;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label labSpec;
        private System.Windows.Forms.Label labPName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labWorkOrder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label infowkname;
        private System.Windows.Forms.Label infowkno;
        private System.Windows.Forms.Label infoempname;
        private System.Windows.Forms.Label infoempno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label infotitle;
        private System.Windows.Forms.TextBox WKAssetsId;
        private System.Windows.Forms.TextBox WKtenantId;
        private System.Windows.Forms.TextBox WKpno;
        private System.Windows.Forms.TextBox WKPartnerId;
        private System.Windows.Forms.TextBox WKprice;
    }
}