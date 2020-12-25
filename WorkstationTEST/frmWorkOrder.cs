using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkstationTEST
{
    public partial class frmWorkOrder : Form
    {
        public frmWorkOrder()
        {
            InitializeComponent();
            Console.WriteLine("frmWK");

        }
        List<Workitem> getwitem = new List<Workitem>();
        List<WorkOrder> getworkorder = new List<WorkOrder>();
        private void frmWorkOrder_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> rtext = CreateElement.loadresx("WK");
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
            //ActiveControl = frmWKMakeno;
            Console.WriteLine("frmWKload");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            var setpageup = new CreateElement();
            setpageup.SetBtn((XButton)frmWKbtnU, "Insert::Insert", rtext[frmWKbtnU.Name]);
            setpageup.SetBtn((XButton)frmWKbtnD, "Delete::Delete", rtext[frmWKbtnD.Name]);
            setpageup.SetBtn((XButton)WKsave, "F12::F12", rtext[WKsave.Name]);

            getwitem.Clear();
            getwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem();
            if (getwitem.Count > 0)
            {
                WKSaveWorderId.Text = getwitem[0].WorkOrderId.ToString();
                frmWKMakeno.Tag = WKSaveWorderId.Text;
            }
            List<Button> btnemplist = new List<Button>();
            if (getwitem.Count() > 0)
            {
                int iSpace = 5;
                int iCol = 0;
                int iRow = 0;
                int ItemsOneRow = 5;
                int totalitem = 10;
                int btnnum = 0;
                var empitemcount = 0;
                var keynum = 0;
                foreach (var empitem in getwitem)
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
                    var thisbtntext = empitem.WorkName;
                    Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateWKBtnWithXY(empitem.WorkNo, thisbtntext, empitem.WorkOrderItemId, empitem.WorkId, btnkey,iRow,iCol,iSpace,WKPanel);
                    empbtn = sethandlerD(empbtn);
                    if (keynum > totalitem)
                    {
                        empbtn.Visible = false;
                    }
                    empbtn.TabStop = false;
                    empbtn.TabIndex = 99;
                    btnemplist.Add(empbtn);
                }
                frmWKRecordnow.Text = "0";
                Console.WriteLine("record=" + frmWKRecordnow.Text);
            }
        }


        private void frmWKMakeno_TextChanged(object sender, EventArgs e)
        {
            var text =  (sender as TextBox).Text;
            infotitle.Text = "";
            int iSpace = 5;
            int iCol = 0;
            int iRow = 0;
            int ItemsOneRow = 5;
            var totalitem = 10;
            if (text!="")
            {
                Console.WriteLine("text=" + text);
                string makeno = "";
                string wid = "";
                Console.WriteLine("m=" + text);
                if (text.IndexOf("::") >= 0)
                {
                    string[] data = text.Split(new string[] { "::" }, StringSplitOptions.None);
                     makeno = data[0];
                     wid = data[data.Length - 1];
                }
                //frmWKMakeno.Text = makeno;
                frmWKMakeno.Tag = wid;
                getwitem.Clear();
                WKPanel.Controls.Clear();
                getworkorder = new API("/CHG/Main/Home/getinfo/", "http://").GetWorkOrder(101,makeno);
                if (getworkorder.Count > 0)
                {
                    labSpec.Text = getworkorder[0].Specification;
                    labRemark.Text = getworkorder[0].Remark;
                    labPName.Text = getworkorder[0].AssetsNo;
                    labWorkOrder.Text = getworkorder[0].MakeNo;
                    labQty.Text = getworkorder[0].MakeQty.ToString();
                    labAssetsName.Text = getworkorder[0].AssetsName;
                    labUnit.Text = getworkorder[0].UseUnits;
                }
                else
                {
                    //MessageBox.Show("無此工令資料");
                    Console.WriteLine("無此工令資料");
                    //ActiveControl = this.frmWKMakeno;
                }
                Guid gwid ;
                var isguid = Guid.TryParse(wid, out gwid);
                if(isguid)
                     getwitem = new API("/CHG/Main/Home/getMakeno/", "http://").GetWorkitem(makeno,Guid.Parse(wid));
                else
                {
                    Console.WriteLine("輸入工令格式錯誤");
                    //ActiveControl = this.frmWKMakeno;
                }


                List<Button> btnemplist = new List<Button>();
                if (getwitem.Count() > 0)
                {
                    var empitemcount = 0;
                    var keynum = 0;
                    var btnnum = 0;
                    foreach (var empitem in getwitem)
                    {
                        iRow = keynum / ItemsOneRow;
                        iCol = keynum % ItemsOneRow;
                        var prestr = "BTNfrmEmp";
                        empitemcount++;
                        if (btnnum + 1 > totalitem)
                            btnnum = 0;
                        btnnum++;
                        keynum++;
                        var btnkey = "F" + btnnum;
                        var poststr = empitemcount.ToString("##");
                        var thisbtnname = prestr + poststr;
                        var thisbtntext = empitem.WorkName;
                        Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateWKBtnWithXY(empitem.WorkNo, thisbtntext,empitem.WorkOrderItemId,empitem.WorkId,btnkey,iRow,iCol,iSpace,WKPanel);
                        empbtn = sethandler(empbtn);
                        if (keynum > totalitem)
                        {
                            empbtn.Visible = false;
                        }
                        btnemplist.Add(empbtn);
                    }

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
                List<Button> btnemplist = new List<Button>();
                if (getwitem.Count() > 0)
                {

                    var empitemcount = 0;
                    var keynum = 0;
                    var btnnum = 0;
                    foreach (var empitem in getwitem)
                    {
                        iRow = keynum / ItemsOneRow;
                        iCol = keynum % ItemsOneRow;
                        var prestr = "BTNfrmEmp";
                        empitemcount++;
                        if (btnnum + 1 > totalitem)
                            btnnum = 0;
                        btnnum++;
                        keynum++;
                        var btnkey = "F" + btnnum;
                        var poststr = empitemcount.ToString("##");
                        var thisbtnname = prestr + poststr;
                        var thisbtntext = empitem.WorkName;
                        Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateWKBtnWithXY(empitem.WorkNo, thisbtntext, empitem.WorkOrderItemId, empitem.WorkId, btnkey,iRow,iCol,iSpace,WKPanel);
                        empbtn = sethandlerD(empbtn);
                        empbtn.TabStop = false;
                        empbtn.TabIndex = 99;
                        btnemplist.Add(empbtn);
                    }
                }
            }
           // frmWKMakeno.Select();
           // ActiveControl = frmWKMakeno;
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
            var nowrow = 0;
            var tempn = int.TryParse(frmWKRecordnow.Text, out nowrow);
            var totalitem = 10;
            if(nowrow>0)
                nowrow--;
            frmWKRecordnow.Text = nowrow.ToString();
            var startnum = nowrow * totalitem + 1;
            var endnum = (nowrow + 1) * totalitem;
            var npoint = 0;
            foreach (Control contr in WKPanel.Controls)
            {
                npoint++;
                if (npoint >= startnum && npoint <= endnum && npoint <= WKPanel.Controls.Count)
                {
                    contr.Visible = true;
                }
                else
                {
                    contr.Visible = false;
                }
            }

            var height = WKPanel.Height;
            var vheight = nowrow * WKPanel.Height;
            if (vheight - (height) < WKPanel.VerticalScroll.Minimum)
            { WKPanel.VerticalScroll.Value = WKPanel.VerticalScroll.Minimum; }
            else
            { WKPanel.VerticalScroll.Value = vheight; }
            WKPanel.PerformLayout();
        }

        private void frmWKbtnD_Click(object sender, EventArgs e)
        {
           var nowrow = 0;
            var tempn = int.TryParse(frmWKRecordnow.Text, out nowrow);
            var totalitem = 10;
            var totoalrow = Math.Ceiling(WKPanel.Controls.Count / (decimal)totalitem);
            nowrow++;
            if (nowrow < totoalrow)
                frmWKRecordnow.Text = nowrow.ToString();
            var startnum = nowrow * totalitem + 1;
            var endnum = (nowrow + 1) * totalitem;
            var npoint = 0;


            var height = WKPanel.Height;
            var vheight = WKPanel.Height * nowrow;
            if (nowrow < totoalrow)
            {
                foreach (Control contr in WKPanel.Controls)
                {
                    npoint++;
                    Console.Write("ptype=" + contr.GetType() + "," + WKPanel.Controls.Count);
                    if (npoint >= startnum && npoint <= endnum && npoint <= WKPanel.Controls.Count)
                    {
                        contr.Visible = true;
                    }
                    else
                    {
                        contr.Visible = false;
                    }
                }
                WKPanel.VerticalScroll.Value = vheight;
                WKPanel.PerformLayout();
            }
        }

        private void labSpec_Click(object sender, EventArgs e)
        {
          
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void infotitle_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
