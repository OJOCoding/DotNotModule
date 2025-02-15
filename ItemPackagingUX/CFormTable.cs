﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ItemPackagingLogic.Entities;
using ItemPackagingLogic.Models;
using ItemPackagingLogic.DataModules;

using Lib.UX.DataGrid; // Add support for the extension method SetColumnSizes
using Lib.UX.Forms;
using Lib.UX.Forms.TableFormStates;
using ItemPackagingLogic;

namespace DataReader.ux
{
    // In Version 2 of this example we have made the proper structural changes in the design of our application
    // so that this form is reusable by any table data module.
    //  * We extended the IDataModule interface
    //  * We rely on the factory method pattern to use different classes for instantiating the composite objects module and __dsTable.


    public partial class CFormTable : Form
    {
        //OO PRINCIPLES: Abstraction. This form does not depend on a specific class of module.
        protected IDataModule module;
        //OO PRINCIPLES: Abstraction. This form does not depend on a specific class of binding list.
        private IBindingList __dsTable;
        protected CTableFormContext dataFormContext;
        protected DataGridViewComboBoxColumn? cboDetailPT = null;


        // ....................................................................
        public IEntity? GridCurrentEntry
        {
            get
            {
                IEntity? oResult = null;
                if (this.gridRecords.CurrentRow != null)
                    oResult = this.gridRecords.CurrentRow.DataBoundItem as IEntity;

                return oResult;
            }
        }
        // ....................................................................

        private DataModuleType __dataModuleType;


        // --------------------------------------------------------------------------------------
        public CFormTable(DataModuleType p_nType)
        {
            InitializeComponent();
            this.__dataModuleType = p_nType;

            // Creating a new context and assigning the controls that will be handled by the states of the context
            this.dataFormContext = new CTableFormContext()
            {
                LoadTable = this.btnLoadTable,
                SaveTable = this.btnSaveTable
            };  //[C#] This is a special block to assign properties of an object after instantiation without repeating the object identifier

            // Sets the state of the form to the initial
            //[C#] The parameter of Initialize receives a class type. Ctrl-Click to go inside Initialize to read more on this advanced technique.
            this.dataFormContext.Initialize(typeof(CTableFormStateInitial));

            this.module = CItemPackagingLogic.CreateDataModule(this.__dataModuleType);

            //PATTERNS: Observer: Subscribe this form's data module to receive notifications by the observer (publisher)
            CItemPackagingLogic.Instance.Observer.Subscribe(this.module);
        }
        // --------------------------------------------------------------------------------------
        private void DoOnFormClosed(object sender, FormClosedEventArgs e)
        {
            //PATTERNS: Observer: Unsubscribe this form's data module because its form is destroyed.
            CItemPackagingLogic.Instance.Observer.UnSubscribe(this.module);
        }
        // --------------------------------------------------------------------------------------
        private void DoOnAddRow(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (this.GridCurrentEntry != null)
            {
                this.GridCurrentEntry.Change = EntryChangeType.CREATED;
                this.dataFormContext.PerformAction("CreateRow");
            }
        }
        // --------------------------------------------------------------------------------------
        private void DoOnEditRow(object sender, DataGridViewCellEventArgs e)
        {
            if (this.GridCurrentEntry != null)
            {
                this.GridCurrentEntry.Change = EntryChangeType.UPDATED;
                this.gridRecords.Refresh();
                this.dataFormContext.PerformAction("EditRow");
            }
        }
        // --------------------------------------------------------------------------------------
        private void DoOnGridKeyDown(object sender, KeyEventArgs e)
        {
            if (this.module.IsLoaded && (!this.gridRecords.ReadOnly))
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        {
                            if (this.GridCurrentEntry != null)
                            {
                                DialogResult oResult = MessageBox.Show("Delete this record?", "Warning", MessageBoxButtons.YesNo
                                                            , MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                                if (oResult == DialogResult.Yes)
                                {
                                    this.GridCurrentEntry.Change = EntryChangeType.DELETED;
                                    Debug.WriteLine("Delete Row");

                                    this.gridRecords.Rows.RemoveAt(this.gridRecords.CurrentRow.Index);
                                    this.gridRecords.Refresh();
                                    this.dataFormContext.PerformAction("DeleteRow");
                                }
                            }
                            e.Handled = true; //[.NET] When the keystroke should not be further used we mark it as handled.
                            break;
                        }
                }

            }
        }
        // --------------------------------------------------------------------------------------
        protected void displayEntryList()
        {
            //.NET: This is an example of data binding, where the mechanism shows a row for each object
            //    and a column for each public property that is declared on the class

            // Create a BindingList to allow table edit operations
            this.__dsTable = CUX.CreateBindingList(this.__dataModuleType, this.module.Model);
            // Bind with the grid
            this.gridRecords.DataSource = this.__dsTable;
            if(this.__dataModuleType == DataModuleType.Measurement_Unit) { addLookupComboBoxOnDetailList(); }
            


            //C#: This is an example on using an extension method. 
            //this.gridRecords.SetColumnSizes(typeof(CPackage_Type));


        }
        protected void addLookupComboBoxOnDetailList()
        {
            //PATTERNS: Lazy Initialization. In this case we will create the column when it is first needed
            //          and prevent for adding it each time we load/create a new master entity

            if (this.cboDetailPT == null)
            {
                this.cboDetailPT = new DataGridViewComboBoxColumn()
                {
                    HeaderText = "Project Type",
                    Width = 200,
                    ValueMember = "CID",             // The key field of the lookup entity
                    DisplayMember = "DisplayText",    // The field that will used for displaying a lookup entity
                    DataPropertyName = "PROJECT_TYPE_CID",        // The foreign key field on the detail entity that will receive the selected value
                };

                // Adds the column to the grid
                this.gridRecords.Columns.Add(cboDetailPT);
            }
            CModuleMeasurement_Unit oModule = (CModuleMeasurement_Unit)this.module;
            // (Re)loads all the options
            this.cboDetailPT.DataSource = oModule.Project_Type;
        }
        // --------------------------------------------------------------------------------------
        private void DoOnAnyCommand(object sender, EventArgs e)
        {
            if (sender == this.btnLoadTable)
            {
                if (this.module.Load())
                {
                    this.displayEntryList();
                    this.dataFormContext.PerformAction("TableLoaded");
                }
                else
                    MessageBox.Show(this.module.LastError, " Error");

            }
            else
            {
                DialogResult oResult = MessageBox.Show("Save changes?", "Warning"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (oResult == DialogResult.Yes)
                {
                    if (this.module.Save())
                    {
                        this.gridRecords.DataSource = null;
                        if (this.module.Load())
                        {
                            this.displayEntryList();
                            this.dataFormContext.PerformAction("TableLoaded");
                        }
                        else
                            MessageBox.Show(this.module.LastError, "Error");
                    }
                    else
                        MessageBox.Show(this.module.LastError, "Error");
                }
            }
        }
        // --------------------------------------------------------------------------------------
        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }
        public void OpenDialogInCenter()
        {
            // Set the StartPosition property to CenterParent
            this.StartPosition = FormStartPosition.CenterParent;

            // Show the dialog
            this.ShowDialog();
        }
    }
}
