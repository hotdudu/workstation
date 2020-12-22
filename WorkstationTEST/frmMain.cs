using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.google.zxing.qrcode;
using com.google.zxing.common;
using com.google.zxing;
using System.IO;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;

namespace WorkstationTEST
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public const int WM_CLOSE = 0x10;
         
        public frmMain()
        {
            InitializeComponent();
        }

        enum clearType : byte { inputAll = 1, displayAll, All };
        private Int32 totalLength = 0;

        public string NO { get; private set; }
        public List<Employees> Employees { get; set; }
        public List<WorkItems> WorkItems { get; set; }
        delegate void Display(Byte[] buffer);
        TextBox NowTextbox;
        string[] txtLoc;
        int nowTenantId = 101;
        MyController thisMyController;
        string sIP = "61.221.176.176";
        string sComport = "COM4";
        string sLANGUAGE = "CHT";
        string nowMode = "Start";
        static bool issave=false;
        int uploadcount = 50;
        bool testparam = false;
        int gWorkItemCount = 0;
        string SQLconnectString="";
        string LocalconnectString = "";
        static string sSQLstatus = "";
        int pageHeight = 128*3+20*3;
        int FindDays = 60;
        //
        frmCheck objfrmCheck;
        static frmLog objfrmLog  = new frmLog(); 
        private void KeyNumber(string sNumber)
        {
            if (NowTextbox != null)
            {
                if (NowTextbox.Text.Length < 6)
                    NowTextbox.Text = NowTextbox.Text + sNumber;
            }


        }
        private void ShowData(string scanData)
        {
             
            objfrmLog.showMsg(scanData);
            if (scanData.IndexOf("::") >= 0)
            {
                string[] data = scanData.Split(new string[] { "::" }, StringSplitOptions.None);

                //  txtWorkNo.Text = data[0]??"";

                //  txtWorkName.Text = data[1] ?? "";
                switch (data[1][0])
                {
                    case 'A':
                        //  A - Start
                        if (data[1].Substring(2) == "Start")
                        { btnSart.PerformClick(); }
                        else if (data[1].Substring(2) == "Stop")
                        { btnStop.PerformClick(); }
                        else if (data[1].Substring(2) == "Save")
                        {
                            //btnStop.PerformClick();
                            objfrmCheck.HideMe();
                            //save OK = clear
                            if (nowMode == "Start")
                            {
                                if (thisMyController.SaveToLocalDB(nowTenantId, (string)txtWorkOrder.Tag, (string)txtWorkNo.Tag, (string)txtEmpNo.Tag, (string)txtDeviceNo.Tag, Int32.Parse(txtTotalQty.Text), dtpTime.Value))
                                {
                                    StartKiller();
                                    MessageBox.Show(this,"Save OK","Application Information");
                                    clearContent(clearType.All);
                                }
                            }
                            else if (nowMode == "Stop")
                            {
                                if (thisMyController.SaveToLocalDB(nowTenantId, (string)txtWorkOrder.Tag, (string)txtWorkNo.Tag, (string)txtEmpNo.Tag, (string)txtDeviceNo.Tag, Int32.Parse(txtTotalQty.Text), Int32.Parse(txtBadQty.Text), Int32.Parse(txtUnfinishQty.Text), dtpTime.Value))
                                {
                                    StartKiller();
                                    MessageBox.Show(this, "Save OK", "Application Information");
                                    clearContent(clearType.All);
                                }
                            }

                            //save fail = no clear

                        }
                        else if (data[1].Substring(2) == "Cancel")
                        {
                            //btnStop.PerformClick();
                            objfrmCheck.HideMe();
                            //cancel = do nothing
                        }
                        else if (data[1].Substring(1) == "-002")
                        { btnT002.PerformClick(); }
                        else if (data[1].Substring(1) == "-003")
                        { btnT003.PerformClick(); }
                        else if (data[1].Substring(1) == "-004")
                        { btnT004.PerformClick(); }
                        else if (data[1].Substring(1) == "-005")
                        { btnT005.PerformClick(); }
                        else if (data[1].Substring(1) == "-006")
                        { btnT006.PerformClick(); }
                        else if (data[1].Substring(1) == "-007")
                        { btnT007.PerformClick(); }
                        else if (data[1].Substring(1, 3) == "K00")
                        {
                            var s = data[1].Substring(4, 1);
                            KeyNumber(s.ToString());

                        }
                        else if (data[1].Substring(1) == "KClear")
                        {
                            if (NowTextbox != null)
                            {
                                NowTextbox.Text = "";

                            }

                        }
                        else if (data[1].Substring(1) == "KUp")
                        {
                            NowTextbox.Focus();
                            this.SelectNextControl(this.ActiveControl, false, true, true, false); //跳上一個元件
                            NowTextbox.Focus();
                        }
                        else if (data[1].Substring(1) == "KDown")
                        {
                            NowTextbox.Focus();
                            this.SelectNextControl(this.ActiveControl, true, true, true, false); //跳下一個元件
                            NowTextbox.Focus();
                        }
                        else if (data[1].Substring(1) == "KWorkNoUp")
                        { 
                            btnWorkNoUp.PerformClick();
                        }
                        else if (data[1].Substring(1) == "KWorkNoDown")
                        { 
                            btnWorkNoDown.PerformClick();
                        }
                        else if (data[1].Substring(1) == "KDeviceUp")
                        { 
                            btnDeviceUp.PerformClick();
                        }
                        else if (data[1].Substring(1) == "KDeviceDown")
                        { 
                            btnDeviceDown.PerformClick();
                        }
                        else if (data[1].Substring(1) == "KEmpUp")
                        { 
                            btnEmpUp.PerformClick();
                        }
                        else if (data[1].Substring(1) == "KEmpDown")
                        { 
                            btnEmpDown.PerformClick();
                        }
                        break;

                    case 'T':
                        var idx = Convert.ToInt32(data[1].Substring(2));
                        TextBox tmpTextbox;

                        if (this.Controls.Find(txtLoc[idx], true).Count() > 0 && this.Controls.Find(txtLoc[idx], true)[0] is TextBox)
                        {
                            if (data[2].Length == 36)
                            {

                                tmpTextbox = (TextBox)this.Controls.Find(txtLoc[idx], true)[0];
                                tmpTextbox.Focus();

                                tmpTextbox.Tag = data[2];
                                tmpTextbox.Text = data[0];
                            }
                            else
                            {
                                tmpTextbox = (TextBox)this.Controls.Find(txtLoc[idx], true)[0];
                                tmpTextbox.Focus();

                                tmpTextbox.Tag = "";
                                tmpTextbox.Text = "";
                            }

                        }

                        break;

                    default:
                        break;


                }




            }

        }

        public void DisplayText(string clickData)
        { ShowData(clickData); }
        private void DisplayText(Byte[] buffer)
        {
            textBox2.Text = String.Format("{0}{1}", BitConverter.ToString(buffer), Environment.NewLine);
            textBox8.Text = System.Text.Encoding.ASCII.GetString(buffer).ToString();
            var scanData = System.Text.Encoding.ASCII.GetString(buffer).ToString().Trim();
            totalLength = totalLength + scanData.Length;
            label1.Text = scanData;

            ShowData(scanData);
 
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void clearContent(clearType ct)
        {

            switch (ct)
            {
                case clearType.inputAll:
                    txtDeviceNo.Text = "";
                    txtEmpName.Text = "";
                    txtEmpNo.Text = "";
                    txtWorkName.Text = "";
                    txtWorkNo.Text = "";
                    txtWorkOrder.Text = "";
                    txtBadQty.Text = "";
                    txtTotalQty.Text = "";
                    txtUnfinishQty.Text = "";
                    break;
                case clearType.displayAll:
                    labLR.Text = "";
                    labPName.Text = "";
                    labQty.Text = "";
                    labRemark.Text = "";
                    labSpec.Text = "";
                    labWorkOrder.Text = "";
                    labAccuracy.Text = "";
                    break;
                case clearType.All:
                    txtDeviceNo.Text = "";
                    txtEmpName.Text = "";
                    txtEmpNo.Text = "";
                    txtWorkName.Text = "";
                    txtWorkNo.Text = "";
                    txtWorkOrder.Text = "";
                    txtBadQty.Text = "";
                    txtTotalQty.Text = "";
                    txtUnfinishQty.Text = "";
                    //
                    labLR.Text = "";
                    labPName.Text = "";
                    labQty.Text = "";
                    labRemark.Text = "";
                    labSpec.Text = "";
                    labWorkOrder.Text = "";
                    labAccuracy.Text = "";
                    break;




            }

        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Byte[] buffer = new Byte[1024];
            Int32 length = (sender as System.IO.Ports.SerialPort).Read(buffer, 0, buffer.Length);
            Array.Resize(ref buffer, length);
            Display d = new Display(DisplayText);
            this.Invoke(d, new Object[] { buffer });
        }

    

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
            serialPort1.PortName = sComport;
            serialPort1.BaudRate = 115200;
            serialPort1.DataBits = 8;
            serialPort1.Parity = System.IO.Ports.Parity.None;
            serialPort1.StopBits = System.IO.Ports.StopBits.One;
            if (!serialPort1.IsOpen)
                serialPort1.Open();
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                labScannerStatus.Text = "連結";
            }
            else
            {
                try
                {

                    labScannerStatus.Text = "斷開";
                    serialPort1.PortName = sComport;
                    serialPort1.BaudRate = 115200;
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = System.IO.Ports.Parity.None;
                    serialPort1.StopBits = System.IO.Ports.StopBits.One;
                    if (!serialPort1.IsOpen)
                        serialPort1.Open();
                }
                catch (Exception)
                {
                    labScannerStatus.Text = "出錯";
                    // throw;
                }


            }
            if (dtpTime.Enabled == false)
                dtpTime.Value = DateTime.Now;
            uploadcount += 1;
            if (uploadcount > 400)
            {
                uploadcount = 0;
                System.Diagnostics.Debug.Print("count=" + uploadcount);
                objfrmLog.showMsg("TIMER Call UpLoadToSQLServer");
                var a = string.IsNullOrEmpty(txtWorkOrder.Text);
                var b =string.IsNullOrEmpty(txtWorkNo.Text);
                var c =string.IsNullOrEmpty(txtEmpNo.Text);
                var d =string.IsNullOrEmpty(txtDeviceNo.Text);
                var e1 =string.IsNullOrEmpty(txtTotalQty.Text);
                var f =string.IsNullOrEmpty(txtBadQty.Text);
                var g = string.IsNullOrEmpty(txtUnfinishQty.Text);

                if(!a&!b&!c)
                {
                    if(nowMode=="Start")
                    {
                        if (!issave)
                        {
                         thisMyController.SaveToLocalDB(nowTenantId, (string)txtWorkOrder.Tag, (string)txtWorkNo.Tag, (string)txtEmpNo.Tag, (string)txtDeviceNo.Tag, Int32.Parse(string.IsNullOrEmpty(txtTotalQty.Text)?"0": txtTotalQty.Text), dtpTime.Value);
                            thisMyController.UpLoadToSQLServer(nowMode);
                        }
                    }
                    else 
                    {
                        thisMyController.SaveToLocalDB(nowTenantId, (string)txtWorkOrder.Tag, (string)txtWorkNo.Tag, (string)txtEmpNo.Tag, (string)txtDeviceNo.Tag, Int32.Parse(txtTotalQty.Text), Int32.Parse(txtBadQty.Text), Int32.Parse(txtUnfinishQty.Text), dtpTime.Value);
                        thisMyController.UpLoadToSQLServer(nowMode);
                    }


                }
                else
                    thisMyController.UpLoadToSQLServer(nowMode);
                // MessageBox.Show(null, "資料為空", "Application Information");

            }

            labSQLstatus.Text = sSQLstatus;

        }
        private void SetQR(string data, ref Button target, int targetHeight = 64, int targetWidth = 64, string codeMode = "QR")
        {
            ByteMatrix bm;
            Bitmap bp;
            bm = new QRCodeWriter().encode(data, BarcodeFormat.QR_CODE, targetWidth, targetHeight);
            bp = bm.ToBitmap();
            target.Image = bp;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            objfrmLog.showMsg("init");
            try
            {

                //Read ini config
                using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
                {

                    sIP = oTINI.getKeyValue("SYSTEM", "IP", "61.221.176.176");
                    sComport = "COM" + oTINI.getKeyValue("SYSTEM", "COMPORT", "4");
                    sLANGUAGE = oTINI.getKeyValue("SYSTEM", "LANGUAGE", "CHT");
                    FindDays = Convert.ToInt32(oTINI.getKeyValue("SYSTEM", "FindDays", "60")) ;
                }
            }
            catch (Exception)
            {
                sIP = "61.221.176.176";
                sComport = "COM4";
                sLANGUAGE = "CHT";
                FindDays = 60;
            }
            thisMyController = new MyController();
            thisMyController.setFindDays(FindDays);
            var sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = sIP;
            sqlBuilder.InitialCatalog = "MISData";
             sqlBuilder.IntegratedSecurity = false;
            sqlBuilder.UserID = "sa";
            sqlBuilder.Password = "Chg8675)$!(";
            sqlBuilder.PersistSecurityInfo = true;
            sqlBuilder.MultipleActiveResultSets = true;
            //sqlBuilder.ApplicationName = "EntityFramework";

            var entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.Metadata = "res://*/DBModel.csdl|res://*/DBModel.ssdl|res://*/DBModel.msl";
            SQLconnectString = entityBuilder.ToString();
            thisMyController.SQLconnectString = SQLconnectString;
 
            FontStyle fs;
            FontFamily fm;
            Font f;
            float size;
 
            Button tmpButton;
            clearContent(clearType.All);
        
            //init
            string code;
            int QRheight = 120; //圖形高
            int QRwidth = 120; // 圖形寬
            int fQRheight = 90; //圖形高
            int fQRwidth = 90; // 圖形寬
            ByteMatrix bm;
            Bitmap bp;
            //init button
            SetQR("::A-Start", ref btnSart, fQRheight, fQRwidth, "QR");
            SetQR("::A-Stop", ref btnStop, fQRheight, fQRwidth, "QR");




            for (var i = 2; i <= 7; i++)
            {
                if (this.Controls.Find("btnT00" + i.ToString(), true).Count() > 0 && this.Controls.Find("btnT00" + i.ToString(), true)[0] is Button)
                {
                    tmpButton = (Button)this.Controls.Find("btnT00" + i.ToString(), true)[0];
                    SetQR("::A-00" + i.ToString(), ref tmpButton, fQRheight, fQRwidth, "QR");
                }
            }

            for (var i = 0; i <= 9; i++)
            {
                if (this.Controls.Find("btnNumber" + i.ToString(), true).Count() > 0 && this.Controls.Find("btnNumber" + i.ToString(), true)[0] is Button)
                {
                    tmpButton = (Button)this.Controls.Find("btnNumber" + i.ToString(), true)[0];
                    SetQR("::AK00" + i.ToString(), ref tmpButton, fQRheight, fQRwidth, "QR");
                }
            }

            //
            SetQR("::AKClear", ref btnNumberClear, fQRheight, fQRwidth, "QR");
            SetQR("::AKUp", ref btnUp, fQRheight, fQRwidth, "QR");
            SetQR("::AKDown", ref btnDown, fQRheight, fQRwidth, "QR");
            SetQR("::AKSend", ref btnSend, fQRheight, fQRwidth, "QR");
            SetQR("::AKWorkNoUp", ref btnWorkNoUp, fQRheight, fQRwidth, "QR");
            SetQR("::AKWorkNoDown", ref btnWorkNoDown, fQRheight, fQRwidth, "QR");
            SetQR("::AKDeviceUp", ref btnDeviceUp, fQRheight, fQRwidth, "QR");
            SetQR("::AKDeviceDown", ref btnDeviceDown, fQRheight, fQRwidth, "QR");
            SetQR("::AKEmpUp", ref btnEmpUp, fQRheight, fQRwidth, "QR");
            SetQR("::AKEmpDown", ref btnEmpDown, fQRheight, fQRwidth, "QR");

            //init loc
            txtLoc = new string[10];
            txtLoc[1] = "txtWorkOrder";
            txtLoc[2] = "txtWorkNo";
            txtLoc[3] = "txtEmpNo";
            txtLoc[4] = "txtDeviceNo";
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            
            if (thisMyController.DownLoadFromSQLServer(nowTenantId) == false)
            {
                thisMyController.LoadFromLocalDB(nowTenantId);
            }

            //WorkItem 
            int WorkItemCount = thisMyController.LocalDBDS.Tables["WorkItems"].Rows.Count;
            int iTop = 0;
            int iLeft = 0;
            int iSpace = 10;
            int iCol = 0;
            int iRow = 0;
            int ItemsOneRow = 5;
            gWorkItemCount = WorkItemCount;
            for (var i = 0; i < WorkItemCount; i++)
            {
                iRow = i / ItemsOneRow;
                iCol = i % ItemsOneRow;
                var btnA = new Button();
                btnA.Name = "btnWorkNo" + i.ToString();
                btnA.Parent = panelWorkNO;
                btnA.Width = 120;
                btnA.Height = 128;
                btnA.Top = iRow * (iSpace * 2 + btnA.Height) + iSpace;
                btnA.Left = iCol * (iSpace * 2 + btnA.Width) + iSpace; ;

                fs = btnA.Font.Style;
                fm = new FontFamily(btnA.Font.Name);
                f = new Font(fm, 12, fs);
                btnA.Font = f;

                btnA.Text = thisMyController.LocalDBDS.Tables["WorkItems"].Rows[i]["WorkNo"].ToString();
                btnA.TextAlign = ContentAlignment.BottomCenter;
                btnA.Click += new EventHandler(btnALLQR_Click);

                btnA.ImageAlign = ContentAlignment.TopCenter; //ContentAlignment.MiddleCenter;
                code = thisMyController.LocalDBDS.Tables["WorkItems"].Rows[i]["WorkNo"].ToString() + "::T-002::" +
                    thisMyController.LocalDBDS.Tables["WorkItems"].Rows[i]["WorkId"].ToString();
                btnA.Tag = code;
                SetQR(code, ref btnA, QRheight, QRwidth, "QR");
            }

            //Device 
            int DeviceItemCount = thisMyController.LocalDBDS.Tables["AssetsItems"].Rows.Count;


            for (var i = 0; i < DeviceItemCount; i++)
            {
                iRow = i / ItemsOneRow;
                iCol = i % ItemsOneRow;
                var btnA = new Button();
                btnA.Name = "btnDevice" + i.ToString();
                btnA.Parent = panelDevice;
                btnA.Width = 120;
                btnA.Height = 128;
                btnA.Top = iRow * (iSpace * 2 + btnA.Height) + iSpace;
                btnA.Left = iCol * (iSpace * 2 + btnA.Width) + iSpace; ;

                fs = btnA.Font.Style;
                fm = new FontFamily(btnA.Font.Name);
                f = new Font(fm, 12, fs);
                btnA.Font = f;

                btnA.Text = thisMyController.LocalDBDS.Tables["AssetsItems"].Rows[i]["SubNo"].ToString();
                btnA.TextAlign = ContentAlignment.BottomCenter;
                btnA.Click += new EventHandler(btnALLQR_Click);

                btnA.ImageAlign = ContentAlignment.TopCenter; //ContentAlignment.MiddleCenter;
                code = thisMyController.LocalDBDS.Tables["AssetsItems"].Rows[i]["SubNo"].ToString() + "::T-004::" +
                    thisMyController.LocalDBDS.Tables["AssetsItems"].Rows[i]["AssetsItemId"].ToString();
                btnA.Tag = code;
                SetQR(code, ref btnA, QRheight, QRwidth, "QR");
            }
            //Emp 
            int EmpItemCount = thisMyController.LocalDBDS.Tables["Employees"].Rows.Count;


            for (var i = 0; i < EmpItemCount; i++)
            {
                string sEmployeeNo = thisMyController.LocalDBDS.Tables["Employees"].Rows[i]["EmployeeNo"].ToString();
                var btnA = new Button();
                if (sEmployeeNo.Length>=3  && sEmployeeNo.Substring(0,3) != "CHZ")
                {

                    iRow = i / ItemsOneRow;
                    iCol = i % ItemsOneRow;
                   
                    btnA.Name = "btnEmp" + i.ToString();
                    btnA.Parent = panelEmp;
                    btnA.Width = 120;
                    btnA.Height = 128;
                    btnA.Top = iRow * (iSpace * 2 + btnA.Height) + iSpace;
                    btnA.Left = iCol * (iSpace * 2 + btnA.Width) + iSpace; ;

                    fs = btnA.Font.Style;
                    fm = new FontFamily(btnA.Font.Name);
                    f = new Font(fm, 12, fs);
                    btnA.Font = f;

                    btnA.Text = thisMyController.LocalDBDS.Tables["Employees"].Rows[i]["EmployeeNo"].ToString() +
                        "-" + thisMyController.LocalDBDS.Tables["Employees"].Rows[i]["FullName"].ToString();
                    btnA.TextAlign = ContentAlignment.BottomCenter;
                    btnA.Click += new EventHandler(btnALLQR_Click);

                    btnA.ImageAlign = ContentAlignment.TopCenter; //ContentAlignment.MiddleCenter;
                    code = thisMyController.LocalDBDS.Tables["Employees"].Rows[i]["EmployeeNo"].ToString() + "::T-003::" +
                        thisMyController.LocalDBDS.Tables["Employees"].Rows[i]["EmployeeId"].ToString();
                    btnA.Tag = code;
                    SetQR(code, ref btnA, QRheight, QRwidth, "QR");

                }
               
            }


         
            objfrmCheck = new frmCheck(this);

             
            this.KeyPreview = true;
 

        }

        private void btnSart_Click(object sender, EventArgs e)
        {
            Boolean goExit = false;
            nowMode = "Start";
            btnSart.BackColor = Color.Lime;
            btnStop.BackColor = SystemColors.Control;
            labBadQty.BackColor = SystemColors.Control;
            labUnfinishQty.BackColor = SystemColors.Control;

            if (txtWorkOrder.Text == "")
            { labWorkOrderNO.BackColor = Color.Red; goExit = true; }
            else { labWorkOrderNO.BackColor = SystemColors.Control; }
            if (txtWorkNo.Text == "")
            { labWorkNO.BackColor = Color.Red; goExit = true; }
            else { labWorkNO.BackColor = SystemColors.Control; }
            if (txtEmpNo.Text == "")
            { labEmpNO.BackColor = Color.Red; goExit = true; }
            else { labEmpNO.BackColor = SystemColors.Control; }
            if (txtDeviceNo.Text == "")
            { labDeviceNO.BackColor = Color.Red; goExit = true; }
            else { labDeviceNO.BackColor = SystemColors.Control; }

            if (txtTotalQty.Text == "")
            { labTotalQty.BackColor = Color.Red; goExit = true; }
            else { labTotalQty.BackColor = SystemColors.Control; }



            if (goExit) return;
            objfrmCheck.Top = this.Top + tabControl1.Location.Y + 25;
            objfrmCheck.Left = this.Left + tabControl1.Location.X;
            objfrmCheck.Show();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Boolean goExit = false;
            nowMode = "Stop";
            btnStop.BackColor = Color.Red;
            btnSart.BackColor = SystemColors.Control;
            if (txtWorkOrder.Text == "")
            { labWorkOrderNO.BackColor = Color.Red; goExit = true; }
            else { labWorkOrderNO.BackColor = SystemColors.Control; }
            if (txtWorkNo.Text == "")
            { labWorkNO.BackColor = Color.Red; goExit = true; }
            else { labWorkNO.BackColor = SystemColors.Control; }
            if (txtEmpNo.Text == "")
            { labEmpNO.BackColor = Color.Red; goExit = true; }
            else { labEmpNO.BackColor = SystemColors.Control; }
            if (txtDeviceNo.Text == "")
            { labDeviceNO.BackColor = Color.Red; goExit = true; }
            else { labDeviceNO.BackColor = SystemColors.Control; }

            if (txtTotalQty.Text == "")
            { labTotalQty.BackColor = Color.Red; goExit = true; }
            else { labTotalQty.BackColor = SystemColors.Control; }
            if (txtBadQty.Text == "")
            { labBadQty.BackColor = Color.Red; goExit = true; }
            else { labBadQty.BackColor = SystemColors.Control; }
            if (txtUnfinishQty.Text == "")
            { labUnfinishQty.BackColor = Color.Red; goExit = true; }
            else { labUnfinishQty.BackColor = SystemColors.Control; }

            if (goExit) return;
            objfrmCheck.Top = this.Top + tabControl1.Location.Y + 25;
            objfrmCheck.Left = this.Left + tabControl1.Location.X;
            objfrmCheck.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String code = textBox3.Text + "::" + textBox4.Text;
            int QRheight = 80; //圖形高
            int QRwidth = 80; // 圖形寬
            ByteMatrix bm = new QRCodeWriter().encode(code, BarcodeFormat.QR_CODE, QRwidth, QRheight);
            Bitmap bp = bm.ToBitmap();
            pictureBox1.Image = bp;
        }

        private void txtWorkOrder_TextChanged(object sender, EventArgs e)
        {
            DataSet WO = new DataSet();
            clearContent(clearType.displayAll);
            tabControl1.SelectedIndex = 0;

            WO = MyController.ConnectToSql_WorkOrders(txtWorkOrder.Text,sIP);
            if (WO != null)
            {
                // name = ds.Tables[0].Rows[0]["WorkName"].ToString();
                if (WO.Tables[0].Rows.Count > 0)
                {
                    labWorkOrder.Text = WO.Tables[0].Rows[0]["MakeNo"].ToString();
                    labQty.Text = WO.Tables[0].Rows[0]["Qty"].ToString();
                    labPName.Text = WO.Tables[0].Rows[0]["AssetsName"].ToString();
                    labSpec.Text = WO.Tables[0].Rows[0]["Specification"].ToString();
                    labAccuracy.Text = WO.Tables[0].Rows[0]["Accuracy"].ToString();
                    labRemark.Text = WO.Tables[0].Rows[0]["Remark"].ToString();

                    if (WO.Tables[0].Rows[0]["MakeQty"] == null)
                    { labLR.Text = ""; }
                    else
                    {
                        if (WO.Tables[0].Rows[0]["EdgePath"].ToString() == "1")
                        {
                            labLR.Text = "右牙R";
                        }
                        else if (WO.Tables[0].Rows[0]["EdgePath"].ToString() == "2")
                        {
                            labLR.Text = "左牙L";
                        }
                        else
                        {
                            labLR.Text = "";
                        }

                    }

                   // var MyWorkInFactory = new WorkInFactory();
                   // MyWorkInFactory = MyController.ConnectToSql_Info(txtWorkOrder.Text);
                    // txtWorkNo.Text = MyWorkInFactory.WorkNo;
                    //  txtWorkName.Text = MyWorkInFactory.WorkName;
                  //  txtTotalQty.Text = MyWorkInFactory.TotalQty?.ToString();

                }



            }
            //
            if (txtWorkOrder.Tag != null && (string)txtWorkOrder.Tag != "")
            {
                /*
                 IEnumerable<DataRow> query = (
                from obj in LocalDBDS.Tables["Employees"].AsEnumerable()
                where obj.Field<string>("EmployeeNo") == No
                select obj
                );
                 * */
                Guid WOrder = Guid.Parse((string)txtWorkOrder.Tag);
                var strArray = (
                   from obj in thisMyController.LocalDBDS.Tables["WorkOrderItems"].AsEnumerable()
                   where obj.Field<Guid>("WorkOrderId") == WOrder
                   select obj
                   );
                var aa = strArray.Select(x => x.Field<Guid>("WorkId")).ToList();
                if (aa.Count() > 0)
                {
                    // gWorkItemCount
                    var j = 0;
                    panelWorkNO.VerticalScroll.Value = panelWorkNO.VerticalScroll.Minimum;

                    panelWorkNO.PerformLayout();
                    for (var i = 0; i < gWorkItemCount; i++)
                    {
                        Button btnA;
                        int iSpace = 10;
                        int iCol = 0;
                        int iRow = 0;
                        int ItemsOneRow = 5;

                        if (this.Controls.Find("btnWorkNo" + i.ToString(), true).Count() > 0 && this.Controls.Find("btnWorkNo" + i.ToString(), true)[0] is Button)
                        {
                            btnA = (Button)this.Controls.Find("btnWorkNo" + i.ToString(), true)[0];
                            var scanData = (string)btnA.Tag;
                            if (scanData.IndexOf("::") >= 0)
                            {
                                string[] data = scanData.Split(new string[] { "::" }, StringSplitOptions.None);
                                Guid Ga = Guid.Parse(data[2]);
                                var cc = (from obj in aa
                                          where obj.Equals(Ga)
                                          select obj
                                          ).Count();
                                if (cc > 0)
                                {
                                    //loc
                                    iRow = j / ItemsOneRow;
                                    iCol = j % ItemsOneRow;
                                    j++;
                                    btnA.Top = iRow * (iSpace * 2 + btnA.Height) + iSpace;
                                    btnA.Left = iCol * (iSpace * 2 + btnA.Width) + iSpace;

                                    btnA.Visible = true;
                                    // panelWorkNO.VerticalScroll.Value = (btnA.Top);

                                    // panelWorkNO.PerformLayout();

                                }
                                else { btnA.Visible = false; }
                            }


                        }


                    }
                }
                else
                {
                    // gWorkItemCount
                    panelWorkNO.VerticalScroll.Value = panelWorkNO.VerticalScroll.Minimum;

                    panelWorkNO.PerformLayout();
                    for (var i = 0; i < gWorkItemCount; i++)
                    {
                        Button btnA;
                        int iSpace = 10;
                        int iCol = 0;
                        int iRow = 0;
                        int ItemsOneRow = 5;
                        if (this.Controls.Find("btnWorkNo" + i.ToString(), true).Count() > 0 && this.Controls.Find("btnWorkNo" + i.ToString(), true)[0] is Button)
                        {
                            btnA = (Button)this.Controls.Find("btnWorkNo" + i.ToString(), true)[0];
                            //loc
                            iRow = i / ItemsOneRow;
                            iCol = i % ItemsOneRow;
                            btnA.Top = iRow * (iSpace * 2 + btnA.Height) + iSpace;
                            btnA.Left = iCol * (iSpace * 2 + btnA.Width) + iSpace;
                            //show
                            btnA.Visible = true;
                        }
                    }
                }
            }
        }
        private void Textbox_Enter(object sender, EventArgs e)
        {
            TextBox tmpTextbox;
            tmpTextbox = (TextBox)sender;
            tmpTextbox.BackColor = Color.Lime;

            if ((string)tmpTextbox.Tag == "number")
                NowTextbox = (TextBox)sender;
        }

        private void Textbox_Leave(object sender, EventArgs e)
        {
            TextBox tmpTextbox;
            tmpTextbox = (TextBox)sender;
            tmpTextbox.BackColor = SystemColors.Window;

        }

        private void btnT002_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedIndex = 1;

            txtWorkNo.Focus();
            //switch to tab page idx



        }

        private void btnT003_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            txtEmpNo.Focus();
            //switch to tab page idx
        }

        private void btnT004_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedIndex = 3;
            txtDeviceNo.Focus();
            //switch to tab page idx
        }

        private void btnT005_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            txtTotalQty.Focus();
            //switch to tab page idx
        }

        private void btnT006_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            txtBadQty.Focus();
            //switch to tab page idx
        }

        private void btnT007_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            txtUnfinishQty.Focus();
            //switch to tab page idx
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            //  NowTextbox.Text = NowTextbox.Text + tmpButton.Text;
            KeyNumber(tmpButton.Text);
            NowTextbox.Focus();
        }

        private void btnNumberClear_Click(object sender, EventArgs e)
        {

            NowTextbox.Text = "";
            NowTextbox.Focus();
        }

        private void txtTotalQty_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtQty_Validating(object sender, CancelEventArgs e)
        {
            /*
            TextBox tmpTextbox;
            tmpTextbox = (TextBox)sender;
            if (!System.Text.RegularExpressions.Regex.IsMatch(tmpTextbox.Text, "  ^ [0-9]"))
            {
                tmpTextbox.Text = "";
            }
            */
        }



        private void txtWorkNo_TextChanged(object sender, EventArgs e)
        {
            //
            // txtWorkName.Text = MyController.ConnectToSql_WorkName(txtWorkNo.Text);
            txtWorkName.Text = thisMyController.Get_WorkNameByNo(txtWorkNo.Text);


        }

        private void txtEmpNo_TextChanged(object sender, EventArgs e)
        {
            // txtEmpName.Text = Employees.Where(x => x.EmployeeNo == txtEmpNo.Text).Select(x => x.FullName).FirstOrDefault() ?? "".ToString();
            txtEmpName.Text = thisMyController.Get_EmpNameByNo(txtEmpNo.Text);
            //
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            NowTextbox.Focus();
            this.SelectNextControl(this.ActiveControl, false, true, true, false); //跳下一個元件
            NowTextbox.Focus();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            NowTextbox.Focus();
            this.SelectNextControl(this.ActiveControl, true, true, true, false); //跳下一個元件
            NowTextbox.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                string sResult = oTINI.getKeyValue("Test5", "1", "Error"); //Test5： Section；1：Key
                MessageBox.Show(sResult);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (panelWorkNO.VerticalScroll.Value - (pageHeight) < panelWorkNO.VerticalScroll.Minimum)
            { panelWorkNO.VerticalScroll.Value = panelWorkNO.VerticalScroll.Minimum; }
            else
            { panelWorkNO.VerticalScroll.Value -= (pageHeight); }
            panelWorkNO.PerformLayout();
        }

        private void btnWorkNoDown_Click(object sender, EventArgs e)
        {
            if (panelWorkNO.VerticalScroll.Value + (pageHeight) > panelWorkNO.VerticalScroll.Maximum)
            { panelWorkNO.VerticalScroll.Value = panelWorkNO.VerticalScroll.Maximum; }
            else
            { panelWorkNO.VerticalScroll.Value += (pageHeight); };
            panelWorkNO.PerformLayout();
        }

        private void btnDeviceUp_Click(object sender, EventArgs e)
        {
            if (panelDevice.VerticalScroll.Value - (pageHeight) < panelDevice.VerticalScroll.Minimum)
            { panelDevice.VerticalScroll.Value = panelDevice.VerticalScroll.Minimum; }
            else
            { panelDevice.VerticalScroll.Value -= (pageHeight); }
            panelDevice.PerformLayout();
        }

        private void btnDeviceDown_Click(object sender, EventArgs e)
        {
            if (panelDevice.VerticalScroll.Value + (pageHeight) > panelDevice.VerticalScroll.Maximum)
            { panelDevice.VerticalScroll.Value = panelDevice.VerticalScroll.Maximum; }
            else
            { panelDevice.VerticalScroll.Value += (pageHeight); }
            panelDevice.PerformLayout();
        }

        private void btnEmpUp_Click(object sender, EventArgs e)
        {
            if (panelEmp.VerticalScroll.Value - (pageHeight) < panelEmp.VerticalScroll.Minimum)
            { panelEmp.VerticalScroll.Value = panelEmp.VerticalScroll.Minimum; }
            else
            { panelEmp.VerticalScroll.Value -= (pageHeight); }
            panelEmp.PerformLayout();
        }

        private void btnEmpDown_Click(object sender, EventArgs e)
        {
            if (panelEmp.VerticalScroll.Value + (pageHeight) > panelEmp.VerticalScroll.Maximum)
            { panelEmp.VerticalScroll.Value = panelEmp.VerticalScroll.Maximum; }
            else
            { panelEmp.VerticalScroll.Value += (pageHeight); }
            panelEmp.PerformLayout();
        }
        private void btnALLQR_Click(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;

            DisplayText((string)tmpButton.Tag);
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            string ss;
            ss = "WorkOrderNo=" + txtWorkOrder.Text + "\r\n" +
                "WorkOrderId=" + (string)txtWorkOrder.Tag + "\r\n" +
                "WorkNo=" + txtWorkNo.Text + "\r\n" +
                "WorkId=" + (string)txtWorkNo.Tag + "\r\n" +
                "EmpNo=" + txtEmpNo.Text + "\r\n" +
                "EmpId=" + (string)txtEmpNo.Tag + "\r\n" +
                "DeviceNo=" + txtDeviceNo.Text + "\r\n" +
                "DeviceId=" + (string)txtDeviceNo.Tag + "\r\n";
            MessageBox.Show(ss);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            testparam = true;
            //thisMyController.LoadFromLocalDBtest(101);
           // thisMyController.UpLoadToSQLServer(nowMode);
        }
        public static void StartKiller()
        {
            Timer timer = new Timer();
            timer.Interval = 3000; //3秒啓動
            timer.Tick += new EventHandler(KillTimer_Tick);
            timer.Start();
        }

        private static void KillTimer_Tick(object sender, EventArgs e)
        {
            KillMessageBox();
            //停止Timer
            ((Timer)sender).Stop();
        }
        public static void showMsg(string s )
        {
            objfrmLog.showMsg(s);
        }
        private static void KillMessageBox()
        {
            //依MessageBox的標題,找出MessageBox的視窗
            IntPtr ptr = FindWindow(null, "Application Information");
            if (ptr != IntPtr.Zero)
            {
                //找到則關閉MessageBox視窗
                PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
        }

        private void txtTotalQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
  
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                dtpTime.Enabled = !dtpTime.Enabled;
            }
            if (e.KeyCode.ToString() == "F8")
            {
                objfrmLog.Show();
            }
        }

        private void frmMain_Leave(object sender, EventArgs e)
        {

        }
        public static void setSQLStatus(string ss)
        {
            sSQLstatus = ss;
           
        }
        public static void savestat(bool ss)
        {
            issave = ss;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            objfrmLog.showMsg("Call UpLoadToSQLServer");
            thisMyController.UpLoadToSQLServer(nowMode);
            objfrmLog.showMsg("Call DownLoadFromSQLServer");
            thisMyController.DownLoadFromSQLServer(nowTenantId);
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void savestat_Click(object sender, EventArgs e)
        {

        }
    }
}
