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
   public class T_ProjectUserModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string CommissionType { get; set; }
        public decimal Commission { get; set; } 
        public virtual T_ProjectModel Projects { get; set; }
    }
   /// <summary>
   /// 查询对象
   /// </summary>
   public class ProjectUserModel : Page
   {
       public int ProjectId { get; set; }
   }
}
