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
    public class T_SysModel
    {
        public string Action { get; set; }
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Remark { get; set; }
        public decimal Listorder { get; set; } 
    }
}
