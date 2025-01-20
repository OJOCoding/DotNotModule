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
    public class CMeasuremet_UnitModel : List<CMeasurement_Unit>
    {
        public table_Measurement_Unit table = new table_Measurement_Unit();

        public CMeasuremet_UnitModel()
        {
        }
        public void CreateEntries()
        {
            this.Clear();

            foreach (Measurement_Unit oRecord in this.table.Records)
            {
                CMeasurement_Unit oEntry = new CMeasurement_Unit();

                oEntry.__record = oRecord;

                this.Add(oEntry);
            }
        }
        public void AddRecords()
        {
            foreach (CMeasurement_Unit oEntry in this)
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
