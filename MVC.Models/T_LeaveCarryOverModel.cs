using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models
{
    /// <summary>
    /// DTO对象
    /// </summary>
    public class T_LeaveCarryOverModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Year { get; set; }
        public int SetingId { get; set; }
        public string SetingName { get; set; }
        public decimal Days { get; set; } 

    }
    /// <summary>
    /// 查询对象
    /// </summary>
    public class LeaveCarryOver : Page
    { 
    }
    
}
