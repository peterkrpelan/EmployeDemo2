using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeDemo.Model {
   public class Department: INotifyPropertyChanged {

      private string m_strCode;
      private string m_strName;
      private int? m_iParent;
      private int? m_iManager;

      public event PropertyChangedEventHandler PropertyChanged;
      public Department(int aID, string aCode, string aName, int? aManagerID, int? aParent) {
         ID         = aID;
         m_strCode  = aCode;
         m_strName  = aName;
         m_iManager = aManagerID;
         m_iParent  = aParent;
         state      = DataRowState.Unchanged;
      }
      public string code {
         get { return m_strCode; }
         set {
            if (m_strCode != value) {
               this.m_strCode = value;
               NotifyPropertyChanged();
            }
         }
      }
      public string name {
         get { return m_strName; }
         set {
            if (m_strName != value) {
               m_strName = value;
               NotifyPropertyChanged();
            }
         }
      }
      public int ID { get; internal set; }
      public int? parent_ID {
         get { return m_iParent; }
         set {
            if(m_iParent != value) {
               m_iParent = value;
               NotifyPropertyChanged();
            }
         }
      }
      public int? manager_id {
         get { return m_iManager; }
         set {
            if(m_iManager != value) {
               m_iManager = value;
               NotifyPropertyChanged();
            } 
         }
      }
      public int level { get; internal set; }
      private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
         state = DataRowState.Modified;
      }

      public DataRowState state { get; internal set; }


   }
}
