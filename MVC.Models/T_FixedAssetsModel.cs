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
    public class T_FixedAssetsModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public string AssetsNo { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string TypeSpecification { get; set; }
        public string Manufacturers { get; set; }
        public DateTime? DateProduction { get; set; }
        public DateTime? DatePurchase { get; set; }
        public int? ValidYear { get; set; }
        public decimal? BuyPrice { get; set; }
        public decimal? NowPrice { get; set; }
        public int? CompanyId { get; set; }
        public int? GroupId { get; set; }
        public int? UseUserId { get; set; }
        public string UseUserName { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        /// <summary>
        /// 查询时间
        /// </summary>
        public DateTime? BeginTime { get; set; }
        /// <summary>
        /// 查询时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 生成数据
        /// </summary>
        public int CreateNum { get; set; }
        public List<int> StatusList { get; set; }
    }
    /// <summary>
    /// 查询对象
    /// </summary>
    public class FixedAssetsModel : Page
    {
        public string AssetsNo { get; set; }
        public string Name { get; set; }
        public int? CompanyId { get; set; }
        public string Category { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Status { get; set;
        }
    }
    /// <summary>
    /// 修改
    /// </summary>
    public class EditFixedAssetsModel
    { 
        public int Id { get; set; }
        public string AssetsNo { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string TypeSpecification { get; set; }
        public string Manufacturers { get; set; }
        public DateTime? DateProduction { get; set; }
        public DateTime? DatePurchase { get; set; }
        public int? ValidYear { get; set; }
        public decimal? BuyPrice { get; set; } 
        public int? CompanyId { get; set; } 
        public string Address { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
         
    }
}
