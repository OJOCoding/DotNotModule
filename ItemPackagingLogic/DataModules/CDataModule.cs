using DataReader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemPackagingLogic.DataModules
{
    // After developing two different module we realized that some members are common between the two classes.
    // Especially the properties and methods that the interface IDataModule dicates.
    //
    // At this iteration of development we move the common code to a new ancestor class, and make the existing
    // classes inherit from CDataModule and implement IDataModule.

    public class CDataModule: IDataModule
    {
        private static int __nextModuleID = 1;
        protected int moduleID;
        

        // ....................................................................
        public String LastError { get; set; }
        // ....................................................................
        public bool IsLoaded { get; set; }
        // ....................................................................

        // --------------------------------------------------------------------------------------
        public CDataModule()
        {
            //[C#]: Using class (static) fields to keep a global variable on the class, visible by all objects.
            //TECHNIQUE: Having an auto-increment ID for each new object instance.
            this.moduleID = CDataModule.__nextModuleID;
            __nextModuleID++;

            this.LastError = "";
            this.IsLoaded = false;
        }
        // --------------------------------------------------------------------------------------

        #region // IDataModule \\
        // --------------------------------------------------------------------------------------
        public Object Model { get { return getModel(); } }
        
        //[C#] This is an example of a virtual getter method
        protected virtual Object getModel() { return null; }
        // --------------------------------------------------------------------------------------
        public virtual bool LoadLookups() { return false; }
        // --------------------------------------------------------------------------------------
        public virtual bool LoadBrowser(Dictionary<string, Object> p_oCriteria) { return false; }
        // --------------------------------------------------------------------------------------
        public virtual bool LoadBrowserFirstPage(Dictionary<string, Object> p_oCriteria) { return false; }
        // --------------------------------------------------------------------------------------
        public virtual bool LoadBrowserNextPage() { return false; }
        // --------------------------------------------------------------------------------------
        public virtual bool LoadBrowserPrevPage() { return false; }
        // --------------------------------------------------------------------------------------
        public virtual bool Load() { return false; }
        // --------------------------------------------------------------------------------------
        public virtual bool LoadMaster(int p_nKeyValue) { return false;}
        // --------------------------------------------------------------------------------------
        public virtual bool Save() { return false;}
        // --------------------------------------------------------------------------------------
        public virtual bool New() { return false;}
        // --------------------------------------------------------------------------------------
        public virtual bool Delete() { return false;}
        // --------------------------------------------------------------------------------------
        #endregion
    }
}
