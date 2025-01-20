using ItemPackagingLogic;
using ItemPackagingLogic.DataModules;
using ItemPackagingLogic.Models;

public class CModulePackage_Type : CDataModule
{
    // ....................................................................
    private CPackage_TypeModel __model = new CPackage_TypeModel();
    // ....................................................................

    // --------------------------------------------------------------------------------------
    public CModulePackage_Type() : base()
    {
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