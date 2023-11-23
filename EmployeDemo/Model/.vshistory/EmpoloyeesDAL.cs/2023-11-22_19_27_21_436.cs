using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeDemo.Model {
   public class EmpoloyeesDAL : IDisposable {
      private SqlConnection m_con;
      private SqlCommand m_cmdAddEmployee;
      private SqlCommand m_cmdUpdEmployee;
      private SqlCommand m_cmdDelEmployee;
      private SqlCommand m_cmUpdDepartment;
      private SqlCommand m_cmGetEmployees;
      private SqlTransaction m_tran = null;
      private bool disposedValue;
      private bool isInTranscation = false;



      //private const string _sqlconstring = "Server={0};Database={1};Trusted_Connection=True";
      private const string _sqlconstring = "Server={0};AttachDbFilename={1};Trusted_Connection=True";

      
      public EmpoloyeesDAL() {
         Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetEntryAssembly().Location);
         var _srvName = config.AppSettings.Settings["ServerName"].Value;
         var _dbname  = config.AppSettings.Settings["DbName"].Value;
         m_con          = new SqlConnection(String.Format(_sqlconstring, _srvName, _dbname));
         try {
            m_con.Open();

            m_cmdAddEmployee = new SqlCommand("addEmployee", m_con);
            m_cmdAddEmployee.Parameters.AddRange(new SqlParameter[]
               {
                  new SqlParameter("@employee_number"      , SqlDbType.Char, 6),
                  new SqlParameter("@employee_firstname"   , SqlDbType.NVarChar, 50),
                  new SqlParameter("@employee_lastname"    , SqlDbType.NVarChar, 50),
                  new SqlParameter("@employee_phone"       , SqlDbType.VarChar, 20),
                  new SqlParameter("@employee_email"       , SqlDbType.VarChar, 20),
                  new SqlParameter("@employee_job"         , SqlDbType.Int),
                  new SqlParameter("@employee_departmentid", SqlDbType.Int),
                  new SqlParameter("@emp_id"               , SqlDbType.Int)
               });
            m_cmdAddEmployee.Parameters[m_cmdAddEmployee.Parameters.Count - 1].Direction = ParameterDirection.ReturnValue;
            m_cmdAddEmployee.CommandType                                                 = CommandType.StoredProcedure;

            m_cmdUpdEmployee = new SqlCommand("updEmployee", m_con);
            m_cmdUpdEmployee.Parameters.AddRange(new SqlParameter[]
               {
                  new SqlParameter("@employee_number"      , SqlDbType.Char, 6),
                  new SqlParameter("@employee_firstname"   , SqlDbType.NVarChar, 50),
                  new SqlParameter("@employee_lastname"    , SqlDbType.NVarChar, 50),
                  new SqlParameter("@employee_phone"       , SqlDbType.VarChar, 20),    
                  new SqlParameter("@employee_email"       , SqlDbType.VarChar, 20),
                  new SqlParameter("@employee_job"         , SqlDbType.Int),
                  new SqlParameter("@employee_departmentid", SqlDbType.Int),
                  new SqlParameter("@employee_id"         , SqlDbType.Int)
               });
            m_cmdUpdEmployee.CommandType = CommandType.StoredProcedure;

            m_cmdDelEmployee = new SqlCommand("delEmployee", m_con);
            m_cmdDelEmployee.Parameters.Add(new SqlParameter("@employee_id", SqlDbType.Int));
            m_cmdDelEmployee.CommandType = CommandType.StoredProcedure;


            m_cmUpdDepartment = new SqlCommand("updDepartment", m_con);
            m_cmUpdDepartment.Parameters.Add(new SqlParameter("@department_name", SqlDbType.NVarChar, 50));
            m_cmUpdDepartment.Parameters.Add(new SqlParameter("@department_code", SqlDbType.Char, 10));
            m_cmUpdDepartment.Parameters.Add(new SqlParameter("@parent_id"      , SqlDbType.Int));
            m_cmUpdDepartment.Parameters.Add(new SqlParameter("@manager_id"     , SqlDbType.Int));
            m_cmUpdDepartment.Parameters.Add(new SqlParameter("@ID"             , SqlDbType.Int));
            m_cmUpdDepartment.CommandType = CommandType.StoredProcedure;

            m_cmGetEmployees = new SqlCommand("getEmployees", m_con);
            m_cmGetEmployees.Parameters.Add(new SqlParameter("@departmentid", SqlDbType.Int));
            m_cmGetEmployees.CommandType = CommandType.StoredProcedure;
         }
         catch (Exception ex) {

            throw ex;
         }
         finally {
            m_con.Close();
         }

      }

      public int add(Employee item) {
         beginTran();
         m_cmdAddEmployee.Transaction = m_tran;
         
         m_cmdAddEmployee.Parameters["@employee_number"      ].Value = item.employe_number ;
         m_cmdAddEmployee.Parameters["@employee_firstname"   ].Value = item.first_name ;
         m_cmdAddEmployee.Parameters["@employee_lastname"    ].Value = item.last_name ;
         m_cmdAddEmployee.Parameters["@employee_phone"       ].Value = item.phone ;
         m_cmdAddEmployee.Parameters["@employee_email"       ].Value = item.email ;
         m_cmdAddEmployee.Parameters["@employee_job"         ].Value = (int)item.job ;
         m_cmdAddEmployee.Parameters["@employee_departmentid"].Value = item.department_id ;

         var ires    = m_cmdAddEmployee.ExecuteNonQuery();
         var iretval = Convert.ToInt32(m_cmdAddEmployee.Parameters["@emp_id"].Value);
         
         if (iretval > 0) {
            item.ID    = ires;
            item.state = DataRowState.Unchanged;
            Employee.identity = ++ires;
         }
         return ires;
      }

      public int remove(Employee item) {
         m_cmdDelEmployee.Parameters["@employee_id"].Value = item.ID;
         m_cmdDelEmployee.Transaction = m_tran;
         var irs = m_cmdDelEmployee.ExecuteNonQuery();
         if(irs > 0) item.state = DataRowState.Detached;
         return irs;
      }

      public int modify(Employee item) {
         beginTran();
         m_cmdUpdEmployee.Parameters["@employee_number"      ].Value = item.employe_number ;
         m_cmdUpdEmployee.Parameters["@employee_firstname"   ].Value = item.first_name ;
         m_cmdUpdEmployee.Parameters["@employee_lastname"    ].Value = item.last_name ;
         m_cmdUpdEmployee.Parameters["@employee_phone"       ].Value = item.phone ;
         m_cmdUpdEmployee.Parameters["@employee_email"       ].Value = item.email ;
         m_cmdUpdEmployee.Parameters["@employee_job"         ].Value = (int)item.job ;
         m_cmdUpdEmployee.Parameters["@employee_departmentid"].Value = item.department_id ;
         m_cmdUpdEmployee.Parameters["@employee_id"          ].Value = item.ID;
         m_cmdUpdEmployee.Transaction = m_tran;
         var irs = m_cmdUpdEmployee.ExecuteNonQuery();
         if(irs > 0) item.state = DataRowState.Unchanged; 
         return irs;
      }

      public int modifyDepartment(Department a_department) {
         beginTran();
         m_cmUpdDepartment.Parameters["@department_name"].Value = a_department.name;
         m_cmUpdDepartment.Parameters["@department_code"].Value = a_department.code;
         m_cmUpdDepartment.Parameters["@parent_id"      ].Value = a_department.parent_ID;
         m_cmUpdDepartment.Parameters["@manager_id"     ].Value = a_department.manager_id;
         m_cmUpdDepartment.Parameters["@ID"             ].Value = a_department.ID;
         m_cmUpdDepartment.Transaction = m_tran;
         return m_cmUpdDepartment.ExecuteNonQuery();
      }

      public DbDataReader getDepartments() {
         var cmd = new SqlCommand("SELECT * FROM [DepartmentView]", m_con);
         openConnection();
         var rdDepartments = cmd.ExecuteReader(CommandBehavior.CloseConnection);
         return rdDepartments;
      }


      public DbDataReader getEmployees(int a_departmentID = 0) {
         openConnection();
         m_cmGetEmployees.Parameters[0].Value = a_departmentID;
         var rdEmployees = m_cmGetEmployees.ExecuteReader(CommandBehavior.CloseConnection);
         return rdEmployees;
      }

      internal void openConnection() {
         if (m_con.State == ConnectionState.Open) return;
         try {
            m_con.Open();
         }
         catch (Exception ex) {
            throw ex;
         }
      }

      private void beginTran() {
         if(!isInTranscation) {
            openConnection();
            m_tran = m_con.BeginTransaction();
            isInTranscation = true;
         }
      }

      public void save() {
         if (isInTranscation) {
            m_tran.Commit();           
         }
         m_cmdAddEmployee.Transaction = null;
         m_cmdDelEmployee.Transaction = null;
         m_cmdUpdEmployee.Transaction = null;
         m_cmUpdDepartment.Transaction = null;
         m_tran = null;
         isInTranscation = false;
      }
     
      protected virtual void Dispose(bool disposing) {
         if (!disposedValue) {
            if (disposing) {
               // TODO: dispose managed state (managed objects)
               
               if(m_con != null) {
                  close();
                  m_tran.Dispose();
                  m_tran = null;
                  m_con.Dispose();
                  m_con = null;
               }
               if(m_cmdAddEmployee != null) {
                  m_cmdAddEmployee.Dispose();
                  m_cmdAddEmployee = null;
               }
               if(m_cmdUpdEmployee != null) {
                  m_cmdUpdEmployee.Dispose();
                  m_cmdUpdEmployee = null;
               }
               if(m_cmdDelEmployee != null) {
                  m_cmdDelEmployee.Dispose();
                  m_cmdDelEmployee = null;
               }
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
         }
      }

      // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
      // ~EmpoloyeesDAL()
      // {
      //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
      //     Dispose(disposing: false);
      // }

      public void Dispose() {
         // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
         Dispose(disposing: true);
         GC.SuppressFinalize(this);
      }

      public void close() {
         if (m_con.State == ConnectionState.Open) {
            if (isInTranscation) m_tran.Rollback();
            isInTranscation = false;
            m_cmdAddEmployee.Transaction = null;
            m_cmdDelEmployee.Transaction = null;
            m_cmdUpdEmployee.Transaction = null;
            m_con.Close();
         }
      }
   }
}
