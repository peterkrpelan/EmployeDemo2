using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeDemo.Model {
   public class Employee : INotifyPropertyChanged, IEquatable<Employee> {

      private string m_strEmpNum;
      private string m_strFrsName;
      private string m_strLstName;
      private int m_iJob;
      private string m_strPhone;
      private string m_strMail;
      private int m_iDepartID;
      internal static int identity = 1;
      public Employee() {
         m_iJob = 4;
         ID = identity++;
         state = DataRowState.Added;
      }
      public Employee(int aID, string aEmpNum, string aFrsName, string aLstName, int aJob, string aPhone, string aMail, int aDeptID) {
         ID = aID;
         identity = aID;
         m_strEmpNum = aEmpNum;
         m_strFrsName = aFrsName;
         m_strLstName = aLstName;
         m_iJob = aJob;
         m_strPhone = aPhone;
         m_strMail = aMail;
         m_iDepartID = aDeptID;
         state = DataRowState.Unchanged;
      }
      public string employe_number {
         get { return m_strEmpNum; }
         set {
            if (m_strEmpNum != value) {
               m_strEmpNum = value;
               notifyPropertyChanged();
            }
         }
      }
      public string first_name {
         get { return m_strFrsName; }
         set {
            if (m_strFrsName != value) {
               m_strFrsName = value;
               notifyPropertyChanged();
            }
         }
      }
      public string last_name {
         get { return m_strLstName; }
         set {
            if (m_strLstName != value) {
               m_strLstName = value;
               notifyPropertyChanged();
            }
         }

      }
      public int job {
         get { return m_iJob; }
         set {
            if (m_iJob != value) {
               m_iJob = value;
               notifyPropertyChanged();
            }
         }
      }
      public string phone {
         get { return m_strPhone; }
         set {
            if (m_strPhone != value) {
               m_strPhone = value;
               notifyPropertyChanged();
            }
         }
      }
      public string email {
         get { return m_strMail; }
         set {
            if (m_strMail != value) {
               m_strMail = value;
               notifyPropertyChanged();
            }
         }

      }
      public int department_id {
         get { return m_iDepartID; }
         set {
            if (m_iDepartID != value) {
               m_iDepartID = value;
               notifyPropertyChanged();
            }
         }
      }
      public int ID { get; internal set; }

      public event PropertyChangedEventHandler PropertyChanged;

      private void notifyPropertyChanged([CallerMemberName] String propertyName = "") {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
         if (state == DataRowState.Unchanged) state = DataRowState.Modified;
      }

      public override int GetHashCode() {
         return Tuple.Create<string, string, string>(m_strEmpNum, m_strFrsName, m_strLstName).GetHashCode();
      }

      public override bool Equals(object obj) {
         return Equals(obj as Employee);
      }


      public static bool operator == (Employee person1, Employee person2) {
         if (((object)person1) == null || ((object)person2) == null) return Object.Equals(person1, person2);
         return person1.Equals(person2);
      }

      public static bool operator != (Employee person1, Employee person2){
         if (((object)person1) == null || ((object)person2) == null) return !Object.Equals(person1, person2);
         return person1.Equals(person2);

      }
      public bool Equals(Employee other) {
         if (m_strEmpNum == other.employe_number && m_strFrsName == other.first_name && m_strLstName == other.last_name) return true;
         return false;
      }

      public DataRowState state { get; internal set; }
   }


}
