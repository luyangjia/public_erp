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
   public static class T_TreeDTO
    {
       public static T_TreeModel DTO(this T_Tree node)
        {
            if (node == null)
                return null;
            var model = new T_TreeModel()
            {
                Id = node.Id,
                ChineseName = node.ChineseName,
                Name = node.Name,
                ParentId = node.ParentId,
                Url = node.Url,
                Icon = node.Icon,
                Enable = node.Enable,
                Keys = node.Keys,
                Listorder = node.Listorder,
                
            };
            return model;
        }

       public static IList<T_TreeModel> DTOList(this IQueryable<T_Tree> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }

       public static T_Tree ToModel(this  T_TreeModel node)
        {
            return new T_Tree()
            {
                Id = node.Id,
                ChineseName = node.ChineseName,
                Icon = node.Icon,
                Enable = node.Enable,
                Keys = node.Keys,
                Listorder = node.Listorder,
                Name = node.Name,
                ParentId = node.ParentId == 0 ? null : node.ParentId,
                Url = node.Url,

            };
        }
    }
}
