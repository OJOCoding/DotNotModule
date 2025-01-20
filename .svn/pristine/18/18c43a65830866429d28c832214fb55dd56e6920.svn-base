using ItemPackagingData.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemPackagingLogic.Entities
{
    public class CProject_Type : CEntity<Project_Type>
    {

        [Key]
        public int CID
        {
            get { return this.Record.CID; }
            set { this.Record.CID = value; }
        }

        public string GENERAL_LEDGER_CODE
        {
            get { return this.Record.GENERAL_LEDGER_CODE; }
            set { this.Record.GENERAL_LEDGER_CODE = value; }
        }

        public string Descr
        {
            get { return this.Record.Descr; }
            set { this.Record.Descr = value; }
        }
        public int IS_UPDATING_GENERAL_LEDGER
        {
            get { return this.Record.IS_UPDATING_GENERAL_LEDGER; }
            set { this.Record.IS_UPDATING_GENERAL_LEDGER = value; }
        }


        public string DisplayText { get { return this.ToString(); } }

        public CProject_Type() : base()
        {

        }

        // --------------------------------------------------------------------------------------
        public override string ToString()
        {
            return $"{this.GENERAL_LEDGER_CODE}";
        }
        // --------------------------------------------------------------------------------------
    }
}
