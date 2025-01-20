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
    public class CProject_TypeModel : List<CProject_Type>
    {
        public table_Project_Type table = new table_Project_Type();

        public CProject_TypeModel()
        {
        }
        public void CreateEntries()
        {
            this.Clear();

            foreach (Project_Type oRecord in this.table.Records)
            {
                CProject_Type oEntry = new CProject_Type();

                oEntry.__record = oRecord;

                this.Add(oEntry);
            }
        }
        public void AddRecords()
        {
            foreach (CProject_Type oEntry in this)
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
