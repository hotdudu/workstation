using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkstationTEST
{
    public partial class FormReturn : Form
    {
        public FormReturn()
        {
            InitializeComponent();
        }
        List<Emp> getemp = new List<Emp>();
        List<Partner> getpartner = new List<Partner>();
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
                    frmPTshowno.TextChanged+= new EventHandler(gettab2);
                    //mk[0].TextChanged += new EventHandler(gettabnowo);
                    break;
                case 2:
                    showrecord();
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
            
            this.WindowState = FormWindowState.Maximized;
            showemp();
            frmEmpshowno.TextChanged += new EventHandler(gettab);
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
            getemp = new API("/CHG/Main/Home/getEmployee/", "http://").GetEmp();
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

                    empbtn = sethandlerD(empbtn);
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
            getpartner = new API("/CHG/Main/Home/getPartner/", "http://").GetPartner(101);
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
                    Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreatePTBtnWithXY(nowcate, thisbtntext, empitem.PartnerId, btnkey, iRow, iCol, iSpace, PTPanel);
                    empbtn = sethandlerP(empbtn);
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

        private void showrecord()
        {
            var itemi = 0;
            var itemj = 0;
            var dayid = "";
            var headlist = new List<string> { "工令", "產品編號", "規格", "製程", "加工日期", "數量", "單位", "外包單號" };
            var widthlist = new List<int> { 100,100,150,150,150,150,150,150 };
            var displaylist = new List<string> { "MakeNo", "AssetsNo", "Specification","WorkNo", "WorkName", "WorkDate", "CompleteQty", "Unit", "OutNo" };
            var editlist = new string[] { "RCompleteQty", "RBadQty" };
            var hidelist = new string[] { "DayReportId" };
            for(var i = 0; i < headlist.Count; i++)
            {
                Label LB = new Label();
                LB.Width = widthlist[i];
                LB.Text = headlist[i];
                LB.Height = 50;
                LB.Font = new Font("", 9, FontStyle.Bold);
                LB.TabIndex = 999;           
            }
            List<TextBox> btnrlist = new List<TextBox>();
            foreach (var ritem in nowrecord)
            {
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
                        // Console.WriteLine("p=" + prop.Name + ",v=" + prop.GetValue(item).ToString());

                        /* if (prop.Name == "EndTime")
                         {
                             TextBox endbtn = new CreateElement(dayid, "").CreateBtn(thisbtntext, isedit, itemj);
                             btnemplist.Add(endbtn);
                         }
                         else
                         {

                         }*/
                        TextBox empbtn = new CreateElement(thisbtnname, thisbtntext).CreateBtn(thisbtntext, isedit, itemj, true);
                        if (isedit)
                        {
                            empbtn.GotFocus += new EventHandler(BtnGotfocus);
                        }
                        btnrlist.Add(empbtn);
                    }
                    if (hidelist.Contains(prop.Name))
                    {
                        TextBox empbtn = new CreateElement(thisbtnname, thisbtntext).CreateBtn(thisbtntext, isedit, 999, false);
                        btnrlist.Add(empbtn);
                    }
                }
            }

            int iSpace = 5;
            int iCol = 0;
            int iRow = 0;
            int ItemsOneRow = displaylist.Count;
            int btnnum = 0;
            var empitemcount = 0;
            var keynum = 0;
            foreach (var rbitem in btnrlist)
            {
                iRow = keynum / ItemsOneRow;
                iCol = keynum % ItemsOneRow;
                var prestr = "BTNfrmR";
                empitemcount++;
                btnnum++;
                keynum++;
                rbitem.Top = iRow * (iSpace * 2 + rbitem.Height) + iSpace; ;
                rbitem.Left = iCol * (iSpace + rbitem.Width);
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

        public Button sethandlerD(Button bt)
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
        public Button sethandlerP(Button bt)
        {
            Button sbt = bt;
            sbt.Click += new EventHandler(btnEMPALL_ClickP);
            return sbt;
        }
        private void btnEMPALL_ClickP(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            SetEmpNO(tmpButton.Tag.ToString());
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
                EMPPanel.Text = nowrow.ToString();
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
                        insertScript += "AND "+ "WorkDate" + "="+ "@outdate";
                    }

                    if (outno != string.Empty)
                    {
                        insertScript += "AND " + "OutNo" + "=" + "@outno";
                    }
                    insertScript += "Order by "+ordertable+" "+ direct;
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
            Console.Write("gotfocus=" + focust.Text);
        }
    }
}
