using ItemPackagingData.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemPackagingLogic.Entities
{
    public class CPackage_Type : CEntity<Package_Type>
    {

        [Key]
        public int ID
        {
            get { return this.Record.ID; }
            set { this.Record.ID = value; }
        }

        public string? Name
        {
            get { return this.Record.Name; }
            set { this.Record.Name = value; }
        }

        public string DisplayText { get { return this.ToString(); } }

        public CPackage_Type() : base()
        {

        }

        // --------------------------------------------------------------------------------------
        public override string ToString()
        {
            return $"{this.Name}";
        }

    }
}