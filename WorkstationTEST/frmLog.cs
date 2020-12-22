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
    public partial class frmLog : Form
    {
        public frmLog()
        {
            InitializeComponent();
        }

        public void showMsg(string s)
        {
            //this.lstLOG.Items.Add(DateTime.Now.ToLocalTime()+" : "+s);
            this.lstLOG.Items.Insert(0, DateTime.Now.ToLocalTime() + " : " + s);
        }

        private void lstLOG_DoubleClick(object sender, EventArgs e)
        {
            lstLOG.Items.Clear();
        }
    }
}
