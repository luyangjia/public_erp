using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{

    [Table("dbo.T_ProjectUser")]
    public partial class T_ProjectUser
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string CommissionType { get; set; } 
        public decimal Commission { get; set; } 
        [ForeignKey("ProjectId")]
        public virtual T_Project Projects { get; set; }
    }
}
