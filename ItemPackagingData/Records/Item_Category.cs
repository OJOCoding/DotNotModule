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
    public class Item_Category:CDBRecord
    {
        [Key]
        public int CID { get; set; }
        public string? Name { get; set; }
        public int Level { get; set; }
        public int? Parent_Category_CID { get; set; }
    }
}
