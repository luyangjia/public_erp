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
    public class T_LogModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string StaffName { get; set; }
        public string Ip { get; set; }
        public string Types { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 查询传参，开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }
        /// <summary>
        /// 查询传参，结束时间
        /// </summary>
        public DateTime? EndTime { get; set; } 
    }
    /// <summary>
    /// 查询对象
    /// </summary>
    public class LogModel : Page
    {
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
