using System;
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
        public string Eno { get { return Empno.Text; } }
        public void setTenant(string[] plist)
        {
            var wnoar = new List<TextBox>();
            var tidar = new List<TextBox>();
            var btnar = new List<Button>();
            int iSpace = 2;
            int iCol = 0;
            int iRow = 0;
            int keynum = 0;
            FMT.RowCount = 2;

            FMT.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            foreach (var item in plist)
            {
                int wh = 40;
                int ww = 100;
                var tidstr = item == "101" ? "精密" : (item == "103" ? "科技" : item);
                TextBox widtext = new TextBox();
                widtext.Tag = item;
                widtext.Visible = false;
                TextBox wnotext = new TextBox();
                wnotext.ReadOnly = true;
                wnotext.Font = new Font("", 16, FontStyle.Bold);
                wnotext.Tag = item;
                wnotext.Height = wh; widtext.Width = ww;
                wnotext.Text = item;
                wnotext.Top = keynum * (iSpace * keynum + wnotext.Height) + iSpace;
                wnotext.Left = 0 * (iSpace + wnotext.Width);
                wnotext.Parent = this.FMT;
                TextBox tidtext = new TextBox();
                tidtext.Font = new Font("", 16, FontStyle.Bold);
                tidtext.ReadOnly = true;
                tidtext.Height = wh; tidtext.Width = ww;
                tidtext.Text = tidstr;
                tidtext.Top = keynum * (iSpace * 2 + wnotext.Height) + iSpace;
                tidtext.Left = 1 * (iSpace + wnotext.Width);
                tidtext.Parent = this.FMT;
                Button tidbtn = new Button();
                tidbtn.Font = new Font("", 16, FontStyle.Bold);
                tidbtn.BackColor = Color.MediumSeaGreen;
                tidbtn.Height = wh; tidbtn.Width = ww;
                tidbtn.Tag = item;
                tidbtn.Text = "確定";
                tidbtn.Top = keynum * (iSpace * 2 + wnotext.Height) + iSpace;
                tidbtn.Left = 2 * (iSpace + wnotext.Width);
                tidbtn.Parent = this.FMT;
                tidbtn.Click += new EventHandler(btnEMPALL_ClickD);
                Console.Write("ten=" + item);
                keynum++;
            }

        }

        public void setTenant(List<WorkOrderO> plist)
        {
            var wnoar = new List<TextBox>();
            var tidar = new List<TextBox>();
            var btnar = new List<Button>();
            int iSpace = 2;
            int iCol = 0;
            int iRow = 0;
            int keynum = 0;
            FMT.RowCount = plist.Count;
            FMT.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            foreach (var item in plist)
            {
                int wh = 40;
                int ww = 100;
                var tidstr = item.TenantId == 101 ? "精密" : (item.TenantId == 103 ? "科技" : item.TenantId.ToString());
                TextBox widtext = new TextBox();
                widtext.Tag = item.TenantId.ToString();
                widtext.Visible = false;
                TextBox wnotext = new TextBox();
                wnotext.ReadOnly = true;
                wnotext.Font = new Font("", 16, FontStyle.Bold);
                wnotext.Tag = item.TenantId.ToString();
                wnotext.Height = wh; widtext.Width = ww;
                wnotext.Text = item.MakeNo;
                wnotext.Top = keynum * (iSpace * keynum + wnotext.Height) + iSpace;
                wnotext.Left = 0 * (iSpace + wnotext.Width);
                wnotext.Parent = this.FMT;
                TextBox tidtext = new TextBox();
                tidtext.Font = new Font("", 16, FontStyle.Bold);
                tidtext.ReadOnly = true;
                tidtext.Height = wh; tidtext.Width = ww;
                tidtext.Text = tidstr;
                tidtext.Top = keynum * (iSpace * 2 + wnotext.Height) + iSpace;
                tidtext.Left = 1 * (iSpace + wnotext.Width);
                tidtext.Parent = this.FMT;
                Button tidbtn = new Button();
                tidbtn.Font = new Font("", 16, FontStyle.Bold);
                tidbtn.BackColor = Color.MediumSeaGreen;
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
        public void setTenant(List<WorkOrder> plist)
        {
            var wnoar = new List<TextBox>();
            var tidar = new List<TextBox>();
            var btnar = new List<Button>();
            int iSpace = 2;
            int iCol = 0;
            int iRow = 0;
            int keynum = 0;
            FMT.RowCount = plist.Count;
            FMT.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            foreach (var item in plist)
            {
                int wh = 40;
                int ww = 100;
                var tidstr = item.TenantId == 101 ? "精密" : (item.TenantId == 103 ? "科技" : item.TenantId.ToString());
                TextBox widtext = new TextBox();
                widtext.Tag = item.TenantId.ToString();
                widtext.Visible = false;
                TextBox wnotext = new TextBox();
                wnotext.ReadOnly = true;
                wnotext.Font = new Font("", 16, FontStyle.Bold);
                wnotext.Tag = item.TenantId.ToString();
                wnotext.Height = wh; widtext.Width = ww;
                wnotext.Text = item.MakeNo;
                wnotext.Top = keynum * (iSpace * keynum + wnotext.Height) + iSpace;
                wnotext.Left = 0 * (iSpace + wnotext.Width);
                wnotext.Parent = this.FMT;
                TextBox tidtext = new TextBox();
                tidtext.Font = new Font("", 16, FontStyle.Bold);
                tidtext.ReadOnly = true;
                tidtext.Height = wh; tidtext.Width = ww;
                tidtext.Text = tidstr;
                tidtext.Top = keynum * (iSpace * 2 + wnotext.Height) + iSpace;
                tidtext.Left = 1 * (iSpace + wnotext.Width);
                tidtext.Parent = this.FMT;
                Button tidbtn = new Button();
                tidbtn.Font = new Font("", 16, FontStyle.Bold);
                tidbtn.BackColor = Color.MediumSeaGreen;
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

        public void setTenant2(List<Tenant> tlist)
        {
            var wnoar = new List<TextBox>();
            var tidar = new List<TextBox>();
            var btnar = new List<Button>();
            int iSpace = 2;
            int iCol = 0;
            int iRow = 0;
            int keynum = 0;
            FMT.CellBorderStyle= TableLayoutPanelCellBorderStyle.Outset;
            foreach (var item in tlist)
            {
                int wh = 40;
                int ww = 100;
                var tidstr = string.IsNullOrEmpty(item.Alias) ? item.ShortName: item.Alias;
                TextBox widtext = new TextBox();
                widtext.Tag = item.TenantId.ToString();
                widtext.Visible = false;
                TextBox wnotext = new TextBox();                
                wnotext.ReadOnly = true;
                wnotext.Font= new Font("", 16, FontStyle.Bold);
                wnotext.Tag = item.TenantId.ToString();
                wnotext.Height = wh; widtext.Width = ww;
                wnotext.Text = item.TenantId;
                wnotext.Top = keynum * (iSpace * 2 + wnotext.Height) + iSpace;
                wnotext.Left = 0 * (iSpace + wnotext.Width);
                wnotext.Parent = this.FMT;
                TextBox tidtext = new TextBox();
                tidtext.Font= new Font("", 16, FontStyle.Bold);
                tidtext.ReadOnly = true;
                tidtext.Height = wh; tidtext.Width = ww;
                tidtext.Text = tidstr;
                tidtext.Top = keynum * (iSpace * 2 + wnotext.Height) + iSpace;
                tidtext.Left = 1 * (iSpace + wnotext.Width);
                tidtext.Parent = this.FMT;
                Button tidbtn = new Button();
                tidbtn.Font= new Font("", 16, FontStyle.Bold);
                tidbtn.Height = wh; tidbtn.Width = ww;
                tidbtn.Tag = item.TenantId.ToString();
                tidbtn.BackColor = Color.MediumSeaGreen;
                tidbtn.Text = "確定";
                tidbtn.Top = keynum * (iSpace * 2 + wnotext.Height) + iSpace;
                tidbtn.Left = 2 * (iSpace + wnotext.Width);
                tidbtn.Parent = this.FMT;
                tidbtn.Click += new EventHandler(btnEMPALL_ClickD);
                keynum++;
            }

        }

        public void setTenantm(string[] rno,string[] tenant)
        {
            var wnoar = new List<TextBox>();
            var tidar = new List<TextBox>();
            var btnar = new List<Button>();
            int iSpace = 2;
            int iCol = 0;
            int iRow = 0;
            int keynum = 0;
            FMT.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            for (var i=0;i<rno.Length;i++)
            {
                int wh = 40;
                int ww = 100;
                var tidstr = tenant[i] == "103" ? "科技" :(tenant[i]=="101"?"精密":tenant[i]);
                TextBox widtext = new TextBox();
                widtext.Tag = tenant[i];
                widtext.Visible = false;
                TextBox wnotext = new TextBox();
                wnotext.ReadOnly = true;
                wnotext.Font = new Font("", 16, FontStyle.Bold);
                wnotext.Tag = rno[i];
                wnotext.Height = wh; widtext.Width = ww;
                wnotext.Text = rno[i];
                wnotext.Top = keynum * (iSpace * 2 + wnotext.Height) + iSpace;
                wnotext.Left = 0 * (iSpace + wnotext.Width);
                wnotext.Parent = this.FMT;
                TextBox tidtext = new TextBox();
                tidtext.Font = new Font("", 16, FontStyle.Bold);
                tidtext.ReadOnly = true;
                tidtext.Height = wh; tidtext.Width = ww;
                tidtext.Text = tidstr;
                tidtext.Top = keynum * (iSpace * 2 + wnotext.Height) + iSpace;
                tidtext.Left = 1 * (iSpace + wnotext.Width);
                tidtext.Parent = this.FMT;
                Button tidbtn = new Button();
                tidbtn.Font = new Font("", 16, FontStyle.Bold);
                tidbtn.Height = wh; tidbtn.Width = ww;
                tidbtn.Tag = tenant[i]+":"+rno[i];
                tidbtn.BackColor = Color.MediumSeaGreen;
                tidbtn.Text = "確定";
                tidbtn.Top = keynum * (iSpace * 2 + wnotext.Height) + iSpace;
                tidbtn.Left = 2 * (iSpace + wnotext.Width);
                tidbtn.Parent = this.FMT;
                tidbtn.Click += new EventHandler(btnEMPALL_Click2);
                keynum++;
            }

        }


        private void btnEMPALL_ClickD(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            tenantvalue.Text = tmpButton.Tag.ToString();
            DialogResult = DialogResult.OK;
        }
        private void btnEMPALL_Click2(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            string rdata=tmpButton.Tag.ToString();
            var rs = rdata.Split(':');
            tenantvalue.Text = rs[0];
            Empno.Text = rs[1];
            DialogResult = DialogResult.OK;
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
