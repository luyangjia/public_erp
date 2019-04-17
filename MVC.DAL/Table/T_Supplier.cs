﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{ 
    [Table("dbo.T_Supplier")]
    public partial class T_Supplier
    {
        public int Id { get; set; } 
        public string COGS { get; set; }
        public string COGS2 { get; set; }
        public int CategoryId { get; set; }
        public string Company { get; set; }
        public decimal? Rebates { get; set; }
        public string Cycle { get; set; }
        public string Collect { get; set; }
        public string Contact { get; set; }
        public string Hp { get; set; }
        public string Tel { get; set; }
        public string Tel2 { get; set; }
        public string Fax { get; set; }
        public string Fax2 { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public string BankNumber { get; set; }

        [ForeignKey("CategoryId")]
        public virtual T_SysList Category { get; set; }
        public virtual ICollection<T_Cost> Cost { get; set; }
    }
}
