using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{

    [Table("dbo.T_Log")]
    public partial class T_Log
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string StaffName { get; set; }
        public string Ip { get; set; }
        public string Types { get; set; }
        public DateTime CreateTime { get; set; } 
    }
}
