using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{
    [Table("dbo.T_LeaveSetting")]
    public partial class T_LeaveSetting
    { 
        public int Id { get; set; } 
        public string Name { get; set; }
        public bool IsLimit { get; set; }
        public bool IsCarryOver { get; set; }
        public decimal Days { get; set; }
        public int Months { get; set; }
        public bool IsUnpaid { get; set; }
        public bool Enable { get; set; } 
       
    }
}
