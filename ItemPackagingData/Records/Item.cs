using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Lib.Data.DB;

namespace ItemPackagingData.Records
{
    public class Item:CDBRecord
    {
        [Key]
        public int ID { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int? Measurement_Unit_CID{ get; set; }
        public int? Item_Category_CID{ get; set; }
        public string Prod_By_Corp {  get; set; }


       



    }
}
