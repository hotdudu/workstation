﻿namespace WorkstationTEST
{
    partial class Numpad
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.NumPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(157, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 22);
            this.textBox1.TabIndex = 0;
            // 
            // NumPanel
            // 
            this.NumPanel.ColumnCount = 3;
            this.NumPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.NumPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.NumPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.NumPanel.Location = new System.Drawing.Point(12, 64);
            this.NumPanel.Name = "NumPanel";
            this.NumPanel.RowCount = 3;
            this.NumPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.NumPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.NumPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.NumPanel.Size = new System.Drawing.Size(501, 491);
            this.NumPanel.TabIndex = 1;
            // 
            // Numpad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 571);
            this.Controls.Add(this.NumPanel);
            this.Controls.Add(this.textBox1);
            this.Name = "Numpad";
            this.Text = "Numpad";
            this.Load += new System.EventHandler(this.Numpad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel NumPanel;
    }
}