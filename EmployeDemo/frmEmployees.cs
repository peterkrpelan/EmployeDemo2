using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeDemo {
   public partial class frmEmployees : Form {
      private EmployeesVM m_employeesVM;
      private BindingSource m_bsDepartments;
      private int iLastMgr = -1;
      public frmEmployees() {
         InitializeComponent();
         m_employeesVM   = new EmployeesVM();
         m_bsDepartments = new BindingSource();

        
         m_bsDepartments.DataSource       = m_employeesVM.departments; 
         bindingNavigator1.BindingSource  = m_bsDepartments;
         
         m_txtDeptName.DataBindings.Add("Text", m_bsDepartments, nameof(Model.Department.name), false, DataSourceUpdateMode.OnValidation);
         m_txtCode.DataBindings.Add("Text", m_bsDepartments, nameof(Model.Department.code), false, DataSourceUpdateMode.OnPropertyChanged);

         m_cbParent.DataBindings.Add("SelectedValue", m_bsDepartments, nameof(Model.Department.parent_ID), false, DataSourceUpdateMode.OnPropertyChanged);
         m_cbParent.DataBindings.Add(new Binding("Enabled", m_employeesVM, nameof(m_employeesVM.isTopDepartment)));
         m_cbParent.DisplayMember = nameof(Model.Department.name);
         m_cbParent.ValueMember   = nameof(Model.Department.ID);

         m_cbManager.DataBindings.Add("SelectedValue", m_bsDepartments, nameof(Model.Department.manager_id));
         m_cbManager.DisplayMember = nameof(Model.Employee.last_name);
         m_cbManager.ValueMember   = nameof(Model.Employee.ID);

         m_dgvcbJob.DisplayMember = nameof(Model.Job.name);
         m_dgvcbJob.ValueMember   = nameof(Model.Job.ID);
         m_dgvcbJob.DataSource    = m_employeesVM.jobs;


         iLastMgr = m_cbManager.SelectedIndex;
    
         //this.Load += delegate { m_employeesVM.load(); };
      }

      private void frmEmployees_Load(object sender, EventArgs e) {
         m_employeesVM.load();
         m_cbManager.DataSource = m_employeesVM.managers.ToList();
         changeDataSource();
      }


      private void m_cbManager_SelectionChangeCommitted(object sender, EventArgs e) {
         var cb = (ComboBox)sender;
         var cv    = bindingNavigator1.BindingSource.CurrencyManager;
         var _prop = cb.DataBindings[0].BindingMemberInfo.BindingField;
         var o_src = cb.SelectedItem.GetType().GetProperty(cb.ValueMember);
         var _id   = o_src.GetValue(cb.SelectedItem);
         var o_obj = cv.Current.GetType().GetProperty(_prop);
         o_obj.SetValue(cv.Current, _id);
         cv.EndCurrentEdit();
      }

      private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e) {
         move();       
      }

      private void move() {
         changeDataSource();
         m_employeesVM.saveChanges();
      }

      private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e) {
         move();

      }

      private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e) {
         move();
      }

      private void changeDataSource() {
         m_employeesVM.setCurrentDepartment(m_bsDepartments.Current);
         employeeBindingSource.DataSource = m_employeesVM.departmentEmployees;
         m_cbParent.Enabled       = (m_employeesVM.isTopDepartment) ? false : true;
         m_cbParent.DataSource    = m_employeesVM.parentDepartments;
      }
      private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e) {
         move();

      }

      private void button1_Click(object sender, EventArgs e) {
         m_employeesVM.saveChanges();
      }

   }
}
