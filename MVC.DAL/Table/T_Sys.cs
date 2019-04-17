using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{
    
    [Table("dbo.T_Sys")]
    public partial class T_Sys
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public decimal Listorder { get; set; } 
    }
}
