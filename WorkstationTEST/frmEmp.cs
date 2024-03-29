﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkstationTEST
{
    public partial class frmEmp : Form
    {
        public frmEmp()
        {
            InitializeComponent();
            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                DepartNo = oTINI.getKeyValue("SYSTEM", "DepartNo", "");
                NIG = oTINI.getKeyValue("SYSTEM", "NIG", "");
                DefCompany= oTINI.getKeyValue("SYSTEM", "DefCompany", "");
                ShowTenants= oTINI.getKeyValue("SYSTEM", "ShowTenants", "");
            }
            //tab = tab1;
        }
        delegate void loadtab(TabControl taba);
        public TabControl tab;
        List<Empm> getemp = new List<Empm>();
        public string DepartNo = "";//部門編號開頭
        public string NIG = "";//不在部門內但要顯示的員工，目前僅能一位，要多位要改API
        public string DefCompany = "";//預設公司
        public string ShowTenants = "";//不同公司但員工姓名相同且身分證號相同的話是否開啟選擇畫面
        Dictionary<string, string> rtext = CreateElement.loadresx("WK");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void frmEmpPageU_Click(object sender, EventArgs e)
        {
            Int32 tlpColumCount = tableLayoutPanel1.ColumnCount;
            Int32 tlpRowCount = tableLayoutPanel1.RowCount;
            List<Button> btnemplist = new List<Button>();
            int nowrecord = 0;
            int recordT = 0;
            bool trynowrecord = int.TryParse(frmEmpRecordnow.Text, out nowrecord);
            bool tryrecordT = int.TryParse(frmEmpRecordT.Text, out recordT);
            var looplimit = nowrecord - recordT;
            var loopinit = looplimit + 1 - (tlpColumCount * tlpRowCount);
            if (trynowrecord&&looplimit>0)
            {
                for (int i = tableLayoutPanel1.Controls.Count - 1; i >= 0; --i)
                    tableLayoutPanel1.Controls[i].Dispose();
                tableLayoutPanel1.Controls.Clear();
            }
            Console.WriteLine("U-nowrecord=" + nowrecord);
            if (nowrecord > 0)
            {
                Console.WriteLine("U-getemp=" + getemp.Count());
                if (getemp.Count() > 0)
                {
                    var empitemcount = 0;
                    var j = loopinit;
                    var recordU = 0;
                    Console.WriteLine("U-j=" + j + ",row=" + tlpRowCount + ",col=" + tlpColumCount+",looplimit="+looplimit);
                    if (j >= 0&&looplimit>0)
                    {
                        var reali = 0;
                        Console.WriteLine("U-loop=" + loopinit+",looplimit="+looplimit);
                        for (var i = loopinit; i <loopinit + (tlpColumCount * tlpRowCount); i += tlpColumCount)
                        {
                            reali++;
                            var realj = 0;
                            for (; j < getemp.Count && j < i + tlpColumCount; j++)
                            {
                                recordU++;
                                Console.WriteLine("U-i=" + i + ",j=" + j + ",name=" + getemp[j].FullName + ",ri=" + reali + ",rj=" + realj);
                                var prestr = "BTNfrmEmp";
                                empitemcount++;
                                var keynum = j % (tlpColumCount * tlpRowCount) + 1;
                                var btnkey = "F" + keynum;
                                var poststr = empitemcount.ToString("##");
                                var thisbtnname = prestr + poststr;
                                var thisbtntext = getemp[j].FullName;
                                Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateEmpBtn(getemp[j].EmployeeNo, thisbtntext,getemp[j].EmployeeId,btnkey);
                                empbtn = sethandler(empbtn);
                                tableLayoutPanel1.Controls.Add(empbtn, realj, reali - 1);
                                frmEmpRecordnow.Text = j.ToString();
                                realj++;
                            }
                        }
                        frmEmpRecordT.Text = recordU.ToString();
                    }

                    Console.WriteLine("record=" + frmEmpRecordnow.Text);
                }
            }
        }
        private void frmEmpPageD_Click(object sender, EventArgs e)
        {
            Int32 tlpColumCount = tableLayoutPanel1.ColumnCount;
            Int32 tlpRowCount = tableLayoutPanel1.RowCount;
            List<Button> btnemplist = new List<Button>();
            int nowrecord = 0;
            bool trynowrecord = int.TryParse(frmEmpRecordnow.Text, out nowrecord);
            if (trynowrecord && nowrecord < getemp.Count-1)
            {
                for (int i =tableLayoutPanel1.Controls.Count - 1; i >= 0; --i)
                    tableLayoutPanel1.Controls[i].Dispose();
                    tableLayoutPanel1.Controls.Clear();
            }
            Console.WriteLine("D-nowrecord=" + nowrecord);
            if (nowrecord > 0)
            {
                Console.WriteLine("D-getemp="+ getemp.Count());
                if (getemp.Count() > 0)
                {
                    var empitemcount = 0;
                    var j = nowrecord+1;

                    Console.WriteLine("D-j=" + j+",row="+tlpRowCount+",col="+tlpColumCount);
                    if (j > 0 &&nowrecord<getemp.Count-1)
                    {
                        var reali = 0;
                        var recordD = 0;
                        Console.WriteLine("d-tlpRowCount="+ tlpRowCount);
                        for (var i = nowrecord + 1; i < (nowrecord+1)+(tlpColumCount*tlpRowCount); i +=tlpColumCount)
                        {
                            reali++;
                            var realj = 0;
                            for (; j < getemp.Count && j <i+tlpColumCount; j++)
                            {
                                recordD++;
                                Console.WriteLine("D-i=" + i + ",j=" + j + ",name=" + getemp[j].FullName+",ri="+reali+",rj="+realj);
                                var prestr = "BTNfrmEmp";
                                empitemcount++;
                                var keynum = j % (tlpColumCount * tlpRowCount) + 1;
                                var btnkey = "F" + keynum;
                                var poststr = empitemcount.ToString("##");
                                var thisbtnname = prestr + poststr;
                                var thisbtntext = getemp[j].FullName;
                                Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateEmpBtn(getemp[j].EmployeeNo, thisbtntext,getemp[j].EmployeeId,btnkey);
                                empbtn = sethandler(empbtn);
                                tableLayoutPanel1.Controls.Add(empbtn, realj, reali-1);
                                frmEmpRecordnow.Text = j.ToString();
                                realj++;
                            }
                        }
                        frmEmpRecordT.Text = recordD.ToString();
                    }

                    Console.WriteLine("record=" + frmEmpRecordnow.Text);
                }
            }
        }
        private void frmEmp_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            var setpageup = new CreateElement();
            setpageup.SetBtn(frmEmpPageU, "Insert::Insert", rtext["frmWKbtnU"]);
            setpageup.SetBtn(frmEmpPageD, "Delete::Delete", rtext["frmWKbtnD"]);
            getemp = new API("/CHG/Main/Home/getEmployee2/", "http://").GetEmpm(DefCompany,DepartNo,NIG);
            Int32 tlpColumCount = tableLayoutPanel1.ColumnCount;
            Int32 tlpRowCount = tableLayoutPanel1.RowCount;
            List<Button> btnemplist = new List<Button>();
            if (getemp.Count() > 0)
            { 
                var empitemcount = 0;
                var keynum = 0;
                foreach(var empitem in getemp)
                {
                    var prestr = "BTNfrmEmp";
                    empitemcount++;
                    if ((empitemcount - 1) != 0 && (empitemcount - 1) % (tlpRowCount*tlpColumCount) == 0)
                        keynum = 0;
                    keynum++;
                    var poststr = empitemcount.ToString("##");
                    var thisbtnname = prestr + poststr;
                    var thisbtntext = empitem.FullName;
                    var btnkey = "F" + keynum;
                    var rlist = empitem.Rlist;
                    var IsMultiple = false;
                    var rno = "";
                    var rtenant = "";
                    if (rlist.Count > 1)
                    {
                        IsMultiple = true;
                        var ri = 0;
                        foreach(var ritem in rlist)
                        {
                            rno += (ri == 0 ? ritem.no : "," + ritem.no);
                            rtenant += (ri == 0 ? ritem.tenant : "," + ritem.tenant);
                            ri++;
                        }
                    }                   
                    Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateEmpBtnm(empitem.EmployeeNo, thisbtntext,empitem.EmployeeId,btnkey,IsMultiple,rno,rtenant);
                    empbtn = sethandler(empbtn);
                    btnemplist.Add(empbtn);
                }
                var j = 0;
                var recordL = 0;
                for (var i = 0; i < tlpRowCount; i+=tlpColumCount)
                {
                    for(;j<btnemplist.Count && j<tlpColumCount*tlpRowCount; j++)
                    {
                        recordL++;
                        Console.WriteLine("L-i=" + i + ",j=" + j + ",name=" + btnemplist[j].Name);
                        tableLayoutPanel1.Controls.Add(btnemplist[j], j, i);                       
                        frmEmpRecordnow.Text = j.ToString();
                    }
                }
                frmEmpRecordT.Text = recordL.ToString();
                Console.WriteLine("record=" + frmEmpRecordnow.Text);
            }
        }
        public void SetEmpNO(string info) {
            var empinfos = info.Split(':');
            if (empinfos.Length == 2)
            {
                frmEmpshowno.Text = empinfos[0];
                empname.Text = empinfos[1];
            }
            else if(empinfos.Length==4)
            {
                if (ShowTenants == "1")
                {
                    var rno = empinfos[2].Split(',');
                    var rten = empinfos[3].Split(',');
                    FormMultiTenant frmt = new FormMultiTenant();
                    frmt.setTenantm(rno,rten);
                    frmt.ShowDialog();
                    frmEmpshowno.Text = frmt.Eno;
                    empname.Text = empinfos[1];
                }
                else if(ShowTenants=="0")
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
        public Button sethandler(Button bt) {
            Button sbt=bt;
            sbt.Click += new EventHandler(btnEMPALL_Click);
            return sbt;
        }

        private void btnEMPALL_Click(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            SetEmpNO(tmpButton.Tag.ToString());           
        }
    }


}
