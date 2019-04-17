using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{

    [Table("dbo.T_Department")]
    public partial class T_Department
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; } 
        [ForeignKey("CompanyId")]
        public virtual T_Company Company { get; set; }
        /// <summary>
        /// 这个部门下的用户
        /// </summary>
        public virtual ICollection<T_User> Users { get; set; }

    }
}
