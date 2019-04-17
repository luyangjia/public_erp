using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{

    [Table("dbo.T_Agree")]
    public partial class T_Agree 
    {
        public T_Agree()
        {
            AgreeList = new HashSet<T_AgreeList>(); 
        }
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int? AgreeIndex { get; set; }
        public string AgreeNo { get; set; }
        public string AgreeName { get; set; }
        public DateTime? AgreeDate { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public string ApprovalUserIds { get; set; }
        public string ApprovalUserNames { get; set; }
        public int? ApprovalUserId { get; set; }
        public string ApprovalUserName { get; set; }
        public decimal? CostTotal { get; set; }
        public decimal? PriceTotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Gst { get; set; }
        public decimal? GstTotal { get; set; }
        public decimal? GrandTotal { get; set; }
        public int? AgreeUserId { get; set; }
        public string AgreeUserName { get; set; } 
        /// <summary>
        /// 所属项目
        /// </summary>
         [ForeignKey("ProjectId")]
        public virtual T_Project Project { get; set; }
        /// <summary>
        /// 所属协议
        /// </summary>
        public virtual ICollection<T_AgreeList> AgreeList { get; set; }

    }
}
