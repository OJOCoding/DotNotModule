using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemPackagingLogic.Models;

namespace ItemPackagingLogic.DataModules
{
    public class CModuleItem_Category : CDataModule
    {
        // ....................................................................
        private CItem_CategoryModel __model = new CItem_CategoryModel();
        // ....................................................................

        // --------------------------------------------------------------------------------------
        public CModuleItem_Category() : base()  {
        }
        // --------------------------------------------------------------------------------------

        #region // Overriden Methods \\
        protected override Object getModel() { return this.__model; }
        // --------------------------------------------------------------------------------------
        public override bool Load()
        {
            bool bResult = false;
            try
            {
                __model.table.LoadTable();
                __model.CreateEntries();
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
                __model.AddRecords();
                __model.table.SaveTable();

                 CItemPackagingLogic.Instance.Observer.NotifyAllToReloadLookups();

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