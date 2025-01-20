using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Schema;
using System.Diagnostics;

using Lib.Data.DB;

namespace DataReader.data
{
    public class CData
    {
        // ....................................................................
        //PATTERN: Singleton. There can be only one instance of the class CApp
        private static CData? __instance = null;
        public static CData Instance
        {
            get
            {
                //PATTERN: Lazy initialization. The only instance is created at the first time that is needed.
                if (__instance == null)
                    __instance = new CData();
                return __instance;
            }
        }
        // ....................................................................


        // ....................................................................
        private CDBMSSQLLocal? __db = null;
        public CDBMSSQLLocal DB
        {
            get
            {
                //PATTERN: Lazy initialization. The only instance is created at the first time that is needed.
                if (__db == null)
                {
                    //C#: Example of a shortcut syntax for instantiation of an object with a block that assigns its properties
                    __db = new CDBMSSQLLocal()
                    {
                        InstanceName = CAppSettings.Instance.InstanceName ?? "MyInstance"
                                ,
                        DatabaseName = CAppSettings.Instance.DatabaseName ?? "ItemPackages"
                                ,
                        DBPath = CAppSettings.Instance.DatabasePath
                    };
                }
                return __db;
            }

            set
            {
                if (__db != null)
                    __db.Disconnect();
                __db = value;
            }
        }
        // ....................................................................



        // --------------------------------------------------------------------------------------
        private CData()
        {
        }
        // --------------------------------------------------------------------------------------
    }
}
