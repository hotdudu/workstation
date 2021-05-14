using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkstationTEST
{
    public partial class FormEND : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        public string Menufilter = "";
        public string ShowTenants = "";//不同公司但員工姓名相同且身分證號相同的話是否開啟選擇畫面
        public string DepartNo = "";//部門編號開頭
        public string NIG = "";//不在部門內但要顯示的員工，目前僅能一位，要多位要改API
        public string DefCompany = "";//預設公司
        public string RestTime = "";//休息時間
        public FormEND(frmMenu fmenu)
        {
            InitializeComponent();
            this.Tag = fmenu;
            this.KeyPreview = true;
            this.Activate();
            this.KeyDown += new KeyEventHandler(mybutton_Click);
            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                Menufilter = oTINI.getKeyValue("SYSTEM", "Menufilter", "");
                ShowTenants = oTINI.getKeyValue("SYSTEM", "ShowTenants", "");
                DepartNo = oTINI.getKeyValue("SYSTEM", "DepartNo", "");
                NIG = oTINI.getKeyValue("SYSTEM", "NIG", "");
                DefCompany = oTINI.getKeyValue("SYSTEM", "DefCompany", "");
                RestTime= oTINI.getKeyValue("SYSTEM", "RestTime", "");
            }
        }
        int fullwidth = 600;
        int fullheight = 600;
        int tabpageheight = 400;
        string sIP = "61.221.176.176";
        string sComport = new API("x", "x").COMPORT;
        delegate void Display(Byte[] buffer);
        List<Empm> getemp = new List<Empm>();
        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }
        List<WorkDayReport> nowrecord = new List<WorkDayReport>();
        List<WorkDayReport> nowselectrecord = new List<WorkDayReport>();
        Dictionary<string,string> rtext = CreateElement.loadresx();
        public Dictionary<string, string> rtext2 = CreateElement.loadresx("ST");
        Dictionary<string, string> rtext3 = CreateElement.loadresx("WK");

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                   /* var frmEmp = new frmEmp();
                    frmEmp.TopLevel = false;
                    frmEmp.Visible = true;
                    tabPage1.Controls.Add(frmEmp);*/
                    //var emp = frmEmp.Controls.Find("frmEmpshowno", false);
                   // emp[0].TextChanged += new EventHandler(gettab);
                    break;
                case 1:
                    /* var frmR = new frmRecord();
                     frmR.TopLevel = false;
                     frmR.Visible = true;
                     frmR.Height = tabControl1.Height - 50;
                     frmR.Width = tabControl1.Width - 50;
                     var recordbtnu = frmR.Controls.Find("frmPTbtnU", true);
                     var recordbtnd = frmR.Controls.Find("frmPTbtnD", true);
                     var recsearch = frmR.Controls.Find("RECsearch", true);
                     recordbtnu[0].Location = new Point(frmR.Width - 200, recordbtnu[0].Location.Y);
                     recordbtnd[0].Location = new Point(frmR.Width - 200, recordbtnd[0].Location.Y);
                     recordbtnd[0].Click+= new EventHandler(gettabd);
                     recordbtnu[0].Click += new EventHandler(gettabu);
                     recsearch[0].TextChanged += new EventHandler(getsearch);
                     tabPage2.Controls.Add(frmR);*/
                    //showrecord(frmEmpshowno.Text);
                    var setpageup = new CreateElement();
                    setpageup.SetBtn(frmPTbtnU, "Insert::Insert", rtext2["prevrecord"]);
                    setpageup.SetBtn(frmPTbtnD, "Delete::Delete", rtext2["nextrecord"]);
                    setpageup.SetBtn(save, "F12::F12", rtext3["WKsave"]);
                    setpageup.SetBtn(next, "Return::Return", "Enter");
                    Int32 tlpColumCountkey = NumPanel.ColumnCount;
                    Int32 tlpRowCountkey = NumPanel.RowCount;
                    save.Click += new EventHandler(savetab);
                    string[] numlist = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ".", "Clear" };
                    string[] keylist = new string[] { "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", "Decimal", "End" };
                    List<Button> btnkeylist = new List<Button>();
                    var empitemcount = 0;
                    for (int i = NumPanel.Controls.Count - 1; i >= 0; --i)
                        NumPanel.Controls[i].Dispose();
                    NumPanel.Controls.Clear();
                    for (var empitem = 0; empitem < numlist.Length; empitem++)
                    {
                        var prestr = "BTNkey";
                        empitemcount++;
                        var poststr = empitemcount.ToString("##");
                        var thisbtnname = prestr + keylist[empitem];
                        var thisbtntext = numlist[empitem];
                        var btnkey = keylist[empitem];
                        Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateNumBtn(numlist[empitem], keylist[empitem]);
                        empbtn = sethandlerbtn(empbtn);
                        btnkeylist.Add(empbtn);
                    }
                    Console.WriteLine("qtybtn=" + btnkeylist.Count + "," + tlpColumCountkey + "," + tlpRowCountkey);
                    var btnj = 0;
                    for (var i = 0; i < tlpRowCountkey; i += tlpColumCountkey)
                    {
                        for (; btnj < btnkeylist.Count && btnj < tlpColumCountkey * tlpRowCountkey; btnj++)
                        {
                            Console.WriteLine("Lqty-i=" + i + ",j=" + btnj + ",name=" + btnkeylist[btnj].Name + ",text=" + btnkeylist[btnj].Text);
                            NumPanel.Controls.Add(btnkeylist[btnj], btnj, i);
                            // frmNumRecordnow.Text = j.ToString();
                        }
                    }
                    break;
            }          
        }

        private void FormEND_Load(object sender, EventArgs e)
        {

            
            var setpageup = new CreateElement();
            setpageup.SetBtn(button1, "PageUp::PageUp", rtext[button1.Name]);
            setpageup.SetBtn2(button2, "Escape::Escape", rtext[button2.Name]);
            setpageup.SetBtn(button3, "PageDown::Next", rtext[button3.Name]);

            this.WindowState = FormWindowState.Maximized;
            this.fullwidth = this.Width;
            this.fullheight = this.Height;
            this.tabpageheight = (int)(this.fullheight * 0.8);
            this.tabControl1.Height = tabpageheight;
            this.tabControl1.Width = this.fullwidth - 10;
            tabPage1.Text = rtext["emp"];
            tabPage2.Text = rtext["unwork"];
            Console.WriteLine("fw=" + fullwidth + ",fh=" + fullheight + ",ch=" + this.tabpageheight);
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
        private void btndown(Panel Panel, Control recordnow)
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
            setpageup.SetBtn(frmEmpPageU, "Insert::Insert", rtext2["frmWKbtnU"]);
            setpageup.SetBtn(frmEmpPageD, "Delete::Delete", rtext2["frmWKbtnD"]);
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

        public void newSetEmpNO(string info)
        {
            var empinfos = info.Split(':');
            if (empinfos.Length == 2)
            {
                frmEmpshowno.Text = empinfos[0];
                empname.Text = empinfos[1];
            }
            else if (empinfos.Length == 4)
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

        private void showrecord(string empno)
        {
            nowrecord = getinit_record(empno);
            nowselectrecord = nowrecord;
            frmRecTotal.Text = nowselectrecord.Count.ToString();
            frmPTRecordnow.Text = "0";
            setview(0,"O");
        }
        private void getsearch(object sender, EventArgs e)
        {
            TextBox nowstr = (TextBox)sender;
            var realstr = nowstr.Text.TrimStart().TrimEnd();
            if ( realstr!= string.Empty)
            {
                if (realstr.IndexOf("::") >= 0)
                {
                    var makenoarray= realstr.Split(new string[] { "::" }, StringSplitOptions.None).First();
                    getstartrec("s", makenoarray);
                }
                else
                {
                    getstartrec("s", "",realstr);
                }
            }
            else
            {
                getstartrec("o");
            }
        }

        private void gettabd(object sender, EventArgs e)
        {
            var nowstr = tabPage2.Controls.Find("RECsearch", true);
            var realstr = nowstr[0].Text.TrimStart().TrimEnd();
            if (realstr != string.Empty)
            {
                if (realstr.IndexOf("::") >= 0)
                {
                    var makenoarray = realstr.Split(new string[] { "::" }, StringSplitOptions.None).First();
                    getstartrec("d", makenoarray);
                }
                else
                {
                    getstartrec("d", "", realstr);
                }
            }
            else
            {
                getstartrec("d");
            }

        }
        private void gettabu(object sender, EventArgs e)
        {

            var nowstr = tabPage2.Controls.Find("RECsearch",true);
            var realstr = nowstr[0].Text.TrimStart().TrimEnd();
            if (realstr != string.Empty)
            {
                if (realstr.IndexOf("::") >= 0)
                {
                    var makenoarray = realstr.Split(new string[] { "::" }, StringSplitOptions.None).First();
                    getstartrec("d", makenoarray);
                }
                else
                {
                    getstartrec("d", "", realstr);
                }
            }
            else
            {
                getstartrec("d");
            }
        }
        private void gettab(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabPage2;
            // var tablecount = 0;
            // getstartrec("o");

            showrecord(frmEmpshowno.Text);

        }


        public void SetkeyNO(string info)
        {
            //var act = ActiveControl;
            var act5 = tabPage2.Controls.Find("BTN-CompleteQty", true);
            var act6 = tabPage2.Controls.Find("BTN-BadQty", true);
            var act1 = tabPage2.Controls.Find("BTN-CompleteGoQty", true);
            var act2 = tabPage2.Controls.Find("BTN-CompleteNgQty", true);
            var act3 = tabPage2.Controls.Find("BTN-BadGoQty", true);
            var act4 = tabPage2.Controls.Find("BTN-BadNgQty", true);
            var nowfocusf = tabPage2.Controls.Find("focust", true);
            string nowfocusname = nowfocusf[0].Text;
            var nowfocusc = tabPage2.Controls.Find(nowfocusname, true);
            /* Control actfocused = null;
             if (act1.Length > 0)
             {
                 actfocused = act1[0].Focused ? act1[0] : (act2[0].Focused ? act2[0] : (act3[0].Focused ? act3[0] : (act4[0].Focused ? act4[0] : act1[0])));
             }
             if (act5.Length > 0)
             {
                 actfocused = act5[0].Focused ? act5[0] : (act6[0].Focused ? act6[0] : act6[5]);
             }
             Console.Write("actfocus=" +actfocused.Name);*/
            if (nowfocusc.Length > 0)
                nowfocusc[0].Text = nowfocusc[0].Text+info;
            if (info == "Clear")
            {
                if (nowfocusc.Length > 0)
                    nowfocusc[0].Text = "";
               // actfocused.Text = "";
                // frmNumshowno.Text = "";
            }
            else
            {
              //  if (nowfocusc.Length > 0) 
                //    nowfocusc[0].Text = nowfocusc[0].Text + info;
               // actfocused.Text = actfocused.Text+info;
                // frmNumshowno.Text = frmNumshowno.Text + info;
            }
        }
        public Button sethandlerbtn(Button bt)
        {
            Button sbt = bt;
            sbt.Click += new EventHandler(btnkey_Click);
            return sbt;
        }

        private void btnkey_Click(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            SetkeyNO(tmpButton.Tag.ToString());

        }

        public Button sethandler(Button bt)
        {
            Button sbt = bt;
            sbt.Click += new EventHandler(btnEMPALL_Click);
            return sbt;
        }

        private void btnEMPALL_Click(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            UpdateRecord(tmpButton.Tag.ToString(), DateTime.Now);
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
                    //MessageBox.Show("開啟掃描器異常");
                }
            }
               
            Console.WriteLine("isopen:"+serialPort1.IsOpen);
        }

        public void DisplayText(string clickData)
        { ShowData(clickData); }
        private void DisplayText(Byte[] buffer)
        {
            var scanData = System.Text.Encoding.ASCII.GetString(buffer).ToString().Trim();
            ShowData(scanData);

        }

        private void DisplayText2(Byte[] buffer)
        {
            var scanData = System.Text.Encoding.ASCII.GetString(buffer).ToString().Trim();
            ShowData2(scanData);

        }
        public string ShowData(string data)
        {
            //Console.WriteLine(data);
            int index = tabControl1.SelectedIndex;
            var tabindex = tabControl1.SelectedIndex;
            Console.WriteLine("nowtab=" + tabindex+","+data);
            if (tabindex == 0)
            {

                var dataarray = data.Split(new string[] { "::" }, StringSplitOptions.None);
                if (dataarray.Length == 3)
                {
                    var tt = tabPage1.Controls.Find("frmEmpshowno", true);
                    tt[0].Text = data;
                    Console.WriteLine("tt=" + tt[0].Name);
                }
                if (dataarray.Length == 2)
                {
                    var pkey = dataarray[1];
                    Console.WriteLine("pkey=" + pkey);
                    setkeymap(pkey);
                }
            }
            if (tabindex == 1)
            {
                var dataarray = data.Split(new string[] { "::" }, StringSplitOptions.None);
                if (dataarray.Length == 2)
                {
                    var pkey = dataarray[1];
                    Console.WriteLine("pkey=" + pkey);
                    setkeymap(pkey);
                }
                if (dataarray.Length >= 3)
                {
                    var isp = dataarray[1].StartsWith("P");
                    Console.WriteLine("showdata=" + isp);
                        setkeymap("XXX", data);
                }
            }
            if (tabindex == 2)
            {

            }
            if (tabindex == 3)
            {

            }
            return data;
        }
        public string ShowData2(string data)
        {
            //Console.WriteLine(data);
            int index = tabControl1.SelectedIndex;
            var tabindex = tabControl1.SelectedIndex;
            Console.WriteLine("nowtab=" + tabindex + "," + data);
            if (tabindex == 0)
            {

                var dataarray = data.Split(new string[] { "::" }, StringSplitOptions.None);
                if (dataarray.Length == 3)
                {
                    var tt = tabPage1.Controls.Find("frmEmpshowno", true);
                    tt[0].Text = data;
                    Console.WriteLine("tt=" + tt[0].Name);
                }
                if (dataarray.Length == 2)
                {
                    var pkey = dataarray[1];
                    Console.WriteLine("pkey=" + pkey);
                    setkeymap(pkey);
                }
            }
            if (tabindex == 1)
            {
                var dataarray = data.Split(new string[] { "::" }, StringSplitOptions.None);
                 if (dataarray.Length == 2)
                {
                    var pkey = dataarray[1];
                    Console.WriteLine("pkey=" + pkey);
                    setkeymap(pkey,"",true);
                }
                if (dataarray.Length >= 3)
                {
                    setkeymap("XXX", data);
                }
            }
            if (tabindex == 2)
            {

            }
            if (tabindex == 3)
            {

            }
            return data;
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Byte[] buffer = new Byte[1024];
            Int32 length = (sender as System.IO.Ports.SerialPort).Read(buffer, 0, buffer.Length);
            Array.Resize(ref buffer, length);
            Display d = new Display(DisplayText2);
            this.Invoke(d, new Object[] { buffer });
        }
        private void mybutton_Click(object sender, KeyEventArgs e)
        {
            Console.WriteLine("keycoe=" + e.KeyCode.ToString());
            setkeymap(e.KeyCode.ToString());
            //tmpb.PerformClick();
        }
        public List<WorkDayReport> getrecord(string eno,string makeno="",string startno="")
        {
            string dbPath = Directory.GetCurrentDirectory() + "\\" + "wd2.db3";
            string cnStr = "data source=" + dbPath + ";Version=3;";
            Console.WriteLine("db=" + File.Exists(dbPath) + "," + dbPath);
            List<WorkDayReport> wrecord = new List<WorkDayReport>();
            var ismultipleno = false;
            var marray = Menufilter.Split(';');
            var msubarray = new List<string>();
            foreach (var item in marray)
            {
                if (item.IndexOf(eno) > -1)
                {
                    ismultipleno = true;
                    var inneritem = item.Split(',');
                    foreach (var inner in inneritem)
                    {
                        msubarray.Add(inner);
                    }
                }
            }
            if (File.Exists(dbPath))
            {
                using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                {
                    var insertScript = "";
                    if (ismultipleno)
                    {
                        insertScript = "SELECT * FROM WorkDayReports  WHERE (EmpNo=@EmpNo OR EmpNo=@EmpNo1) AND  EndTime IS NULL Order by StartTime";
                    }
                    else
                    {
                        insertScript = "SELECT * FROM WorkDayReports  WHERE EmpNo=@EmpNo AND  EndTime IS NULL Order by StartTime";
                    }
                    if (makeno != string.Empty)
                    {
                        if (ismultipleno)
                        {
                            insertScript = "SELECT * FROM WorkDayReports  WHERE (EmpNo=@EmpNo OR EmpNo=@EmpNo1) AND MakeNo=@MakeNo AND EndTime IS NULL Order by StartTime";

                        }
                        else
                        {
                            insertScript = "SELECT * FROM WorkDayReports  WHERE EmpNo=@EmpNo AND MakeNo=@MakeNo AND EndTime IS NULL Order by StartTime";
                        }
                    }
                    else if(startno!=string.Empty)
                    {
                        if (ismultipleno)
                        {
                            insertScript = "SELECT * FROM WorkDayReports  WHERE (EmpNo=@EmpNo OR EmpNo=@EmpNo1) AND MakeNo LIKE @startno AND EndTime IS NULL Order by StartTime";

                        }
                        else
                        {
                             insertScript = "SELECT * FROM WorkDayReports  WHERE EmpNo=@EmpNo AND MakeNo LIKE @startno AND EndTime IS NULL Order by StartTime";

                        }
                    }
                    SQLiteCommand cmd = new SQLiteCommand(insertScript, conn);
                    if(makeno != string.Empty)
                    {
                        if (ismultipleno)
                        {
                            cmd.Parameters.AddWithValue("@EmpNo", msubarray[0]);
                            cmd.Parameters.AddWithValue("@EmpNo1", msubarray[1]);
                            cmd.Parameters.AddWithValue("@MakeNo", makeno);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@EmpNo", eno);
                            cmd.Parameters.AddWithValue("@MakeNo", makeno);
                        }

                    }
                    else if (startno != string.Empty)
                    {
                        if (ismultipleno)
                        {
                            cmd.Parameters.AddWithValue("@EmpNo", msubarray[0]);
                            cmd.Parameters.AddWithValue("@EmpNo1", msubarray[1]);
                            cmd.Parameters.AddWithValue("@startno", '%' + startno);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@EmpNo", eno);
                            cmd.Parameters.AddWithValue("@startno", '%'+startno);
                        }

                    }
                    else
                    {
                        if(ismultipleno)
                        {
                            cmd.Parameters.AddWithValue("@EmpNo", msubarray[0]);
                            cmd.Parameters.AddWithValue("@EmpNo1", msubarray[1]);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@EmpNo", eno);
                        }

                    }
                        conn.Open();
                    try
                    {
                        // SQLiteDataReader reader = cmd.ExecuteReader();
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "FirstTable");
                        Console.WriteLine("rl=" + ds.Tables[0].Rows.Count);
                        int itemcount = 0;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            itemcount++;
                            Console.WriteLine("r=" + row["DayReportId"]);
                            var ritem = new WorkDayReport()
                            {
                                DayReportId = row["DayReportId"] as string ?? "",
                                AssetsName = row["AssetsName"] as string ?? "",
                                TenantId = row["TenantId"] as int? ?? default(int),
                                EmployeeId = row["EmployeeId"] as string ?? "",
                                EndTime = row["EndTime"] as DateTime? ?? null,
                                AdjustTime = row["AdjustTime"] as decimal? ?? null,
                                BadQty = row["BadQty"] as decimal? ?? null,
                                CompleteQty = row["CompleteQty"] as decimal? ?? null,
                                StartTime = row["StartTime"] as DateTime? ?? null,
                                WorkDate = row["WorkDate"] as string ?? "",
                                WorkId = row["WorkId"] as string ?? "",
                                WorkOrderId = row["WorkOrderId"] as string ?? "",
                                WorkOrderItemId = row["WorkOrderItemId"] as string ?? "",
                                WorkQty = row["WorkQty"] as decimal? ?? null,
                                Specification = row["Specification"] as string ?? "",
                                WorkName = row["WorkName"] as string ?? "",
                                WorkNo = row["WorkNo"] as string ?? "",
                                MakeNo = row["MakeNo"] as string ?? "",
                                EmpNo = row["EmpNo"] as string ?? "",
                                MNo = row["MNo"] as string ?? "",
                                CompletGoQty = row["CompletGoQty"] as decimal? ?? null,
                                CompletNgQty = row["CompletNgQty"] as decimal? ?? null,
                                BadGoQty = row["BadGoQty"] as decimal? ?? null,
                                BadNgQty = row["BadNgQty"] as decimal? ?? null,
                                itemno = itemcount,
                                UseUnits=row["Unit"] as string ??"",
                            };
                            wrecord.Add(ritem);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    //參數是用@paramName


                }
            }
            return wrecord;
        }

        public List<WorkDayReport> getinit_record(string eno, string makeno = "", string startno = "")
        {
            string dbPath = Directory.GetCurrentDirectory() + "\\" + "wd2.db3";
            string cnStr = "data source=" + dbPath + ";Version=3;";
            Console.WriteLine("db=" + File.Exists(dbPath) + "," + dbPath);
            List<WorkDayReport> wrecord = new List<WorkDayReport>();
            var employeeno = "";

            if (eno.IndexOf(":") > 0)
            {
                employeeno = eno.Split(':').First();
            }
            else
            {
                employeeno = eno;
            }
            var ismultipleno = false;
            var marray = Menufilter.Split(';');
            var msubarray = new List<string>();
            foreach (var item in marray)
            {
                if (item.IndexOf(eno) > -1)
                {
                    ismultipleno = true;
                    var inneritem = item.Split(',');
                    foreach (var inner in inneritem)
                    {
                        msubarray.Add(inner);
                    }
                }
            }
            if (File.Exists(dbPath))
            {
                using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                {
                    var insertScript = "";
                    if (ismultipleno)
                    {
                        insertScript = "SELECT * FROM WorkDayReports  WHERE (EmpNo=@EmpNo OR EmpNo=@EmpNo1) AND  EndTime IS NULL Order by StartTime";
                    }
                    else
                    {
                        insertScript = "SELECT * FROM WorkDayReports  WHERE EmpNo=@EmpNo AND  EndTime IS NULL Order by StartTime";
                    }

                    SQLiteCommand cmd = new SQLiteCommand(insertScript, conn);
                    if (ismultipleno)
                    {
                        cmd.Parameters.AddWithValue("@EmpNo", msubarray[0]);
                        cmd.Parameters.AddWithValue("@EmpNo1", msubarray[1]);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@EmpNo", employeeno);
                    }
                    conn.Open();
                    try
                    {
                        // SQLiteDataReader reader = cmd.ExecuteReader();
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "FirstTable");
                        Console.WriteLine("rl=" + ds.Tables[0].Rows.Count);
                        int itemcount = 0;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            itemcount++;
                            Console.WriteLine("r=" + row["DayReportId"]);
                            var ritem = new WorkDayReport()
                            {
                                DayReportId = row["DayReportId"] as string ?? "",
                                AssetsName = row["AssetsName"] as string ?? "",
                                TenantId = row["TenantId"] as int? ?? default(int),
                                EmployeeId = row["EmployeeId"] as string ?? "",
                                EndTime = row["EndTime"] as DateTime? ?? null,
                                AdjustTime = row["AdjustTime"] as decimal? ?? null,
                                BadQty = row["BadQty"] as decimal? ?? null,
                                CompleteQty = row["CompleteQty"] as decimal? ?? null,
                                StartTime = row["StartTime"] as DateTime? ?? null,
                                WorkDate = row["WorkDate"] as string ?? "",
                                WorkId = row["WorkId"] as string ?? "",
                                WorkOrderId = row["WorkOrderId"] as string ?? "",
                                WorkOrderItemId = row["WorkOrderItemId"] as string ?? "",
                                WorkQty = row["WorkQty"] as decimal? ?? null,
                                Specification = row["Specification"] as string ?? "",
                                WorkName = row["WorkName"] as string ?? "",
                                WorkNo = row["WorkNo"] as string ?? "",
                                MakeNo = row["MakeNo"] as string ?? "",
                                EmpNo = row["EmpNo"] as string ?? "",
                                MNo = row["MNo"] as string ?? "",
                                CompletGoQty = row["CompletGoQty"] as decimal? ?? null,
                                CompletNgQty = row["CompletNgQty"] as decimal? ?? null,
                                BadGoQty = row["BadGoQty"] as decimal? ?? null,
                                BadNgQty = row["BadNgQty"] as decimal? ?? null,
                                itemno = itemcount,
                                UseUnits = row["Unit"] as string ?? "",
                                AssetsItemId=row["AssetsItemId"] as string ??"",
                            };
                            wrecord.Add(ritem);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    //參數是用@paramName


                }
            }
            return wrecord;
        }
        private int getsetorder(string act)
        {
            int nowpoint = 0;
            int totalrow = 0;
            int.TryParse(frmPTRecordnow.Text, out nowpoint);
            int.TryParse(frmRecTotal.Text, out totalrow);
            if (act == "d")
            {
                if (nowpoint + 1 < totalrow)
                {
                    nowpoint++;
                }
            }
            if (act == "u")
            {
                if (nowpoint - 1 >= 0)
                {
                    nowpoint--;
                }
            }
            frmPTRecordnow.Text = nowpoint.ToString();
            return nowpoint; 
        }
        private void setview(int dataorder,string act)
        {
            if (nowselectrecord.Count > 0)
            {
                var rp = RPanel;
                for (int i = rp.Controls.Count - 1; i >= 0; --i)
                    rp.Controls[i].Dispose();
                rp.Controls.Clear();
                showrecordmsg(dataorder,nowselectrecord.Count);
                var item = nowselectrecord[dataorder];
                var namelist = new string[] { "GP-NP", "GP-WP", "GP-IP", "GR-NR", "GR-IR", "GR-WR" };
                var hidelist = new string[] { "UseUnits", "TenantId", "WorkOrderId", "WorkOrderItemId", "WorkId", "WorkDate", "AssetsItemId" };
                var displaylist = new List<string> { "MakeNo", "StartTime", "CompleteQty", "BadQty", "AdjustTime", "WorkQty", "WorkNo", "WorkName", "Specification", "WorkTime", "EndTime" };
                var editlist = new string[] { "CompleteQty", "BadQty", "AdjustTime" };
                if (item.UseUnits.TrimStart().TrimEnd() == "Set")
                {
                    displaylist = new List<string>() { "MakeNo", "StartTime", "CompletGoQty", "CompletNgQty", "BadGoQty", "BadNgQty", "AdjustTime", "WorkQty", "WorkNo", "WorkName", "Specification", "WorkTime", "EndTime" };
                    editlist = new string[] { "CompletGoQty", "CompletNgQty", "BadGoQty", "BadNgQty", "AdjustTime" };
                }
                List<TextBox> btnemplist = new List<TextBox>();
                var dayid = "";
                var itemj = 0;
                foreach (var prop in item.GetType().GetProperties())
                {
                    var cAssetsName = "";
                    if (prop.Name == "DayReportId")
                    {
                        dayid = prop.GetValue(item).ToString();
                    }
                    var prestr = "BTN";
                    var poststr = dataorder.ToString("##");
                    var poststr2 = itemj.ToString("##");
                    bool isedit = editlist.Contains(prop.Name);
                    var thisbtnname = prestr + "-" + prop.Name;
                    string thisbtntext = prop.GetValue(item) != null ? prop.GetValue(item).ToString() : "";
                    if (displaylist.Contains(prop.Name))
                    {
                        itemj++;
                        TextBox empbtn = new CreateElement(thisbtnname, thisbtntext).CreateBtn(thisbtntext, isedit, itemj, true);
                        if (isedit)
                        {
                            empbtn.TextChanged += new EventHandler(CheckQTY);
                            empbtn.GotFocus += new EventHandler(BtnGotfocus);
                        }
                        btnemplist.Add(empbtn);
                    }
                    if (hidelist.Contains(prop.Name))
                    {
                        TextBox empbtn = new CreateElement(thisbtnname, thisbtntext).CreateBtn(thisbtntext, isedit, 999, false);
                        btnemplist.Add(empbtn);
                    }
                }
                TextBox rid = new TextBox();
                rid.Visible = false;
                rid.Name = "DayReportId";
                rid.TabIndex = 999;
                rid.Text = dayid;
                btnemplist.Add(rid);

                var tableheadstr = new string[] { rtext["makeno"], rtext["spec"], rtext["proc"], "", rtext["makeqty"], rtext["completeqty"], rtext["badqty"],rtext["adjust"], rtext["starttime"], rtext["endtime"], rtext["worktime"] };

                if (btnemplist.Count > 20)
                    tableheadstr = new string[] { rtext["makeno"], rtext["spec"], rtext["proc"], "", rtext["makeqty"], "Go" + rtext["completeqty"], "NoGo" + rtext["completeqty"], "Go" + rtext["badqty"], "NoGo" + rtext["badqty"], rtext["adjust"], rtext["starttime"], rtext["endtime"], rtext["worktime"] };
                for (var a = 0; a < tableheadstr.Count(); a++)
                {
                    TextBox templab = new TextBox();
                    templab.Text = tableheadstr[a];
                    templab.ReadOnly = true;
                    templab.Margin = new Padding(0);
                    templab.TabIndex = 999;
                    templab.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
                    rp.Controls.Add(templab, a, 0);
                }

                for (var j = 0; j < btnemplist.Count; j++)
                {
                    rp.Controls.Add((TextBox)btnemplist[j], j, 0 + 1);
                }
                var CompleteQty = item.CompleteQty;
                var BadQty = item.BadQty;
                var CompletGoQty = item.CompletGoQty;
                var CompletNgQty = item.CompletNgQty;
                var BadGoQty = item.BadGoQty;
                var BadNgQty = item.BadNgQty;
                var AdjustTime = item.AdjustTime;
                var EndTime = item.EndTime;
                var WorkTime = item.WorkTime;


                var actg = tabPage2.Controls.Find("BTN-CompleteQty", true);
                var actn = tabPage2.Controls.Find("BTN-CompletGoQty", true);
                var actnq = tabPage2.Controls.Find("BTN-CompletNgQty", true);
                var abtgq = tabPage2.Controls.Find("BTN-BadGoQty", true);
                var abtnq = tabPage2.Controls.Find("BTN-BadNgQty", true);
                var abtg = tabPage2.Controls.Find("BTN-BadQty", true);
                var ajt = tabPage2.Controls.Find("BTN-AdjustTime", true);
                var aet = tabPage2.Controls.Find("BTN-EndTime", true);
                var awt = tabPage2.Controls.Find("BTN-WorkTime", true);
                if (actg.Length > 0) {
                    actg[0].Text = CompleteQty.HasValue ? (CompleteQty == 0 ? "" : CompleteQty.ToString()) : "";
                }
                if (actn.Length > 0)
                {
                    actn[0].Text = CompletGoQty.HasValue ? (CompletGoQty == 0 ? "" : CompletGoQty.ToString()) : "";
                }
                if (actnq.Length > 0)
                {
                    actnq[0].Text = CompletNgQty.HasValue ? (CompletNgQty == 0 ? "" : CompletNgQty.ToString()) : "";
                }
                if (abtgq.Length > 0)
                {
                    abtgq[0].Text = BadGoQty.HasValue ? (BadGoQty == 0 ? "" : BadGoQty.ToString()) : "";
                }
                if (abtnq.Length > 0)
                {
                    abtnq[0].Text = BadNgQty.HasValue ? (BadNgQty == 0 ? "" : BadNgQty.ToString()) : "";
                }
                if (abtg.Length > 0)
                {
                    abtg[0].Text = BadQty.HasValue ? (BadQty == 0 ? "" : BadQty.ToString()) : "";
                }
                if (ajt.Length > 0)
                {
                    ajt[0].Text = AdjustTime.HasValue ? (AdjustTime == 0 ? "" : AdjustTime.ToString()) : "";
                }
                if (aet.Length > 0)
                {
                    aet[0].Text = EndTime.HasValue ? EndTime.ToString() : "";
                }
                if (awt.Length > 0)
                {
                    awt[0].Text = WorkTime.HasValue ? WorkTime.ToString() : "";
                }
                if (actg.Count() > 0)
                    actg[0].Select();
                if (actn.Count() > 0)
                    actn[0].Select();
                emptydata.Visible = false;
            }
            else
            {
                emptydata.Visible = true;
            }
        }
        public void UpdateRecord(string id,DateTime endtime)
        {
            string dbPath = Directory.GetCurrentDirectory() + "\\" + "wd2.db3";
            string cnStr = "data source=" + dbPath + ";Version=3;";
            Console.WriteLine("db=" + File.Exists(dbPath) + "," + dbPath);
            List<WorkDayReport> wrecord = new List<WorkDayReport>();
            if (File.Exists(dbPath))
            {
                using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                {
                    var insertScript = "UPDATE  WorkDayReports SET  EndTime=@EndTime WHERE DayReportId=@DayReportId";
                    SQLiteCommand cmd = new SQLiteCommand(insertScript, conn);
                    cmd.Parameters.AddWithValue("@EndTime", endtime.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@DayReportId", id);
                  
                    try
                    { 
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    //參數是用@paramName


                }
                var refreshid= tabPage2.Controls.Find(id, true);
                if (refreshid.Length > 0)
                {
                    refreshid[0].Text = endtime.ToString();
                }
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        public void setkeymap(string keychar, string data = "",bool isbarcode=false)
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
                button3.PerformClick();
            }
            if (keyupper == "Escape")
            {
                button2.PerformClick();
            }
            if (t == 0)
            {
                var up = tabPage1.Controls.Find("frmEmpPageU", true);
                var down = tabPage1.Controls.Find("frmEmpPageD", true);
                string[] keyarray = new string[] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10" };
                if (keyupper == "Delete")
                {
                    ((Button)down[0]).PerformClick();
                }
                if (keyupper == "Insert")
                {
                    ((Button)up[0]).PerformClick();
                }
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
                                if(btn!=null)
                                ((Button)(btn)).PerformClick();
                            }                          
                                Console.WriteLine("per:" + keychar);
                        }
                    }
                }
            }
            if (t == 1)
            {
                var up = tabPage2.Controls.Find("frmPTbtnU", true);
                var down = tabPage2.Controls.Find("frmPTbtnD", true);
                var save = tabPage2.Controls.Find("save", true);
                var recordfocus = tabPage2.Controls.Find("focust", true);
                string[] keyarray = new string[] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10" };
                string[] keylist = new string[] { "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", "Decimal", "End" };

                if (keyupper== "Return")
                {
                    
                    var farray = new string[] { "BTN-CompleteQty", "BTN-BadQty", "BTN-CompleteGoQty" , "BTN-CompleteNgQty" , "BTN-BadGoQty" , "BTN-BadNgQty" };
                    SendKeys.Send("{TAB}");
                   // Control getfocus = ActiveControl;
                   // if (farray.Contains(getfocus.Name))
                   /* {
                        recordfocus[0].Text = getfocus.Name;
                    }*/
                    Console.Write("notfirst=" + recordfocus[0].Text);
                }
                if (data == "")//非輸入工令情形
                {
                    if (keyupper == "Delete")
                    {
                        ((Button)down[0]).PerformClick();
                    }
                    if (keyupper == "Insert")
                    {
                        ((Button)up[0]).PerformClick();
                    }
                    if(keyupper == "F12")
                    {
                        ((Button)save[0]).PerformClick();
                    }
                    if (keyarray.Contains(keyupper))
                    {
                        Console.WriteLine("kc");
                        for (var i = 0; i < keyarray.Length; i++)
                        {
                            if (keyarray[i] == keyupper)
                            {
                                Console.WriteLine("ke=" + keyupper + "," + keyarray[i]);
                                var estr = "Rsave" + (i + 1);
                                var tempbtn = tabPage2.Controls.Find(estr, true);
                                if (tempbtn.Length > 0)
                                {
                                    ((Button)(tempbtn[0])).PerformClick();
                                    Console.WriteLine("per:" + keychar);
                                }
                            }
                        }
                    }

                    if (keylist.Contains(keyupper))
                    {
                        if (!isbarcode)
                        {
                            for (var i = 0; i < keylist.Length; i++)
                            {
                                if (keylist[i] == keyupper)
                                {
                                    Console.WriteLine("ke=" + keyupper + "," + keylist[i]);
                                    var estr = "BTNkey" + keylist[i];
                                    var tempbtn = tabPage2.Controls.Find(estr, true);
                                    if (tempbtn.Length > 0)
                                    {
                                        ((Button)(tempbtn[0])).PerformClick();
                                        Console.WriteLine("per:" + keychar);
                                    }
                                }
                            }
                        }
                        else
                        {
                            var getkeyfocus = tabPage2.Controls.Find("focust", true);
                            string keyfocusstr = getkeyfocus[0].Text;
                            var setkeyfocus= tabPage2.Controls.Find(keyfocusstr, true);
                            if (setkeyfocus.Length > 0)
                            {
                                if(keyupper!= "Decimal" && keyupper != "End")
                                {
                                    var keyval = keyupper.Substring(keyupper.Length - 1);
                                    setkeyfocus[0].Text = setkeyfocus[0].Text + keyval;
                                }
                                else
                                {
                                    var bestr = "";
                                    if (keyupper == "Decimal")
                                    {
                                        bestr = "BTNkeyDecimal";
                                    }
                                    else if (keyupper == "End")
                                    {
                                        bestr = "BTNkeyEnd";
                                    }
                                    var btempbtn = tabPage2.Controls.Find(bestr, true);
                                    ((Button)(btempbtn[0])).PerformClick();
                                }
                            }
                        }
                    }

                }
                else
                {
                    var tt = tabPage2.Controls.Find("RECsearch", true);
                    tt[0].Text = data;

                    Console.WriteLine("tt=" + tt[0].Name);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEND_FormClosed(object sender, FormClosedEventArgs e)
        {
            tempclose();
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            var t = this.tabControl1.SelectedIndex;
            Console.WriteLine("t=" + t);
            if (t > 0)
            {
                this.tabControl1.SelectedIndex = t - 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var t = this.tabControl1.SelectedIndex;
            if (t < this.tabControl1.Controls.Count - 1)
            {
                this.tabControl1.SelectedIndex = t + 1;
            }
        }

        private void savetab(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            UpdateRecordCom();
        }

        public void UpdateRecordCom()
        {
            string[] notincludelist = new string[] { "D16" };

            var s = new saving();
            s.Show();
            var DayReportIdS = tabPage2.Controls.Find("DayReportId", true);
            var CompleteQtyS = tabPage2.Controls.Find("BTN-CompleteQty", true);
            var BadQtyS = tabPage2.Controls.Find("BTN-BadQty", true);
            var CompletGoQtyS = tabPage2.Controls.Find("BTN-CompletGoQty", true);
            var CompletNgQtyS = tabPage2.Controls.Find("BTN-CompletNgQty", true);
            var BadGoQtyS = tabPage2.Controls.Find("BTN-BadGoQty", true);
            var BadNgQtyS = tabPage2.Controls.Find("BTN-BadNgQty", true);
            var StartTimeS = tabPage2.Controls.Find("BTN-StartTime", true);
            var EndTimeS = tabPage2.Controls.Find("BTN-EndTime", true);
            var WorkTimeS = tabPage2.Controls.Find("BTN-WorkTime", true);
            var MakeNoS= tabPage2.Controls.Find("BTN-MakeNo", true);
            var Units = tabPage2.Controls.Find("BTN-UseUnits", true);
            var WorkNoS= tabPage2.Controls.Find("BTN-WorkNo", true);
            var AdjustTimeS = tabPage2.Controls.Find("BTN-AdjustTime", true);
            var AssetsItemIdS = tabPage2.Controls.Find("BTN-AssetsItemId", true);
            //local
            var EmpnoS = tabPage1.Controls.Find("frmEmpshowno", true);
            var WorkDateS= tabPage2.Controls.Find("BTN-WorkDate", true);
            var TenantIdS= tabPage2.Controls.Find("BTN-TenantId", true);
            var WorkOrderIdS = tabPage2.Controls.Find("BTN-WorkOrderId", true);
            var WorkOrderItemIdS = tabPage2.Controls.Find("BTN-WorkOrderItemId", true);
            var WorkIdS = tabPage2.Controls.Find("BTN-WorkId", true);

            
            var DayReportId = DayReportIdS[0].Text;
            decimal CompleteQty = decimal.Parse(CompleteQtyS.Length > 0&& CompleteQtyS[0].Text!="" ? CompleteQtyS[0].Text : "0");
            decimal BadQty = decimal.Parse(BadQtyS.Length > 0&& BadQtyS[0].Text!="" ? BadQtyS[0].Text : "0");
            decimal CompletGoQty = decimal.Parse(CompletGoQtyS.Length > 0&& CompletGoQtyS[0].Text!="" ? CompletGoQtyS[0].Text : "0");
            decimal CompletNgQty = decimal.Parse(CompletNgQtyS.Length > 0&& CompletNgQtyS[0].Text!="" ? CompletNgQtyS[0].Text : "0");
            decimal BadGoQty = decimal.Parse(BadGoQtyS.Length > 0&& BadGoQtyS[0].Text !=""? BadGoQtyS[0].Text : "0");
            decimal BadNgQty = decimal.Parse(BadNgQtyS.Length > 0&& BadNgQtyS[0].Text!="" ? BadNgQtyS[0].Text : "0");
            double AdjustTime = double.Parse(AdjustTimeS.Length > 0 && AdjustTimeS[0].Text != "" ? AdjustTimeS[0].Text : "0");
            double subtime = double.Parse(RestTime);
            DateTime StartTime = DateTime.Parse(StartTimeS[0].Text);
            DateTime EndTime = EndTimeS.Length > 0 && EndTimeS[0].Text != "" ? DateTime.Parse(EndTimeS[0].Text) : DateTime.Now;
            double WorkTime = Math.Ceiling( EndTime.Subtract(StartTime).TotalMinutes);
            string MakeNo = MakeNoS.Length > 0 ? MakeNoS[0].Text : "";
            int TenantId = int.Parse(TenantIdS.Length > 0 ? TenantIdS[0].Text:"101");
            string WorkDate = WorkDateS.Length > 0 ? WorkDateS[0].Text : "";
            string WorkOrderId = WorkOrderIdS.Length > 0 ? WorkOrderIdS[0].Text : "";
            string WorkOrderItemId = WorkOrderItemIdS.Length > 0 ? WorkOrderItemIdS[0].Text : "";
            string WorkId = WorkIdS.Length > 0 ? WorkIdS[0].Text : "";
            string AssetsItemId = AssetsItemIdS.Length > 0 ? AssetsItemIdS[0].Text : "";
            string Unit = Units.Length > 0 ? Units[0].Text : "";
            string WorkNo = WorkNoS.Length > 0 ? WorkNoS[0].Text : "";
            var middletimestart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            var middletimeend = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 0, 0);
            if (StartTime <= middletimestart && EndTime >= middletimeend)
            {
                WorkTime -= subtime;
            }
            WorkTime -= AdjustTime;
            if (Unit == "Set")
            {
                if (CompletGoQty + CompletNgQty > 0)
                {
                    if (notincludelist.Contains(WorkNo))
                    {
                        CompleteQty = CompletGoQty + CompletNgQty;
                    }
                    else
                    {
                        CompleteQty = (CompletGoQty + CompletNgQty) / 2;
                    }
                }
                   
                if (BadGoQty + BadNgQty > 0)
                {
                    if (notincludelist.Contains(WorkNo))
                    {
                        BadQty = BadGoQty + BadNgQty;
                    }
                    else
                    {
                        BadQty = (BadGoQty + BadNgQty) / 2;
                    }
                }
                    
            }

            /*var ri = ((TableLayoutPanel)rpanel[0]).RowCount;
            var rj = ((TableLayoutPanel)rpanel[0]).ColumnCount;
            var tc = (TableLayoutPanel)rpanel[0];
            for (var i = 1; i < ri; i++)
            {
                for(var j = 0; j < rj; j++)
                {
                    Control c = tc.GetControlFromPosition(i, j);
                    Console.Write("control:" + c.GetType());
                }
            }*/
            string Empno = EmpnoS.Length > 0 ? EmpnoS[0].Text.IndexOf(':')>=0? EmpnoS[0].Text.Split(':').First(): EmpnoS[0].Text : "";
            string dbPath = Directory.GetCurrentDirectory() + "\\" + "wd2.db3";
            string cnStr = "data source=" + dbPath + ";Version=3;";
            Console.WriteLine("db=" + File.Exists(dbPath) + "," + dbPath);
            List<WorkDayReport> wrecord = new List<WorkDayReport>();
            var wdritem = new WorkDayReport()
            {
                EmployeeId = "",
                AdjustTime = null,
                BadQty = BadQty,
                CompleteQty = CompleteQty,
                CompletGoQty = CompletGoQty,
                CompletNgQty = CompletNgQty,
                BadGoQty = BadGoQty,
                BadNgQty = BadNgQty,
                DayReportId = DayReportId.ToString(),
                EmpNo = Empno,
                EndTime = EndTime,
                MakeNo = MakeNo,
                MNo = "",
                Specification = "",
                WorkNo = "",
                StartTime = StartTime,
                TenantId = TenantId,
                WorkDate = WorkDate,
                WorkId = WorkId,
                WorkName = "",
                WorkOrderId = WorkOrderId,
                WorkOrderItemId = WorkOrderItemId,
                WorkQty = null,
                WorkTime =(decimal) WorkTime,
                AssetsItemId=AssetsItemId,
            };
            if (File.Exists(dbPath))
            {
                using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                {
                    var insertScript = "UPDATE  WorkDayReports SET  EndTime=@EndTime,CompleteQty=@CompleteQty,BadQty=@BadQty,CompletGoQty=@CompletGoQty,CompletNgQty=@CompletNgQty,BadGoQty=@BadGoQty,BadNgQty=@BadNgQty,WorkTime=@WorkTime" + 
                        " WHERE DayReportId=@DayReportId";
                    SQLiteCommand cmd = new SQLiteCommand(insertScript, conn);
                    cmd.Parameters.AddWithValue("@EndTime", EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@DayReportId", DayReportId);
                    cmd.Parameters.AddWithValue("@CompleteQty", CompleteQty);
                    cmd.Parameters.AddWithValue("@BadQty", BadQty);
                    cmd.Parameters.AddWithValue("@CompletGoQty", CompletGoQty);
                    cmd.Parameters.AddWithValue("@CompletNgQty", CompletNgQty);
                    cmd.Parameters.AddWithValue("@BadGoQty", BadGoQty);
                    cmd.Parameters.AddWithValue("@BadNgQty", BadNgQty);
                    cmd.Parameters.AddWithValue("@WorkTime", WorkTime);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                       /* var rTabT = tabPage2.Controls.Find("frmRecTotal", true);
                        int rtotalval = 0;
                        var trytotal = int.TryParse(rTabT[0].Text, out rtotalval);
                        if (rtotalval > 0)
                            rtotalval -= 1;
                        rTabT[0].Text = rtotalval.ToString();*/

                        int ind = nowrecord.FindIndex(x => x.DayReportId == DayReportId);
                        if (nowrecord[ind].localupdate == false)
                        {
                            var up = new API("/CHG/Main/Home/Addworkdayreport3/", "http://").UploadServer(wdritem);
                            if (up.dayid.HasValue)
                            {
                                var updatesql = "Update WorkDayReports SET isupdate=1 where DayReportId=@DayReportId";
                                SQLiteCommand updatecmd = new SQLiteCommand(updatesql, conn);
                                updatecmd.Parameters.AddWithValue("@DayReportId", up.dayid.ToString());
                                updatecmd.ExecuteNonQuery();
                            }
                            else
                            {
                                var logScript = "INSERT INTO ErrorLog (logid,DayReportId,error) VALUES (@logid,@DayReportId,@error)";
                                SQLiteCommand updatecmd = new SQLiteCommand(logScript, conn);
                                updatecmd.Parameters.AddWithValue("@logid", Guid.NewGuid().ToString());
                                updatecmd.Parameters.AddWithValue("@DayReportId", DayReportId);
                                updatecmd.Parameters.AddWithValue("@error", up.ermsg);
                                updatecmd.ExecuteNonQuery();
                            }
                        }
                        
                        if (ind >= 0)
                        {
                            nowrecord[ind].localupdate = true;
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("上傳資料發生錯誤:" + ex.Message);
                    }
                    //參數是用@paramName


                }

                if (EndTimeS.Length > 0)
                {
                    EndTimeS[0].Text = EndTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
                if (WorkTimeS.Length > 0)
                {
                    WorkTimeS[0].Text = WorkTime.ToString();
                }
                for(var i = 0; i < nowselectrecord.Count; i++)
                {
                    if (nowselectrecord[i].DayReportId == DayReportId)
                    {
                        nowselectrecord[i].EndTime = EndTime;
                        nowselectrecord[i].WorkTime = (decimal)WorkTime;
                        nowselectrecord[i].CompleteQty = CompleteQty;
                        nowselectrecord[i].CompletGoQty = CompletGoQty;
                        nowselectrecord[i].CompletNgQty = CompletNgQty;
                        nowselectrecord[i].BadQty = BadQty;
                        nowselectrecord[i].BadGoQty = BadGoQty;
                        nowselectrecord[i].BadNgQty = BadNgQty;
                        nowselectrecord[i].AdjustTime = (decimal)AdjustTime;
                    }
                }
            }
            s.Close();
        }
        private void getstartrec(string pact,string makeno="",string startno="")
        {
            var EMP = tabPage1.Controls.Find("frmEmpshowno", true);
            var rEMP = tabPage2.Controls.Find("frmREno", true);
            var save = tabPage2.Controls.Find("save", true);
            Console.Write("saveconut=" + save.Count());
            save[0].Click += new EventHandler(savetab);
            rEMP[0].Text = EMP[0].Text;
            var empinfo1 = "";
            if (rEMP[0].Text.IndexOf(':') > 0)
            {
                var emptemp=rEMP[0].Text.Split(':');
                empinfo1 = emptemp[0];
                rEMP[0].Text = empinfo1;
            }
            Console.WriteLine("remp=" + rEMP[0].Text + ",emp=" + EMP[0].Text);
            List<WorkDayReport> nowrecordselect = new List<WorkDayReport>();
            if (rEMP[0].Text != "")
            {
                /*
                if (makeno != "")
                {
                    nowrecord = getrecord(rEMP[0].Text,makeno);
                }
                else if (startno != "")
                {
                    nowrecord = getrecord(rEMP[0].Text, "",startno);
                }
                else
                {
                    nowrecord = getrecord(rEMP[0].Text);
                }*/

                var temprTabn = tabPage2.Controls.Find("frmPTRecordnow", true);
                var indnum = 0;
                if (pact == "o")
                {
                    nowrecord = null;
                    //nowrecordselect = null;
                    nowrecord = getrecord(rEMP[0].Text);
                    if (nowrecord.Count > 0)
                    {
                        var temprTabT = tabPage2.Controls.Find("frmRecTotal", true);
                        temprTabT[0].Text = nowrecord.Count.ToString();
                        temprTabn[0].Text = "0";
                        indnum = int.Parse(temprTabn[0].Text);
                        var temprTC = tabPage2.Controls.Find("totalcount", true);
                        var temprtqty = tabPage2.Controls.Find("tqty", true);
                        var temprTC2 = tabPage2.Controls.Find("totalcount2", true);
                        temprTC[0].Text = rtext["total"];
                        temprtqty[0].Text = temprTabT[0].Text;
                        temprtqty[0].ForeColor = Color.Blue;
                        temprTC2[0].Text = rtext["record"];
                        var temprN = tabPage2.Controls.Find("nowrecord", true);
                        var temprcqty = tabPage2.Controls.Find("cqty", true);
                        var temprN2 = tabPage2.Controls.Find("nowrecord2", true);
                        temprN[0].Text = rtext["current"];
                        temprcqty[0].Text = ((indnum + 1).ToString());
                        temprcqty[0].ForeColor = Color.Blue;
                        temprN2[0].Text = rtext["record"];
                        nowrecordselect.Add(nowrecord[indnum]);
                    }

                }
                else if (pact == "s")
                {
                    nowrecord = null;
                    //nowrecordselect = null;
                    nowrecord = getrecord(rEMP[0].Text);
                    if (nowrecord.Count > 0)
                    {

                       List<WorkDayReport> srecord = new List<WorkDayReport>();
                        if (makeno != "")
                        {
                            nowrecord= nowrecord.Where(x => x.MakeNo == makeno && !x.WorkTime.HasValue).ToList();
                        }
                        else if(startno!="")
                        {
                           nowrecord  = nowrecord.Where(x => x.MakeNo.StartsWith(startno.ToUpper())&& !x.WorkTime.HasValue).ToList();
                        }
                        var temprTabT = tabPage2.Controls.Find("frmRecTotal", true);
                        temprTabT[0].Text = nowrecord.Count.ToString();
                        temprTabn[0].Text = "0";
                        indnum = int.Parse(temprTabn[0].Text);
                        var temprTC = tabPage2.Controls.Find("totalcount", true);
                        var temprtqty = tabPage2.Controls.Find("tqty", true);
                        var temprTC2 = tabPage2.Controls.Find("totalcount2", true);
                        temprTC[0].Text = rtext["total"];
                        temprtqty[0].Text = temprTabT[0].Text;
                        temprtqty[0].ForeColor = Color.Blue;
                        temprTC2[0].Text = rtext["record"];
                        var temprN = tabPage2.Controls.Find("nowrecord", true);
                        var temprcqty = tabPage2.Controls.Find("cqty", true);
                        var temprN2 = tabPage2.Controls.Find("nowrecord2", true);
                        temprN[0].Text = rtext3["current"];
                        temprcqty[0].Text = ((indnum + 1).ToString());
                        temprcqty[0].ForeColor = Color.Blue;
                        temprN2[0].Text = rtext["record"];
                        if (nowrecord.Count>0)
                        {
                             nowrecordselect.Add(nowrecord[indnum]);
                        }


                    }
                }
                else
                {
                    //nowrecordselect = null;
                    var tempstr = temprTabn[0].Text;
                    var tempnum = int.Parse(tempstr);
                    if (tempnum + 1 < nowrecord.Count&&nowrecord.Count>0)
                    {
                        indnum = tempnum + 1;
                        temprTabn[0].Text = indnum.ToString();
                        nowrecordselect.Add(nowrecord[indnum]);
                        var temprN = tabPage2.Controls.Find("cqty", true);
                        temprN[0].Text = (indnum + 1).ToString();
                    }
                }


            }
            foreach (var item in nowrecord)
            {
                Console.WriteLine(item.DayReportId + "," + item.EmployeeId + "," + item.AdjustTime + "," + item.BadQty + "," + item.CompleteQty + "," + item.EndTime + "," + item.StartTime + "," + item.TenantId + "," + item.WorkDate + "," + item.WorkQty);
            }
            var rTab = tabPage2.Controls.Find("RPanel", true);
            var rTabC = tabPage2.Controls.Find("frmPTRecordnow", true);
            var rTabT = tabPage2.Controls.Find("frmRecTotal", true);
            TableLayoutPanel rp = (TableLayoutPanel)rTab[0];
            for (int i = rp.Controls.Count - 1; i >= 0; --i)
                rp.Controls[i].Dispose();
            rp.Controls.Clear();

            var keytab = tabPage2.Controls.Find("NumPanel", true);
            TableLayoutPanel keyp = (TableLayoutPanel)keytab[0];
            for (int i = keyp.Controls.Count - 1; i >= 0; --i)
                keyp.Controls[i].Dispose();
            keyp.Controls.Clear();
            Int32 tlpColumCount = ((TableLayoutPanel)rTab[0]).ColumnCount;
            Int32 tlpRowCount = ((TableLayoutPanel)rTab[0]).RowCount;
            var newtable = new TableLayoutPanel();
            List<List<TextBox>> blist = new List<List<TextBox>>();
            var namelist = new string[] { "GP-NP", "GP-WP", "GP-IP", "GR-NR", "GR-IR", "GR-WR" };
            var hidelist = new string[] { "UseUnits", "TenantId", "WorkOrderId", "WorkOrderItemId", "WorkId", "WorkDate" };
            var emptydata = tabPage2.Controls.Find("emptydata", true);
            if (nowrecordselect.Count > 0)
            {
                emptydata[0].Visible = false;
                var itemi = 0;
                tlpRowCount = 1;
                tlpColumCount = 11;
                var isgong = false;
                foreach (var item in nowrecordselect)
                {
                    itemi++;
                    var itemj = 0;
                    var dayid = "";
                    var displaylist = new List<string> { "MakeNo", "StartTime", "CompleteQty", "BadQty", "WorkQty", "WorkNo", "WorkName", "Specification", "WorkTime", "EndTime" };
                    var editlist = new string[] { "CompleteQty", "BadQty" };
                    if (item.UseUnits.TrimStart().TrimEnd()=="Set")
                    {
                        displaylist =new List<string>() { "MakeNo", "StartTime", "CompletGoQty", "CompletNgQty", "BadGoQty", "BadNgQty", "WorkQty", "WorkNo", "WorkName", "Specification", "WorkTime", "EndTime" };
                        editlist = new string[] { "CompletGoQty", "CompletNgQty", "BadGoQty", "BadNgQty" };
                    }
                    Console.WriteLine("display:" + itemi + "," + displaylist.Count());
                    List<TextBox> btnemplist = new List<TextBox>();
                    foreach (var prop in item.GetType().GetProperties())
                    {
                        var cAssetsName = "";
                        if (prop.Name == "DayReportId")
                        {
                            dayid = prop.GetValue(item).ToString();
                        }
                        var prestr = "BTN";
                        var poststr = itemi.ToString("##");
                        var poststr2 = itemj.ToString("##");
                        bool isedit = editlist.Contains(prop.Name);
                        var thisbtnname = prestr + "-" + prop.Name;
                        string thisbtntext = prop.GetValue(item) != null ? prop.GetValue(item).ToString() : "";
                        if (displaylist.Contains(prop.Name))
                        {
                            itemj++;
                            // Console.WriteLine("p=" + prop.Name + ",v=" + prop.GetValue(item).ToString());

                            /* if (prop.Name == "EndTime")
                             {
                                 TextBox endbtn = new CreateElement(dayid, "").CreateBtn(thisbtntext, isedit, itemj);
                                 btnemplist.Add(endbtn);
                             }
                             else
                             {

                             }*/
                            TextBox empbtn = new CreateElement(thisbtnname, thisbtntext).CreateBtn(thisbtntext, isedit, itemj,true);
                            if (isedit)
                            {
                                empbtn.TextChanged += new EventHandler(CheckQTY);
                                empbtn.GotFocus+= new EventHandler(BtnGotfocus);
                            }
                            btnemplist.Add(empbtn);
                        }
                        if (hidelist.Contains(prop.Name))
                        {
                            TextBox empbtn = new CreateElement(thisbtnname, thisbtntext).CreateBtn(thisbtntext, isedit, 999, false);
                            btnemplist.Add(empbtn);
                        }
                    }
                    TextBox rid = new TextBox();
                    rid.Visible = false;
                    rid.Name = "DayReportId";
                    rid.TabIndex = 999;
                    rid.Text = dayid;
                    btnemplist.Add(rid);
                    blist.Add(btnemplist);
                    var sprestr = "Rsave";
                    var spoststr = itemi.ToString("##");
                    var sthisbtnname = sprestr + spoststr;
                    var btnkey = "F" + spoststr;
                    string sthisbtntext = dayid;
                    var mmsg = "";
                    foreach(var itema in btnemplist)
                    {
                        mmsg += "," + itema.Name;
                    }

                }
                var icount = 0;
                var isc = int.TryParse(rTabC[0].Text, out icount);

                var tableheadstr = new string[] { rtext["makeno"], rtext["spec"], rtext["proc"], "", rtext["makeqty"], rtext["completeqty"], rtext["badqty"],rtext["starttime"], rtext["endtime"], rtext["worktime"] };

                    var bitem = blist[0];
                    if (bitem.Count>17)
                        tableheadstr = new string[] { rtext["makeno"], rtext["spec"], rtext["proc"], "", rtext["makeqty"], "Go"+ rtext["completeqty"], "NoGo"+ rtext["completeqty"], "Go"+ rtext["badqty"], "NoGo"+ rtext["badqty"], rtext["starttime"], rtext["endtime"], rtext["worktime"] };
                    for (var a = 0; a < tableheadstr.Count(); a++)
                    {
                        TextBox templab = new TextBox();
                        templab.Text = tableheadstr[a];
                        templab.ReadOnly = true;
                        templab.Margin = new Padding(0);
                        templab.TabIndex = 999;
                        templab.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
                        ((TableLayoutPanel)rTab[0]).Controls.Add(templab, a, 0);
                    }

                    for (var j = 0; j < bitem.Count; j++)
                    {
                        Console.WriteLine("Lqty-i=" + icount + ",j=" + j + ",name=" + bitem[j].Name);
                        ((TableLayoutPanel)rTab[0]).Controls.Add((TextBox)bitem[j], j, 0 + 1);
                    }
                var actg = tabPage2.Controls.Find("BTN-CompleteQty", true);
                var actn = tabPage2.Controls.Find("BTN-CompletGoQty", true);
                if (actg.Count() > 0)
                    actg[0].Select();
                if (actn.Count() > 0)
                    actn[0].Select();
            }
            else
            {
                emptydata[0].Text = rtext["nodata"];
                emptydata[0].Visible = true;
            }
            var numpad = tabPage2.Controls.Find("NumPanel", true);
            Int32 tlpColumCountkey = ((TableLayoutPanel)(numpad[0])).ColumnCount;
            Int32 tlpRowCountkey = ((TableLayoutPanel)(numpad[0])).RowCount;
            string[] numlist = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ".", "Clear" };
            string[] keylist = new string[] { "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", "Decimal", "End" };
            List<Button> btnkeylist = new List<Button>();
            var empitemcount = 0;

            for (var empitem = 0; empitem < numlist.Length; empitem++)
            {
                var prestr = "BTNkey";
                empitemcount++;
                var poststr = empitemcount.ToString("##");
                var thisbtnname = prestr + keylist[empitem];
                var thisbtntext = numlist[empitem];
                var btnkey = keylist[empitem];
                Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateNumBtn(numlist[empitem], keylist[empitem]);
                empbtn = sethandlerbtn(empbtn);
                btnkeylist.Add(empbtn);
            }
            Console.WriteLine("qtybtn=" + btnkeylist.Count + "," + tlpColumCountkey + "," + tlpRowCountkey);
            var btnj = 0;
            for (var i = 0; i < tlpRowCountkey; i += tlpColumCountkey)
            {
                for (; btnj < btnkeylist.Count && btnj < tlpColumCountkey * tlpRowCountkey; btnj++)
                {
                    Console.WriteLine("Lqty-i=" + i + ",j=" + btnj + ",name=" + btnkeylist[btnj].Name + ",text=" + btnkeylist[btnj].Text);
                    ((TableLayoutPanel)(numpad[0])).Controls.Add(btnkeylist[btnj], btnj, i);
                    // frmNumRecordnow.Text = j.ToString();
                }
            }
            var cqty1 = tabPage2.Controls.Find("BTN-CompleteQty", true);
            var cqty2 = tabPage2.Controls.Find("BTN-CompleteGoQty", true);
            var whoisfocused = "";
            if (cqty1.Length > 0)
            {
                if (cqty1[0].Focused)
                    whoisfocused = cqty1[0].Name;
            }
            if (cqty2.Length > 0)
            {
                if (cqty2[0].Focused)
                    whoisfocused = cqty2[0].Name;
            }
            //var getfirstfocus = tabPage2.Controls.Find("focust", true);
            //getfirstfocus[0].Text = whoisfocused;
            //Console.Write("firstfocus=" + whoisfocused);

        }
        private void CheckQTY(object sender, EventArgs e)
        {
            TextBox tmpButton = (TextBox)sender;

            var CompleteQtyS = tabPage2.Controls.Find("BTN-CompleteQty", true);
            var BadQtyS = tabPage2.Controls.Find("BTN-BadQty", true);
            var CompletGoQtyS = tabPage2.Controls.Find("BTN-CompletGoQty", true);
            var CompletNgQtyS = tabPage2.Controls.Find("BTN-CompletNgQty", true);
            var BadGoQtyS = tabPage2.Controls.Find("BTN-BadGoQty", true);
            var BadNgQtyS = tabPage2.Controls.Find("BTN-BadNgQty", true);
            var MakeNoS = tabPage2.Controls.Find("BTN-MakeNo", true);
            var Units = tabPage2.Controls.Find("BTN-UseUnits", true);
            var WorkNoS = tabPage2.Controls.Find("BTN-WorkNo", true);
            var WorkQtyS = tabPage2.Controls.Find("BTN-WorkQty", true);
            var cqty = 0m;
            var bqty = 0m;
            var gcqty = 0m;
            var ncqty = 0m;
            var gbqty = 0m;
            var nbqty = 0m;
            var makeqty = 0m;
            if (CompleteQtyS.Length > 0)
                decimal.TryParse(CompleteQtyS[0].Text, out cqty);
            if (BadQtyS.Length > 0)
                decimal.TryParse(BadQtyS[0].Text, out bqty);
            if (CompleteQtyS.Length > 0)
                decimal.TryParse(CompleteQtyS[0].Text, out cqty);
            if (CompletGoQtyS.Length > 0)
                decimal.TryParse(CompletGoQtyS[0].Text, out gcqty);
            if (CompletNgQtyS.Length > 0)
                decimal.TryParse(CompletNgQtyS[0].Text, out ncqty);
            if (BadGoQtyS.Length > 0)
                decimal.TryParse(BadGoQtyS[0].Text, out gbqty);
            if (BadNgQtyS.Length > 0)
                decimal.TryParse(BadNgQtyS[0].Text, out nbqty);
            if (WorkQtyS.Length > 0)
                decimal.TryParse(WorkQtyS[0].Text, out makeqty);
            if(CompletGoQtyS.Length > 0 && CompletNgQtyS.Length > 0 && BadGoQtyS.Length > 0 && BadNgQtyS.Length > 0)
            {
                cqty = (gcqty + ncqty) / 2;
                bqty = (gbqty + nbqty) / 2;
            }
            if (makeqty > 0)
            {
                if (cqty + bqty > makeqty)
                {
                    ermsg.Visible = true;
                    ermsg.Text = rtext["qtygreat"];
                }
                else
                {
                    ermsg.Visible = false;
                    ermsg.Text = "";
                }
            }
        }
        private void BtnGotfocus(object sender, EventArgs e)
        {
            TextBox tmpButton = (TextBox)sender;
            var getfirstfocus = tabPage2.Controls.Find("focust", true);
            getfirstfocus[0].Text = tmpButton.Name;
            Console.Write("gotfocus=" + getfirstfocus[0].Text);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void frmPTbtnU_Click(object sender, EventArgs e)
        {
            var nowrec = getsetorder("u");
            setview(nowrec, "u");
        }

        private void frmPTbtnD_Click(object sender, EventArgs e)
        {
            var nowrec = getsetorder("d");
            setview(nowrec, "d");
        }

        private void RECsearch_TextChanged(object sender, EventArgs e)
        {
            if (RECsearch.Text != "")
            {
                var realstr = RECsearch.Text.TrimStart().TrimEnd();
                var mkno = "";
                if (realstr != string.Empty)
                {
                    if (realstr.IndexOf("::") >= 0)
                    {
                        mkno = realstr.Split(new string[] { "::" }, StringSplitOptions.None).First().ToUpper();

                    }
                    else
                    {
                        mkno = realstr.ToUpper();
                    }
                }
                nowselectrecord = nowrecord.Where(x => x.MakeNo.StartsWith(mkno)).ToList();
                frmRecTotal.Text = nowselectrecord.Count.ToString();
                frmPTRecordnow.Text = "0";
            }
            else
            {
                nowselectrecord = nowrecord;
                frmRecTotal.Text = nowselectrecord.Count.ToString();
                frmPTRecordnow.Text = "0";
            }
            setview(0, "o");
        }
        private void showrecordmsg(int now,int total) {
            frmRecTotal.Text = total.ToString();
            int nowrecord = 0;
            int.TryParse(frmPTRecordnow.Text, out nowrecord);
            totalcount.Text = rtext["total"];
            tqty.Text = frmRecTotal.Text;
            tqty.ForeColor = Color.Blue;
            totalcount2.Text = rtext["record"];
            nowrecordt.Text = rtext["current"];
            cqty.Text = ((now + 1).ToString());
            cqty.ForeColor = Color.Blue;
            nowrecord2.Text = rtext["record"];
        }
    }
}
