using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.DAL
{

    [Table("dbo.T_Tree")]
    public partial class T_Tree
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string ChineseName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public bool Enable { get; set; }
        public string Keys { get; set; }
        public decimal Listorder { get; set; }
     
      
    }
}
