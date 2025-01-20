using DataReader;
using DataReader.data.Tables;
using ItemPackagingData.Records;
using ItemPackagingLogic.Entities;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemPackagingLogic.Models
{
    public class CItem_CategoryModel : List<CItem_Category>
    {
        public table_Item_Category table = new table_Item_Category();

        // --------------------------------------------------------------------------------------
        public CItem_CategoryModel()
        {
        }
        // --------------------------------------------------------------------------------------
        public void CreateEntries()
        {
            this.Clear();

            foreach (Item_Category oRecord in this.table.Records)
            {
                CItem_Category oEntry = new CItem_Category();
                oEntry.__record = oRecord;

                this.Add(oEntry);
            }
        }
       public void AddRecords()
        {
            foreach (CItem_Category oEntry in this)
            {
                if (oEntry.Change == EntryChangeType.CREATED)
                {
                    if (this.table.Records.IndexOf(oEntry.Record) == -1)
                        this.table.Records.Add(oEntry.Record);
                }
            }
        }
    }
}