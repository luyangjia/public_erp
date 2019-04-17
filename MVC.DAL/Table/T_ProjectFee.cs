using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{

    [Table("dbo.T_ProjectFee")]
    public partial class T_ProjectFee
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int PayNo { get; set; }
        public string Remark { get; set; }
        public DateTime? PlanPayDate { get; set; }
        public DateTime? PayDate { get; set; }
        public decimal PlayFee { get; set; }
        public int Status { get; set; }
        [ForeignKey("ProjectId")]
        public virtual T_Project Projects { get; set; }
    }
}
