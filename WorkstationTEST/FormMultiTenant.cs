﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkstationTEST
{
    public partial class FormMultiTenant : Form
    {
        public FormMultiTenant()
        {
            InitializeComponent();
        }
        public string TenantId { get { return tenantvalue.Text; } }
        public void setTenant(List<WorkOrderO> plist)
        {
            var wnoar = new List<TextBox>();
            var tidar = new List<TextBox>();
            var btnar = new List<Button>();
            int iSpace = 2;
            int iCol = 0;
            int iRow = 0;
            int keynum = 0;
            foreach (var item in plist)
            {
                int wh = 20;
                int ww = 100;
                var tidstr = item.TenantId == 101 ? "精密" : (item.TenantId == 103 ? "科技" : item.TenantId.ToString());
                TextBox widtext = new TextBox();
                widtext.Tag = item.TenantId.ToString();
                widtext.Visible = false;
                TextBox wnotext = new TextBox();
                wnotext.Tag = item.TenantId.ToString();
                wnotext.Height = wh; widtext.Width = ww;
                wnotext.Text = item.MakeNo;
                wnotext.Top = keynum * (iSpace * 2 + wnotext.Height) + iSpace;
                wnotext.Left = 0 * (iSpace + wnotext.Width);
                wnotext.Parent = this.FMT;

                TextBox tidtext = new TextBox();
                tidtext.Height = wh; tidtext.Width = ww;
                tidtext.Text = tidstr;
                tidtext.Top = keynum * (iSpace * 2 + wnotext.Height) + iSpace;
                tidtext.Left = 1 * (iSpace + wnotext.Width);
                tidtext.Parent = this.FMT;

                Button tidbtn = new Button();
                tidbtn.Height = wh; tidbtn.Width = ww;
                tidbtn.Tag = item.TenantId.ToString();
                tidbtn.Text = "確定";
                tidbtn.Top = keynum * (iSpace * 2 + wnotext.Height) + iSpace;
                tidbtn.Left = 2 * (iSpace + wnotext.Width);
                tidbtn.Parent = this.FMT;
                tidbtn.Click += new EventHandler(btnEMPALL_ClickD);
                Console.Write("wid=" + item.WorkOrderId + ",sn=" + item.MakeNo + ",ten=" + item.TenantId);
                keynum++;
            }

        }

        private void btnEMPALL_ClickD(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            tenantvalue.Text = tmpButton.Tag.ToString();
            DialogResult = DialogResult.OK;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
