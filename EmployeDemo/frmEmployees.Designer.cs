
namespace EmployeDemo {
   partial class frmEmployees {
      /// <summary>
      ///  Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      ///  Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      ///  Required method for Designer support - do not modify
      ///  the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployees));
         this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
         this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
         this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
         this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
         this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.m_txtDeptName = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.m_cbManager = new System.Windows.Forms.ComboBox();
         this.m_cbParent = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.m_txtCode = new System.Windows.Forms.TextBox();
         this.button1 = new System.Windows.Forms.Button();
         this.employenumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.lastnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.m_dgvcbJob = new System.Windows.Forms.DataGridViewComboBoxColumn();
         this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
         this.bindingNavigator1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
         this.SuspendLayout();
         // 
         // bindingNavigator1
         // 
         this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
         this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
         this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
         this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
         this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
         this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
         this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
         this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
         this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
         this.bindingNavigator1.Name = "bindingNavigator1";
         this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
         this.bindingNavigator1.Size = new System.Drawing.Size(563, 25);
         this.bindingNavigator1.TabIndex = 0;
         this.bindingNavigator1.Text = "bindingNavigator1";
         // 
         // bindingNavigatorAddNewItem
         // 
         this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorAddNewItem.Enabled = false;
         this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
         this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
         this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorAddNewItem.Text = "Add new";
         this.bindingNavigatorAddNewItem.Visible = false;
         // 
         // bindingNavigatorCountItem
         // 
         this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
         this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
         this.bindingNavigatorCountItem.Text = "of {0}";
         this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
         // 
         // bindingNavigatorDeleteItem
         // 
         this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorDeleteItem.Enabled = false;
         this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
         this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
         this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorDeleteItem.Text = "Delete";
         this.bindingNavigatorDeleteItem.Visible = false;
         // 
         // bindingNavigatorMoveFirstItem
         // 
         this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
         this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
         this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMoveFirstItem.Text = "Move first";
         this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
         // 
         // bindingNavigatorMovePreviousItem
         // 
         this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
         this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
         this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMovePreviousItem.Text = "Move previous";
         this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
         // 
         // bindingNavigatorSeparator
         // 
         this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
         this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
         // 
         // bindingNavigatorPositionItem
         // 
         this.bindingNavigatorPositionItem.AccessibleName = "Position";
         this.bindingNavigatorPositionItem.AutoSize = false;
         this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
         this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
         this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
         this.bindingNavigatorPositionItem.Text = "0";
         this.bindingNavigatorPositionItem.ToolTipText = "Current position";
         // 
         // bindingNavigatorSeparator1
         // 
         this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
         this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // bindingNavigatorMoveNextItem
         // 
         this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
         this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
         this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMoveNextItem.Text = "Move next";
         this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
         // 
         // bindingNavigatorMoveLastItem
         // 
         this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
         this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
         this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
         this.bindingNavigatorMoveLastItem.Text = "Move last";
         this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
         // 
         // bindingNavigatorSeparator2
         // 
         this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
         this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // m_txtDeptName
         // 
         this.m_txtDeptName.Location = new System.Drawing.Point(111, 39);
         this.m_txtDeptName.Name = "m_txtDeptName";
         this.m_txtDeptName.Size = new System.Drawing.Size(156, 20);
         this.m_txtDeptName.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 39);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(93, 13);
         this.label1.TabIndex = 2;
         this.label1.Text = "Department Name";
         // 
         // dataGridView1
         // 
         this.dataGridView1.AutoGenerateColumns = false;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employenumberDataGridViewTextBoxColumn,
            this.firstnameDataGridViewTextBoxColumn,
            this.lastnameDataGridViewTextBoxColumn,
            this.m_dgvcbJob,
            this.phoneDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
         this.dataGridView1.DataSource = this.employeeBindingSource;
         this.dataGridView1.Location = new System.Drawing.Point(15, 115);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.Size = new System.Drawing.Size(536, 210);
         this.dataGridView1.TabIndex = 3;
         // 
         // m_cbManager
         // 
         this.m_cbManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.m_cbManager.FormattingEnabled = true;
         this.m_cbManager.Location = new System.Drawing.Point(111, 68);
         this.m_cbManager.Name = "m_cbManager";
         this.m_cbManager.Size = new System.Drawing.Size(156, 21);
         this.m_cbManager.TabIndex = 6;
         this.m_cbManager.SelectionChangeCommitted += new System.EventHandler(this.m_cbManager_SelectionChangeCommitted);
         // 
         // m_cbParent
         // 
         this.m_cbParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.m_cbParent.FormattingEnabled = true;
         this.m_cbParent.Location = new System.Drawing.Point(397, 68);
         this.m_cbParent.Name = "m_cbParent";
         this.m_cbParent.Size = new System.Drawing.Size(134, 21);
         this.m_cbParent.TabIndex = 7;
         this.m_cbParent.SelectionChangeCommitted += new System.EventHandler(this.m_cbManager_SelectionChangeCommitted);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(47, 68);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(49, 13);
         this.label2.TabIndex = 8;
         this.label2.Text = "Manager";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(356, 71);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(38, 13);
         this.label3.TabIndex = 9;
         this.label3.Text = "Parent";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(356, 39);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(32, 13);
         this.label4.TabIndex = 10;
         this.label4.Text = "Code";
         // 
         // m_txtCode
         // 
         this.m_txtCode.Location = new System.Drawing.Point(394, 36);
         this.m_txtCode.Name = "m_txtCode";
         this.m_txtCode.Size = new System.Drawing.Size(134, 20);
         this.m_txtCode.TabIndex = 11;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(476, 347);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 12;
         this.button1.Text = "Save";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // employenumberDataGridViewTextBoxColumn
         // 
         this.employenumberDataGridViewTextBoxColumn.DataPropertyName = "employe_number";
         this.employenumberDataGridViewTextBoxColumn.HeaderText = "Emp. Number";
         this.employenumberDataGridViewTextBoxColumn.Name = "employenumberDataGridViewTextBoxColumn";
         // 
         // firstnameDataGridViewTextBoxColumn
         // 
         this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "first_name";
         this.firstnameDataGridViewTextBoxColumn.HeaderText = "First Name";
         this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
         // 
         // lastnameDataGridViewTextBoxColumn
         // 
         this.lastnameDataGridViewTextBoxColumn.DataPropertyName = "last_name";
         this.lastnameDataGridViewTextBoxColumn.HeaderText = "Last Name";
         this.lastnameDataGridViewTextBoxColumn.Name = "lastnameDataGridViewTextBoxColumn";
         // 
         // m_dgvcbJob
         // 
         this.m_dgvcbJob.DataPropertyName = "job";
         this.m_dgvcbJob.HeaderText = "job";
         this.m_dgvcbJob.Name = "m_dgvcbJob";
         this.m_dgvcbJob.Resizable = System.Windows.Forms.DataGridViewTriState.True;
         this.m_dgvcbJob.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
         // 
         // phoneDataGridViewTextBoxColumn
         // 
         this.phoneDataGridViewTextBoxColumn.DataPropertyName = "phone";
         this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
         this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
         // 
         // emailDataGridViewTextBoxColumn
         // 
         this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
         this.emailDataGridViewTextBoxColumn.HeaderText = "e-mail";
         this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
         // 
         // employeeBindingSource
         // 
         this.employeeBindingSource.DataSource = typeof(EmployeDemo.Model.Employee);
         // 
         // frmEmployees
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(563, 382);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.m_txtCode);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.m_cbParent);
         this.Controls.Add(this.m_cbManager);
         this.Controls.Add(this.dataGridView1);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.m_txtDeptName);
         this.Controls.Add(this.bindingNavigator1);
         this.Name = "frmEmployees";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.frmEmployees_Load);
         ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
         this.bindingNavigator1.ResumeLayout(false);
         this.bindingNavigator1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.BindingNavigator bindingNavigator1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
      private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
      private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
      private System.Windows.Forms.TextBox m_txtDeptName;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.ComboBox m_cbManager;
      private System.Windows.Forms.ComboBox m_cbParent;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox m_txtCode;
      private System.Windows.Forms.BindingSource employeeBindingSource;
      private System.Windows.Forms.DataGridViewTextBoxColumn employenumberDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn lastnameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewComboBoxColumn m_dgvcbJob;
      private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
      private System.Windows.Forms.Button button1;
   }
}

