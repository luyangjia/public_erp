using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{
    
    [Table("dbo.T_User")]
    public partial class T_User
    { 
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string StaffName { get; set; }
        public string Alias { get; set; }
        public string Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? Dateoined { get; set; }
        public DateTime? DateResignation { get; set; }
        public int? GroupId { get; set; }
        public string Position { get; set; } 
        public string Nationality { get; set; }
        public string Marital { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Blk { get; set; }
        public string StreetName { get; set; }
        public string BuildingName { get; set; }
        public string Unit { get; set; }
        public string PostalCode { get; set; }
        public bool Enable { get; set; }
        public string AcctCode { get; set; }
        public int CompanyId { get; set; }
         [ForeignKey("CompanyId")]
        public virtual T_Company Company { get; set; }
         public int RoleId { get; set; }
          [ForeignKey("RoleId")]
         public virtual T_Role Role { get; set; }
          [ForeignKey("GroupId")]
          public virtual T_Department Department { get; set; }

          public decimal? Salary { get; set; }
          public decimal? AppointmentAllowance { get; set; }
          public decimal? FixedAllowance { get; set; }
          public decimal? EmployerCpf { get; set; }
          public decimal? EmployeeCpf { get; set; }
          public string BankName { get; set; }
          public string BankNumber { get; set; }
          public decimal? Commission { get; set; }
    }
 

}
