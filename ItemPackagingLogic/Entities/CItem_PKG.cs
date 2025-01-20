using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemPackagingData.Records;

namespace ItemPackagingLogic.Entities
{
    public class CItem_PKG : CEntity<Item_PKG>
    {
        [Key]  //.NET: Example of declaring a field as primary key, using the Key attribute
        [Browsable(false)]
        public int ID
        {
            get { return this.Record.ID; }
            set { this.Record.ID = value; }
        }

        [Browsable(false)]
        public int ITEM_ID
        {
            get { return this.Record.Item_ID; }
            set { this.Record.Item_ID = value; }
        }
        public string Barcode
        {
            get { return this.Record.Barcode; }
            set { this.Record.Barcode = value; }
        }

        public string Serial_Num
        {
            get { return this.Record.Serial_Num; }
            set { this.Record.Serial_Num = value; }
        }

        public int? Package_Type_CID
        {
            get
            {
                if (this.Record.Package_Type_CID == 0)
                    return null;
                else
                    return this.Record.Package_Type_CID;
            }
            set { this.Record.Package_Type_CID = value ?? 0; }
        }

        public int? Dim_X
        {
            get { return this.Record.Dim_X; }
            set { this.Record.Dim_X = value; }
        }
        public int? Dim_Y
        {
            get { return this.Record.Dim_Y; }
            set { this.Record.Dim_Y = value; }
        }
        public int? Dim_Z
        {
            get { return this.Record.Dim_Z; }
            set { this.Record.Dim_Z = value; }
        }
        public int? Volume
        {
            get { return this.Record.Dim_X * this.Record.Dim_Y * this.Record.Dim_Z; }
            set { }
        }
        public DateTime? Created_Date
        {
            get { return this.Record.Created_Date; }
            set { this.Record.Created_Date = value; }
        }

        public CItem_PKG() : base()
        {

        }
    }
}
