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
    public static class T_RoleDTO
    {
        public static T_RoleModel DTO(this T_Role node)
        {
            if (node == null)
                return null;
            var model = new T_RoleModel()
            {
                Id = node.Id,
                Name = node.Name,
                AccessKey = node.AccessKey,
            };
            return model;
        }

        public static IList<T_RoleModel> DTOList(this IQueryable<T_Role> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }

        public static T_Role ToModel(this T_RoleModel node)
        {
            return new T_Role()
            {
                Id = node.Id,
                 Name=node.Name,
                 AccessKey=node.AccessKey,
            };
        }
    }
}
