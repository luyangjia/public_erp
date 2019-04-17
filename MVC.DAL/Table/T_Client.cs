using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{

    [Table("dbo.T_Client")]
    public partial class T_Client
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string  Name { get; set; }
        public string Company { get; set; }
        public string Race { get; set; }
        public string Nric { get; set; }
        public DateTime RegDate { get; set; } 
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; } 
        public string Fax { get; set; }   
        public string Blk { get; set; }
        public string StreetName { get; set; }
        public string BuildingName { get; set; }
        public string Unit { get; set; }
        public string PostalCode { get; set; }
        public string Sectors { get; set; }
        public bool Enable { get; set; }
        public virtual ICollection<T_Project> Projects { get; set; }
         
    }
}
