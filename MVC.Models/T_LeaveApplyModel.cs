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
    public class T_LeaveApplyModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime FromDate { get; set; }
        public string FromType { get; set; }
        public DateTime EndDate { get; set; }
        public string EndType { get; set; }
        public int SetingId { get; set; }
        public string SetingName { get; set; }
        public decimal Days { get; set; }
        public string Reaon { get; set; }
        public int Status { get; set; }
        public string Undo { get; set; }
        public int? AppyId { get; set; }
        public int? ApprovalId { get; set; }
        public string ApprovalName { get; set; }
        public string ApprovalReaon { get; set; }
        public string PayrollNo { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUser { get; set; }
        public int IsLock { get; set; }

        /// <summary>
        /// 查询传参，多种状态
        /// </summary>
        public List<int> StatusList { get; set; }
        /// <summary>
        /// 已用多少天
        /// </summary>
        public decimal UseDays{ get; set; }
        /// <summary>
        /// 今年总共多少天
        /// </summary>
        public decimal TotalDays { get; set; }
    }
    /// <summary>
    /// 查询对象
    /// </summary>
    public class LeaveApplyModel : Page
    {
        public string UserName { get; set; }
        public int SetingId { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public int UserId { get; set; }
    }
}
