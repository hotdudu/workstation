using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Resources;
using System.Collections;

namespace WorkstationTEST
{
    public partial class frmMenu : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
       private  Dictionary<string, string> rtext = CreateElement.loadresx();
        public string Menufilter = "";
        public frmMenu()
        {
            InitializeComponent();
            var load = new loading();
            var lang = "";
            load.Show();
            dataGridView1.DataSource = getdatatable();
            dataGridView1.Columns[0].HeaderText = rtext["emp"];
            dataGridView1.Columns[1].HeaderText = rtext["makeno"];
            dataGridView1.Columns[2].HeaderText = rtext["spec"];
            dataGridView1.Columns[3].HeaderText = rtext["workdate"];

            dataGridView1.Columns[4].HeaderText = rtext["procno"];

            dataGridView1.Columns[5].HeaderText = rtext["makeqty"];
            dataGridView1.Columns[6].HeaderText = rtext["completeqty"];
            dataGridView1.Columns[7].HeaderText = rtext["badqty"];
            dataGridView1.Columns[8].HeaderText = "GO"+Environment.NewLine+ rtext["completeqty"];
            dataGridView1.Columns[9].HeaderText = "GO" + Environment.NewLine + rtext["badqty"];
            dataGridView1.Columns[10].HeaderText = "NOGO" + Environment.NewLine + rtext["completeqty"];
            dataGridView1.Columns[11].HeaderText = "NOGO" + Environment.NewLine + rtext["badqty"];
            dataGridView1.Columns[12].HeaderText =rtext["update"];
            dataGridView1.Columns[13].HeaderText = rtext["procname"];
            dataGridView1.Columns[14].HeaderText = rtext["starttime"];
            dataGridView1.Columns[15].HeaderText = rtext["endtime"];
            dataGridView1.Columns[16].HeaderText = rtext["wminute"];
            dataGridView1.Columns[17].HeaderText = rtext["unit"];

            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                lang=oTINI.getKeyValue("SYSTEM", "LANGUAGE", "");
                Menufilter= oTINI.getKeyValue("SYSTEM", "Menufilter", "");
            }
            if (lang == "CHT")
            {
                dataGridView1.Columns[0].Width = 60;
                dataGridView1.Columns[3].Width = 90;
                dataGridView1.Columns[4].Width = 60;
                dataGridView1.Columns[5].Width = 70;
                dataGridView1.Columns[6].Width = 70;
                dataGridView1.Columns[7].Width = 70;
                dataGridView1.Columns[8].Width = 70;
                dataGridView1.Columns[9].Width = 70;
                dataGridView1.Columns[10].Width = 70;
                dataGridView1.Columns[11].Width = 70;
            }

