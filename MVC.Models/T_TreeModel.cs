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
    public class T_TreeModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set; }
        public string Name { get; set; }
        public string ChineseName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public bool Enable { get; set; }
        public string Keys { get; set; }
        public decimal Listorder { get; set; }
      
    }
    /// <summary>
    /// 菜单树
    /// </summary>
    public class T_TreeMenuModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string ChineseName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public bool Enable { get; set; }
        public string Keys { get; set; }
        public decimal Listorder { get; set; }
        public string iconCls { get; set; }
        
        public List<T_TreeMenuModel> children{ get; set; }
    }
    /// <summary>
    /// 下拉数
    /// </summary>
    public class T_TreeCombo
    { 
        public int id { get; set; } 
        public string text { get; set; } 
        public List<T_TreeCombo> children { get; set; }
    }
}
