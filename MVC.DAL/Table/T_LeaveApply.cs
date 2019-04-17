using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{
    [Table("dbo.T_LeaveApply")]
    public partial class T_LeaveApply
    {
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
    }
}
