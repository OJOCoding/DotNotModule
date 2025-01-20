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
    public class table_Measurement_Unit
    {
        // ....................................................................
        protected List<Measurement_Unit> records = new List<Measurement_Unit>();
        public List<Measurement_Unit> Records { get { return records; } }
        // ....................................................................


        // --------------------------------------------------------------------------------------
        public table_Measurement_Unit()
        {

        }
        // --------------------------------------------------------------------------------------
        public void LoadTable()
        {
            var oRecords = CData.Instance.DB.Select<Measurement_Unit>("select * from Measurement_Unit");

            // When a select returns no records a null object might be returned by the method
            if (oRecords != null)
                this.records = oRecords;
        }
        // --------------------------------------------------------------------------------------
        public void SaveTable()
        {
            if (this.records != null)
            {
                CData.Instance.DB.SaveChanges<Measurement_Unit>(this.records,

                            // Provide the insert statement that will be used for new records
                            @"
                                  insert into Measurement_Unit
                                  (
                                     Name
	                                ,Symbol,PROJECT_TYPE_CID
                                  )
                                  values
                                  (
                                     @Name
	                                ,@Symbol,@PROJECT_TYPE_CID
                                  )",

                            // Provide the update statement that will be used for updated records
                            @"
                                  update Measurement_Unit set
                                     Name              = @Name
	                                ,Symbol              = @Symbol
                                    ,PROJECT_TYPE_CID    =@PROJECT_TYPE_CID
                                  where 
                                    CID = @CID
                                ",

                            // Provide the delete statement that will be used for deleted records
                            @"delete from Measurement_Unit where CID = @CID"
                        );

                // We reload the table to reflect all the changes that have been saved in the DB
                this.LoadTable();
            }
        }
        // --------------------------------------------------------------------------------------

    }
}
