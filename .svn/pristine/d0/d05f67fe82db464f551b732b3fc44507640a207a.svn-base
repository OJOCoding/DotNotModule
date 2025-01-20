using DataReader.data.Records;
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
    public class table_Item_PKG
    {
        // ....................................................................
        protected List<Item_PKG> records = new List<Item_PKG>();
        public List<Item_PKG> Records { get { return records; } }
        // ....................................................................
        public IDbTransaction? Transaction { get; set; }
        // ....................................................................

        public int MasterKey { get; set; }

        // --------------------------------------------------------------------------------------
        public table_Item_PKG()
        {
            this.Transaction = null;
        }
        // --------------------------------------------------------------------------------------
        public void LoadDetails()
        {
            var oRecords = CData.Instance.DB.Select<Item_PKG>(
                $"select * from Item_PKG where Item_ID = {this.MasterKey}");

            // When a select returns no records a null object might be returned by the method
            if (oRecords != null)
                this.records = oRecords;
        }
        // --------------------------------------------------------------------------------------
        public void SaveDetails()
        {
            if (this.records != null)
            {
                CData.Instance.DB.SaveChanges<Item_PKG>(this.records,

                            // Provide the insert statement that will be used for new records
                            @"
                                  insert into Item_PKG
                                  (
                         
	                                Item_ID,Barcode,Serial_Num,Package_Type_CID,Dim_X,Dim_Y,Dim_Z,Created_Date

                                  )
                                  values
                                  (
                                     @Item_ID,@Barcode,@Serial_Num,@Package_Type_CID,@Dim_X,@Dim_Y,@Dim_Z,@Created_Date

                                  )",

                            // Provide the update statement that will be used for updated records
                            @"
                                  update Item_PKG set
                                     Item_ID              = @Item_ID
                                    ,Barcode              = @Barcode
                                    ,Serial_Num              = @Serial_Num
                                    ,Package_Type_CID              = @Package_Type_CID
                                    ,Dim_X              = @Dim_X
                                    ,Dim_Y              = @Dim_Y
                                    ,Dim_Z              = @Dim_Z

                                    ,Created_Date              = @Created_Date
                                  where 
                                    ID = @ID
                                ",

                            // Provide the delete statement that will be used for deleted records
                            @"delete from Item_PKG where ID = @ID",
                            this.Transaction
                        );
            }
        }
        // --------------------------------------------------------------------------------------
    }
}
