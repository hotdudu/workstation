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
    public partial class frmWorkTime2 : Form
    {
        public frmWorkTime2(string unit)
        {
            InitializeComponent();
            Unit = unit;
        }
        public string Unit;
        Dictionary<string, string> rtext = CreateElement.loadresx();
        Dictionary<string, string> rtext2 = CreateElement.loadresx("WK");
        private void frmWorkTime_Load(object sender, EventArgs e)
        {
            label7.Text = rtext2["infotitle"];
            label13.Text = rtext2["label7"];

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            var setpageup = new CreateElement();
            setpageup.SetBtn(save, "F12::F12", "儲存");
            var tableheadstr = new string[] {};
            var textarray = new string[] { };
            if (Unit=="Set")
            {
                tableheadstr = new string[] {rtext["worktime"] ,"Go" + rtext["completeqty"], "NoGo" + rtext["completeqty"], "Go" + rtext["badqty"], "NoGo" + rtext["badqty"]};
                textarray = new string[] { "WorkTime", "GoCompleteQty", "NoGoCompleteQty", "GoBadQty", "NoGoBadQty" };

            }
            else
            {
                tableheadstr = new string[] { rtext["worktime"] , rtext["completeqty"], rtext["badqty"], };
                textarray = new string[] { "WorkTime", "CompleteQty", "BadQty" };
            }
            /*for (int i = RPanel.Controls.Count - 1; i >= 0; --i)
                RPanel.Controls[i].Dispose();
            RPanel.Controls.Clear();*/
           /* for (var a = 0; a < tableheadstr.Count(); a++)
            {
                TextBox templab = new TextBox();
                templab.Text = tableheadstr[a];
                templab.ReadOnly = true;
                templab.Margin = new Padding(0);
                templab.TabIndex = 999;
                templab.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
                RPanel.Controls.Add(templab, a, 0);
                TextBox numbox = new TextBox();
                numbox.Name = textarray[a];
                numbox.TabIndex = a + 1;
                numbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
                numbox.GotFocus += new EventHandler(BtnGotfocus);
                RPanel.Controls.Add(numbox, a, 1);
            }
            */
            Int32 tlpColumCount = NumPanel.ColumnCount;
            Int32 tlpRowCount = NumPanel.RowCount;
            int num = 10;
            string[] numlist = new string[] {"1", "2", "3", "4", "5", "6", "7", "8", "9","0" ,".","Clear" };
            string[] keylist = new string[] { "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", "Decimal", "Divide" };
            List<Button> btnemplist = new List<Button>();
            var empitemcount = 0;

            for (var empitem = 0; empitem < numlist.Length; empitem++)
            {
                var prestr = "BTNfrmEmp";
                empitemcount++;
                var poststr = empitemcount.ToString("##");
                var thisbtnname = prestr + poststr;
                var thisbtntext = numlist[empitem];
                var btnkey = keylist[empitem];
                Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateNumBtn(numlist[empitem], keylist[empitem]);
                empbtn = sethandler(empbtn);
                empbtn.TabStop = false;
                btnemplist.Add(empbtn);
            }
            Console.WriteLine("qtybtn=" + btnemplist.Count + "," + tlpColumCount + "," + tlpRowCount);
            var j = 0;
            for (var i = 0; i < tlpRowCount; i += tlpColumCount)
            {
                for (; j < btnemplist.Count && j < tlpColumCount * tlpRowCount; j++)
                {
                    Console.WriteLine("Lqty-i=" + i + ",j=" + j + ",name=" + btnemplist[j].Name + ",text=" + btnemplist[j].Text);
                    NumPanel.Controls.Add(btnemplist[j], j, i);
                    frmNumRecordnow.Text = j.ToString();
                }
            }
            Console.WriteLine("record=" + frmNumRecordnow.Text);
        }

        public void SetEmpNO(string info)
        {
            var nowfocusc = this.Controls.Find(focust.Text, true);
            /* Control actfocused = null;
             if (act1.Length > 0)
             {
                 actfocused = act1[0].Focused ? act1[0] : (act2[0].Focused ? act2[0] : (act3[0].Focused ? act3[0] : (act4[0].Focused ? act4[0] : act1[0])));
             }
             if (act5.Length > 0)
             {
                 actfocused = act5[0].Focused ? act5[0] : (act6[0].Focused ? act6[0] : act6[5]);
             }
             Console.Write("actfocus=" +actfocused.Name);*/
            if (info == "Clear")
            {
                if (nowfocusc.Length > 0)
                    nowfocusc[0].Text = "";
                // actfocused.Text = "";
                // frmNumshowno.Text = "";
            }
            else
            {
                if (nowfocusc.Length > 0)
                    nowfocusc[0].Text = nowfocusc[0].Text+ info;
                //  if (nowfocusc.Length > 0) 
                //    nowfocusc[0].Text = nowfocusc[0].Text + info;
                // actfocused.Text = actfocused.Text+info;
                // frmNumshowno.Text = frmNumshowno.Text + info;
            }
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

        private void BtnGotfocus(object sender, EventArgs e)
        {
            TextBox tmpButton = (TextBox)sender;
            focust.Text = tmpButton.Name;
            Console.Write("gotfocus=" +focust.Text);
        }
    }
}
