using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkstationTEST
{
    public partial class FormMain : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        public FormMain(frmMenu fmenu)
        {
            this.Tag = fmenu;
            InitializeComponent();
            this.KeyPreview = true;
            this.Activate();
            this.KeyDown+= new KeyEventHandler(mybutton_Click);
        }
        int fullwidth = 600;
        int fullheight = 600;
        int tabpageheight = 400;
       // public string sIP;
        public string sComport = new API("x","x").COMPORT;
        delegate void Display(Byte[] buffer);
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    var frmEmp = new frmEmp();
                    frmEmp.TopLevel = false;
                    frmEmp.Visible = true;
                    tabPage1.Controls.Add(frmEmp);
                    break;
                case 2:
                    var frmWK = new frmWorkOrder3();
                    frmWK.TopLevel = false;
                    frmWK.Visible = true;
                    frmWK.Height = tabControl1.Height - 50;
                    frmWK.Width = tabControl1.Width - 50;
                    var empbtnu = frmWK.Controls.Find("frmWKbtnU", true);
                    var empbtnd = frmWK.Controls.Find("frmWKbtnD", true);
                    empbtnu[0].Location = new Point(frmWK.Width - 200, empbtnu[0].Location.Y);
                    empbtnd[0].Location = new Point(frmWK.Width - 200, empbtnd[0].Location.Y);
                    tabPage3.Controls.Add(frmWK);
                    var wk = frmWK.Controls.Find("frmWKWorkitem", false);
                    var mk = frmWK.Controls.Find("frmWKMakeno", false);
                    ActiveControl = mk[0];
                    wk[0].TextChanged += new EventHandler(gettab3);
                    Console.WriteLine(frmWK.Name);
                    break;
                case 1:
                    var frmPartner = new frmPartner();
                    frmPartner.TopLevel = false;
                    frmPartner.Visible = true;
                    frmPartner.Height = tabControl1.Height - 50;
                    frmPartner.Width = tabControl1.Width - 50;
                    var ptbtnu = frmPartner.Controls.Find("frmPTbtnU", true);
                    var ptbtnd = frmPartner.Controls.Find("frmPTbtnD", true);
                    ptbtnu[0].Location = new Point(frmPartner.Width - 200, ptbtnu[0].Location.Y);
                    ptbtnd[0].Location = new Point(frmPartner.Width - 200, ptbtnd[0].Location.Y);
                    tabPage2.Controls.Add(frmPartner);
                    var pt = frmPartner.Controls.Find("frmPTshowno", true);
                    Console.WriteLine("frpt=" + pt.Length);
                    pt[0].TextChanged += new EventHandler(gettab2);
                    break;
                case 3:
                    var frmQTY = new frmQTY();
                    frmQTY.TopLevel = false;
                    frmQTY.Visible = true;
                    frmQTY.Height = tabControl1.Height - 50;
                    frmQTY.Width = tabControl1.Width - 50;
                    var qtybtnu = frmQTY.Controls.Find("frmNumbtnU", true);
                    var qtybtnd = frmQTY.Controls.Find("frmNumbtnD", true);
                    qtybtnu[0].Location = new Point(frmQTY.Width - 200, qtybtnu[0].Location.Y);
                    qtybtnd[0].Location = new Point(frmQTY.Width - 200, qtybtnd[0].Location.Y);
                    tabPage4.Controls.Add(frmQTY);
                    var qty = frmQTY.Controls.Find("frmNumshowno", false);
                    qty[0].TextChanged += new EventHandler(gettab4);
                    var save = frmQTY.Controls.Find("save", false);
                    save[0].Click += new EventHandler(savetab);
                    var qtyfocus= frmQTY.Controls.Find("outqty",true);
                    ActiveControl = qtyfocus[0];
                    break;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.fullwidth = this.Width;
            this.fullheight = this.Height;
            this.tabpageheight = (int)(this.fullheight*0.8);
            this.tabControl1.Height = tabpageheight;
            this.tabControl1.Width = this.fullwidth - 10;

            Console.WriteLine("fw=" + fullwidth + ",fh=" + fullheight + ",ch=" +this.tabpageheight);
            var setpageup = new CreateElement();
            setpageup.SetBtn(button1, "PageUp::PageUp", "上一步");
            setpageup.SetBtn(button3, "Escape::Escape", "關閉視窗");
            setpageup.SetBtn(button2, "PageDown::Next", "下一步");
            var frmEmp = new frmEmp();
            frmEmp.TopLevel = false;
            frmEmp.Visible = true;
            frmEmp.Height = tabControl1.Height-50;
            frmEmp.Width = tabControl1.Width-50;
            var empbtnu= frmEmp.Controls.Find("frmEmpPageU", true);
            var empbtnd = frmEmp.Controls.Find("frmEmpPageD", true);
            empbtnu[0].Location = new Point(frmEmp.Width -200, empbtnu[0].Location.Y);
            empbtnd[0].Location = new Point(frmEmp.Width -200, empbtnd[0].Location.Y);
            tabPage1.Controls.Add(frmEmp);
            //tabPage1.KeyPress += new KeyPressEventHandler(mybutton_Click);
            //ActiveControl = tabPage1;
            var emp=frmEmp.Controls.Find("frmEmpshowno", false);
            //ActiveControl = emp[0];
           // FindFocusedControl(this);
            emp[0].TextChanged += new EventHandler(gettab);
           // object c = emp[0];
            // SerialPort serRec = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
            // serRec.Open();
           // openseria();
           // serialPort1.DataReceived+= delegate (object dsender, SerialDataReceivedEventArgs de)
           // { SerialPort_DataReceived(dsender, de, emp[0]); };
            openseria();

        }

        private void mybutton_Click(object sender, KeyEventArgs e)
        {
            Console.WriteLine("keycoe=" + e.KeyCode.ToString());
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
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e,Control c)
        {
            var serialPort = (SerialPort)sender;
            var data = serialPort.ReadExisting();
            var tb = tabPage1.Controls.Find("frmEmp", true);
            var tt= tabPage1.Controls.Find("frmEmpshowno", true);
            tt[0].Text = data;
            Console.WriteLine(tt[0].Name);
        }
        public void openseria() {
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

            var dataarray = data.Split(new string[] { "::" }, StringSplitOptions.None);
            if (dataarray.Length == 2)
            {
                var pkey = dataarray[1];
                Console.WriteLine("pkey=" + pkey);
                setkeymap(pkey);
            }
            if (dataarray.Length == 3)
            {
                setkeymap("XXX",data);
            }
            return data;
        }
        private void gettab(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabPage2;

            Console.WriteLine("name=" + this.tabControl1.SelectedTab.Name);

        }
        private void gettab2(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabPage3;
            Console.WriteLine("name=" + this.tabControl1.SelectedTab.Name);
        }
        private void gettab3(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabPage4;
            Console.WriteLine("name=" + this.tabControl1.SelectedTab.Name);
        }
        private void gettab4(object sender, EventArgs e)
        {
            Console.WriteLine("name=" + this.tabControl1.SelectedTab.Name);
        }
        private void savetab(object sender, EventArgs e)
        {
            var empno = tabPage1.Controls.Find("frmEmpshowno", true);
            var workorderitemId = tabPage3.Controls.Find("WKSaveWitemId", true);
            var workorderid = tabPage3.Controls.Find("WKSaveWorderId",true);
            var workid= tabPage3.Controls.Find("WKSaveWorkId", true);
            var partnerid = tabPage2.Controls.Find("PTSavePartnerId", true);
            var comqty = tabPage4.Controls.Find("outqty", true);
            var price = tabPage4.Controls.Find("price", true);
            var MakeNo = tabPage3.Controls.Find("WKSaveMakeNo", true);
            var Specification = tabPage3.Controls.Find("WKSaveSpecification", true);
            var WorkNo = tabPage3.Controls.Find("WKSaveWorkNo", true);
            var Workqty = tabPage3.Controls.Find("WKSaveWorkqty", true);
            var tenantids= tabPage3.Controls.Find("WKtenantId", true);
            var WorkName = tabPage3.Controls.Find("WKSaveWorkName", true);
            var AssetsIds = tabPage3.Controls.Find("WKAssetsId", true);
            var chkousides = tabPage4.Controls.Find("chkouside", true);
            var starttime = DateTime.Now;
            var workdate = DateTime.Today;
            var ischk =(CheckBox)chkousides[0];
            int tid = 101;
            var createempno = empno[0].Text;
            var tenantid = tenantids[0].Text;
            var pid = partnerid[0].Text;
            Guid dayreportid = Guid.NewGuid();
            Console.WriteLine("empno=" + empno[0].Text+"witenid="+workorderitemId[0].Text+",woid="+workorderid[0].Text+",workid="+workid[0].Text+",pid="+partnerid[0].Text+",qty="+comqty[0].Text+",did="+dayreportid+",won="+WorkName[0].Text+",wn="+WorkNo[0].Text+",mk="+MakeNo[0].Text+",wq="+Workqty[0].Text+",sp="+Specification[0].Text);
            string dbPath = Directory.GetCurrentDirectory()+ "\\"+"wd3.db3";
            string cnStr = "data source=" + dbPath+ ";Version=3;";
            Console.WriteLine("db=" + File.Exists(dbPath)+","+dbPath);
            if (File.Exists(dbPath))
            {
                using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                {
                    var insertScript = "INSERT INTO WorkDayReports (DayReportId,TenantId,WorkOrderId,WorkOrderItemId,WorkId,StartTime,PartnerId,EmpNo,CompleteQty,WorkQty,MakeNo,Specification,WorkName,WorkNo,Out,isupdate,AssetsId,WorkDate,Price) VALUES (@DayReportId, @TenantId, @WorkOrderId, @WorkOrderItemId, @WorkId, @StartTime, @PartnerId, @EmpNo, @CompleteQty,@WorkQty,@MakeNo,@Specification,@WorkName,@WorkNo,@Out,@isupdate,@AssetsId,@WorkDate,@Price)";
                    SQLiteCommand cmd = new SQLiteCommand(insertScript, conn);
                    cmd.Parameters.AddWithValue("@DayReportId", dayreportid.ToString());
                    cmd.Parameters.AddWithValue("@TenantId",tenantid);
                    cmd.Parameters.AddWithValue("@WorkOrderId", workorderid[0].Text);
                    cmd.Parameters.AddWithValue("@WorkOrderItemId", workorderitemId[0].Text);
                    cmd.Parameters.AddWithValue("@WorkId", workid[0].Text);
                    cmd.Parameters.AddWithValue("@StartTime", starttime);
                    cmd.Parameters.AddWithValue("@PartnerId", partnerid[0].Text);
                    cmd.Parameters.AddWithValue("@EmpNo", empno[0].Text);
                    cmd.Parameters.AddWithValue("@CompleteQty", comqty[0].Text);
                    cmd.Parameters.AddWithValue("@WorkQty", Workqty[0].Text);
                    cmd.Parameters.AddWithValue("@MakeNo", MakeNo[0].Text);
                    cmd.Parameters.AddWithValue("@WorkNo", WorkNo[0].Text);
                    cmd.Parameters.AddWithValue("@WorkName", WorkName[0].Text);
                    cmd.Parameters.AddWithValue("@Specification", Specification[0].Text);
                    cmd.Parameters.AddWithValue("@AssetsId", AssetsIds[0].Text);
                     cmd.Parameters.AddWithValue("@WorkDate", workdate);
                    cmd.Parameters.AddWithValue("@Out", true);
                    cmd.Parameters.AddWithValue("@Price", price[0].Text);
                    cmd.Parameters.AddWithValue("@isupdate", false);
                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        var savestat = tabPage4.Controls.Find("SaveStat", true);
                        savestat[0].Visible = true;
                        savestat[0].Text = "儲存成功";
                        cleardata();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }


                    if (ischk.Checked)
                    {
                        var selectScript = "SELECT * FROM WorkDayReports W WHERE  WorkDate=@WorkDate AND PartnerId=@PartnerId AND TenantId=@TenantId AND isupdate=0 ";
                        SQLiteCommand cmd2 = new SQLiteCommand(selectScript, conn);
                        cmd2.Parameters.AddWithValue("@WorkDate", workdate);
                        cmd2.Parameters.AddWithValue("@PartnerId", pid);
                        cmd2.Parameters.AddWithValue("@TenantId", tenantid);
                        var EmpNos = "";
                        var DayReportIds = "";
                        var CompleteQtys = "";
                        var WorkIds = "";
                        var WorkOrderIds = "";
                        var WorkOrderItemIds = "";
                        var AssetsIdset = "";
                        var Prices = "";
                        var i = 0;
                        using (SQLiteDataReader row = cmd2.ExecuteReader())
                        {
                            while (row.Read())
                            {
                                DayReportIds = DayReportIds+(i==0?"":",")+(row["DayReportId"] as string ?? "");
                                CompleteQtys = CompleteQtys + (i == 0 ? "" : ",") + (row["CompleteQty"] as decimal? ?? null);
                                WorkIds = WorkIds + (i == 0 ? "" : ",") + (row["WorkId"] as string ?? "");
                                WorkOrderIds = WorkOrderIds + (i == 0 ? "" : ",") + (row["WorkOrderId"] as string ?? "");
                                WorkOrderItemIds = WorkOrderItemIds + (i == 0 ? "" : ",") + (row["WorkOrderItemId"] as string ?? "");
                                EmpNos = EmpNos + (i == 0 ? "" : ",") + row["EmpNo"] as string ?? "";
                                AssetsIdset = AssetsIdset + (i == 0 ? "" : ",") + (row["AssetsId"] as string ?? "");
                                Prices = Prices + (i == 0 ? "" : ",") + (row["Price"] as decimal? ?? null);
                                i++;
                            }
                        }
                        var upwk = new API("/CHG/Main/Home/AddOutsource/", "http://").UploadServerOut(EmpNos,CompleteQtys,DayReportIds,WorkOrderIds,WorkIds,WorkOrderItemIds,AssetsIdset,Prices,createempno,tenantid, pid);
                    }
                    else
                    {
                    }

                }
            }
        }
        public static Control FindFocusedControl(Control control)
        {
            var container = control as IContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as IContainerControl;
                Console.WriteLine("con=" + control);
            }
            return control;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {

        }
        public void setkeymap(string keychar,string data="",bool isp = false, bool isbarcode = false)
        {
            var t = this.tabControl1.SelectedIndex;
            Console.WriteLine("st=" + t+",ind="+keychar);
            var keyupper = keychar.ToString();
            if (keyupper == "PageUp")
            {
                button1.PerformClick();
            }
            if (keyupper == "Next")
            {
                button2.PerformClick();
            }
            if (keyupper == "Escape")
            {
                button3.PerformClick();
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
                    for(var i = 0; i < keyarray.Length; i++)
                    {
                        if (keyarray[i] == keyupper)
                        {
                            var estr = "BTNfrmEmp" + (i + 1);
                            Console.WriteLine("ke=" + keyupper + "," + keyarray[i] + estr);
                            var tempbtn=tabPage1.Controls.Find(estr, true);
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
                var mk = tabPage3.Controls.Find("frmWKMakeno", false);
                var up = tabPage3.Controls.Find("frmWKbtnU", true);
                var down = tabPage3.Controls.Find("frmWKbtnD", true);
                var WKSaveWorderId = tabPage3.Controls.Find("WKSaveWorderId", true);
                var wkmo = tabPage3.Controls.Find("frmWKMakeno", true);
                List<Workitem> Wgetwitem = new List<Workitem>();
                if (keyupper == "Return")
                {
                    List<WorkOrderO> Wgetworkorder = new List<WorkOrderO>();
                    Wgetworkorder = new API("/CHG/Main/Home/getinfo/", "http://").GetWorkOrderO(101, wkmo[0].Text.ToUpper());
                    Guid? wid = null;
                    if (Wgetworkorder.Count > 0)
                    {
                        var labSpec = tabPage3.Controls.Find("labSpec", true);
                        var labRemark = tabPage3.Controls.Find("labRemark", true);
                        var labPName = tabPage3.Controls.Find("labPName", true);
                        var labWorkOrder = tabPage3.Controls.Find("labWorkOrder", true);
                        var labQty = tabPage3.Controls.Find("labQty", true);
                        var labUnit = tabPage3.Controls.Find("labUnit", true);
                        var labAssetsNames = tabPage3.Controls.Find("labAssetsName", true);
                        var WKAssetsIds= tabPage3.Controls.Find("WKAssetsId", true);
                        var WKtenatIds = tabPage3.Controls.Find("WKtenantId", true);
                        labSpec[0].Text = Wgetworkorder[0].Specification;
                        labRemark[0].Text = Wgetworkorder[0].Remark;
                        labPName[0].Text = Wgetworkorder[0].AssetsNo;
                        labWorkOrder[0].Text = Wgetworkorder[0].MakeNo;
                        labQty[0].Text = Wgetworkorder[0].MakeQty.ToString();
                        labUnit[0].Text = Wgetworkorder[0].UseUnits;
                        labAssetsNames[0].Text = Wgetworkorder[0].AssetsName;
                        WKAssetsIds[0].Text = Wgetworkorder[0].AssetsId.HasValue? Wgetworkorder[0].AssetsId.ToString():"";
                        WKtenatIds[0].Text = Wgetworkorder[0].TenantId.ToString();
                        wid = Wgetworkorder[0].WorkOrderId;
                        wkmo[0].Tag = wid.ToString();
                    }
                    else
                    {
                        //MessageBox.Show("無此工令資料");
                        Console.WriteLine("無此工令資料");
                    }

                    if (wid.HasValue)
                        Wgetwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem(wkmo[0].Text, (Guid)wid);
                    else
                    {
                        Console.WriteLine("輸入工令格式錯誤");
                    }
                    var WKPanels = tabPage3.Controls.Find("WKPanel", true);
                    var frmWKRecordnows = tabPage3.Controls.Find("frmWKRecordnow", true);
                    var frmWKRecordTs = tabPage3.Controls.Find("frmWKRecordT", true);
                    var frmWKRecordnow = frmWKRecordnows[0];
                    var frmWKRecordT = frmWKRecordTs[0];
                    TableLayoutPanel WKPanel = (TableLayoutPanel)WKPanels[0];
                    Int32 tlpColumCount = WKPanel.ColumnCount;
                    Int32 tlpRowCount = WKPanel.RowCount;
                    List<Button> btnemplist = new List<Button>();
                    if (Wgetwitem.Count() > 0)
                    {
                        var empitemcount = 0;
                        var keynum = 0;
                        foreach (var empitem in Wgetwitem)
                        {
                            var prestr = "BTNfrmEmp";
                            empitemcount++;
                            if ((empitemcount - 1) != 0 && (empitemcount - 1) % (tlpRowCount * tlpColumCount) == 0)
                                keynum = 0;
                            keynum++;
                            var btnkey = "F" + keynum;
                            var poststr = empitemcount.ToString("##");
                            var thisbtnname = prestr + poststr;
                            var thisbtntext = empitem.WorkName;
                            Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateWKBtn(empitem.WorkNo, thisbtntext, empitem.WorkOrderItemId, empitem.WorkId, btnkey);
                            empbtn = sethandlerW(empbtn);
                            btnemplist.Add(empbtn);
                        }
                        Console.WriteLine("btn=" + btnemplist.Count + "," + tlpColumCount + "," + tlpRowCount);
                        var j = 0;
                        var recordL = 0;
                        for (int c = WKPanel.Controls.Count - 1; c >= 0; --c)
                            WKPanel.Controls[c].Dispose();
                        WKPanel.Controls.Clear();
                        for (var i = 0; i < tlpRowCount; i += tlpColumCount)
                        {
                            for (; j < btnemplist.Count && j < tlpColumCount * tlpRowCount; j++)
                            {
                                recordL++;
                                Console.WriteLine("L-i=" + i + ",j=" + j + ",name=" + btnemplist[j].Name);
                                WKPanel.Controls.Add(btnemplist[j], j, i);
                                frmWKRecordnow.Text = j.ToString();
                            }
                        }
                        frmWKRecordT.Text = recordL.ToString();
                        Console.WriteLine("record=" + frmWKRecordnow.Text);
                    }
                }
                string[] keyarray = new string[] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10" };
                if (data == "")
                {
                    var svmk = tabPage3.Controls.Find("labWorkOrder", true);
                    //Console.WriteLine("nodata:"+ svmk[0].Text.ToUpper());
                    if (keyupper == "Delete")
                    {
                        //((Button)down[0]).PerformClick();

                        frmWKbtnD(svmk[0].Text.ToUpper(), Guid.Parse(WKSaveWorderId[0].Text));
                    }
                    if (keyupper == "Insert")
                    {
                        // ((Button)up[0]).PerformClick();
                        frmWKbtnU(svmk[0].Text.ToUpper(), Guid.Parse(WKSaveWorderId[0].Text));
                    }
                    if (keyarray.Contains(keyupper))
                    {
                        Console.WriteLine("kc");
                        for (var i = 0; i < keyarray.Length; i++)
                        {
                            if (keyarray[i] == keyupper)
                            {
                                Console.WriteLine("ke=" + keyupper + "," + keyarray[i]);
                                var estr = "BTNfrmEmp" + (i + 1);
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
                    var wup = tabPage3.Controls.Find("frmWKbtnU", true);
                    var wdown = tabPage3.Controls.Find("frmWKbtnD", true);
                    if (keyupper == "Delete")
                    {
                        ((Button)wdown[0]).PerformClick();
                    }
                    if (keyupper == "Insert")
                    {
                        ((Button)wup[0]).PerformClick();
                    }
                    if (isp)
                    {
                        var wkno = tabPage3.Controls.Find("frmWKWorkitem", true);
                        var winfo = data.Split(new string[] { "::" }, StringSplitOptions.None);
                        wkno[0].Text = winfo[0];
                    }
                    else
                    {
                        var tt = tabPage3.Controls.Find("frmWKMakeno", true);
                        tt[0].Text = data;
                        Console.WriteLine("tt=" + tt[0].Name);
                    }
                }


            }
            if (t == 1)
            {
                var up = tabPage2.Controls.Find("frmPTbtnU", true);
                var down = tabPage2.Controls.Find("frmPTbtnD", true);
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
                    var wkrec = tabPage2.Controls.Find("frmPTRecordnow", true);
                    var wkrecn = 0;
                    var tempcn = int.TryParse(wkrec[0].Text, out wkrecn);
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
                            var estr = "BTNfrmEmp" + (wkrecn * 10 + i + 1);
                            Console.WriteLine("estr=" + estr);
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

            if (t == 3)
            {
                if (keyupper == "Return")
                {
                    SendKeys.Send("{TAB}");
                }
                var save = tabPage4.Controls.Find("save", true);
                string clearkey = "Divide";
                string[] keyarray = new string[] { "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", "Decimal", "Divide" };
                if (keyupper == "S")
                {
                    ((Button)save[0]).PerformClick();
                }
                if (keyarray.Contains(keyupper))
                {
                    Console.WriteLine("kc" + "," + t);
                    for (var i = 0; i < keyarray.Length; i++)
                    {
                        if (keyarray[i] == keyupper)
                        {
                            var estr = "BTNfrmEmp" + (i + 1);
                            Console.WriteLine("ke=" + keyupper + "," + keyarray[i] + estr);
                            if (keyupper == clearkey)
                            {
                                var ft = tabPage4.Controls.Find("focust", true);
                                var numno = tabPage3.Controls.Find(ft[0].Text, true);
                                if (numno.Length > 0)
                                {
                                    numno[0].Text = "";
                                }
                            }
                            else
                            {
                                if (isbarcode)
                                {
                                    var tempbtn = tabPage3.Controls.Find(estr, true);
                                    if (tempbtn.Length > 0)
                                    {
                                        ((Button)(tempbtn[0])).PerformClick();
                                        Console.WriteLine("per:" + keychar);
                                    }
                                }
                                else
                                {

                                }
                            }

                        }
                    }
                }
            }
        }

        private void frmWKbtnU(string makeno, Guid wid)
        {
            var getwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem(makeno, wid);
            Console.WriteLine("functionU:" + getwitem.Count);
            var WKPanels = tabPage3.Controls.Find("WKPanel", true);
            var frmWKRecordnows = tabPage3.Controls.Find("frmWKRecordnow", true);
            var frmWKRecordTs = tabPage3.Controls.Find("frmWKRecordT", true);
            TableLayoutPanel WKPanel = (TableLayoutPanel)WKPanels[0];
            var frmWKRecordnow = frmWKRecordnows[0];
            var frmWKRecordT = frmWKRecordTs[0];
            Int32 tlpColumCount = WKPanel.ColumnCount;
            Int32 tlpRowCount = WKPanel.RowCount;
            List<Button> btnemplist = new List<Button>();
            int nowrecord = 0;
            int recordT = 0;
            bool trynowrecord = int.TryParse(frmWKRecordnow.Text, out nowrecord);
            bool tryrecordT = int.TryParse(frmWKRecordT.Text, out recordT);
            var looplimit = nowrecord - recordT;
            var loopinit = looplimit + 1 - (tlpColumCount * tlpRowCount);
            Console.WriteLine("u-limit=" + looplimit + ",loopinit=" + loopinit);
            if (trynowrecord && looplimit > 0)
            {
                for (int i = WKPanel.Controls.Count - 1; i >= 0; --i)
                    WKPanel.Controls[i].Dispose();
                WKPanel.Controls.Clear();
            }
            Console.WriteLine("U-nowrecord=" + nowrecord);
            if (nowrecord > 0)
            {
                Console.WriteLine("U-getemp=" + getwitem.Count());
                if (getwitem.Count() > 0)
                {
                    var empitemcount = 0;

                    var j = loopinit;
                    var recordU = 0;
                    Console.WriteLine("U-j=" + j + ",row=" + tlpRowCount + ",col=" + tlpColumCount);
                    if (j >= 0 && looplimit > 0)
                    {
                        var reali = 0;
                        Console.WriteLine("U-loop=" + loopinit + ",looplimit=" + looplimit);
                        for (var i = loopinit; i < loopinit + (tlpColumCount * tlpRowCount); i += tlpColumCount)
                        {
                            reali++;
                            var realj = 0;
                            for (; j < getwitem.Count && j < i + tlpColumCount; j++)
                            {
                                recordU++;
                                Console.WriteLine("U-i=" + i + ",j=" + j + ",name=" + getwitem[j].WorkNo + ",ri=" + reali + ",rj=" + realj);
                                var prestr = "BTNfrmEmp";
                                empitemcount++;
                                var keynum = j % (tlpColumCount * tlpRowCount) + 1;
                                var btnkey = "F" + keynum;
                                var poststr = empitemcount.ToString("##");
                                var thisbtnname = prestr + poststr;
                                var thisbtntext = getwitem[j].WorkName;
                                Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateWKBtn(getwitem[j].WorkNo, thisbtntext, getwitem[j].WorkOrderItemId, getwitem[j].WorkId, btnkey);
                                empbtn = sethandlerW(empbtn);
                                WKPanel.Controls.Add(empbtn, realj, reali - 1);
                                frmWKRecordnow.Text = j.ToString();
                                realj++;
                            }
                        }
                        frmWKRecordT.Text = recordU.ToString();

                    }

                    Console.WriteLine("record=" + frmWKRecordnow.Text);
                }
            }
        }

        private void frmWKbtnD(string makeno, Guid wid)
        {
            Console.WriteLine("makeno=" + makeno + ",w=" + wid);
            var getwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem(makeno, wid);
            Console.WriteLine("functionD:" + getwitem.Count);
            var WKPanels = tabPage3.Controls.Find("WKPanel", true);
            var frmWKRecordnows = tabPage3.Controls.Find("frmWKRecordnow", true);
            var frmWKRecordTs = tabPage3.Controls.Find("frmWKRecordT", true);
            TableLayoutPanel WKPanel = (TableLayoutPanel)WKPanels[0];
            var frmWKRecordnow = frmWKRecordnows[0];
            var frmWKRecordT = frmWKRecordTs[0];
            Int32 tlpColumCount = WKPanel.ColumnCount;
            Int32 tlpRowCount = WKPanel.RowCount;
            List<Button> btnemplist = new List<Button>();
            int nowrecord = 0;
            bool trynowrecord = int.TryParse(frmWKRecordnow.Text, out nowrecord);
            if (trynowrecord && nowrecord < getwitem.Count - 1)
            {
                for (int i = WKPanel.Controls.Count - 1; i >= 0; --i)
                    WKPanel.Controls[i].Dispose();
                WKPanel.Controls.Clear();
            }
            Console.WriteLine("D-nowrecord=" + nowrecord);
            if (nowrecord > 0)
            {
                Console.WriteLine("D-getemp=" + getwitem.Count());
                if (getwitem.Count() > 0)
                {
                    var empitemcount = 0;
                    var j = nowrecord + 1;

                    Console.WriteLine("D-j=" + j + ",row=" + tlpRowCount + ",col=" + tlpColumCount);
                    if (j > 0 && nowrecord < getwitem.Count - 1)
                    {
                        var reali = 0;
                        var recordD = 0;
                        Console.WriteLine("d-tlpRowCount=" + tlpRowCount);
                        for (var i = nowrecord + 1; i < (nowrecord + 1) + (tlpColumCount * tlpRowCount); i += tlpColumCount)
                        {
                            reali++;
                            var realj = 0;
                            for (; j < getwitem.Count && j < i + tlpColumCount; j++)
                            {
                                recordD++;
                                Console.WriteLine("D-i=" + i + ",j=" + j + ",name=" + getwitem[j].WorkNo + ",ri=" + reali + ",rj=" + realj);
                                var prestr = "BTNfrmEmp";
                                empitemcount++;
                                var keynum = j % (tlpColumCount * tlpRowCount) + 1;
                                var btnkey = "F" + keynum;
                                var poststr = empitemcount.ToString("##");
                                var thisbtnname = prestr + poststr;
                                var thisbtntext = getwitem[j].WorkName;
                                Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateWKBtn(getwitem[j].WorkNo, thisbtntext, getwitem[j].WorkOrderItemId, getwitem[j].WorkId, btnkey);
                                empbtn = sethandlerW(empbtn);
                                WKPanel.Controls.Add(empbtn, realj, reali - 1);
                                frmWKRecordnow.Text = j.ToString();
                                realj++;
                            }
                        }
                        frmWKRecordT.Text = recordD.ToString();
                    }

                    Console.WriteLine("record=" + frmWKRecordnow.Text);
                }
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
            var labUnits = tabPage3.Controls.Find("labUnit", true);
            var labAssetsNames = tabPage3.Controls.Find("labAssetsName", true);

            var WKSaveMakeNo = WKSaveMakeNos[0];
            var WKSaveSpecification = WKSaveSpecifications[0];
            var WKSaveWorkqty = WKSaveWorkqtys[0];
            var WKSaveWorderId = WKSaveWorderIds[0];
            var labWorkOrder = labWorkOrders[0];
            var labSpec = labSpecs[0];
            var labQty = labQtys[0];
            var labUnit = labUnits[0];
            var frmWKMakeno = frmWKMakenos[0];
            var frmWKWorkitem = frmWKWorkitems[0];
            var WKSaveWitemId = WKSaveWitemIds[0];
            var WKSaveWorkId = WKSaveWorkIds[0];
            var WKSaveWorkNo = WKSaveWorkNos[0];
            var WKSaveWorkName = WKSaveWorkNames[0];
            if (!isdef)
            {
                WKSaveMakeNo.Text = labWorkOrder.Text;
                WKSaveSpecification.Text = labSpec.Text;
                WKSaveWorkqty.Text = labQty.Text;
                WKSaveWorderId.Text = frmWKMakeno.Tag.ToString();
            }
            frmWKWorkitem.Text = wkno;
            WKSaveWitemId.Text = witemid;
            WKSaveWorkId.Text = workid;


            WKSaveWorkNo.Text = wkno;

            WKSaveWorkName.Text = infoarray[2];
            Console.WriteLine("wkno=" + frmWKWorkitem.Text + ",witemid=" + witemid + ",workid=" + workid + ",workorderid=" + WKSaveWorderId.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var t = this.tabControl1.SelectedIndex;
            Console.WriteLine("t=" + t);
            if (t > 0)
            {
                this.tabControl1.SelectedIndex = t-1;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var t = this.tabControl1.SelectedIndex;
            if (t < this.tabControl1.Controls.Count - 1)
            {
                this.tabControl1.SelectedIndex = t + 1;
            }
        }
        public void cleardata() {
            //num
            var nno = tabPage4.Controls.Find("frmNumshowno", true);
            //num
            //pt
            var pto = tabPage2.Controls.Find("frmPTshowno", true);
            var ptrn = tabPage2.Controls.Find("frmPTRecordnow", true);
            var ptrt = tabPage2.Controls.Find("frmPTRecordT", true);
            //pt
            //wk
            var wkn = tabPage3.Controls.Find("frmWKMakeno", true);
            var wki = tabPage3.Controls.Find("frmWKWorkitem", true);
            var wkr = tabPage3.Controls.Find("frmWKRecordnow", true);
            var wkt = tabPage3.Controls.Find("frmWKRecordT", true);
            var wksm = tabPage3.Controls.Find("WKSaveMakeNo", true);
            var wksw= tabPage3.Controls.Find("WKSaveWitemId", true);
            var wksmn = tabPage3.Controls.Find("WKSaveMNo", true);
            var wkss = tabPage3.Controls.Find("WKSaveSpecification", true);
            var wksq = tabPage3.Controls.Find("WKSaveWorkqty", true);
            var wkm = tabPage3.Controls.Find("WKSaveMakeNo", true);
            var lw = tabPage3.Controls.Find("labWorkOrder", true);
            var ln = tabPage3.Controls.Find("labPName", true);
            var ls = tabPage3.Controls.Find("labSpec", true);
            var lq = tabPage3.Controls.Find("labQty", true);
            var wktid = tabPage3.Controls.Find("WKtenantId", true);
            //wk
            //var emn = tabPage1.Controls.Find("frmEmpshowno", true); 
            var emr = tabPage1.Controls.Find("frmEmpRecordnow", true);
            var emt = tabPage1.Controls.Find("frmEmpRecordT", true);
            try
            {
                nno[0].Text = string.Empty;
                pto[0].Text = string.Empty;
                ptrn[0].Text = string.Empty;
                ptrt[0].Text = string.Empty;
                wki[0].Text = string.Empty;
                wkm[0].Text = string.Empty;
                wkn[0].Text = string.Empty;
                wkr[0].Text = string.Empty;
                wksm[0].Text = string.Empty;
                wksmn[0].Text = string.Empty;
                wksq[0].Text = string.Empty;
                wkss[0].Text = string.Empty;
                wksw[0].Text = string.Empty;
                wkt[0].Text = string.Empty;
                //emn[0].Text = string.Empty;
                emr[0].Text = string.Empty;
                emt[0].Text = string.Empty;
                ln[0].Text = string.Empty;
                lw[0].Text = string.Empty;
                ls[0].Text = string.Empty;
                lq[0].Text = string.Empty;
                wktid[0].Text = string.Empty;
            }
            catch(Exception ex)
            {
                Console.WriteLine("cleardata error:" + ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
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
    }
}
