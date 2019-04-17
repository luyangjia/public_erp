using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{ 
    [Table("dbo.T_SysList")]
    public partial class T_SysList
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public int SysId { get; set; }
        public decimal Listorder { get; set; }
        public string Remark { get; set; }
        [ForeignKey("ParentId")]
        public virtual T_SysList ParSysList { get; set; }
        public virtual ICollection<T_SysList> ChildSysList { get; set; }
        public virtual ICollection<T_Supplier> Supplier { get; set; } 
        public virtual ICollection<T_Cost> Cost { get; set; }
       /// public virtual ICollection<T_User> Group { get; set; }
    }
}
