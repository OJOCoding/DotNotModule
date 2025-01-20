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
    public class CPackage_TypeModel : List<CPackage_Type>
    {
        public table_Package_Type table = new table_Package_Type();

        public CPackage_TypeModel()
        {
        }
        public void CreateEntries()
        {
            this.Clear();

            foreach (Package_Type oRecord in this.table.Records)
            {
                CPackage_Type oEntry = new CPackage_Type();

                oEntry.__record = oRecord;

                this.Add(oEntry);
            }
        }
       public void AddRecords()
        {
            foreach (CPackage_Type oEntry in this)
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
