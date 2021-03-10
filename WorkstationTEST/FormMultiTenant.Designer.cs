namespace WorkstationTEST
{
    partial class FormMultiTenant
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
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.FMT = new System.Windows.Forms.TableLayoutPanel();
            this.tenantvalue = new System.Windows.Forms.Label();
            this.Empno = new System.Windows.Forms.Label();
            this.partneridvalue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cancel.Location = new System.Drawing.Point(123, 261);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(303, 261);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 1;
            this.ok.Text = "ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Visible = false;
            // 
            // FMT
            // 
            this.FMT.AutoScroll = true;
            this.FMT.ColumnCount = 3;
            this.FMT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.FMT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.FMT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.FMT.Location = new System.Drawing.Point(42, 45);
            this.FMT.Name = "FMT";
            this.FMT.RowCount = 2;
            this.FMT.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FMT.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.FMT.Size = new System.Drawing.Size(456, 152);
            this.FMT.TabIndex = 2;
            // 
            // tenantvalue
            // 
            this.tenantvalue.AutoSize = true;
            this.tenantvalue.Location = new System.Drawing.Point(475, 214);
            this.tenantvalue.Name = "tenantvalue";
            this.tenantvalue.Size = new System.Drawing.Size(0, 12);
            this.tenantvalue.TabIndex = 3;
            this.tenantvalue.Visible = false;
            // 
            // Empno
            // 
            this.Empno.AutoSize = true;
            this.Empno.Location = new System.Drawing.Point(362, 214);
            this.Empno.Name = "Empno";
            this.Empno.Size = new System.Drawing.Size(0, 12);
            this.Empno.TabIndex = 4;
            this.Empno.Visible = false;
            // 
            // partneridvalue
            // 
            this.partneridvalue.AutoSize = true;
            this.partneridvalue.Location = new System.Drawing.Point(454, 251);
            this.partneridvalue.Name = "partneridvalue";
            this.partneridvalue.Size = new System.Drawing.Size(0, 12);
            this.partneridvalue.TabIndex = 5;
            this.partneridvalue.Visible = false;
            // 
            // FormMultiTenant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 397);
            this.Controls.Add(this.partneridvalue);
            this.Controls.Add(this.Empno);
            this.Controls.Add(this.tenantvalue);
            this.Controls.Add(this.FMT);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cancel);
            this.Name = "FormMultiTenant";
            this.Text = "FormMultiTenant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.TableLayoutPanel FMT;
        private System.Windows.Forms.Label tenantvalue;
        private System.Windows.Forms.Label Empno;
        private System.Windows.Forms.Label partneridvalue;
    }
}