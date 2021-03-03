﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkstationTEST
{
    public class API
    {

        public string URL;
        public string apiip;
        public string dbip;
        public string COMPORT;
        private string Empdef;
        private int timeout;
        public API(string url) {
            URL = url;
            timeout = 20000;
        }
        public API(string url, string title)
        {
            var sIP = "";
            var sComport = "";
            var ndbip = "";
            var getconf = false;
            int apitimeout = 20000;
            try
            {

                string cPath = Directory.GetCurrentDirectory() + "\\" + "config.ini";
                if (File.Exists(cPath))
                {
                    string[] lines = System.IO.File.ReadAllLines(@cPath);
                    foreach (string line in lines)
                    {
                        var linear = line.Split('=');
                        if (linear.Length == 2)
                        {
                            if (linear[0] == "IP")
                            {
                                sIP = linear[1];
                                getconf = true;
                            }
                            if (linear[0] == "COMPORT")
                            {
                                sComport = "COM" + linear[1];
                                getconf = true;
                            }
                            if (linear[0] == "Dbip")
                            {
                                ndbip = linear[1];
                                getconf = true;
                            }
                            if (linear[0] == "Empdef")
                            {
                                Empdef = linear[1];
                            }
                            if (linear[0] == "Timeout")
                            {
                                var tryint = int.TryParse(linear[1], out apitimeout);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("api error:" + ex);
            }
            if (!getconf)
            {
                sIP = "61.221.176.176";
                sComport = "COM4";
                ndbip = "59.125.158.96";
            }

            var tip = title + sIP + url;
            Console.WriteLine("ip:" + sIP + ",scom=" + sComport + ",tip=" + tip);
            URL = tip;
            apiip = sIP;
            dbip = ndbip;
            COMPORT = sComport;
            timeout = apitimeout;
        }
        public List<Emp> GetEmp()
        {
            var load = new loading();
            load.Show();
            var client = new HttpClient();
            var actrequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(this.URL),
                Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("tenantid","101"),
                new KeyValuePair<string, string>("iswork","true"),
                })
            };//"http://localhost:56893/CHG/Main/Home/getEmployee/"
            actrequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = client.SendAsync(actrequest).GetAwaiter().GetResult();
            List<Emp> empobj = new List<Emp>();
            var defemplist = Empdef.Split(',');
            if (res.StatusCode.ToString() == "OK")
            {
                //string r = res.Content.ReadAsStringAsync().Result.ToString();
                // Message MS = JsonConvert.DeserializeObject<Message>(r);
                // var Result = JsonConvert.SerializeObject(MS);
                empobj = JsonConvert.DeserializeObject<List<Emp>>(res.Content.ReadAsStringAsync().Result);
                Console.WriteLine("def=" + defemplist.Length);
                if (empobj.Count > 0)
                {
                    empobj = empobj.Where(x => defemplist.Contains(x.EmployeeNo)).OrderBy(x => x.EmployeeNo).ToList();
                }
                foreach (var item in empobj)
                {
                    Console.WriteLine("r=" + item.FullName);
                }
                load.Close();
            }
            else
            {
                load.Close();
                MessageBox.Show("伺服器連線異常");
                Console.WriteLine("伺服器連線異常");
            }
            return empobj;
        }

        public List<Workitem> GetWorkitem(int tid,string makeno, Guid wid)
        {
            var load = new loading();
            load.Show();
            var istimeout = false;
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(timeout);
            var actrequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(this.URL),
                Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("tenantid",tid.ToString()),
                new KeyValuePair<string, string>("makeno",makeno),
                new KeyValuePair<string, string>("wid",wid.ToString()),
                })
            };//"http://localhost:56893/CHG/Main/Home/getMakeno/"
            actrequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Workitem> witemobj = new List<Workitem>();
            try
            {
                HttpResponseMessage res = client.SendAsync(actrequest).GetAwaiter().GetResult();

                if (res.StatusCode.ToString() == "OK")
                {
                    load.Close();
                    //string r = res.Content.ReadAsStringAsync().Result.ToString();
                    // Message MS = JsonConvert.DeserializeObject<Message>(r);
                    // var Result = JsonConvert.SerializeObject(MS);
                    witemobj = JsonConvert.DeserializeObject<List<Workitem>>(res.Content.ReadAsStringAsync().Result);
                    foreach (var item in witemobj)
                    {
                        Console.WriteLine("r=" + item.WorkName);
                    }

                }
                else
                {
                    load.Close();
                    MessageBox.Show("伺服器連線異常");
                    Console.WriteLine("伺服器連線異常");
                }
            }
            catch (OperationCanceledException oex)
            {
                load.Close();
                MessageBox.Show("伺服器連線逾時:" + oex.Message);
            }

            return witemobj;
        }

        public List<Workitem> GetWorkitem()
        {
            var load = new loading();
            load.Show();
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(timeout);
            var actrequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(this.URL),
            };//"http://localhost:56893/CHG/Main/Home/getMakeno/"
            actrequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Workitem> witemobj = new List<Workitem>();
            try
            {
                HttpResponseMessage res = client.SendAsync(actrequest).GetAwaiter().GetResult();

                if (res.StatusCode.ToString() == "OK")
                {
                    load.Close();
                    //string r = res.Content.ReadAsStringAsync().Result.ToString();
                    // Message MS = JsonConvert.DeserializeObject<Message>(r);
                    // var Result = JsonConvert.SerializeObject(MS);
                    witemobj = JsonConvert.DeserializeObject<List<Workitem>>(res.Content.ReadAsStringAsync().Result);
                    foreach (var item in witemobj)
                    {
                        Console.WriteLine("r=" + item.WorkName);
                    }

                }
                else
                {
                    load.Close();
                    MessageBox.Show("伺服器連線異常");
                }
            }
            catch (OperationCanceledException oex)
            {
                load.Close();
                MessageBox.Show("伺服器連線逾時:" + oex.Message);
            }

            return witemobj;
        }
        public List<WorkOrder> GetWorkOrder(int? tenantid, string makeno)
        {
            var client = new HttpClient();
            var actrequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(this.URL),
                Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("makeno",makeno),
                new KeyValuePair<string, string>("tenantid",tenantid.ToString()),
                })
            };//"http://localhost:56893/CHG/Main/Home/getinfo/"
            actrequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = client.SendAsync(actrequest).GetAwaiter().GetResult();
            List<WorkOrder> witemobj = new List<WorkOrder>();
            if (res.StatusCode.ToString() == "OK")
            {
                //string r = res.Content.ReadAsStringAsync().Result.ToString();
                // Message MS = JsonConvert.DeserializeObject<Message>(r);
                // var Result = JsonConvert.SerializeObject(MS);
                witemobj = JsonConvert.DeserializeObject<List<WorkOrder>>(res.Content.ReadAsStringAsync().Result);
                foreach (var item in witemobj)
                {
                    Console.WriteLine("r=" + item.Specification);
                }

            }
            else
            {
                Console.WriteLine("伺服器連線異常");
            }
            return witemobj;
        }

        public List<WorkOrderO> GetWorkOrderO(int? tenantid, string makeno)
        {
            var client = new HttpClient();
            var actrequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(this.URL),
                Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("makeno",makeno),
                new KeyValuePair<string, string>("tenantid",tenantid.ToString()),
                })
            };//"http://localhost:56893/CHG/Main/Home/getinfo/"
            actrequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = client.SendAsync(actrequest).GetAwaiter().GetResult();
            List<WorkOrderO> witemobj = new List<WorkOrderO>();
            if (res.StatusCode.ToString() == "OK")
            {
                //string r = res.Content.ReadAsStringAsync().Result.ToString();
                // Message MS = JsonConvert.DeserializeObject<Message>(r);
                // var Result = JsonConvert.SerializeObject(MS);
                witemobj = JsonConvert.DeserializeObject<List<WorkOrderO>>(res.Content.ReadAsStringAsync().Result);
                foreach (var item in witemobj)
                {
                    Console.WriteLine("r=" + item.Specification);
                }

            }
            else
            {
                Console.WriteLine("伺服器連線異常");
            }
            return witemobj;
        }
        public List<Partner> GetPartner(int? tenantid)
        {
            var client = new HttpClient();
            var actrequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(this.URL),
                Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("tenantid",tenantid.ToString()),
                })
            };//"http://localhost:56893/CHG/Main/Home/getMakeno/"
            actrequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = client.SendAsync(actrequest).GetAwaiter().GetResult();
            List<Partner> witemobj = new List<Partner>();
            if (res.StatusCode.ToString() == "OK")
            {
                //string r = res.Content.ReadAsStringAsync().Result.ToString();
                // Message MS = JsonConvert.DeserializeObject<Message>(r);
                // var Result = JsonConvert.SerializeObject(MS);
                witemobj = JsonConvert.DeserializeObject<List<Partner>>(res.Content.ReadAsStringAsync().Result);
                foreach (var item in witemobj)
                {
                    Console.WriteLine("r=" + item.ShortName);
                }

            }
            else
            {
                Console.WriteLine("伺服器連線異常");
            }
            return witemobj;
        }

        public List<Partner> GetPartner2(int tenantid,string pno)
        {
            var client = new HttpClient();
            var actrequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(this.URL),
                Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("tenantid",tenantid.ToString()),
                new KeyValuePair<string, string>("pno",pno),
                })
            };
            actrequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = client.SendAsync(actrequest).GetAwaiter().GetResult();
            List<Partner> witemobj = new List<Partner>();
            if (res.StatusCode.ToString() == "OK")
            {
                //string r = res.Content.ReadAsStringAsync().Result.ToString();
                // Message MS = JsonConvert.DeserializeObject<Message>(r);
                // var Result = JsonConvert.SerializeObject(MS);
                witemobj = JsonConvert.DeserializeObject<List<Partner>>(res.Content.ReadAsStringAsync().Result);
                foreach (var item in witemobj)
                {
                    Console.WriteLine("r=" + item.ShortName);
                }

            }
            else
            {
                Console.WriteLine("伺服器連線異常");
            }
            return witemobj;
        }
        public List<Tenant> GetTenant(int? tenantid)
        {
            var client = new HttpClient();
            var actrequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(this.URL),
                Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("tenantid",tenantid.ToString()),
                })
            };
            actrequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = client.SendAsync(actrequest).GetAwaiter().GetResult();
            List<Tenant> tobj = new List<Tenant>();
            if (res.StatusCode.ToString() == "OK")
            {
                //string r = res.Content.ReadAsStringAsync().Result.ToString();
                // Message MS = JsonConvert.DeserializeObject<Message>(r);
                // var Result = JsonConvert.SerializeObject(MS);
                tobj = JsonConvert.DeserializeObject<List<Tenant>>(res.Content.ReadAsStringAsync().Result);
                foreach (var item in tobj)
                {
                    Console.WriteLine("t=" + item.ShortName);
                }

            }
            else
            {
                Console.WriteLine("伺服器連線異常");
            }
            return tobj;
        }
        public returnmsg UploadServer(WorkDayReport wdr)
        {
            var client = new HttpClient();
            /* List<KeyValuePair<string, object>> keyValues = new List<KeyValuePair<string, object>>();
             keyValues.Add(new KeyValuePair<string, object>("EmployeeId", wdr.EmployeeId));
             keyValues.Add(new KeyValuePair<string, object>("BadQty", wdr.BadQty));
             keyValues.Add(new KeyValuePair<string, object>("CompleteQty", wdr.CompleteQty));
             keyValues.Add(new KeyValuePair<string, object>("DayReportId", wdr.DayReportId));
             keyValues.Add(new KeyValuePair<string, object>("EmpNo", wdr.EmpNo));
             keyValues.Add(new KeyValuePair<string, object>("MakeNo", wdr.MakeNo));
             keyValues.Add(new KeyValuePair<string, object>("MNo", wdr.MNo));
             keyValues.Add(new KeyValuePair<string, object>("TenantId", wdr.TenantId));
             keyValues.Add(new KeyValuePair<string, object>("WorkId", wdr.WorkId));
             keyValues.Add(new KeyValuePair<string, object>("WorkNo", wdr.WorkNo));
             keyValues.Add(new KeyValuePair<string, object>("WorkOrderId", wdr.WorkOrderId));
             keyValues.Add(new KeyValuePair<string, object>("WorkOrderItemId", wdr.WorkOrderItemId));
             keyValues.Add(new KeyValuePair<string, object>("WorkTime", wdr.WorkTime));
             keyValues.Add(new KeyValuePair<string, object>("StartTime", wdr.StartTime));*/

            var keyValues = new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("EmployeeId", wdr.EmployeeId),
                new KeyValuePair<string, string>("BadQty", wdr.BadQty.HasValue?wdr.BadQty.ToString():""),
                new KeyValuePair<string, string>("CompleteQty", wdr.CompleteQty.HasValue?wdr.CompleteQty.ToString():""),
                new KeyValuePair<string, string>("BadGoQty", wdr.BadGoQty.HasValue?wdr.BadGoQty.ToString():""),
                new KeyValuePair<string, string>("CompleteGoQty", wdr.CompletGoQty.HasValue?wdr.CompletGoQty.ToString():""),
                new KeyValuePair<string, string>("BadNgQty", wdr.BadNgQty.HasValue?wdr.BadNgQty.ToString():""),
                new KeyValuePair<string, string>("CompletNgQty", wdr.CompletNgQty.HasValue?wdr.CompletNgQty.ToString():""),

                new KeyValuePair<string,string>("DayReportId", wdr.DayReportId),
                new KeyValuePair<string, string>("EmpNo", wdr.EmpNo),
                new KeyValuePair<string, string>("MakeNo", wdr.MakeNo),
                new KeyValuePair<string, string>("MNo", wdr.MNo),
                new KeyValuePair<string, string>("TenantId", wdr.TenantId.ToString()),
                new KeyValuePair<string, string>("WorkId", wdr.WorkId),
                new KeyValuePair<string, string>("WorkNo", wdr.WorkNo),
                new KeyValuePair<string, string>("WorkOrderId", wdr.WorkOrderId),
                new KeyValuePair<string, string>("WorkOrderItemId", wdr.WorkOrderItemId),
                new KeyValuePair<string, string>("WorkTime", wdr.WorkTime.HasValue?wdr.WorkTime.ToString():""),
                new KeyValuePair<string, string>("StartTime", wdr.StartTime.HasValue?wdr.StartTime.ToString():""),
                 new KeyValuePair<string, string>("EndTime", wdr.EndTime.HasValue?wdr.EndTime.ToString():"")
                };
            var actrequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(this.URL),
                Content = new FormUrlEncodedContent(keyValues),

            };
            actrequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Guid? dayid = null;
            var ermsg = "";
            var result = new returnmsg();
            try
            {

            }
            catch(Exception ex)
            {
                if (ex is TaskCanceledException)
                {

                    result.ermsg = "連線逾時";
                    return result;
                }
                else
                {
                    result.ermsg = "伺服器發生錯誤";
                    return result;
                }
            }

            HttpResponseMessage res = client.SendAsync(actrequest).GetAwaiter().GetResult();

            if (res.StatusCode.ToString() == "OK")
            {
                //string r = res.Content.ReadAsStringAsync().Result.ToString();
                // Message MS = JsonConvert.DeserializeObject<Message>(r);
                // var Result = JsonConvert.SerializeObject(MS);

                dayid = JsonConvert.DeserializeObject<Guid>(res.Content.ReadAsStringAsync().Result);
            }
            else if(res.StatusCode.ToString()== "BadRequest")
            {
                ermsg= JsonConvert.DeserializeObject<string>(res.Content.ReadAsStringAsync().Result);                
            }
            else
            {
                Console.WriteLine("伺服器連線異常");
            }
            result.dayid = dayid;
            result.ermsg = ermsg;
            return result;
        }

        public returnlistmsg UploadServerOut(string EmpNo, string CompleteQty,string DayReportId,string WorkOrderId,string WorkId,string WorkOrderItemId,string AssetsId,string Price,string createempno,string tenantid,string pid)
        {
            var client = new HttpClient();


            var keyValues = new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("CompleteQty", CompleteQty),        
                new KeyValuePair<string,string>("DayReportId", DayReportId),
                new KeyValuePair<string, string>("EmpNo", EmpNo),
                new KeyValuePair<string, string>("WorkId",WorkId),
                new KeyValuePair<string, string>("WorkOrderId",WorkOrderId),
                new KeyValuePair<string, string>("WorkOrderItemId",WorkOrderItemId),
                new KeyValuePair<string, string>("AssetsId",AssetsId),
                new KeyValuePair<string, string>("Price",Price),
                new KeyValuePair<string, string>("createempno", createempno),
                new KeyValuePair<string, string>("TenantId", tenantid),
                new KeyValuePair<string, string>("PartnerId", pid),
                };
            var actrequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(this.URL),
                Content = new FormUrlEncodedContent(keyValues),

            };
            actrequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Guid> dayid =new List<Guid>();
            var ermsg = "";
            var result = new returnlistmsg();
            try
            {
                HttpResponseMessage res = client.SendAsync(actrequest).GetAwaiter().GetResult();

                if (res.StatusCode.ToString() == "OK")
                {
                    //string r = res.Content.ReadAsStringAsync().Result.ToString();
                    // Message MS = JsonConvert.DeserializeObject<Message>(r);
                    // var Result = JsonConvert.SerializeObject(MS);

                    result = JsonConvert.DeserializeObject<returnlistmsg>(res.Content.ReadAsStringAsync().Result);
                }
                else if (res.StatusCode.ToString() == "BadRequest")
                {
                    ermsg = JsonConvert.DeserializeObject<string>(res.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    Console.WriteLine("伺服器連線異常");
                }
            }
            catch (Exception ex)
            {
                if (ex is TaskCanceledException)
                {
                    ermsg = "連線逾時";
                }
                else
                {
                    ermsg = "伺服器發生錯誤";
                }
            }
            return result;
        }
    }

    public class Emp {
        public Guid EmployeeId { get; set; }
        public string EmployeeNo { get; set; }
        public string FullName { get; set; }
        public string Lanaugage { get; set; }
    }
    public class Workitem
    {
        public Guid? WorkOrderId { get; set; }
        public Guid WorkOrderItemId { get; set; }
        public Guid WorkId { get; set; }
        public string WorkNo { get; set; }
        public string WorkName { get; set; }
        public float BadQty { get; set; }
        public float MakeQty { get; set; }
        public string Specification { get; set; }
    }

    public class Partner
    {
        public Guid PartnerId { get; set; }
        public string PartnerNo { get; set; }
        public string ShortName { get; set; }
        public string CategoryName { get; set; }
    }
    public class WorkOrder
    {

        public string MakeNo { get; set; }
        public string AssetsNo { get; set; }
        public string Remark { get; set; }
        public float MakeQty { get; set; }
        public string Specification { get; set; }
        public Guid? WorkOrderId { get; set; }
        public string AssetsName { get; set; }
        public int TenantId { get; set; }
        public string UseUnits { get; set; }
    }
    public class WorkOrderO:WorkOrder
    {
        public Guid? AssetsId { get; set; }
        public decimal? Price { get; set; }
    }
    public class WorkDayReport
    {

        public string DayReportId { get; set; }
        public string AssetsName { get; set; }
        public string MakeNo { get; set; }
        public string Specification { get; set; }
        public string WorkNo { get; set; }
        public string WorkName { get; set; }
        public decimal? WorkQty { get; set; }
        public decimal? AdjustTime { get; set; }
        public decimal? CompleteQty { get; set; }
        public decimal? BadQty { get; set; }
        public decimal? CompletGoQty { get; set; }
        public decimal? CompletNgQty { get; set; }
        public decimal? BadGoQty { get; set; }
        public decimal? BadNgQty { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? WorkTime { get; set; }
        public int TenantId { get; set; }
        public string EmployeeId { get; set; }
        public string WorkOrderId { get; set; }
        public string WorkOrderItemId { get; set; }
        public string WorkId { get; set; }
        public string WorkDate { get; set; }
        public string MNo { get; set; }
        public string EmpNo { get; set; }
        public string UseUnits { get; set; }
        public bool localupdate { get; set; }
        public int itemno { get; set; }

    }
    public class WorkOutReport : WorkDayReport
    {
        public string OutNo { get; set; }
        public decimal? RCompleteQty { get; set; }
        public decimal? RBadQty { get; set; }
        public bool? isreturn { get; set; }
    }
    public class WorkDayReportMenu : WorkDayReport
    {
        public bool? isupdate { get; set; }
    }
    public class WorkDayReportOut
    {
        public string DayReportId { get; set; }
        public decimal? Price { get; set; }
        public string AssetsNo { get; set; }
        public string MakeNo { get; set; }
        public string Specification { get; set; }
        public string WorkNo { get; set; }
        public string WorkName { get; set; }
        public decimal? CompleteQty { get; set; }
        public string EmpNo { get; set; }
    }
    public class returnmsg
    {
        public Guid? dayid { get; set; }
        public string ermsg { get; set; }
    }
    public class returnlistmsg
    {
        public List<Guid> ids { get; set; }
        public List<String> no { get; set; }
    }
    public class apiresult
    {
        public string MakeNo { get; set; }
        public int index { get; set; }
        public List<TextBox> titem { get; set; }
    }
    public class Tenant
    {
        public string TenantId { get; set; }
        public string ShortName { get; set; }
        public string GroupId { get; set; }
        public string Alias { get; set; }
    }
    public class ComboboxItem
    {

        public ComboboxItem(string value, string text)

        {

            Value = value;

            Text = text;

        }

        public string Value
        {

            get;

            set;

        }

        public string Text
        {

            get;

            set;

        }

        public override string ToString()
        {

            return Text;

        }

    }
}