            load.Close();
           // System.Timers.Timer timer = new System.Timers.Timer(2000);
           // timer.AutoReset = true;
           // timer.Elapsed += new System.Timers.ElapsedEventHandler(HandleTimer);
           // timer.Start();
        }
        public void showmsg()
        {
            Console.WriteLine("call:" + serialPort1.IsOpen);
            if (!serialPort1.IsOpen)
            {
                openseria(sComport);
            }
        }
        private void setport()
        {
            var fstart = false;
            var fend = false;
            var fout = false;
            var fstart2 = false;
            IntPtr ptr = FindWindow("FormSTART", null);
            if (ptr != IntPtr.Zero)
            {
                fstart = true;
            }
            ptr = IntPtr.Zero;
            ptr = FindWindow("FormEND", null);
            if (ptr != IntPtr.Zero)
            {
                fend = true;
            }
            ptr = IntPtr.Zero;
            ptr = FindWindow("FormMain", null);
            if (ptr != IntPtr.Zero)
            {
                fout = true;
            }
            ptr = IntPtr.Zero;
            ptr = FindWindow("FormSTART2", null);
            if (ptr != IntPtr.Zero)
            {
                fstart2 = true;
            }
            ptr = IntPtr.Zero;
            Console.WriteLine("st=" + fstart + ",sn=" + fend + ",so=" + fout);
            if(!fstart && !fend && !fout&&!fstart2)
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        // openseria(sComport);
                        labScannerStatus.Text = rtext["connected"];
                    }
                    else
                    {
                        labScannerStatus.Text = rtext["Disconnected"];
                    }
                    
                }
                catch (Exception ex)
                {
                    labScannerStatus.Text = rtext["Disconnected"];
                }
                
            }
            else
            {
                labScannerStatus.Text = rtext["connected"];
            }
        }
        void HandleTimer(object sender, System.Timers.ElapsedEventArgs e)
        {
            setport();
        }
        delegate void Display(Byte[] buffer);
        public string sComport = new API("x", "x").COMPORT;
        private void ousidework_Click(object sender, EventArgs e)
        {
            tempclose("o");
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            var rtext=CreateElement.loadresx();
            
            Console.WriteLine("load");
            this.WindowState = FormWindowState.Maximized;
            var setpageup = new CreateElement();
            setpageup.SetBtn(startwork, "F1::F1", "開始工作");
            setpageup.SetBtn(start2, "F2::F2", "開始工作2");
            setpageup.SetBtn(endwork, "F3::F3", "結束工作");
            setpageup.SetBtn(ousidework, "F4::F4", "外包 ",115);
            setpageup.SetBtn(ousideworkR, "F6::F6", "外包送回",115);
            setpageup.SetBtn(FItem, "F7::F7", "成品區",110);
            SetControlName(rtext);
            this.KeyPreview = true;
            this.Activate();
            this.KeyDown += new KeyEventHandler(mybutton_Click);
            var ip = "59.125.158.96";
            ip = new API("", "").dbip;
            var sqlstat = "";
            var scanstat = "";
           // var com = "COM4";
            //com = new API("", "").COMPORT;
            System.Data.SqlClient.SqlConnection conn =
    new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString =
 "integrated security=false; data source=" + ip + ";" +
 "initial catalog=MISData;persist security info=True;user id=sa;password=Chg8675)$!(;MultipleActiveResultSets=True;    ";
            try
            {
                conn.Open();
                conn.Close();
                sqlstat = rtext["connected"];
                laberror.Text = "";
            }
            catch(Exception ex)
            {
                sqlstat = rtext["Disconnected"];
                laberror.Text = ex.Message;
            }
             //SerialPort sport = new SerialPort(com, 115200, Parity.None, 8, StopBits.One);
            try
            {
                if(!serialPort1.IsOpen)
                openseria(sComport);
                scanstat = rtext["connected"];
            }
            catch(Exception ex)
            {
                scanstat = rtext["Disconnected"];
                MessageBox.Show("發生錯誤:" + ex);
                Console.WriteLine("無法連結");
            }
            labScannerStatus.Text = scanstat;
            labSQLstatus.Text = sqlstat;
            setselect();

        }

        private void mybutton_Click(object sender, KeyEventArgs e)
        {
            Console.WriteLine("keycoe=" + e.KeyCode);
            setkeymap(e.KeyCode.ToString());
            //tmpb.PerformClick();
        }
        private void endwork_Click(object sender, EventArgs e)
        {
            tempclose("e");
        }

        private void startwork_Click(object sender, EventArgs e)
        {


            // setstart();
            tempclose("s");

        }
        private void tempclose(string frm)
        {
            var CloseDown = new System.Threading.Thread(new System.Threading.ThreadStart(CloseSerialOnExit));
            CloseDown.Start();           
            Console.WriteLine("after start=" + serialPort1.IsOpen);
            var isop = false;
            execfrm(frm);

        }
        private async void execfrm(string frm)
        {
            await Task.Delay(200);
            Console.WriteLine("wait:" + serialPort1.IsOpen);
            if(serialPort1.IsOpen)
            {
                await Task.Delay(800);
                if (frm == "s")
                {
                    var m = new FormSTART(this);
                    m.Show();
                }
                if (frm == "m")
                {
                    var m = new FormSTART2(this);
                    m.Show();
                }
                if (frm=="e")
                {
                    var m = new FormEND(this);
                    m.Show();
                }
                if (frm == "o")
                {
                    var m = new FormMain(this);
                    m.Show();
                }
                if (frm == "r")
                {
                    var m = new FormReturn(this);
                    m.Show();
                }
                if (frm == "f")
                {
                    var m = new FinishItem(this);
                    m.Show();
                }
            }
            else
            {
                if (frm == "s")
                {
                    var m = new FormSTART(this);
                    m.Show();
                }
                if (frm == "m")
                {
                    var m = new FormSTART2(this);
                    m.Show();
                }
                if (frm == "e")
                {
                    var m = new FormEND(this);
                    m.Show();
                }
                if (frm == "o")
                {
                    var m = new FormMain(this);
                    m.Show();
                }
                if (frm == "r")
                {
                    var m = new FormReturn(this);
                    m.Show();
                }
                if (frm == "f")
                {
                    var m = new FinishItem(this);
                    m.Show();
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
        private void setstart()
        {
            var isop = false;
            try
            {
                Console.WriteLine("brfore start=" + serialPort1.IsOpen);
                isop = serialPort1.IsOpen;
                if (serialPort1.IsOpen == true)
                {
                    
                    serialPort1.DtrEnable = false;
                    serialPort1.RtsEnable = false;
                    Thread.Sleep(200);
                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            Console.WriteLine("after start=" + isop);
            var m = new FormSTART(this);
            m.Show();
        }
        private void setselect()
        {
            string dbPath = Directory.GetCurrentDirectory() + "\\" + "wd2.db3";
            string cnStr = "data source=" + dbPath + ";Version=3;";
            Console.WriteLine("cn=" + cnStr + ",r" + File.Exists(dbPath));
            List<string> selectemp = new List<string>();
            selectemp.Add(" ");
            if (File.Exists(dbPath))
            {
                using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                {
                    try
                    {
                        var insertscript = "SELECT DISTINCT EmpNo FROM WorkDayReports ORDER BY EmpNo";
                        conn.Open();
                        var cmd = new SQLiteCommand(insertscript, conn);
                        using (SQLiteDataReader row = cmd.ExecuteReader())
                        {
                            while (row.Read())
                            {
                                selectemp.Add(row["EmpNo"] as string ?? "");
                            }
                        }
                     }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw new Exception("錯誤:" + ex.Message);
                    }
                }

            }
            if (selectemp.Count > 0)
            {
                foreach(var item in selectemp)
                {
                    empnolist.Items.Add(new ComboboxItem(item,item));
                }
            }


        }

        private DataTable getdatatable(string empno=" ")
        {
            using (DataTable table = new DataTable())
            {
                // Add columns.
                table.Columns.Add("EmpNo", typeof(string));
                table.Columns.Add("MakeNo", typeof(string));
                table.Columns.Add("Specification", typeof(string));
                table.Columns.Add("WorkDate", typeof(string));
        
                table.Columns.Add("WorkNo", typeof(string));

                table.Columns.Add("WorkQty", typeof(string));
                table.Columns.Add("CompleteQty", typeof(string));
                table.Columns.Add("BadQty", typeof(string));
                table.Columns.Add("CompletGoQty", typeof(string));
                table.Columns.Add("BadGoQty", typeof(string));
                table.Columns.Add("CompletNgQty", typeof(string));
                table.Columns.Add("BadNgQty", typeof(string));
                table.Columns.Add("isupdate", typeof(string));

                table.Columns.Add("WorkName", typeof(string));
                table.Columns.Add("StartTime", typeof(string));
                table.Columns.Add("EndTime", typeof(string));
                table.Columns.Add("WorkTime", typeof(string));
                table.Columns.Add("Unit", typeof(string));
                string dbPath = Directory.GetCurrentDirectory() + "\\" + "wd2.db3";
                string cnStr = "data source=" + dbPath + ";Version=3;";
                Console.WriteLine("cn=" + cnStr + ",r" + File.Exists(dbPath));
                List<WorkDayReportMenu> wkd = new List<WorkDayReportMenu>();
                if (File.Exists(dbPath))
                {
                    using (SQLiteConnection conn = new SQLiteConnection(cnStr))
                    {

                        try
                        {
                            var insertScript = "SELECT * FROM WorkDayReports ORDER BY StartTime DESC";
                            var ismultipleno = false;
                            var marray = Menufilter.Split(';');
                            var msubarray = new List<string>();
                            if (empno!=" ")
                            {

                                foreach (var item in marray)
                                {
                                    if (item.IndexOf(empno) > -1)
                                    {
                                        ismultipleno = true;
                                        var inneritem = item.Split(',');
                                        foreach (var inner in inneritem)
                                        {
                                            msubarray.Add(inner);
                                        }
                                    }
                                }
                                if (ismultipleno)
                                {
                                    insertScript= "SELECT * FROM WorkDayReports WHERE EmpNo=@EmpNo OR EmpNo=@EmpNo1 ORDER BY StartTime DESC";
                                }
                                else
                                {
                                    insertScript = "SELECT * FROM WorkDayReports WHERE EmpNo=@EmpNo ORDER BY StartTime DESC";
                                }
                            }

                            //wkd = conn.Query<WorkDayReport>(insertScript).ToList();
                            conn.Open();
                            var cmd =new SQLiteCommand(insertScript, conn);
                            if(empno!=" ")
                            {
                                if (ismultipleno)
                                {
                                    cmd.Parameters.AddWithValue("@EmpNo", msubarray[0]);
                                    cmd.Parameters.AddWithValue("@EmpNo1", msubarray[1]);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpNo", empno);

                                }
                            }

                            using (SQLiteDataReader row = cmd.ExecuteReader())
                            {
                                while (row.Read())
                                {
                                    wkd.Add(new WorkDayReportMenu() {
                                        DayReportId = row["DayReportId"] as string ?? "",
                                        TenantId = row["TenantId"] as int? ?? default(int),
                                        EmployeeId = row["EmployeeId"] as string ?? "",
                                        EndTime = row["EndTime"] as DateTime? ?? null,
                                        AdjustTime = row["AdjustTime"] as decimal? ?? null,
                                        BadQty = row["BadQty"] as decimal? ?? null,
                                        CompleteQty = row["CompleteQty"] as decimal? ?? null,
                                        BadGoQty = row["BadGoQty"] as decimal? ?? null,
                                        CompletGoQty = row["CompletGoQty"] as decimal? ?? null,
                                        BadNgQty = row["BadNgQty"] as decimal? ?? null,
                                        CompletNgQty = row["CompletNgQty"] as decimal? ?? null,
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
                                        WorkTime = row["WorkTime"] as decimal? ?? null,
                                        isupdate = row["isupdate"] as Boolean?,
                                        UseUnits=row["Unit"] as string??"",
                                    });
                                }
                            }
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            throw new Exception("錯誤:"+ex.Message);
                        }

                    }
                }
                Console.WriteLine("wkd=" + wkd.Count);
                foreach(var r in wkd.Take(100))
                {
                    DateTime wdate = new DateTime();
                    var isdate = DateTime.TryParse(r.WorkDate, out wdate);
                    Console.WriteLine("en=" + r.EmpNo);
                    table.Rows.Add(r.EmpNo, r.MakeNo, r.Specification,wdate.ToShortDateString(), r.WorkNo, r.WorkQty, r.CompleteQty, r.BadQty,r.CompletGoQty,r.BadGoQty,r.CompletNgQty,r.BadNgQty,
                        r.isupdate == true ? rtext["success"] : (r.WorkTime.HasValue ? rtext["failure"] : ""), r.WorkName, r.StartTime,r.EndTime, r.WorkTime, r.UseUnits);
                }
                return table;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = getdatatable();
        }
        public void openseria(string com)
        {
            serialPort1.PortName = com;
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
                    MessageBox.Show("開啟掃描器異常");
                }
            }
                
            //Console.WriteLine("isopen:"+serialPort1.IsOpen);
        }
        public void setkeymap(string keychar, string data = "", bool isp = false)
        {
            Console.WriteLine(",ind=" + keychar);
            var keyupper = keychar.ToString();
            if (keyupper == "F1")
            {
                Console.WriteLine("eror:");
              //  tempclose();
                startwork.PerformClick();
            }
            if (keyupper == "F3")
            {
                endwork.PerformClick();
            }
            if (keyupper == "F2")
            {
                start2.PerformClick();
            }
            if (keyupper == "F4")
            {
                ousidework.PerformClick();
            }
            if (keyupper == "F6")
            {
                ousideworkR.PerformClick();
            }
            if (keyupper == "F7")
            {
                FItem.PerformClick();
            }
        }
        public void DisplayText(string clickData)
        { ShowData(clickData); }
        private void DisplayText(Byte[] buffer)
        {
            var scanData = System.Text.Encoding.ASCII.GetString(buffer).ToString().Trim();
            ShowData(scanData);
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Byte[] buffer = new Byte[1024];
            Int32 length = (sender as System.IO.Ports.SerialPort).Read(buffer, 0, buffer.Length);
            Array.Resize(ref buffer, length);
            Display d = new Display(DisplayText);
            this.Invoke(d, new Object[] { buffer });
        }

        public string ShowData(string data)
        {
            //Console.WriteLine(data);
            var dataarray = data.Split(new string[] { "::" }, StringSplitOptions.None);
            if (dataarray.Length == 2)
            {
                var pkey = dataarray[1];
                Console.WriteLine("pkey=" + pkey);
                setkeymap(pkey);
            }
            return data;
        }

        private void empnolist_SelectedIndexChanged(object sender, EventArgs e)
        {
            var emp = (ComboBox)sender;
            ComboboxItem selectedCar = (ComboboxItem)emp.SelectedItem;
            dataGridView1.DataSource = getdatatable(selectedCar.Value);
        }

        public void SetControlName(Dictionary<string,string> namelist)
        {
            label1.Text = namelist[label1.Name];
            label23.Text = namelist[label23.Name];
            label2.Text = namelist[label2.Name];
            txtinfo.Text = namelist[txtinfo.Name];
            startwork.LeftText = namelist[startwork.Name];
            endwork.LeftText = namelist[endwork.Name];
            //ousidework.LeftText = namelist[ousidework.Name];
            start2.LeftText = namelist[startwork.Name] + "2";
            startwork.Refresh();
            endwork.Refresh();
           // ousidework.Refresh();
            start2.Refresh();
            //menu

        }

        public void ChangeLang(string name)
        {
            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                oTINI.setKeyValue("SYSTEM", "LANGUAGE", name);
            }
            var dict=CreateElement.loadresx();
            SetControlName(dict);
        }
        private void CHT_Click(object sender, EventArgs e)
        {
            ChangeLang(((Button)sender).Name);
        }

        private void EN_Click(object sender, EventArgs e)
        {
            ChangeLang(((Button)sender).Name);
        }

        private void VN_Click(object sender, EventArgs e)
        {
            ChangeLang(((Button)sender).Name);
        }

        private void IN_Click(object sender, EventArgs e)
        {
            ChangeLang(((Button)sender).Name);
        }

        private void start2_Click(object sender, EventArgs e)
        {
            tempclose("m");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ip = new API("", "").dbip;
            var connstr = "data source=" + ip + ";" +
"initial catalog=MISData;persist security info=True;user id=sa;password=Chg8675)$!(;MultipleActiveResultSets=True;    ";
            List<remotEmp> remp = new Local(connstr).getremoteEmp();
            var path = Directory.GetCurrentDirectory(); var dbfile = "wd2.db3";
            var localconn = new Local(path, dbfile).connstring;
            using (SQLiteConnection sconn = new SQLiteConnection(localconn))
            {
                var insertScript = "INSERT OR IGNORE  INTO Employees (EmployeeId,TenantId,FullName,EmployeeNo,DepartmentId) VALUES (@EmployeeId,@TenantId,@FullName,@EmployeeNo,@DepartmentId)";
                sconn.Open();
                foreach (var item in remp)
                {
                    SQLiteCommand cmd = new SQLiteCommand(insertScript, sconn);
                    cmd.Parameters.AddWithValue("@EmployeeId", item.EmployeeId.ToString());
                    cmd.Parameters.AddWithValue("@TenantId", item.TenantId);
                    cmd.Parameters.AddWithValue("@DepartmentId", item.DepartmentId.ToString());
                    cmd.Parameters.AddWithValue("@EmployeeNo", item.EmployeeNo);
                    cmd.Parameters.AddWithValue("@FullName", item.FullName);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        private void ousideworkR_Click(object sender, EventArgs e)
        {
            tempclose("r");
        }

        private void FItem_Click(object sender, EventArgs e)
        {
            tempclose("f");
        }
    }
}
