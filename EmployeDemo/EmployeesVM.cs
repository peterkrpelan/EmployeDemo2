using EmployeDemo.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EmployeDemo {
   public class EmployeesVM {
      private EmpoloyeesDAL m_empdb;
      private BindingList<Department> m_lstDepartments;
      private List<Employee> m_lstEmployes;
      private Department m_deptCuurent;
      private BindingList<Employee> m_FilteredEmploys;
      public EmployeesVM() {
         m_empdb          = new EmpoloyeesDAL();
         m_lstDepartments = new BindingList<Department>();
         m_lstEmployes    = new List<Employee>();

         m_lstDepartments.ListChanged += lstDepartments_ListChanged;
         

         jobs = new List<Job>(){
            new Job() { ID = 1, name = "CEO" },
            new Job() { ID = 2, name = "DIRTECTOR" },
            new Job() { ID = 3, name = "MANAGER" },
            new Job() { ID = 4, name = "STAFF" },
            new Job() { ID = 5, name = "WORKER" }
         };

      }

      private void lstDepartments_ListChanged(object sender, ListChangedEventArgs e) {
         if(e.ListChangedType == ListChangedType.ItemChanged) {
            var _dep = m_lstDepartments[e.NewIndex];
            if(_dep.manager_id.HasValue && _dep.manager_id > 0) {
               var ixEmp =m_lstEmployes.FindIndex(x => x.ID == _dep.manager_id);
               if(ixEmp > 0 && m_lstEmployes[ixEmp].department_id != _dep.ID) {
                  m_lstEmployes[ixEmp].department_id = _dep.ID;
                  m_FilteredEmploys.Add(m_lstEmployes[ixEmp]);
                  if(m_lstEmployes[ixEmp].state != System.Data.DataRowState.Added) m_lstEmployes[ixEmp].state = System.Data.DataRowState.Modified;
               }
            }
         }
      }

      private void lstEmployes_ListChanged(object sender, ListChangedEventArgs e) {
         BindingList<Employee> _empList = sender as BindingList<Employee>;


         switch (e.ListChangedType) {
            case ListChangedType.Reset:
               break;
            case ListChangedType.ItemAdded:
               var _rAdd           = _empList[e.NewIndex];
               _rAdd.department_id = currentDepartment.ID;

               if(_rAdd.state != System.Data.DataRowState.Modified) _rAdd.state = System.Data.DataRowState.Added;

               var ix = m_lstEmployes.FindIndex(x => x.ID == _rAdd.ID && x.state != System.Data.DataRowState.Unchanged);

               if(ix == -1)  m_lstEmployes.Add(_rAdd);
               break;
            case ListChangedType.ItemDeleted:
               var _rDel = _empList[e.NewIndex];
               var _st   = _rDel.state;

               var idel = m_lstEmployes.FindIndex(x => x.ID == _rDel.ID);
               if (idel > -1) m_lstEmployes[idel].state = (_st == System.Data.DataRowState.Added) ? System.Data.DataRowState.Detached : System.Data.DataRowState.Deleted;

               break;
            default:
               break;
         }
      }

      public void load() {
         using (var rd = m_empdb.getDepartments()) {
            int iMngCol = rd.GetOrdinal("DEPARTMENT_MANAGERID");
            while (rd.Read()) {
               var iMngColVal = rd.IsDBNull(iMngCol) ? -1 : rd.GetInt32(iMngCol);

               m_lstDepartments.Add(
                  new Department(
                     Convert.ToInt32(rd["DEPARTMENT_ID"]),
                     rd["DEPARTMENT_CODE"].ToString(),
                     rd["DEPARTMENT_NAME"].ToString(),
                     iMngColVal,
                     Convert.ToInt32(rd["PARENT_ID"])) { level = Convert.ToInt32(rd["DEPARMENT_LEVEL"]) });

            }//while (rd.Read()) {
         }//using (var rd = m_empdb.getDepartments()) {


         using (var rdEmp = m_empdb.getEmployees()) {
            int iMailCol = rdEmp.GetOrdinal("EMPLOYEE_EMAIL");
            var iPhonCol = rdEmp.GetOrdinal("EMPLOYEE_PHONE");
            while (rdEmp.Read()) {

               var _phon = (rdEmp.IsDBNull(iPhonCol) ? "" : rdEmp.GetString(iPhonCol));
               var _mail = (rdEmp.IsDBNull(iMailCol) ? "" : rdEmp.GetString(iMailCol));

               m_lstEmployes.Add(
                  new Employee(
                     Convert.ToInt32(rdEmp["EMPLOYEE_ID"]),
                     rdEmp["EMPLOYEE_NUMBER"].ToString(),
                     rdEmp["EMPLOYEE_FIRSTNAME"].ToString(),
                     rdEmp["EMPLOYEE_LASTNAME"].ToString(),
                     Convert.ToInt32(rdEmp["EMPLOYEE_JOB"]),
                     _phon,
                     _mail,
                     Convert.ToInt32(rdEmp["EMPLOYEE_DEPARTMENTID"])));

               //if (m_lstEmployes.Last().job < 4) m_lstManagers.Add(m_lstEmployes.Last());

            }//while (rdEmp.Read()) {

         }
      }

      public bool isTopDepartment {
         get {
            if (currentDepartment is null || currentDepartment.level == 1) return true;
            return false;
         }
      }

      public List<Job> jobs { get; private set; }

      private Department currentDepartment {
         get { return m_deptCuurent; }
      }

      public void setCurrentDepartment(object currentRow) {
         m_deptCuurent = currentRow as Department;
      }

      public IEnumerable<Employee> managers {
         get { return m_lstEmployes.Where(x => x.job < 4); }

      }

      public BindingList<Department> parentDepartments {
         get {
            if (currentDepartment is null || currentDepartment.level == 1) return new BindingList<Department>();
            var filteredDept = new BindingList<Department>(m_lstDepartments.Where(x => x.level == currentDepartment.level - 1).ToList());
            return filteredDept;
         }
      }

      public void saveChanges() {
         var _changDep = m_lstDepartments.Where(x => x.state == System.Data.DataRowState.Modified).ToArray();
         if (_changDep.Length > 0) {
            m_empdb.modifyDepartment(_changDep[0]);
         }
         var _addEmployes = m_lstEmployes.Where(x => x.state == System.Data.DataRowState.Added).ToArray();
         for (int i = 0; i < _addEmployes.Length; i++) {
            m_empdb.add(_addEmployes[i]);

         }
         var _updEmployes = m_lstEmployes.Where(x => x.state == System.Data.DataRowState.Modified).ToArray();
         for (int i = 0; i < _updEmployes.Length; i++) {
            m_empdb.modify(_updEmployes[i]);
         }
         var _delEmployes = m_lstEmployes.Where(x => x.state == System.Data.DataRowState.Deleted).ToArray();
         for (int i = 0; i < _delEmployes.Length; i++) {
            m_empdb.remove(_delEmployes[i]);
         }
         m_empdb.save();
         m_lstEmployes.RemoveAll(x => x.state == System.Data.DataRowState.Detached);
      }
      public BindingList<Department> departments { get { return m_lstDepartments; } }

      public BindingList<Employee> departmentEmployees {
         get {
            m_FilteredEmploys = new BindingList<Employee>(m_lstEmployes.Where(x => x.department_id == currentDepartment.ID && x.state != System.Data.DataRowState.Deleted).ToList());
            m_FilteredEmploys.ListChanged += lstEmployes_ListChanged;
            return m_FilteredEmploys;
         }
      }


   }
}
