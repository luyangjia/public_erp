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
    public class T_SysListModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public int SysId { get; set; }
        public decimal Listorder { get; set; }
        public string Remark { get; set; }
        public virtual T_SysListModel ParSysList { get; set; }
        public virtual ICollection<T_SysListModel> ChildSysList { get; set; }
    }
    public class T_TreeSysListModel
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; } 
        public int SysId { get; set; }
        public decimal Listorder { get; set; }
        public string Remark { get; set; }
        public int Rank { get; set; }
        public List<T_TreeSysListModel> children { get; set; }
        /// <summary>
        /// 下拉框用
        /// </summary>
        public string id { get; set; }
        public string text { get; set; }
        /// <summary>
        /// 分组下拉用
        /// </summary>
        public string group { get; set; }
         /// <summary>
        /// 下拉框用扩展信息
        /// </summary>
       public string Blk { get; set; }
        public string BuildingName { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
         public string Unit { get; set; }
         public string Mobile { get; set; }
         public string Phone { get; set; }
        /// <summary>
        /// 假期下拉框用，已用掉的假期天数 ,空不显示
        /// </summary>
         public decimal?  UseDays { get; set; }
         /// <summary>
         /// 假期下拉框用，剩余的假期天数，空不显示
         /// </summary>
         public decimal? RemainingDays { get; set; } 
         
    }
    /// <summary>
    /// 获得该节点的父级节点
    /// </summary>
    public class T_ParentSysListModel
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set; }

        public List<T_ParentSysListModel> Parent { get; set; }
      

    }
   

}
