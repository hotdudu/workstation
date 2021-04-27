using Newtonsoft.Json;
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
        private string PTdef;
        private int timeout;
        private string[]filterstring =  new string[] { "完成入庫", "防銹包裝", "表面刻字", "成品檢驗", "鋁柄刻字" };
        private string[] filterstring1 = new string[] { "入庫", "包裝", "刻字", "檢驗", "熱處理" };
        public API(string url)
        {
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
                using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
                {
                    sIP = oTINI.getKeyValue("SYSTEM", "IP", "");
                    sComport = "COM"+ oTINI.getKeyValue("SYSTEM", "COMPORT", "");
                    ndbip = oTINI.getKeyValue("SYSTEM", "Dbip", "");
                    Empdef = oTINI.getKeyValue("SYSTEM", "Empdef", "");
                    var to= oTINI.getKeyValue("SYSTEM", "Timeout", "");//暫存
                    var tryint = int.TryParse(to, out apitimeout);// 逾時時間
                    PTdef = oTINI.getKeyValue("SYSTEM", "PTdef", "");
                    getconf = true;
                }
                /*string cPath = Directory.GetCurrentDirectory() + "\\" + "config.ini";
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
                            if (linear[0] == "PTdef")
                            {
                                PTdef = linear[1];
                            }
                        }
                    }
                }*/

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
        public List<Empm> GetEmpm(string tenantid, string DepartNo, string NIG)
        {
            var load = new loading();
            load.Show();
            var client = new HttpClient();
            var actrequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(this.URL),
                Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("tenantid",tenantid),
                 new KeyValuePair<string, string>("word",DepartNo),
                 new KeyValuePair<string, string>("notingroup",NIG),
                new KeyValuePair<string, string>("iswork","true"),
                })
            };//"http://localhost:56893/CHG/Main/Home/getEmployee/"
            actrequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = client.SendAsync(actrequest).GetAwaiter().GetResult();
            List<Empm> empobj = new List<Empm>();
            var defemplist = Empdef.Split(',');
            if (res.StatusCode.ToString() == "OK")
            {
                //string r = res.Content.ReadAsStringAsync().Result.ToString();
                // Message MS = JsonConvert.DeserializeObject<Message>(r);
                // var Result = JsonConvert.SerializeObject(MS);
                empobj = JsonConvert.DeserializeObject<List<Empm>>(res.Content.ReadAsStringAsync().Result);
                Console.WriteLine("def=" + defemplist.Length);
                if (empobj.Count > 0)
                {
                    empobj = empobj.Where(x => !defemplist.Contains(x.EmployeeNo)).OrderBy(x => x.EmployeeNo).ToList();
                    empobj = EmployeeDepartment_Filter(tenantid, empobj);
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

        public List<Workitem> GetWorkitem(int tid, string makeno, Guid wid, bool isout = false)
        {
            var filter = "";
            var filter1 = "";
            var filtero = "";
            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                var filtername = "f_GetWorkitem";
                var filtername1 = "f_GetWorkitem1";
                var filternameo = "f_GetWorkitemo";
                filter = oTINI.getKeyValue("SYSTEM", filtername, "");
                filter1 = oTINI.getKeyValue("SYSTEM", filtername1, "");
                filtero = oTINI.getKeyValue("SYSTEM", filternameo, "");
            }
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
            if (filtero == "1")//外包
            {
                witemobj = witemobj.Where(x => x.Outsourcing == isout).ToList();
                if (!isout)//外包不再過濾字串
                {
                    if (filter1 == "1")//模糊過濾(較少筆)
                    {
                        foreach (var item in filterstring1)
                        {
                            witemobj = witemobj.Where(x => !x.WorkName.Contains(item)).ToList();
                        }
                    }
                    else
                    {
                        if (filter == "1")//完全過濾(較多筆)
                        {

                            foreach (var item in filterstring)
                            {
                                witemobj = witemobj.Where(x => !x.WorkName.Contains(item)).ToList();
                            }

                        }
                    }
                }
            }
            else
            {
                if (filter1 == "1")//模糊過濾(較少筆)
                {
                    foreach (var item in filterstring1)
                    {
                        witemobj = witemobj.Where(x => !x.WorkName.Contains(item)).ToList();
                    }
                }
                else
                {
                    if (filter == "1")//完全過濾(較多筆)
                    {

                        foreach(var item in filterstring)
                        {
                            witemobj = witemobj.Where(x => !x.WorkName.Contains(item)).ToList();
                        }

                    }
                }
            }


            return witemobj;
        }

        public List<Workitem> GetWorkitem(bool isout = false)
        {
            var filter = "";
            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                var filtername = "f_GetWorkitem";
                filter = oTINI.getKeyValue("SYSTEM", filtername, "");
            }
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
            witemobj = witemobj.Where(x => x.Outsourcing == isout).ToList();
            if (filter == "1")
            {
                foreach (var item in filterstring)
                {
                    witemobj = witemobj.Where(x => !x.WorkName.Contains(item)).ToList();
                }

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
            var ptf = "";
            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                ptf = oTINI.getKeyValue("SYSTEM", "PTdef", "");
            }
            var defarray = ptf.Split(',');
            if (res.StatusCode.ToString() == "OK")
            {

                //string r = res.Content.ReadAsStringAsync().Result.ToString();
                // Message MS = JsonConvert.DeserializeObject<Message>(r);
                // var Result = JsonConvert.SerializeObject(MS);
                witemobj = JsonConvert.DeserializeObject<List<Partner>>(res.Content.ReadAsStringAsync().Result);
                if (witemobj.Count > 0)
                {
                    witemobj = witemobj.Where(x => !defarray.Contains(x.ShortName)).ToList();
                    witemobj = Partner_Filter(tenantid.ToString(), witemobj);
                }
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

        public List<Partnerm> GetPartnerm(int? tenantid)
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
            List<Partnerm> witemobj = new List<Partnerm>();
            var ptf = "";
            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                ptf = oTINI.getKeyValue("SYSTEM", "PTdef", "");
            }
            var defarray = ptf.Split(',');
            if (res.StatusCode.ToString() == "OK")
            {

                //string r = res.Content.ReadAsStringAsync().Result.ToString();
                // Message MS = JsonConvert.DeserializeObject<Message>(r);
                // var Result = JsonConvert.SerializeObject(MS);
                witemobj = JsonConvert.DeserializeObject<List<Partnerm>>(res.Content.ReadAsStringAsync().Result);
                if (witemobj.Count > 0)
                {
                    witemobj = witemobj.Where(x => !defarray.Contains(x.ShortName)).ToList();
                }
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


        public List<Partner> GetPartner2(int tenantid, string pno)
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
            catch (Exception ex)
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
            else if (res.StatusCode.ToString() == "BadRequest")
            {
                ermsg = JsonConvert.DeserializeObject<string>(res.Content.ReadAsStringAsync().Result);
            }
            else
            {
                Console.WriteLine("伺服器連線異常");
            }
            result.dayid = dayid;
            result.ermsg = ermsg;
            return result;
        }

        public returnlistmsg UploadServerOut(string EmpNo, string CompleteQty, string DayReportId, string WorkOrderId, string WorkId, string WorkOrderItemId, string AssetsId, string Price, string createempno, string tenantid, string pid)
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
            List<Guid> dayid = new List<Guid>();
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

        public returnlistmsg UploadServerReturn(string EmpNo, string CompleteQty, string BadQty, string DayReportId, string WorkId, string WorkOrderItemId, string AssetsId, string Price, string createempno, string tenantid, string pid)
        {
            var client = new HttpClient();


            var keyValues = new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("CompleteQty", CompleteQty),
                new KeyValuePair<string, string>("BadQty", BadQty),
                new KeyValuePair<string,string>("DayReportId", DayReportId),
                new KeyValuePair<string, string>("EmpNo", EmpNo),
                new KeyValuePair<string, string>("WorkId",WorkId),
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
            List<Guid> dayid = new List<Guid>();
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
        private List<Empm> EmployeeDepartment_Filter(string tid, List<Empm> orglist)
        {
            List<Empm> Result = orglist;
            var name = "Emp";
            var cloumn = "DepartmentNo";
            var Nfilter = getfilter(name,cloumn, "Not", tid);
            var Gfilter= getfilter(name,cloumn, "Ok", tid);
            if (Nfilter.Result != "")
            {
                var key = Nfilter.Result.Split(',');
                Result = Result.Where(x => !key.Contains(x.EmployeeNo.Substring(0,4))).ToList();
            }
            if (Gfilter.Result != "")
            {
                var key2 = Gfilter.Result.Split(',');
                Result = Result.Where(x => key2.Contains(x.EmployeeNo.Substring(0,4))).ToList();
            }
            return Result;
        }
        private List<Partner> Partner_Filter(string tid, List<Partner> orglist)
        {
            List<Partner> Result = orglist;
            var name = "Partner";
            var cloumn = "PartnerNo";
            var Nfilter = getfilter(name, cloumn, "Not", tid);
            var Gfilter = getfilter(name, cloumn, "Ok", tid);
            if (Nfilter.Result != "")
            {
                var key = Nfilter.Result.Split(',');
                Result = Result.Where(x => !key.Contains(x.PartnerNo)).ToList();
            }
            if (Gfilter.Result != "")
            {
                var key2 = Gfilter.Result.Split(',');
                Result = Result.Where(x => key2.Contains(x.PartnerNo)).ToList();
            }
            return Result;
        }
        public filterobj getfilter(string Func,string cloumn,string PlusOrMinus,string tenant)
        {
            var basename = "filter";
            var filtername = basename + "_" + Func + "_"+cloumn+"_" + PlusOrMinus + "_" + tenant;
            filterobj returnobj = new filterobj();
            int tid = 0;
            int.TryParse(tenant, out tid);
            using (TINI oTINI = new TINI(Path.Combine(Application.StartupPath, "config.ini")))
            {
                try
                {
                    var result = "";
                    result=oTINI.getKeyValue("SYSTEM", filtername, "");
                    returnobj.Result = result;
                    returnobj.PlusOrMinus = PlusOrMinus == "Not" ? false : true;
                    returnobj.TenantId = tid;
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine("nofilter");
                }
            }
            return returnobj;
        }
    }


    public class filterobj
    {
        public bool PlusOrMinus { get; set; }
        public int TenantId { get; set; }
        public string Result { get; set; }
        public string Cloumn { get; set; }
    }
    public class Emp
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeNo { get; set; }
        public string FullName { get; set; }
        public string Lanaugage { get; set; }
    }
    public class Empm
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeNo { get; set; }
        public string FullName { get; set; }
        public string Lanaugage { get; set; }
        public List<Empin> Rlist { get; set; }
    }
    public class Empin
    {
        public string no { get; set; }
        public string tenant { get; set; }
    }
    public class Ptin : Empin
    {
        public Guid id { get; set; }
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
        public bool Outsourcing { get; set; }
    }

    public class Partner
    {
        public Guid PartnerId { get; set; }
        public string PartnerNo { get; set; }
        public string ShortName { get; set; }
        public string CategoryName { get; set; }
    }
    public class Partnerm : Partner
    {
        public List<Ptin> Rlist { get; set; }
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
    public class WorkOrderO : WorkOrder
    {
        public Guid? AssetsId { get; set; }
        public decimal? Price { get; set; }
    }
    public class btnsize
    {
        public string name { get; set; }
        public int width { get; set; }
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
    public class WorkOutReport
    {
        public string DayReportId { get; set; }
        public string AssetsName { get; set; }
        public string MakeNo { get; set; }
        public string AssetsNo { get; set; }
        public string Specification { get; set; }
        public string WorkNo { get; set; }
        public string WorkName { get; set; }
        public string WorkDate { get; set; }
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
        public decimal? Price { get; set; }
        public string EmployeeId { get; set; }
        public string WorkOrderId { get; set; }
        public string WorkOrderItemId { get; set; }
        public string WorkId { get; set; }
        public string AssetsId { get; set; }
        public string MNo { get; set; }
        public string EmpNo { get; set; }
        public string UseUnits { get; set; }
        public bool localupdate { get; set; }
        public int itemno { get; set; }
        public string OutNo { get; set; }
        public bool? isreturn { get; set; }
        public decimal? RCompleteQty { get; set; }
        public decimal? RBadQty { get; set; }
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
