﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Lib.Data.DB;


namespace ItemPackagingData.Records
{
    public class Measurement_Unit : CDBRecord
    {
        [Key]
        public int CID { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public int? PROJECT_TYPE_CID { get; set; }



    }
}
