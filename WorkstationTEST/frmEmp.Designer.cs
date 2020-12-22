namespace WorkstationTEST
{
    partial class frmEmp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmp));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.frmEmpPageU = new WorkstationTEST.XButton();
            this.frmEmpPageD = new WorkstationTEST.XButton();
            this.frmEmpshowno = new System.Windows.Forms.TextBox();
            this.frmEmpRecordnow = new System.Windows.Forms.Label();
            this.EMPSave1 = new System.Windows.Forms.TextBox();
            this.frmEmpRecordT = new System.Windows.Forms.Label();
            this.empname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.CausesValidation = false;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // frmEmpPageU
            // 
            this.frmEmpPageU.LeftText = null;
            resources.ApplyResources(this.frmEmpPageU, "frmEmpPageU");
            this.frmEmpPageU.Name = "frmEmpPageU";
            this.frmEmpPageU.TopText = null;
            this.frmEmpPageU.UseVisualStyleBackColor = true;
            this.frmEmpPageU.Click += new System.EventHandler(this.frmEmpPageU_Click);
            // 
            // frmEmpPageD
            // 
            this.frmEmpPageD.LeftText = null;
            resources.ApplyResources(this.frmEmpPageD, "frmEmpPageD");
            this.frmEmpPageD.Name = "frmEmpPageD";
            this.frmEmpPageD.TopText = null;
            this.frmEmpPageD.UseVisualStyleBackColor = true;
            this.frmEmpPageD.Click += new System.EventHandler(this.frmEmpPageD_Click);
            // 
            // frmEmpshowno
            // 
            resources.ApplyResources(this.frmEmpshowno, "frmEmpshowno");
            this.frmEmpshowno.Name = "frmEmpshowno";
            this.frmEmpshowno.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // frmEmpRecordnow
            // 
            resources.ApplyResources(this.frmEmpRecordnow, "frmEmpRecordnow");
            this.frmEmpRecordnow.Name = "frmEmpRecordnow";
            // 
            // EMPSave1
            // 
            this.EMPSave1.CausesValidation = false;
            resources.ApplyResources(this.EMPSave1, "EMPSave1");
            this.EMPSave1.Name = "EMPSave1";
            // 
            // frmEmpRecordT
            // 
            resources.ApplyResources(this.frmEmpRecordT, "frmEmpRecordT");
            this.frmEmpRecordT.Name = "frmEmpRecordT";
            // 
            // empname
            // 
            this.empname.CausesValidation = false;
            resources.ApplyResources(this.empname, "empname");
            this.empname.Name = "empname";
            // 
            // frmEmp
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.empname);
            this.Controls.Add(this.frmEmpRecordT);
            this.Controls.Add(this.EMPSave1);
            this.Controls.Add(this.frmEmpRecordnow);
            this.Controls.Add(this.frmEmpshowno);
            this.Controls.Add(this.frmEmpPageD);
            this.Controls.Add(this.frmEmpPageU);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmEmp";
            this.Load += new System.EventHandler(this.frmEmp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private XButton frmEmpPageU;
        private XButton frmEmpPageD;
        private System.Windows.Forms.TextBox frmEmpshowno;
        private System.Windows.Forms.Label frmEmpRecordnow;
        private System.Windows.Forms.TextBox EMPSave1;
        private System.Windows.Forms.Label frmEmpRecordT;
        private System.Windows.Forms.TextBox empname;
    }
}