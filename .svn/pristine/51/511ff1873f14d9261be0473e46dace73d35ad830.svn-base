using ItemPackagingData.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemPackagingLogic.Entities
{
    public class CMeasurement_Unit : CEntity<Measurement_Unit>
    {

        [Key]
        public int CID
        {
            get { return this.Record.CID; }
            set { this.Record.CID = value; }
        }

        public string Name
        {
            get { return this.Record.Name; }
            set { this.Record.Name = value; }
        }

        public string Symbol
        {
            get { return this.Record.Symbol; }
            set { this.Record.Symbol = value; }
        }

        
        public int? PROJECT_TYPE_CID
        {
            get
            {
                if (this.Record.PROJECT_TYPE_CID == 0)
                    return null;
                else
                    return this.Record.PROJECT_TYPE_CID;
            }
            set { this.Record.PROJECT_TYPE_CID = value ?? 0; }
        }


        public string DisplayText { get { return this.ToString(); } }

        public CMeasurement_Unit() : base()
        {

        }

        // --------------------------------------------------------------------------------------
        public override string ToString()
        {
            return $"{this.Name} ({this.Symbol})";
        }
        // --------------------------------------------------------------------------------------
    }
}
