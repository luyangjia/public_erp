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
    public class T_CostModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public string Group { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public decimal Cost { get; set; }
        public decimal Profit { get; set; }
        /// <summary>
        /// 做项目的时候用，Price=Profit
        /// </summary>
        public decimal Price { get; set; }
        public string Remark { get; set; }
        public bool Enable { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; } 
        public virtual T_SysListModel Category { get; set; } 
        public virtual T_SupplierModel Supplier { get; set; }
        /// <summary>
        /// Category 当前的ID的名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Category 最顶级的名称
        /// </summary>
        public string CategoryLoopName { get; set; }
        /// <summary>
        /// Category 从顶级到最下面的路径，比如 1-2-3-4
        /// </summary>
        public string CategoryFromName { get; set; }
        /// <summary>
        /// 盈利
        /// </summary>
        public decimal CostMarkup { get; set; }
        /// <summary>
        /// 数量，默认1
        /// </summary>

        public decimal Qty 
        {
            get;
            set;
        }


 


    }
    /// <summary>
    /// 查询对象
    /// </summary>
    public class CostModel : Page
    {
        public string Description { get; set; }
        public int? CategoryId { get; set; }
    }
}
