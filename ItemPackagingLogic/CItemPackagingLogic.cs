﻿using DataReader;
using System.Xml.Linq;
using ItemPackagingLogic.DataModules;


namespace ItemPackagingLogic
{
    public class CItemPackagingLogic
    {
        // ....................................................................
        //PATTERN: Singleton. There can be only one instance of the class CApp
        private static CItemPackagingLogic? __instance = null;
        public static CItemPackagingLogic Instance
        {
            get
            {
                //PATTERN: Lazy initialization. The only instance is created at the first time that is needed.
                if (__instance == null)
                    __instance = new CItemPackagingLogic();
                return __instance;
            }
        }
        // ....................................................................
        private CDataModuleObserver __observer = new CDataModuleObserver();
        public CDataModuleObserver Observer { get { return __observer; } }
        // ....................................................................

        // --------------------------------------------------------------------------------
        private CItemPackagingLogic()
        {

        }
        // --------------------------------------------------------------------------------
        //PATTERNS: Factory method. Creates a module using the proper class for the give module type and returns it to a client object.
        //          The client object does not need to have visibility of the class types used inside the factory method
        //          and also does not need an specific implementation except the methods of the IDataModule interface.
        public static IDataModule CreateDataModule(DataModuleType p_nType)
        {
            switch (p_nType)
            {
                case DataModuleType.Item: return new CModuleItem();
                case DataModuleType.Measurement_Unit: return new CModuleMeasurement_Unit();
                case DataModuleType.Package_Type: return new CModulePackage_Type();
                case DataModuleType.Item_Category: return new CModuleItem_Category();
                case DataModuleType.Project_Type: return new CModuleProject_Type();
                default: return null;
            }
        }
    }
}