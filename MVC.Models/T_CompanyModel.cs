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
  public  class T_CompanyModel
    {
        public string Action { get; set; }
        public int Id { get; set; } 
        public string Company { get; set; }
        public string Alias { get; set; } 
        public string Address { get; set; }
        public string Logo { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Registration { get; set; }
        public decimal GST { get; set; }
        public string GSTReg { get; set; }
        public int? AgreementNo { get; set; }
        public string License { get; set; }
        public int? ReceiptNo { get; set; }
        public virtual ICollection<T_DepartmentModel> Departments { get; set; }
        public virtual ICollection<T_ProjectModel> Projects { get; set; }
    }
    /// <summary>
    /// 查询对象
    /// </summary>
  public class CompanyModel : Page
  {
      public string Company { get; set; }
  }
}
