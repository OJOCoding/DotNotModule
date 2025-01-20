using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Lib.Data.DB;
using Lib.Data.Attribs;

namespace ItemPackagingData.Records
{
    public class Package_Type : CDBRecord
    {
        [Key]
        [ColumnWidth(30)]
        public int ID { get; set; }
        [ColumnWidth(250)]
        public string? Name { get; set; }
     
    }
}
