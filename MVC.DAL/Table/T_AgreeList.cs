using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{

    [Table("dbo.T_AgreeList")]
    public partial class T_AgreeList
    {

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
        [ForeignKey("ProjectId")]
        public virtual T_Project Project { get; set; }
        [ForeignKey("AgreeId")]
        public virtual T_Agree Agree { get; set; }
    }
}
