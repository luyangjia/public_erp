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
    public static class T_DepartmentDTO
    {
        public static T_DepartmentModel DTO(this T_Department node)
        {
            if (node == null)
                return null;
            var model = new T_DepartmentModel()
            {
                Id = node.Id,
                Name = node.Name,
                CompanyId = node.CompanyId,
                UserId = node.UserId,
                UserName = node.UserName, 
             //   Company = node.Company != null ? node.Company.DTO() : null, //公司表中已经有部门的子集，这里不能添加这行代码
              //  Users = node.Users != null ? node.Users.Select(s=>s.DTO).ToList(): null,
                Users = node.Users.Count > 0 ? node.Users.ToList().Select(s => s.DTO()).ToList() : null,
              
            };
            return model;
        }

        public static IList<T_DepartmentModel> DTOList(this IQueryable<T_Department> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }

        public static T_Department ToModel(this T_DepartmentModel node)
        {
            return new T_Department()
            {
                Id = node.Id,
                Name = node.Name,
                CompanyId = node.CompanyId,
                UserId = node.UserId,
                UserName = node.UserName,
            };
        }
    }
}
