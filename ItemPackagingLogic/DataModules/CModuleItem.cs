﻿using DataReader;
using DataReader.data.Records;
using ItemPackagingLogic.Entities;
using ItemPackagingLogic.Models;
using ItemPackagingLogic.DataModules;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItemPackagingLogic.DataModules
{
    public class CModuleItem : CDataModule
    {
        // ....................................................................
        private CItemModel __model = new CItemModel();

        //[C#] The use of the new keyword hides the ancestor property Model that is of type Object.
        public new CItemModel Model { get { return __model; } }
        // ....................................................................

        #region // Lookup Models \\
        // ....................................................................
        public CItem_CategoryModel ItemCategories = new CItem_CategoryModel();
        // ....................................................................
        public CPackage_TypeModel PackageType = new CPackage_TypeModel();
        // ....................................................................
        public CMeasuremet_UnitModel MeasurementUnits = new CMeasuremet_UnitModel();

        public CProject_TypeModel Project_Type = new CProject_TypeModel();

        // ....................................................................
        #endregion


        #region // Overriden Methods \\
        protected override Object getModel() { return this.__model; }
        // --------------------------------------------------------------------------------------
        public override bool LoadLookups()
        {
            Debug.WriteLine($"AppUser Module #{this.moduleID} --> loading lookups");
            bool bResult = false;
            try
            {
                ItemCategories.table.LoadTable();
                ItemCategories.CreateEntries();

                MeasurementUnits.table.LoadTable();
                MeasurementUnits.CreateEntries();

                PackageType.table.LoadTable();
                PackageType.CreateEntries(); 

                Project_Type.table.LoadTable();
                Project_Type.CreateEntries();
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }
        // --------------------------------------------------------------------------------------
        public override bool LoadBrowser(Dictionary<string, Object> p_oCriteria)
        {
            bool bResult = false;
            try
            {
                // Reloads the browser
                __model.browser.LoadTable();
                __model.CreateBrowserEntries();

                this.IsLoaded = true;
                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }
        // --------------------------------------------------------------------------------------
        public override bool LoadMaster(int p_nKeyValue)
        {
            int nKeyValue = p_nKeyValue;
            if (p_nKeyValue == -1)
                nKeyValue = __model.master.Records[0].PrimaryKeyValue;

            bool bResult = false;
            try
            {
                __model.master.LoadRecord(nKeyValue);
                __model.detail.MasterKey = nKeyValue;
                __model.detail.LoadDetails();
                __model.CreateMasterDetailEntity();
                __model.Item.ParentModule = this;

                this.IsLoaded = true;
                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }
        // --------------------------------------------------------------------------------------
        public override bool Save()
        {
            bool bResult = false;
            try
            {
                __model.SaveMasterDetail();
                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }
        // --------------------------------------------------------------------------------------
        public override bool New()
        {
            __model.Clear();

            __model.Item.Change = EntryChangeType.CREATED;
            __model.Item.ParentModule = this;

            this.IsLoaded = true;
            return true;
        }
        // --------------------------------------------------------------------------------------
        public override bool Delete()
        {
            bool bResult = false;

            try
            {
                __model.DeleteMasterDetail();
                bResult = true;
            }
            catch (Exception oException)
            {
                this.LastError = oException.Message;
            }
            return bResult;
        }
        // --------------------------------------------------------------------------------------
        #endregion
    }
}
