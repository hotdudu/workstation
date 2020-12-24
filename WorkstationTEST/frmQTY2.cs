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
    public partial class frmQTY2 : Form
    {
        public frmQTY2()
        {
            InitializeComponent();
        }

        private void frmQTY_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> rtext = CreateElement.loadresx("WK");
            // SaveStat.Visible = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            var setpageup = new CreateElement();
            setpageup.SetBtn((XButton)save, "Insert::Insert", rtext["WKsave"]);
            Int32 tlpColumCount = NumPanel.ColumnCount;
            Int32 tlpRowCount = NumPanel.RowCount;
            int num = 10;
            string[] numlist = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ".","Clear" };
            string[] keylist = new string[] { "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", "Decimal", "Divide" };
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

    }
}
