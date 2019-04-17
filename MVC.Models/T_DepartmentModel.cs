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
    public class T_DepartmentModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public virtual T_CompanyModel Company { get; set; }
        /// <summary>
        /// 这个部门下的用户
        /// </summary>
        public virtual ICollection<T_UserModel> Users { get; set; }
    }
    /// <summary>
    /// 查询对象
    /// </summary>
    public class DepartmentModel : Page
    {
    }
}
