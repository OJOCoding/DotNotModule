using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Lib.Data.Attribs; 

namespace DataReader.data.Records
{
    public class View_Item    {
        [Key]                  
        [ReadOnly(true)]        
        [ColumnWidth(30)]       
        public int ID { get; set; }

        [DisplayName("Name")]
        [ReadOnly(true)]
        [ColumnWidth(250)]
        public string? Name { get; set; }

        [DisplayName("Symbol")]
        [ReadOnly(true)]
        [ColumnWidth(250)]
        public string? Symbol { get; set; }


        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", this.ID, this.Name, this.Symbol);
        }
    }
}
