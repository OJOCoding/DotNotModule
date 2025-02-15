﻿using DataReader.data.Records;
using ItemPackagingData.Records;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.data.Tables
{
    public class table_Package_Type
    {
        // ....................................................................
        protected List<Package_Type> records = new List<Package_Type>();
        public List<Package_Type> Records { get { return records; } }
        // ....................................................................


        // --------------------------------------------------------------------------------------
        public table_Package_Type()
        {

        }
        // --------------------------------------------------------------------------------------
        public void LoadTable()
        {
            var oRecords = CData.Instance.DB.Select<Package_Type>("select * from Package_Type");

            // When a select returns no records a null object might be returned by the method
            if (oRecords != null)
                this.records = oRecords;
        }
        // --------------------------------------------------------------------------------------
        public void SaveTable()
        {
            if (this.records != null)
            {
                CData.Instance.DB.SaveChanges<Package_Type>(this.records,

                            // Provide the insert statement that will be used for new records
                            @"
                                  insert into Package_Type
                                  (
                                     Name
	                                
                                  )
                                  values
                                  (
                                     @Name
                                  )",

                            // Provide the update statement that will be used for updated records
                            @"
                                  update Package_Type set
                                     Name              = @Name
=                                   where 
                                    ID = @ID
                                ",

                            // Provide the delete statement that will be used for deleted records
                            @"delete from Package_Type where ID = @ID"
                        );

                // We reload the table to reflect all the changes that have been saved in the DB
                this.LoadTable();
            }
        }
        // --------------------------------------------------------------------------------------

    }
}
