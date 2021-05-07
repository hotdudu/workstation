﻿using com.google.zxing;
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

        public TextBox CreateBtn(string str,bool isedit,int ind,bool visble,int width=100,int height=100,bool isauto=false)
        {
            TextBox btn = new TextBox();
            btn.Name = bname;
            btn.Text = str;
            btn.ReadOnly = !isedit;
            btn.Tag = btext;
            if (!isauto)
            {
                btn.Size = new Size(width, height);
            }
            else
            {
                
            }
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

        public Button CreateReturnBtn(string str, bool isedit, int ind, bool visble, int width = 100, int height = 100)
        {
            Button btn = new Button();
            btn.Name = bname;
            btn.Text = str;
            btn.Tag = btext;
            btn.Size = new Size(width, height);
            if (isedit)
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
            btn.Margin = new Padding(5,0,5,0);
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TopText = key;
            btn.Tag = btext;
            btn.Image = SetQR(qr, 80, 80, "QR");

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
            btn.Image = SetQR(qr, 80, 80, "QR");
            btn.Tag = no+":"+name;
            return btn;
        }
        public Button CreateEmpBtnm(string no, string name, Guid? empid, string key,bool IsMultiple,string rno,string rtenant)
        {
            XButton btn = new XButton();
            btn.Name = bname;
            var qr = no + "::" + key;
            btn.LeftText = no + Environment.NewLine + name;
            btn.Size = new Size(160, 165);
            btn.Margin = new Padding(20, 15, 20, 15);
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TopText = key;
            btn.Image = SetQR(qr, 80, 80, "QR");
            if(IsMultiple)
            {
                btn.Tag = no + ":" + name + ":" + rno + ":" + rtenant;
            }
            else
            {
                btn.Tag = no + ":" + name;
            }

            return btn;
        }
        public Button CreateEmpBtnm_panel(string no, string name, Guid? empid, string key, bool IsMultiple, string rno, string rtenant, int irow, int icol, int ispace, Control p)
        {
            XButton btn = new XButton();
            btn.Name = bname;
            var qr = no + "::" + key;
            btn.LeftText = no + Environment.NewLine + name;
            btn.Size = new Size(160, 165);
            btn.Margin = new Padding(20, 15, 20, 15);
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TopText = key;
            btn.Image = SetQR(qr, 80, 80, "QR");
            if (IsMultiple)
            {
                btn.Tag = no + ":" + name + ":" + rno + ":" + rtenant;
            }
            else
            {
                btn.Tag = no + ":" + name;
            }
            btn.Top = irow * (ispace * 2 + btn.Height) + ispace;
            btn.Left = icol * (ispace + btn.Width);
            btn.Parent = p;
            return btn;
        }
        public Button CreateEmpBtnWithXY(string no, string name, Guid? empid, string key, int irow, int icol, int ispace, Control p)
        {
            XButton btn = new XButton();
            btn.Name = bname;
            var qr = no + "::" + key;
            btn.LeftText = no + Environment.NewLine + name;
            btn.Size = new Size(160, 165);
            btn.Margin = new Padding(0, 20, 0, 20);
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TopText = key;
            btn.Image = SetQR(qr, 80, 80, "QR");
            btn.Tag = no + ":" + name;
            btn.Top = irow * (ispace * 2 + btn.Height) + ispace;
            btn.Left = icol * (ispace + btn.Width);
            btn.Parent = p;
            return btn;
        }
        public Button CreateMachine(string no, string name, Guid? empid, string key, int irow, int icol, int ispace, Control p)
        {
            XButton btn = new XButton();
            btn.Name = bname;
            var qr = no + "::" + key;
            btn.LeftText = no + Environment.NewLine + name;
            btn.Size = new Size(160, 165);
            btn.Margin = new Padding(0, 20, 0, 20);
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TopText = key;
            btn.Image = SetQR(qr, 80, 80, "QR");
            btn.Tag = no + ":" + name+":"+empid;
            btn.Top = irow * (ispace * 2 + btn.Height) + ispace;
            btn.Left = icol * (ispace + btn.Width);
            btn.Parent = p;
            return btn;
        }
        public Button CreateWKBtn(string no, string name, Guid WitemId,Guid WorkId,string key)
        {
            var savestr = WitemId.ToString() + ":" + WorkId.ToString() +":"+name +":"+no;
            XButton btn = new XButton();
            btn.Name = bname;
            var qr = no + "::" + key;
            btn.LeftText = no + Environment.NewLine + name;
            btn.Size = new Size(170, 150);
            btn.Margin = new Padding(5, 15, 5, 15);
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TopText = key;
            btn.Image = SetQR(qr,80, 80, "QR");
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
            btn.Size = new Size(190, 150);
            btn.Margin = new Padding(0, 15, 0, 15);
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TopText = key;
            btn.Image = SetQR(qr, 80, 80, "QR");
            btn.Tag = savestr;
            btn.Top = irow * (ispace * 2 + btn.Height) + ispace; ;
            btn.Left = icol * (ispace + btn.Width);
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
            btn.LeftText = no + Environment.NewLine + name;
            btn.TopText = key;
            btn.Size = new Size(190, 150);
            btn.Margin = new Padding(0, 20, 0, 20);
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TopText = key;
            btn.Image = SetQR(qr, 80, 80, "QR");
            btn.Tag = savestr;

            return btn;
        }

        public Button CreatePTBtnWithXY(string cate, string name,string rno, Guid PId, string key, int irow, int icol, int ispace, Control p)
        {
            var savestr = cate + ":" + PId.ToString()+":"+name+":"+rno;
            Console.WriteLine("PTbtn=" + savestr);
            XButton btn = new XButton();
            btn.Name = bname;
            var qr = rno + "::" + key;
            btn.LeftText = name+Environment.NewLine+cate;
            btn.TopText = key;
            btn.Size = new Size(190, 170);
            btn.Margin = new Padding(0, 20, 0, 20);
            btn.Image = SetQR(qr, 100, 100, "QR");
            btn.Tag = savestr;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.Top = irow * (ispace * 2 + btn.Height) + ispace;
            btn.Left = icol * (ispace + btn.Width);
            btn.Parent = p;
            return btn;
        }

        public Button CreatePTBtnWithXYr(string cate, string name, string rno, Guid PId, string key, int irow, int icol, int ispace, Control p,bool IsMultiple,string rarray,string tenant,string PIds)
        {
            var savestr = cate + ":" + PId.ToString() + ":" + name + ":" + rno;
            if (IsMultiple)
            {
                savestr+= ":" + rarray + ":" + tenant+":"+PIds;
            }
            Console.WriteLine("PTbtn=" + savestr);
            XButton btn = new XButton();
            btn.Name = bname;
            var qr = rno + "::" + key;
            btn.LeftText = name + Environment.NewLine + cate;
            btn.TopText = key;
            btn.Size = new Size(190, 170);
            btn.Margin = new Padding(0, 20, 0, 20);
            btn.Image = SetQR(qr, 100, 100, "QR");
            btn.Tag = savestr;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.Top = irow * (ispace * 2 + btn.Height) + ispace;
            btn.Left = icol * (ispace + btn.Width);
            btn.Parent = p;
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
            btn.Size = new Size(195, 110);
            btn.Image = SetQR(no, 80, 80, "QR");
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
                    pevent.Graphics.DrawString(LeftText, f, brush, rect, sf);

                }
                var fcolor = Color.CadetBlue;
                using (Brush brush2 = new SolidBrush(fcolor))
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    Font f2 = new Font("", 16, FontStyle.Bold);
                    pevent.Graphics.DrawString(TopText, f2, brush2, rect, sf);
                }
            }
        }
    }


}
