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
    public class Item_PKG : CDBRecord
    {
        [Key]
        public int ID { get; set; }
        public int Item_ID { get; set; }
        public string? Barcode { get; set; }
        public string? Serial_Num { get; set; }
        public int Package_Type_CID { get; set; }
        public int? Dim_X { get; set; }
        public int? Dim_Y { get; set; }
        public int? Dim_Z { get; set; }
        public DateTime? Created_Date {  get; set; }
        

    }
}
