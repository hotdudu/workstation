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
                case 1:
                    var frmWK = new frmWorkOrder();
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
                    var mk = frmWK.Controls.Find("frmWKMakeno", false);
                    ActiveControl = mk[0];
                    wk[0].TextChanged += new EventHandler(gettab2);
                    Console.WriteLine(frmWK.Name);
                    break;
                case 2:
                    var frmPartner = new frmPartner();
                    frmPartner.TopLevel = false;
                    frmPartner.Visible = true;
                    frmPartner.Height = tabControl1.Height - 50;
                    frmPartner.Width = tabControl1.Width - 50;
                    var ptbtnu = frmPartner.Controls.Find("frmPTbtnU", true);
                    var ptbtnd = frmPartner.Controls.Find("frmPTbtnD", true);
                    ptbtnu[0].Location = new Point(frmPartner.Width - 200, ptbtnu[0].Location.Y);
                    ptbtnd[0].Location = new Point(frmPartner.Width - 200, ptbtnd[0].Location.Y);
                    tabPage3.Controls.Add(frmPartner);
                    var pt = frmPartner.Controls.Find("frmPTshowno", true);
                    Console.WriteLine("frpt=" + pt.Length);
                    pt[0].TextChanged += new EventHandler(gettab3);
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
                serialPort1.Open();
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
            var workorderitemId = tabPage2.Controls.Find("WKSaveWitemId", true);
            var workorderid = tabPage2.Controls.Find("WKSaveWorderId",true);
            var workid= tabPage2.Controls.Find("WKSaveWorkId", true);
            var partnerid = tabPage3.Controls.Find("PTSavePartnerId", true);
            var comqty = tabPage4.Controls.Find("frmNumshowno", true);
            var MakeNo = tabPage2.Controls.Find("WKSaveMakeNo", true);
            var Specification = tabPage2.Controls.Find("WKSaveSpecification", true);
            var WorkNo = tabPage2.Controls.Find("WKSaveWorkNo", true);
            var Workqty = tabPage2.Controls.Find("WKSaveWorkqty", true);
            var WorkName = tabPage2.Controls.Find("WKSaveWorkName", true);
            var starttime = DateTime.Now;
            int tid = 101;
            Guid dayreportid = Guid.NewGuid();
            Console.WriteLine("empno=" + empno[0].Text+"witenid="+workorderitemId[0].Text+",woid="+workorderid[0].Text+",workid="+workid[0].Text+",pid="+partnerid[0].Text+",qty="+comqty[0].Text+",did="+dayreportid+",won="+WorkName[0].Text+",wn="+WorkNo[0].Text+",mk="+MakeNo[0].Text+",wq="+Workqty[0].Text+",sp="+Specification[0].Text);
            string dbPath = Directory.GetCurrentDirectory()+ "\\"+"wd2.db3";
            string cnStr = "data source=" + dbPath+ ";Version=3;";
            Console.WriteLine("db=" + File.Exists(dbPath)+","+dbPath);
            if (File.Exists(dbPath))
            {
                using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                {
                    var insertScript = "INSERT INTO WorkDayReports (DayReportId,TenantId,WorkOrderId,WorkOrderItemId,WorkId,StartTime,PartnerId,EmpNo,CompleteQty,WorkQty,MakeNo,Specification,WorkName,WorkNo) VALUES (@DayReportId, @TenantId, @WorkOrderId, @WorkOrderItemId, @WorkId, @StartTime, @PartnerId, @EmpNo, @CompleteQty,@WorkQty,@MakeNo,@Specification,@WorkName,@WorkNo)";
                    SQLiteCommand cmd = new SQLiteCommand(insertScript, conn);
                    cmd.Parameters.AddWithValue("@DayReportId", dayreportid.ToString());
                    cmd.Parameters.AddWithValue("@TenantId", tid);
                    cmd.Parameters.AddWithValue("@WorkOrderId", workorderid[0].Text);
                    cmd.Parameters.AddWithValue("@WorkOrderItemId", workorderitemId[0].Text);
                    cmd.Parameters.AddWithValue("@WorkId", workid[0].Text);
                    cmd.Parameters.AddWithValue("@StartTime", starttime);
                    cmd.Parameters.AddWithValue("@PartnerId", partnerid[0].Text);
                    cmd.Parameters.AddWithValue("@EmpNo", empno[0].Text);
                    cmd.Parameters.AddWithValue("@CompleteQty", comqty[0].Text);
                    cmd.Parameters.AddWithValue("@WorkQty", Workqty[0].Text );
                    cmd.Parameters.AddWithValue("@MakeNo", MakeNo[0].Text);
                    cmd.Parameters.AddWithValue("@WorkNo", WorkNo[0].Text);
                    cmd.Parameters.AddWithValue("@WorkName", WorkName[0].Text);
                    cmd.Parameters.AddWithValue("@Specification", Specification[0].Text);
                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                       var savestat= tabPage4.Controls.Find("SaveStat", true);
                        savestat[0].Visible = true;
                        savestat[0].Text = "儲存成功";
                        cleardata();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
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
        public void setkeymap(string keychar,string data="")
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
            if (t == 1)
            {
                var up = tabPage2.Controls.Find("frmWKbtnU", true);
                var down = tabPage2.Controls.Find("frmWKbtnD", true);
                string[] keyarray = new string[] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10" };
                if (data == "")
                {
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
                    var tt = tabPage2.Controls.Find("frmWKMakeno", true);
                    tt[0].Text = data;

                    Console.WriteLine("tt=" + tt[0].Name);
                }

            }
            if (t == 2)
            {
                var up = tabPage3.Controls.Find("frmPTbtnU", true);
                var down = tabPage3.Controls.Find("frmPTbtnD", true);
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

            if (t == 3)
            {
                var save = tabPage4.Controls.Find("save", true);
                string[] keyarray = new string[] { "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10" };
                if (keyupper == "S")
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
                            
                            var estr = "BTNfrmEmp" + (i +1);
                            Console.WriteLine("ke=" + keyupper + "," + keyarray[i]+estr);
                            var tempbtn = tabPage4.Controls.Find(estr, true);
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
            var pto = tabPage3.Controls.Find("frmPTshowno", true);
            var ptrn = tabPage3.Controls.Find("frmPTRecordnow", true);
            var ptrt = tabPage3.Controls.Find("frmPTRecordT", true);
            //pt
            //wk
            var wkn = tabPage2.Controls.Find("frmWKMakeno", true);
            var wki = tabPage2.Controls.Find("frmWKWorkitem", true);
            var wkr = tabPage2.Controls.Find("frmWKRecordnow", true);
            var wkt = tabPage2.Controls.Find("frmWKRecordT", true);
            var wksm = tabPage2.Controls.Find("WKSaveMakeNo", true);
            var wksw= tabPage2.Controls.Find("WKSaveWitemId", true);
            var wksmn = tabPage2.Controls.Find("WKSaveMNo", true);
            var wkss = tabPage2.Controls.Find("WKSaveSpecification", true);
            var wksq = tabPage2.Controls.Find("WKSaveWorkqty", true);
            var wkm = tabPage2.Controls.Find("WKSaveMakeNo", true);
            var lw = tabPage2.Controls.Find("labWorkOrder", true);
            var ln = tabPage2.Controls.Find("labPName", true);
            var ls = tabPage2.Controls.Find("labSpec", true);
            var lq = tabPage2.Controls.Find("labQty", true);
            //wk
            var emn = tabPage1.Controls.Find("frmEmpshowno", true); 
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
                emn[0].Text = string.Empty;
                emr[0].Text = string.Empty;
                emt[0].Text = string.Empty;
                ln[0].Text = string.Empty;
                lw[0].Text = string.Empty;
                ls[0].Text = string.Empty;
                lq[0].Text = string.Empty;
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
