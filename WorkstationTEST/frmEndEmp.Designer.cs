namespace WorkstationTEST
{
    partial class frmEndEmp
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.frmEmpRecordnow = new System.Windows.Forms.Label();
            this.frmEmpPageD = new WorkstationTEST.XButton();
            this.frmEmpPageU = new WorkstationTEST.XButton();
            this.frmEmpshowno = new System.Windows.Forms.TextBox();
            this.frmEmpRecordT = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CausesValidation = false;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 52);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // frmEmpRecordnow
            // 
            this.frmEmpRecordnow.AutoSize = true;
            this.frmEmpRecordnow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.frmEmpRecordnow.Location = new System.Drawing.Point(267, 467);
            this.frmEmpRecordnow.Name = "frmEmpRecordnow";
            this.frmEmpRecordnow.Size = new System.Drawing.Size(98, 12);
            this.frmEmpRecordnow.TabIndex = 10;
            this.frmEmpRecordnow.Text = "frmEmpRecordnow";
            this.frmEmpRecordnow.Visible = false;
            // 
            // frmEmpPageD
            // 
            this.frmEmpPageD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.frmEmpPageD.LeftText = null;
            this.frmEmpPageD.Location = new System.Drawing.Point(736, 437);
            this.frmEmpPageD.Name = "frmEmpPageD";
            this.frmEmpPageD.Size = new System.Drawing.Size(75, 23);
            this.frmEmpPageD.TabIndex = 9;
            this.frmEmpPageD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmEmpPageD.TopText = null;
            this.frmEmpPageD.UseVisualStyleBackColor = true;
            this.frmEmpPageD.Click += new System.EventHandler(this.frmEmpPageD_Click);
            // 
            // frmEmpPageU
            // 
            this.frmEmpPageU.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.frmEmpPageU.LeftText = null;
            this.frmEmpPageU.Location = new System.Drawing.Point(736, 132);
            this.frmEmpPageU.Name = "frmEmpPageU";
            this.frmEmpPageU.Size = new System.Drawing.Size(75, 23);
            this.frmEmpPageU.TabIndex = 8;
            this.frmEmpPageU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmEmpPageU.TopText = null;
            this.frmEmpPageU.UseVisualStyleBackColor = true;
            this.frmEmpPageU.Click += new System.EventHandler(this.frmEmpPageU_Click);
            // 
            // frmEmpshowno
            // 
            this.frmEmpshowno.Location = new System.Drawing.Point(374, 12);
            this.frmEmpshowno.Name = "frmEmpshowno";
            this.frmEmpshowno.Size = new System.Drawing.Size(100, 22);
            this.frmEmpshowno.TabIndex = 11;
            // 
            // frmEmpRecordT
            // 
            this.frmEmpRecordT.AutoSize = true;
            this.frmEmpRecordT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.frmEmpRecordT.Location = new System.Drawing.Point(427, 467);
            this.frmEmpRecordT.Name = "frmEmpRecordT";
            this.frmEmpRecordT.Size = new System.Drawing.Size(85, 12);
            this.frmEmpRecordT.TabIndex = 12;
            this.frmEmpRecordT.Text = "frmEmpRecordT";
            this.frmEmpRecordT.Visible = false;
            // 
            // frmEndEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 610);
            this.Controls.Add(this.frmEmpRecordT);
            this.Controls.Add(this.frmEmpshowno);
            this.Controls.Add(this.frmEmpRecordnow);
            this.Controls.Add(this.frmEmpPageD);
            this.Controls.Add(this.frmEmpPageU);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmEndEmp";
            this.Text = "frmEndEmp";
            this.Load += new System.EventHandler(this.frmEndEmp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label frmEmpRecordnow;
        private XButton frmEmpPageD;
        private XButton frmEmpPageU;
        private System.Windows.Forms.TextBox frmEmpshowno;
        private System.Windows.Forms.Label frmEmpRecordT;
    }
}