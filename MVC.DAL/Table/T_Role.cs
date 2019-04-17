using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{ 
    [Table("dbo.T_Role")]
    public partial class T_Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccessKey { get; set; }
        public virtual ICollection<T_User> Users { get; set; }
    }
}
