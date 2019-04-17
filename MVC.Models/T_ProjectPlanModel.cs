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
    public class T_ProjectPlanModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
     
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } 
        public virtual T_ProjectModel Projects { get; set; }
    }
    /// <summary>
    /// 查询对象
    /// </summary>
    public class ProjectPlanModel : Page
    {
        public int ProjectId { get; set; }
    }
}
