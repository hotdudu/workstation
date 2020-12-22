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
    public partial class frmRecord : Form
    {
        public frmRecord()
        {
            InitializeComponent();
        }

        private void frmRecord_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            var setpageup = new CreateElement();
            setpageup.SetBtn(frmPTbtnU, "Insert::Insert", "上一筆");
            setpageup.SetBtn(frmPTbtnD, "Delete::Delete", "下一筆");
            setpageup.SetBtn(save, "F12::F12", "儲存");
            setpageup.SetBtn(next, "Return::Return", "Enter");
            var ry = frmREno.Location.Y + frmREno.Height + 5;
            var rx = 10;
            var ny = ry + RPanel.Location.Y + 30;
            var nx = 10;
            RPanel.Location = new Point(rx, ry);
            NumPanel.Location = new Point(nx, ny);
            /*Int32 tlpColumCount = NumPanel.ColumnCount;
            Int32 tlpRowCount = NumPanel.RowCount;
            string[] numlist = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ".", "Clear" };
            string[] keylist = new string[] { "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", "Decimal", "Divide" };
            List<Button> btnemplist = new List<Button>();
            var empitemcount = 0;

            for (var empitem = 0; empitem < numlist.Length; empitem++)
            {
                var prestr = "BTNkey";
                empitemcount++;
                var poststr = empitemcount.ToString("##");
                var thisbtnname = prestr + keylist[empitem];
                var thisbtntext = numlist[empitem];
                var btnkey = keylist[empitem];
                Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreateNumBtn(numlist[empitem], keylist[empitem]);
                empbtn = sethandler(empbtn);
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
                   // frmNumRecordnow.Text = j.ToString();
                }
            }*/

        }

       /* public void SetEmpNO(string info)
        {
            //var act = ActiveControl;
            Console.Write("act=" + info);
            if (info == "Clear")
            {
               // frmNumshowno.Text = "";
            }
            else
            {
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

        }*/


        private void frmPTbtnU_Click(object sender, EventArgs e)
        {

        }

        private void frmPTbtnD_Click(object sender, EventArgs e)
        {

        }
    }
}
