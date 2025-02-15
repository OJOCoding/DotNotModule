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
    public class table_Item_Category
    {
        // ....................................................................
        protected List<Item_Category> records = new List<Item_Category>();
        public List<Item_Category> Records { get { return records; } }
        // ....................................................................


        // --------------------------------------------------------------------------------------
        public table_Item_Category()
        {

        }
        // --------------------------------------------------------------------------------------
        public void LoadTable()
        {
            var oRecords = CData.Instance.DB.Select<Item_Category>("select * from Item_Category");

            // When a select returns no records a null object might be returned by the method
            if (oRecords != null)
                this.records = oRecords;
        }
        // --------------------------------------------------------------------------------------
        public void SaveTable()
        {
            if (this.records != null)
            {
                CData.Instance.DB.SaveChanges<Item_Category>(this.records,

                            // Provide the insert statement that will be used for new records
                            @"
                                  insert into Item_Category
                                  (
                                     CID
	                                ,Name, Level, Parent_Category_CID
                                  )
                                  values
                                  (
                                     @CID
	                                ,@Name, @Level, @Parent_Category_CID
                                  )",

                            // Provide the update statement that will be used for updated records
                            @"
                                  update Item_Category set
                                     Name              = @Name
	                                ,Level              = @Level                                     Name              = @Name
	                                ,Parent_Category_CID              = @Parent_Category_CID
                                  where 
                                    CID = @CID
                                ",

                            // Provide the delete statement that will be used for deleted records
                            @"delete from Item_Category where CID = @CID"
                        );

                // We reload the table to reflect all the changes that have been saved in the DB
                this.LoadTable();
            }
        }
        // --------------------------------------------------------------------------------------

    }
}
