using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
namespace WorkstationTEST
{
    public partial class Numpad : Form
    {
        private  SerialPort SP;
        public string result="";
        public Numpad(SerialPort sp,Point p)
        {
            InitializeComponent();
            SP = sp;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = p;
            this.KeyPreview = true;
            this.Activate();
            this.KeyDown += new KeyEventHandler(mybutton_Click);
        }

        private void Numpad_Load(object sender, EventArgs e)
        {
            List<Button> btnemplist = new List<Button>();
            var empitemcount = 0;
            Int32 tlpColumCount = NumPanel.ColumnCount;
            Int32 tlpRowCount = NumPanel.RowCount;
            int num = 10;
            string[] numlist = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ".", "Clear" };
            string[] keylist = new string[] { "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", "Decimal", "Divide" };
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
            var j = 0;
            for (var i = 0; i < tlpRowCount; i += tlpColumCount)
            {
                for (; j < btnemplist.Count && j < tlpColumCount * tlpRowCount; j++)
                {
                    Console.WriteLine("Lqty-i=" + i + ",j=" + j + ",name=" + btnemplist[j].Name + ",text=" + btnemplist[j].Text);
                    NumPanel.Controls.Add(btnemplist[j], j, i);
                   // frmNumRecordnow.Text = j.ToString();
                }
            }
        }

        public void SetEmpNO(string info)
        {
            if (info == "Clear")
            {
              //  frmNumshowno.Text = "";
            }
            else
            {
                //frmNumshowno.Text = frmNumshowno.Text + info;
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

        private void mybutton_Click(object sender, KeyEventArgs e)
        {
            Console.WriteLine("keycoe=" + e.KeyCode);
            setkeymap(e.KeyCode.ToString());
            //tmpb.PerformClick();
        }
        public void setkeymap(string keychar, string data = "", bool isp = false)
        {
            Console.WriteLine(",ind=" + keychar);
            var keyupper = keychar.ToString();
            if(keyupper== "Return")
            {
                Console.WriteLine("ok=" + textBox1.Text);
                this.result = textBox1.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
