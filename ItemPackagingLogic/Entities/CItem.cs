using DataReader.data.Records;
using ItemPackagingData.Records;
using ItemPackagingLogic.DataModules;
using ItemPackagingLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemPackagingLogic.Entities
{
    public class CItem : CEntity<Item>
    {
        public CModuleItem ParentModule { get; set; }

        [Key]  //.NET: Example of declaring a field as primary key, using the Key attribute
        public int Id
        {
            get { return this.Record.ID; }
            set { this.Record.ID = value; }
        }

        public string Code
        {
            get { return this.Record.Code; }
            set { this.Record.Code = value; }
        }
        public string Name
        {
            get { return this.Record.Name; }
            set { this.Record.Name = value; }
        }
        public decimal Price
        {
            get { return this.Record.Price; }
            set { this.Record.Price = value; }
        }
        public int? Measurement_Unit_CID
        {
            get { return this.Record.Measurement_Unit_CID; }
            set
            {
                this.Record.Measurement_Unit_CID = value;
            }

        }
        public int? Item_Category_CID
        {
            get { return this.Record.Item_Category_CID; }
            set
            {
                this.Record.Item_Category_CID = value;
            }

        }

        public string Prod_By_Corp
        {
            get { return this.Record.Prod_By_Corp; }
            set { this.Record.Prod_By_Corp = value; }   
        
        }



        // --------------------------------------------------------------------------------------
        public CItem() : base()
        {
        }
        // --------------------------------------------------------------------------------------        
    }

}
