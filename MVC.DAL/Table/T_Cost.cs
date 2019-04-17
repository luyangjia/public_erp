using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{

    [Table("dbo.T_Cost")]
    public partial class T_Cost
    { 
        public int Id { get; set; }
        public string Group { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public decimal Cost { get; set; }
        public decimal Profit { get; set; }
        public string Remark { get; set; }
        public bool Enable { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
  
        [ForeignKey("CategoryId")]
        public virtual T_SysList Category { get; set; }
        [ForeignKey("SupplierId")]
        public virtual T_Supplier Supplier { get; set; }

    }
}
