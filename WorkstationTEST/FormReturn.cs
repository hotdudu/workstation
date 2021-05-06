using System;
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
    public partial class FormReturn : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public const int WM_CLOSE = 0x10;
        public bool debug = true;
        public FormReturn(frmMenu fmenu)
        {
            InitializeComponent();
            this.Tag = fmenu;
            this.KeyPreview = true;
            this.Activate();
            this.KeyDown += new KeyEventHandler(mybutton_Click);
            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                DepartNo = oTINI.getKeyValue("SYSTEM", "DepartNo", "");
                NIG = oTINI.getKeyValue("SYSTEM", "NIG", "");
                DefCompany = oTINI.getKeyValue("SYSTEM", "DefCompany", "");
            }
        }
        string sIP = "61.221.176.176";
        string sComport = new API("x", "x").COMPORT;
        delegate void Display(Byte[] buffer);
        private string DefCompany = "";//預設公司
        private string DepartNo = "";//要過濾的部門編號開頭
        private string NIG = "";//在過濾部門範圍外要新增的員工編號，只允許一位
        private string ButtonName = "out";//動態產生的按鈕prefix
        List<Empm> getemp = new List<Empm>();
        List<Partnerm> getpartner = new List<Partnerm>();
        List<WorkOutReport> nowrecord = new List<WorkOutReport>();
        Dictionary<string, string> rtext = CreateElement.loadresx("WK");
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    showpartner();
                    frmPTshowno.TextChanged += new EventHandler(gettab2);
                    //mk[0].TextChanged += new EventHandler(gettabnowo);
                    break;
                case 2:
                    showrecord("o");
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FormReturn_Load(object sender, EventArgs e)
        {
            //  this.TopLevel = false;
            //  this.Visible = true;
            var setpageup = new CreateElement();
            setpageup.SetBtn(button1, "PageUp::PageUp", "上一步");
            setpageup.SetBtn(button2, "Escape::Escape", "關閉視窗");
            setpageup.SetBtn(button4, "Home::Home", "完成");
            setpageup.SetBtn(button3, "PageDown::Next", "下一步");
            setpageup.SetBtn(save, "F12::F12", "全部上傳");
            this.WindowState = FormWindowState.Maximized;
            showemp();
            frmEmpshowno.TextChanged += new EventHandler(gettab);
            openseria();
        }
        private void gettab(object sender, EventArgs e)
        {

            if (frmEmpshowno.Text == "")
            {
                this.tabControl1.SelectedTab = tabPage1;
            }
            else
            {
                this.tabControl1.SelectedTab = tabPage2;
            }

        }
        private void gettab2(object sender, EventArgs e)
        {

            if (frmPTshowno.Text == "")
            {
                this.tabControl1.SelectedTab = tabPage2;
            }
            else
            {
                this.tabControl1.SelectedTab = tabPage3;
            }

        }
        private void showemp()
        {
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            var setpageup = new CreateElement();
            setpageup.SetBtn(frmEmpPageU, "Insert::Insert", rtext["frmWKbtnU"]);
            setpageup.SetBtn(frmEmpPageD, "Delete::Delete", rtext["frmWKbtnD"]);
            getemp = new API("/CHG/Main/Home/getEmployee2/", "http://").GetEmpm(DefCompany,DepartNo, NIG);
            // List<Button> btnemplist = new List<Button>();
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
                    var poststr = empitemcount.ToString("##");
                    var thisbtnname = prestr + poststr;
                    var thisbtntext = empitem.FullName;
                    Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateEmpBtnWithXY(empitem.EmployeeNo, thisbtntext, empitem.EmployeeId, btnkey, iRow, iCol, iSpace, EMPPanel);

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
        }

        private void showpartner()
        {
            getpartner = new API("/CHG/Main/Home/getPartner2/", "http://").GetPartnerm(int.Parse(DefCompany));
            //List<Button> btnemplist = new List<Button>();
            if (getpartner.Count() > 0)
            {
                int iSpace = 5;
                int iCol = 0;
                int iRow = 0;
                int ItemsOneRow = 5;
                int totalitem = 10;
                int btnnum = 0;
                var empitemcount = 0;
                var keynum = 0;
                foreach (var empitem in getpartner)
                {
                    var nowcate = getpropername(empitem.PartnerNo);
                    if (nowcate == "")
                    {
                        nowcate = empitem.CategoryName;
                        nowcate = nowcate.Substring(nowcate.IndexOf('-') + 1);
                    }
                    iRow = keynum / ItemsOneRow;
                    iCol = keynum % ItemsOneRow;
                    var prestr = "BTNfrmP";
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
                    var thisbtntext = empitem.ShortName;
                    var rlist = empitem.Rlist;
                    var IsMultiple = false;
                    var rno = "";
                    var rtenant = "";
                    var pids = "";
                    if (rlist.Count > 1)
                    {
                        IsMultiple = true;
                        var ri = 0;
                        foreach (var ritem in rlist)
                        {
                            rno += (ri == 0 ? ritem.no : "," + ritem.no);
                            rtenant += (ri == 0 ? ritem.tenant : "," + ritem.tenant);
                            pids += (ri == 0 ? ritem.id.ToString() : "," + ritem.id.ToString());
                            ri++;
                        }
                    }
                    Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreatePTBtnWithXYr(nowcate, thisbtntext, empitem.PartnerNo, empitem.PartnerId, btnkey, iRow, iCol, iSpace, PTPanel, IsMultiple, rno, rtenant, pids);
                    empbtn = sethandlerPartner(empbtn);
                    if (keynum > totalitem)
                    {
                        empbtn.Visible = false;
                    }
                    empbtn.TabStop = false;
                    empbtn.TabIndex = 99;
                    // btnemplist.Add(empbtn);
                }
                frmPTRecordnow.Text = "0";
            }
        }

        private void showrecord(string act,string info="")
        {
            RPanel.AutoScroll = false;              //
            RPanel.HorizontalScroll.Enabled = false;//取消水平卷軸
            RPanel.AutoScroll = true;               //
            if (act == "o")
            {
                nowrecord.Clear();
            }

            for (int c = RPanel.Controls.Count - 1; c >= 0; --c)
                RPanel.Controls[c].Dispose();
            var itemi = 0;
            var itemj = 0;
            var dayid = "";
            var headlist = new List<string> { "工令", "產品編號", "規格", "製程", "", "加工日期", "外包數", "單位", "外包單號", "完成"+Environment.NewLine+"數", "不良"+Environment.NewLine+"數", "執行" };
            var widthlist = new List<int> { 110, 110, 110, 60, 80, 110, 80, 60, 135, 60, 60,145 };
            var displaylist = new List<string> { "MakeNo", "AssetsNo", "Specification", "WorkNo", "WorkName", "WorkDate", "CompleteQty", "UseUnits", "OutNo", "RCompleteQty", "RBadQty" };
            var editlist = new string[] { "RCompleteQty", "RBadQty" };
            var hidelist = new string[] { "DayReportId" };
            List<TextBox> btnrlist = new List<TextBox>();
            List<Label> LBrlist = new List<Label>();
            List<btnsize> btslist = new List<btnsize>();
            var LBheight = 50;
            for (var i = 0; i < headlist.Count; i++)
            {

                Label LB = new Label();
                LB.Width = widthlist[i];
                LB.AutoSize = false;
                LB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                LB.Text = headlist[i];
                LB.Font = new Font("", 15, FontStyle.Bold);
                LB.TabIndex = 999;
                LB.Margin = new Padding(0);
                if (LB.Height > LBheight)
                    LBheight = LB.Height;
                LBrlist.Add(LB);
            }
            for (var lb = 0; lb < LBrlist.Count; lb++)
            {
                LBrlist.ElementAt(lb).Height = LBheight;
            }
            for (var j = 0; j < displaylist.Count; j++)
            {
                btslist.Add(new btnsize() { name = displaylist[j], width = widthlist[j] });
            }
            if (act == "o")
            {
                string dbPath = Directory.GetCurrentDirectory() + "\\" + "wd3.db3";
                string cnStr = "data source=" + dbPath + ";Version=3;";
                if (File.Exists(dbPath))
                {
                    using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                    {
                        var insertScript = "SELECT * FROM WorkDayReports  WHERE PartnerId=@PartnerId  AND  isupdate=1 AND (isreturn=0 OR isreturn is null) Order by StartTime";
                        SQLiteCommand cmd = new SQLiteCommand(insertScript, conn);
                        if (debug)
                            MessageBox.Show("partneridr=" +PTSavePartnerId.Text);
                        cmd.Parameters.AddWithValue("@PartnerId", PTSavePartnerId.Text);
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
                                var ritem = new WorkOutReport()
                                {
                                    DayReportId = row["DayReportId"] as string ?? "",
                                    AssetsNo = row["AssetsNo"] as string ?? "",
                                    AssetsName = row["AssetsName"] as string ?? "",
                                    AssetsId = row["AssetsId"] as string ?? "",
                                    TenantId = row["TenantId"] as int? ?? default(int),
                                    EmployeeId = row["EmployeeId"] as string ?? "",
                                    EndTime = row["EndTime"] as DateTime? ?? null,
                                    AdjustTime = row["AdjustTime"] as decimal? ?? null,
                                    BadQty = row["BadQty"] as decimal? ?? null,
                                    CompleteQty = row["CompleteQty"] as decimal? ?? null,
                                    StartTime = row["StartTime"] as DateTime? ?? null,
                                    WorkDate = row["WorkDate"].ToString(),
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
                                    Price = row["Price"] as decimal? ?? null,
                                    CompletGoQty = row["CompletGoQty"] as decimal? ?? null,
                                    CompletNgQty = row["CompletNgQty"] as decimal? ?? null,
                                    BadGoQty = row["BadGoQty"] as decimal? ?? null,
                                    BadNgQty = row["BadNgQty"] as decimal? ?? null,
                                    itemno = itemcount,
                                    UseUnits = row["Unit"] as string ?? "",
                                    OutNo = row["OutNo"] as string ?? "",
                                    RBadQty = row["RBadQty"] as decimal? ?? null,
                                    RCompleteQty = row["RCompleteQty"] as decimal? ?? null,
                                    isreturn = row["isreturn"] as bool? ?? null,
                                };
                                nowrecord.Add(ritem);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
            else
            {
                getsearch(act, info);
            }
            var recordcount = 0;
            var edittabcount = 1;
            foreach (var ritem in nowrecord)
            {
                recordcount++;
                var recordbtn = new TextBox();
                foreach (var prop in ritem.GetType().GetProperties())
                {
                    var cAssetsName = "";
                    if (prop.Name == "DayReportId")
                    {
                        dayid = prop.GetValue(ritem).ToString();
                    }
                    var prestr = "BTN";
                    var poststr = itemi.ToString("##");
                    var poststr2 = itemj.ToString("##");
                    bool isedit = editlist.Contains(prop.Name);
                    var thisbtnname = prestr + "-" + prop.Name;
                    string thisbtntext = dayid;
                    if (displaylist.Contains(prop.Name))
                    {
                        itemj++;
                        var d_textsize = btslist.Where(x => x.name == prop.Name).First();

                        TextBox empbtn = new CreateElement(thisbtnname, thisbtntext).CreateBtn(prop.GetValue(ritem)?.ToString(), isedit, itemj, true, d_textsize.width);
                        if (isedit)
                        {
                            empbtn.GotFocus += new EventHandler(BtnGotfocus);
                            empbtn.TextChanged += new EventHandler(TxtChanged);
                            empbtn.TabIndex = edittabcount;
                                edittabcount++;
                        }
                       // empbtn.Text = empbtn.TabIndex.ToString();
                        btnrlist.Add(empbtn);
                    }
                    if (hidelist.Contains(prop.Name))
                    {
                        var hnum = recordcount % 12;
                        Console.WriteLine("hnum=" + thisbtnname + "-" + hnum);
                        recordbtn = new CreateElement(thisbtnname+"-"+hnum, thisbtntext).CreateBtn(thisbtntext, isedit, 999, true);
                        recordbtn.Tag = recordbtn.Text;
                        recordbtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                        recordbtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                        recordbtn.BackColor = Color.MediumSeaGreen;
                        recordbtn.Font = new Font("Arial", 15, FontStyle.Bold);
                        recordbtn.Name = ButtonName + recordcount;
                        recordbtn.Text = "F" + hnum; //"上傳";
                        recordbtn.Click += new EventHandler(btnEMPALL_ClickR);
                        // btnrlist.Add(empbtn);
                    }
                }
                recordbtn.Tag += ":" + ritem.AssetsId + ":" + ritem.WorkId + ":" + ritem.WorkOrderItemId + ":" + ritem.TenantId + ":" + ritem.Price;
                btnrlist.Add(recordbtn);
            }

            int iSpace = 2;
            int iCol = 0;
            int iRow = 0;
            int ItemsOneRow = displaylist.Count;
            int recordrows = 8;
            int btnnum = 0;
            var empitemcount = 0;
            var keynum = 1;
            var Lkeynum = 0;
            var Lcol = 0;
            var cnum = 0;
            RPanel.ColumnCount = displaylist.Count + 1;
            /* foreach (var LBitem in LBrlist)
             {
                 Lcol = Lkeynum % ItemsOneRow;
                 Lkeynum++;
                 LBitem.Top = 0 * (iSpace * 2 + LBitem.Height) + iSpace;
                 LBitem.Left = Lcol * (LBitem.Width)-5;
                 //rbitem.Text = rbitem.Top + "," + rbitem.Left;
                 LBitem.Parent = RPanel;
                 LBitem.Margin = new Padding(0);
             }*/
            foreach(var citem in LBrlist)
            {
                var LCol = cnum % ItemsOneRow;
                if(citem.Width==50)
                {
                    Lkeynum += citem.Width+50;
                }
                else
                {
                    

                }
                Lkeynum += citem.Width;
                cnum++;
                citem.Top = 1 * (iSpace * 2 + citem.Height) + iSpace;
                citem.Left = Lkeynum;
                //rbitem.Text = rbitem.Top + "," + rbitem.Left;
                citem.Parent = RPanel;
            }
            foreach (var rbitem in btnrlist)
            {
                iRow = keynum % recordrows;
                if (keynum == recordrows)
                {
                    iRow = recordrows;
                }
                iCol = keynum % ItemsOneRow;
                var prestr = "BTNfrmR";
                empitemcount++;
                btnnum++;
                keynum++;

                rbitem.Top = iRow * (iSpace * 2 + rbitem.Height) + iSpace;
                rbitem.Left = iCol * (rbitem.Width);
                //rbitem.Text = rbitem.Top + "," + rbitem.Left;
                rbitem.Parent = RPanel;

                /*if (keynum > totalitem)
                {
                    empbtn.Visible = false;
                }
                empbtn.TabStop = false;
                empbtn.TabIndex = 99;*/
            }
        }

        public void SetEmpNO(string info)
        {
            frmEmpshowno.Text = info;
        }
        public void SetRecord(string info, string name)
        {
            var dayreports = info.Split(':');

            var recordcount = name.Replace(ButtonName, "");
            if (debug)
            {

            }
            List<Control> cons = new List<Control>();
            var ct = RPanel.ColumnCount;
            var empno = frmEmpshowno.Text.Contains(":") ? frmEmpshowno.Text.Split(':').First() : frmEmpshowno.Text;
            var pid = PTSavePartnerId.Text;
            var assetid = "";
            var workid = "";
            var workitemid = "";
            var tenant = "";
            var rqty = "";
            var rbqty = "";
            var dayreportid = "";
            var price = "";
            if (dayreports.Length >= 3)
            {
                dayreportid = dayreports[0];
                assetid = dayreports[1];
                workid = dayreports[2];
                workitemid = dayreports[3];
                tenant = dayreports[4];
                price = dayreports[5];
            }
            for (var i = 0; i < ct; i++)
            {
                var ritem = RPanel.GetControlFromPosition(i, int.Parse(recordcount) - 1);
                if (ritem != null)
                {
                    if (ritem.Name == "BTN-RCompleteQty")
                    {
                        rqty = ritem.Text;
                    }
                    if (ritem.Name == "BTN-RBadQty")
                    {
                        rbqty = ritem.Text;
                    }
                    //cons.Add(ritem);
                }
            }
            try
            {
                UpdateRecord(dayreportid,rqty,rbqty);
                var ReturnResult = new API("/CHG/Main/Home/AddOutsourceReturn/", "http://").UploadServerReturn(empno, rqty, rbqty, dayreportid, workid, workitemid, assetid, price, "", tenant, pid);
                if (ReturnResult.ids.Count > 0)
                {
                    List<Guid> daylist = ReturnResult.ids;
                    List<String> outlist = ReturnResult.no;
                    var outno = ReturnResult.no;
                    for (var ui = 0; ui < daylist.Count; ui++)
                    {
                        UpdateRecord(daylist[ui].ToString(), outlist[ui]);
                        nowrecord.RemoveAll(x => x.DayReportId == daylist[ui].ToString());
                        var actbutton= RPanel.Controls.Find(name, false);
                        if (actbutton.Length > 0)
                        {
                            actbutton[0].Text = outlist[ui].ToString();
                            actbutton[0].BackColor = Color.Gray;
                            actbutton[0].Size = new Size(140, 50);
                        }


                    }
                    
                }
                else
                {
                    MessageBox.Show("上傳資料失敗");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("上傳資料失敗:"+ex.Message);
            }

        }
        public void UpdateRecord(string id, string cqty,string bqty)
        {
            string dbPath = Directory.GetCurrentDirectory() + "\\" + "wd3.db3";
            string cnStr = "data source=" + dbPath + ";Version=3;";
            Console.WriteLine("db=" + File.Exists(dbPath) + "," + dbPath);
            List<WorkDayReport> wrecord = new List<WorkDayReport>();
            if (File.Exists(dbPath))
            {
                using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                {
                    var insertScript = "UPDATE  WorkDayReports SET  RCompleteQty=@cqty,RBadQty=@bqty WHERE DayReportId=@DayReportId";
                    SQLiteCommand cmd = new SQLiteCommand(insertScript, conn);
                    cmd.Parameters.AddWithValue("@DayReportId", id);
                    cmd.Parameters.AddWithValue("@cqty", cqty);
                    cmd.Parameters.AddWithValue("@bqty", bqty);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("更新上傳結果錯誤");
                    }
                    //參數是用@paramName


                }
            }

        }
        public void UpdateRecord(string id, string no)
        {
            string dbPath = Directory.GetCurrentDirectory() + "\\" + "wd3.db3";
            string cnStr = "data source=" + dbPath + ";Version=3;";
            Console.WriteLine("db=" + File.Exists(dbPath) + "," + dbPath);
            List<WorkDayReport> wrecord = new List<WorkDayReport>();
            if (File.Exists(dbPath))
            {
                using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                {
                    var insertScript = "UPDATE  WorkDayReports SET  isreturn=1,ReturnNo=@no,EndTime=@now WHERE DayReportId=@DayReportId";
                    SQLiteCommand cmd = new SQLiteCommand(insertScript, conn);
                    cmd.Parameters.AddWithValue("@DayReportId", id);
                    cmd.Parameters.AddWithValue("@no", no);
                    cmd.Parameters.AddWithValue("@now", DateTime.Now);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("更新上傳結果錯誤");
                    }
                    //參數是用@paramName


                }
            }

        }
        private void btnEMPALL_ClickR(object sender, EventArgs e)
        {
            TextBox tmpButton = (TextBox)sender;
            var btname = tmpButton.Name;
            SetRecord(tmpButton.Tag.ToString(), btname);
        }
        public Button sethandlerEmp(Button bt)
        {
            Button sbt = bt;
            sbt.Click += new EventHandler(btnEMPALL_ClickD);
            return sbt;
        }
        private void btnEMPALL_ClickD(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            SetEmpNO(tmpButton.Tag.ToString());
        }
        public Button sethandlerPartner(Button bt)
        {
            Button sbt = bt;
            sbt.Click += new EventHandler(btnEMPALL_ClickP);
            return sbt;
        }
        private void btnEMPALL_ClickP(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            SetPNo(tmpButton.Tag.ToString());
        }
        public void SetPNo(string info)
        {
            var PTarray = info.Split(':');
            Console.WriteLine("ptl=" + PTarray.Length);
            var ptno = "";
            var ptid = "";
            var ptname = "";
            var pcate = "";
            if (PTarray.Length > 4)
            {
                var rno = PTarray[4].Split(',');
                var rten = PTarray[5].Split(',');
                var rpid = PTarray[6].Split(',');
                if (debug)
                {
                    MessageBox.Show("rno=" + rno + ",rten=" + rten + ",pid=" + rpid);
                }
                FormMultiTenant frmt = new FormMultiTenant();
                frmt.setTenantm(rno, rten, rpid);
                frmt.ShowDialog();
                PTSavePartnerId.Text = frmt.PartnerId;

            }
            ptno = PTarray[3];
            ptid = PTarray[1];
            ptname = PTarray[2];
            pcate = PTarray[0];
            frmPTname.Text = ptname;
            PTSavePartnerId.Text = ptid;
            frmPTshowno.Text = ptno;

            // PTSavePartnerId.Text =ptid;//改成在輸入工序階段取得partnerid
            if (debug)
            {
                MessageBox.Show("ptno=" + frmPTshowno.Text + ",ptid=" + PTSavePartnerId.Text);
            }
        }

        private void frmEmpPageU_Click(object sender, EventArgs e)
        {
            var nowrow = 0;
            var tempn = int.TryParse(frmEmpRecordnow.Text, out nowrow);
            var totalitem = 10;
            if (nowrow > 0)
                nowrow--;
            frmEmpRecordnow.Text = nowrow.ToString();
            var startnum = nowrow * totalitem + 1;
            var endnum = (nowrow + 1) * totalitem;
            var npoint = 0;
            foreach (Control contr in EMPPanel.Controls)
            {
                npoint++;
                if (npoint >= startnum && npoint <= endnum && npoint <= EMPPanel.Controls.Count)
                {
                    contr.Visible = true;
                }
                else
                {
                    contr.Visible = false;
                }
            }

            var height = EMPPanel.Height;
            var vheight = nowrow * EMPPanel.Height;
            if (vheight - (height) < EMPPanel.VerticalScroll.Minimum)
            { EMPPanel.VerticalScroll.Value = EMPPanel.VerticalScroll.Minimum; }
            else
            { EMPPanel.VerticalScroll.Value = vheight; }
            EMPPanel.PerformLayout();
        }

        private void frmEmpPageD_Click(object sender, EventArgs e)
        {
            var nowrow = 0;
            var tempn = int.TryParse(frmEmpRecordnow.Text, out nowrow);
            var totalitem = 10;
            var totoalrow = Math.Ceiling(EMPPanel.Controls.Count / (decimal)totalitem);
            nowrow++;
            if (nowrow < totoalrow)
                frmEmpRecordnow.Text = nowrow.ToString();
            var startnum = nowrow * totalitem + 1;
            var endnum = (nowrow + 1) * totalitem;
            var npoint = 0;


            var height = EMPPanel.Height;
            var vheight = EMPPanel.Height * nowrow;
            if (nowrow < totoalrow)
            {
                foreach (Control contr in EMPPanel.Controls)
                {
                    npoint++;
                    Console.Write("ptype=" + contr.GetType() + "," + EMPPanel.Controls.Count);
                    if (npoint >= startnum && npoint <= endnum && npoint <= EMPPanel.Controls.Count)
                    {
                        contr.Visible = true;
                    }
                    else
                    {
                        contr.Visible = false;
                    }
                }
                EMPPanel.VerticalScroll.Value = vheight;
                EMPPanel.PerformLayout();
            }
        }

        private void frmPTbtnU_Click(object sender, EventArgs e)
        {
            var nowrow = 0;
            var tempn = int.TryParse(frmPTRecordnow.Text, out nowrow);
            var totalitem = 10;
            if (nowrow > 0)
                nowrow--;
            frmPTRecordnow.Text = nowrow.ToString();
            var startnum = nowrow * totalitem + 1;
            var endnum = (nowrow + 1) * totalitem;
            var npoint = 0;
            foreach (Control contr in PTPanel.Controls)
            {
                npoint++;
                if (npoint >= startnum && npoint <= endnum && npoint <= PTPanel.Controls.Count)
                {
                    contr.Visible = true;
                }
                else
                {
                    contr.Visible = false;
                }
            }

            var height = PTPanel.Height;
            var vheight = nowrow * PTPanel.Height;
            if (vheight - (height) < PTPanel.VerticalScroll.Minimum)
            { PTPanel.VerticalScroll.Value = PTPanel.VerticalScroll.Minimum; }
            else
            { PTPanel.VerticalScroll.Value = vheight; }
            PTPanel.PerformLayout();
        }

        private void frmPTbtnD_Click(object sender, EventArgs e)
        {
            var nowrow = 0;
            var tempn = int.TryParse(frmPTRecordnow.Text, out nowrow);
            var totalitem = 10;
            var totoalrow = Math.Ceiling(PTPanel.Controls.Count / (decimal)totalitem);
            nowrow++;
            if (nowrow < totoalrow)
                PTPanel.Text = nowrow.ToString();
            var startnum = nowrow * totalitem + 1;
            var endnum = (nowrow + 1) * totalitem;
            var npoint = 0;


            var height = PTPanel.Height;
            var vheight = PTPanel.Height * nowrow;
            if (nowrow < totoalrow)
            {
                foreach (Control contr in PTPanel.Controls)
                {
                    npoint++;
                    Console.Write("ptype=" + contr.GetType() + "," + PTPanel.Controls.Count);
                    if (npoint >= startnum && npoint <= endnum && npoint <= PTPanel.Controls.Count)
                    {
                        contr.Visible = true;
                    }
                    else
                    {
                        contr.Visible = false;
                    }
                }
                PTPanel.VerticalScroll.Value = vheight;
                PTPanel.PerformLayout();
            }
        }

        public string getpropername(string phone)
        {
            string dbPath = Directory.GetCurrentDirectory() + "\\" + "wd3.db3";
            string cnStr = "data source=" + dbPath + ";Version=3;";
            var result = "";
            if (File.Exists(dbPath))
            {
                using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                {
                    var selectScript = "SELECT * FROM LPartner L WHERE phone=@phone";
                    SQLiteCommand cmd2 = new SQLiteCommand(selectScript, conn);
                    cmd2.Parameters.AddWithValue("@phone", phone);
                    conn.Open();
                    using (SQLiteDataReader row = cmd2.ExecuteReader())
                    {
                        while (row.Read())
                        {
                            result = row["cate"] as string ?? "";
                        }
                    }
                }
            }
            return result;
        }

        public List<WorkOutReport> getrecord(string pid, string outdate = "", string outno = "")
        {
            string dbPath = Directory.GetCurrentDirectory() + "\\" + "wd3.db3";
            string cnStr = "data source=" + dbPath + ";Version=3;";
            Console.WriteLine("db=" + File.Exists(dbPath) + "," + dbPath);
            var ordertable = "StartTime";
            var direct = "ASC";
            List<WorkOutReport> wrecord = new List<WorkOutReport>();
            if (File.Exists(dbPath))
            {
                using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                {
                    var insertScript = "SELECT * FROM WorkDayReports  WHERE PartnerId=@pid AND isreturn=0 AND (OutNo IS NOT NULL AND OutNo !='')";

                    if (outdate != string.Empty)
                    {
                        insertScript += "AND " + "WorkDate" + "=" + "@outdate";
                    }

                    if (outno != string.Empty)
                    {
                        insertScript += "AND " + "OutNo" + "=" + "@outno";
                    }
                    insertScript += "Order by " + ordertable + " " + direct;
                    SQLiteCommand cmd = new SQLiteCommand(insertScript, conn);
                    cmd.Parameters.AddWithValue("@pid", pid);
                    if (outdate != string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@outdate", outdate);
                    }
                    if (outno != string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@outno", outno);
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
                            var ritem = new WorkOutReport()
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
                                isreturn = row["isreturn"] as bool? ?? null,
                                OutNo = row["OutNo"] as string ?? "",
                                RCompleteQty = row["RCompleteQty"] as decimal? ?? null,
                                RBadQty = row["RBadQty"] as decimal? ?? null,
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

        private void BtnGotfocus(object sender, EventArgs e)
        {
            TextBox tmpButton = (TextBox)sender;
            focust.Text = tmpButton.Name;
            var x = tmpButton.Location.X + tmpButton.Width;
            var y = tmpButton.Location.Y+ tmpButton.Height+305;
            var tmplocation = new Point(x, y);
            Console.WriteLine("act");

            if (numstat.Text == "")
            {
                var num = new Numpad(serialPort1, tmplocation);
                numstat.Text = "ok";
                num.ShowDialog();
                if (num.DialogResult == DialogResult.OK)
                {
                    tmpButton.Text = num.result;
                    Console.Write("gotfocus=" + focust.Text);
                }
            }



           // num.Close();
        }
        private void TxtChanged(object sender, EventArgs e)
        {
            TextBox tmpButton = (TextBox)sender;
            IntPtr ptr = FindWindow(null, "Numpad");
            if (ptr != IntPtr.Zero)
            {
                //找到則關閉MessageBox視窗
                PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
            numstat.Text = "";
            SendKeys.Send("{TAB}");
            Console.Write("gotchange=");
            // num.Close();
        }
        private void mybutton_Click(object sender, KeyEventArgs e)
        {
            Console.WriteLine("keycoe=" + e.KeyCode.ToString());
            setkeymap(e.KeyCode.ToString());
            //tmpb.PerformClick();
        }

        public void setkeymap(string keychar, string data = "", bool isbarcode = false)
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
            if (keyupper == "F12")
            {
                save.PerformClick();
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
                                ((Button)(tempbtn[0])).PerformClick();
                                Console.WriteLine("per:" + keychar);
                            }
                        }
                    }
                }
            }
            if (t == 1)
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
                            var estr = "BTNfrmP" + (i + 1);
                            Console.WriteLine("ke=" + keyupper + "," + keyarray[i] + estr);
                            var tempbtn = tabPage2.Controls.Find(estr, true);
                            if (tempbtn.Length > 0)
                            {
                                ((Button)(tempbtn[0])).PerformClick();
                                Console.WriteLine("per:" + keychar);
                            }
                        }
                    }
                }
            }
            if (t == 2)
            {
                var up = tabPage1.Controls.Find("frmEmpPageU", true);
                var down = tabPage1.Controls.Find("frmEmpPageD", true);
                string[] keyarray = new string[] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10","F11" };
                if (keyupper == "Return")
                {
                    SendKeys.Send("{TAB}");
                }
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
                            var estr = "BTN-DayReportId-" + (i + 1);
                            Console.WriteLine("ke=" + keyupper + "," + keyarray[i] + estr);
                            var tempbtn = tabPage2.Controls.Find(estr, true);
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

        private void FormReturn_FormClosed(object sender, FormClosedEventArgs e)
        {
            tempclose();
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

        private void DisplayTextSeria(Byte[] buffer)
        {
            var scanData = System.Text.Encoding.ASCII.GetString(buffer).ToString().Trim();
            ShowDataSeria(scanData);

        }

        public void DisplayTextClick(string clickData)
        { ShowDataClick(clickData); }
        public string ShowDataClick(string data)
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

        public string ShowDataSeria(string data)
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
                    setkeymap(pkey, "", true);
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
            Display d = new Display(DisplayTextSeria);
            this.Invoke(d, new Object[] { buffer });
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
                catch (Exception ex)
                {
                    MessageBox.Show("開啟掃描器異常");
                }
            }

            Console.WriteLine("isopen:" + serialPort1.IsOpen);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtsearchbyW_TextChanged(object sender, EventArgs e)
        {
            TextBox nowstr = (TextBox)sender;
            var realstr = nowstr.Text.TrimStart().TrimEnd();
            showrecord("w", realstr);
        }

        private void txtsearchbyO_TextChanged(object sender, EventArgs e)
        {
            TextBox nowstr = (TextBox)sender;
            var realstr = nowstr.Text.TrimStart().TrimEnd();
            showrecord("r",realstr);
        }

        private void getsearch(string type,string realstr)
        {
            if (type == "w")
            {
                if (realstr != string.Empty)
                {
                    if (realstr.IndexOf("::") >= 0)
                    {
                        var makenoarray = realstr.Split(new string[] { "::" }, StringSplitOptions.None);
                        var  workorderid = makenoarray[2];
                        var makeno = makenoarray[0];
                        nowrecord = nowrecord.Where(x => x.WorkOrderId == workorderid).ToList();
                    }
                    else
                    {
                        nowrecord = nowrecord.Where(x=>x.MakeNo.StartsWith(realstr.ToUpper())).ToList();
                    }
                }
                else
                {
                }
            }
            if (type == "r")
            {
                if (realstr != string.Empty)
                {
                    nowrecord = nowrecord.Where(x => x.OutNo.StartsWith(realstr.ToUpper())).ToList();
                }
                else
                {

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
                        this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            cleardata(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var t = this.tabControl1.SelectedIndex;
            if (t < this.tabControl1.Controls.Count - 1)
            {
                this.tabControl1.SelectedIndex = t + 1;
            }
        }

        public void cleardata(bool finish)
        {
            try
            {
                frmEmpshowno.Text = string.Empty;
                frmPTRecordnow.Text = string.Empty;
                frmPTRecordT.Text= string.Empty;
                frmPTshowno.Text = string.Empty;
                if (finish)
                {
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("cleardata error:" + ex.Message);
            }

        }

        private void save_Click(object sender, EventArgs e)
        {
            var s = new saving();
            s.Show();
            var t = nowrecord.Count;
            for (var i=0;i<t;i++)
            {
                i++;
                var buttonname = ButtonName + i;
                var con = RPanel.Controls.Find(buttonname, false);
                if(con.Length>0)
                {
                    SetRecord(con[0].Tag.ToString(),con[0].Name);
                }

            }
            s.Close();
        }
    }
}
