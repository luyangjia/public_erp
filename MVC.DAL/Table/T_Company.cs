using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{

    [Table("dbo.T_Company")]
    public partial class T_Company
    {
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
        /// <summary>
        /// 该公司下的用户
        /// </summary>
        public virtual ICollection<T_User> Users { get; set; }
        public virtual ICollection<T_Project> Projects { get; set; }
        public virtual ICollection<T_Department> Departments { get; set; }

    }
}
