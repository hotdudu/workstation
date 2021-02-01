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
    public partial class frmPartner : Form
    {
        public frmPartner()
        {
            InitializeComponent();
        }
        List<Partner> getwitem = new List<Partner>();
        private void frmPartner_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            var setpageup = new CreateElement();
            setpageup.SetBtn(frmPTbtnU, "Insert::Insert", "上一頁");
            setpageup.SetBtn(frmPTbtnD, "Delete::Delete", "下一頁");
            getwitem = new API("/CHG/Main/Home/getPartner/", "http://").GetPartner(101);
            //Int32 tlpColumCount = PTPanel.ColumnCount;
            //Int32 tlpRowCount = PTPanel.RowCount;
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
                    var nowcate = getpropername(empitem.PartnerNo);
                    if (nowcate == "")
                    {
                        nowcate = empitem.CategoryName;
                        nowcate = nowcate.Substring(nowcate.IndexOf('-')+1);
                    }
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
                    var thisbtntext = empitem.ShortName;
                    Button empbtn = new CreateElement(thisbtnname, thisbtntext).CreatePTBtnWithXY(nowcate, thisbtntext, empitem.PartnerId, btnkey, iRow, iCol, iSpace, PTPanel);
                    empbtn = sethandler(empbtn);
                    if (keynum > totalitem)
                    {
                        empbtn.Visible = false;
                    }
                    empbtn.TabStop = false;
                    empbtn.TabIndex = 99;
                    btnemplist.Add(empbtn);
                }
                frmPTRecordnow.Text = "0";
            }
        }

        public void SetEmpNO(string info)
        {
            var PTarray = info.Split(':');
            Console.WriteLine("ptl="+PTarray.Length);
            var ptno = PTarray[0];
            var ptid = PTarray[1];
            var ptname = PTarray[2];
            frmPTshowno.Text = ptno;
            frmPTname.Text = ptname;
           // PTSavePartnerId.Text =ptid;//改成在輸入工序階段取得partnerid
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
                frmPTRecordnow.Text = nowrow.ToString();
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
    }
}
