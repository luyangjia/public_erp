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
    public static class T_LogDTO
    {
        public static T_LogModel DTO(this T_Log node)
        {
            if (node == null)
                return null;
            var model = new T_LogModel()
            {
                Id = node.Id,
                StaffName = node.StaffName,
                Ip = node.Ip,
                LoginId = node.LoginId,
                Types = node.Types, 
                CreateTime=node.CreateTime,
            };
            return model;
        }

        public static IList<T_LogModel> DTOList(this IQueryable<T_Log> nodes)
        {
            if (nodes == null)
                return null;
            var result = nodes.ToList().Select(node => node.DTO()).ToList();
            return result;
        }

        public static T_Log ToModel(this T_LogModel node)
        {
            return new T_Log()
            {
                Id = node.Id,
                StaffName = node.StaffName,
                Ip=node.Ip,
                LoginId=node.LoginId,
                Types=node.Types, 
                 CreateTime=DateTime.Now,
            };
        }
    }
}
