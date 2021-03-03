using System;
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
    public partial class frmWorkOrder3 : Form
    {
        public string DefCompany = "";
        public frmWorkOrder3()
        {
            InitializeComponent();
            Console.WriteLine("frmWK");
            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                DefCompany = oTINI.getKeyValue("SYSTEM", "DefCompany", "");
            }
        }
        List<Workitem> getwitem = new List<Workitem>();
        List<WorkOrderO> getworkorder = new List<WorkOrderO>();
        bool debug = false;
        private void frmWorkOrder_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> rtext = CreateElement.loadresx("WK");
            WKtenantId.Text = DefCompany;
            label13.Text = rtext[label13.Name];
            label1.Text = rtext[label1.Name];
            label2.Text = rtext[label2.Name];
            label4.Text = rtext[label4.Name];
            label5.Text = rtext[label5.Name];
            label7.Text = rtext[label7.Name];
            label9.Text = rtext[label9.Name];
            label12.Text = rtext[label12.Name];
            label21.Text = rtext[label21.Name];
            infotitle.Text = rtext[infotitle.Name];
            labelname.Text = rtext[labelname.Name];
            ActiveControl = frmWKMakeno;
            Console.WriteLine("frmWKload");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            var setpageup = new CreateElement();
            setpageup.SetBtn((XButton)frmWKbtnU, "Insert::Insert", rtext["frmWKbtnU"]);
            setpageup.SetBtn((XButton)frmWKbtnD, "Delete::Delete", rtext["frmWKbtnD"]);
            getwitem.Clear();
            getwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem();
            if (getwitem.Count > 0)
            {
                WKSaveWorderId.Text = getwitem[0].WorkOrderId.ToString();
                frmWKMakeno.Tag = WKSaveWorderId.Text;
            }
            Int32 tlpColumCount = WKPanel.ColumnCount;
            Int32 tlpRowCount = WKPanel.RowCount;
            List<Button> btnemplist = new List<Button>();
            if (getwitem.Count() > 0)
            {
                var empitemcount = 0;
                var keynum = 0;
                foreach (var empitem in getwitem)
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
                    empbtn = sethandlerD(empbtn);
                    empbtn.TabStop = false;
                    empbtn.TabIndex = 99;
                    btnemplist.Add(empbtn);
                }
                Console.WriteLine("btn=" + btnemplist.Count + "," + tlpColumCount + "," + tlpRowCount);
                var j = 0;
                var recordL = 0;
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


        private void frmWKMakeno_TextChanged(object sender, EventArgs e)
        {
            var text =  (sender as TextBox).Text;
            if (text!="")
            {
                Console.WriteLine("text=" + text);
                string makeno = "";
                string wid = "";
                string tid = "";
                var tidval = 0;
                Console.WriteLine("m=" + text);
                if (text.IndexOf("::") >= 0)
                {
                    string[] data = text.Split(new string[] { "::" }, StringSplitOptions.None);
                     makeno = data[0];
                    wid = data.Length == 4 ? data[data.Length - 2] : data[data.Length - 1];//qr碼新增tenantid，陣列長度變為4
                    tid = data.Length == 4 ? data[data.Length - 1] : "";
                    int.TryParse(tid, out tidval);
                    if (data.Length == 4)
                    {
                        tidval = int.Parse(tid);
                    }
                    WKtenantId.Text = tid;
                    if (debug)
                    {
                        MessageBox.Show("wid=" + wid + ",tid=" + tid);
                    }
                }
                //frmWKMakeno.Text = makeno;
                frmWKMakeno.Tag = wid;
                getwitem.Clear();
                getworkorder = new API("/CHG/Main/Home/getinfo2/", "http://").GetWorkOrderO(tidval,makeno);
                if (getworkorder.Count > 0)
                {
                    var R_TenantId = "";
                    if (getworkorder.Count > 1)
                    {
                        FormMultiTenant frmt = new FormMultiTenant();
                        frmt.setTenant(getworkorder);
                        frmt.ShowDialog();
                        R_TenantId = frmt.TenantId;
                        int.TryParse(R_TenantId, out tidval);
                    }
                    else
                    {
                        R_TenantId = getworkorder[0].TenantId.ToString();
                    }
                    if (debug)
                        MessageBox.Show(R_TenantId);
                    getworkorder = getworkorder.Where(x => x.TenantId == tidval).ToList();
                    labSpec.Text = getworkorder[0].Specification;
                    labRemark.Text = getworkorder[0].Remark;
                    labPName.Text = getworkorder[0].AssetsNo;
                    labWorkOrder.Text = getworkorder[0].MakeNo;
                    labQty.Text = getworkorder[0].MakeQty.ToString();
                    labUnit.Text = getworkorder[0].UseUnits;
                    labAssetsName.Text = getworkorder[0].AssetsName;
                    WKAssetsId.Text = getworkorder[0].AssetsId.HasValue ? getworkorder[0].AssetsId.ToString() : "";
                    WKtenantId.Text = R_TenantId;
                    WKprice.Text = getworkorder[0].Price.ToString();
                    UpdatePID();
                }
                else
                {
                    //MessageBox.Show("無此工令資料");
                    Console.WriteLine("無此工令資料");
                    //ActiveControl = this.frmWKMakeno;
                }
                Guid gwid ;
                var isguid = Guid.TryParse(wid, out gwid);
                if (isguid)
                {

                     getwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem(tidval,makeno,Guid.Parse(wid));
                }

                else
                {
                    Console.WriteLine("輸入工令格式錯誤");
                    //ActiveControl = this.frmWKMakeno;
                }
                   

                Int32 tlpColumCount = WKPanel.ColumnCount;
                Int32 tlpRowCount = WKPanel.RowCount;
                List<Button> btnemplist = new List<Button>();
                if (getwitem.Count() > 0)
                {
                    var empitemcount = 0;
                    var keynum = 0;
                    foreach (var empitem in getwitem)
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
                        Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateWKBtn(empitem.WorkNo, thisbtntext,empitem.WorkOrderItemId,empitem.WorkId,btnkey);
                        empbtn = sethandler(empbtn);
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
                     ActiveControl = this.label1;
                   // ActiveControl = this.frmWKMakeno;
                }
                else
                {
                   // ActiveControl = this.frmWKMakeno;
                }
               

            }
            else
            {
                getwitem.Clear();
                getwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem();
                if (getwitem.Count > 0)
                {
                    WKSaveWorderId.Text = getwitem[0].WorkOrderId.ToString();
                    frmWKMakeno.Tag = WKSaveWorderId.Text;
                }
                Int32 tlpColumCount = WKPanel.ColumnCount;
                Int32 tlpRowCount = WKPanel.RowCount;
                for (int i = WKPanel.Controls.Count - 1; i >= 0; --i)
                    WKPanel.Controls[i].Dispose();
                WKPanel.Controls.Clear();
                List<Button> btnemplist = new List<Button>();
                if (getwitem.Count() > 0)
                {
                    var empitemcount = 0;
                    var keynum = 0;
                    foreach (var empitem in getwitem)
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
                        empbtn = sethandlerD(empbtn);
                        empbtn.TabStop = false;
                        empbtn.TabIndex = 99;
                        btnemplist.Add(empbtn);
                    }
                    Console.WriteLine("btn=" + btnemplist.Count + "," + tlpColumCount + "," + tlpRowCount);
                    var j = 0;
                    var recordL = 0;
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
        }

        public void SetEmpNO(string info,bool isdef=false)
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
            Console.WriteLine("wkno=" + frmWKWorkitem.Text+",witemid="+witemid+",workid="+workid+",workorderid="+WKSaveWorderId.Text);
            frmWKWorkitem.Text = wkno;
        }
        public Button sethandler(Button bt)
        {
            Button sbt = bt;
            sbt.Click += new EventHandler(btnEMPALL_Click);
            return sbt;
        }
        public Button sethandlerD(Button bt)
        {
            Button sbt = bt;
            sbt.Click += new EventHandler(btnEMPALL_ClickD);
            return sbt;
        }
        private void btnEMPALL_Click(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            SetEmpNO(tmpButton.Tag.ToString());
        }
        private void btnEMPALL_ClickD(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            SetEmpNO(tmpButton.Tag.ToString(),true);
        }
        private void labPName_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmWKbtnU_Click(object sender, EventArgs e)
        {
            Console.WriteLine("wku");
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
                                Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateWKBtn(getwitem[j].WorkNo, thisbtntext, getwitem[j].WorkOrderItemId, getwitem[j].WorkId,btnkey);
                                empbtn = sethandler(empbtn);
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

        private void frmWKbtnD_Click(object sender, EventArgs e)
        {
            Console.WriteLine("wkd");
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
                                Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateWKBtn(getwitem[j].WorkNo, thisbtntext, getwitem[j].WorkOrderItemId, getwitem[j].WorkId,btnkey);
                                empbtn = sethandler(empbtn);
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

        private void labSpec_Click(object sender, EventArgs e)
        {

        }

        private void infotitle_Click(object sender, EventArgs e)
        {

        }

        private void UpdatePID()
        {
            var tid = 0;

            int.TryParse(WKtenantId.Text, out tid);
            var pno = WKpno.Text;
            List<Partner> getpt = new API("/CHG/Main/Home/getPartnerId/", "http://").GetPartner2(tid, pno);
            Console.WriteLine("tenantid change:tid:" + tid + ",pno=" + pno);
            if (getpt.Count > 0)
            {
                WKPartnerId.Text = getpt.First().PartnerId.ToString();
                Console.WriteLine("tenantid change:newpid:" + WKPartnerId.Text);
            }

        }

        private void SetCompany_Click(object sender, EventArgs e)
        {
            var titem = new List<Tenant>();
            int? tidval = null;
            if (!string.IsNullOrEmpty(DefCompany))
            {
                tidval = int.Parse(DefCompany);
            }
            try
            {
                titem= new API("/CHG/Main/Home/getTenant/", "http://").GetTenant(tidval);
            }
            catch(Exception ex)
            {
                Console.WriteLine("tenant_error:" + ex.Message);
            }
            FormMultiTenant frmt = new FormMultiTenant();
            frmt.setTenant2(titem);
            frmt.ShowDialog();
            WKtenantId.Text = frmt.TenantId;
            getCommon();
        }

        private void getCommon()
        {
            getwitem.Clear();
            getwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem();
            if (getwitem.Count > 0)
            {
                WKSaveWorderId.Text = getwitem[0].WorkOrderId.ToString();
                frmWKMakeno.Tag = WKSaveWorderId.Text;
            }
            Int32 tlpColumCount = WKPanel.ColumnCount;
            Int32 tlpRowCount = WKPanel.RowCount;
            for (int i = WKPanel.Controls.Count - 1; i >= 0; --i)
                WKPanel.Controls[i].Dispose();
            WKPanel.Controls.Clear();
            List<Button> btnemplist = new List<Button>();
            if (getwitem.Count() > 0)
            {
                var empitemcount = 0;
                var keynum = 0;
                foreach (var empitem in getwitem)
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
                    empbtn = sethandlerD(empbtn);
                    empbtn.TabStop = false;
                    empbtn.TabIndex = 99;
                    btnemplist.Add(empbtn);
                }
                Console.WriteLine("btn=" + btnemplist.Count + "," + tlpColumCount + "," + tlpRowCount);
                var j = 0;
                var recordL = 0;
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
    }
}
