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
    public class T_ProjectFeeModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int PayNo { get; set; }
        public string Remark { get; set; }
        public DateTime? PlanPayDate { get; set; }
        public DateTime? PayDate { get; set; }
        public decimal PlayFee { get; set; }
        public int Status { get; set; } 
        public virtual T_ProjectModel Projects { get; set; }
    }
    /// <summary>
    /// 查询对象
    /// </summary>
    public class ProjectFeeModel : Page
    {
        public int ProjectId { get; set; }
    }
}
