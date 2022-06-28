﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkstationTEST
{
    public partial class FinishItem : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
       // [DllImport("user32.dll", CharSet = CharSet.Auto)]
       // public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
       // public const int WM_CLOSE = 0x10;
        public FinishItem(frmMenu fmenu)
        {
            InitializeComponent();
            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                lang = oTINI.getKeyValue("SYSTEM", "LANGUAGE", "");
                DepartNo = oTINI.getKeyValue("SYSTEM", "DepartNo", "");
                NIG = oTINI.getKeyValue("SYSTEM", "NIG", "");
                DefCompany = oTINI.getKeyValue("SYSTEM", "DefCompany", "");
                ShowTenants = oTINI.getKeyValue("SYSTEM", "ShowTenants", "");
                ShowMachine = int.Parse(oTINI.getKeyValue("SYSTEM", "ShowMachine", ""));
            }
            this.Tag = fmenu;
            this.KeyPreview = true;
            this.Activate();
            this.KeyDown += new KeyEventHandler(mybutton_Click);
        }
        int fullwidth = 600;
        int fullheight = 600;
        int tabpageheight = 400;
        // public string sIP;
        public string sComport = new API("x", "x").COMPORT;
        public Dictionary<string, string> rtext = CreateElement.loadresx("ST");
        Dictionary<string, string> rtext2 = CreateElement.loadresx("WK");

        delegate void Display(Byte[] buffer);

        //emp start
        List<Empm> getemp = new List<Empm>();
        List<Machine> getemachine = new List<Machine>();
        List<Workitem> getwitem = new List<Workitem>();
        List<WorkOrder> getworkorder = new List<WorkOrder>();
        bool debug = false;
        public string DepartNo = "";//部門編號開頭
        public string NIG = "";//不在部門內但要顯示的員工，目前僅能一位，要多位要改API
        public string DefCompany = "";//預設公司
        public string ShowTenants = "";//不同公司但員工姓名相同且身分證號相同的話是否開啟選擇畫面
        public int ShowMachine = 0;//是否顯示設備，以數字型別與Selectindex相加
        string lang = "";
        //emp end
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    /* var frmEmp = new frmEmp();
                     frmEmp.TopLevel = false;
                     frmEmp.Visible = true;
                     tabPage1.Controls.Add(frmEmp);
                     Console.WriteLine("1." + ActiveControl.Name);*/
                    //showemp();
                    break;
                case 2:
                    /* var frmWK = new frmWorkOrder();
                     frmWK.TopLevel = false;
                     frmWK.Visible = true;
                     frmWK.Height = tabControl1.Height - 50;
                     frmWK.Width = tabControl1.Width - 50;
                     var empbtnu = frmWK.Controls.Find("frmWKbtnU", true);
                     var empbtnd = frmWK.Controls.Find("frmWKbtnD", true);
                     var empsave = frmWK.Controls.Find("WKsave", true);
                     empbtnu[0].Location = new Point(frmWK.Width - 200, empbtnu[0].Location.Y);
                     empbtnd[0].Location = new Point(frmWK.Width - 200, empbtnd[0].Location.Y);
                     empsave[0].Location = new Point(frmWK.Width - 200, empbtnu[0].Location.Y - empbtnu[0].Height-20);
                     tabPage2.Controls.Add(frmWK);
                     var wk = frmWK.Controls.Find("frmWKWorkitem", false);
                     var mk = tabPage2.Controls.Find("frmWKMakeno",true);
                      ActiveControl = mk[0];
                     var save = frmWK.Controls.Find("WKsave", false);
                     save[0].Click += new EventHandler(gettabsave);
                     wk[0].TextChanged += new EventHandler(gettab2);*/

                    //showmachine();
                    //showworktime();
                    break;
                case 1:
                    /* var frmWorkTime = new frmWorkTime();
                     frmWorkTime.TopLevel = false;
                     frmWorkTime.Visible = true;
                     frmWorkTime.Height = tabControl1.Height - 50;
                     frmWorkTime.Width = tabControl1.Width - 50;
                     tabPage3.Controls.Add(frmWorkTime);
                     var wtbqty = frmWorkTime.Controls.Find("frmNumshowno", false);*/
                    // wtbqty[0].TextChanged += new EventHandler(gettab3);
                    ActiveControl = frmWKMakeno;
                    frmWKMakeno.TextChanged += new EventHandler(gettabW);
                    frmWKWorkitem.TextChanged += new EventHandler(gettabWI);
                    WKsave.Click += new EventHandler(gettabsave);
                    setnum();
                    showworkorder(true);
                    break;
                case 3:
                   /* var frmBQTY = new frmBadqty();
                    frmBQTY.TopLevel = false;
                    frmBQTY.Visible = true;
                    frmBQTY.Height = tabControl1.Height - 50;
                    frmBQTY.Width = tabControl1.Width - 50;
                    tabPage4.Controls.Add(frmBQTY);
                    var bqty = frmBQTY.Controls.Find("frmNumshowno", false);*/
                  //  bqty[0].TextChanged += new EventHandler(gettab4);
                    break;
                case 4:
                   /* var frmQTY = new frmQTY();
                    frmQTY.TopLevel = false;
                    frmQTY.Visible = true;
                    frmQTY.Height = tabControl1.Height - 50;
                    frmQTY.Width = tabControl1.Width - 50;
                    var qtybtnu = frmQTY.Controls.Find("frmNumbtnU", true);
                    var qtybtnd = frmQTY.Controls.Find("frmNumbtnD", true);
                    qtybtnu[0].Location = new Point(frmQTY.Width - 200, qtybtnu[0].Location.Y);
                    qtybtnd[0].Location = new Point(frmQTY.Width - 200, qtybtnd[0].Location.Y);
                    tabPage5.Controls.Add(frmQTY);
                    var qty = frmQTY.Controls.Find("frmNumshowno", false);
                    Showinformation();
                    qty[0].TextChanged += new EventHandler(gettab4);
                    var save = frmQTY.Controls.Find("save", false);
                    save[0].Click += new EventHandler(savetab);*/
                   
                    break;
            }
        }

        private void FinishItem_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.fullwidth = this.Width;
            this.fullheight = this.Height;
            this.tabpageheight = (int)(this.fullheight * 0.8);
            this.tabControl1.Height = tabpageheight;
            this.tabControl1.Width = this.fullwidth - 10;
            this.tabPage1.Text = this.tabPage1.Text;// rtext[tabPage1.Name];
            //this.tabPage2.Text = "數量";//rtext[tabPage2.Name];
            this.tabPage3.Text = this.tabPage3.Text;// rtext[tabPage3.Name];
            Console.WriteLine("fw=" + fullwidth + ",fh=" + fullheight + ",ch=" + this.tabpageheight);
             var setpageup = new CreateElement();           
             setpageup.SetBtn(button1, "PageUp::PageUp", rtext[button1.Name]);
             setpageup.SetBtn(button2, "PageDown::Next", rtext[button2.Name]);
             setpageup.SetBtn(button3, "Home::Home", rtext[button3.Name]);
             setpageup.SetBtn2(button4, "Escape::Escape", rtext[button4.Name]);
            /* var frmEmp = new frmEmp();
             frmEmp.TopLevel = false;
             frmEmp.Visible = true;
             frmEmp.Height = tabControl1.Height - 50;
             frmEmp.Width = tabControl1.Width - 50;
             var empbtnu = frmEmp.Controls.Find("frmEmpPageU", true);
             var empbtnd = frmEmp.Controls.Find("frmEmpPageD", true);
             empbtnu[0].Location = new Point(frmEmp.Width - 200, empbtnu[0].Location.Y);
             empbtnd[0].Location = new Point(frmEmp.Width - 200, empbtnd[0].Location.Y);
             tabPage1.Controls.Add(frmEmp);
             var emp = frmEmp.Controls.Find("frmEmpshowno", false);
             emp[0].TextChanged += new EventHandler(gettab);*/
            showemp();
            openseria();
        }
        private void frmWKPageU_Click(object sender, EventArgs e)
        {
           // btup(WKPanel, frmWKRecordnow);
        }

        private void frmWKPageD_Click(object sender, EventArgs e)
        {
           // btndown(WKPanel, frmWKRecordnow);
        }


        private void frmEmpPageU_Click(object sender, EventArgs e)
        {
            btup(EMPPanel, frmEmpRecordnow);
        }
        private void frmEmpPageD_Click(object sender, EventArgs e)
        {
            btndown(EMPPanel, frmEmpRecordnow);
        }
        private void btup(Panel Panel, Control recordnow)
        {
            var nowrow = 0;
            var tempn = int.TryParse(recordnow.Text, out nowrow);
            var totalitem = 10;
            if (nowrow > 0)
                nowrow--;
            recordnow.Text = nowrow.ToString();
            var startnum = nowrow * totalitem + 1;
            var endnum = (nowrow + 1) * totalitem;
            var npoint = 0;
            foreach (Control contr in Panel.Controls)
            {
                npoint++;
                if (npoint >= startnum && npoint <= endnum && npoint <= Panel.Controls.Count)
                {
                    contr.Visible = true;
                }
                else
                {
                    contr.Visible = false;
                }
            }

            var height = Panel.Height;
            var vheight = nowrow * Panel.Height;
            if (vheight - (height) < Panel.VerticalScroll.Minimum)
            { Panel.VerticalScroll.Value = Panel.VerticalScroll.Minimum; }
            else
            { Panel.VerticalScroll.Value = vheight; }
            Panel.PerformLayout();
        }
        private void btndown(Panel Panel,Control recordnow)
        {
            var nowrow = 0;
            var tempn = int.TryParse(recordnow.Text, out nowrow);
            var totalitem = 10;
            var totoalrow = Math.Ceiling(Panel.Controls.Count / (decimal)totalitem);
            nowrow++;
            if (nowrow < totoalrow)
                recordnow.Text = nowrow.ToString();
            var startnum = nowrow * totalitem + 1;
            var endnum = (nowrow + 1) * totalitem;
            var npoint = 0;
            var height = Panel.Height;
            var vheight = Panel.Height * nowrow;
            if (nowrow < totoalrow)
            {
                foreach (Control contr in Panel.Controls)
                {
                    npoint++;
                    Console.Write("ptype=" + contr.GetType() + "," + Panel.Controls.Count);
                    if (npoint >= startnum && npoint <= endnum && npoint <= Panel.Controls.Count)
                    {
                        contr.Visible = true;
                    }
                    else
                    {
                        contr.Visible = false;
                    }
                }
                Panel.VerticalScroll.Value = vheight;
                Panel.PerformLayout();
            }

        }
        private void showemp()
        {
            var setpageup = new CreateElement();
            setpageup.SetBtn(frmEmpPageU, "Insert::Insert", rtext["frmWKbtnU"]);
            setpageup.SetBtn(frmEmpPageD, "Delete::Delete", rtext["frmWKbtnD"]);
            getemp = new API("/CHG/Main/Home/getEmployee2/", "http://").GetEmpm(DefCompany, DepartNo, NIG);
            if (getemp.Count() > 0)
            {
                int iSpace = 5;
                int iCol = 0;
                int iRow = 0;
                int ItemsOneRow = 5;
                int totalitem = 10;
                int btnnum = 0;
                var empitemcount = 0;
                var keynum = 0;
                foreach (var empitem in getemp)
                {
                    iRow = keynum / ItemsOneRow;
                    iCol = keynum % ItemsOneRow;
                    var prestr = "BTNfrmEmp";
                    empitemcount++;
                    if (btnnum + 1 > totalitem)
                    {
                        btnnum = 0;
                    }
                    btnnum++;
                    keynum++;
                    var btnkey = "F" + btnnum;
                    var poststr = btnnum.ToString("##");
                    var thisbtnname = prestr + poststr;
                    var thisbtntext = empitem.FullName;
                    var rlist = empitem.Rlist;
                    var IsMultiple = false;
                    var rno = "";
                    var rtenant = "";
                    if (rlist.Count > 1)
                    {
                        IsMultiple = true;
                        var ri = 0;
                        foreach (var ritem in rlist)
                        {
                            rno += (ri == 0 ? ritem.no : "," + ritem.no);
                            rtenant += (ri == 0 ? ritem.tenant : "," + ritem.tenant);
                            ri++;
                        }
                    }
                    Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateEmpBtnm_panel(empitem.EmployeeNo, thisbtntext, empitem.EmployeeId, btnkey, IsMultiple, rno, rtenant, iRow, iCol, iSpace, EMPPanel);
                    empbtn = sethandlerEmp(empbtn);
                    if (keynum > totalitem)
                    {
                        empbtn.Visible = false;
                    }
                    empbtn.TabStop = false;
                    empbtn.TabIndex = 99;
                    // btnemplist.Add(empbtn);
                }
                frmEmpRecordnow.Text = "0";
            }
            frmEmpshowno.TextChanged += new EventHandler(gettab);
        }


        private void showworkorder(bool isinit=false,string makeno="",string wid="",bool iskey=false)
        {
           // frmWKWorkitem.TextChanged += new EventHandler(gettab2);
            WKSaveTenantId.Text = DefCompany;
            int tidval = int.Parse(DefCompany);
            label13.Text = label13.Text;// rtext2[label13.Name];
            label4.Text = label4.Text;//rtext2[label4.Name];
            label5.Text = label5.Text;//rtext2[label5.Name];
            label7.Text = label7.Text;// rtext2[label7.Name];
            label9.Text = label9.Text;// rtext2[label9.Name];
            label12.Text = label12.Text;// rtext2[label12.Name];
            label21.Text = label21.Text;// rtext2[label21.Name];
            infotitle.Text = infotitle.Text;// rtext2[infotitle.Name];
            labelname.Text = labelname.Text;// rtext2[labelname.Name];
            //ActiveControl = frmWKMakeno;
            Console.WriteLine("frmWKload");
           // this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            var setpageup = new CreateElement();
            setpageup.SetBtn((XButton)frmWKPageU, "Insert::Insert", rtext2["frmWKbtnU"]);
            setpageup.SetBtn((XButton)frmWKPageD, "Delete::Delete", rtext2["frmWKbtnD"]);
            setpageup.SetBtn((XButton)WKsave, "F12::F12", rtext2[WKsave.Name]);
            getwitem.Clear();
            if (isinit)
            {
                /*getwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem();
                if (getwitem.Count > 0)
                {
                    WKSaveWorderId.Text = getwitem[0].WorkOrderId.ToString();
                    frmWKMakeno.Tag = WKSaveWorderId.Text;
                }*/
            }
            else
            {
                getworkorder = new API("/CHG/Main/Home/getinfo/", "http://").GetWorkOrder(tidval, makeno);
                if (getworkorder.Count > 0)
                {
                    var R_TenantId = "";
                    if (getworkorder.Count > 1)
                    {
                        FormMultiTenant frmt = new FormMultiTenant();
                        frmt.setTenant(getworkorder);
                        frmt.ShowDialog();
                        R_TenantId = frmt.TenantId;
                    }
                    else
                    {
                        R_TenantId = getworkorder[0].TenantId.ToString();

                    }
                    if (!string.IsNullOrEmpty(R_TenantId))
                    {
                        tidval = int.Parse(R_TenantId);
                    }
                    getworkorder = getworkorder.Where(x => x.TenantId == tidval).ToList();
                    labSpec.Text = getworkorder[0].Specification;
                    labRemark.Text = getworkorder[0].Remark;
                    labPName.Text = getworkorder[0].AssetsNo;
                    labWorkOrder.Text = getworkorder[0].MakeNo;
                    labQty.Text = getworkorder[0].MakeQty.ToString();
                    labAssetsName.Text = getworkorder[0].AssetsName;
                    labUnit.Text = getworkorder[0].UseUnits;
                    WKSaveTenantId.Text = getworkorder[0].TenantId.ToString();
                    WKSaveMakeNo.Text = getworkorder[0].MakeNo;
                    WKSaveSpecification.Text = getworkorder[0].Specification;
                    WKSaveWorkqty.Text = getworkorder[0].MakeQty.ToString();
                    WKSaveWorderId.Text = getworkorder[0].WorkOrderId.ToString();
                    var pwid = wid != "" ? wid:getworkorder[0].WorkOrderId.ToString();
                    int.TryParse(WKSaveTenantId.Text, out tidval);
                    Guid gwid;
                    var isguid = Guid.TryParse(pwid, out gwid);
                    if (isguid)
                    {
                       // getwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem(tidval, makeno, gwid);
                    }
                    else
                    {
                        Console.WriteLine("輸入工令格式錯誤");
                        //ActiveControl = this.frmWKMakeno;
                    }
                }
                else
                {
                    //MessageBox.Show("無此工令資料");
                    Console.WriteLine("無此工令資料");
                    //ActiveControl = this.frmWKMakeno;
                }
            }
        }

        private void setnum() {
           // MessageBox.Show("c=" + NumPanel.Controls.Count);
            if (NumPanel.Controls.Count == 0)
            {
                Int32 tlpColumCount = NumPanel.ColumnCount;
                Int32 tlpRowCount = NumPanel.RowCount;
                string[] numlist = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ".", "Clear" };
                string[] keylist = new string[] { "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", "Decimal", "Divide" };
                List<Button> btnnumlist = new List<Button>();
                var numitemcount = 0;
                for (var empitem = 0; empitem < numlist.Length; empitem++)
                {
                    var prestr = "BTNfrmNum";
                    numitemcount++;
                    var poststr = numitemcount.ToString("##");
                    var thisbtnname = prestr + poststr;
                    var thisbtntext = numlist[empitem];
                    var btnkey = keylist[empitem];
                    Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateNumBtn(numlist[empitem], keylist[empitem]);
                    empbtn = sethandlernum(empbtn);
                    empbtn.TabStop = false;
                    btnnumlist.Add(empbtn);
                }
                var j = 0;
                for (var i = 0; i < tlpRowCount; i += tlpColumCount)
                {
                    for (; j < btnnumlist.Count && j < tlpColumCount * tlpRowCount; j++)
                    {
                        // Console.WriteLine("Lqty-i=" + i + ",j=" + j + ",name=" + btnnumlist[j].Name + ",text=" + btnnumlist[j].Text);
                        NumPanel.Controls.Add(btnnumlist[j], j, i);
                       // frmNumRecordnow.Text = j.ToString();
                    }
                }
            }

        }

       /* private void showworktime()
        {
            var initunit = labUnit.Text;
            var rp = RPanel;
            TableLayoutPanel rpc = NumPanel;
            var setpageup = new CreateElement();
            setpageup.SetBtn(save, "F12::F12", rtext2["WKsave"]);
            setpageup.SetBtn(return1, "Return::Return", "Enter");
            if (rp.Controls.Count > 0)
            {
                for (int i = rp.Controls.Count - 1; i >= 0; --i)
                    rp.Controls[i].Dispose();
                rp.Controls.Clear();
            }
            if (NumPanel.Controls.Count > 0)
            {
                for (int i = NumPanel.Controls.Count - 1; i >= 0; --i)
                    NumPanel.Controls[i].Dispose();
                NumPanel.Controls.Clear();
            }
            var tableheadstr = new string[] { };
            var textarray = new string[] { };
            if (initunit == "Set")
            {
                tableheadstr = new string[] { "Go" + rtext["completeqty"], "NoGo" + rtext["completeqty"] };
                textarray = new string[] {"GoCompleteQty", "NoGoCompleteQty"};

            }
            else
            {
                tableheadstr = new string[] {rtext["completeqty"]};
                textarray = new string[] {"CompleteQty"};
            }
            for (var a = 0; a < tableheadstr.Count(); a++)
            {
                TextBox templab = new TextBox();
                templab.Text = tableheadstr[a];
                if (textarray[a].ToLower().Contains("bad"))
                {
                    templab.BackColor = Color.Red;
                }
                if (lang != "CHT")
                {
                    if (textarray[a] == "NoGoCompleteQty" || textarray[a] == "NoGoBadQty")
                    {
                        templab.Width = 150;
                    }
                    if (textarray[a] == "GoCompleteQty" || textarray[a] == "GoBadQty")
                    {
                        templab.Width = 120;
                    }
                }
                templab.ReadOnly = true;
                templab.Margin = new Padding(0);
                templab.TabIndex = 999;
                templab.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
                rp.Controls.Add(templab, a, 0);
                TextBox numbox = new TextBox();
                numbox.Name = textarray[a];
                if (textarray[a] == "Adjust")
                {
                    numbox.Text = "0";
                }
                if (textarray[a].ToLower().Contains("bad"))
                {
                    numbox.ForeColor = Color.Red;
                }
                if (lang != "CHT")
                {
                    if (textarray[a] == "NoGoCompleteQty" || textarray[a] == "NoGoBadQty")
                    {
                        numbox.Width = 150;
                    }
                    if (textarray[a] == "GoCompleteQty" || textarray[a] == "GoBadQty")
                    {
                        numbox.Width = 120;
                    }
                }
                numbox.TabIndex = a + 1;
                numbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
                numbox.GotFocus += new EventHandler(BtnGotfocus);
                rp.Controls.Add(numbox, a, 1);
            }
            Int32 tlpColumCount = NumPanel.ColumnCount;
            Int32 tlpRowCount = NumPanel.RowCount;
            string[] numlist = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ".", "Clear" };
            string[] keylist = new string[] { "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", "Decimal", "Divide" };
            List<Button> btnnumlist = new List<Button>();
            var numitemcount = 0;
            for (var empitem = 0; empitem < numlist.Length; empitem++)
            {
                var prestr = "BTNfrmNum";
                numitemcount++;
                var poststr = numitemcount.ToString("##");
                var thisbtnname = prestr + poststr;
                var thisbtntext = numlist[empitem];
                var btnkey = keylist[empitem];
                Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateNumBtn(numlist[empitem], keylist[empitem]);
                empbtn = sethandlernum(empbtn);
                empbtn.TabStop = false;
                btnnumlist.Add(empbtn);
            }
            var j = 0;
            for (var i = 0; i < tlpRowCount; i += tlpColumCount)
            {
                for (; j < btnnumlist.Count && j < tlpColumCount * tlpRowCount; j++)
                {
                    // Console.WriteLine("Lqty-i=" + i + ",j=" + j + ",name=" + btnnumlist[j].Name + ",text=" + btnnumlist[j].Text);
                    NumPanel.Controls.Add(btnnumlist[j], j, i);
                    frmNumRecordnow.Text = j.ToString();
                }
            }
           var st2 = tabPage2.Controls.Find("GoCompleteQty", true);
            if(st2.Length==0)
                st2 = tabPage2.Controls.Find("CompleteQty", true);
            if(st2.Length>0)
                ActiveControl = st2[0];
            //var wtbqty = frmNumshowno;
            Showinformation();

        }*/
        private void getinform(object sender, EventArgs e)
        {
            //Showinformation();
        }
       public void SetNumNO(string info)
        {
            var nowfocusc = this.Controls.Find("frmWKWorkitem", true);
            if (info == "Clear")
            {
                if (nowfocusc.Length > 0)
                    nowfocusc[0].Text = "";
                // actfocused.Text = "";
                // frmNumshowno.Text = "";
            }
            else
            {
                if (nowfocusc.Length > 0)
                    nowfocusc[0].Text = nowfocusc[0].Text + info;
                //  if (nowfocusc.Length > 0) 
                //    nowfocusc[0].Text = nowfocusc[0].Text + info;
                // actfocused.Text = actfocused.Text+info;
                // frmNumshowno.Text = frmNumshowno.Text + info;
            }
        }
       public Button sethandlernum(Button bt)
        {
            Button sbt = bt;
            sbt.Click += new EventHandler(btnnumALL_Click);
            return sbt;
        }

       private void btnnumALL_Click(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            SetNumNO(tmpButton.Tag.ToString());

        }
        public void newSetEmpNO(string info)
        {
            var empinfos = info.Split(':');
            if (empinfos.Length == 3)
            {
                frmEmpshowno.Text = empinfos[0];
                empname.Text = empinfos[1];
            }
            else if (empinfos.Length == 5)
            {
                if (ShowTenants == "1")
                {
                    var rno = empinfos[2].Split(',');
                    var rten = empinfos[3].Split(',');
                    FormMultiTenant frmt = new FormMultiTenant();
                    frmt.setTenantm(rno, rten);
                    frmt.ShowDialog();
                    frmEmpshowno.Text = frmt.Eno;
                    empname.Text = empinfos[1];
                }
                else if (ShowTenants == "0")
                {
                    frmEmpshowno.Text = empinfos[0];
                    empname.Text = empinfos[1];
                }
            }
            else
            {
                frmEmpshowno.Text = info;
            }

        }
        public Button sethandlerEmp(Button bt)
        {
            Button sbt = bt;
            sbt.Click += new EventHandler(newbtnEMPALL_Click);
            return sbt;
        }

        private void newbtnEMPALL_Click(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            newSetEmpNO(tmpButton.Tag.ToString());
        }

        public Button sethandlerWorkOrder(Button bt)
        {
            Button sbt = bt;
            sbt.Click += new EventHandler(btnEMPALL_ClickWorkOrder);
            return sbt;
        }
        private void btnEMPALL_ClickWorkOrder(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            SetEmpNOWorkOrder(tmpButton.Tag.ToString(), true);
        }
        public void SetEmpNOWorkOrder(string info, bool isdef = false)
        {
            var infoarray = info.Split(':');
            var wkno = infoarray[infoarray.Length - 1];
            var witemid = infoarray[0];
            var workid = infoarray[1];
            if (!isdef)
            {
                WKSaveMakeNo.Text = labWorkOrder.Text;
                WKSaveSpecification.Text = labSpec.Text;
                WKSaveWorkqty.Text = labQty.Text;
                WKSaveWorderId.Text = frmWKMakeno.Tag.ToString();
            }

            WKSaveWitemId.Text = witemid;
            WKSaveWorkId.Text = workid;


            WKSaveWorkNo.Text = wkno;

            WKSaveWorkName.Text = infoarray[2];
            Console.WriteLine("wkno=" + frmWKWorkitem.Text + ",witemid=" + witemid + ",workid=" + workid + ",workorderid=" + WKSaveWorderId.Text);
            frmWKWorkitem.Text = wkno;
        }
        private void mybutton_Click(object sender, KeyEventArgs e)
        {
            Console.WriteLine("keycoe=" + e.KeyCode);
            setkeymap(e.KeyCode.ToString());
            //tmpb.PerformClick();
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Byte[] buffer = new Byte[1024];
            Int32 length = (sender as System.IO.Ports.SerialPort).Read(buffer, 0, buffer.Length);
            Array.Resize(ref buffer, length);
            Display d = new Display(DisplayText);
            this.Invoke(d, new Object[] { buffer });
        }
        private void BtnGotfocus(object sender, EventArgs e)
        {
            TextBox tmpButton = (TextBox)sender;
            var ft = tabPage3.Controls.Find("focust", true);
            ft[0].Text = tmpButton.Name;
            Console.Write("gotfocus=" + ft[0].Text);
        }
        public void openseria()
        {
            serialPort1.PortName = sComport;
            serialPort1.BaudRate = 115200;
            serialPort1.DataBits = 8;
            serialPort1.Parity = System.IO.Ports.Parity.None;
            serialPort1.StopBits = System.IO.Ports.StopBits.One;
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("error:" + ex.Message);
                }
                
            }
                
            //Console.WriteLine("isopen:"+serialPort1.IsOpen);
        }

        public void DisplayText(string clickData)
        { ShowData(clickData); }
        private void DisplayText(Byte[] buffer)
        {
            var scanData = System.Text.Encoding.ASCII.GetString(buffer).ToString().Trim();
            ShowData(scanData);

        }

        public string ShowData(string data)
        {
            //Console.WriteLine(data);
            int index = tabControl1.SelectedIndex;
            var tabindex = tabControl1.SelectedIndex;
            Console.WriteLine("nowtab=" + tabindex);
            /* if (tabindex == 0)
             {
                 var dataarray = data.Split(new string[] { "::" }, StringSplitOptions.None);
                 if(dataarray.Length==3)
                 {
                     var tt = tabPage1.Controls.Find("frmEmpshowno", true);
                     tt[0].Text = data;
                     Console.WriteLine("tt="+tt[0].Name);
                 }

             }
             if (tabindex == 1)
             {
                 var tt = tabPage2.Controls.Find("frmWKMakeno", true);
                 tt[0].Text = data;

                 Console.WriteLine("tt=" + tt[0].Name);
             }
             if (tabindex == 2)
             {

             }
             if (tabindex == 3)
             {

             }*/
            var dataarray = data.Split(new string[] { "::" }, StringSplitOptions.None);
            if (dataarray.Length == 2)
            {
                var pkey = dataarray[1];
                Console.WriteLine("pkey=" + pkey);
                setkeymap(pkey);
            }
            if (dataarray.Length >= 3)
            {
                var isp  = dataarray[1].StartsWith("P");
                Console.WriteLine("showdata=" + isp);
                if (isp)
                {
                    setkeymap("XXX", data,isp);
                }
                else
                {
                    setkeymap("XXX", data);
                }
                
            }
            return data;
        }
        private void gettab(object sender, EventArgs e)
        {
            var nowindex = this.tabControl1.SelectedIndex;
            if (frmEmpshowno.Text == "")
            {
                this.tabControl1.SelectedTab = tabPage1;
            }
            else
            {
                this.tabControl1.SelectedTab = tabPage3;
            }
            

            Console.WriteLine("tab1 name=" + this.tabControl1.SelectedTab.Name+","+ frmEmpshowno.Text);

        }
        private void gettabM(object sender, EventArgs e)
        {
            var nowindex = this.tabControl1.SelectedIndex;
           /* if (frmMachineshowno.Text == "")
            {
                //this.tabControl1.SelectedTab = tabPage1;
            }
            else
            {
                this.tabControl1.SelectedTab = tabPage3;
            }*/


            Console.WriteLine("tab1 name=" + this.tabControl1.SelectedTab.Name + "," + frmEmpshowno.Text);

        }
        private void gettabW(object sender, EventArgs e)
        {

            var gmkno = frmWKMakeno;
            var gwk = frmWKWorkitem;
            var text = gmkno.Text;
            //infotitle.Text = "";
            var tid = DefCompany;
            int tidval = 0;
            bool iskey = false;
            if (text != "")
            {
                Console.WriteLine("text=" + text);
                string makeno = "";
                string wid = "";
                Console.WriteLine("m=" + text);
                if (text.IndexOf("::") >= 0)
                {
                    iskey = true;
                    string[] data = text.Split(new string[] { "::" }, StringSplitOptions.None);
                    makeno = data[0];
                    wid = data.Length == 4 ? data[data.Length - 2] : data[data.Length - 1];
                    tid = data.Length == 4 ? data[data.Length - 1] : "";
                    if (data.Length == 4)
                    {
                        tidval = int.Parse(tid);
                    }

                    if (debug)
                    {
                        MessageBox.Show("wid=" + wid + ",tid=" + tid);
                    }

                    WKSaveTenantId.Text = tid;
                }
                showworkorder(false, makeno, wid,iskey);
                ActiveControl = frmWKWorkitem;
                var empnameinfo = empname;
                var empnoinfo = frmEmpshowno;
                var wknoinfo = WKSaveWorkNo;
                var wknameinfo = WKSaveWorkName;
                var empnot = infoempno;
                var empnamet = infoempname;
                var wknot = infowkno;
                var wknamet = infowkname;

                var lab4 = label4;
                var lab5 = label5;
                lab4.Visible = true;
                lab5.Visible = true;
                empnamet.Text = empnameinfo.Text;
                empnot.Text = empnoinfo.Text;
                wknot.Text = wknoinfo.Text;
                wknamet.Text = wknameinfo.Text;
                var ititle = infotitle;
                ititle.Text = ititle.Text;//rtext[ititle.Name];
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#111211");
                ititle.ForeColor = col;
                infowkno.Text = labWorkOrder.Text;

            }
        }
        private void gettabWI(object sender, EventArgs e)
        {
            CQty.Text = frmWKWorkitem.Text;
        }
        private void gettabnowo(object sender, EventArgs e)
        {

            MessageBox.Show("init");

        }
       /* private void gettab2(object sender, EventArgs e)
        {
            var gmkno = frmWKMakeno;
            var gwk = frmWKWorkitem;
            if (gmkno.Text == "" && gwk.Text != "")
            {
                this.tabControl1.SelectedTab = tabPage2;
                Console.WriteLine("tab=2");
            }
            else
            {
                this.tabControl1.SelectedTab = tabPage2;
            }
        }*/
        private void gettab3(object sender, EventArgs e)
        {
            // this.tabControl1.SelectedTab = tabPage4;
            Console.WriteLine("tab3 name=" + this.tabControl1.SelectedTab.Name );
        }
        /*private void gettab4(object sender, EventArgs e)
        {
            Showinformation();
            Console.WriteLine("tab4 name=" + this.tabControl1.SelectedTab.Name );
        }*/
        private void gettabsave(object sender, EventArgs e)
        {
            savetab(true);
        }
        private void savetab(bool isclick=false)
        {
            var empno = frmEmpshowno.Text;
            var info = infotitle;
            var workorderid = WKSaveWorderId;
            // var AssetsItemId = frmAssetsItemId;
            // var worktime = tabPage3.Controls.Find("frmNumshowno", true);
            // var bqty = tabPage4.Controls.Find("frmNumshowno", true);
            // var comqty = tabPage5.Controls.Find("frmNumshowno", true);
            var comQty = 0m;
            Decimal.TryParse(frmWKWorkitem.Text,out comQty);
            var status = 0;
            var date = DateTime.Now;
            var WKSaveTenantIdval = WKSaveTenantId;
            var Specification = WKSaveSpecification.Text;
            var MakeNo = WKSaveMakeNo.Text;
            var AssetsName = labAssetsName.Text;
            var tid = 0;
            int.TryParse(WKSaveTenantIdval.Text, out tid);
            if(workorderid.Text == "")
            {
                info.Text=rtext["notselect"];
                info.ForeColor = Color.Crimson;
            }
            else
            {
               // MessageBox.Show("emp=" + empno + ",info=" + info + ",workorderid=" + workorderid + ",qty=" + comQty + ",t=" + WKSaveTenantIdval);
                Guid id = Guid.NewGuid();
                string dbPath = Directory.GetCurrentDirectory() + "\\" + "wd2.db3";
                string cnStr = "data source=" + dbPath + ";Version=3;";
                Console.WriteLine("db=" + File.Exists(dbPath) + "," + dbPath);
                var wdritem = new FinishItems()
                {
                    Id = id.ToString(),
                    EmployeeId = empno,
                    WorkorderId = workorderid.Text.ToString(),
                    TenantId = tid,
                    Qty = comQty,
                    Status = 0,
                    Date = DateTime.Now
                };
                if (File.Exists(dbPath))
                {
                    using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                    {
                        var insertScript = "INSERT INTO FinishItem (Id,TenantId,WorkOrderId,Empno,Qty,Status,Date,MakeNo,WorkName,Specification) VALUES (@Id, @TenantId, @WorkOrderId, @Empno, @Qty, @Status,@Date,@MakeNo,@WorkName,@Specification)";
                        SQLiteCommand cmd = new SQLiteCommand(insertScript, conn);
                        cmd.Parameters.AddWithValue("@Id", id.ToString());
                        cmd.Parameters.AddWithValue("@TenantId", tid);
                        cmd.Parameters.AddWithValue("@WorkOrderId", workorderid.Text);
                        cmd.Parameters.AddWithValue("@Empno", empno);
                        cmd.Parameters.AddWithValue("@Qty",comQty);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Today.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@Specification", Specification);
                        cmd.Parameters.AddWithValue("@MakeNo", MakeNo);
                        cmd.Parameters.AddWithValue("@WorkName", AssetsName);
                        conn.Open();
                        var s = new saving();
                        s.Show();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            var up = new API("/CHG/Main/Home/AddOutsourceFinish/", "http://").UploadServerFinish(wdritem);
                            if (up.dayid.HasValue)
                            {
                                var updatesql = "Update FinishItem SET isupdate=1 where Id=@id";
                                SQLiteCommand updatecmd = new SQLiteCommand(updatesql, conn);
                                updatecmd.Parameters.AddWithValue("@Id", up.dayid.ToString());
                                updatecmd.ExecuteNonQuery();
                                cleardata(false);
                            }
                            /*var savestat = tabPage5.Controls.Find("SaveStat", true);
                            savestat[0].Visible = true;
                            savestat[0].Text = "儲存成功";                       
                            var up = new API("/CHG/Main/Home/Addworkdayreport2/", "http://").UploadServer(wdritem);
                            if (up.HasValue)
                            {
                                var updatesql = "Update WorkDayReports SET isupdate=1 where DayReportId=@DayReportId";
                                SQLiteCommand updatecmd = new SQLiteCommand(updatesql, conn);
                                updatecmd.Parameters.AddWithValue("@DayReportId", up.ToString());
                                updatecmd.ExecuteNonQuery();
                            }
                            Console.WriteLine("up="+up);

                            tabControl1.SelectedIndex = 1;
                            savestat[0].Visible = false;*/

                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        conn.Close();
                        s.Close();
                        ActiveControl = frmWKMakeno;
                    }
                }
            }

           // tabControl1.SelectedTab = tabPage2;
        }

        public void cleardata(bool finish)
        {
            //bnum
            // var bno = tabPage4.Controls.Find("frmNumshowno", true);
            //bnum

            //num
            /* var msgemp = tabPage5.Controls.Find("msgemp", true);
             var msgmkno = tabPage5.Controls.Find("msgmkno", true);
             var msgwork = tabPage5.Controls.Find("msgwork", true);
             var msgcomplet = tabPage5.Controls.Find("msgcomplet", true);
             var msgbad = tabPage5.Controls.Find("msgbad", true);
             var msgworktime = tabPage5.Controls.Find("msgworktime", true);
             var nno = tabPage5.Controls.Find("frmNumshowno", true);*/
            //num

            //worktime
            //var wt = tabPage3.Controls.Find("frmNumshowno", true);
            //worktime
            //wk
            var wkn = frmWKMakeno;
            var wki = frmWKWorkitem;
            var wkr = frmWKRecordnow;
            var wkt = frmWKRecordT;
            var wksm = WKSaveMakeNo;
            var wksw = WKSaveWitemId;
            var wksmn = WKSaveMNo;
            var wkss = WKSaveSpecification;
            var wksq = WKSaveWorkqty;
            var wkm = WKSaveMakeNo;
            var workorderid = WKSaveWorderId;
            var workid = WKSaveWorkId;
            var lw = labWorkOrder;
            var ln = labPName;
            var ls = labSpec;
            var lq = labQty;
            var la = labAssetsName;
            var lu = labUnit;

            var wkwno = WKSaveWorkNo;
            var wkwna = WKSaveWorkName;
            var leno = infoempno;
            var lena = infoempname;
            var lwno = infowkno;
            var lwna = infowkname;

            var ititle = infotitle;
            var lab4 = label4;
            var lab5 = label5;
            ititle.Text = "";
            lab4.Visible = true;
            lab5.Visible = true;
            //wk
            try
            {
                //nno[0].Text = string.Empty;
                //bno[0].Text = string.Empty;
               // wt[0].Text = string.Empty;
                wki.Text = string.Empty;
                wkm.Text = string.Empty;
                wkn.Text = string.Empty;
                wkr.Text = string.Empty;
                wksm.Text = string.Empty;
                wksmn.Text = string.Empty;
                wksq.Text = string.Empty;
                wkss.Text = string.Empty;
                wksw.Text = string.Empty;
                wkt.Text = string.Empty;
                wkn.Tag = string.Empty;
                workorderid.Text = string.Empty;
                workid.Text = string.Empty;
                ln.Text = string.Empty;
                lw.Text = string.Empty;
                ls.Text = string.Empty;
                lq.Text = string.Empty;
                la.Text = string.Empty;
                lu.Text = string.Empty;
                wkwno.Text = string.Empty;
                wkwna.Text = string.Empty;
                leno.Text = string.Empty;
                lena.Text = string.Empty;
                lwna.Text = string.Empty;
                lwno.Text = string.Empty;
                // msgemp[0].Text = string.Empty;
                // msgmkno[0].Text = string.Empty;
                // msgwork[0].Text = string.Empty;
                // msgcomplet[0].Text = string.Empty;
                // msgbad[0].Text = string.Empty;
                // msgworktime[0].Text = string.Empty;
                if (finish)
                {
                    var emn = tabPage1.Controls.Find("frmEmpshowno", true);
                    // var emr = tabPage1.Controls.Find("frmEmpRecordnow", true);
                    //var emt = tabPage1.Controls.Find("frmEmpRecordT", true);           
                    emn[0].Text = string.Empty;
                    var ena = tabPage1.Controls.Find("empname", true);
                    ena[0].Text = string.Empty;
                    //emr[0].Text = string.Empty;
                    //emt[0].Text = string.Empty;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("clear:" + ex.Message);
            }

            //tabControl1.SelectedTab = tabPage2;
        }

        public static Control FindFocusedControl(Control control)
        {
            ContainerControl container = control as ContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as ContainerControl;
            }
            return control;
        }

        public void setkeymap(string keychar, string data = "",bool isp=false)
        {
            var t = this.tabControl1.SelectedIndex;
            Console.WriteLine("st=" + t + ",ind=" + keychar);
            var keyupper = keychar.ToString();
            if (keyupper == "PageUp")
            {
                button1.PerformClick();
            }
            if (keyupper == "Next")
            {
                button2.PerformClick();
            }
            if (keyupper == "Home")
            {
                button3.PerformClick();
            }
            if (keyupper == "Escape")
            {
                button4.PerformClick();
            }
            if (t == 0)
            {
                var up = frmEmpPageU;
                var down = frmEmpPageD;
                string[] keyarray = new string[] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10" };
                if (keyupper == "Delete")
                {
                    down.PerformClick();
                }
                if (keyupper == "Insert")
                {
                    up.PerformClick();
                }
                if (isp)
                {
                    var saveno = frmEmpshowno;
                   var infoarray = data.Split(new string[] { "::" }, StringSplitOptions.None);
                    saveno.Text = infoarray[0];
                }
                else
                {
                    if (keyarray.Contains(keyupper))
                    {
                        Console.WriteLine("kc");
                        for (var i = 0; i < keyarray.Length; i++)
                        {
                            if (keyarray[i] == keyupper)
                            {
                                var estr = "BTNfrmEmp" + (i + 1);
                                Console.WriteLine("ke=" + keyupper + "," + keyarray[i] + estr);
                                var tempbtn = tabPage1.Controls.Find(estr, true);
                                if (tempbtn.Length > 0)
                                {
                                    var btn = tempbtn.Where(x => x.Visible == true).FirstOrDefault();
                                    if (btn != null)
                                        ((Button)(btn)).PerformClick();
                                }
                            }
                        }
                    }
                }

            }
            if (t == 1)
            {
                var up = frmWKPageU;
                var down = frmWKPageD;
                var WKSaveWorderIdval = WKSaveWorderId;
                var wkmo = frmWKMakeno;
                var wksave = WKsave;
                var wkrnow = frmWKRecordnow;
                var tid = "";
                var tidval = 0;
                List<Workitem> Wgetwitem = new List<Workitem>();
                if (keyupper == "F12")
                {
                    wksave.PerformClick();
                }
                if (keyupper == "Return")
                {
                    showworkorder(false, wkmo.Text.ToUpper());
                }
                string[] keyarray = new string[] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10" };
                if (data == "")
                {
                    var svmk = tabPage3.Controls.Find("labWorkOrder", true);
                    //Console.WriteLine("nodata:"+ svmk[0].Text.ToUpper());
                    if (keyupper == "Delete")
                    {
                        down.PerformClick();
                        //((Button)down[0]).PerformClick();

                       // frmWKbtnD(svmk[0].Text.ToUpper(),Guid.Parse(WKSaveWorderId.Text));
                    }
                    if (keyupper == "Insert")
                    {
                        up.PerformClick();
                        // ((Button)up[0]).PerformClick();
                        //frmWKbtnU(svmk[0].Text.ToUpper(), Guid.Parse(WKSaveWorderId.Text));
                    }
                    if (keyarray.Contains(keyupper))
                    {
                        Console.WriteLine("kc");
                        var wkrec = frmWKRecordnow;
                        var wkrecn = 0;
                        var tempcn = int.TryParse(wkrec.Text, out wkrecn);
                        for (var i = 0; i < keyarray.Length; i++)
                        {
                            if (keyarray[i] == keyupper)
                            {
                                var middlestr = "";
                                if (wkrecn > 0)
                                {
                                    middlestr = (wkrecn * 10).ToString();
                                }
                                Console.WriteLine("ke=" + keyupper + "," + keyarray[i]);
                                var estr = "BTNfrmEmp" +(wkrecn * 10+i + 1);
                                Console.WriteLine("estr=" + estr);
                                var tempbtn = tabPage3.Controls.Find(estr, true);
                                if (tempbtn.Length > 0)
                                {
                                    ((Button)(tempbtn[0])).PerformClick();
                                    Console.WriteLine("per:" + keychar);
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("hasdata");
                    var wup = frmWKPageU;
                    var wdown = frmWKPageD;
                    if (keyupper == "Delete")
                    {
                        wdown.PerformClick();
                    }
                    if (keyupper == "Insert")
                    {
                        wup.PerformClick();
                    }
                    if (isp)
                    {
                        var wkno = tabPage3.Controls.Find("frmWKWorkitem", true);
                        var winfo=data.Split(new string[] { "::" }, StringSplitOptions.None);
                        wkno[0].Text = winfo[0];
                    }
                    else
                    {
                        var tt = frmWKMakeno;
                        tt.Text = data;
                        Console.WriteLine("tt=" + tt.Text);
                    }                    
                }

            }
            if (t == 2)//設備
            {

            }
            if (t == 3)
            {
                if (keyupper == "Return")
                {
                    button2.PerformClick();
                }
                string clearkey = "Divide";
                string[] keyarray = new string[] { "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", "Decimal", "Divide" };
                if (isp)
                {
                    var wkno = tabPage3.Controls.Find("frmNumshowno", true);
                    var winfo = data.Split(new string[] { "::" }, StringSplitOptions.None);
                    wkno[0].Text = winfo[0];
                }
                else
                {
                    if (keyarray.Contains(keyupper))
                    {
                        Console.WriteLine("kc");
                        for (var i = 0; i < keyarray.Length; i++)
                        {
                            if (keyarray[i] == keyupper)
                            {
                                var estr = "BTNfrmEmp" + (i + 1);
                                Console.WriteLine("ke=" + keyupper + "," + keyarray[i] + estr);
                                if (keyupper == clearkey)
                                {
                                    var numno4 = tabPage3.Controls.Find("frmNumshowno", true);
                                    if (numno4.Length > 0)
                                    {
                                        numno4[0].Text = "";
                                    }
                                }
                                else
                                {
                                    var tempbtn = tabPage3.Controls.Find(estr, true);
                                    if (tempbtn.Length > 0)
                                    {
                                        ((Button)(tempbtn[0])).PerformClick();
                                        Console.WriteLine("per:" + keychar);
                                    }
                                }

                            }
                        }
                    }
                }

            }
            if (t == 4)
            {
            }
        }

        public Button sethandlerW(Button bt)
        {
            Button sbt = bt;
            sbt.Click += new EventHandler(btnEMPALL_ClickW);
            return sbt;
        }
        private void btnEMPALL_ClickW(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            SetEmpNOW(tmpButton.Tag.ToString());
        }
       public void SetEmpNOW(string info, bool isdef = false)
        {
            var infoarray = info.Split(':');
            var wkno = infoarray[infoarray.Length - 1];
            var witemid = infoarray[0];
            var workid = infoarray[1];
            var WKSaveMakeNos = tabPage3.Controls.Find("WKSaveMakeNo", true);
            var WKSaveSpecifications = tabPage3.Controls.Find("WKSaveSpecification", true);
            var WKSaveWorkqtys = tabPage3.Controls.Find("WKSaveWorkqty", true);
            var WKSaveWorderIds = tabPage3.Controls.Find("WKSaveWorderId", true);
            var labWorkOrders = tabPage3.Controls.Find("labWorkOrder", true);
            var labSpecs = tabPage3.Controls.Find("labSpec", true);
            var labQtys = tabPage3.Controls.Find("labQty", true);
            var frmWKMakenos = tabPage3.Controls.Find("frmWKMakeno", true);
            var frmWKWorkitems = tabPage3.Controls.Find("frmWKWorkitem", true);
            var WKSaveWitemIds = tabPage3.Controls.Find("WKSaveWitemId", true);
            var WKSaveWorkIds = tabPage3.Controls.Find("WKSaveWorkId", true);
            var WKSaveWorkNos = tabPage3.Controls.Find("WKSaveWorkNo", true);
            var WKSaveWorkNames = tabPage3.Controls.Find("WKSaveWorkName", true);
            var WKSaveMakeNo = WKSaveMakeNos[0];
            var WKSaveSpecification = WKSaveSpecifications[0];
            var WKSaveWorkqty = WKSaveWorkqtys[0];
            var WKSaveWorderId = WKSaveWorderIds[0];
            var labWorkOrder = labWorkOrders[0];
            var labSpec = labSpecs[0];
            var labQty = labQtys[0];
            var frmWKMakeno = frmWKMakenos[0];
            var frmWKWorkitem = frmWKWorkitems[0];
            var WKSaveWitemId = WKSaveWitemIds[0];
            var WKSaveWorkId = WKSaveWorkIds[0];
            var WKSaveWorkNo = WKSaveWorkNos[0];
            var WKSaveWorkName = WKSaveWorkNames[0];
            WKSaveWitemId.Text = witemid;
            WKSaveWorkId.Text = workid;
            WKSaveWorkNo.Text = wkno;
            WKSaveWorkName.Text = infoarray[2];
            Console.WriteLine("wkno=" + frmWKWorkitem.Text + ",witemid=" + witemid + ",workid=" + workid + ",workorderid=" + WKSaveWorderId.Text);
            if (!isdef)
            {
                WKSaveMakeNo.Text = labWorkOrder.Text;
                WKSaveSpecification.Text = labSpec.Text;
                WKSaveWorkqty.Text = labQty.Text;
                WKSaveWorderId.Text = frmWKMakeno.Tag.ToString();
            }
            frmWKWorkitem.Text = wkno;//會觸發事件
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            var t = this.tabControl1.SelectedIndex;
            Console.WriteLine("t=" + t);
            if (t > 0)
            {
                this.tabControl1.SelectedIndex = t - 1;
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var t = this.tabControl1.SelectedIndex;
            if (t < this.tabControl1.Controls.Count - 1)
            {
                this.tabControl1.SelectedIndex = t + 1;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
            cleardata(true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FinishItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            tempclose();
        }
       /* private void Showinformation()
        {
            var omkno = WKSaveMakeNo;
            var owkn = WKSaveWorkName;
            var owkno = WKSaveWorkNo;
            var owko = frmWKWorkitem;
            var ounit = labUnit;
            var ocq = tabPage2.Controls.Find("CompleteQty", true);
            var ogcq = tabPage2.Controls.Find("GoCompleteQty", true);
            var ognq = tabPage2.Controls.Find("NoGoCompleteQty", true);
            try
            {
                var check_gocqty = 0m;
                var check_gobqty = 0m;
                var check_ngcqty = 0m;
                var check_ngbqty = 0m;
                var check_cqty = 0m;
                var check_bqty = 0m;
                var check_makeqty = 0m;
                var check_makeno = "";
                var unit = labUnit.Text;
                decimal.TryParse(labQty.Text, out check_makeqty);
                msgemp.Text = frmEmpshowno.Text;
                msgmkno.Text = omkno.Text;
                check_makeno = omkno.Text.Trim();

                if (ocq.Length > 0)
                {
                    msgcomplet.Text = ocq[0].Text;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("顯示物件error:" + ex);
            }

        }*/




        private void CloseSerialOnExit()
        {

            try
            {
                serialPort1.DtrEnable = false;
                serialPort1.RtsEnable = false;
                serialPort1.DiscardInBuffer();
                serialPort1.DiscardOutBuffer();
                serialPort1.Close();
                if (serialPort1.IsOpen)
                {
                    Console.WriteLine("menuopen");
                }
                else
                {
                    Console.WriteLine("menuclose");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("close:" + ex.Message);

            }
        }

        private void tempclose()
        {
            var CloseDown = new System.Threading.Thread(new System.Threading.ThreadStart(CloseSerialOnExit));
            CloseDown.Start();
            Console.WriteLine("after start=" + serialPort1.IsOpen);
            var isop = false;
            execfrm();

        }
        private async void execfrm()
        {
            await Task.Delay(200);
            Console.WriteLine("wait:" + serialPort1.IsOpen);
            if (serialPort1.IsOpen)
            {
                await Task.Delay(800);
            }
            else
            {
                ((frmMenu)this.Tag).showmsg();
                IntPtr ptr = FindWindow("frmMenu", null);
                if (ptr != IntPtr.Zero)
                {
                    ShowWindow(ptr, 0);
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
       /* private void getinit()
        {
            var mk = tabPage2.Controls.Find("frmWKMakeno", true);
            if (mk[0].Text == "")
            {
                List<Workitem> getwitem = new List<Workitem>();
                getwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem();
                if (getwitem.Count > 0)
                {
                    var WKSaveWorderIds = tabPage2.Controls.Find("WKSaveWorderId", true);
                    var frmWKMakenos = tabPage2.Controls.Find("frmWKMakeno", true);
                    WKSaveWorderIds[0].Text = getwitem[0].WorkOrderId.ToString();
                    frmWKMakenos[0].Tag = WKSaveWorderIds[0].Text;
                }
                List<Button> btnemplist = new List<Button>();
                if (getwitem.Count() > 0)
                {
                    int iSpace = 5;
                    int iCol = 0;
                    int iRow = 0;
                    int ItemsOneRow = 5;
                    int totalitem = 10;
                    int btnnum = 0;
                    var empitemcount = 0;
                    var keynum = 0;
                    var wkpanel = tabPage2.Controls.Find("WKPanel", true);
                    var wkp = wkpanel[0];
                    wkp.Controls.Clear();
                    foreach (var empitem in getwitem)
                    {
                        iRow = keynum / ItemsOneRow;
                        iCol = keynum % ItemsOneRow;
                        var prestr = "BTNfrmEmp";
                        empitemcount++;
                        if (btnnum + 1 > totalitem)
                        {
                            btnnum = 0;
                        }
                        btnnum++;
                        keynum++;
                        var btnkey = "F" + btnnum;
                        var poststr = empitemcount.ToString("##");
                        var thisbtnname = prestr + poststr;
                        var thisbtntext = empitem.WorkName;
                        Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateWKBtnWithXY(empitem.WorkNo, thisbtntext, empitem.WorkOrderItemId, empitem.WorkId, btnkey, iRow, iCol, iSpace, wkp);
                        empbtn = sethandlerW(empbtn);
                        empbtn.TabStop = false;
                        empbtn.TabIndex = 99;
                        btnemplist.Add(empbtn);
                    }
                }
            }
        }*/

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}