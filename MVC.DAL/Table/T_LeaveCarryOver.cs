using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{
    [Table("dbo.T_LeaveCarryOver")]
    public partial class T_LeaveCarryOver
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Year { get; set; }
        public int SetingId { get; set; }
        public string SetingName { get; set; }
        public decimal Days { get; set; } 
    }
}
