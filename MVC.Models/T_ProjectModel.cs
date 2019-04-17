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
    public class T_ProjectModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public int? ClientId { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public DateTime? VisitDate { get; set; }  
        public string Property { get; set; }
        public string Towi { get; set; }
        public string ProjectType { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; } 
        public string Blk { get; set; }
        public string StreetName { get; set; }
        public string BuildingName { get; set; }
        public string Unit { get; set; }
        public string PostalCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// 客户详细信息
        /// </summary>
        public virtual T_ClientModel Client { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司详细信息
        /// </summary>
        public virtual T_CompanyModel Company { get; set; } 

        public virtual ICollection<T_ProjectUserModel> ProjectUsers { get; set; }
        
        /// <summary>
        /// 项目负责人 获取t_projectuser role=Manager 的第一个人
        /// </summary>
        /// 
        public string Leader { get; set; }
        public virtual ICollection<T_ProjectPlanModel> ProjectPlans { get; set; }
        public virtual ICollection<T_AgreeModel> ProjectAgrees { get; set; }
        /// <summary>
        /// 查询传参，多种状态
        /// </summary>
        public List<int> StatusList { get; set; }
    }
    /// <summary>
    /// 查询对象
    /// </summary>
    public class ProjectModel : Page
    {
        public string Description { get; set; } 
    }
    public class T_ProjectEditModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public int? ClientId { get; set; } 
        public string ProjectName { get; set; }
        public DateTime? VisitDate { get; set; }
        public string Property { get; set; }
        public string Towi { get; set; }
        public string ProjectType { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Blk { get; set; }
        public string StreetName { get; set; }
        public string BuildingName { get; set; }
        public string Unit { get; set; }
        public string PostalCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public string Remark { get; set; }
       
    }
}
