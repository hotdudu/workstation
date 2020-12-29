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
    public partial class frmPartner : Form
    {
        public frmPartner()
        {
            InitializeComponent();
        }
        List<Partner> getpt = new List<Partner>();
        private void frmPartner_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            var setpageup = new CreateElement();
            setpageup.SetBtn(frmPTbtnU, "Insert::Insert", "上一頁");
            setpageup.SetBtn(frmPTbtnD, "Delete::Delete", "下一頁");
            getpt = new API("/CHG/Main/Home/getPartner/", "http://").GetPartner(101);
            Int32 tlpColumCount = PTPanel.ColumnCount;
            Int32 tlpRowCount = PTPanel.RowCount;
            List<Button> btnemplist = new List<Button>();
            Console.WriteLine("ptlength=" + getpt.Count);
            if (getpt.Count() > 0)
            {
                var empitemcount = 0;
                var keynum = 0;
                foreach (var empitem in getpt)
                {
                    var prestr = "BTNfrmEmp";
                    empitemcount++;
                    if ((empitemcount - 1) != 0 && (empitemcount - 1) % (tlpRowCount * tlpColumCount) == 0)
                        keynum = 0;
                    keynum++;
                    var poststr = empitemcount.ToString("##");
                    var thisbtnname = prestr + poststr;
                    var thisbtntext = empitem.ShortName;
                    var btnkey = "F" + keynum;
                    Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreatePTBtn(empitem.PartnerNo, thisbtntext,empitem.PartnerId,btnkey);
                    empbtn = sethandler(empbtn);
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
                        PTPanel.Controls.Add(btnemplist[j], j, i);
                        frmPTRecordnow.Text = j.ToString();
                    }
                }
                frmPTRecordT.Text = recordL.ToString();
                Console.WriteLine("record=" + frmPTRecordnow.Text);
            }
        }

        public void SetEmpNO(string info)
        {
            var PTarray = info.Split(':');
            Console.WriteLine("ptl="+PTarray.Length);
            var ptno = PTarray[0];
            var ptid = PTarray[1];
            frmPTshowno.Text = ptno;
            PTSavePartnerId.Text =ptid;
            Console.WriteLine("ptno=" + frmPTshowno.Text + ",ptid=" + PTSavePartnerId.Text);

        }
        public Button sethandler(Button bt)
        {
            Button sbt = bt;
            sbt.Click += new EventHandler(btnEMPALL_Click);
            return sbt;
        }

        private void btnEMPALL_Click(object sender, EventArgs e)
        {
            Button tmpButton = (Button)sender;
            SetEmpNO(tmpButton.Tag.ToString());

        }

        private void frmPTbtnU_Click(object sender, EventArgs e)
        {
            Int32 tlpColumCount = PTPanel.ColumnCount;
            Int32 tlpRowCount = PTPanel.RowCount;
            List<Button> btnemplist = new List<Button>();
            int nowrecord = 0;
            int recordT = 0;
            bool trynowrecord = int.TryParse(frmPTRecordnow.Text, out nowrecord);
            bool tryrecordT = int.TryParse(frmPTRecordT.Text, out recordT);
            var looplimit = nowrecord - recordT;
            var loopinit = looplimit + 1 - (tlpColumCount * tlpRowCount);
            if (trynowrecord && looplimit > 0)
            {
                for (int i = PTPanel.Controls.Count - 1; i >= 0; --i)
                    PTPanel.Controls[i].Dispose();
                PTPanel.Controls.Clear();
            }
            Console.WriteLine("U-nowrecord=" + nowrecord);
            if (nowrecord > 0)
            {
                Console.WriteLine("U-getemp=" + getpt.Count());
                if (getpt.Count() > 0)
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
                            for (; j < getpt.Count && j < i + tlpColumCount; j++)
                            {
                                recordU++;
                                Console.WriteLine("U-i=" + i + ",j=" + j + ",name=" + getpt[j].ShortName + ",ri=" + reali + ",rj=" + realj);
                                var prestr = "BTNfrmEmp";
                                empitemcount++;
                                var keynum = j % (tlpColumCount * tlpRowCount) + 1;
                                var btnkey = "F" + keynum;
                                var poststr = empitemcount.ToString("##");
                                var thisbtnname = prestr + poststr;
                                var thisbtntext = getpt[j].ShortName;
                                Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreatePTBtn(getpt[j].PartnerNo, thisbtntext, getpt[j].PartnerId,btnkey);
                                empbtn = sethandler(empbtn);
                                PTPanel.Controls.Add(empbtn, realj, reali - 1);
                                frmPTRecordnow.Text = j.ToString();
                                realj++;
                            }
                        }
                        frmPTRecordT.Text = recordU.ToString();
                    }

                    Console.WriteLine("record=" + frmPTRecordnow.Text);
                }
            }
        }

        private void frmPTbtnD_Click(object sender, EventArgs e)
        {
            Int32 tlpColumCount = PTPanel.ColumnCount;
            Int32 tlpRowCount = PTPanel.RowCount;
            List<Button> btnemplist = new List<Button>();
            int nowrecord = 0;
            bool trynowrecord = int.TryParse(frmPTRecordnow.Text, out nowrecord);
            if (trynowrecord && nowrecord < getpt.Count - 1)
            {
                for (int i = PTPanel.Controls.Count - 1; i >= 0; --i)
                    PTPanel.Controls[i].Dispose();
                PTPanel.Controls.Clear();
            }
            Console.WriteLine("D-nowrecord=" + nowrecord);
            if (nowrecord > 0)
            {
                Console.WriteLine("D-getemp=" + getpt.Count());
                if (getpt.Count() > 0)
                {
                    var empitemcount = 0;
                    var j = nowrecord + 1;

                    Console.WriteLine("D-j=" + j + ",row=" + tlpRowCount + ",col=" + tlpColumCount);
                    if (j > 0 && nowrecord < getpt.Count - 1)
                    {
                        var reali = 0;
                        var recordD = 0;
                        Console.WriteLine("d-tlpRowCount=" + tlpRowCount);
                        for (var i = nowrecord + 1; i < (nowrecord + 1) + (tlpColumCount * tlpRowCount); i += tlpColumCount)
                        {
                            reali++;
                            var realj = 0;
                            for (; j < getpt.Count && j < i + tlpColumCount; j++)
                            {
                                recordD++;
                                Console.WriteLine("D-i=" + i + ",j=" + j + ",name=" + getpt[j].PartnerNo + ",ri=" + reali + ",rj=" + realj);
                                var prestr = "BTNfrmEmp";
                                empitemcount++;
                                empitemcount++;
                                var keynum = j % (tlpColumCount * tlpRowCount) + 1;
                                var btnkey = "F" + keynum;
                                var poststr = empitemcount.ToString("##");
                                var thisbtnname = prestr + poststr;
                                var thisbtntext = getpt[j].ShortName;
                                Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreatePTBtn(getpt[j].PartnerNo, thisbtntext, getpt[j].PartnerId,btnkey);
                                empbtn = sethandler(empbtn);
                                PTPanel.Controls.Add(empbtn, realj, reali - 1);
                                frmPTRecordnow.Text = j.ToString();
                                realj++;
                            }
                        }
                        frmPTRecordT.Text = recordD.ToString();
                    }

                    Console.WriteLine("record=" + frmPTRecordnow.Text);
                }
            }
        }
    }
}
