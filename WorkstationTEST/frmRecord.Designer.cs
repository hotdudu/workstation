namespace WorkstationTEST
{
    partial class frmRecord
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
            this.RPanel = new System.Windows.Forms.TableLayoutPanel();
            this.frmPTRecordnow = new System.Windows.Forms.Label();
            this.frmREno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NumPanel = new System.Windows.Forms.TableLayoutPanel();
            this.frmRecTotal = new System.Windows.Forms.Label();
            this.save = new WorkstationTEST.XButton();
            this.frmPTbtnD = new WorkstationTEST.XButton();
            this.frmPTbtnU = new WorkstationTEST.XButton();
            this.next = new WorkstationTEST.XButton();
            this.emptydata = new System.Windows.Forms.Label();
            this.focust = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RECsearch = new System.Windows.Forms.TextBox();
            this.totalcount = new System.Windows.Forms.Label();
            this.nowrecord = new System.Windows.Forms.Label();
            this.tqty = new System.Windows.Forms.Label();
            this.totalcount2 = new System.Windows.Forms.Label();
            this.cqty = new System.Windows.Forms.Label();
            this.nowrecord2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.RPanel.Location = new System.Drawing.Point(10, 33);
            this.RPanel.Name = "RPanel";
            this.RPanel.RowCount = 2;
            this.RPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RPanel.Size = new System.Drawing.Size(1300, 0);
            this.RPanel.TabIndex = 3;
            this.RPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RPanel_Paint);
            // 
            // frmPTRecordnow
            // 
            this.frmPTRecordnow.AutoSize = true;
            this.frmPTRecordnow.Location = new System.Drawing.Point(812, 272);
            this.frmPTRecordnow.Name = "frmPTRecordnow";
            this.frmPTRecordnow.Size = new System.Drawing.Size(89, 12);
            this.frmPTRecordnow.TabIndex = 11;
            this.frmPTRecordnow.Text = "frmPTRecordnow";
            this.frmPTRecordnow.Visible = false;
            this.frmPTRecordnow.Click += new System.EventHandler(this.frmPTRecordnow_Click);
            // 
            // frmREno
            // 
            this.frmREno.Location = new System.Drawing.Point(452, 3);
            this.frmREno.Name = "frmREno";
            this.frmREno.ReadOnly = true;
            this.frmREno.Size = new System.Drawing.Size(100, 22);
            this.frmREno.TabIndex = 12;
            this.frmREno.TextChanged += new System.EventHandler(this.frmREno_TextChanged);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("新細明體", 15F);
            this.label1.Location = new System.Drawing.Point(10, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "工令";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("新細明體", 15F);
            this.label2.Location = new System.Drawing.Point(510, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "完成數";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("新細明體", 15F);
            this.label3.Location = new System.Drawing.Point(410, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "仕掛數";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("新細明體", 15F);
            this.label4.Location = new System.Drawing.Point(210, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "製程";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("新細明體", 15F);
            this.label5.Location = new System.Drawing.Point(110, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 17;
            this.label5.Text = "規格";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("新細明體", 15F);
            this.label6.Location = new System.Drawing.Point(610, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 18;
            this.label6.Text = "開始時間";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("新細明體", 15F);
            this.label7.Location = new System.Drawing.Point(710, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 19;
            this.label7.Text = "結束時間";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label7.Visible = false;
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
            this.NumPanel.Location = new System.Drawing.Point(12, 147);
            this.NumPanel.Name = "NumPanel";
            this.NumPanel.RowCount = 3;
            this.NumPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.NumPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.NumPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.NumPanel.Size = new System.Drawing.Size(0, 0);
            this.NumPanel.TabIndex = 20;
            // 
            // frmRecTotal
            // 
            this.frmRecTotal.AutoSize = true;
            this.frmRecTotal.Location = new System.Drawing.Point(868, 251);
            this.frmRecTotal.Name = "frmRecTotal";
            this.frmRecTotal.Size = new System.Drawing.Size(33, 12);
            this.frmRecTotal.TabIndex = 22;
            this.frmRecTotal.Text = "label8";
            this.frmRecTotal.Visible = false;
            this.frmRecTotal.Click += new System.EventHandler(this.frmRecTotal_Click);
            // 
            // save
            // 
            this.save.LeftText = null;
            this.save.Location = new System.Drawing.Point(853, 147);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 21;
            this.save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.save.TopText = null;
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // frmPTbtnD
            // 
            this.frmPTbtnD.LeftText = null;
            this.frmPTbtnD.Location = new System.Drawing.Point(1022, 417);
            this.frmPTbtnD.Name = "frmPTbtnD";
            this.frmPTbtnD.Size = new System.Drawing.Size(75, 23);
            this.frmPTbtnD.TabIndex = 10;
            this.frmPTbtnD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmPTbtnD.TopText = null;
            this.frmPTbtnD.UseVisualStyleBackColor = true;
            this.frmPTbtnD.Click += new System.EventHandler(this.frmPTbtnD_Click);
            // 
            // frmPTbtnU
            // 
            this.frmPTbtnU.LeftText = null;
            this.frmPTbtnU.Location = new System.Drawing.Point(1022, 117);
            this.frmPTbtnU.Name = "frmPTbtnU";
            this.frmPTbtnU.Size = new System.Drawing.Size(75, 23);
            this.frmPTbtnU.TabIndex = 9;
            this.frmPTbtnU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmPTbtnU.TopText = null;
            this.frmPTbtnU.UseVisualStyleBackColor = true;
            this.frmPTbtnU.Click += new System.EventHandler(this.frmPTbtnU_Click);
            // 
            // next
            // 
            this.next.LeftText = null;
            this.next.Location = new System.Drawing.Point(853, 426);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(75, 23);
            this.next.TabIndex = 23;
            this.next.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.next.TopText = null;
            this.next.UseVisualStyleBackColor = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // emptydata
            // 
            this.emptydata.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.emptydata.Location = new System.Drawing.Point(296, 33);
            this.emptydata.Name = "emptydata";
            this.emptydata.Size = new System.Drawing.Size(174, 34);
            this.emptydata.TabIndex = 24;
            this.emptydata.Text = "目前無資料";
            this.emptydata.Visible = false;
            this.emptydata.Click += new System.EventHandler(this.emptydata_Click);
            // 
            // focust
            // 
            this.focust.Location = new System.Drawing.Point(870, 526);
            this.focust.Name = "focust";
            this.focust.Size = new System.Drawing.Size(100, 22);
            this.focust.TabIndex = 25;
            this.focust.Visible = false;
            this.focust.TextChanged += new System.EventHandler(this.focust_TextChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(610, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 26;
            this.label8.Text = "搜尋:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // RECsearch
            // 
            this.RECsearch.Location = new System.Drawing.Point(679, 3);
            this.RECsearch.Name = "RECsearch";
            this.RECsearch.Size = new System.Drawing.Size(100, 22);
            this.RECsearch.TabIndex = 27;
            this.RECsearch.TextChanged += new System.EventHandler(this.RECsearch_TextChanged);
            // 
            // totalcount
            // 
            this.totalcount.AutoSize = true;
            this.totalcount.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.totalcount.ForeColor = System.Drawing.Color.ForestGreen;
            this.totalcount.Location = new System.Drawing.Point(787, 6);
            this.totalcount.Name = "totalcount";
            this.totalcount.Size = new System.Drawing.Size(0, 19);
            this.totalcount.TabIndex = 28;
            // 
            // nowrecord
            // 
            this.nowrecord.AutoSize = true;
            this.nowrecord.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.nowrecord.ForeColor = System.Drawing.Color.ForestGreen;
            this.nowrecord.Location = new System.Drawing.Point(996, 7);
            this.nowrecord.Name = "nowrecord";
            this.nowrecord.Size = new System.Drawing.Size(0, 19);
            this.nowrecord.TabIndex = 29;
            // 
            // tqty
            // 
            this.tqty.AutoSize = true;
            this.tqty.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tqty.ForeColor = System.Drawing.Color.ForestGreen;
            this.tqty.Location = new System.Drawing.Point(844, 7);
            this.tqty.Name = "tqty";
            this.tqty.Size = new System.Drawing.Size(0, 19);
            this.tqty.TabIndex = 30;
            // 
            // totalcount2
            // 
            this.totalcount2.AutoSize = true;
            this.totalcount2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.totalcount2.ForeColor = System.Drawing.Color.ForestGreen;
            this.totalcount2.Location = new System.Drawing.Point(893, 7);
            this.totalcount2.Name = "totalcount2";
            this.totalcount2.Size = new System.Drawing.Size(0, 19);
            this.totalcount2.TabIndex = 31;
            // 
            // cqty
            // 
            this.cqty.AutoSize = true;
            this.cqty.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cqty.ForeColor = System.Drawing.Color.ForestGreen;
            this.cqty.Location = new System.Drawing.Point(1077, 3);
            this.cqty.Name = "cqty";
            this.cqty.Size = new System.Drawing.Size(0, 19);
            this.cqty.TabIndex = 32;
            // 
            // nowrecord2
            // 
            this.nowrecord2.AutoSize = true;
            this.nowrecord2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.nowrecord2.ForeColor = System.Drawing.Color.ForestGreen;
            this.nowrecord2.Location = new System.Drawing.Point(1092, 6);
            this.nowrecord2.Name = "nowrecord2";
            this.nowrecord2.Size = new System.Drawing.Size(0, 19);
            this.nowrecord2.TabIndex = 33;
            // 
            // frmRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 650);
            this.Controls.Add(this.nowrecord2);
            this.Controls.Add(this.cqty);
            this.Controls.Add(this.totalcount2);
            this.Controls.Add(this.tqty);
            this.Controls.Add(this.nowrecord);
            this.Controls.Add(this.totalcount);
            this.Controls.Add(this.RECsearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.focust);
            this.Controls.Add(this.emptydata);
            this.Controls.Add(this.next);
            this.Controls.Add(this.frmRecTotal);
            this.Controls.Add(this.save);
            this.Controls.Add(this.NumPanel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.frmREno);
            this.Controls.Add(this.frmPTRecordnow);
            this.Controls.Add(this.frmPTbtnD);
            this.Controls.Add(this.frmPTbtnU);
            this.Controls.Add(this.RPanel);
            this.Name = "frmRecord";
            this.Text = "frmRecord";
            this.Load += new System.EventHandler(this.frmRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel RPanel;
        private System.Windows.Forms.Label frmPTRecordnow;
        private XButton frmPTbtnD;
        private XButton frmPTbtnU;
        private System.Windows.Forms.TextBox frmREno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel NumPanel;
        private XButton save;
        private System.Windows.Forms.Label frmRecTotal;
        private XButton next;
        private System.Windows.Forms.Label emptydata;
        private System.Windows.Forms.TextBox focust;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox RECsearch;
        private System.Windows.Forms.Label totalcount;
        private System.Windows.Forms.Label nowrecord;
        private System.Windows.Forms.Label tqty;
        private System.Windows.Forms.Label totalcount2;
        private System.Windows.Forms.Label cqty;
        private System.Windows.Forms.Label nowrecord2;
    }
}