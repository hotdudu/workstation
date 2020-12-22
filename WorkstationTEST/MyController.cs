using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkstationTEST
{
    class MyController
    {

        public LocalDBDataSet LocalDBDS;
        OleDbConnection LocalDBConn;
        int FindDays = -30;
        public string SQLconnectString = "";
        public string LocalconnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = LocalDB.mdb; Jet OLEDB:DataBase Password = chg88739881";
        public MyController()
        {
            LocalDBDS = new LocalDBDataSet();
            LocalDBConn = OleDbOpenConn();
        }
        public void setFindDays(int f)
        {
            FindDays = f>0?-f:f;
        }
        public string Get_EmpNameByNo(string No)
        {
            IEnumerable<DataRow> query = (
                from obj in LocalDBDS.Tables["Employees"].AsEnumerable()
                where obj.Field<string>("EmployeeNo") == No
                select obj
                );
            if (query.Count() > 0)
            {
                return query.FirstOrDefault().Field<string>("FullName");
            }
            else
            { return ""; }
        }
        public string Get_EmpNameById(string ID)
        {
            IEnumerable<DataRow> query = (
                from obj in LocalDBDS.Tables["Employees"].AsEnumerable()
                where obj.Field<string>("EmployeeId") == ID
                select obj
                );
            if (query.Count() > 0)
            {
                return query.FirstOrDefault().Field<string>("FullName");
            }
            else
            { return ""; }
        } 

        public string Get_WorkNameByNo(string NO)
        {
            IEnumerable<DataRow> query = (
                from obj in LocalDBDS.Tables["WorkItems"].AsEnumerable()
                where obj.Field<string>("WorkNo") == NO
                select obj
                );
            if (query.Count() > 0)
            {
                return query.FirstOrDefault().Field<string>("WorkName");
            }
            else
            { return ""; }
        }

        

        public static DataSet ConnectToSql_WorkOrders(string No,string sIP)
        {
            var name = "";

            System.Data.SqlClient.SqlConnection conn =
                new System.Data.SqlClient.SqlConnection();
            // TODO: Modify the connection string and include any
            // additional required properties for your database.


            conn.ConnectionString =
             "integrated security=false; data source="+ sIP+";" +
             "initial catalog=MISData;persist security info=True;user id=sa;password=Chg8675)$!(;MultipleActiveResultSets=True;    ";
            try
            {
                conn.Open();
                // Insert code to process data.

                // step 3 . 建立SqlConnection
                //    SqlConnection conn = new SqlConnection(Constr);

                // step 4 . 宣告查詢字串
                string Sqlstr =
                        "select WorkOrders.MakeNo,WorkOrders.MakeQty" +
                        ",[ProductDesigns].EdgePath,WorkOrders.Remark" +
                        ",InOrderItems.AssetsName,InOrderItems.Specification" +
                        ",InOrderItems.Accuracy,InOrderItems.Qty" +
                        " FROM WorkOrders" +
                        " join InOrderItems on WorkOrders.InOrderItemId = InOrderItems.InOrderItemId" +
                        " join[Assets] on[WorkOrders].AssetsId=[Assets].AssetsId" +
                        " join[ProductDesigns] on[Assets].AssetsNo =[ProductDesigns].WorkFigureNo" +
                        " Where WorkOrders.MAKENO=\'" + No.Trim() + "\'";
                // string Sqlstr = "select FullName,EmployeeNo from Employees ";

                // step 5. 建立SqlDataAdapter
                SqlDataAdapter da = new SqlDataAdapter(Sqlstr, conn);

                // step 6. 建立DataSet來儲存Table
                DataSet ds = new DataSet();

                // step 7. 將DataAdapter查詢之後的結果，填充至DataSet
                da.Fill(ds);
                return ds;
                // step 8 . 用DataGridView1 顯示出來
                // this.dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmMain.StartKiller();
                frmMain.showMsg(ex.ToString());
                MessageBox.Show(null, "Failed to connect to data source", "Application Information");
                return null;
            }
            finally
            {
                conn.Close();

            }

        }
        public Boolean DownLoadFromSQLServer(int iTenantId)
        {
            var isOK = false;
            var TableName = "";
            frmMsg objfrmMsg = new frmMsg();
            objfrmMsg.Show();
            Application.DoEvents();
            System.Threading.Thread.Sleep(1);

            try
            {
                string OleDbString = "";
                OleDbDataAdapter da;
                OleDbCommandBuilder commandBuilder;
                OleDbCommand cmd;
                // LocalDBConn = OleDbOpenConn();


                //Access - init
                LocalDBDS.Clear();
                if (LocalDBConn.State == ConnectionState.Closed) LocalDBConn.Open();
                //Access - WorkInFactory
                TableName = "WorkInFactory";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);

                //Access - Employees
                TableName = "Employees";
                OleDbString = "Select * from " + TableName + " where   EmployeeNo not like \'CHZ%\' ";
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);

                //GetData from SQL Server Employees
                using (var ctx = new MISDataEntities(SQLconnectString))
                {
                    var SQLEmployees = (from obj in ctx.Employees
                                        where obj.TenantId == iTenantId && obj.UnhireDate==null
                                        && obj.FullName!=""
                                        && obj.EmployeeNo.StartsWith("CHZ")==false
                                        select obj);
                    if (SQLEmployees.Count() > 0)
                    {
                        cmd = new OleDbCommand("delete from " + TableName, LocalDBConn);
                        cmd.ExecuteNonQuery();
                        LocalDBDS.Tables[TableName].Clear();
                        foreach (var obj in SQLEmployees)
                        {
                            DataRow xRow;
                            xRow = LocalDBDS.Tables[TableName].NewRow();
                            xRow["EmployeeId"] = obj.EmployeeId;
                            xRow["TenantId"] = obj.TenantId;
                            xRow["FullName"] = obj.FullName;
                            xRow["EmployeeNo"] = obj.EmployeeNo;
                            LocalDBDS.Tables[TableName].Rows.Add(xRow);
                        }
                        da.Update(LocalDBDS.Tables[TableName]);
                    }

                }
                //Access - Assets
                TableName = "Assets";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);
                //GetData from SQL Server Assets
                using (var ctx = new MISDataEntities(SQLconnectString))
                {
                    var SQLAssets = (from obj in ctx.Assets
                                     where obj.rTenantId == iTenantId && obj.AssetsType == 31
                                     select obj);
                    if (SQLAssets.Count() > 0)
                    {
                        cmd = new OleDbCommand("delete from " + TableName, LocalDBConn);
                        cmd.ExecuteNonQuery();
                        LocalDBDS.Tables[TableName].Clear();
                        foreach (var obj in SQLAssets)
                        {
                            DataRow xRow;
                            xRow = LocalDBDS.Tables[TableName].NewRow();
                            xRow["AssetsId"] = obj.AssetsId;
                            xRow["AssetsNo"] = obj.AssetsNo;
                            LocalDBDS.Tables[TableName].Rows.Add(xRow);
                        }
                        da.Update(LocalDBDS.Tables[TableName]);
                    }

                }
                //Access - AssetsItems
                TableName = "AssetsItems";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);
                //GetData from SQL Server AssetsItems
                using (var ctx = new MISDataEntities(SQLconnectString))
                {
                    var SQLAssetsItems = (from obj in ctx.AssetsItems
                                          where obj.TenantId == iTenantId && obj.Assets.AssetsType == 31
                                          orderby obj.SubNo
                                          select obj);
                    if (SQLAssetsItems.Count() > 0)
                    {
                        cmd = new OleDbCommand("delete from " + TableName, LocalDBConn);
                        cmd.ExecuteNonQuery();
                        LocalDBDS.Tables[TableName].Clear();
                        foreach (var obj in SQLAssetsItems)
                        {
                            DataRow xRow;
                            xRow = LocalDBDS.Tables[TableName].NewRow();
                            xRow["AssetsItemId"] = obj.AssetsItemId;
                            xRow["AssetsId"] = obj.AssetsId;
                            xRow["SubNo"] = obj.SubNo;
                            LocalDBDS.Tables[TableName].Rows.Add(xRow);
                        }
                        da.Update(LocalDBDS.Tables[TableName]);
                    }
                }
                //Access - WorkItems
                TableName = "WorkItems";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);
                //GetData from SQL Server WorkItems
                using (var ctx = new MISDataEntities(SQLconnectString))
                {
                    var SQLWorkItems = (from obj in ctx.WorkItems

                                        select obj);
                    if (SQLWorkItems.Count() > 0)
                    {
                        cmd = new OleDbCommand("delete from " + TableName, LocalDBConn);
                        cmd.ExecuteNonQuery();
                        LocalDBDS.Tables[TableName].Clear();
                        foreach (var obj in SQLWorkItems)
                        {
                            DataRow xRow;
                            xRow = LocalDBDS.Tables[TableName].NewRow();
                            xRow["WorkId"] = obj.WorkId;
                            xRow["WorkNo"] = obj.WorkNo;
                            xRow["WorkName"] = obj.WorkName;
                            LocalDBDS.Tables[TableName].Rows.Add(xRow);
                        }
                        da.Update(LocalDBDS.Tables[TableName]);
                    }

                }
                //Access - WorkOrderItems
                TableName = "WorkOrderItems";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);
                //GetData from SQL Server WorkOrderItems
                using (var ctx = new MISDataEntities(SQLconnectString))
                {
                    DateTime startDate = DateTime.Today.AddDays(FindDays);
                    var SQLWorkOrderItems = (from obj in ctx.WorkOrderItems
                                             where obj.WorkOrders.WorkOrderDate >= startDate
                                             select obj);
                    if (SQLWorkOrderItems.Count() > 0)
                    {
                        cmd = new OleDbCommand("delete from " + TableName, LocalDBConn);
                        cmd.ExecuteNonQuery();
                        LocalDBDS.Tables[TableName].Clear();
                        foreach (var obj in SQLWorkOrderItems)
                        {
                            DataRow xRow;
                            xRow = LocalDBDS.Tables[TableName].NewRow();
                            xRow["WorkOrderItemId"] = obj.WorkOrderItemId;
                            xRow["WorkOrderId"] = obj.WorkOrderId;
                            xRow["ItemNo"] = obj.ItemNo;
                            xRow["WorkId"] = obj.WorkId;
                            LocalDBDS.Tables[TableName].Rows.Add(xRow);
                        }
                        da.Update(LocalDBDS.Tables[TableName]);

                    }

                }
                //Access - WorkOrders
                TableName = "WorkOrders";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);
                //GetData from SQL Server WorkOrders
                using (var ctx = new MISDataEntities(SQLconnectString))
                {
                    DateTime startDate = DateTime.Today.AddDays(FindDays);
                    var SQLWorkOrders = (from obj in ctx.WorkOrders
                                         where obj.TenantId == iTenantId && obj.WorkOrderDate >= startDate
                                         select obj);
                    if (SQLWorkOrders.Count() > 0)
                    {

                        cmd = new OleDbCommand("delete from " + TableName, LocalDBConn);
                        cmd.ExecuteNonQuery();
                        LocalDBDS.Tables[TableName].Clear();
                        foreach (var obj in SQLWorkOrders)
                        {
                            DataRow xRow;
                            xRow = LocalDBDS.Tables[TableName].NewRow();
                            xRow["WorkOrderId"] = obj.WorkOrderId;
                            xRow["MakeNo"] = obj.MakeNo;
                            xRow["AssetsId"] = obj.AssetsId;
                            xRow["MakeQty"] = obj.MakeQty;
                            LocalDBDS.Tables[TableName].Rows.Add(xRow);
                        }
                        da.Update(LocalDBDS.Tables[TableName]);
                    }

                }



                if (LocalDBConn.State == ConnectionState.Open) LocalDBConn.Close();
                frmMain.setSQLStatus("連線");
                isOK = true;
            }
            catch (Exception ex)
            {
                frmMain.StartKiller();
                frmMain.showMsg(ex.ToString());
                //MessageBox.Show(null, "Failed to connect to data source", "Application Information");
                frmMain.setSQLStatus("斷線");
                isOK = false;
            }
            finally
            {
                 
                objfrmMsg.Close();

            }



            return isOK;
        }
        public Boolean LoadFromLocalDB(int iTenantId)
        {
            var isOK = false;
            var TableName = "";
            try
            {
                string OleDbString = "";
                OleDbDataAdapter da;
                OleDbCommandBuilder commandBuilder;
                OleDbCommand cmd;
                LocalDBConn = OleDbOpenConn();


                //Access - init
                LocalDBDS.Clear();
                //Access - WorkInFactory
                TableName = "WorkInFactory";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);

                //Access - Employees
                TableName = "Employees";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);


                //Access - Assets
                TableName = "Assets";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);

                //Access - AssetsItems
                TableName = "AssetsItems";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);

                //Access - WorkItems
                TableName = "WorkItems";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);
                //GetData from SQL Server WorkItems

                //Access - WorkOrderItems
                TableName = "WorkOrderItems";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);

                //Access - WorkOrders
                TableName = "WorkOrders";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);




                if (LocalDBConn.State == ConnectionState.Open) LocalDBConn.Close();
                isOK = true;
            }
            catch (Exception ex)
            {
                frmMain.StartKiller();
                frmMain.showMsg(ex.ToString());
                MessageBox.Show(null, "Failed to connect to data source", "Application Information");
                isOK = false;
            }
            finally
            {


            }



            return isOK;
        }
        public Boolean SaveToLocalDB(int iTenantId, string WorkOrderId, string WorkId, string EmpId, string DeviceId, int TotalQty, DateTime startTime)
        {
            Boolean isOK = false;
            try
            {
                string OleDbString = "";
                OleDbDataAdapter da;
                OleDbCommandBuilder commandBuilder;
                OleDbCommand cmd;
                string TableName = "WorkInFactory";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                LocalDBDS.Tables[TableName].Clear();
                da.Fill(LocalDBDS, TableName);
                DataRow xRow;
                xRow = LocalDBDS.Tables[TableName].NewRow();
                xRow["WorkInFactoryID"] = Guid.NewGuid();
                xRow["TenantId"] = iTenantId;
                xRow["EmployeeId"] = Guid.Parse(EmpId);

                xRow["WorkId"] = Guid.Parse(WorkId);
                xRow["WorkOrderId"] = Guid.Parse(WorkOrderId);
                xRow["AssetsItemId"] = Guid.Parse(DeviceId);
                xRow["TotalQty"] = TotalQty;

                xRow["StartTime"] = startTime;


                LocalDBDS.Tables[TableName].Rows.Add(xRow);

                da.Update(LocalDBDS.Tables[TableName]);
                isOK = true;
                //   if (UpLoadToSQLServer())
                //      MessageBox.Show("UpLoadToSQLServer OK");




            }
            catch (Exception ex)
            {
                frmMain.showMsg(ex.ToString());
                isOK = false;
            }
            return isOK;
        }
        public Boolean SaveToLocalDB(int iTenantId, string WorkOrderId, string WorkId, string EmpId, string DeviceId, int TotalQty, int BadQty, int UnfinishQty, DateTime stopTime)
        {
            Boolean isOK = false;
            try
            {
                string OleDbString = "";
                OleDbDataAdapter da;
                OleDbCommandBuilder commandBuilder;
                OleDbCommand cmd;
                string TableName = "WorkInFactory";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                LocalDBDS.Tables[TableName].Clear();
                da.Fill(LocalDBDS, TableName);
                DataRow xRow;
                xRow = LocalDBDS.Tables[TableName].NewRow();
                xRow["WorkInFactoryID"] = Guid.NewGuid();
                xRow["TenantId"] = iTenantId;
                xRow["EmployeeId"] = Guid.Parse(EmpId);

                xRow["WorkId"] = Guid.Parse(WorkId);
                xRow["WorkOrderId"] = Guid.Parse(WorkOrderId);
                xRow["AssetsItemId"] = Guid.Parse(DeviceId);
                xRow["TotalQty"] = TotalQty;
                xRow["BadQty"] = BadQty;
                xRow["CompleteQty"] = TotalQty - UnfinishQty;
                xRow["StopTime"] = stopTime;


                LocalDBDS.Tables[TableName].Rows.Add(xRow);

                da.Update(LocalDBDS.Tables[TableName]);
                isOK = true;
                //  if (UpLoadToSQLServer())
                //      MessageBox.Show("UpLoadToSQLServer OK");

            }
            catch (Exception ex)
            {
                frmMain.showMsg(ex.ToString());
                isOK = false;
            }
            return isOK;
        }
        public Boolean UpLoadToSQLServer(string nowmode)
        {
            frmMsg objfrmMsg = new frmMsg();
            objfrmMsg.Show();
            Application.DoEvents();
            System.Threading.Thread.Sleep(1);
            try
            {
                
                //Boolean SQLstatus=false;
                using (var ctx = new MISDataEntities(SQLconnectString))
                {
                    if (ctx.Database.Exists())
                    {
                        //

                        try
                        {

                            using (var transaction = ctx.Database.BeginTransaction())
                            {
                                bool isOk = false;
                                bool emptydata = false;
                                try
                                {
                                    var item = LocalDBDS.Tables["WorkInFactory"].Rows;
                                    if (item.Count > 0)
                                    {
                                        foreach (var obj in LocalDBDS.Tables["WorkInFactory"].Rows)
                                        {
                                            DataRow xRow = (DataRow)obj;
                                            Guid objWorkInFactoryID = (Guid)xRow["WorkInFactoryID"];
                                            WorkInFactory tt = ctx.WorkInFactory.Where(x => x.WorkInFactoryID == objWorkInFactoryID).FirstOrDefault();
                                            if (tt == null)
                                            { //add
                                                WorkInFactory newWorkInFactory = new WorkInFactory();
                                                newWorkInFactory.WorkInFactoryID = (Guid)xRow["WorkInFactoryID"];
                                                newWorkInFactory.TenantId = (int)xRow["TenantId"];
                                                newWorkInFactory.EmployeeId = (Guid)xRow["EmployeeId"];
                                                newWorkInFactory.WorkId = (Guid)xRow["WorkId"];
                                                newWorkInFactory.WorkOrderId = (Guid)xRow["WorkOrderId"];
                                                newWorkInFactory.AssetsItemId = (Guid)xRow["AssetsItemId"];
                                                newWorkInFactory.TotalQty = (decimal)xRow["TotalQty"];
                                                if (xRow.IsNull("CompleteQty") == false)
                                                    newWorkInFactory.CompleteQty = (decimal)xRow["CompleteQty"];
                                                if (xRow.IsNull("BadQty") == false)
                                                    newWorkInFactory.BadQty = (decimal)xRow["BadQty"];
                                                if (xRow.IsNull("StartTime") == false)
                                                    newWorkInFactory.StartTime = (DateTime)xRow["StartTime"];
                                                if (xRow.IsNull("StopTime") == false)
                                                    newWorkInFactory.StopTime = (DateTime)xRow["StopTime"];
                                                ctx.WorkInFactory.Add(newWorkInFactory);
                                            }
                                            else//edit
                                            {
                                                //
                                                //   tt.WorkInFactoryID = (Guid)xRow["WorkInFactoryID"];
                                                tt.TenantId = (int)xRow["TenantId"];
                                                tt.EmployeeId = (Guid)xRow["EmployeeId"];
                                                tt.WorkId = (Guid)xRow["WorkId"];
                                                tt.WorkOrderId = (Guid)xRow["WorkOrderId"];
                                                tt.AssetsItemId = (Guid)xRow["AssetsItemId"];
                                                tt.TotalQty = (decimal)xRow["TotalQty"];
                                                if (xRow.IsNull("CompleteQty") == false)
                                                    tt.CompleteQty = (decimal)xRow["CompleteQty"];
                                                if (xRow.IsNull("BadQty") == false)
                                                    tt.BadQty = (decimal)xRow["BadQty"];
                                                if (xRow.IsNull("StartTime") == false)
                                                    tt.StartTime = (DateTime)xRow["StartTime"];
                                                if (xRow.IsNull("StopTime") == false)
                                                    tt.StopTime = (DateTime)xRow["StopTime"];
                                            }
                                        }

                                        ctx.SaveChanges();
                                        transaction.Commit();
                                        isOk = true;
                                    }
                                    else
                                    {
                                        emptydata = true;
                                        isOk = false;
                                    }
                                }
                                catch (System.Data.Entity.Core.EntitySqlException ex)
                                {
                                    transaction.Rollback();
                                    //throw ex;
                                    isOk = false;
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    //throw ex;
                                    isOk = false;
                                }
                                if (isOk)
                                {
                                    //del
                                    try
                                    {
                                        if (LocalDBConn.State == ConnectionState.Closed) LocalDBConn.Open();
                                        var cmd = new OleDbCommand("delete from WorkInFactory", LocalDBConn);
                                        cmd.ExecuteNonQuery();
                                        LocalDBDS.Tables["WorkInFactory"].Clear();
                                        if (LocalDBConn.State == ConnectionState.Open) LocalDBConn.Close();
                                        if (nowmode == "Start")
                                        {
                                            frmMain.savestat(true);
                                        }
                                        if(nowmode=="Stop")
                                        {
                                            frmMain.savestat(false);
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        frmMain.setSQLStatus("錯誤");
                                        return false;
                                    }
                                    frmMain.setSQLStatus("連線");
                                    return true;
                                }
                                else
                                {
                                    if(!emptydata)
                                        frmMain.setSQLStatus("錯誤");
                                    return false;
                                }
                            }

                        }
                        catch (System.Data.Entity.Core.EntitySqlException ex)
                        {
                            frmMain.setSQLStatus("錯誤");
                            frmMain.showMsg(ex.ToString());
                            return false;


                        }
                        catch (Exception ex)
                        {
                            frmMain.showMsg(ex.ToString());
                            frmMain.setSQLStatus("錯誤");
                            return false;
                        }
                    }
                    else
                    {
                        frmMain.setSQLStatus("錯誤");
                        return false;

                    }
                }

                // return true;
            }
            catch (Exception)
            {
                frmMain.setSQLStatus("錯誤");
                return false;

            }
            finally
            {
                objfrmMsg.Close();

            }


           
        }
        public OleDbConnection OleDbOpenConn()
        {

            string cnstr = string.Format(LocalconnectString);
            OleDbConnection icn = new OleDbConnection();
            icn.ConnectionString = cnstr;
            if (icn.State == ConnectionState.Open) icn.Close();
            icn.Open();
            return icn;
        }
        public void LoadFromLocalDBtest(int iTenantId)
        {
            var isOK = false;
            var TableName = "";

            {
                string OleDbString = "";
                OleDbDataAdapter da;
                OleDbCommandBuilder commandBuilder;
                OleDbCommand cmd;
                LocalDBConn = OleDbOpenConn();


                //Access - init
                LocalDBDS.Clear();

                //Access - Employees
                TableName = "Employees";
                OleDbString = "Select * from " + TableName;
                da = new OleDbDataAdapter(OleDbString, LocalDBConn);
                commandBuilder = new OleDbCommandBuilder(da);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";
                da.Fill(LocalDBDS, TableName);
            }
        }
    }

}
