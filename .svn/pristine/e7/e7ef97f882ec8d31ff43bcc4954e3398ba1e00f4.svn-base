using ItemPackagingData.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemPackagingLogic.Entities
{
    public class CItem_Category : CEntity<Item_Category>
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

        public int Level
        {
            get { return this.Record.Level; }
            set { this.Record.Level = value; }
        }
        public int? Parent_Category_ID
        {
            get { return this.Record.Parent_Category_CID; }
            set { this.Record.Parent_Category_CID = value; }
        }

        public string DisplayText { get { return this.ToString(); } }

        public CItem_Category() : base()
        {

        }

        // --------------------------------------------------------------------------------------
        public override string ToString()
        {
            return $"{this.Name} ({this.Level})";
        }
        // --------------------------------------------------------------------------------------
    }
}
