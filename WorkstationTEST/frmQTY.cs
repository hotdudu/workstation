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
    public partial class frmQTY : Form
    {
        public frmQTY()
        {
            InitializeComponent();
        }

        private void frmQTY_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> rtext = CreateElement.loadresx("WK");

            // SaveStat.Visible = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            var setpageup = new CreateElement();
            setpageup.SetBtn((XButton)save, "F12::F12", rtext["WKsave"]);
            setpageup.SetBtn((XButton)btnoutside, "F11::F11", "勾選");
            Int32 tlpColumCount = NumPanel.ColumnCount;
            Int32 tlpRowCount = NumPanel.RowCount;
            int num = 10;
            var tableheadstr = new string[] { "數量", "單價"};
            var textarray = new string[] { "outqty", "price"};
            string[] numlist = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ".","Clear" };
            string[] keylist = new string[] { "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", "Decimal", "Divide" };
            for (var a = 0; a < tableheadstr.Count(); a++)
            {
                TextBox templab = new TextBox();
                templab.Text = tableheadstr[a];
                templab.ReadOnly = true;
                templab.Margin = new Padding(0);
                templab.TabIndex = 999;
                templab.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
                RIPanel.Controls.Add(templab, a, 0);
                TextBox numbox = new TextBox();
                numbox.Name = textarray[a];
                numbox.TabIndex = a + 1;
                numbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
                numbox.GotFocus += new EventHandler(BtnGotfocus);
                RIPanel.Controls.Add(numbox, a, 1);
            }
            List<Button> btnemplist = new List<Button>();
                var empitemcount = 0;
                
                for (var empitem=0;empitem<numlist.Length;empitem++)
                {
                    var prestr = "BTNfrmEmp";
                    empitemcount++;
                    var poststr = empitemcount.ToString("##");
                    var thisbtnname = prestr + poststr;
                    var thisbtntext = numlist[empitem];
                    var btnkey = keylist[empitem];
                    Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateNumBtn(numlist[empitem],keylist[empitem]);
                    empbtn = sethandler(empbtn);
                    btnemplist.Add(empbtn);
                }
                Console.WriteLine("qtybtn=" + btnemplist.Count + "," + tlpColumCount + "," + tlpRowCount);
                var j = 0;
                for (var i = 0; i < tlpRowCount; i += tlpColumCount)
                {
                    for (; j < btnemplist.Count && j < tlpColumCount * tlpRowCount; j++)
                    {
                        Console.WriteLine("Lqty-i=" + i + ",j=" + j + ",name=" + btnemplist[j].Name+",text="+ btnemplist[j].Text);
                        NumPanel.Controls.Add(btnemplist[j], j, i);
                        frmNumRecordnow.Text = j.ToString();
                    }
                }
                Console.WriteLine("record=" + frmNumRecordnow.Text);



        }

        public void SetEmpNO(string info)
        {
            if (info == "Clear")
            {
                frmNumshowno.Text = "";
            }
            else
            {
                frmNumshowno.Text = frmNumshowno.Text+info;
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

        private void btnoutside_Click(object sender, EventArgs e)
        {
            if (chkouside.Checked == true)
                chkouside.Checked = false;
            else
                chkouside.Checked = true;

        }

        private void BtnGotfocus(object sender, EventArgs e)
        {
            TextBox tmpButton = (TextBox)sender;
            focust.Text = tmpButton.Name;
        }

        private void Qpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
