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
    public partial class FormSTART2 : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
       // [DllImport("user32.dll", CharSet = CharSet.Auto)]
       // public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
       // public const int WM_CLOSE = 0x10;
        public FormSTART2(frmMenu fmenu)
        {
            InitializeComponent();
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
        delegate void Display(Byte[] buffer);
        public Dictionary<string, string> rtext = CreateElement.loadresx("ST");
        string lang = "";



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                lang = oTINI.getKeyValue("SYSTEM", "LANGUAGE", "");
            }
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    var frmEmp = new frmEmp2();
                    frmEmp.TopLevel = false;
                    frmEmp.Visible = true;
                    tabPage1.Controls.Add(frmEmp);
                    Console.WriteLine("1." + ActiveControl.Name);
                    break;
                case 1:
                    var frmWK = new frmWorkOrder2();
                    frmWK.TopLevel = false;
                    frmWK.Visible = true;
                    frmWK.Height = tabControl1.Height - 50;
                    frmWK.Width = tabControl1.Width - 50;
                    var empbtnu = frmWK.Controls.Find("frmWKbtnU", true);
                    var empbtnd = frmWK.Controls.Find("frmWKbtnD", true);
                    empbtnu[0].Location = new Point(frmWK.Width - 200, empbtnu[0].Location.Y);
                    empbtnd[0].Location = new Point(frmWK.Width - 200, empbtnd[0].Location.Y);
                    tabPage2.Controls.Add(frmWK);
                    var wk = frmWK.Controls.Find("frmWKWorkitem", false);

                    var mk = tabPage2.Controls.Find("frmWKMakeno", true);
                      ActiveControl = mk[0];

                    wk[0].TextChanged += new EventHandler(gettab2);
                    break;
                case 2:
                    var labUnit = tabPage2.Controls.Find("labUnit", true);
                    var initunit = labUnit[0].Text;


                    var frmWorkTime = new frmWorkTime2(initunit);
                    frmWorkTime.TopLevel = false;
                    frmWorkTime.Visible = true;
                    frmWorkTime.Height = tabControl1.Height - 50;
                    frmWorkTime.Width = tabControl1.Width - 50;
                    tabPage3.Controls.Add(frmWorkTime);

                    var rp = tabPage3.Controls.Find("RPanel", true);
                    TableLayoutPanel rpc = null;
                    if (rp.Length > 0)
                    {
                        rpc = (TableLayoutPanel)rp[0];
                        if (rp[0].Controls.Count > 0)
                        {
                            for (int i = rp[0].Controls.Count - 1; i >= 0; --i)
                                rp[0].Controls[i].Dispose();
                            rp[0].Controls.Clear();
                        }

                    }
                    var tableheadstr = new string[] { };
                    var textarray = new string[] { };
                    if (initunit == "Set")
                    {

                        tableheadstr = new string[] { rtext["worktime"], "Go" + rtext["completeqty"], "NoGo" + rtext["completeqty"], "Go" + rtext["badqty"], "NoGo" + rtext["badqty"] };
                        textarray = new string[] { "WorkTime", "GoCompleteQty", "NoGoCompleteQty", "GoBadQty", "NoGoBadQty" };

                    }
                    else
                    {
                        tableheadstr = new string[] { rtext["worktime"], rtext["completeqty"], rtext["badqty"], };
                        textarray = new string[] { "WorkTime", "CompleteQty", "BadQty" };
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
                            if(textarray[a] == "NoGoCompleteQty" || textarray[a] == "NoGoBadQty")
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
                        rpc.Controls.Add(templab, a, 0);
                        TextBox numbox = new TextBox();
                        numbox.Name = textarray[a];
                        if(textarray[a].ToLower().Contains("bad"))
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
                        rpc.Controls.Add(numbox, a, 1);
                    }


                    var st2 = tabPage3.Controls.Find("WorkTime", true);
                    ActiveControl = st2[0];
                    var wtbqty = frmWorkTime.Controls.Find("frmNumshowno", false);
                    Showinformation();
                    var ocq = tabPage3.Controls.Find("CompleteQty", true);
                    var obq = tabPage3.Controls.Find("BadQty", true);
                    var ogcq = tabPage3.Controls.Find("GoCompleteQty", true);
                    var ognq = tabPage3.Controls.Find("NoGoCompleteQty", true);
                    var obcq = tabPage3.Controls.Find("GoBadQty", true);
                    var obnq = tabPage3.Controls.Find("NoGoBadQty", true);
                    var owt = tabPage3.Controls.Find("WorkTime", true);
                    if (ocq.Length > 0)
                    {
                      ocq[0].TextChanged+= new EventHandler(getinform);
                        obq[0].TextChanged += new EventHandler(getinform);
                        owt[0].TextChanged += new EventHandler(getinform);
                    }
                    if (ogcq.Length > 0)
                    {
                        ogcq[0].TextChanged += new EventHandler(getinform);
                        ognq[0].TextChanged += new EventHandler(getinform);
                        obcq[0].TextChanged += new EventHandler(getinform);
                        obnq[0].TextChanged += new EventHandler(getinform);
                        owt[0].TextChanged += new EventHandler(getinform);
                    }
                    var save = frmWorkTime.Controls.Find("save", true);
                    save[0].Click += new EventHandler(savetab);
                    // wtbqty[0].TextChanged += new EventHandler(gettab3);
                    break;
                case 3:

                case 4:
                  /*  var frmQTY = new frmQTY2();
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
                    save[0].Click += new EventHandler(savetab);
                   */
                    break;
            }
        }

        private void FormSTART_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.fullwidth = this.Width;
            this.fullheight = this.Height;
            this.tabpageheight = (int)(this.fullheight * 0.8);
            this.tabControl1.Height = tabpageheight;
            this.tabControl1.Width = this.fullwidth - 10;
            this.tabPage1.Text = rtext[tabPage1.Name];
            this.tabPage2.Text = rtext[tabPage2.Name];
            this.tabPage3.Text = rtext[tabPage3.Name];
            Console.WriteLine("fw=" + fullwidth + ",fh=" + fullheight + ",ch=" + this.tabpageheight);
            var setpageup = new CreateElement();           
            setpageup.SetBtn(button1, "PageUp::PageUp", rtext[button1.Name]);
            setpageup.SetBtn(button2, "PageDown::Next", rtext[button2.Name]);
            setpageup.SetBtn(button3, "Home::Home", rtext[button3.Name]);
            setpageup.SetBtn2(button4, "Escape::Escape", rtext[button4.Name]);
            var frmEmp = new frmEmp2();
            frmEmp.TopLevel = false;
            frmEmp.Visible = true;
            frmEmp.Height = tabControl1.Height - 50;
            frmEmp.Width = tabControl1.Width - 50;
            var empbtnu = frmEmp.Controls.Find("frmEmpPageU", true);
            var empbtnd = frmEmp.Controls.Find("frmEmpPageD", true);
            empbtnu[0].Location = new Point(frmEmp.Width - 200, empbtnu[0].Location.Y);
            empbtnd[0].Location = new Point(frmEmp.Width - 200, empbtnd[0].Location.Y);
            tabPage1.Controls.Add(frmEmp);
            //tabPage1.KeyPress += new KeyPressEventHandler(mybutton_Click);
            //ActiveControl = tabPage1;
            var emp = frmEmp.Controls.Find("frmEmpshowno", false);
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
                setkeymap(pkey,"",false,true);
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
            var gempo = tabPage1.Controls.Find("frmEmpshowno", true);
            if (gempo[0].Text == "")
            {
                this.tabControl1.SelectedTab = tabPage1;
            }
            else
            {
                this.tabControl1.SelectedTab = tabPage2;
            }
            

            Console.WriteLine("tab1 name=" + this.tabControl1.SelectedTab.Name+","+ gempo[0].Text);

        }
        private void gettab2(object sender, EventArgs e)
        {
            var gmkno = tabPage2.Controls.Find("frmWKMakeno", true); 
            var gwk = tabPage2.Controls.Find("frmWKWorkitem", true);
            if (gmkno[0].Text == ""&& gwk[0].Text!="")
            {
                this.tabControl1.SelectedTab = tabPage3;
                Console.WriteLine("tab=2");
            }
            else
            {
                this.tabControl1.SelectedTab = tabPage3;
            }

            Console.WriteLine("tab2 name=" + this.tabControl1.SelectedTab.Name + "," + gmkno[0].Text);
        }
        private void gettab3(object sender, EventArgs e)
        {
            // this.tabControl1.SelectedTab = tabPage4;
            Console.WriteLine("tab3 name=" + this.tabControl1.SelectedTab.Name );
        }

        private void getinform(object sender, EventArgs e)
        {
            Showinformation();
        }
        private void gettab4(object sender, EventArgs e)
        {
            Showinformation();
            Console.WriteLine("tab4 name=" + this.tabControl1.SelectedTab.Name );
        }   
        private void savetab(object sender, EventArgs e)
        {
            var s = new saving();
            s.Show();
            var empno = tabPage1.Controls.Find("frmEmpshowno", true);
            var workorderitemId = tabPage2.Controls.Find("WKSaveWitemId", true);
            var workorderid = tabPage2.Controls.Find("WKSaveWorderId", true);
            var workid = tabPage2.Controls.Find("WKSaveWorkId", true);
            var unit=  tabPage2.Controls.Find("labUnit", true); 
            var assetsname = tabPage2.Controls.Find("labAssetsName", true);
            // var bqty = tabPage4.Controls.Find("frmNumshowno", true);
            // var comqty = tabPage5.Controls.Find("frmNumshowno", true);
            var MakeNo = tabPage2.Controls.Find("WKSaveMakeNo", true);
            var Specification = tabPage2.Controls.Find("WKSaveSpecification", true);
            var WorkNo = tabPage2.Controls.Find("WKSaveWorkNo", true);
            var Workqty = tabPage2.Controls.Find("WKSaveWorkqty", true);
            var WorkName = tabPage2.Controls.Find("WKSaveWorkName", true);
            var WKSaveTenantId = tabPage2.Controls.Find("WKSaveTenantId", true);
            var ocq = tabPage3.Controls.Find("CompleteQty", true);
            var obq = tabPage3.Controls.Find("BadQty", true);
            var ogcq = tabPage3.Controls.Find("GoCompleteQty", true);
            var ognq = tabPage3.Controls.Find("NoGoCompleteQty", true);
            var obcq = tabPage3.Controls.Find("GoBadQty", true);
            var obnq = tabPage3.Controls.Find("NoGoBadQty", true);
            var owt = tabPage3.Controls.Find("WorkTime", true);
            var starttime = DateTime.Now;
            var workdate = starttime.ToString("yyyy-MM-dd");
            var smakeno = MakeNo[0].Text;
            string[] notincludelist = new string[] { "D16" };
            int tid = 0;
            int.TryParse(WKSaveTenantId[0].Text, out tid);
            Guid dayreportid = Guid.NewGuid();
          //  Console.WriteLine("empno=" + empno[0].Text + "witenid=" + workorderitemId[0].Text + ",woid=" + workorderid[0].Text + ",workid=" + workid[0].Text + ",bqty=" + bqty[0].Text + ",qty=" + comqty[0].Text + ",did=" + dayreportid + ",won=" + WorkName[0].Text + ",wn=" + WorkNo[0].Text + ",mk=" + MakeNo[0].Text + ",wq=" + Workqty[0].Text + ",sp=" + Specification[0].Text);
            string dbPath = Directory.GetCurrentDirectory() + "\\" + "wd2.db3";
            string cnStr = "data source=" + dbPath + ";Version=3;";
            decimal bqty=0;
            decimal cqty = 0;
            decimal cgqty = 0;
            decimal cnqty = 0;
            decimal bgqty = 0;
            decimal bnqty = 0;
            if (ocq.Length > 0)
            {
                decimal.TryParse( ocq[0].Text,out cqty);
                decimal.TryParse(obq[0].Text, out bqty);
            }
            if (ogcq.Length > 0)
            {
                decimal.TryParse(ogcq[0].Text, out cgqty);
                decimal.TryParse(ognq[0].Text, out cnqty);
                decimal.TryParse(obcq[0].Text, out bgqty);
                decimal.TryParse(obnq[0].Text, out bnqty);
                if (notincludelist.Contains(WorkNo[0].Text))
                {
                    cqty = cgqty + cnqty;
                    bqty = bgqty + bnqty;
                }
                else
                {
                    if (cgqty > 0 || cnqty > 0)
                    {
                        cqty = (cgqty + cnqty) / 2;
                    }
                    if (bgqty > 0 || bnqty > 0)
                    {
                        bqty = (bgqty + bnqty) / 2;
                    }
                }

            }
           // decimal.TryParse(comqty[0].Text, out cqtyt);
            decimal worktime = 0;
            decimal.TryParse(owt[0].Text, out worktime);
            var eno = empno[0].Text.Contains(":") ? empno[0].Text.Split(':').First() : empno[0].Text;
            var ena= empno[0].Text.Contains(":") ? empno[0].Text.Split(':').ElementAt(1) : "";
            Console.WriteLine("db=" + File.Exists(dbPath) + "," + dbPath);
            var wdritem=new WorkDayReport() {
                EmployeeId = "",
                AdjustTime = null,
                BadQty = bqty,
                CompleteQty = cqty,
                CompletGoQty = cgqty,
                CompletNgQty = cnqty,
                BadGoQty = bgqty,
                BadNgQty = bnqty,
                DayReportId = dayreportid.ToString(),
                EmpNo = eno,
                EndTime = null,
                MakeNo = MakeNo[0].Text,
                MNo = "",
                Specification = "",
                WorkNo = "",
                StartTime = starttime,
                TenantId =tid ,
                WorkDate = workdate,
                WorkId = workid[0].Text,
                WorkName = "",
                WorkOrderId =workorderid[0].Text ,
                WorkOrderItemId = workorderitemId[0].Text,
                WorkQty = null,
                WorkTime =worktime,
            };
            if (File.Exists(dbPath))
            {
                using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                {
                    var insertScript = "INSERT INTO WorkDayReports (DayReportId,TenantId,WorkOrderId,WorkOrderItemId,WorkId,StartTime,BadQty,EmpNo,EndTime,"+
                        "CompleteQty,WorkQty,MakeNo,Specification,WorkName,WorkNo,WorkTime,WorkDate,Out,isupdate,AssetsName,CompletGoQty,CompletNgQty,BadGoQty,BadNgQty,Unit)" + 
                        " VALUES (@DayReportId,@TenantId,@WorkOrderId,@WorkOrderItemId,@WorkId,@StartTime,@BadQty,@EmpNo,@EndTime,"+
                        "@CompleteQty,@WorkQty,@MakeNo,@Specification,@WorkName,@WorkNo,@WorkTime,@WorkDate,@Out,@isupdate,@AssetsName,@CompletGoQty,@CompletNgQty,@BadGoQty,@BadNgQty,@Unit)";
                    SQLiteCommand cmd = new SQLiteCommand(insertScript, conn);
                    cmd.Parameters.AddWithValue("@DayReportId", dayreportid.ToString());
                    cmd.Parameters.AddWithValue("@TenantId", tid);
                    cmd.Parameters.AddWithValue("@WorkOrderId", workorderid[0].Text);
                    cmd.Parameters.AddWithValue("@WorkOrderItemId", workorderitemId[0].Text);
                    cmd.Parameters.AddWithValue("@WorkId", workid[0].Text);
                    cmd.Parameters.AddWithValue("@StartTime", starttime);
                    cmd.Parameters.AddWithValue("@BadQty", bqty);
                    cmd.Parameters.AddWithValue("@EmpNo", eno);
                    cmd.Parameters.AddWithValue("@CompleteQty", cqty);
                    cmd.Parameters.AddWithValue("@WorkQty", Workqty[0].Text);
                    cmd.Parameters.AddWithValue("@MakeNo", MakeNo[0].Text);
                    cmd.Parameters.AddWithValue("@WorkNo", WorkNo[0].Text);
                    cmd.Parameters.AddWithValue("@WorkName", WorkName[0].Text);
                    cmd.Parameters.AddWithValue("@WorkDate", workdate);
                    cmd.Parameters.AddWithValue("@Specification", Specification[0].Text);
                    cmd.Parameters.AddWithValue("@WorkTime",worktime);
                    cmd.Parameters.AddWithValue("@Out", false);
                    cmd.Parameters.AddWithValue("@isupdate", false);
                    cmd.Parameters.AddWithValue("@AssetsName", assetsname[0].Text);
                    cmd.Parameters.AddWithValue("@CompletGoQty", cgqty);
                    cmd.Parameters.AddWithValue("@CompletNgQty", cnqty);
                    cmd.Parameters.AddWithValue("@BadGoQty", bgqty);
                    cmd.Parameters.AddWithValue("@BadNgQty", bnqty);
                    cmd.Parameters.AddWithValue("@Unit", unit[0].Text);
                    cmd.Parameters.AddWithValue("@EndTime", starttime);
                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        //   var savestat = tabPage5.Controls.Find("SaveStat", true);
                        //   savestat[0].Visible = true;
                        //  savestat[0].Text = "儲存成功";                       
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
                            updatecmd.Parameters.AddWithValue("@DayReportId", dayreportid);
                            updatecmd.Parameters.AddWithValue("@error", up.ermsg);
                            updatecmd.ExecuteNonQuery();
                            MessageBox.Show(up.ermsg);
                        }
                        Console.WriteLine("up="+up);
                         cleardata(false);
                        tabControl1.SelectedIndex = 1;
                      //  savestat[0].Visible = false;

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    conn.Close();
                }
            }
            s.Close();
            // tabControl1.SelectedTab = tabPage2;
            var ititle = tabPage2.Controls.Find("infotitle", true);
            var teno = tabPage2.Controls.Find("infoempno", true);
            var tena = tabPage2.Controls.Find("infoempname", true); 
            var twno = tabPage2.Controls.Find("infowkno", true);
            var twna = tabPage2.Controls.Find("infowkname", true);
            ititle[0].ForeColor = Color.MediumSeaGreen;
            ititle[0].Font = new Font("", 16, FontStyle.Bold);
            teno[0].Text = eno;
            tena[0].Text = ena;
            twno[0].Text = smakeno;
            twna[0].Text = WorkNo[0].Text;
        }

        public void cleardata(bool finish)
        {
            //bnum
           // var bno = tabPage4.Controls.Find("frmNumshowno", true);
            //bnum

            //num
            var msgemp = tabPage3.Controls.Find("msgemp", true);
            var msgmkno = tabPage3.Controls.Find("msgmkno", true);
            var msgwork = tabPage3.Controls.Find("msgwork", true);
            var msgcomplet = tabPage3.Controls.Find("msgcomplet", true);
            var msgbad = tabPage3.Controls.Find("msgbad", true);
            var msgworktime = tabPage3.Controls.Find("msgworktime", true);
            //num

            //worktime
            var wt = tabPage3.Controls.Find("frmNumshowno", true);
            //worktime
            //wk
            var wkn = tabPage2.Controls.Find("frmWKMakeno", true);
            var wki = tabPage2.Controls.Find("frmWKWorkitem", true);
            var wkr = tabPage2.Controls.Find("frmWKRecordnow", true);
            var wkt = tabPage2.Controls.Find("frmWKRecordT", true);
            var wksm = tabPage2.Controls.Find("WKSaveMakeNo", true);
            var wksw = tabPage2.Controls.Find("WKSaveWitemId", true);
            var wksmn = tabPage2.Controls.Find("WKSaveMNo", true);
            var wkss = tabPage2.Controls.Find("WKSaveSpecification", true);
            var wksq = tabPage2.Controls.Find("WKSaveWorkqty", true);
            var wkm = tabPage2.Controls.Find("WKSaveMakeNo", true);
            var lw = tabPage2.Controls.Find("labWorkOrder", true);
            var ln = tabPage2.Controls.Find("labPName", true);
            var ls = tabPage2.Controls.Find("labSpec", true);
            var lq = tabPage2.Controls.Find("labQty", true);
            var lu =tabPage2.Controls.Find("labUnit", true); 
            var la = tabPage2.Controls.Find("labAssetsName", true);
            var rp = tabPage3.Controls.Find("RPanel", true);
            //wk
            try
            {
                //  nno[0].Text = string.Empty;
                // bno[0].Text = string.Empty;

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
                wkn[0].Tag = string.Empty;
                lu[0].Text = string.Empty;
                la[0].Text = string.Empty;

                ln[0].Text = string.Empty;
                lw[0].Text = string.Empty;
                ls[0].Text = string.Empty;
                lq[0].Text = string.Empty;

                msgemp[0].Text = string.Empty;
                msgmkno[0].Text = string.Empty;
                msgwork[0].Text = string.Empty;
                msgcomplet[0].Text = string.Empty;
                msgbad[0].Text = string.Empty;
                msgworktime[0].Text = string.Empty;
                if (finish)
                {
                    var emn = tabPage1.Controls.Find("frmEmpshowno", true);
                    // var emr = tabPage1.Controls.Find("frmEmpRecordnow", true);
                    //var emt = tabPage1.Controls.Find("frmEmpRecordT", true);           
                    emn[0].Text = string.Empty;
                    //emr[0].Text = string.Empty;
                    //emt[0].Text = string.Empty;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("clear fail:" + ex.Message);
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

        public void setkeymap(string keychar, string data = "",bool isp=false,bool isbarcode=false)
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
                if (isp)
                {
                   var saveno= tabPage1.Controls.Find("frmEmpshowno", true);
                   var infoarray = data.Split(new string[] { "::" }, StringSplitOptions.None);
                    saveno[0].Text = infoarray[0];
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
                                    ((Button)(tempbtn[0])).PerformClick();
                                    Console.WriteLine("per:" + keychar);
                                }
                            }
                        }
                    }
                }

            }
            if (t == 1)
            {
                var mk = tabPage2.Controls.Find("frmWKMakeno", false);
                var up = tabPage2.Controls.Find("frmWKbtnU", true);
                var down = tabPage2.Controls.Find("frmWKbtnD", true);
                var WKSaveWorderId = tabPage2.Controls.Find("WKSaveWorderId", true);
                 var wkmo = tabPage2.Controls.Find("frmWKMakeno", true);
                List<Workitem> Wgetwitem = new List<Workitem>();
                if (keyupper == "Return")
                {                  
                    List<WorkOrder> Wgetworkorder = new List<WorkOrder>();
                    Wgetworkorder = new API("/CHG/Main/Home/getinfo/", "http://").GetWorkOrder(101, wkmo[0].Text.ToUpper());
                    Guid? wid = null;
                    var tidval = 0;
                    if (Wgetworkorder.Count > 0)
                    {
                        var labSpec = tabPage2.Controls.Find("labSpec", true);
                        var labRemark = tabPage2.Controls.Find("labRemark", true);
                        var labPName = tabPage2.Controls.Find("labPName", true);
                        var labWorkOrder = tabPage2.Controls.Find("labWorkOrder", true);
                        var labQty = tabPage2.Controls.Find("labQty", true);
                        var labUnit = tabPage2.Controls.Find("labUnit", true);
                        var labAssetsNames = tabPage2.Controls.Find("labAssetsName", true);
                        var labWKSaveTenantId = tabPage2.Controls.Find("WKSaveTenantId", true);
                        labSpec[0].Text = Wgetworkorder[0].Specification;
                        labRemark[0].Text = Wgetworkorder[0].Remark;
                        labPName[0].Text = Wgetworkorder[0].AssetsNo;
                        labWorkOrder[0].Text = Wgetworkorder[0].MakeNo;
                        labQty[0].Text = Wgetworkorder[0].MakeQty.ToString();
                        labUnit[0].Text = Wgetworkorder[0].UseUnits;
                        labAssetsNames[0].Text = Wgetworkorder[0].AssetsName;
                        labWKSaveTenantId[0].Text = Wgetworkorder[0].TenantId.ToString();
                        int.TryParse(labWKSaveTenantId[0].Text, out tidval);
                        wid = Wgetworkorder[0].WorkOrderId;
                        wkmo[0].Tag = wid.ToString();
                    }
                    else
                    {
                        //MessageBox.Show("無此工令資料");
                        Console.WriteLine("無此工令資料");
                    }

                    if (wid.HasValue)
                        Wgetwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem(tidval,wkmo[0].Text,(Guid)wid);
                    else
                    {
                        Console.WriteLine("輸入工令格式錯誤");
                    }
                    var WKPanels = tabPage2.Controls.Find("WKPanel", true); 
                    var frmWKRecordnows = tabPage2.Controls.Find("frmWKRecordnow", true);
                    var frmWKRecordTs = tabPage2.Controls.Find("frmWKRecordT", true);
                    var frmWKRecordnow = frmWKRecordnows[0];
                    var frmWKRecordT = frmWKRecordTs[0];
                    TableLayoutPanel WKPanel =(TableLayoutPanel) WKPanels[0];
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
                    var labWKSaveTenantId = tabPage2.Controls.Find("WKSaveTenantId", true);
                    var tid = 0;
                    int.TryParse(labWKSaveTenantId[0].Text, out tid);
                    var svmk = tabPage2.Controls.Find("labWorkOrder", true);
                    //Console.WriteLine("nodata:"+ svmk[0].Text.ToUpper());
                    if (keyupper == "Delete")
                    {
                        //((Button)down[0]).PerformClick();

                        frmWKbtnD(tid,svmk[0].Text.ToUpper(),Guid.Parse(WKSaveWorderId[0].Text));
                    }
                    if (keyupper == "Insert")
                    {
                        // ((Button)up[0]).PerformClick();
                        frmWKbtnU(tid,svmk[0].Text.ToUpper(), Guid.Parse(WKSaveWorderId[0].Text));
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
                else
                {
                    Console.WriteLine("hasdata");
                    var wup = tabPage2.Controls.Find("frmWKbtnU", true);
                    var wdown = tabPage2.Controls.Find("frmWKbtnD", true);
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
                        var wkno = tabPage2.Controls.Find("frmWKWorkitem", true);
                        var winfo=data.Split(new string[] { "::" }, StringSplitOptions.None);
                        wkno[0].Text = winfo[0];
                    }
                    else
                    {
                        var tt = tabPage2.Controls.Find("frmWKMakeno", true);
                        tt[0].Text = data;
                        Console.WriteLine("tt=" + tt[0].Name);
                    }                    
                }

            }
            if (t == 2)
            {
                if (keyupper == "Return")
                {
                    SendKeys.Send("{TAB}");
                }
                if (keyupper == "F12")
                {
                    var save= tabPage3.Controls.Find("save", true);
                    ((Button)save[0]).PerformClick();
                }
                string clearkey = "Divide";
                string[] keyarray = new string[] { "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", "Decimal","Divide" };
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
                        Console.WriteLine("kc"+","+t);
                        for (var i = 0; i < keyarray.Length; i++)
                        {
                            if (keyarray[i] == keyupper)
                            {
                                var estr = "BTNfrmEmp" + (i + 1);
                                Console.WriteLine("ke=" + keyupper + "," + keyarray[i] + estr);
                                if(keyupper== clearkey)
                                {
                                    var ft= tabPage3.Controls.Find("focust", true);
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
            if (t == 3)
            {

            }
            if (t == 4)
            {
              /*  string clearkey = "Divide";
                var save = tabPage5.Controls.Find("save", true);
                string[] keyarray = new string[] { "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", "Decimal", "Divide" };
                if (keyupper == "Insert"||keyupper=="Return")
                {
                     ((Button)save[0]).PerformClick();
                    tabControl1.SelectTab(1);
                }
                if (isp)
                {
                    var wkno = tabPage5.Controls.Find("frmNumshowno", true);
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
                                    var numno5 = tabPage5.Controls.Find("frmNumshowno", true);
                                    if (numno5.Length > 0)
                                    {
                                        numno5[0].Text = "";
                                    }
                                }
                                else
                                {
                                    var tempbtn = tabPage5.Controls.Find(estr, true);
                                    if (tempbtn.Length > 0)
                                    {
                                        ((Button)(tempbtn[0])).PerformClick();
                                        Console.WriteLine("per:" + keychar);
                                    }
                                }

                            }
                        }
                    }
                }*/

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
            var WKSaveMakeNos = tabPage2.Controls.Find("WKSaveMakeNo", true);
            var WKSaveSpecifications = tabPage2.Controls.Find("WKSaveSpecification", true);
            var WKSaveWorkqtys = tabPage2.Controls.Find("WKSaveWorkqty", true);
            var WKSaveWorderIds = tabPage2.Controls.Find("WKSaveWorderId", true);
            var labWorkOrders = tabPage2.Controls.Find("labWorkOrder", true);
            var labSpecs = tabPage2.Controls.Find("labSpec", true);
            var labQtys = tabPage2.Controls.Find("labQty", true);
            var frmWKMakenos = tabPage2.Controls.Find("frmWKMakeno", true);
            var frmWKWorkitems = tabPage2.Controls.Find("frmWKWorkitem", true);
            var WKSaveWitemIds = tabPage2.Controls.Find("WKSaveWitemId", true);
            var WKSaveWorkIds = tabPage2.Controls.Find("WKSaveWorkId", true);
            var WKSaveWorkNos = tabPage2.Controls.Find("WKSaveWorkNo", true);
            var WKSaveWorkNames = tabPage2.Controls.Find("WKSaveWorkName", true);
            var labUnits = tabPage2.Controls.Find("labUnit", true);
            var labAssetsNames = tabPage2.Controls.Find("labAssetsName", true);

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

        private void FormSTART_FormClosed(object sender, FormClosedEventArgs e)
        {
            tempclose();
        }
        private void Showinformation()
        {
            var msgemp= tabPage3.Controls.Find("msgemp", true);
            var msgmkno = tabPage3.Controls.Find("msgmkno", true);
            var msgwork = tabPage3.Controls.Find("msgwork", true);
            var msgcomplet = tabPage3.Controls.Find("msgcomplet", true);
            var msgbad = tabPage3.Controls.Find("msgbad", true);
            var msgworktime = tabPage3.Controls.Find("msgworktime", true);

            var oemp = tabPage1.Controls.Find("frmEmpshowno",true);
            var omkno = tabPage2.Controls.Find("WKSaveMakeNo", true);
            var owkn = tabPage2.Controls.Find("WKSaveWorkName", true);
            var owkno = tabPage2.Controls.Find("WKSaveWorkNo", true);
            var owko = tabPage2.Controls.Find("frmWKWorkitem", true);
            var ocq = tabPage3.Controls.Find("CompleteQty", true);
            var obq = tabPage3.Controls.Find("BadQty", true);
            var ogcq = tabPage3.Controls.Find("GoCompleteQty", true);
            var ognq = tabPage3.Controls.Find("NoGoCompleteQty", true);
            var obcq = tabPage3.Controls.Find("GoBadQty", true);
            var obnq = tabPage3.Controls.Find("NoGoBadQty", true);
            var owt = tabPage3.Controls.Find("WorkTime", true);
            string[] notincludelist = new string[] { "D16" };
            try
            {
                if (oemp.Length > 0)
                {
                    msgemp[0].Text = oemp[0].Text;
                }
                if (omkno.Length > 0)
                {
                    msgmkno[0].Text = omkno[0].Text;
                }
                if (owko.Length > 0 && owkn.Length>0)
                {
                    msgwork[0].Text = owko[0].Text+ " "+owkn[0].Text;
                }
                if (owt.Length > 0)
                {
                    msgworktime[0].Text = owt[0].Text;
                }
                if (ocq.Length > 0)
                {
                    msgcomplet[0].Text = ocq[0].Text;
                }
                if (obq.Length > 0)
                {
                    msgbad[0].Text = obq[0].Text;
                }
                if (ogcq.Length > 0&&ognq.Length>0)
                {
                    var cq = 0m;
                    var nq = 0m;
                    var tq = 0m;
                    decimal.TryParse(ogcq[0].Text, out cq);
                    decimal.TryParse(ognq[0].Text, out nq);
                    if (cq > 0 || nq > 0)
                    {
                        if (notincludelist.Contains(owkno[0].Text))
                        {
                            tq = cq + nq;
                        }
                        else
                        {
                            tq = (cq + nq) / 2;
                        }

                    }
                    msgcomplet[0].Text = tq.ToString();
                }
                if (obcq.Length > 0 && obnq.Length > 0)
                {
                    var bcq = 0m;
                    var bnq = 0m;
                    var btq = 0m;
                    decimal.TryParse(obcq[0].Text, out bcq);
                    decimal.TryParse(obnq[0].Text, out bnq);
                    if (bcq > 0 || bnq > 0)
                    {
                        if (notincludelist.Contains(owkno[0].Text))
                        {
                            btq = bcq + bnq;
                        }
                        else
                        {
                            btq = (bcq + bnq) / 2;
                        }

                    }
                    msgbad[0].Text = btq.ToString();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("顯示物件error:" + ex);
            }
            

        }

        private void frmWKbtnU(int tid,string makeno, Guid wid)
        {
            var getwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem(tid,makeno, wid);
            Console.WriteLine("functionU:" + getwitem.Count);
            var WKPanels = tabPage2.Controls.Find("WKPanel", true);
            var frmWKRecordnows = tabPage2.Controls.Find("frmWKRecordnow", true);
            var frmWKRecordTs = tabPage2.Controls.Find("frmWKRecordT", true);
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

        private void frmWKbtnD(int tid, string makeno,Guid wid)
        {
            Console.WriteLine("makeno=" + makeno + ",w=" + wid);
            var getwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem(tid,makeno, wid);
            Console.WriteLine("functionD:" + getwitem.Count);
            var WKPanels = tabPage2.Controls.Find("WKPanel", true);
            var frmWKRecordnows = tabPage2.Controls.Find("frmWKRecordnow", true);
            var frmWKRecordTs = tabPage2.Controls.Find("frmWKRecordT", true);
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

        private void BtnGotfocus(object sender, EventArgs e)
        {
            TextBox tmpButton = (TextBox)sender;
            var ft = tabPage3.Controls.Find("focust", true);
            ft[0].Text = tmpButton.Name;
            Console.Write("gotfocus=" + ft[0].Text);
        }
    }
}
