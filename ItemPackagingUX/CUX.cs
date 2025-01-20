using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Data.SqlClient;

using DataReader.ux;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using ItemPackagingLogic.Entities;
using System.ComponentModel;
using ItemPackagingLogic.DataModules;
using Microsoft.VisualBasic.Devices;

namespace DataReader.ux
{
    public class CUX
    {
        // ....................................................................
        //PATTERN: Singleton. There can be only one instance of the class CApp
        private static CUX? __instance = null;
        public static CUX Instance
        {
            get
            {
                //PATTERN: Lazy initialization. The only instance is created at the first time that is needed.
                if (__instance == null)
                    __instance = new CUX();
                return __instance;
            }
        }
        // ....................................................................



        // --------------------------------------------------------------------------------------
        private CUX()
        {
        }
        // --------------------------------------------------------------------------------
        //PATTERNS: Factory method. Creates a module using the proper class for the give module type and returns it to a client object.
        //          The client object does not need to have visibility of the class types used inside the factory method
        //          and also does not need an specific implementation except the methods of the IDataModule interface.
        public static IBindingList CreateBindingList(DataModuleType p_nType, object p_oEntityList)
        {
            //[C#] Type-casting the parameter of the BindingList constructor is type-casted to the proper list type, e.g. list of CAppUser.

            switch (p_nType)
            {
                case DataModuleType.Item: return new BindingList<CItem>((List<CItem>)p_oEntityList);
                case DataModuleType.Measurement_Unit: return new BindingList<CMeasurement_Unit>((List<CMeasurement_Unit>)p_oEntityList);
                case DataModuleType.Item_Category: return new BindingList<CItem_Category>((List<CItem_Category>)p_oEntityList);
                case DataModuleType.Package_Type: return new BindingList<CPackage_Type>((List<CPackage_Type>)p_oEntityList);
                case DataModuleType.Project_Type: return new BindingList<CProject_Type>((List<CProject_Type>)p_oEntityList);
                default: return null;
            }
        }
        // --------------------------------------------------------------------------------------
    }
}
