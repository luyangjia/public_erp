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
    public class T_AgreeListModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int AgreeId { get; set; }
        public int? CostId { get; set; }
        public int? CategoryId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Qty { get; set; }
        /// <summary>
        /// 库中原来的价格
        /// </summary>
        public decimal? Profit { get; set; }
        public decimal? Price { get; set; }
        /// <summary>
        /// 盈利
        /// </summary>
        public decimal CostMarkup { get; set; }

        public decimal TotalPrice { get; set; }
        public decimal TotalCost { get; set; }
        
    }
    /// <summary>
    /// 查询对象
    /// </summary>
    public class AgreeList : Page
    {
        public int AgreeId { get; set; } 
        public int? CategoryId { get; set; }
    }
    /// <summary>
    /// 数据提交
    /// </summary>
    public class T_AgreeListPost
    {
        public string Action { get; set; }
        public List<T_AgreeListModel> dataList { get; set; }
    }
}
