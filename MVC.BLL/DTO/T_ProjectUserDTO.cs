using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.DAL;
using MVC.Models;
using MVC.Helper;
using System.Linq.Expressions;
namespace MVC.BLL
{
    public static class T_ProjectUserDTO
    {
        public static T_ProjectUserModel DTO(this T_ProjectUser node)
        {
            if (node == null)
                return null;
            var model = new T_ProjectUserModel()
            {
                Id = node.Id,
                ProjectId = node.ProjectId,
                Commission = node.Commission,
                CommissionType = node.CommissionType,
                Role = node.Role,
                UserId = node.UserId,
                UserName = node.UserName,

            };
            return model;
        }

        public static IList<T_ProjectUserModel> DTOList(this IQueryable<T_ProjectUser> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }




        public static T_ProjectUser ToModel(this  T_ProjectUserModel node)
        {
            return new T_ProjectUser()
            {
                Id = node.Id,
                ProjectId = node.ProjectId,
                Commission = node.Commission,
                CommissionType = node.CommissionType,
                Role = node.Role,
                UserId = node.UserId,
                UserName = node.UserName,
            };
        }

    }
}

