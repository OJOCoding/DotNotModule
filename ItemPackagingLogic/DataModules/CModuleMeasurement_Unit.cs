using ItemPackagingLogic;
using ItemPackagingLogic.DataModules;
using ItemPackagingLogic.Models;

public class CModuleMeasurement_Unit : CDataModule
{
    // ....................................................................
    private CMeasuremet_UnitModel __model = new CMeasuremet_UnitModel();
    // ....................................................................
    public CProject_TypeModel Project_Type = new CProject_TypeModel();

    // --------------------------------------------------------------------------------------
    public CModuleMeasurement_Unit() : base()
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
            Project_Type.table.LoadTable();
            Project_Type.CreateEntries();

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