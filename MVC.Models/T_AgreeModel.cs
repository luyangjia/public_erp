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
    public class T_AgreeModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int? AgreeIndex { get; set; }
        public string AgreeNo { get; set; }
        public string AgreeName { get; set; }
        public DateTime? AgreeDate { get; set; }
        public string Remark { get; set; }
        /// <summary>
        /// 审批协议的时候，1通过，3不同意
        /// </summary>
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
        public virtual T_ProjectModel Project { get; set; }
        /// <summary>
        /// 所属协议
        /// </summary>
        public virtual ICollection<T_AgreeListModel> AgreeList { get; set; }
        /// <summary>
        /// 查询传参，多种状态
        /// </summary>
        public List<int> StatusList { get; set; }
    }
    /// <summary>
    /// 查询对象
    /// </summary>
    public class  AgreeModel : Page
    {
        public int ProjectId { get; set; }
        /// <summary>
        /// 查询传参，多种状态
        /// </summary>
        public List<int> StatusList { get; set; }
    }
}
