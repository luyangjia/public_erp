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
    public class T_FixedAssetsUseModel
    {
        public string Action { get; set; }

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
    /// <summary>
    /// 查询对象
    /// </summary>
    public class FixedAssetsUseModel : Page
    {

    }
}
