using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{

    [Table("dbo.T_Project")] 
     public partial class T_Project
    {
        public T_Project()
        {
            ProjectUsers = new HashSet<T_ProjectUser>();
            ProjectPlans = new HashSet<T_ProjectPlan>();
            ProjectFees = new HashSet<T_ProjectFee>();
            ProjectAgrees = new HashSet<T_Agree>();
        }
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public int? ClientId { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public DateTime? VisitDate { get; set; }
        public string Property { get; set; }
        public string Towi { get; set; }
        public string ProjectType { get; set; }
        public DateTime? BeginDate { get; set; }  
        public DateTime? EndDate { get; set; }
        public string Blk { get; set; }
        public string StreetName { get; set; }
        public string BuildingName { get; set; }
        public string Unit { get; set; }
        public string PostalCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        [ForeignKey("CompanyId")]
        public virtual T_Company Company { get; set; }
        [ForeignKey("ClientId")]
        public virtual T_Client Client { get; set; }
        public virtual ICollection<T_ProjectUser> ProjectUsers { get; set; }
        public virtual ICollection<T_ProjectPlan> ProjectPlans { get; set; }
        public virtual ICollection<T_ProjectFee> ProjectFees { get; set; }
        public virtual ICollection<T_Agree> ProjectAgrees { get; set; }
    }
}
