﻿using DataReader.data.Records;
using ItemPackagingData.Records;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.data.Tables
{
    public class table_Item
    {
        // ....................................................................
        protected List<Item> records = new List<Item>();
        public List<Item> Records { get { return records; } }
        // ....................................................................
        public IDbTransaction? Transaction { get; set; }
        // ....................................................................

        public int MasterKey { get; set; }

        // --------------------------------------------------------------------------------------
        public table_Item()
        {
            this.Transaction = null;
        }
        // --------------------------------------------------------------------------------------
        public void LoadRecord(int p_nID)
        {
            // We create an object to hold the ID parameter for the select statement
            Item? oParams = new Item();
            oParams.ID = p_nID;

            using (var iTransaction = CData.Instance.DB.BeginTransaction())
            {
                try
                {
                    var oRecords = CData.Instance.DB.SelectWithParams<Item>(
                            "select * from Item where ID = @ID", oParams, iTransaction);
                    iTransaction.Commit();

                    // When a select returns no records a null object might be returned by the method
                    if (oRecords != null)
                    {
                        this.records = oRecords;

                        foreach (var oRecord in this.records)
                            Debug.WriteLine(oRecord.ToString());
                    }
                }
                catch
                {
                    iTransaction.Rollback();
                    throw;
                }
            }
        }
        public void LoadTable()
        {
            var oRecords = CData.Instance.DB.Select<Item>("select * from Item");

            // When a select returns no records a null object might be returned by the method
            if (oRecords != null)
            {
                this.records = oRecords;

                foreach (var oRecord in this.records)
                    Debug.WriteLine(oRecord.ToString());
            }
        }
        // --------------------------------------------------------------------------------------

        
        public void SaveTable()
        {
            try
            {
                if (this.records != null)
                {
                    CData.Instance.DB.SaveChanges<Item>(
                        this.records,
                        // Provide the insert statement for new records
                        @"
                    INSERT INTO Item
                    (Code, Name, Price, Measurement_Unit_CID, Item_Category_CID, Prod_By_Corp)
                    VALUES (@Code, @Name, @Price, @Measurement_Unit_CID, @Item_Category_CID, @Prod_By_Corp)
                ",
                        // Provide the update statement for updated records
                        @"
                    UPDATE Item
                    SET Code = @Code, Name = @Name, Price = @Price, Measurement_Unit_CID = @Measurement_Unit_CID,
                        Item_Category_CID = @Item_Category_CID, Prod_By_Corp = @Prod_By_Corp
                    WHERE ID = @ID
                ",
                        // Provide the delete statement for deleted records
                        @"DELETE FROM Item WHERE ID = @ID",
                        this.Transaction
                    );
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Debug.WriteLine($"Error in SaveTable: {ex.Message}");
                throw; // Rethrow the exception to indicate the failure
            }
        }

        // --------------------------------------------------------------------------------------
    }
}
