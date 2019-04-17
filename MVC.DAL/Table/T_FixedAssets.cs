using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{

    [Table("dbo.T_FixedAssets")]
    public partial class T_FixedAssets
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
          
    }
}
