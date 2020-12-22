using com.google.zxing;
using com.google.zxing.common;
using com.google.zxing.qrcode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkstationTEST
{
    class CreateElement
    {
        public string bname;
        public string btext;
        public CreateElement(string name,string text)
        {
            this.bname = name;
            this.btext = text;
        }
        public CreateElement()
        {
            this.bname = "";
            this.btext = "";
        }
        public Button CreateBtn() {
            Button btn = new Button();
            btn.Name = bname;
            btn.Text = btext;
            btn.Size=  new Size(130, 110);
            btn.Margin = new Padding(50);
            btn.Tag = btext;
            btn.Image = SetQR(btext, 100, 100, "QR");
            btn.ImageAlign = ContentAlignment.TopCenter;
            btn.TextAlign = ContentAlignment.BottomCenter;
            return btn;
        }
        public Button CreateBtn(string str)
        {
            Button btn = new Button();
            btn.Name = bname;
            btn.Text = str;
            btn.Tag = btext;
            btn.Size = new Size(100, 100);
            btn.Margin = new Padding(0);
            return btn;
        }

        public TextBox CreateBtn(string str,bool isedit,int ind,bool visble)
        {
            TextBox btn = new TextBox();
            btn.Name = bname;
            btn.Text = str;
            btn.ReadOnly = !isedit;
            btn.Tag = btext;
            btn.Size = new Size(100, 100);
            if(isedit)
            {
             btn.TabIndex = ind;
            }
            else
            {
                btn.TabIndex = 999;
            }
            btn.Visible = visble;
            btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btn.Margin = new Padding(0);
            return btn;
        }

        public Button CreateBtn(string str,int margin,string key)
        {
            Button btn = new Button();
            btn.Name = bname;
            btn.Text = key+". "+str;
            btn.Tag = btext;
            btn.Size = new Size(100, 100);
            btn.Margin = new Padding(margin,0,0,50);
            var qr = btext + "::" + key;
            btn.Image = SetQR(qr, 100, 100, "QR");
            btn.ImageAlign = ContentAlignment.TopCenter;
            btn.TextAlign = ContentAlignment.BottomCenter;
            return btn;
        }
        public Button CreateNumBtn(string no,string key)
        {
            XButton btn = new XButton();
            var qr = no + "::" + key;
            btn.Name = bname;
            btn.LeftText = no;
            btn.Size = new Size(140, 140);
            btn.Margin = new Padding(10);
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TopText = key;
            btn.Tag = btext;
            btn.Image = SetQR(qr, 50, 50, "QR");

            return btn;
        }
        public Button CreateEmpBtn(string no, string name, Guid? empid, string key)
        {
            XButton btn = new XButton();
            btn.Name = bname;
            var qr = no + "::" + key;
            btn.LeftText = no + Environment.NewLine + name;
            btn.Size = new Size(160, 165);
            btn.Margin = new Padding(20, 50, 20, 50);           
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TopText = key;
            btn.Image = SetQR(qr, 50, 50, "QR");
            btn.Tag = no+":"+name;
            return btn;
        }
        public Button CreateWKBtn(string no, string name, Guid WitemId,Guid WorkId,string key)
        {
            var savestr = WitemId.ToString() + ":" + WorkId.ToString() +":"+name +":"+no;
            XButton btn = new XButton();
            btn.Name = bname;
            var qr = no + "::" + key;
            btn.LeftText = no + Environment.NewLine + name;
            btn.Size = new Size(160, 165);
            btn.Margin = new Padding(20, 20, 20, 20);
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TopText = key;
            btn.Image = SetQR(qr,50, 50, "QR");
            btn.Tag = savestr;
            return btn;
        }
        public Button CreateWKBtnWithXY(string no, string name, Guid WitemId, Guid WorkId, string key,int irow,int icol,int ispace,Control p)
        {
            var savestr = WitemId.ToString() + ":" + WorkId.ToString() + ":" + name + ":" + no;
            XButton btn = new XButton();
            btn.Name = bname;
            var qr = no + "::" + key;
            btn.LeftText = no + Environment.NewLine + name;
            btn.Size = new Size(140, 160);
            btn.Margin = new Padding(20, 20, 20, 20);
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TopText = key;
            btn.Image = SetQR(qr, 80, 80, "QR");
            btn.Tag = savestr;
            btn.Top = irow * (ispace * 2 + btn.Height) + ispace; ;
            btn.Left = icol * (ispace * 2 + btn.Width) + ispace;
            btn.Parent = p;
            return btn;
        }
        public Button CreatePTBtn(string no, string name, Guid PId,string key)
        {
            var savestr = no + ":" + PId.ToString();
            Console.WriteLine("PTbtn=" + savestr);
            XButton btn = new XButton();
            btn.Name = bname;
            var qr = no + "::" + key;
            btn.LeftText =name;
            btn.TopText = key;
            btn.Size = new Size(160, 165);
            btn.Margin = new Padding(20, 20, 20, 20);
            btn.Image = SetQR(qr, 100, 100, "QR");
            btn.Tag = savestr;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            return btn;
        }
        public void SetBtn(XButton btn,string no,string name)
        {
            var btnarray = no.Split(new string[] { "::" }, StringSplitOptions.None);
            var key = btnarray[1];
            Keys myEnum = (Keys)Enum.Parse(typeof(Keys), key);
            Console.WriteLine("myEnum=" + myEnum);
            btn.LeftText = name;
            btn.TopText = key;
            btn.Size = new Size(130, 110);
            btn.Image = SetQR(no, 50, 50, "QR");
            btn.Tag = no;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
        }
        public void SetBtn2(XButton btn, string no, string name)
        {
            var btnarray = no.Split(new string[] { "::" }, StringSplitOptions.None);
            var key = btnarray[1];
            Keys myEnum = (Keys)Enum.Parse(typeof(Keys), key);
            Console.WriteLine("myEnum=" + myEnum);
            btn.LeftText = name;
            btn.TopText = key;
            btn.Size = new Size(130, 110);
            btn.Tag = no;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
        }
        public Bitmap SetQR(string data, int targetHeight = 64, int targetWidth = 64, string codeMode = "QR")
        {
            ByteMatrix bm;
            Bitmap bp;
            bm = new QRCodeWriter().encode(data, BarcodeFormat.QR_CODE, targetWidth, targetHeight);
            bp = bm.ToBitmap();
            return bp;
        }

        public static Dictionary<string, string> loadresx(string formname = "")
        {
            Dictionary<string, string> namedic = new Dictionary<string, string>();
            var Lang = "";
            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                Lang = oTINI.getKeyValue("SYSTEM", "LANGUAGE");
            }
            var fname = formname == string.Empty ? "" : "-" + formname;
            string resxFile = Path.Combine(Application.StartupPath, "Resources-" + Lang + fname + ".resx");
            using (ResXResourceSet resxSet = new ResXResourceSet(resxFile))
            {
                IDictionaryEnumerator dict = resxSet.GetEnumerator();
                while (dict.MoveNext())
                {
                    string key = (string)dict.Key;
                    string value = resxSet.GetString(key);
                    // Retrieve resource by name.
                    namedic.Add(key, value);

                }
            }
            return namedic;
        }

    }

    public class XButton : Button
    {
        public XButton()
        {
            UseVisualStyleBackColor = false;
            TextImageRelation = TextImageRelation.ImageAboveText;
        }
        public override string Text
        {
            get { return ""; }
            set { base.Text = value; }
        }
        public string LeftText { get; set; }
        public string TopText { get; set; }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Rectangle rect = ClientRectangle;
            rect.Inflate(-5, -5);
            using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far })
            {
                using (Brush brush = new SolidBrush(ForeColor))
                {
                    Font f = new Font("", 14, FontStyle.Bold);
                    Font f2 = new Font("", 16, FontStyle.Bold);
                    pevent.Graphics.DrawString(LeftText, f, brush, rect, sf);
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    pevent.Graphics.DrawString(TopText, f2, brush, rect, sf);
                }
            }
        }
    }


}
