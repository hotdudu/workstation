using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.google.zxing.qrcode;
using com.google.zxing.common;
using com.google.zxing;
using System.IO;

namespace WorkstationTEST
{
    public partial class frmCheck : Form
    {
        frmMain ParentForm;
        public frmCheck(frmMain PM)
        {
            InitializeComponent();
            ParentForm = PM;
        }

        private void frmCheck_Load(object sender, EventArgs e)
        {
            String code = "::A-Save";
            int QRheight = 90; //圖形高
            int QRwidth = 90; // 圖形寬
            ByteMatrix bm = new QRCodeWriter().encode(code, BarcodeFormat.QR_CODE, QRwidth, QRheight);
            Bitmap bp = bm.ToBitmap();
            btnSave.Image = bp;
            btnSave.Tag = code;
            code = "::A-Cancel";
            QRheight = 90; //圖形高
            QRwidth = 90; // 圖形寬
            bm = new QRCodeWriter().encode(code, BarcodeFormat.QR_CODE, QRwidth, QRheight);
            bp = bm.ToBitmap();
            btnCancel.Image = bp;
            btnCancel.Tag = code;
        }
        public void HideMe()
        {
            this.Hide();

        }

 

        private void btn_Click(object sender, EventArgs e)
        {
            //var tmpForm = (frmMain)this.ParentForm;
            Button tmpButton = (Button)sender;
            ParentForm.DisplayText((string)tmpButton.Tag);
        }
    }
}
