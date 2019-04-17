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
  public  class T_ClientModel
    {
       public string Action { get; set; }
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
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
        public virtual ICollection<T_ProjectModel> Projects { get; set; }
    }
  /// <summary>
  /// 查询对象
  /// </summary>
  public class ClientModel : Page
  {
      public string Name { get; set; }
  }
}
