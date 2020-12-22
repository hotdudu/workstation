using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace WorkstationTEST
{
    class Local
    {
        public string connstring;
        bool isexist;
       public Local(string path,string filename)
        {
            string dbPath = path + "\\" + filename;
            if (File.Exists(dbPath))
                isexist = true;
            else
                isexist = false;
            connstring = "data source=" + dbPath + ";Version=3;";
        }
       public  Local(string cstr)
        {
            connstring = cstr;
        }

        public List<Emp> SelectEmp()
        {
            List<Emp>emp=new List<Emp>() ;
            using (SQLiteConnection conn = new SQLiteConnection(connstring))
            {
                string strSql = "Select * from Employee";
                emp = conn.Query<Emp>(strSql).ToList();
            }
            return emp;
        }
        public List<remotEmp> getremoteEmp()
        {
            List<remotEmp> emp = new List<remotEmp>();
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                    try
                    {
                        string Sqlstr =
        "SELECT EmployeeId,FullName,EmployeeNo,DepartmentId,TenantId FROM Employees" +
                  " Where TenantId=@TenantId and UnhireDate is null";
                         emp = conn.Query<remotEmp>(Sqlstr,new { TenantId=101 }).ToList();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("geterror:" + ex);
                    }
            }

            
            return emp;
        }

        public List<rWorkOrder> getworkorder()
        {
            List<rWorkOrder> emp = new List<rWorkOrder>();
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                try
                {
                    string Sqlstr =
    "SELECT WorkOrderId,TenantId,MakeNo,MakeQty,PartnerId,WorkOrderDate,OrderItemId,InOrderItemId,UpdateDate,e.AssetsId,Material," +
                    "a.Specification FROM WorkOrders e JOIN Assets a ON e.AssetsId=a.AssetsId";
                    emp = conn.Query<rWorkOrder>(Sqlstr).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("geterror:" + ex);
                }
            }


            return emp;
        }

        public List<rWorkOrderItem> getworkorderitem()
        {
            List<rWorkOrderItem> emp = new List<rWorkOrderItem>();
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                try
                {
                    string Sqlstr =
    "SELECT WorkOrderItemId,WorkOrderId,WorkId,CompleteQty,BadQty,CompleteDate,WorkOrderDate,WorkNo,WorkName" +
                    "  FROM WorkOrderItems w1 JOIN WorkItems w2 ON w1.WorkId=w2.WorkId";
                    emp = conn.Query<rWorkOrderItem>(Sqlstr).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("geterror:" + ex);
                }
            }


            return emp;
        }
    }

    public class remotEmp
    {
        public int TenantId { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeNo { get; set; }
        public string FullName { get; set; }
        public Guid DepartmentId { get; set; }
    }
    public class rWorkOrder
    {
        public int TenantId { get; set; }
        public Guid WorkOrderId { get; set; }
        public string MakeNo { get; set; }
        public decimal MakeQty { get; set; }
        public Guid PartnerId { get; set; }
        public DateTime WorkOrderDate { get; set; }
        public Guid OrderItemId { get; set; }
        public Guid InOrderItemId { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid AssetsId { get; set; }
        public string Material { get; set; }
        public string Specification { get; set; }
    }

    public class rWorkOrderItem
    {
        public Guid WorkOrderItemId { get; set; }
        public Guid WorkOrderId { get; set; }
        public Guid WorkId { get; set; }
        public decimal CompleteQty { get; set; }
        public decimal BadQty { get; set; }
        public DateTime CompleteDate { get; set; }
        public string WorkNo { get; set; }
        public string WorkName { get; set; }
    }
}
