using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.DAL;
using MVC.Models;
using System.Linq.Expressions;
namespace MVC.BLL
{
    public static class T_SysListDTO
    {
        public static T_SysListModel DTO(this T_SysList node)
        {
            if (node == null)
                return null;
            var model = new T_SysListModel()
            {
                Id = node.Id,
                ParentId = node.ParentId,
                Remark = node.Remark,
                Name = node.Name,
                Listorder = node.Listorder,
                SysId = node.SysId, 
                ParSysList=node.ParSysList.DTO(),
                //ChildSysList=node.ChildSysList.Select(s=>s.DTO()).ToList(), //会卡死
            };
            return model;
        }

        public static IList<T_SysListModel> DTOList(this IQueryable<T_SysList> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }

        public static T_SysList ToModel(this  T_SysListModel node)
        {
            return new T_SysList()
            {
                Id = node.Id,
                ParentId = node.ParentId,
                Remark = node.Remark,
                Name = node.Name,
                Listorder = node.Listorder,
                SysId = node.SysId, 

            };
        }
    }
}
