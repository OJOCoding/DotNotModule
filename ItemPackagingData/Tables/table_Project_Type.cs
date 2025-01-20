using DataReader.data.Records;
using ItemPackagingData.Records;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.data.Tables
{
    public class table_Project_Type
    {
        // ....................................................................
        protected List<Project_Type> records = new List<Project_Type>();
        public List<Project_Type> Records { get { return records; } }
        // ....................................................................


        // --------------------------------------------------------------------------------------
        public table_Project_Type()
        {

        }
        // --------------------------------------------------------------------------------------
        public void LoadTable()
        {
            var oRecords = CData.Instance.DB.Select<Project_Type>("select * from Project_Type");

            // When a select returns no records a null object might be returned by the method
            if (oRecords != null)
                this.records = oRecords;
        }
        // --------------------------------------------------------------------------------------
        public void SaveTable()
        {
            if (this.records != null)
            {
                CData.Instance.DB.SaveChanges<Project_Type>(this.records,

                            // Provide the insert statement that will be used for new records
                            @"
                                  insert into Project_Type
                                  (
                                     GENERAL_LEDGER_CODE
	                                ,DESCR ,IS_UPDATING_GENERAL_LEDGER
                                  )
                                  values
                                  (
                                     @GENERAL_LEDGER_CODE
	                                ,@DESCR ,@IS_UPDATING_GENERAL_LEDGER
                                  )",

                            // Provide the update statement that will be used for updated records
                            @"
                                  update Project_Type set
                                     GENERAL_LEDGER_CODE              = @GENERAL_LEDGER_CODE
	                                ,DESCR              = @DESCR
                                    ,IS_UPDATING_GENERAL_LEDGER = @IS_UPDATING_GENERAL_LEDGER
                                  where 
                                    CID = @CID
                                ",

                            // Provide the delete statement that will be used for deleted records
                            @"delete from Project_Type where CID = @CID"
                        );

                // We reload the table to reflect all the changes that have been saved in the DB
                this.LoadTable();
            }
        }
        // --------------------------------------------------------------------------------------

    }
}
