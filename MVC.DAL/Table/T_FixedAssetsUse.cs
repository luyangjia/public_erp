using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{

    [Table("dbo.T_FixedAssetsUse")]
    public partial class T_FixedAssetsUse
    {
        public int Id { get; set; }
        public int AssetsId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public int? CompanyId { get; set; }
        public int? GroupId { get; set; }
        public int? UseUserId { get; set; }
        public string UseUserName { get; set; }
        public string Address { get; set; } 
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
    }
}
